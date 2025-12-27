using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PagueiBaratoApi.Domain.Entities;

namespace PagueiBaratoApi.Infrastructure.Setup.Configurations;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.Property(x => x.Nome)
            .HasMaxLength(96);

        builder.HasOne(x => x.Marca)
            .WithMany()
            .HasForeignKey(x => x.MarcaId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Categorias)
            .WithMany()
            .UsingEntity<ProdutoCategoria>();

        builder.Property(x => x.Atributos)
            .HasColumnType("jsonb");

        builder.HasOne(x => x.CriadoPor)
            .WithMany()
            .HasForeignKey(x => x.CriadoPorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.CriadoEm)
            .HasDefaultValueSql("NOW()");
    }
}
