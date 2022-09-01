using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.Embro.Setup
{
    public class CBM_Employee
    {
        [Key]
        public decimal EmpId { get; set; }
        public string EmpNum { get; set; }
        public string EmpName { get; set; }
        public string EmpDept { get; set; }
        public string EmpSection { get; set; }
        public string EmpDesig { get; set; }
        public string EmpCategory { get; set; }
        public decimal? CompId { get; set; }
    }
}
