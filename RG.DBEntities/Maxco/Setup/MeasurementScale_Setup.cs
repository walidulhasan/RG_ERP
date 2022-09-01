using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class MeasurementScale_Setup
    {
        public MeasurementScale_Setup()
        {
            //StyleElementMeasurementScale = new HashSet<StyleElementMeasurementScale>();
            //TrimMeasurementScaleSetup = new HashSet<TrimMeasurementScaleSetup>();
        }

        public int ID { get; set; }
        public string Description { get; set; }

       // public virtual ICollection<StyleElementMeasurementScale> StyleElementMeasurementScale { get; set; }
       // public virtual ICollection<TrimMeasurementScaleSetup> TrimMeasurementScaleSetup { get; set; }
    }
}
