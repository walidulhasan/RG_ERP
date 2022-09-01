using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.AlgoHR.Setup;

namespace RG.Infrastructure.Persistence.AlgoHRDB.Configurations.dbo
{
    public class Tbl_ShiftConfiguration : IEntityTypeConfiguration<tbl_Shift>
    {
        public void Configure(EntityTypeBuilder<tbl_Shift> builder)
        {
            builder.HasKey(b => b.Shift_ID);
        }
    }
}
