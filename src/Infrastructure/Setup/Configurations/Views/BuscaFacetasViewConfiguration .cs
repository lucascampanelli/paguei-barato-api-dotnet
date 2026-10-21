using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PagueiBaratoApi.Domain.Entities.Views;

namespace PagueiBaratoApi.Infrastructure.Setup.Configurations.Views;

public class BuscaFacetaViewConfiguration : IEntityTypeConfiguration<BuscaFacetaView>
{
    public void Configure(EntityTypeBuilder<BuscaFacetaView> builder)
    {
        builder.ToView("BuscaFacetasView");

        builder.HasNoKey();
    }
}