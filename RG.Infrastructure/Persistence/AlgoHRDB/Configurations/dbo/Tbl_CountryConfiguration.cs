using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.Persistence.AlgoHRDB.Configurations.dbo
{
    public class Tbl_CountryConfiguration : IEntityTypeConfiguration<Tbl_Country>
    {
        public void Configure(EntityTypeBuilder<Tbl_Country> builder)
        {
            builder.HasKey(b => b.Country_CID);
            builder.ToTable("Tbl_Country", "dbo");
        }
    }
}
