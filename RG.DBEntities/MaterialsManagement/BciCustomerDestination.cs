using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciCustomerDestination
    {
        [Key]
        public int CustomerId { get; set; }
        public int DestinationId { get; set; }
        public byte Deleted { get; set; }
    }
}
