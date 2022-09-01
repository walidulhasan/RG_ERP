using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.FiniteScheduler.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.Persistence.FiniteSchedulerDB.Configurations.ajt
{
    public class TempAssetConfiguration : IEntityTypeConfiguration<TempAsset>
    {

        public void Configure(EntityTypeBuilder<TempAsset> builder)
        {
            builder.HasKey(b => b.ID);

            builder.ToTable("TempAsset", "ajt");
        }
    }
}
