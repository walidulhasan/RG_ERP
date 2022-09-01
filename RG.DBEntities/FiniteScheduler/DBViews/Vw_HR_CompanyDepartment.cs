using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.FiniteScheduler.DBViews
{
    public class Vw_HR_CompanyDepartment
    {
        public int Dept_ID { get; set; }
        public string Dept_Name { get; set; }
        public int Dept_CD { get; set; }
        public int Division_ID { get; set; }
        public string Division_Name { get; set; }
        public string Division_Cd { get; set; }
        public int EmbroCompanyID { get; set; }
        public string Cmp_Name { get; set; }
        public string Cmp_ShortName { get; set; }
        public string Cmp_Address { get; set; }
    }
}
