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
   
    public class Plan_FinishFabricConfiguration : IEntityTypeConfiguration<Plan_FinishFabric>
    {
        public void Configure(EntityTypeBuilder<Plan_FinishFabric> builder)
        {
            builder.HasKey(b => b.FinishFabricID);
            builder.Property(p => p.FinishFabricQuantity).HasPrecision(18, 2);
            builder.ToTable("Plan_FinishFabric", "ajt");
        }
    }
}
