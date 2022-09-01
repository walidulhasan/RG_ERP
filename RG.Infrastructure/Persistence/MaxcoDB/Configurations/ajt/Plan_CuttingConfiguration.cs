using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.Maxco.Business;

namespace RG.Infrastructure.Persistence.MaxcoDB.Configurations.ajt
{
    public class Plan_CuttingConfiguration : IEntityTypeConfiguration<Plan_Cutting>
    {
        public void Configure(EntityTypeBuilder<Plan_Cutting> builder)
        {
            builder.HasKey(b => b.CuttingID);
            builder.Property(p => p.CuttingQuantity).HasPrecision(18,2);
            builder.ToTable("Plan_Cutting", "ajt");
        }
    }
}
