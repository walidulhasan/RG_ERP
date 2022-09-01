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
    public class vw_ERP_EmpShortInfoConfiguration : IEntityTypeConfiguration<vw_ERP_EmpShortInfo>
    {
        public void Configure(EntityTypeBuilder<vw_ERP_EmpShortInfo> builder)
        {
            builder.HasKey(b=>b.EmployeeID);
            builder.ToTable("vw_ERP_EmpShortInfo", "ajt");
        }
    }
}
