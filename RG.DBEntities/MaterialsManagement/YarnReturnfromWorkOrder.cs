using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnReturnfromWorkOrder
    {
        [Key]
        public long RwoId { get; set; }
        public long WorkOrderId { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal ReturnedYarn { get; set; }

        public virtual YarnWorkOrderMaster WorkOrder { get; set; }
    }
}
