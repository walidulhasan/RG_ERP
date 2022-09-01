using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class PolyBagCode
    {
        public int Id { get; set; }
        public int PolyBagSpecsId { get; set; }
        public int? StyleId { get; set; }
        public int PolyBagCodeTypeId { get; set; }
        public int? SizeSetId { get; set; }
        public int? ColorSetId { get; set; }
        public string Code { get; set; }
    }
}
