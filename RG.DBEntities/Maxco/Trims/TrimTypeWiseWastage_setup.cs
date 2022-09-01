using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Trims
{
    public class TrimTypeWiseWastage_setup 
    {
        public int ID { get; set; }
        public int MrpitemCode { get; set; }
        public int TrimTypeID { get; set; }
        public int Wastage { get; set; }
    }
}
