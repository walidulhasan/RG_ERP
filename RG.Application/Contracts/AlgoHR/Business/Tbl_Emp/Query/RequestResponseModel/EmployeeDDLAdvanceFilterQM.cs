using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Tbl_Emp.Query.RequestResponseModel
{
    public class EmployeeDDLAdvanceFilterQM
    {
        public EmployeeDDLAdvanceFilterQM()
        {
            Companys = new List<int>();
            Divisions = new List<int>();
            Departments = new List<int>();
            Sections = new List<int>();
            Designation = new List<int>();
            Locations = new List<int>();
            EmployeeTypes = new List<int>();

            ActiveStatus = true;
            Predict = null;
        }
        public List<int> Companys { get; set; }
        public List<int> Divisions { get; set; }
        public List<int> Departments { get; set; }
        public List<int> Sections { get; set; }
        public List<int> Designation { get; set; }
        public List<int> Locations { get; set; }
        public List<int> EmployeeTypes { get; set; }
        public string Genders { get; set; }
        public bool? ActiveStatus { get; set; }
        public string Predict { get; set; }
    }
}
