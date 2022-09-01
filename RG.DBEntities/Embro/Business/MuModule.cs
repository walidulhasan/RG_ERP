using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class MuModule
    {
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public int? ParentId { get; set; }
        public int? ServerId { get; set; }
        public string WebDirectoryName { get; set; }
    }
}
