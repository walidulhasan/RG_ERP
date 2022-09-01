using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.Embro.Setup;

namespace RG.Infrastructure.Persistence.EmbroDB.Configurations.Setup
{    
    public class BalanceSheetGroupMapConfiguration : IEntityTypeConfiguration<BalanceSheetGroupMap>
    {
        public void Configure(EntityTypeBuilder<BalanceSheetGroupMap> builder)
        {
            builder.HasKey(b => b.ID);
            builder.ToTable("BalanceSheetGroupMap", "ajt");
        }
    }
}
