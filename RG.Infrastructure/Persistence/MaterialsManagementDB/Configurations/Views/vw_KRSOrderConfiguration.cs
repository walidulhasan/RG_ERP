using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.MaterialsManagement.DBViews;

namespace RG.Infrastructure.Persistence.MaterialsManagementDB.Configurations.Views
{
    public class vw_KRSOrderConfiguration : IEntityTypeConfiguration<vw_KRSOrder>
    {
        public void Configure(EntityTypeBuilder<vw_KRSOrder> builder)
        {
            builder.HasKey(b => b.KRSID);
            builder.ToTable("vw_KRSOrder", "ajt");
        }
    }
}