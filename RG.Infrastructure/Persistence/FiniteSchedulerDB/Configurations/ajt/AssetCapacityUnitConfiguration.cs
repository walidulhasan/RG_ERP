using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.FiniteScheduler.Setup;

namespace RG.Infrastructure.Persistence.FiniteSchedulerDB.Configurations.ajt
{
    public class AssetCapacityUnitConfiguration : IEntityTypeConfiguration<AssetCapacityUnit>
    {

        public void Configure(EntityTypeBuilder<AssetCapacityUnit> builder)
        {
            builder.HasKey(b => b.CapacityUnitID);

            builder.ToTable("AssetCapacityUnit", "ajt");
        }
    }
}