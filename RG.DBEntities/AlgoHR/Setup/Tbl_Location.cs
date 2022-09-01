using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.AlgoHR.Setup
{
    public class Tbl_Location
    {
        public int Location_Id { get; set; }
        public string Location_Cd { get; set; }
        public string Location_Name { get; set; }
        public int? Location_Company { get; set; }
        public DateTime? Location_Created { get; set; }

    }
}
