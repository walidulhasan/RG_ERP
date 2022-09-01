using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblDocumentTypeSetup
    {
        public CmblDocumentTypeSetup()
        {
            CmblLog = new HashSet<CmblLog>();
        }
        [Key]
        public int DocumentTypeId { get; set; }
        public string DocumentName { get; set; }
        public string DocumentDescription { get; set; }
        public string Initials { get; set; }

        public virtual ICollection<CmblLog> CmblLog { get; set; }
    }
}
