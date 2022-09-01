using RG.DBEntities.Maxco.Business;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class GarmentWashing
    {
        public int Id { get; set; }
        public int StyleId { get; set; }
        public int WashingCodeId { get; set; }
        public int? SelectedElementId { get; set; }

        public virtual SelectedElement SelectedElement { get; set; }
    }
}
