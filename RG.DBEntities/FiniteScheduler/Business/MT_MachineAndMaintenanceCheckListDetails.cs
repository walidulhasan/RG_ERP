using RG.DBEntities.FiniteScheduler.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public class MT_MachineAndMaintenanceCheckListDetails: DefaultTableProperties
    {
        public int ID { get; set; }
        [ForeignKey("MachineAndMaintenanceCheckListMaster")]
        public int MasterID { get; set; }
        public int AssociationID { get; set; }
        public bool? MechanicalChecked { get; set; }
        public string MechanicalComments { get; set; }
        public DateTime? MechanicalCommentsDate { get; set; }
        public bool? ElectricalChecked { get; set; }
        public string ElectricalComments { get; set; }
        public DateTime? ElectricalCommentsDate { get; set; }        
        public virtual MT_MachineAndMaintenanceCheckListMaster MachineAndMaintenanceCheckListMaster { get; set; }
    }
}
