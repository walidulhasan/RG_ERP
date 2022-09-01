using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.AlgoHR.Business;

namespace RG.Infrastructure.Persistence.AlgoHRDB.Configurations.rpt
{
    public class DivisionOtherCostConfiguration : IEntityTypeConfiguration<DivisionOtherCost>
    {
        public void Configure(EntityTypeBuilder<DivisionOtherCost> builder)
        {
            builder.HasKey(b => b.OtherCostID);
            builder.ToTable("DivisionOtherCost", "rpt");
        }
    }
}