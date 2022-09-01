using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.Persistence.FiniteSchedulerDB.Configurations.ajt
{
    public class MT_MaintenanceItem_SetupConfiguration : IEntityTypeConfiguration<MT_MaintenanceItem_Setup>
    {
        public void Configure(EntityTypeBuilder<MT_MaintenanceItem_Setup> builder)
        { 
            builder.ToTable("MT_MaintenanceItem_Setup", "ajt");
        }
    }
}
