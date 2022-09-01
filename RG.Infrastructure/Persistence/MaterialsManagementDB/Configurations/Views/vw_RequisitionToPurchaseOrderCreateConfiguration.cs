using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.MaterialsManagement.DBViews;

namespace RG.Infrastructure.Persistence.MaterialsManagementDB.Configurations.Views
{
    public class vw_RequisitionToPurchaseOrderCreateConfiguration : IEntityTypeConfiguration<vw_RequisitionToPurchaseOrderCreate>
    {
        public void Configure(EntityTypeBuilder<vw_RequisitionToPurchaseOrderCreate> builder)
        {
            builder.HasNoKey();
            builder.Property(p => p.ConversionToSKU).HasPrecision(18, 5);
            builder.Property(p => p.FinalSheetUnitCost).HasPrecision(18, 5);
            builder.Property(p => p.Gross).HasPrecision(18, 2);
            builder.Property(p => p.InHand).HasPrecision(18, 2);
            builder.Property(p => p.Net).HasPrecision(18, 2);
            builder.Property(p => p.PoRQty).HasPrecision(18, 2); 

            builder.ToTable("vw_RequisitionToPurchaseOrderCreate", "ajt");
        }
    }
}
