using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class MuModule2
    {
        public int Id { get; set; }
        public double? ModuleId { get; set; }
        public string ModuleName { get; set; }
        public double? ParentId { get; set; }
        public string ModuleLink { get; set; }
    }
}
