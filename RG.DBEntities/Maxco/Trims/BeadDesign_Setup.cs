using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class BeadDesign_Setup
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int? TrimID { get; set; }
    }
}
