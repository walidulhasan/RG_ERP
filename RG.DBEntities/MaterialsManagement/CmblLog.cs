using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblLog
    {
        [Key]
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public long PrimaryKey { get; set; }
        public int DocumentTypeId { get; set; }
        public DateTime LogDate { get; set; }
        public long LogId { get; set; }

        public virtual CmblCategory Category { get; set; }
        public virtual CmblDocumentTypeSetup DocumentType { get; set; }
    }
}
