using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.AlgoHR;
using RG.DBEntities.AlgoHR.Business;

namespace RG.Infrastructure.Persistence.AlgoHRDB.Configurations.ajt
{
    public class LateAttendanceWarningLetterMasterConfiguration : IEntityTypeConfiguration<LateAttendanceWarningLetterMaster>
    {
        public void Configure(EntityTypeBuilder<LateAttendanceWarningLetterMaster> builder)
        {
            builder.HasKey(b => b.LetterMasterID);
            builder.ToTable("LateAttendanceWarningLetterMaster", "ajt");
        }
    }
}
