using System.Text;
using Microsoft.EntityFrameworkCore;
using PagueiBaratoApi.Domain.Dtos.Busca;
using PagueiBaratoApi.Infrastructure.Repository.Interfaces;
using PagueiBaratoApi.Infrastructure.Setup;

namespace PagueiBaratoApi.Infrastructure.Repository;

public class BuscaRepository : IBuscaRepository
{
    private readonly DatabaseContext _dbContext;

    public BuscaRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<BuscaCatalogoResponseDto> BuscarAsync(BuscaCatalogoRequestDto filtros)
    {
        var where = new StringBuilder("1 = 1");
        var parameters = new List<object>();
        int pIndex = 0;

        void AddFilter(string column, object? value, bool ehLista = false)
        {
            if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
            {
                where.Append(ehLista
                    ? $" AND \"{column}\" @> ARRAY[{{{pIndex}}}]::text[]"
                    : $" AND \"{column}\" = {{{pIndex}}}");
                pIndex++;
                parameters.Add(value);
            }
        }

        AddFilter("Tipo", filtros.Tipo);
        AddFilter("Categorias", filtros.Categoria, ehLista: true);
        AddFilter("Marca", filtros.Marca);
        AddFilter("Ramos", filtros.Ramo, ehLista: true);
        AddFilter("Cidades", filtros.Cidade, ehLista: true);
        AddFilter("Estados", filtros.Estado, ehLista: true);
        AddFilter("Bairros", filtros.Bairro, ehLista: true);

        string orderClause = "ORDER BY \"Nome\" ASC";

        if (!string.IsNullOrWhiteSpace(filtros.Termo))
        {
            where.Append($" AND (\"SearchVector\" @@ websearch_to_tsquery('portuguese', {{{pIndex}}})");
            where.Append($" OR similarity(lower(\"Nome\"), lower({{{pIndex}}})) > 0.10");
            where.Append($" OR similarity(lower(\"SearchText\"), lower({{{pIndex}}})) > 0.08)");
            
            orderClause = $"ORDER BY ts_rank_cd(\"SearchVector\", websearch_to_tsquery('portuguese', {{{pIndex}}})) DESC, similarity(lower(\"Nome\"), lower({{{pIndex}}})) DESC";
            
            parameters.Add(filtros.Termo);
            pIndex++;
        }

        // 1. Contagem total de itens filtrados
        var baseSql = $"SELECT * FROM public.vw_BuscaCatalogo WHERE {where}";
        var totalItens = await _dbContext.BuscaCatalogoView
            .FromSqlRaw(baseSql, parameters.ToArray())
            .CountAsync();

        // 2. Consulta dos itens paginados
        var offset = (filtros.Pagina - 1) * filtros.TamanhoPagina;
        var pagedParameters = new List<object>(parameters)
        {
            filtros.TamanhoPagina,
            offset
        };
        var pagedSql = $"SELECT * FROM public.vw_BuscaCatalogo WHERE {where} {orderClause} LIMIT {{{pIndex}}} OFFSET {{{pIndex + 1}}}";
        var itens = await _dbContext.BuscaCatalogoView
            .FromSqlRaw(pagedSql, pagedParameters.ToArray())
            .ToListAsync();

        // Cada faceta ignora o proprio filtro para manter os demais valores disponiveis.
        var definicoesFacetas = new (string Nome, string Coluna, bool Multivalorado)[]
        {
            ("Categoria", "Categorias", true),
            ("Marca", "Marca", false),
            ("Ramo", "Ramos", true),
            ("Tipo", "Tipo", false),
            ("Cidade", "Cidades", true),
            ("Estado", "Estados", true),
            ("Bairro", "Bairros", true)
        };
        var parametrosFacetas = new List<object>();
        var consultasFacetas = new List<string>();

        foreach (var (nome, coluna, multivalorado) in definicoesFacetas)
        {
            var filtroFaceta = new StringBuilder("1 = 1");

            foreach (var (colunaFiltro, valorFiltro, filtroMultivalorado) in new (string Coluna, string? Valor, bool Multivalorado)[]
            {
                ("Tipo", filtros.Tipo, false),
                ("Categorias", filtros.Categoria, true),
                ("Marca", filtros.Marca, false),
                ("Ramos", filtros.Ramo, true),
                ("Cidades", filtros.Cidade, true),
                ("Estados", filtros.Estado, true),
                ("Bairros", filtros.Bairro, true)
            })
            {
                if (colunaFiltro == coluna || string.IsNullOrWhiteSpace(valorFiltro))
                    continue;

                filtroFaceta.Append(filtroMultivalorado
                    ? $" AND \"{colunaFiltro}\" @> ARRAY[{{{parametrosFacetas.Count}}}]::text[]"
                    : $" AND \"{colunaFiltro}\" = {{{parametrosFacetas.Count}}}");
                parametrosFacetas.Add(valorFiltro);
            }

            if (!string.IsNullOrWhiteSpace(filtros.Termo))
            {
                var indiceTermo = parametrosFacetas.Count;
                filtroFaceta.Append($" AND (\"SearchVector\" @@ websearch_to_tsquery('portuguese', {{{indiceTermo}}})");
                filtroFaceta.Append($" OR similarity(lower(\"Nome\"), lower({{{indiceTermo}}})) > 0.10");
                filtroFaceta.Append($" OR similarity(lower(\"SearchText\"), lower({{{indiceTermo}}})) > 0.08)");
                parametrosFacetas.Add(filtros.Termo);
            }

            var consultaFaceta = multivalorado
                ? $"SELECT '{nome}'::text AS Faceta, valores.Valor::text AS Valor, COUNT(*)::integer AS Total FROM public.vw_BuscaCatalogo CROSS JOIN LATERAL unnest(\"{coluna}\") AS valores(Valor) WHERE {filtroFaceta} AND valores.Valor <> '' GROUP BY valores.Valor"
                : $"SELECT '{nome}'::text AS Faceta, \"{coluna}\"::text AS Valor, COUNT(*)::integer AS Total FROM public.vw_BuscaCatalogo WHERE {filtroFaceta} AND \"{coluna}\" IS NOT NULL AND \"{coluna}\" <> '' GROUP BY \"{coluna}\"";
            consultasFacetas.Add(consultaFaceta);
        }

        var facetasSql = string.Join(" UNION ALL ", consultasFacetas);

        var facetas = await _dbContext.BuscaFacetaView
            .FromSqlRaw(facetasSql, parametrosFacetas.ToArray())
            .ToListAsync();

        return new BuscaCatalogoResponseDto
        {
            // Mapeia apenas ItemId, Nome e ImagemPath na resposta final
            Itens = itens.Select(x => new BuscaCatalogoDto
            {
                ItemId = x.ItemId,
                Tipo = x.Tipo,
                Nome = x.Nome,
                ImagemPath = x.ImagemPath
            }),
            Facetas = facetas.Select(x => new BuscaFacetaDto
            {
                Faceta = x.Faceta,
                Valor = x.Valor,
                Total = x.Total
            }),
            Pagina = filtros.Pagina,
            TamanhoPagina = filtros.TamanhoPagina,
            TotalItens = totalItens
        };
    }
}
