using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.Maxco.Business;

namespace RG.Infrastructure.Persistence.MaxcoDB.Configurations.rpt
{
    public class Plan_GarmentAssortmentAndFabricsReportConfiguration : IEntityTypeConfiguration<Plan_GarmentAssortmentAndFabricsReport>
    {
        public void Configure(EntityTypeBuilder<Plan_GarmentAssortmentAndFabricsReport> builder)
        {
            builder.HasKey(b => b.Serial);
            builder.Property(p => p.MainFabricRequiredQuantity).HasPrecision(18, 2);
            builder.Property(p => p.MainFabricUseConsumption).HasPrecision(18, 6);

            builder.Property(p => p.RibRequiredQuantity).HasPrecision(18, 6);
            builder.Property(p => p.RibUseConsumption).HasPrecision(18, 6);

            builder.Property(p => p.WastagePercent).HasPrecision(18, 2);

            builder.ToTable("Plan_GarmentAssortmentAndFabricsReport", "rpt");
        }
    }
}
