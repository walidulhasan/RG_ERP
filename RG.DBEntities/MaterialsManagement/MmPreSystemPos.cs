using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MmPreSystemPos
    {
        public MmPreSystemPos()
        {
            MmMaterialReceivingWithOutPomaster = new HashSet<MmMaterialReceivingWithOutPomaster>();
        }
        [Key]
        public int PspoId { get; set; }
        public int SupplierId { get; set; }
        public int OrderId { get; set; }
        public string ContactPerson { get; set; }
        public string Pono { get; set; }
        public DateTime Podate { get; set; }
        public string DeliveryChallanNo { get; set; }
        public DateTime DeliveryChallanDate { get; set; }
        public string InvoiceNo { get; set; }
        public string VehicleNo { get; set; }

        public virtual ICollection<MmMaterialReceivingWithOutPomaster> MmMaterialReceivingWithOutPomaster { get; set; }
    }
}
