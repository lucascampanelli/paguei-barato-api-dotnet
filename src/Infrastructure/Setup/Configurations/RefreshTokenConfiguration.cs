using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PagueiBaratoApi.Domain.Entities;

namespace PagueiBaratoApi.Infrastructure.Setup.Configurations;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.HasIndex(x => new { x.Token, x.UsuarioId })
            .IsUnique();

        builder.HasOne(x => x.Usuario)
            .WithOne(x => x.RefreshToken)
            .HasForeignKey<RefreshToken>(x => x.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
