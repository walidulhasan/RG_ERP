using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.Embro.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.Persistence.EmbroDB.Configurations.Views
{
   public class vw_ItemAccounts_OfCompanyConfiguration : IEntityTypeConfiguration<vw_ItemAccounts_OfCompany>
    {
        public void Configure(EntityTypeBuilder<vw_ItemAccounts_OfCompany> builder)
        {
            builder.HasNoKey();

            builder.ToTable("vw_ItemAccounts_OfCompany", "ajt");
        }
    }
}
