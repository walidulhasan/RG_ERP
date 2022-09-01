using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.AlgoHR.Setup;

namespace RG.Infrastructure.Persistence.AlgoHRDB.Configurations.ajt
{
    public class ApprovalConfigDetailConfiguration : IEntityTypeConfiguration<ApprovalConfigDetail>
    {
        public void Configure(EntityTypeBuilder<ApprovalConfigDetail> builder)
        {
            builder.HasKey(b => b.ConfigDetailID);
            builder.ToTable("ApprovalConfigDetail", "ajt");
        }
    }
}
