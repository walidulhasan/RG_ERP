using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.FiniteScheduler.Business;

namespace RG.Infrastructure.Persistence.FiniteSchedulerDB.Configurations.ajt
{
    public class AssetAttributeConfiguration : IEntityTypeConfiguration<AssetAttribute>
    {
        public void Configure(EntityTypeBuilder<AssetAttribute> builder)
        {
            builder.HasKey(b => b.AttributeID);

            builder.ToTable("AssetAttribute", "ajt");
        }
    }
}
