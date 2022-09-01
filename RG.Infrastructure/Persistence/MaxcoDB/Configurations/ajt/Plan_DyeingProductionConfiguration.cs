using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.Maxco.Business;

namespace RG.Infrastructure.Persistence.MaxcoDB.Configurations.ajt
{
    public class Plan_DyeingProductionConfiguration : IEntityTypeConfiguration<Plan_DyeingProduction>
    {
        public void Configure(EntityTypeBuilder<Plan_DyeingProduction> builder)
        {
            builder.HasKey(b => b.DyeingProductionID);
            builder.Property(p => p.ProductionQuantity).HasPrecision(18, 2);
            builder.ToTable("Plan_DyeingProduction", "ajt");
        }
    }
}
