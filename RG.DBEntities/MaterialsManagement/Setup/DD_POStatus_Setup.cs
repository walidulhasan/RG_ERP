using RG.DBEntities.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Setup
{
   public class DD_POStatus_Setup
    {
        public DD_POStatus_Setup()
        {
            DD_PurchaseOrder = new HashSet<DD_PurchaseOrder>();
        }

        public int ID { get; set; }
        public string Description { get; set; }
        public string UsedFor { get; set; }
       public int?    CompanyId         {get;set;}
     
       public virtual ICollection<DD_PurchaseOrder> DD_PurchaseOrder { get; set; }
    }
}
