using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Business
{
  public  class DD_POInstructions
    {
        public int ID { get; set; }
        [ForeignKey("DD_PurchaseOrder")]
        public long PurchaseOrderID { get; set; }
        public string Instruction { get; set; }
        public int CompanyId { get; set; }
       
        public virtual DD_PurchaseOrder DD_PurchaseOrder { get; set; }
    }
}
