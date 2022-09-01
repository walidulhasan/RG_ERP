using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.AlgoHR.Business;

namespace RG.Infrastructure.Persistence.AlgoHRDB.Configurations.rpt
{
    public class DivisionCostHeadsConfiguration : IEntityTypeConfiguration<DivisionCostHeads>
    {
        public void Configure(EntityTypeBuilder<DivisionCostHeads> builder)
        {
            builder.HasKey(b => b.CostHeadID);
            builder.ToTable("DivisionCostHeads", "rpt");
        }
    }
}