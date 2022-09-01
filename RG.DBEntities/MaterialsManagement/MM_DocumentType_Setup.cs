using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MM_DocumentType_Setup
    {
        [Key]
        public int DocumentTypeID { get; set; }
        public string DocumentName { get; set; }
        public string DocumentDescription { get; set; }
        public int SubModuleID { get; set; }

      //  public virtual SubModule_Setup SubModule_Setup { get; set; }
    }
}
