using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_Machine_Setups.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_Machine_Setups.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Setup;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using RG.Application.ViewModel.FiniteScheduler.Setup.MTMachineSetup;
using RG.DBEntities.FiniteScheduler.Setup;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.FiniteScheduler.Setup
{
    public class MT_Machine_SetupService : IMT_Machine_SetupService
    {
        private readonly IMT_Machine_SetupRepository mt_Machine_SetupRepository;
        private readonly IMapper mapper;

        public MT_Machine_SetupService(IMT_Machine_SetupRepository _mt_Machine_SetupRepository, IMapper _mapper)
        {
            mt_Machine_SetupRepository = _mt_Machine_SetupRepository;
            mapper = _mapper;
        }
        public async Task<List<SelectListItem>> DDLLocationWiseMachine(int locationID, CancellationToken cancellationToken)
        {
            return await mt_Machine_SetupRepository.DDLLocationWiseMachine(locationID, cancellationToken);
        }

        //public async Task<List<MT_Machine_SetupVM>> GetListOfMachine(int companyID, int locationID, int machineGroupID, CancellationToken cancellationToken)
        //{
        //    return await mt_Machine_SetupRepository.GetListOfMachine(companyID,locationID,machineGroupID,cancellationToken);
        //}
        public IQueryable<MachinesRM> GetListOfMachine(int companyID, int locationID, int machineGroupID)
        {
            return  mt_Machine_SetupRepository.GetListOfMachine(companyID, locationID, machineGroupID);
        }

        public async Task<RResult> RemoveMachine(int machineID, bool saveChange)
        {
            var entity = await mt_Machine_SetupRepository.GetByIdAsync(machineID);
            entity.IsRemoved = true;
            return await mt_Machine_SetupRepository.UpdateMachine(entity, saveChange);
        }

        public async Task<RResult> SaveMachine(MT_Machine_SetupDTM model, bool saveChange)

        {
            var rResult = await mt_Machine_SetupRepository.CheckDuplicateMachine(model.MachineName);
            if (!rResult.isDuplicate)
            {
                var dbModel = mapper.Map<MT_Machine_SetupDTM, MT_Machine_Setup>(model);
                return await mt_Machine_SetupRepository.SaveMachine(dbModel, saveChange);
            }
            else
            {
                rResult.result = 0;
                rResult.message = ReturnMessage.DuplicateMessage;
                return rResult;
            }

        }

        public async Task<RResult> UpdateMachine(MT_Machine_SetupDTM model, bool saveChange)
        {
            var rResult = await mt_Machine_SetupRepository.CheckDuplicateMachine(model.MachineName, model.MachineID);
            if (!rResult.isDuplicate)
            {
                var dbModel = await mt_Machine_SetupRepository.GetByIdAsync(model.MachineID);
                dbModel.MachineName = model.MachineName;
                dbModel.MachineCode = model.MachineCode;
                dbModel.MachineGroupID = model.MachineGroupID;
                dbModel.MinMaintainceDurationDays = model.MinMaintainceDurationDays;
                return await mt_Machine_SetupRepository.UpdateMachine(dbModel, saveChange);
            }
            else
            {
                rResult.result = 0;
                rResult.message = ReturnMessage.DuplicateMessage;
                return rResult;
            }
        }
    }
}
