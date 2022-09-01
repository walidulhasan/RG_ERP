using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.FiniteScheduler.Business;

namespace RG.Infrastructure.Persistence.FiniteSchedulerDB.Configurations.ajt
{
    public class AssetAttributeAssociationConfiguration : IEntityTypeConfiguration<AssetAttributeAssociation>
    {
        public void Configure(EntityTypeBuilder<AssetAttributeAssociation> builder)
        {
            builder.HasKey(b => b.AssociationID);

            builder.ToTable("AssetAttributeAssociation", "ajt");
        }
    }
}
