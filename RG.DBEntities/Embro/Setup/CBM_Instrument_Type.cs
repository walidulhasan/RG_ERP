using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.Embro.Setup
{
    public class CBM_Instrument_Type
    {
        [Key]
        public decimal TypeID { get; set; }
        public string TypeName { get; set; }
    }
}
