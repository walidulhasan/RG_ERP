using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.AlgoHR.Setup
{
    public class Tbl_Designation
    {
        [Key]
        public int Designation_Id { get; set; }
        public string Designation_Cd { get; set; }
        public string Designation_Name { get; set; }
        public int? Designation_Grade { get; set; }
        public int? Designation_Cadre { get; set; }
        public DateTime? Designation_Created { get; set; }
        public bool? Designation_Active { get; set; }
        public string Designation_Old { get; set; }
        public string Designation_OldC { get; set; }
        public int? Designation_TextileGrade { get; set; }
        public int? Designation_GarmentGrade { get; set; }
        public string Designation_Bname { get; set; }
        public string Designation_subname { get; set; }
        public string Designation_sub { get; set; }

    }
}
