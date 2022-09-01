using AutoMapper;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.MT_MachineAndMaintenanceItemAssociations.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MachineAndMaintenanceItemAssociations.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MachineAndMaintenanceItemAssociations.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Setup;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.FiniteScheduler.Setup
{
    public class MT_MachineAndMaintenanceItemAssociationService : IMT_MachineAndMaintenanceItemAssociationService
    {
        private readonly IMT_MachineAndMaintenanceItemAssociationRepository mt_MachineAndMaintenanceItemAssociationRepository;
        private readonly IMapper mapper;

        public MT_MachineAndMaintenanceItemAssociationService(IMT_MachineAndMaintenanceItemAssociationRepository _mt_MachineAndMaintenanceItemAssociationRepository
            , IMapper _mapper)
        {
            mt_MachineAndMaintenanceItemAssociationRepository = _mt_MachineAndMaintenanceItemAssociationRepository;
            mapper = _mapper;
        }

        public async Task<List<MachineWiseMaintenanceItemDetailResponseModel>> GetMachineWiseMaintenanceItemDetailList(int machineID,int masterID, CancellationToken cancellationToken)
        {
            return await mt_MachineAndMaintenanceItemAssociationRepository.GetMachineWiseMaintenanceItemDetailList(machineID, masterID, cancellationToken);
        }

        public async Task<List<MachineWiseMaintenanceItemResponseModel>> GetMachineWiseMaintenanceItemList(int machineID, CancellationToken cancellationToken)
        {
            return await mt_MachineAndMaintenanceItemAssociationRepository.GetMachineWiseMaintenanceItemList(machineID, cancellationToken);
        }

        public async Task<RResult> RemoveMachineMaintainceAssociation(List<UpdateAssociationDTM> models)
        {
            return await mt_MachineAndMaintenanceItemAssociationRepository.RemoveMachineMaintainceAssociation(models);
        }

        public async Task<RResult> SaveMachineAndMaintenanceItemAssociation(List<AssociationDTM> models, bool saveChange)
        {
            var entities = mapper.Map<List<AssociationDTM>, List<MT_MachineAndMaintenanceItemAssociation>>(models);
            return await mt_MachineAndMaintenanceItemAssociationRepository.SaveMachineAndMaintenanceItemAssociation(entities, saveChange);
        }
    }
}
