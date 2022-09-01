using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.Maxco.Business;

namespace RG.Infrastructure.Persistence.MaxcoDB.Configurations.ajt
{

    public class Plan_ShipmentConfiguration : IEntityTypeConfiguration<Plan_Shipment>
    {
        public void Configure(EntityTypeBuilder<Plan_Shipment> builder)
        {
            builder.HasKey(b => b.ShipmentID);
            builder.Property(p => p.ShipmentQuantity).HasPrecision(18, 2);
            builder.ToTable("Plan_Shipment", "ajt");
        }
    }
}
