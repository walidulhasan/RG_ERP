using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Business
{
   public partial class ModelConsumptionSelectedElement
    {
        public int ID { get; set; }
        public long StyleID { get; set; }
        public int ElementID { get; set; }
        public bool CapturingStatus { get; set; }
    }
}
