using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class SubModule_Setup
    {
        public SubModule_Setup()
        {
           // MM_DocumentType_Setup = new HashSet<MM_DocumentType_Setup>();
        }
        [Key]
        public int SubModuleID { get; set; }
        public int ModuleID { get; set; }
        public string SubModuleName { get; set; }

      //  public virtual Module_Setup Module_Setup { get; set; }
      //  public virtual ICollection<MM_DocumentType_Setup> MM_DocumentType_Setup { get; set; }
    }
}
