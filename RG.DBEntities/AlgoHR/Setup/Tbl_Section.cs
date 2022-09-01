using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.AlgoHR.Setup
{
    public class Tbl_Section
    {
        [Key]
        public int Section_Id { get; set; }
        public string Section_Cd { get; set; }
        public string Section_Name { get; set; }
        public DateTime? Section_Created { get; set; }
        public bool? Section_Active { get; set; }
        public int? Section_Dept { get; set; }
        public int? Section_Location { get; set; }
        public string Section_Color { get; set; }
        public string Section_DeptOld { get; set; }
        public string Section_Loc { get; set; }
        public string Section_BName { get; set; }

    }
}
