using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PagueiBaratoApi.Domain.Entidades;

namespace PagueiBaratoApi.Infrastructure.Setup.Configurations;

public class EstoqueConfiguration : IEntityTypeConfiguration<Estoque>
{
    public void Configure(EntityTypeBuilder<Estoque> builder)
    {
        builder.HasOne(e => e.Produto)
            .WithMany()
            .HasForeignKey(e => e.ProdutoId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Loja)
            .WithMany()
            .HasForeignKey(e => e.LojaId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.CriadoPor)
            .WithMany()
            .HasForeignKey(e => e.CriadoPorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(e => e.CriadoEm)
            .HasDefaultValueSql("NOW()");
    }
}
