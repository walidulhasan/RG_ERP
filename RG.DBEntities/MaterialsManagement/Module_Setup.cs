using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class Module_Setup
    {
        public Module_Setup()
        {
            SubModule_Setup = new HashSet<SubModule_Setup>();
        }
        [Key]
        public int ModuleID { get; set; }
        public string ModuleName { get; set; }
        public string ModuleDescription { get; set; }

        public virtual ICollection<SubModule_Setup> SubModule_Setup { get; set; }
    }
}
