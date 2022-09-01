using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.MaterialsManagement.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.Persistence.MaterialsManagementDB.Configurations.Setup
{
    public class BuildingInfoConfiguration : IEntityTypeConfiguration<BuildingInfo>
    {
        public void Configure(EntityTypeBuilder<BuildingInfo> builder)
        {
            builder.ToTable("BuildingInfo", "ajt");
            builder.HasKey(e => e.BuildingID);
        }
    }
}
