using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public class AssetDepartment
    {
        public int DepartmentID { get; set; }
        public int DivisionID { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentShortCode { get; set; }
        public string HRDepartmentID { get; set; }
    }
}
