using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.MT_MachineAndMaintenanceItemAssociations.Commands.DataTransferModel
{
    public class UpdateAssociationDTM
    {
        public int MachineID { get; set; }
        public int AssociationID { get; set; }
    }
}
