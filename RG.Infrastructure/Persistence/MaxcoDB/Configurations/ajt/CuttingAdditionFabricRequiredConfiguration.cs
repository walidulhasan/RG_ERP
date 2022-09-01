using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.Maxco.Setup;

namespace RG.Infrastructure.Persistence.MaxcoDB.Configurations.ajt
{
    public class CuttingAdditionFabricRequiredConfiguration : IEntityTypeConfiguration<CuttingAdditionFabricRequired>
    {
        public void Configure(EntityTypeBuilder<CuttingAdditionFabricRequired> builder)
        {
            builder.HasKey(b => b.ID);
            builder.ToTable("CuttingAdditionFabricRequired", "ajt");
        }
    }
}
