using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.MT_MachineAndMaintenanceItemAssociations.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MachineAndMaintenanceItemAssociations.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MachineAndMaintenanceItemAssociations.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.FiniteScheduler.Setup
{
    public interface IMT_MachineAndMaintenanceItemAssociationService
    {
        Task<RResult> SaveMachineAndMaintenanceItemAssociation(List<AssociationDTM> models, bool saveChange);
        Task<List<MachineWiseMaintenanceItemResponseModel>> GetMachineWiseMaintenanceItemList(int machineID, CancellationToken cancellationToken);
        Task<List<MachineWiseMaintenanceItemDetailResponseModel>> GetMachineWiseMaintenanceItemDetailList(int machineID,int masterID, CancellationToken cancellationToken);
        Task<RResult> RemoveMachineMaintainceAssociation(List<UpdateAssociationDTM> models);
    }
}
