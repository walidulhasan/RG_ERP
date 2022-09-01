using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.Maxco.Setup;

namespace RG.Infrastructure.Persistence.MaxcoDB.Configurations.ajt
{
    public class SchedularReportEmailConfiguration : IEntityTypeConfiguration<SchedularReportEmail>
    {
        public void Configure(EntityTypeBuilder<SchedularReportEmail> builder)
        {
            builder.HasKey(b => b.ID);
            builder.ToTable("SchedularReportEmail", "ajt");
        }
    }
}
