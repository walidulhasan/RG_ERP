using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.FiniteScheduler.DBViews;

namespace RG.Infrastructure.Persistence.FiniteSchedulerDB.Configurations.DbViews
{
    public class VW_BuildingInfoConfiguration : IEntityTypeConfiguration<VW_BuildingInfo>
    {
        public void Configure(EntityTypeBuilder<VW_BuildingInfo> builder)
        {
            builder.HasKey(x=>x.BuildingFloorID);
            builder.ToTable("VW_BuildingInfo", "ajt");
        }
    }
}