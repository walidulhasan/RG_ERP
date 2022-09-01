using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries.RequestResponseModel
{
    public class GatepassRM
    {
        public byte? CategoryID { get; set; }
        public string CategoryName { get; set; }
        public long GatePassID { get; set; }
        public string Serial { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public bool IsApprovedByAccounts { get; set; }
        public bool isApproved { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedTime { get; set; }
        public bool? IsDeleted { get; set; }
        public string VehicleNo { get; set; }
        public long? IssuedById { get; set; }
        public string IssuedBy { get; set; }
        public long? DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string CustomerName { get; set; }
        public string IsExpired { get; set; }
        public long? ApprovedByID { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? ApprovedOn { get; set; }
        public long? MarkedOutByID { get; set; }
        public string MarkedOutBy { get; set; }
        public DateTime? MarkedOutOn { get; set; }
        public string Status { get; set; }
        public string CatName { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool IsSatisfied { get; set; }
        public int? ExpireDayes { get; set; }
        public int CA_UserID { get; set; }
        public string CreatedEmployee { get; set; }
        public string CreatedEmployeeDept { get; set; }
        public string CreatedEmployeeDesig { get; set; }
        public bool IsAccountsApprovalRequired { get; set; }
    }
}
