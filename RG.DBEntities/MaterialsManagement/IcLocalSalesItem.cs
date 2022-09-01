using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class IcLocalSalesItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public long AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
    }
}
