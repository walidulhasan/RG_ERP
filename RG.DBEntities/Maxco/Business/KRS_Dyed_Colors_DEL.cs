using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class KRS_Dyed_Colors_DEL
    {
        public int KRSDID { get; set; }
        public int KRSCID { get; set; }
        public int KRSID { get; set; }
        public string Percentage { get; set; }
        public string ColorName { get; set; }
        public int? MainID { get; set; }
    }
}
