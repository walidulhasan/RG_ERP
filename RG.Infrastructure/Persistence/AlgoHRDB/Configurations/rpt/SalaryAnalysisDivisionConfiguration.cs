using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.AlgoHR.Business;

namespace RG.Infrastructure.Persistence.AlgoHRDB.Configurations.rpt
{
    public class SalaryAnalysisDivisionConfiguration : IEntityTypeConfiguration<SalaryAnalysisDivision>
    {
        public void Configure(EntityTypeBuilder<SalaryAnalysisDivision> builder)
        {
            builder.HasKey(b => b.SalaryAnalysisDivisionID);
            builder.ToTable("SalaryAnalysisDivision", "rpt");
        }
    }
}