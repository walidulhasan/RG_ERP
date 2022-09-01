using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.Embro.Setup;

namespace RG.Infrastructure.Persistence.EmbroDB.Configurations.Setup
{

    public class COAGroupIgnoredItemConfiguration : IEntityTypeConfiguration<COAGroupIgnoredItem>
    {
        public void Configure(EntityTypeBuilder<COAGroupIgnoredItem> builder)
        {
            builder.HasKey(b => b.GroupIgnoredItemID);
            builder.ToTable("COAGroupIgnoredItem", "ajt");
        }
    }
}
