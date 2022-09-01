using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class Cartage_Setup
    {
        [Key]
        public int CartageID { get; set; }
        public string CartageDesc { get; set; }
    }
}
