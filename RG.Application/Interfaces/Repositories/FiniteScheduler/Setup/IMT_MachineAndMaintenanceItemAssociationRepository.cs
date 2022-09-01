using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MachineAndMaintenanceItemAssociations.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MachineAndMaintenanceItemAssociations.Queries.RequestResponseModel;
using RG.DBEntities.FiniteScheduler.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.FiniteScheduler.Setup
{
    public interface IMT_MachineAndMaintenanceItemAssociationRepository : IGenericRepository<MT_MachineAndMaintenanceItemAssociation>
    {
        Task<RResult> SaveMachineAndMaintenanceItemAssociation(List<MT_MachineAndMaintenanceItemAssociation> entities, bool saveChange);
        Task<List<MachineWiseMaintenanceItemResponseModel>> GetMachineWiseMaintenanceItemList(int machineID, CancellationToken cancellationToken);
        Task<List<MachineWiseMaintenanceItemDetailResponseModel>> GetMachineWiseMaintenanceItemDetailList(int machineID, int masterID, CancellationToken cancellationToken);
        Task<RResult> RemoveMachineMaintainceAssociation(List<UpdateAssociationDTM> models);
    }
}
