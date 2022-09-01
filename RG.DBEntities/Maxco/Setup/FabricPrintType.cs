using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Setup
{
    public class FabricPrintType
    {
        public int ID { get; set; }
        public string PrintType { get; set; }
        public bool IsActive { get; set; }
        public bool IsRemoved { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
