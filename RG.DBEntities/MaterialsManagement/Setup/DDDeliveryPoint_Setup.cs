using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Setup
{
    public partial class DDDeliveryPoint_Setup
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int? DomainID { get; set; }
    }
}
