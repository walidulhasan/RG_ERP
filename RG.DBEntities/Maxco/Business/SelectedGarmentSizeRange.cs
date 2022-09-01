using RG.DBEntities.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Maxco.Business
{
    public class SelectedGarmentSizeRange
    {
        public SelectedGarmentSizeRange()
        {
            //CollarSizeSpecification = new HashSet<CollarSizeSpecification>();
            //GarmentAssortment = new HashSet<GarmentAssortment>();
            //LabelSize = new HashSet<LabelSize>();
        }

        public long ID { get; set; }
        [ForeignKey("GarmentSizeRange_Setup")]
        public int GarmentSizeRangeID { get; set; }
        [ForeignKey("SelectedElement")]
        public int SelectedElementID { get; set; }

        public virtual GarmentSizeRange_Setup GarmentSizeRange { get; set; }
        public virtual SelectedElement SelectedElement { get; set; }
        //public virtual ICollection<CollarSizeSpecification> CollarSizeSpecification { get; set; }
        //public virtual ICollection<GarmentAssortment> GarmentAssortment { get; set; }
        //public virtual ICollection<LabelSize> LabelSize { get; set; }
    }
}
