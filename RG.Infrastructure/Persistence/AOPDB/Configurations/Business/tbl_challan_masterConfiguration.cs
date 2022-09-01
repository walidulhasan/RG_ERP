using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.AOP.Business;

namespace RG.Infrastructure.Persistence.AOPDB.Configurations.Business
{
    public class tbl_challan_masterConfiguration : IEntityTypeConfiguration<tbl_challan_master>
    {
        public void Configure(EntityTypeBuilder<tbl_challan_master> builder)
        {
            builder.ToTable("tbl_challan_master", "dbo");
            builder.HasKey(b => b.challan_id);
        }
    }
}
