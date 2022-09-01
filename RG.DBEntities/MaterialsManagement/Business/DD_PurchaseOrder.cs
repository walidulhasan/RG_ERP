using RG.DBEntities.MaterialsManagement.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Business
{
   public class DD_PurchaseOrder
    {
        public DD_PurchaseOrder()
        {
            DD_POInstructions = new HashSet<DD_POInstructions>();
            DD_POItemMaster = new HashSet<DD_POItemMaster>();
            DD_POStatusChangeHistory = new HashSet<DD_POStatusChangeHistory>();
        }

        public long ID { get; set; }
        public string PurchaseOrderNo { get; set; }
        public int SigningAuthorityID { get; set; }
        public int SupplierID { get; set; }
        public int? ContactPersonID { get; set; }
        public string SpecialComments { get; set; }
        public DateTime? CreationDate { get; set; }
        [ForeignKey("DD_POStatus_Setup")]
        public int? Status { get; set; }
        public int? UserID { get; set; }
        public int? ParentPOID { get; set; }
        public int? VersionNo { get; set; }
        public int? OriginalPOID { get; set; }
        public int? RevisionReasonID { get; set; }
        public int? PriceSelection { get; set; }
        public int? LocationSelection { get; set; }
        public int? DeliveryDateSelection { get; set; }
        public string PaymentMode { get; set; }
        public string PaymentTerm { get; set; }
        public int Consolidate { get; set; }
        public int? PaymentTermDays { get; set; }
        public string PaymentSubTerm { get; set; }
        public int? IsImported { get; set; }
        public int? NoOfDays { get; set; }
        public int? IsIndReq { get; set; }
        public long? CompanyID { get; set; }
        public long? BusinessID { get; set; }
        public int? LCM_ID { get; set; }
        public int? advance_percentage { get; set; }
     
        
        public virtual DD_POStatus_Setup DD_POStatus_Setup { get; set; }
        public virtual ICollection<DD_POInstructions> DD_POInstructions { get; set; }
        public virtual ICollection<DD_POItemMaster> DD_POItemMaster { get; set; }
        public virtual ICollection<DD_POStatusChangeHistory> DD_POStatusChangeHistory { get; set; }
    }
}
