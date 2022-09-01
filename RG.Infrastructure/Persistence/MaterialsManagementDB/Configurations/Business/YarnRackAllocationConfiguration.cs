using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.MaterialsManagement.Business;

namespace RG.Infrastructure.Persistence.MaterialsManagementDB.Configurations.Business
{

    public class YarnRackAllocationConfiguration : IEntityTypeConfiguration<YarnRackAllocation>
    {
        public void Configure(EntityTypeBuilder<YarnRackAllocation> builder)
        {
            builder.ToTable("YarnRackAllocation", "ajt");
            builder.HasKey(e => e.RackAllocationID);
        }
    }
}
