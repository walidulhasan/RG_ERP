using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.AlgoHR.DBViews;

namespace RG.Infrastructure.Persistence.AlgoHRDB.Configurations.Views
{
    public class Viw_ApprovalConfigurationConfiguration : IEntityTypeConfiguration<Viw_ApprovalConfiguration>
    {
        public void Configure(EntityTypeBuilder<Viw_ApprovalConfiguration> builder)
        {
            builder.HasNoKey();
            builder.ToTable("Viw_ApprovalConfiguration", "ajt");
        }
    }
}
