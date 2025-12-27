using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PagueiBaratoApi.Domain.Entities;

namespace PagueiBaratoApi.Infrastructure.Setup.Configurations;

public class RelatoConfiguration : IEntityTypeConfiguration<Relato>
{
    public void Configure(EntityTypeBuilder<Relato> builder)
    {
        builder.HasOne(x => x.Estoque)
            .WithMany()
            .HasForeignKey(x => x.EstoqueId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.CriadoPor)
            .WithMany()
            .HasForeignKey(x => x.CriadoPorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.CriadoEm)
            .HasDefaultValueSql("NOW()");
    }
}
