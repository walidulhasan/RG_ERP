using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.Maxco.Business;

namespace RG.Infrastructure.Persistence.MaxcoDB.Configurations.ajt
{
    public class Plan_OrderMasterConfiguration : IEntityTypeConfiguration<Plan_OrderMaster>
    {
        public void Configure(EntityTypeBuilder<Plan_OrderMaster> builder)
        {
            builder.HasKey(b => b.PlanID);
            builder.ToTable("Plan_OrderMaster", "ajt");
        }
    }
}
