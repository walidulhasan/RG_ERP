using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class ComboCustomer
    {
        [Key]
        public long CustomerId { get; set; }
        public string CustomerCode { get; set; }
    }
}
