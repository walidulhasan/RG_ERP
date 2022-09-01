using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RG.DBEntities.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.Persistence.AlgoHRDB.Configurations.ajt
{
    public class UploadedDocumentTypeConfiguration : IEntityTypeConfiguration<UploadedDocumentType>
    {
        public void Configure(EntityTypeBuilder<UploadedDocumentType> builder)
        {
            builder.HasKey(b => b.DocumentTypeID);
            builder.ToTable("UploadedDocumentType", "ajt");
        }
    }
}