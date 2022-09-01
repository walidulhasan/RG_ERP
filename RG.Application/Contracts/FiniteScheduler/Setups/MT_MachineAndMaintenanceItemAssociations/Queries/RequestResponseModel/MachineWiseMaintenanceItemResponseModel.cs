using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.MT_MachineAndMaintenanceItemAssociations.Queries.RequestResponseModel
{
    public class MachineWiseMaintenanceItemResponseModel
    {

        public int AssociationID { get; set; }
        public int MachineID { get; set; }
        public int MaintenanceItemID { get; set; }
        public string ItemName { get; set; }
    }
}
