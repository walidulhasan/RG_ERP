using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.AlgoHR.Setup;

namespace RG.Infrastructure.Persistence.AlgoHRDB.Configurations.ajt
{

    public class SystemNoticeCustomCustingConfiguration : IEntityTypeConfiguration<SystemNoticeCustomCusting>
    {
        public void Configure(EntityTypeBuilder<SystemNoticeCustomCusting> builder)
        {
            builder.HasKey(b => b.CustingID);
            builder.ToTable("SystemNoticeCustomCusting", "ajt");
        }
    }
}
