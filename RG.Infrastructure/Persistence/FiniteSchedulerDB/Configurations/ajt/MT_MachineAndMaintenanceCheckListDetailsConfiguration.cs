using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.FiniteScheduler.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.Persistence.FiniteSchedulerDB.Configurations.ajt
{
   public  class MT_MachineAndMaintenanceCheckListDetailsConfiguration : IEntityTypeConfiguration<MT_MachineAndMaintenanceCheckListDetails>
    {
        public void Configure(EntityTypeBuilder<MT_MachineAndMaintenanceCheckListDetails> builder)
        {
             
            builder.ToTable("MT_MachineAndMaintenanceCheckListDetails", "ajt");
        }
    }
}
