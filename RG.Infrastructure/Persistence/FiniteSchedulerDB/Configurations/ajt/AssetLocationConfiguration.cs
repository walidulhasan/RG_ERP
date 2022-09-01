using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.Persistence.FiniteSchedulerDB.Configurations.ajt
{
    public class AssetLocationConfiguration : IEntityTypeConfiguration<AssetLocation>
    {
        public void Configure(EntityTypeBuilder<AssetLocation> builder)
        {
            builder.HasKey(b => b.ID);

            builder.ToTable("AssetLocation", "ajt");
        }
    }
}
