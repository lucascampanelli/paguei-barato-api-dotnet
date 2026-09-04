using Microsoft.EntityFrameworkCore;
using PagueiBaratoApi.Domain.Dtos.Produto;
using PagueiBaratoApi.Domain.Mappers.Produto;
using PagueiBaratoApi.Infrastructure.Repository.Interfaces;
using PagueiBaratoApi.Infrastructure.Setup;

namespace PagueiBaratoApi.Infrastructure.Repository;

public class ProdutoRepository : IProdutoRepository
{
    private readonly DatabaseContext _dbContext;

    public ProdutoRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ProdutoDetalhesDto?> ObterPorIdAsync(int id)
    {
        var produtoEntity = await _dbContext.Produtos
            .Include(x => x.Categorias)
            .Include(x => x.Marca)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (produtoEntity == null)
            return null;

        return produtoEntity.ToDetalhesDto();
    }
}