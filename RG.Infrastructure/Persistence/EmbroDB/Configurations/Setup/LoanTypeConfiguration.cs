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
    public class LoanTypeConfiguration : IEntityTypeConfiguration<LoanType>
    {
        public void Configure(EntityTypeBuilder<LoanType> builder)
        {
            builder.ToTable("LoanType", "ajt");
            builder.HasKey(b => b.ID);
        }
    }
}
