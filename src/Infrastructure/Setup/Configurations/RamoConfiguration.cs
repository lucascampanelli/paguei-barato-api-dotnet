using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PagueiBaratoApi.Domain.Entities;

namespace PagueiBaratoApi.Infrastructure.Setup.Configurations;

public class RamoConfiguration : IEntityTypeConfiguration<Ramo>
{
    public void Configure(EntityTypeBuilder<Ramo> builder)
    {
        builder.Property(x => x.Nome)
            .HasMaxLength(96);

        builder.Property(x => x.Descricao)
            .HasMaxLength(144);

        builder.HasOne(x => x.CriadoPor)
            .WithMany()
            .HasForeignKey(x => x.CriadoPorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.CriadoEm)
            .HasDefaultValueSql("NOW()");
    }
}
