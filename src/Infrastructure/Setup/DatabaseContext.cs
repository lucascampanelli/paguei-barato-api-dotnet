using Microsoft.EntityFrameworkCore;
using PagueiBaratoApi.Domain.Entities;
using PagueiBaratoApi.Infrastructure.Setup.Configurations;

namespace PagueiBaratoApi.Infrastructure.Setup;

public class DatabaseContext : DbContext
{
    public virtual DbSet<Categoria> Categorias { get; set; }
    public virtual DbSet<Estoque> Estoques { get; set; }
    public virtual DbSet<Loja> Lojas { get; set; }
    public virtual DbSet<Marca> Marcas { get; set; }
    public virtual DbSet<Produto> Produtos { get; set; }
    public virtual DbSet<Ramo> Ramos { get; set; }
    public virtual DbSet<Relato> Relatos { get; set; }
    public virtual DbSet<Usuario> Usuarios { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CategoriaConfiguration());
        modelBuilder.ApplyConfiguration(new EstoqueConfiguration());
        modelBuilder.ApplyConfiguration(new LojaConfiguration());
        modelBuilder.ApplyConfiguration(new MarcaConfiguration());
        modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
        modelBuilder.ApplyConfiguration(new RamoConfiguration());
        modelBuilder.ApplyConfiguration(new RelatoConfiguration());
        modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
    }
}
