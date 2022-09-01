using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class ModelInterlinningCosting
    {
        public int Id { get; set; }
        public int StyleId { get; set; }
        public int CollectionId { get; set; }
        public int VersionId { get; set; }
        public int RollWidthId { get; set; }
        public int ConstructionId { get; set; }
        public int InterlinningTypeId { get; set; }
        public int SolubleTypeId { get; set; }
        public double Consumption { get; set; }
        public double Rate { get; set; }
    }
}
