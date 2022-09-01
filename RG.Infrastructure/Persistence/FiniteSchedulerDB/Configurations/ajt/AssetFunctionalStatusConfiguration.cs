using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.FiniteScheduler.Setup;

namespace RG.Infrastructure.Persistence.FiniteSchedulerDB.Configurations.ajt
{
    public class AssetFunctionalStatusConfiguration : IEntityTypeConfiguration<AssetFunctionalStatus>
    {

        public void Configure(EntityTypeBuilder<AssetFunctionalStatus> builder)
        {
            builder.HasKey(b => b.StatusID);

            builder.ToTable("AssetFunctionalStatus", "ajt");
        }
    }
}