using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.MaterialsManagement.DBViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.Persistence.MaterialsManagementDB.Configurations.Views
{
    public class Vw_CompanyInfoConfiguration : IEntityTypeConfiguration<Vw_CompanyInfo>
    {
        public void Configure(EntityTypeBuilder<Vw_CompanyInfo> builder)
        {
            builder.HasNoKey();
            builder.ToTable("Vw_CompanyInfo", "ajt");
        }
    }
}
