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
    
    public class Plan_SewingConfiguration : IEntityTypeConfiguration<Plan_Sewing>
    {
        public void Configure(EntityTypeBuilder<Plan_Sewing> builder)
        {
            builder.HasKey(b => b.SewingID);
            builder.Property(p => p.SewingQuantity).HasPrecision(18, 2);
            builder.ToTable("Plan_Sewing", "ajt");
        }
    }
}
