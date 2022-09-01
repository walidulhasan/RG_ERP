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
    public class FloorTypeConfiguration : IEntityTypeConfiguration<FloorType>
    {
        public void Configure(EntityTypeBuilder<FloorType> builder)
        {
            builder.ToTable("FloorType", "ajt");
            builder.HasKey(e => e.FloorTypeID);
        }
    }
}
