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
    public class AssetSubTypeConfiguration : IEntityTypeConfiguration<AssetSubType>
    {
        public void Configure(EntityTypeBuilder<AssetSubType> builder)
        {
            builder.HasKey(b => b.AssetSubTypeID);

            builder.ToTable("AssetSubType", "ajt");
        }
    }
}
