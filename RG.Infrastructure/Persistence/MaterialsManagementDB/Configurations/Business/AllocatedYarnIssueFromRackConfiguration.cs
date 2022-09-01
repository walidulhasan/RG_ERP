using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.MaterialsManagement.Business;

namespace RG.Infrastructure.Persistence.MaterialsManagementDB.Configurations.Business
{
    public class AllocatedYarnIssueFromRackConfiguration : IEntityTypeConfiguration<AllocatedYarnIssueFromRack>
    {
        public void Configure(EntityTypeBuilder<AllocatedYarnIssueFromRack> builder)
        {
            builder.ToTable("AllocatedYarnIssueFromRack", "ajt");
            builder.HasKey(e => e.IssuanceID);
        }
    }
}
