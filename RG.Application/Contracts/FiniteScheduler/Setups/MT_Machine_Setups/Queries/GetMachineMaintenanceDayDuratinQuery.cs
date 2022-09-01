using MediatR;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_Machine_Setups.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.MT_Machine_Setups.Queries
{
   public class GetMachineMaintenanceDayDuratinQuery:IRequest<MachineMaintenanceDayDurationRM>
    {
        //public List<CreateMT_MaintenanceSchedule_SetupDTM> Model { get;set; }
    }
}
