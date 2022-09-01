using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.FiniteScheduler.DBViews;

namespace RG.Infrastructure.Persistence.FiniteSchedulerDB.Configurations.DbViews
{
    public class Vw_EmbroCompanyInfoConfiguration : IEntityTypeConfiguration<Vw_EmbroCompanyInfo>
    {
        public void Configure(EntityTypeBuilder<Vw_EmbroCompanyInfo> builder)
        {
            builder.HasKey(x => x.CompanyID);
            builder.ToTable("Vw_EmbroCompanyInfo", "ajt");
        }
    }
}