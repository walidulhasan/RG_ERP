using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.AlgoHR.Setup
{
    public class Tbl_Country
    {
        [Key]
        public string Country_CID { get; set; }
        public string Country_CName { get; set; }
    }
}
