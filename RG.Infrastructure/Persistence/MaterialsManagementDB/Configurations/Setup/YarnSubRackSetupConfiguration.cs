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
    public class YarnSubRackSetupConfiguration : IEntityTypeConfiguration<YarnSubRackSetup>
    {
        public void Configure(EntityTypeBuilder<YarnSubRackSetup> builder)
        {
            builder.ToTable("YarnSubRackSetup", "ajt");
            builder.HasKey(e => e.SubRackID);
        }
    }
}
