using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.AlgoHR;
using RG.DBEntities.AlgoHR.Business;

namespace RG.Infrastructure.Persistence.AlgoHRDB.Configurations.dbo
{
    public class Tbl_EmpLeavesConfiguration : IEntityTypeConfiguration<Tbl_EmpLeaves>
    {
        public void Configure(EntityTypeBuilder<Tbl_EmpLeaves> builder)
        {
            builder.HasKey(b => b.ID);
            builder.ToTable("Tbl_EmpLeaves", "dbo");
        }
    }
}
