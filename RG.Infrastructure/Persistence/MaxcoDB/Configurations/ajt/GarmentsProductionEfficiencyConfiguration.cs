using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.Maxco.Setup;

namespace RG.Infrastructure.Persistence.MaxcoDB.Configurations.ajt
{
    public class GarmentsProductionEfficiencyConfiguration : IEntityTypeConfiguration<GarmentsProductionEfficiency>
    {
        public void Configure(EntityTypeBuilder<GarmentsProductionEfficiency> builder)
        {
            builder.HasKey(b => b.ID);
            builder.ToTable("GarmentsProductionEfficiency", "ajt");
        }
    }
}
