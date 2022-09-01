using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class Greige_IssuanceAgainstDyeingContract_Detail
    {
        public int ID { get; set; }
        [ForeignKey("Greige_DyeingContractMaster")]
        public int DCID { get; set; }
        public long DCGAttributeInstanceID { get; set; }
        public long StockGAttributeInstanceID { get; set; }
        public int? RollID { get; set; }
        public string RollNo { get; set; }
        public double? Quantity { get; set; }
        public string PantoneNo { get; set; }
        public DateTime? TransactionDate { get; set; }
        public bool? Status { get; set; }
        public long? IssuanceID { get; set; }

        public virtual Greige_DyeingContractMaster Greige_DyeingContractMaster { get; set; }
    }
}
