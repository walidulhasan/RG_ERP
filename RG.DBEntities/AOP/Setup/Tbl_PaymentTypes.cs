using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.AOP.Setup
{
    public class Tbl_PaymentType
    {
        [Key]
        public int PaymentID { get; set; }
        public string PaymentType { get; set; }
        public bool IsActive { get; set; }
    }
}
