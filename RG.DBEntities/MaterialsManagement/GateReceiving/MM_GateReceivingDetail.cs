using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.GateReceiving
{
    

    public partial class MM_GateReceivingDetail
    {
        [Key]
        public int GRDID { get; set; }
        [ForeignKey("MM_GateReceiving")]
        public int GRID { get; set; }
        public int? ObjectID { get; set; }
        public int? AttributeInstanceID { get; set; }
        public double Quantity { get; set; }
        public int? StyleID { get; set; }
        public int? PODetailID { get; set; }
        public int? MRPItemCode { get; set; }

        public virtual MM_GateReceiving MM_GateReceiving { get; set; }
    }
}
