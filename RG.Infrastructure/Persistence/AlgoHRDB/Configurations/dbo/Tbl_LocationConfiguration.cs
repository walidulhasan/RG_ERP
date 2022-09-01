using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.AlgoHR;
using RG.DBEntities.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.Persistence.AlgoHRDB.Configurations.dbo
{
    public class Tbl_LocationConfiguration : IEntityTypeConfiguration<Tbl_Location>
    {
        public void Configure(EntityTypeBuilder<Tbl_Location> builder)
        {
            builder.HasKey(b => b.Location_Id);
        }
    }
}
