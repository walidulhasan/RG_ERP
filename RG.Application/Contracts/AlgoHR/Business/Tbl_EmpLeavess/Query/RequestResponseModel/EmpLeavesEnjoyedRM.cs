using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Tbl_EmpLeavess.Query.RequestResponseModel
{
    public class EmpLeavesEnjoyedRM
    {
        public long EmployeeID { get; set; }
        public int LeaveTypeID { get; set; }
        public int LeaveEnjoyed { get; set; }
        public string LeaveDate { get; set; }
    }
}
