using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class IcDepartment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
    }
}
