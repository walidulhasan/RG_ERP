using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.AlgoHR;
using RG.DBEntities.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.Persistence.AlgoHRDB.Configurations.dbo
{
    public class Tbl_EmpAttendanceConfiguration : IEntityTypeConfiguration<Tbl_EmpAttendance>
    {
        public void Configure(EntityTypeBuilder<Tbl_EmpAttendance> builder)
        {
            builder.HasKey(b => new { b.Att_EmpCd,b.Att_Date });
            builder.ToTable("Tbl_EmpAttendance", "dbo");
        }
    }
}
