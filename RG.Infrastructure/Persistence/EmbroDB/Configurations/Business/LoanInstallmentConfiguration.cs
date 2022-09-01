using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.Embro.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.Persistence.EmbroDB.Configurations.Business
{
    public class LoanInstallmentConfiguration : IEntityTypeConfiguration<LoanInstallment>
    {
        public void Configure(EntityTypeBuilder<LoanInstallment> builder)
        {
            builder.ToTable("LoanInstallment", "ajt");
            builder.HasKey(b => b.LoanInstallmentID);
        }
    }
}
