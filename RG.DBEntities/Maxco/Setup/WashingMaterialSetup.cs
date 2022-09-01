using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class WashingMaterialSetup
    {
        public int? Id { get; set; }
        public string ChemicalDescription { get; set; }
        public double? Cost { get; set; }
        public int? UnitId { get; set; }
    }
}
