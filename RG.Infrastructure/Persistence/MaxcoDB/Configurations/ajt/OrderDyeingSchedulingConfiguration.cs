using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.Maxco.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.Persistence.MaxcoDB.Configurations.ajt
{
    public class OrderDyeingSchedulingConfiguration : IEntityTypeConfiguration<OrderDyeingScheduling>
    {
        public void Configure(EntityTypeBuilder<OrderDyeingScheduling> builder)
        {
            builder.HasKey(b => b.DyeingScheduleID);
            builder.ToTable("OrderDyeingScheduling", "ajt");
        }
    }
}
