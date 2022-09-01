using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.FiniteScheduler.DBViews;

namespace RG.Infrastructure.Persistence.FiniteSchedulerDB.Configurations.DbViews
{
    public class Vw_HR_CompanyDepartmentConfiguration : IEntityTypeConfiguration<Vw_HR_CompanyDepartment>
    {
        public void Configure(EntityTypeBuilder<Vw_HR_CompanyDepartment> builder)
        {
            builder.HasKey(x => x.Dept_ID);
            builder.ToTable("Vw_HR_CompanyDepartment", "rpt");
        }
    }
}