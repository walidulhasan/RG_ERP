using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.MaterialsManagement.DBViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.Persistence.MaterialsManagementDB.Configurations.Views
{
    class viw_CurrentMovingAverageForAttributeInstanceConfiguration : IEntityTypeConfiguration<viw_CurrentMovingAverageForAttributeInstance>
    {
        public void Configure(EntityTypeBuilder<viw_CurrentMovingAverageForAttributeInstance> builder)
        {
            builder.HasNoKey();
            builder.Property(p => p.MovingAverage).HasPrecision(18, 5);
            builder.ToTable("viw_CurrentMovingAverageForAttributeInstance", "ajt");
        }
    }
}
