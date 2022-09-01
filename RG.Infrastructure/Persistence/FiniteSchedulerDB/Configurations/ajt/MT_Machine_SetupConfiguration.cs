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
    public  class MT_Machine_SetupConfiguration : IEntityTypeConfiguration<MT_Machine_Setup>
    {
        public void Configure(EntityTypeBuilder<MT_Machine_Setup> builder)
        {
            builder.HasKey(b => b.MachineID);             
            builder.ToTable("MT_Machine_Setup", "ajt");
        }
    }
}
