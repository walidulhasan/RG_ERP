using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.FiniteScheduler.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.Persistence.FiniteSchedulerDB.Configurations.ajt
{
    public class AssetDepartmentConfiguration : IEntityTypeConfiguration<AssetDepartment>
    {
        public void Configure(EntityTypeBuilder<AssetDepartment> builder)
        {
            builder.HasKey(b => b.DepartmentID);
            builder.ToTable("AssetDepartment", "ajt");
        }
    }
}
