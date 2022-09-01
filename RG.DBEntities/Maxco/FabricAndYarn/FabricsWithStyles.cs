using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricsWithStyles
    {
        public int Id { get; set; }
        public int FabricId { get; set; }
        public byte FabricTrimId { get; set; }
        public string FabricTrim { get; set; }
        public long StyleId { get; set; }
    }
}
