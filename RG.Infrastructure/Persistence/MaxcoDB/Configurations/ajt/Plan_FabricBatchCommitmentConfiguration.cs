using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.Maxco.Business;

namespace RG.Infrastructure.Persistence.MaxcoDB.Configurations.ajt
{
    public class Plan_FabricBatchCommitmentConfiguration : IEntityTypeConfiguration<Plan_FabricBatchCommitment>
    {
        public void Configure(EntityTypeBuilder<Plan_FabricBatchCommitment> builder)
        {
            builder.HasKey(b => b.FabricBatchCommitmentID);
            builder.Property(p => p.CommitmentQuantity).HasPrecision(18, 2);
            builder.ToTable("Plan_FabricBatchCommitment", "ajt");
        }
    }
}
