using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class Debug
    {
        [Key]
        public int Did { get; set; }
        public string Xml { get; set; }
        public DateTime? Date { get; set; }
        public string Sp { get; set; }
    }
}
