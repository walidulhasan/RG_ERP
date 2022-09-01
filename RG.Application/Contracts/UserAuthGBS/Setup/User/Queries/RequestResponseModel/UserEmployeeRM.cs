using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.UserAuthGBS.Setup.User.Queries.RequestResponseModel
{
    public class UserEmployeeRM
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public string Email { get; set; }
        public string DepartmentName { get; set; }
        public int SourceEmployeeID { get; set; }
        public int SourceUserID { get; set; }
    }
}
