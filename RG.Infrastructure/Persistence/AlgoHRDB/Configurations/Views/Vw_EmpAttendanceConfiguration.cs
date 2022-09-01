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
    public class Vw_EmpAttendanceConfiguration : IEntityTypeConfiguration<Vw_EmpAttendance>
    {
        public void Configure(EntityTypeBuilder<Vw_EmpAttendance> builder)
        {
            builder.HasKey(b=>b.Serial);
            builder.ToTable("Vw_EmpAttendance", "ajt");
        }
    }
}
