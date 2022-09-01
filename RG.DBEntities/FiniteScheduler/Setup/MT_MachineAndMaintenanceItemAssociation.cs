using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public class MT_MachineAndMaintenanceItemAssociation: DefaultTableProperties
    {        
        public int AssociationID { get; set; }
        public int MachineID { get; set; }
        public int MaintenanceItemID { get; set; }
        public int? SerialNo { get; set; }
 

    }
}
