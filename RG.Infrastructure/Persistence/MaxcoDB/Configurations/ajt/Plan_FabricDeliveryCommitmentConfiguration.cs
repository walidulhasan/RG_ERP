using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.Maxco.Business;

namespace RG.Infrastructure.Persistence.MaxcoDB.Configurations.ajt
{
    public class Plan_FabricDeliveryCommitmentConfiguration : IEntityTypeConfiguration<Plan_FabricDeliveryCommitment>
    {
        public void Configure(EntityTypeBuilder<Plan_FabricDeliveryCommitment> builder)
        {
            builder.HasKey(b => b.FabricDeliveryCommitmentID);
            builder.Property(p => p.CommitmentQuantity).HasPrecision(18, 2);
            builder.ToTable("Plan_FabricDeliveryCommitment", "ajt");
        }
    }
}
