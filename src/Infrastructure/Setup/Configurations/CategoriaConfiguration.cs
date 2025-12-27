using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PagueiBaratoApi.Domain.Entities;

namespace PagueiBaratoApi.Infrastructure.Setup.Configurations;

public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.Property(x => x.Nome)
            .HasMaxLength(96);

        builder.HasOne(x => x.CriadoPor)
            .WithMany()
            .HasForeignKey(x => x.CriadoPorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.CriadoEm)
            .HasDefaultValueSql("NOW()");
    }
}
