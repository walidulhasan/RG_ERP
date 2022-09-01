﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.Persistence.FiniteSchedulerDB.Configurations.ajt
{
    public class MT_MachineMaintenanceStatusConfiguration : IEntityTypeConfiguration<MT_MachineMaintenanceStatus>
    {
        public void Configure(EntityTypeBuilder<MT_MachineMaintenanceStatus> builder)
        {

            builder.HasKey(b => b.StatusID);
            builder.ToTable("MT_MachineMaintenanceStatus", "ajt");
        }
    }
}
