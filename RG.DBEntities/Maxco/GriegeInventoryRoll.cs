using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco
{
    public partial class GriegeInventoryRoll
    {[Key]
        public int GreigeIrid { get; set; }
        public int GreigeInventoryId { get; set; }
        public string RollNo { get; set; }
        public double Quantity { get; set; }
        public int UnitId { get; set; }
    }
}
