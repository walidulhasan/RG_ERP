using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.UserAuthGBS.API.UserInfos.Queries
{
   public class LoggedUserInfoResponseModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int? EmployeeID { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }
        public int RoleID { get; set; }
        public int? CompanyID { get; set; }
        public int? BusinessID { get; set; }
        public string BusinessName { get; set; }
        public int? DomainID { get; set; }
        public int? AlgoUserID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public bool IsSuperAdminRole { get; set; }
        public string RoleName { get; set; }
        public string CompanyName { get; set; }
        public string CompanyShortName { get; set; }
        public string CompanyAddress { get; set; }
        public string DesignationName { get; set; }
        public string DepartmentName { get; set; }
    }
}
