using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.AlgoHR.Business;

namespace RG.Infrastructure.Persistence.AlgoHRDB.Configurations.dbo
{
    public class Tbl_EmpShiftConfiguration : IEntityTypeConfiguration<Tbl_EmpShift>
    {
        public void Configure(EntityTypeBuilder<Tbl_EmpShift> builder)
        {
            builder.HasKey(k => new { k.Shift_EmpCD, k.Shift_Date });
        }
    }
}
