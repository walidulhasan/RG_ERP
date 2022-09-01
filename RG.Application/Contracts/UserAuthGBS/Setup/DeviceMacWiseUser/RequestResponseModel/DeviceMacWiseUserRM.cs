using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.UserAuthGBS.Setup.DeviceMacWiseUser.RequestResponseModel
{
    public class DeviceMacWiseUserRM
    {
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string CompanyName { get; set; }
        public string CompanyShortName { get; set; }
        public string DepartmentName { get; set; }
        public string DesignationName { get; set; }
    }
}
