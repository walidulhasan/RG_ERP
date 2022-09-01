using RG.DBEntities.Maxco.Business;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class OrderStyleElement_Setup
    {
        public OrderStyleElement_Setup()
        {
            PrintEmbroImage_Setup = new HashSet<PrintEmbroImage_Setup>();
            SelectedElement = new HashSet<SelectedElement>();
            //StyleElementMeasurementScale = new HashSet<StyleElementMeasurementScale>();
        }

        public int ID { get; set; }
        public string Description { get; set; }
        public bool IsOptional { get; set; }
        public bool IsStyleElement { get; set; }
        public string URL { get; set; }
        public string AjtURL { get; set; }
        public int? Sequence { get; set; }
        public bool? IsDefaultConsumptionElement { get; set; }
        public bool? IsDefaultStyleElement { get; set; }
        public virtual ICollection<PrintEmbroImage_Setup> PrintEmbroImage_Setup { get; set; }
       public virtual ICollection<SelectedElement> SelectedElement { get; set; }
      //  public virtual ICollection<StyleElementMeasurementScale> StyleElementMeasurementScale { get; set; }
    }
}
