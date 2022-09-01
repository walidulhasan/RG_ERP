using RG.DBEntities.Maxco.Business;
using RG.DBEntities.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricTrimSelected
    {
        public FabricTrimSelected()
        {
            FabricSpecification = new HashSet<FabricSpecification>();
        }

        public int ID { get; set; }
        [ForeignKey("FabricTrims_Setup")]
        public int? FabricTrimID { get; set; }
        [ForeignKey("SelectedElement")]
        public int SelectedElementID { get; set; }
        public int? Status { get; set; }

        public virtual FabricTrims_Setup FabricTrims_Setup { get; set; }
        public virtual SelectedElement SelectedElement { get; set; }
        public virtual ICollection<FabricSpecification> FabricSpecification { get; set; }
    }
}
