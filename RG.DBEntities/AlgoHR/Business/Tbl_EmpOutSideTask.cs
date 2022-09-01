using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.AlgoHR.Business
{
    public class Tbl_EmpOutSideTask : DefaultTableProperties
    {
        public int OutSideTaskID { get; set; }
        public long EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public DateTime OutsideTaskDate { get; set; }
        public string TaskDurationType { get; set; }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
        public string Reason { get; set; }
        public string TaskAddress { get; set; }
        public int? IsApproved { get; set; }
    }
}
