using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Setup
{
    public class Department
    {
        public int ID { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentNameUc { get; set; }
        public string Code { get; set; }
        public int CompanyID { get; set; }
    }
}
