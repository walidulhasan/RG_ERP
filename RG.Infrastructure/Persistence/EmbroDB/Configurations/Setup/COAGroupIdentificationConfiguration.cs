using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.Embro.Setup;

namespace RG.Infrastructure.Persistence.EmbroDB.Configurations.Setup
{    
    public class COAGroupIdentificationConfiguration : IEntityTypeConfiguration<COAGroupIdentification>
    {
        public void Configure(EntityTypeBuilder<COAGroupIdentification> builder)
        {
            builder.HasKey(b => b.GroupIdentificationID);            
            builder.ToTable("COAGroupIdentification", "ajt");
        }
    }
}
