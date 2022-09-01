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
    public class BuildingFloorInfoConfiguration : IEntityTypeConfiguration<BuildingFloorInfo>
    {
        public void Configure(EntityTypeBuilder<BuildingFloorInfo> builder)
        {
            builder.ToTable("BuildingFloorInfo", "ajt");
            builder.HasKey(e => e.BuildingFloorID);
        }
    }
}
