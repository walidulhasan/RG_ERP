using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.MaterialsManagement.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.Persistence.MaterialsManagementDB.Configurations.Setup
{
    public class CMBL_POQuotationFileUploadConfiguration : IEntityTypeConfiguration<CMBL_POQuotationFileUpload>
    {
        public void Configure(EntityTypeBuilder<CMBL_POQuotationFileUpload> builder)
        {
            builder.ToTable("CMBL_POQuotationFileUpload");
            builder.HasKey(e => e.POAttachmentID);
        }

    }
}
