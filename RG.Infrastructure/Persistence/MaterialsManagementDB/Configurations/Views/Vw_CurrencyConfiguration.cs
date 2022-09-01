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
    public class Vw_CurrencyConfiguration : IEntityTypeConfiguration<Vw_Currency>
    {
        public void Configure(EntityTypeBuilder<Vw_Currency> builder)
        {
            builder.HasKey(v => v.ID);
            builder.ToTable("Vw_Currency", "ajt");
        }
    }
}
