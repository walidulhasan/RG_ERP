using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Business
{
   public class DD_POItemDetails
    {
        public int ID { get; set; }
        public double Quantity { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Remarks { get; set; }
        [ForeignKey("DD_POItemMaster")]
        public int POItemMasterID { get; set; }
        public int? DeliveryPointID { get; set; }
        public double? Rate { get; set; }
        public double? Balance { get; set; }
        public double? ConvPrice { get; set; }
        public double? CurrencyRate { get; set; }
        public int? CurrencyID { get; set; }
        public int? CompanyId { get; set; }
       

        public virtual DD_POItemMaster DD_POItemMaster { get; set; }
    }
}
