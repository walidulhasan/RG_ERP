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
    public class Tbl_HolidayConfiguration : IEntityTypeConfiguration<Tbl_Holiday>
    {
        public void Configure(EntityTypeBuilder<Tbl_Holiday> builder)
        {
            builder.HasKey(b => b.Holiday_ID);
            builder.ToTable("Tbl_Holiday", "dbo");
        }
    }
}
