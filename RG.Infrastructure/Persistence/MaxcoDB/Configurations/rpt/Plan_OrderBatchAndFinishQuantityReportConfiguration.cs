using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.Maxco.Business;

namespace RG.Infrastructure.Persistence.MaxcoDB.Configurations.rpt
{
    public class Plan_OrderBatchAndFinishQuantityReportConfiguration : IEntityTypeConfiguration<Plan_OrderBatchAndFinishQuantityReport>
    {
        public void Configure(EntityTypeBuilder<Plan_OrderBatchAndFinishQuantityReport> builder)
        {
            builder.HasKey(b => b.Serial);
            builder.Property(p => p.BatchQty).HasPrecision(18, 2);
            builder.Property(p => p.FinishQty).HasPrecision(18, 2);
            builder.Property(p => p.RibQty).HasPrecision(18, 2);
            builder.ToTable("Plan_OrderBatchAndFinishQuantityReport", "rpt");
        }
    }
}
