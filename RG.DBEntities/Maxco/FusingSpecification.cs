using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco
{
    public partial class FusingSpecification
    {
        public long Id { get; set; }
        public int FusingTypeId { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public int StyleElementMeasurementScaleId { get; set; }
        public int ObjectId { get; set; }

        public virtual FusingTypeSetup FusingType { get; set; }
        public virtual StyleElementMeasurementScale StyleElementMeasurementScale { get; set; }
    }
}
