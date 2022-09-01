using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.AlgoHR.DBViews
{
    public class Viw_ApprovalConfiguration
    {
        public int ConfigMasterID { get; set; }
        public string ModuleName { get; set; }
        public int Cmp_ID { get; set; }
        public string Cmp_Name { get; set; }
        public string Cmp_ShortName { get; set; }
        public int EmbroCompanyID { get; set; }
        public int ConfigDetailID { get; set; }
        public int ApprovalLevel { get; set; }
        public string Division_Name { get; set; }
        public int? Division_ID { get; set; }
        public int? Dept_ID { get; set; }
        public string Dept_Name { get; set; }
        public int Section_Id { get; set; }
        public string Section_Name { get; set; }
        public int? Designation_Id { get; set; }
        public string Designation_Name { get; set; }
        public long AppEmpID { get; set; }
        public string AppEmpCode { get; set; }
        public string ApplEmpName { get; set; }
        public string AppDesignation { get; set; }
    }
}
