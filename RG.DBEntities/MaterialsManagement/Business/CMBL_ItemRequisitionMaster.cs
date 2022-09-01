using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class CMBL_ItemRequisitionMaster
    {
        public CMBL_ItemRequisitionMaster()
        {
            CMBL_ItemRequisitionRequirement = new HashSet<CMBL_ItemRequisitionRequirement>();
        }
        [Key]
        public long IRID { get; set; }
        public long IRCode { get; set; }
        public int UserID { get; set; }
        public int DepartmentID { get; set; }
        public DateTime CreationDate { get; set; }
        public int Status { get; set; }
        public int POStatus { get; set; }
        public string CreatorComments { get; set; }
        public string POComments { get; set; }
        public long? CompanyID { get; set; }
        public string StoreComments { get; set; }
        public int? StoreID { get; set; }
        public int? BuyerID { get; set; }
        public int? ReqTypeID { get; set; }
        public byte ReqTypes { get; set; }
        public long? ReqRef { get; set; }
        public int? LoanStoreID { get; set; }
        public long LocationID { get; set; }
        public long? LoanCompanyID { get; set; }
        public int? WashingStageID { get; set; }
        public virtual ICollection<CMBL_ItemRequisitionRequirement> CMBL_ItemRequisitionRequirement { get; set; }
    }
}
