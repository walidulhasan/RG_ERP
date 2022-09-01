using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.AlgoHR.Setup;

namespace RG.Infrastructure.Persistence.AlgoHRDB.Configurations.dbo
{
    public class Tbl_EmpTypeConfiguration : IEntityTypeConfiguration<Tbl_EmpType>
    {
        public void Configure(EntityTypeBuilder<Tbl_EmpType> builder)
        {
            builder.HasKey(b => b.Type_ID);
        }
    }
}
