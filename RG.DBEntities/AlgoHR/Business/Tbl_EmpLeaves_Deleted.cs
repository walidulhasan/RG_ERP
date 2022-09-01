using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.AlgoHR.Business
{
    public class Tbl_EmpLeaves_Deleted
    {
        public long ID { get; set; }
        public int? LeaveApplicationID { get; set; }
        public long? Leave_Emp { get; set; }
        public string Leave_EmpCD { get; set; }
        public int? Leave_ID { get; set; }
        public short? Leave_Fiscal { get; set; }
        public DateTime? Leave_From { get; set; }
        public DateTime? Leave_To { get; set; }
        public DateTime? Leave_Created { get; set; }
        public string Leave_Reason { get; set; }
        public string Leave_User { get; set; }
        public bool? Leave_Approved { get; set; }
        public string Leave_Code { get; set; }
        public string Leave_Address { get; set; }
    }
}
