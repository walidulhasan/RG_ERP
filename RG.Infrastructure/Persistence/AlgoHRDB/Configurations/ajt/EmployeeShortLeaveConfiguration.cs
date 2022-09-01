using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.Persistence.AlgoHRDB.Configurations.ajt
{
    public class EmployeeShortLeaveConfiguration : IEntityTypeConfiguration<EmployeeShortLeave>
    {
        public void Configure(EntityTypeBuilder<EmployeeShortLeave> builder)
        {
            builder.HasKey(b => b.ShortLeaveID);
            builder.ToTable("EmployeeShortLeave", "ajt");
        }
    }
}
