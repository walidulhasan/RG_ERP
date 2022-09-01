using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.AlgoHR.DBViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.Persistence.AlgoHRDB.Configurations.Views
{
    public class Vw_OutSideTaskConfiguration : IEntityTypeConfiguration<Vw_OutSideTask>
    {
        public void Configure(EntityTypeBuilder<Vw_OutSideTask> builder)
        {
            builder.HasKey(b => b.OutSideTaskID);
            builder.ToTable("Vw_OutSideTask", "ajt");
        }
    }
}
