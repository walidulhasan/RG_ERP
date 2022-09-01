using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.Maxco.Business
{
    public class KRS_Dyed_Colors
    {
      [Key]
        public int KRSDID { get; set; }
        public int KRSCID { get; set; }
        public int KRSID { get; set; }
        public string Percentage { get; set; }
        public string ColorName { get; set; }
    }
}
