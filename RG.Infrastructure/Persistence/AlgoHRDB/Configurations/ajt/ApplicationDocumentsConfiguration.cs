using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.AlgoHR.Business;

namespace RG.Infrastructure.Persistence.AlgoHRDB.Configurations.ajt
{
    public class ApplicationDocumentsConfiguration : IEntityTypeConfiguration<ApplicationDocuments>
    {
        public void Configure(EntityTypeBuilder<ApplicationDocuments> builder)
        {
            builder.HasKey(b => b.DocumentID);
            builder.ToTable("ApplicationDocuments", "ajt");
        }
    }
}

