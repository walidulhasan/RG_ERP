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
    public class View_AttributeInstanceYarnInfoConfiguration : IEntityTypeConfiguration<View_AttributeInstanceYarnInfo>
    {
        public void Configure(EntityTypeBuilder<View_AttributeInstanceYarnInfo> builder)
        {
            builder.HasKey(v=>v.AttributeInstanceID);
            builder.ToTable("View_AttributeInstanceYarnInfo","ajt");
        }
    }
}
