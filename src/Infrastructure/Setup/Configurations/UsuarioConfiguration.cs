using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PagueiBaratoApi.Domain.Entidades;

namespace PagueiBaratoApi.Infrastructure.Setup.Configurations;

public class UsuariosConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.Property(x => x.CriadoEm)
            .HasDefaultValueSql("NOW()");
    }
}
