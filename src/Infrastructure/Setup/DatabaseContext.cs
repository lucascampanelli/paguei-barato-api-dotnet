using Microsoft.EntityFrameworkCore;
using PagueiBaratoApi.Domain.Entidades;

namespace PagueiBaratoApi.Infrastructure.Setup;

public class DatabaseContext : DbContext
{
    public virtual DbSet<Categoria> Categorias { get; set; }
    public virtual DbSet<Estoque> Estoques { get; set; }
    public virtual DbSet<Indicacao> Indicacoes { get; set; }
    public virtual DbSet<Loja> Lojas { get; set; }
    public virtual DbSet<Marca> Marcas { get; set; }
    public virtual DbSet<Produto> Produtos { get; set; }
    public virtual DbSet<Ramo> Ramos { get; set; }
    public virtual DbSet<Usuario> Usuarios { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
    }
}
