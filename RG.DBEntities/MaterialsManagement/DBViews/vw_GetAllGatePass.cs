using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.MaterialsManagement.DBViews
{
    public class vw_GetAllGatePass
    {
        [Key]
        public long GatePassID { get; set; }
        public byte? CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool? IsAccountsApprovalRequired { get; set; }
        public string Serial { get; set; }
        public bool? IsApprovedByAccounts { get; set; }
        public long? AccountsApprovedBy { get; set; }
        public string AccountsApprovedEmp { get; set; }
        public DateTime? AccountsApprovalDate { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public string CreationDate { get; set; }
        public string CreationTime { get; set; }
        public bool? isApproved { get; set; }
        public long? ApprovedBy { get; set; }
        public string ApprovalEmp { get; set; }
        public DateTime? ApprovedDateTime { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedTime { get; set; }
        public bool? isDeleted { get; set; }
        public string VehicleNo { get; set; }
        public long? IssuedBy { get; set; }
        public string IssuerEmp { get; set; }
        public bool? isMarkedOut { get; set; }
        public long? MarkedOutBy { get; set; }
        public string MarkOutEMP { get; set; }
        public DateTime? MarkOutDateTime { get; set; }
        public long? DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public int? CustomerTypeID { get; set; }
        public long? CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int? IsExpired { get; set; }
        public DateTime? ExpectedReturnDate { get; set; }
        public int? ExpireDayes { get; set; }
        public decimal? BalanceQuantity { get; set; }
        public string Status { get; set; }
        public bool IsSatisfied { get; set; }
        public int CA_UserID { get; set; }
    }
}
