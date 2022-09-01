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
    public class OrderSchedulingConfiguration : IEntityTypeConfiguration<OrderScheduling>
    {
        public void Configure(EntityTypeBuilder<OrderScheduling> builder)
        {
            builder.HasKey(b => b.ScheduleID);
            builder.ToTable("OrderScheduling", "ajt");
        }
    }
}
