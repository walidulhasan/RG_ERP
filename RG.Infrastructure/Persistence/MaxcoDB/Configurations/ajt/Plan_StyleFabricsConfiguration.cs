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
   
    public class Plan_StyleFabricsConfiguration : IEntityTypeConfiguration<Plan_StyleFabrics>
    {
        public void Configure(EntityTypeBuilder<Plan_StyleFabrics> builder)
        {
            builder.HasKey(b => b.StyleFabricsID);
            builder.Property(p => p.RequiredQuantity).HasPrecision(18, 2);
            builder.Property(p => p.RibQuantity).HasPrecision(18, 2);
            builder.Property(p => p.MainFabricUseConsumption).HasPrecision(18, 6);
            builder.Property(p => p.RibUseConsumption).HasPrecision(18, 6);

            builder.ToTable("Plan_StyleFabrics", "ajt");
        }
    }
}
