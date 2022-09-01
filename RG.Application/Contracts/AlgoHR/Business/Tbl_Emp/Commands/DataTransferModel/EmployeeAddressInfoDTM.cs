using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Tbl_Emp.Commands.DataTransferModel
{
    public class EmployeeAddressInfoDTM
    {
        public long Emp_ID { get; set; }
        public Int16? Emp_Country1 { get; set; }
        public Int16? Emp_Country2 { get; set; }
        public string Emp_State1 { get; set; }
        public string Emp_State2 { get; set; }
        public string Emp_City1 { get; set; }
        public string Emp_City2 { get; set; }
        public string Emp_Address1 { get; set; }
        public string Emp_Address2 { get; set; }
        public string Emp_Zip1 { get; set; }
        public string Emp_Zip2 { get; set; }
    }
}
