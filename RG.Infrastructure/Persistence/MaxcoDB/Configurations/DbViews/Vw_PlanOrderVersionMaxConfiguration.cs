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
    public class Vw_PlanOrderVersionMaxConfiguration : IEntityTypeConfiguration<Vw_PlanOrderVersionMax>
    {
        public void Configure(EntityTypeBuilder<Vw_PlanOrderVersionMax> builder)
        {
            builder.HasKey(k => k.PlanVersionID);
            builder.ToTable("Vw_PlanOrderVersionMax","ajt");
        }
    }
}
