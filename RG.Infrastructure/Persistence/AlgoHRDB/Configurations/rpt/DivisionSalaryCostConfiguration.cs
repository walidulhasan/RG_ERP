using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.AlgoHR.Business;

namespace RG.Infrastructure.Persistence.AlgoHRDB.Configurations.rpt
{
    public class DivisionSalaryCostConfiguration : IEntityTypeConfiguration<DivisionSalaryCost>
    {
        public void Configure(EntityTypeBuilder<DivisionSalaryCost> builder)
        {
            builder.HasKey(b => b.SalaryCostID);
            builder.ToTable("DivisionSalaryCost", "rpt");
        }
    }
}
