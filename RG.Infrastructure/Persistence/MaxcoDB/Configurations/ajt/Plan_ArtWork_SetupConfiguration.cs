using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.Maxco.Setup;

namespace RG.Infrastructure.Persistence.MaxcoDB.Configurations.ajt
{
    public class Plan_ArtWork_SetupConfiguration : IEntityTypeConfiguration<Plan_ArtWork_Setup>
    {
        public void Configure(EntityTypeBuilder<Plan_ArtWork_Setup> builder)
        {
            builder.HasKey(b => b.ArtWorkID);
            builder.ToTable("Plan_ArtWork_Setup", "ajt");
        }
    }
}
