using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Setup
{
    public class Pantone
    {
        public int ID { get; set; }
        public string PantoneNo { get; set; }
        public string PicturePath { get; set; }        
        public string Description { get; set; }
        public string Type { get; set; }
        public string HTMLcode { get; set; }
        public double? Price { get; set; }
        public bool? IsPriceInsert { get; set; }
        public string ColorItalCode { get; set; }
        public int? PalleteID { get; set; }
    }
}
