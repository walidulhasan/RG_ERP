using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class QrmOrderSheetInterlinningActual
    {
        public int Id { get; set; }
        public int VersionId { get; set; }
        public int RollWidthId { get; set; }
        public string RollWidth { get; set; }
        public int ConstructionId { get; set; }
        public string Construction { get; set; }
        public int TypeId { get; set; }
        public string Type { get; set; }
        public int SolubleTypeId { get; set; }
        public string SolubleType { get; set; }
        public double? OrderConsumption { get; set; }
        public double? CostingRate { get; set; }
        public double? Acqty { get; set; }
        public double? Acrate { get; set; }
        public double? Acamount { get; set; }
        public double? Acvariance { get; set; }
    }
}
