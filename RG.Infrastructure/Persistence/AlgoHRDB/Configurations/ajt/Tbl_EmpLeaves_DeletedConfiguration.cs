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
    public class Tbl_EmpLeaves_DeletedConfiguration : IEntityTypeConfiguration<Tbl_EmpLeaves_Deleted>
    {
        public void Configure(EntityTypeBuilder<Tbl_EmpLeaves_Deleted> builder)
        {
            builder.HasKey(b => b.ID);
            builder.ToTable("Tbl_EmpLeaves_Deleted", "ajt");
        }
    }
}

