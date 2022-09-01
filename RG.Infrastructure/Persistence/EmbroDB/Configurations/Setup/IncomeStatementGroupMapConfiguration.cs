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
    public class IncomeStatementGroupMapConfiguration : IEntityTypeConfiguration<IncomeStatementGroupMap>
    {
        public void Configure(EntityTypeBuilder<IncomeStatementGroupMap> builder)
        {
            builder.HasKey(b => b.ID);
            builder.ToTable("IncomeStatementGroupMap", "ajt");
        }
    }
}
