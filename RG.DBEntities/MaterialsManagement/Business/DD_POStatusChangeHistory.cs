using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Business
{
  public  class DD_POStatusChangeHistory
    {
        public int ID { get; set; }
        [ForeignKey("DD_PurchaseOrder")]
        public long PurchaseOrderID { get; set; }
        
        public int Status { get; set; }
        public int UserID { get; set; }
        public DateTime Date { get; set; }
        public string Comments { get; set; }
        public int? ReasonID { get; set; }
        public DateTime? DispatchDate { get; set; }
        public string DispatchTo { get; set; }
        public int? DispatchTypeID { get; set; }

        public int? CompanyId { get; set; }
      

        public virtual DD_PurchaseOrder DD_PurchaseOrder { get; set; }
    }
}
