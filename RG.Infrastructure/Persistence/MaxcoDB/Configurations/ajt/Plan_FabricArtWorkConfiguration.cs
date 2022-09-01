using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.Maxco.Business;

namespace RG.Infrastructure.Persistence.MaxcoDB.Configurations.ajt
{
    public class Plan_FabricArtWorkConfiguration : IEntityTypeConfiguration<Plan_FabricArtWork>
    {
        public void Configure(EntityTypeBuilder<Plan_FabricArtWork> builder)
        {
            builder.HasKey(b => b.FabricArtWorkID);
            builder.ToTable("Plan_FabricArtWork", "ajt");
        }
    }
}
