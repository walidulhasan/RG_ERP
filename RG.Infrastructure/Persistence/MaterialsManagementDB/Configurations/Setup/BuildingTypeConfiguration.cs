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
    public class BuildingTypeConfiguration : IEntityTypeConfiguration<BuildingType>
    {
        public void Configure(EntityTypeBuilder<BuildingType> builder)
        {
            builder.ToTable("BuildingType", "ajt");
            builder.HasKey(e => e.ID);
        }
    }
}
