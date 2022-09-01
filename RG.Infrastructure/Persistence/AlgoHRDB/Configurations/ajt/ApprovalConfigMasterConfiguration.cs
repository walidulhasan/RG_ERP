using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.AlgoHR.Setup;

namespace RG.Infrastructure.Persistence.AlgoHRDB.Configurations.ajt
{
    public class ApprovalConfigMasterConfiguration : IEntityTypeConfiguration<ApprovalConfigMaster>
    {
        public void Configure(EntityTypeBuilder<ApprovalConfigMaster> builder)
        {
            builder.HasKey(b => b.ConfigMasterID);
            builder.ToTable("ApprovalConfigMaster", "ajt");
        }
    }
}
