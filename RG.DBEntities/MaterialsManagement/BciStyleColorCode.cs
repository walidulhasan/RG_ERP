using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciStyleColorCode
    {
        [Key]
        public long StyleId { get; set; }
        public long ColorId { get; set; }
        public string ColorCode { get; set; }
        public byte Deleted { get; set; }
        public DateTime TransactionDate { get; set; }
        public int UserId { get; set; }
    }
}
