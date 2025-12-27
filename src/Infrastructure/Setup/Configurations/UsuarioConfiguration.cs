using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PagueiBaratoApi.Domain.Entities;

namespace PagueiBaratoApi.Infrastructure.Setup.Configurations;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.Property(x => x.Nome)
            .HasMaxLength(160);

        builder.Property(x => x.Email)
            .HasMaxLength(160);

        builder.Property(x => x.Cep)
            .IsRequired(false)
            .HasMaxLength(9);

        builder.Property(x => x.CriadoEm)
            .HasDefaultValueSql("NOW()");
    }
}
