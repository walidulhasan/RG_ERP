using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class CMBL_ItemRequisitionRequirement
    {
        [Key]
        public long IRRID { get; set; }
        [ForeignKey("CMBL_ItemRequisitionMaster")]
        public long IRID { get; set; }
        public long ItemID { get; set; }
        public int UserSelectedUnitID { get; set; }
        public double ReqQuantity { get; set; }
        public int Status { get; set; }
        public int POStatus { get; set; }
        public double? ReducedQuantity { get; set; }
        public double? ReservedQuantity { get; set; }
        public string ReducedReason { get; set; }
        public DateTime? ReqDate { get; set; }
        public double? InPOQuantity { get; set; }
        public double IssuedQuantity { get; set; }
        public double? PrePOQuantity { get; set; }
        public int? OrderID { get; set; }
        public double? FabricQty { get; set; }
        public string Color { get; set; }
        public int? IsLoan { get; set; }
        public double ReturnedQuantity { get; set; }
        public long? Lot_Id { get; set; }
        public string Lot_No { get; set; }
        public string ReqMachineName { get; set; }
        public int? ReqMachineCap { get; set; }
        public string ReqMachineNo { get; set; }
        public int? ProcessID { get; set; }
        public double? ByWeight { get; set; }
        public double? ByGramPerLitre { get; set; }
        public double? LiquorRatio { get; set; }
        public virtual CMBL_ItemRequisitionMaster CMBL_ItemRequisitionMaster { get; set; }
    }
}
