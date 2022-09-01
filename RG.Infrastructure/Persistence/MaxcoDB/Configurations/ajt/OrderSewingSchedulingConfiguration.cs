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
    public class OrderSewingSchedulingConfiguration : IEntityTypeConfiguration<OrderSewingScheduling>
    {
        public void Configure(EntityTypeBuilder<OrderSewingScheduling> builder)
        {
            builder.HasKey(b => b.SewingScheduleID);
            builder.ToTable("OrderSewingScheduling", "ajt");
        }
    }
}
