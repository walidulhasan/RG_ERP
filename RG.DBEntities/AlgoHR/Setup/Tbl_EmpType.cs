using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.AlgoHR.Setup
{
    public class Tbl_EmpType
    {
        public int Type_ID { get; set; }
        public string Type_CD { get; set; }
        public string Type_Name { get; set; }
        public int? Type_Company { get; set; }
        public int? Type_Payroll { get; set; }
        public DateTime? Type_Created { get; set; }
        public string Type_NameBn { get; set; }
    }
}
