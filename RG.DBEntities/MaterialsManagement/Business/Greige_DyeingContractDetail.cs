using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class Greige_DyeingContractDetail
    {
        public int ID { get; set; }
        [ForeignKey("Greige_DyeingContractMaster")]
        public int ContractID { get; set; }
        public long AttributeInstanceId { get; set; }
        public int? UnitID { get; set; }
        public int? OrderID { get; set; }
        public int? ModelID { get; set; }
        public int? MRPItemCode { get; set; }
        public int? ReqSheetID { get; set; }
        public double? Quantity { get; set; }
        public double? Balance { get; set; }
        public double? Rate { get; set; }
        public string DeliveryDate { get; set; }
        public int? DeliveryPointID { get; set; }
        public string Remarks { get; set; }
        public long? GreigeAttributeInstanceID { get; set; }
        public string PantoneNo { get; set; }
        public int? MatchingSourceID { get; set; }
        public int? FinishingCodeID { get; set; }
        public int? ProgramTypeID { get; set; }
        public long? PantoneID { get; set; }
        public int? week { get; set; }
        public int? year { get; set; }
        public virtual Greige_DyeingContractMaster Greige_DyeingContractMaster { get; set; }
    }
}
