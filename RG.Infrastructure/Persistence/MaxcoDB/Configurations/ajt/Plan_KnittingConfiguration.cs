using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.Maxco.Business;

namespace RG.Infrastructure.Persistence.MaxcoDB.Configurations.ajt
{
    public class Plan_KnittingConfiguration : IEntityTypeConfiguration<Plan_Knitting>
    {
        public void Configure(EntityTypeBuilder<Plan_Knitting> builder)
        {
            builder.HasKey(b => b.KnittingID);
            builder.Property(p => p.KnittingQuantity).HasPrecision(18, 2);
            builder.ToTable("Plan_Knitting", "ajt");
        }
    }
}
