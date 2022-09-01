using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Setup
{
    public class MM_UnitConversion_Setup
    {
        public int ID { get; set; }
        public int UnitID { get; set; }
        public int ConvertedUnitID { get; set; }
        public double ConversionFormula { get; set; }
    }
}
