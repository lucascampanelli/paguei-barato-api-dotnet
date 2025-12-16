using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PagueiBaratoApi.Domain.Entidades;

namespace PagueiBaratoApi.Infrastructure.Setup.Configurations;

public class IndicacaoConfiguration : IEntityTypeConfiguration<Indicacao>
{
    public void Configure(EntityTypeBuilder<Indicacao> builder)
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
