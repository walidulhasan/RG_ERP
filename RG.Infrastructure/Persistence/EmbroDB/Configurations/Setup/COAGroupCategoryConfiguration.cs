using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.Embro.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.Persistence.EmbroDB.Configurations.Setup
{
    public class COAGroupCategoryConfiguration : IEntityTypeConfiguration<COAGroupCategory>
    {
        public void Configure(EntityTypeBuilder<COAGroupCategory> builder)
        {
            builder.HasKey(b => b.GroupCategoryID);
            builder.ToTable("COAGroupCategory", "ajt");
        }
    }
}
