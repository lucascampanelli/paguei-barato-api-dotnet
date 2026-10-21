using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PagueiBaratoApi.Domain.Entities.Views;

namespace PagueiBaratoApi.Infrastructure.Setup.Configurations.Views;

public class BuscaCatalogoViewConfiguration : IEntityTypeConfiguration<BuscaCatalogoView>
{
    public void Configure(EntityTypeBuilder<BuscaCatalogoView> builder)
    {
        builder.ToView("vw_BuscaCatalogo", "public");

        builder.HasNoKey();
    }
}
