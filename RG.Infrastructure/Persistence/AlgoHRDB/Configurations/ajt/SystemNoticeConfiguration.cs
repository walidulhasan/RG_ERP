using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.AlgoHR.Setup;

namespace RG.Infrastructure.Persistence.AlgoHRDB.Configurations.ajt
{

    public class SystemNoticeConfiguration : IEntityTypeConfiguration<SystemNotice>
    {
        public void Configure(EntityTypeBuilder<SystemNotice> builder)
        {
            builder.HasKey(b => b.NoticeID);
            builder.ToTable("SystemNotice", "ajt");
        }
    }
}
