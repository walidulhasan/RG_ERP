using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.Persistence.MaterialsManagementDB.Configurations.Business
{
    public class YarnRackIssueConfiguration : IEntityTypeConfiguration<YarnRackIssue>
    {
        public void Configure(EntityTypeBuilder<YarnRackIssue> builder)
        {
            builder.ToTable("YarnRackIssue", "ajt");
            builder.HasKey(e => e.RackIssueID);
        }
    }
}
