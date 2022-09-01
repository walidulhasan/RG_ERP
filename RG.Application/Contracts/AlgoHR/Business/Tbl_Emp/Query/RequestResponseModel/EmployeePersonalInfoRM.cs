using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Tbl_Emp.Query.RequestResponseModel
{
    public class EmployeePersonalInfoRM
    {
        public long Emp_ID { get; set; }
        public string Emp_Cd { get; set; }
        public string Emp_oldNo { get; set; }
        public string Emp_Name { get; set; }
        public string Emp_Fname { get; set; }
        public string Emp_Mname { get; set; }
        public string Emp_Lname { get; set; }
        public DateTime? Emp_Appointment { get; set; }
        public string Emp_AppointmentMsg { get { return Emp_Appointment==null?"":Emp_Appointment.Value.ToString("dd-MMM-yyyy"); } }
        public DateTime? Emp_Confirmation { get; set; }
        public string Emp_ConfirmationMsg { get { return Emp_Confirmation==null?"": Emp_Confirmation.Value.ToString("dd-MMM-yyyy"); } }
        public int? emp_type { get; set; }
        public Int16? Emp_Religion { get; set; }
        public string Emp_SSN { get; set; }
        public string Emp_Gender { get; set; }
        public string Emp_Father { get; set; }
        public string Emp_MotherName { get; set; }
        public DateTime? Emp_DOB { get; set; }
        public string Emp_DOBMsg { get { return Emp_DOB==null?"":Emp_DOB.Value.ToString("dd-MMM-yyyy"); } }
        
    }
}
