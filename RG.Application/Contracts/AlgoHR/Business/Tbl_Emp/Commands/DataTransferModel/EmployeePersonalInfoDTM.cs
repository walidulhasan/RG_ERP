using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Tbl_Emp.Commands.DataTransferModel
{
    public class EmployeePersonalInfoDTM
    {
        public long Emp_ID { get; set; }
        public string Emp_Cd { get; set; }
        public string Emp_oldNo { get; set; }
        public string Emp_Name { get { return $"{Emp_Fname} {Emp_Mname} {Emp_Lname}"; } }
        public string Emp_Fname { get; set; }
        public string Emp_Mname { get; set; }
        public string Emp_Lname { get; set; }
        public DateTime? Emp_Appointment { get; set; }        
        public DateTime? Emp_Confirmation { get; set; }        
        public int? emp_type { get; set; }
        public Int16? Emp_Religion { get; set; }
        public string Emp_SSN { get; set; }
        public string Emp_Father { get; set; }
        public string Emp_MotherName { get; set; }
        public string Emp_Gender { get; set; }
        public DateTime? Emp_DOB { get; set; }
        
    }
}
