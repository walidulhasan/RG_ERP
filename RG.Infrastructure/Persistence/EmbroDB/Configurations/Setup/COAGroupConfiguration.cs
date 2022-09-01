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
    public class COAGroupConfiguration : IEntityTypeConfiguration<COAGroup>
    {
        public void Configure(EntityTypeBuilder<COAGroup> builder)
        {
            builder.HasKey(b => b.GroupID);
            builder.ToTable("COAGroup", "ajt");
        }
    }
}
