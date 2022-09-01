using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.AlgoHR;
using RG.DBEntities.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.Persistence.AlgoHRDB.Configurations.dbo
{
   public class Tbl_LeavesConfiguration : IEntityTypeConfiguration<Tbl_Leaves>
    {
        public void Configure(EntityTypeBuilder<Tbl_Leaves> builder)
        {
            builder.HasKey(b => b.Leaves_ID);
            builder.ToTable("Tbl_Leaves", "dbo");
        }
    }
}
