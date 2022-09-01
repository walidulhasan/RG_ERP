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
    public class vw_CMBL_ItemALLAttributeConfiguration : IEntityTypeConfiguration<vw_CMBL_ItemALLAttribute>
    {
        public void Configure(EntityTypeBuilder<vw_CMBL_ItemALLAttribute> builder)
        {
            builder.HasNoKey();
            builder.ToTable("vw_CMBL_ItemALLAttribute", "ajt");
        }
    }
}
