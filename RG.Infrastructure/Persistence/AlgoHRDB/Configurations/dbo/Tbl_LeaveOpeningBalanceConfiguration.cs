using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.AlgoHR;
using RG.DBEntities.AlgoHR.Business;

namespace RG.Infrastructure.Persistence.AlgoHRDB.Configurations.dbo
{
    public class Tbl_LeaveOpeningBalanceConfiguration : IEntityTypeConfiguration<Tbl_LeaveOpeningBalance>
    {
        public void Configure(EntityTypeBuilder<Tbl_LeaveOpeningBalance> builder)
        {
            builder.HasKey(b => b.ID);
            builder.ToTable("Tbl_LeaveOpeningBalance", "dbo");
        }
    }
}

