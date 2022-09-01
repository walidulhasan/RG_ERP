using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.Maxco.Business;

namespace RG.Infrastructure.Persistence.MaxcoDB.Configurations.ajt
{
    public class Plan_VersionsConfiguration : IEntityTypeConfiguration<Plan_Versions>
    {
        
        public void Configure(EntityTypeBuilder<Plan_Versions> builder)
        {
            builder.HasKey(b => b.PlanVersionID);
            
            builder.ToTable("Plan_Versions", "ajt");
        }
    }
}
