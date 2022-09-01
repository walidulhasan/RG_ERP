using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Tbl_Emp.Query.RequestResponseModel
{
    public class EmployeeToSectionRM
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string CompnayShort { get; set; }

        public int DivisionID { get; set; }
        public string DivisionName { get; set; }

        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }

        public int SectionID { get; set; }
        public string SectionName { get; set; }

        public int LocationID { get; set; }
        public string LocationName { get; set; }

        public int DesignationID { get; set; }
        public string DesignationName { get; set; }

        public int UserID { get; set; }
        public string UserName { get; set; }

        public bool isSelected { get; set; }
    }
}
