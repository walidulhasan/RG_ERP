using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.Embro.DBViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.Persistence.EmbroDB.Configurations.Views
{
    public class Vw_BasicCOAConfiguration : IEntityTypeConfiguration<Vw_BasicCOA>
    {
        public void Configure(EntityTypeBuilder<Vw_BasicCOA> builder)
        {
            builder.HasNoKey();
            builder.ToTable("Vw_BasicCOA","ajt");
        }
    }
}
