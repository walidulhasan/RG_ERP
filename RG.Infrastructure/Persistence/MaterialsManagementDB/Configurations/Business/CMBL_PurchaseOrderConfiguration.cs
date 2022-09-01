using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.MaterialsManagement.Business;

namespace RG.Infrastructure.Persistence.MaterialsManagementDB.Configurations.Business
{
    public class CMBL_PurchaseOrderConfiguration : IEntityTypeConfiguration<CMBL_PurchaseOrder>
    {
        public void Configure(EntityTypeBuilder<CMBL_PurchaseOrder> builder)
        {
            builder.ToTable("CMBL_PurchaseOrder", "dbo");
            builder.HasKey(e => e.POID);
        }
    }
}
