using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class VStyleColorSearch
    {
        public int Id { get; set; }
        public long ColorId { get; set; }
        public string ColorName { get; set; }
        public string Description { get; set; }
        public byte? FabricTrimId { get; set; }
    }
}
