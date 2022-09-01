using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Common.Utilities
{
   public class EmployeeBreakDownRM
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public int DivisionID { get; set; }
        public int DepartmentID { get; set; }
        public int SectionID { get; set; }
        public int DesignationID { get; set; }
        /// <summary>
        /// Employee ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Employee Name
        /// </summary>
        public string Name { get; set; }
        public SelectListGroup Group { get; set; }
    }
}
