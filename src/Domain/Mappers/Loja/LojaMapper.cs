using PagueiBaratoApi.Domain.Dtos.Loja;
using PagueiBaratoApi.Domain.Mappers.Ramo;

namespace PagueiBaratoApi.Domain.Mappers.Loja;

public static class LojaMapper
{
    public static LojaDetalhesDto ToDetalhesDto(this Entities.Loja loja)
    {
        return new LojaDetalhesDto
        {
            Id = loja.Id,
            Nome = loja.Nome,
            Ramos = loja.Ramos.Select(x => x.ToResponseDto()).ToList(),
            Logradouro = loja.Logradouro,
            Numero = loja.Numero,
            Bairro = loja.Bairro,
            Cidade = loja.Cidade,
            Estado = loja.Estado,
            Cep = loja.Cep,
            ImagemPath = loja.ImagemPath,
            CriadoEm = loja.CriadoEm
        };
    }

    public static LojaResponseDto ToResponseDto(this LojaDetalhesDto loja, string? imagemUrl)
    {
        return new LojaResponseDto
        {
            Id = loja.Id,
            Nome = loja.Nome,
            Ramos = loja.Ramos,
            Logradouro = loja.Logradouro,
            Numero = loja.Numero,
            Bairro = loja.Bairro,
            Cidade = loja.Cidade,
            Estado = loja.Estado,
            Cep = loja.Cep,
            ImagemUrl = imagemUrl ?? string.Empty,
            CriadoEm = loja.CriadoEm
        };
    }
}
