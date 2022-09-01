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
    public class AssetAssignedTypeConfiguration : IEntityTypeConfiguration<AssetAssignedType>
    {

        public void Configure(EntityTypeBuilder<AssetAssignedType> builder)
        {
            builder.HasKey(b => b.AssignedTypeNameID);

            builder.ToTable("AssetAssignedType", "ajt");
        }
    }
}
