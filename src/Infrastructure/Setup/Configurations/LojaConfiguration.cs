using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PagueiBaratoApi.Domain.Entidades;

namespace PagueiBaratoApi.Infrastructure.Setup.Configurations;

public class LojaConfiguration : IEntityTypeConfiguration<Loja>
{
    public void Configure(EntityTypeBuilder<Loja> builder)
    {
        builder.Property(x => x.Nome)
            .HasMaxLength(96);

        builder.HasMany(x => x.Ramos)
            .WithMany()
            .UsingEntity<LojaRamo>();

        builder.Property(x => x.Logradouro)
            .HasMaxLength(96);
        
        builder.Property(x => x.Numero)
            .HasMaxLength(6);

        builder.Property(x => x.Bairro)
            .HasMaxLength(96);

        builder.Property(x => x.Cidade)
            .HasMaxLength(96);

        builder.Property(x => x.Estado)
            .HasMaxLength(2);

        builder.Property(x => x.Cep)
            .HasMaxLength(9);

        builder.HasOne(x => x.CriadoPor)
            .WithMany()
            .HasForeignKey(x => x.CriadoPorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.CriadoEm)
            .HasDefaultValueSql("NOW()");
    }
}
