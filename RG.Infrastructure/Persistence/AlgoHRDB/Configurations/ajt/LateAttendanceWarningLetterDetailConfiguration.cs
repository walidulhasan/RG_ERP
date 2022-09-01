using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.AlgoHR.Business;

namespace RG.Infrastructure.Persistence.AlgoHRDB.Configurations.ajt
{
    public class LateAttendanceWarningLetterDetailConfiguration : IEntityTypeConfiguration<LateAttendanceWarningLetterDetail>
    {
        public void Configure(EntityTypeBuilder<LateAttendanceWarningLetterDetail> builder)
        {
            builder.HasKey(b => b.LetterDetailID);
            builder.ToTable("LateAttendanceWarningLetterDetail", "ajt");
        }
    }
}
