using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.Persistence.AlgoHRDB.Configurations.dbo
{
    public class Tbl_AttendanceStatusConfiguration : IEntityTypeConfiguration<Tbl_AttendanceStatus>
    {
        public void Configure(EntityTypeBuilder<Tbl_AttendanceStatus> builder)
        {
            builder.HasKey(b => b.StatusID);
        }
    }
}
