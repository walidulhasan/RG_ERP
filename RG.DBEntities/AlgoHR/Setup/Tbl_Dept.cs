using System;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.AlgoHR.Setup
{
    public class Tbl_Dept
    {
        [Key]
        public int Dept_ID { get; set; }
        public string Dept_CD { get; set; }
        public string Dept_Name { get; set; }
        public int? Dept_Division { get; set; }
        public string Dept_Color { get; set; }
        public DateTime Dept_Created { get; set; }
        public int? Dept_User { get; set; }
        public bool? Dept_Active { get; set; }
        public int? Dept_FinanceID { get; set; }
        public int? Dept_Finance_GrossAccount { get; set; }
        public string Dept_BName { get; set; }
        public string Dept_subname { get; set; }
        public string Dept_Unit { get; set; }

    }
}
