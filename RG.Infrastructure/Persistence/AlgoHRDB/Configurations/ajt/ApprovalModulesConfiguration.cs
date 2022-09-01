using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.AlgoHR.Setup;

namespace RG.Infrastructure.Persistence.AlgoHRDB.Configurations.ajt
{
    public class ApprovalModulesConfiguration : IEntityTypeConfiguration<ApprovalModules>
    {
        public void Configure(EntityTypeBuilder<ApprovalModules> builder)
        {
            builder.HasKey(b => b.ApprovalModuleID);
            builder.ToTable("ApprovalModules", "ajt");
        }
    }
}
