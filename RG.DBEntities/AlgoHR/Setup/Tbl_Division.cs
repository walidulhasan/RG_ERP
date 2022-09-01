using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.AlgoHR.Setup
{
    public class Tbl_Division
    {
        [Key]
        public int Division_ID { get; set; }
        public string Division_Cd { get; set; }
        public string Division_Name { get; set; }
        public int? Division_Company { get; set; }
        public DateTime? Division_Created { get; set; }
        public bool? Division_Active { get; set; }
        public string Division_Color { get; set; }
        public int RegulatoryAuthority { get; set; }
        public string Division_BName { get; set; }

    }
}
