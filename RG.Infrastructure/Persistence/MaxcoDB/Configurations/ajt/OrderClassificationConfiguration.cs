using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.Maxco.Setup;

namespace RG.Infrastructure.Persistence.MaxcoDB.Configurations.ajt
{
    public class OrderClassificationConfiguration : IEntityTypeConfiguration<OrderClassification>
    {
        public void Configure(EntityTypeBuilder<OrderClassification> builder)
        {
            builder.HasKey(b => b.OrderClassificationID);
            builder.ToTable("OrderClassification", "ajt");
        }
    }
}
