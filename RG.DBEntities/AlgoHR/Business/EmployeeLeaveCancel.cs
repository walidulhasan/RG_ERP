using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.AlgoHR.Business
{
    public class EmployeeLeaveCancel: DefaultTableProperties
    {
        public int LeaveCancelID { get; set; }
        public long EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public long LeaveID { get; set; }
        public string Reason { get; set; }
        public string Recommendation { get; set; }
    }
}
