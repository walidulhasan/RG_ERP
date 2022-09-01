using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricCalculationDimensions
    {
        public int Id { get; set; }
        public double Bodylength { get; set; }
        public double SleeveLength { get; set; }
        public int StyleId { get; set; }
    }
}
