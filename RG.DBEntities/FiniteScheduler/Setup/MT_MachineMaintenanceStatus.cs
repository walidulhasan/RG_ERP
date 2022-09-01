using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public class MT_MachineMaintenanceStatus 
    {
        public int StatusID { get; set; }
        public string StatusName { get; set; }
        public string StatusDescription { get; set; }
        public bool IsActive { get; set; }
        public bool IsRemoved { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifedDate { get; set; }

    }
}
