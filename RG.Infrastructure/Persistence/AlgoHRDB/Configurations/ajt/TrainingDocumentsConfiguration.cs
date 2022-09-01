using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.AlgoHR.Business;

namespace RG.Infrastructure.Persistence.AlgoHRDB.Configurations.ajt
{
    public class TrainingDocumentsConfiguration : IEntityTypeConfiguration<TrainingDocuments>
    {
        public void Configure(EntityTypeBuilder<TrainingDocuments> builder)
        {
            builder.HasKey(b => b.ID);
            builder.ToTable("TrainingDocuments", "ajt");
        }
    }
}