using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.Maxco.Setup;

namespace RG.Infrastructure.Persistence.MaxcoDB.Configurations.ajt
{
    public class Plan_DyeingProductionLocation_SetupConfiguration : IEntityTypeConfiguration<Plan_DyeingProductionLocation_Setup>
    {
        public void Configure(EntityTypeBuilder<Plan_DyeingProductionLocation_Setup> builder)
        {
            builder.HasKey(b => b.ProductionLocationID);
            builder.ToTable("Plan_DyeingProductionLocation_Setup", "ajt");
        }
    }
}
