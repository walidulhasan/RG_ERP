using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Tbl_EmpAttendances.Query.RequestResponseModel
{
    public class EmployeeShiftShortInfoRM
    {
        public int EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public int ShiftID { get; set; }
        public string ShiftName { get; set; }
        public DateTime ShiftDate { get; set; }
        public DateTime ShiftIn { get; set; }
        public DateTime ShiftOut { get; set; }
    }
}
