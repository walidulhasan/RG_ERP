using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.UserAuthGBS.API.UserInfos.Queries
{
    public class UsersRM
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string UserCompany { get; set; }
        public string ProjectRole { get; set; }
        public string DepartmentName { get; set; }
        public string DesignationName { get; set; }
    }
}
