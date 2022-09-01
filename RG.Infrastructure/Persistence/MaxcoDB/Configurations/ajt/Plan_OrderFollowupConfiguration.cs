using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.Maxco.Business;

namespace RG.Infrastructure.Persistence.MaxcoDB.Configurations.ajt
{
    public class Plan_OrderFollowupConfiguration : IEntityTypeConfiguration<Plan_OrderFollowup>
    {
        public void Configure(EntityTypeBuilder<Plan_OrderFollowup> builder)
        {
            builder.HasKey(b => b.FollowupID);
            builder.Property(p => p.AdditionalFromStock).HasPrecision(18, 2);
            builder.ToTable("Plan_OrderFollowup", "ajt");
        }
    }
}
