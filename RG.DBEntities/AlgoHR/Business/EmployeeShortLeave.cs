using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.AlgoHR.Business
{
    public class EmployeeShortLeave:DefaultTableProperties
    {
        public int ShortLeaveID { get; set; }
        public long EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public bool Returnable { get; set; }
        public DateTime LeaveDate { get; set; }
        public string LeaveTimeFrom { get; set; }
        public string LeaveTimeTo { get; set; }
        public string LeaveReason { get; set; }
        public string LeaveAddress { get; set; }
        public bool? IsApproved { get; set; }
    }
}
