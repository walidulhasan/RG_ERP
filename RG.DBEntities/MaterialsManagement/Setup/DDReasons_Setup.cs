using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Setup
{
   
    public partial class DDReasons_Setup
    {
        public DDReasons_Setup()
        {
          //  DdblockedSupplier = new HashSet<DdblockedSupplier>();
        }

        public int ID { get; set; }
        public int ReasonTypeID{ get; set; }
        public string Reason { get; set; }

       // public virtual DdreasonTypeSetup ReasonType { get; set; }
       // public virtual ICollection<DdblockedSupplier> DdblockedSupplier { get; set; }
    }
}
