using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PagueiBaratoApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CriaViewBuscaCatalogo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE EXTENSION IF NOT EXISTS pg_trgm;");

            migrationBuilder.Sql(@"
                CREATE MATERIALIZED VIEW public.vw_BuscaCatalogo AS
                SELECT
                    p.""Id""                                    AS ""ItemId"",
                    'produto'::text                             AS ""Tipo"",
                    p.""Nome""                                  AS ""Nome"",
                    p.""ImagemPath"",
                    p.""MarcaId"",
                    m.""Nome""                                  AS ""Marca"",
                    COALESCE(c.""Valores"", ARRAY[]::text[])    AS ""Categorias"",
                    ARRAY[]::text[]                             AS ""Ramos"",
                    ARRAY[]::text[]                             AS ""Cidades"",
                    ARRAY[]::text[]                             AS ""Estados"",
                    ARRAY[]::text[]                             AS ""Bairros"",
                    lower(
                        concat_ws(' ',
                            p.""Nome"",
                            m.""Nome"",
                            p.""Atributos""::text,
                            array_to_string(c.""Valores"", ' ')
                        )
                    )                                           AS ""SearchText"",
                    to_tsvector('portuguese',
                        concat_ws(' ',
                            p.""Nome"",
                            m.""Nome"",
                            p.""Atributos""::text,
                            array_to_string(c.""Valores"", ' ')
                        )
                    )                                           AS ""SearchVector""
                FROM ""Produtos"" p
                LEFT JOIN ""Marcas"" m ON m.""Id"" = p.""MarcaId""
                LEFT JOIN LATERAL (
                    SELECT array_agg(DISTINCT c.""Nome"") AS ""Valores""
                    FROM ""ProdutoCategoria"" pc
                    JOIN ""Categorias"" c ON c.""Id"" = pc.""CategoriaId""
                    WHERE pc.""ProdutoId"" = p.""Id""
                ) c ON TRUE

                UNION ALL

                SELECT
                    l.""Id""                                    AS ""ItemId"",
                    'loja'::text                                AS ""Tipo"",
                    l.""Nome""                                  AS ""Nome"",
                    l.""ImagemPath"",
                    NULL::integer                               AS ""MarcaId"",
                    NULL::text                                  AS ""Marca"",
                    ARRAY[]::text[]                             AS ""Categorias"",
                    COALESCE(r.""Valores"", ARRAY[]::text[])    AS ""Ramos"",
                    CASE WHEN NULLIF(l.""Cidade"", '') IS NULL THEN ARRAY[]::text[] ELSE ARRAY[l.""Cidade""] END AS ""Cidades"",
                    CASE WHEN NULLIF(l.""Estado"", '') IS NULL THEN ARRAY[]::text[] ELSE ARRAY[l.""Estado""] END AS ""Estados"",
                    CASE WHEN NULLIF(l.""Bairro"", '') IS NULL THEN ARRAY[]::text[] ELSE ARRAY[l.""Bairro""] END AS ""Bairros"",
                    lower(
                        concat_ws(' ',
                            l.""Nome"",
                            l.""Logradouro"",
                            l.""Bairro"",
                            l.""Cidade"", 
                            l.""Estado"",
                            array_to_string(r.""Valores"", ' ')
                        )
                    )                                           AS ""SearchText"",
                    to_tsvector('portuguese',
                        concat_ws(' ',
                            l.""Nome"",
                            l.""Logradouro"",
                            l.""Bairro"",
                            l.""Cidade"",
                            l.""Estado"",
                            array_to_string(r.""Valores"", ' ')
                        )
                    )                                           AS ""SearchVector""
                FROM ""Lojas"" l
                LEFT JOIN LATERAL (
                    SELECT array_agg(DISTINCT r.""Nome"") AS ""Valores""
                    FROM ""LojaRamo"" lr
                    JOIN ""Ramos"" r ON r.""Id"" = lr.""RamoId""
                    WHERE lr.""LojaId"" = l.""Id""
                ) r ON TRUE;
            ");

            migrationBuilder.Sql(@"
                CREATE UNIQUE INDEX vw_BuscaCatalogo_pk_idx ON public.vw_BuscaCatalogo (""ItemId"", ""Tipo"");
            ");

            migrationBuilder.Sql(@"
                CREATE INDEX vw_BuscaCatalogo_search_idx ON public.vw_BuscaCatalogo USING gin (""SearchVector"");
                CREATE INDEX vw_BuscaCatalogo_trgm_nome_idx ON public.vw_BuscaCatalogo USING gin (""Nome"" gin_trgm_ops);
                CREATE INDEX vw_BuscaCatalogo_trgm_searchtext_idx ON public.vw_BuscaCatalogo USING gin (""SearchText"" gin_trgm_ops);
                CREATE INDEX vw_BuscaCatalogo_categorias_idx ON public.vw_BuscaCatalogo USING gin (""Categorias"");
                CREATE INDEX vw_BuscaCatalogo_marca_idx ON public.vw_BuscaCatalogo (""Marca"");
                CREATE INDEX vw_BuscaCatalogo_ramos_idx ON public.vw_BuscaCatalogo USING gin (""Ramos"");
                CREATE INDEX vw_BuscaCatalogo_tipo_idx ON public.vw_BuscaCatalogo (""Tipo"");
                CREATE INDEX vw_BuscaCatalogo_cidades_idx ON public.vw_BuscaCatalogo USING gin (""Cidades"");
                CREATE INDEX vw_BuscaCatalogo_estados_idx ON public.vw_BuscaCatalogo USING gin (""Estados"");
                CREATE INDEX vw_BuscaCatalogo_bairros_idx ON public.vw_BuscaCatalogo USING gin (""Bairros"");
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP MATERIALIZED VIEW IF EXISTS public.vw_BuscaCatalogo;");
        }
    }
}
