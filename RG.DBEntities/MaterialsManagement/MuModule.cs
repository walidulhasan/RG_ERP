using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MuModule
    {
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public int? ParentId { get; set; }
        public string ModuleLink { get; set; }
    }
}
