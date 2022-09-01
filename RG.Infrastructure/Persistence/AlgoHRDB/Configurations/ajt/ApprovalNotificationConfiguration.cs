using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.AlgoHR.Business;

namespace RG.Infrastructure.Persistence.AlgoHRDB.Configurations.ajt
{
    public class ApprovalNotificationConfiguration : IEntityTypeConfiguration<ApprovalNotification>
    {
        public void Configure(EntityTypeBuilder<ApprovalNotification> builder)
        {
            builder.HasKey(b => b.NotificationID);
            builder.ToTable("ApprovalNotification", "ajt");
        }
    }
}
