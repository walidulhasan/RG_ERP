using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Setup
{
    public class Yarn_DaysOfPayment_Setup
    {
        [Key]
        public int DaysId { get; set; }
        public string DaysDesc { get; set; }
    }
}
