using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class SwatchSetup
    {
        public int ID { get; set; }
        public int BuyerID { get; set; }
        public string SwatchCode { get; set; }
        public string PicturePath { get; set; }
        public string SwatchName { get; set; }
    }
}
