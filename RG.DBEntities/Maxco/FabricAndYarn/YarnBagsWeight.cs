using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class YarnBagsWeight
    {
        [Key]
        public int YarnBwid { get; set; }
        public int YarnIqid { get; set; }
        public string BagNo { get; set; }
        public double Weight { get; set; }
        public int Status { get; set; }
    }
}
