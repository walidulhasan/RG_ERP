using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class MuModule
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public int? ParentId { get; set; }
        public string ModuleLink { get; set; }
    }
}
