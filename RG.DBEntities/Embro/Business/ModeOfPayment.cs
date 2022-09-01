using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Embro.Business
{
    public partial class ModeOfPayment
    {
        [Key]
        public int ModeID { get; set; }
        public string Description { get; set; }
        public int NoOfDays { get; set; }
    }
}
