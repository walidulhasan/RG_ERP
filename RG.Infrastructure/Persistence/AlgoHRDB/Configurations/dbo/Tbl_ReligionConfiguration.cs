using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.AlgoHR.Setup;

namespace RG.Infrastructure.Persistence.AlgoHRDB.Configurations.dbo
{
    public class Tbl_ReligionConfiguration : IEntityTypeConfiguration<Tbl_Religion>
    {
        public void Configure(EntityTypeBuilder<Tbl_Religion> builder)
        {
            builder.HasKey(b => b.Religion_ID);
            builder.ToTable("Tbl_Religion", "dbo");
        }
    }
}
