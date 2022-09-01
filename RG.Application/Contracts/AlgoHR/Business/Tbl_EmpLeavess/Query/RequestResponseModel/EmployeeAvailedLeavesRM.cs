using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Tbl_EmpLeavess.Query.RequestResponseModel
{
    public class EmployeeAvailedLeavesRM
    {
        public long EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public int LeaveID { get; set; }
        public int AvailedLeaveCount { get; set; }
    }
}
