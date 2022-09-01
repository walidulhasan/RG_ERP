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
    class MT_MachineMaintenanceCategory_SetupConfiguration : IEntityTypeConfiguration<MT_MachineMaintenanceCategory_Setup>
    {
        public void Configure(EntityTypeBuilder<MT_MachineMaintenanceCategory_Setup> builder)
        {
            builder.HasKey(b => b.ID);
            builder.ToTable("MT_MachineMaintenanceCategory_Setup", "ajt");
        }
    }
}
