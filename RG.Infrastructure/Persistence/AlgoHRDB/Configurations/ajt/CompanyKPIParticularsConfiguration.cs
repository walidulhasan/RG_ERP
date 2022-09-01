using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.AlgoHR.Setup;

namespace RG.Infrastructure.Persistence.AlgoHRDB.Configurations.ajt
{
    public class CompanyKPIParticularsConfiguration : IEntityTypeConfiguration<CompanyKPIParticulars>
    {
        public void Configure(EntityTypeBuilder<CompanyKPIParticulars> builder)
        {
            builder.HasKey(b => b.ID);
            builder.ToTable("CompanyKPIParticulars", "ajt");
        }
    }
}