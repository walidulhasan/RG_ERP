using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.MaterialsManagement.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.Persistence.MaterialsManagementDB.Configurations
{
    public class DailyProductionHourConfiguration : IEntityTypeConfiguration<DailyProductionHour>
    {
        public void Configure(EntityTypeBuilder<DailyProductionHour> builder)
        {
            builder.ToTable("DailyProductionHour", "ajt");
            builder.HasKey(e => e.ID);
        }
    }
}
