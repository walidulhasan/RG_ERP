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
    public class Tbl_EmpConfiguration : IEntityTypeConfiguration<Tbl_Emp>
    {
        public void Configure(EntityTypeBuilder<Tbl_Emp> builder)
        {
            builder.HasKey(b => b.Emp_ID);
        }
    }
}
