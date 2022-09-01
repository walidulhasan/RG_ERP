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
    public class Vw_EmpLeavesConfiguration : IEntityTypeConfiguration<Vw_EmpLeaves>
    {
        public void Configure(EntityTypeBuilder<Vw_EmpLeaves> builder)
        {
            //builder.HasKey(b => b.LeaveApplicationID);
            builder.HasNoKey();
            builder.ToTable("Vw_EmpLeaves", "ajt");
        }
    }
}
