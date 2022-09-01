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
    public class MT_MachineAndMaintenanceCheckListMasterConfiguration : IEntityTypeConfiguration<MT_MachineAndMaintenanceCheckListMaster>
    {
        public void Configure(EntityTypeBuilder<MT_MachineAndMaintenanceCheckListMaster> builder)
        {
            builder.HasKey(b => b.ID);
            builder.ToTable("MT_MachineAndMaintenanceCheckListMaster", "ajt");
        }
    }
}
