using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco
{
    public partial class Debug
    {
       [Key]
        public int Did { get; set; }
        public string Input { get; set; }
        public DateTime? Date { get; set; }
    }
}
