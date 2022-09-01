using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.Maxco.DBViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.Persistence.MaxcoDB.Configurations.DbViews
{
    public class Vw_OrderDyeingFabricConfiguration : IEntityTypeConfiguration<Vw_OrderDyeingFabric>
    {
        public void Configure(EntityTypeBuilder<Vw_OrderDyeingFabric> builder)
        {
            builder.HasNoKey();
            builder.ToTable("Vw_OrderDyeingFabric", "ajt");
        }
    }
}
