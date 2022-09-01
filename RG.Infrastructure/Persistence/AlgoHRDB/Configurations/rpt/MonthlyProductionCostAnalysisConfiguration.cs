using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.AlgoHR.Business;

namespace RG.Infrastructure.Persistence.AlgoHRDB.Configurations.rpt
{
    public class MonthlyProductionCostAnalysisConfiguration : IEntityTypeConfiguration<MonthlyProductionCostAnalysis>
    {
        public void Configure(EntityTypeBuilder<MonthlyProductionCostAnalysis> builder)
        {
            builder.HasKey(b => b.ID);
            builder.ToTable("MonthlyProductionCostAnalysis", "rpt");
        }
    }
}