using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.Persistence.MaterialsManagementDB.Configurations.Business
{
    public class CMBL_PurchaseOrderItemConfiguration : IEntityTypeConfiguration<CMBL_PurchaseOrderItem>
    {
        public void Configure(EntityTypeBuilder<CMBL_PurchaseOrderItem> builder)
        {
            builder.ToTable("CMBL_PurchaseOrderItem", "dbo");
            builder.HasKey(e => e.POItemID);
        }
    }
}
