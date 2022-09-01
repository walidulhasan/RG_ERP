using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Business
{
  public  class Yarn_RequisitionDetail
    {
        [Key]
        public long YarnReqDetailID { get; set; }
        public int MrpitemCode { get; set; }
        public long? AttributeInstanceID { get; set; }
        public double? OriginalQty { get; set; }
        public double? BalanceQty { get; set; }
       // [ForeignKey("Yarn_RequisitionMaster")]
        public long YarnReqID { get; set; }
        public int? OrderID { get; set; }
        public int? StyleID { get; set; }
        public long? GrossID { get; set; }
        public double? GrossQty { get; set; }
        public double? NetQty { get; set; }
        public string ColorName { get; set; }
        public int? ReadyForPo { get; set; }
        public string Remarks { get; set; }

        public virtual Yarn_RequisitionMaster Yarn_RequisitionMaster { get; set; }
    }
}
