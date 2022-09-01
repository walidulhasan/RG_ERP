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
    public class Vw_SupplierSetupConfiguration : IEntityTypeConfiguration<Vw_SupplierSetup>
    {
        public void Configure(EntityTypeBuilder<Vw_SupplierSetup> builder)
        {
            builder.HasNoKey();
            builder.ToTable("Vw_SupplierSetup", "ajt");
        }
    }
}
