using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.Embro.DBViews;

namespace RG.Infrastructure.Persistence.EmbroDB.Configurations.Views
{
    public class viw_VoucherConfiguration : IEntityTypeConfiguration<viw_Voucher>
    {
        public void Configure(EntityTypeBuilder<viw_Voucher> builder)
        {
            builder.HasNoKey();
            builder.ToTable("viw_Voucher", "dbo");
        }
    }
}
