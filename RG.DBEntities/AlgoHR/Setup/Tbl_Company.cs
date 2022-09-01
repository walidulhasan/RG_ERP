using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.AlgoHR.Setup
{
    public class Tbl_Company
    {
        [Key]
        public int Cmp_ID { get; set; }
        public string Cmp_Name { get; set; }
        public string Cmp_ShortName { get; set; }
        public int? Cmp_Established { get; set; }
        public string Cmp_Address { get; set; }
        public string Cmp_City { get; set; }
        public string Cmp_State { get; set; }
        public string Cmp_Zip { get; set; }
        public int? Cmp_Country { get; set; }
        public string Cmp_Tel1 { get; set; }
        public string Cmp_Tel2 { get; set; }
        public string Cmp_Fax { get; set; }
        public string Cmp_Web { get; set; }
        public string Cmp_Email { get; set; }
        public string Cmp_EOBI { get; set; }
        public string Cmp_Contact { get; set; }
        public int? Cmp_MinAge { get; set; }
        public int? Cmp_MaxAge { get; set; }
        public string BanglaCName { get; set; }
        public int EmbroCompanyID { get; set; }

    }
}
