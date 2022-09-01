using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.MaterialsManagement.DBViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.Persistence.MaterialsManagementDB.Configurations.Views
{
    public class Viw_SupplierConfiguration : IEntityTypeConfiguration<Viw_Supplier>
    {
        public void Configure(EntityTypeBuilder<Viw_Supplier> builder)
        {
            builder.HasKey(b => b.SupplierID);
            builder.ToTable("Viw_Supplier","ajt");
        }
    }
}
