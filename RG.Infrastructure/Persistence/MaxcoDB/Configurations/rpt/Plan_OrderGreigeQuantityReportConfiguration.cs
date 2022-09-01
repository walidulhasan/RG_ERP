using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.Maxco.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.Persistence.MaxcoDB.Configurations.rpt
{
    public class Plan_OrderGreigeQuantityReportConfiguration : IEntityTypeConfiguration<Plan_OrderGreigeQuantityReport>
    {
        public void Configure(EntityTypeBuilder<Plan_OrderGreigeQuantityReport> builder)
        {
            builder.HasKey(b => b.Serial);
            builder.Property(p => p.GreigeQuantity).HasPrecision(18, 2);
            builder.ToTable("Plan_OrderGreigeQuantityReport", "rpt");
        }
    }
}