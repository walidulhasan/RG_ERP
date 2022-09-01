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
    public class AssetDivisionConfiguration : IEntityTypeConfiguration<AssetDivision>
    {

        public void Configure(EntityTypeBuilder<AssetDivision> builder)
        {
            builder.HasKey(b => b.DivisionID);
            builder.ToTable("AssetDivision", "ajt");
        }
    }
}
