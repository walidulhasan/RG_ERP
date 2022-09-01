using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class CMBL_PurchaseOrder
    {
        public long POID { get; set; }
        public long PONo { get; set; }
        public int? POStatus { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string PaymentMode { get; set; }
        public string PaymentTerm { get; set; }
        public int UserID { get; set; }
        public int? ApprvAuthorityID { get; set; }
        public int? SupplierID { get; set; }
        public string POComments { get; set; }
        public int? LocationSelStatus { get; set; }
        public int? DateSelStatus { get; set; }
        public int? PriceSelStatus { get; set; }
        public int? CompanyID { get; set; }
        public int? NoOfDays { get; set; }
        public int? ApprovedBy { get; set; }
        public string MainComments { get; set; }
        public int? PTID { get; set; }
        public byte POTypeID { get; set; }
        public string LCNumber { get; set; }
        public long? PONO_New { get; set; }
        public int? advance_percentage { get; set; }
    }
}
