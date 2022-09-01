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
    public class CMBL_StatusPOConfiguration : IEntityTypeConfiguration<CMBL_StatusPO>
    {
        public void Configure(EntityTypeBuilder<CMBL_StatusPO> builder)
        {
            builder.ToTable("CMBL_StatusPO", "dbo");
            builder.HasKey(e => e.StatusID);
        }
    }
}
