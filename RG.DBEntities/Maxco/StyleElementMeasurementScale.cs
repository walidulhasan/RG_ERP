using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco
{
    public partial class StyleElementMeasurementScale
    {
        public StyleElementMeasurementScale()
        {
            EmbroSpecification = new HashSet<EmbroSpecification>();
            FusingSpecification = new HashSet<FusingSpecification>();
            PrintingSpecification = new HashSet<PrintingSpecification>();
        }

        public int Id { get; set; }
        public byte MeasurementScaleId { get; set; }
        public int OrderStyleElementId { get; set; }

        public virtual MeasurementScale_Setup MeasurementScale { get; set; }
        public virtual OrderStyleElement_Setup OrderStyleElement { get; set; }
        public virtual ICollection<EmbroSpecification> EmbroSpecification { get; set; }
        public virtual ICollection<FusingSpecification> FusingSpecification { get; set; }
        public virtual ICollection<PrintingSpecification> PrintingSpecification { get; set; }
    }
}
