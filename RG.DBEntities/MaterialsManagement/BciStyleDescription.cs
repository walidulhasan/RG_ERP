using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciStyleDescription
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long StyleId { get; set; }
        public string Description { get; set; }
        public int Deleted { get; set; }
    }
}
