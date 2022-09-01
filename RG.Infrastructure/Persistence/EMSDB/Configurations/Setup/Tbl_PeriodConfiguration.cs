using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.EMS.Setup;

namespace RG.Infrastructure.Persistence.EMSDB.Configurations.Setup
{
    public class Tbl_PeriodConfiguration : IEntityTypeConfiguration<Tbl_Period>
    {
        public void Configure(EntityTypeBuilder<Tbl_Period> builder)
        {
            builder.HasKey(b => b.Period_ID);
            builder.ToTable("Tbl_Period", "dbo");
        }
    }
}
