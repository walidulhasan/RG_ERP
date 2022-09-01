using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class IcLocalSalesGatePassMaster
    {
        [Key]
        public long GatePassId { get; set; }
        public long CustomerId { get; set; }
        public long DepartmentId { get; set; }
        public long IssuedBy { get; set; }
        public bool? IsSelfVehicle { get; set; }
    }
}
