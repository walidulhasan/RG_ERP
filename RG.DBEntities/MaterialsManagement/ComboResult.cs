using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class ComboResult
    {
        [Key]
        public long? CustomerId { get; set; }
        public string CustomerCode { get; set; }
        public long? ComboId { get; set; }
        public string ComboCode { get; set; }
        public long? ComboDetailId { get; set; }
        public string ComboDetailCode { get; set; }
        public long? CartonId { get; set; }
    }
}
