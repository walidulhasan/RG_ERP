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
    public class Tbl_EmpOutSideTaskConfiguration : IEntityTypeConfiguration<Tbl_EmpOutSideTask>
    {
        public void Configure(EntityTypeBuilder<Tbl_EmpOutSideTask> builder)
        {
            builder.HasKey(b => b.OutSideTaskID);

            builder.ToTable("Tbl_EmpOutSideTask", "ajt");
        }
    }
}
