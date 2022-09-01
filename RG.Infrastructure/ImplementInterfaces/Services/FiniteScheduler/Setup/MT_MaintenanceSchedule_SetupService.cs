using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MaintenanceSchedule_Setups.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MaintenanceSchedule_Setups.Queries.DataResponseModel;
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
    public class MT_MaintenanceSchedule_SetupService: IMT_MaintenanceSchedule_SetupService
    {
        private readonly IMT_MaintenanceSchedule_SetupRepository _maintenanceSchedule_SetupRepository;
        private readonly IMapper _mapper;

        public MT_MaintenanceSchedule_SetupService(IMT_MaintenanceSchedule_SetupRepository maintenanceSchedule_SetupRepository,IMapper mapper)
        {
            _maintenanceSchedule_SetupRepository = maintenanceSchedule_SetupRepository;
            _mapper = mapper;
        }

        public async Task<List<SelectListItem>> DDLMachineWiseMaintenanceSchedule(int machineID, CancellationToken cancellationToken)
        {
            return await _maintenanceSchedule_SetupRepository.DDLMachineWiseMaintenanceSchedule(machineID, cancellationToken);
        }

        public async Task<List<MachineMaintenanceScheduleRM>> GetMachineMaintenanceSchedule(int machineID, CancellationToken cancellationToken)
        {
            return await _maintenanceSchedule_SetupRepository.GetMachineMaintenanceSchedule(machineID, cancellationToken);
        }

        public async Task<RResult> SaveSchedule(List<CreateMT_MaintenanceSchedule_SetupDTM> model, CancellationToken cancellationToken = default)
        {
            RResult oResult =new RResult();
            try
            {
                var dbModel = model.Select(s => new MT_MaintenanceSchedule_Setup()
                {
                    MachineID = s.MachineID,
                    ScheduleDate = s.ScheduleDate
                }).ToList();
                await _maintenanceSchedule_SetupRepository.InsertAsync(dbModel, true);
                oResult.result = 1;
                oResult.message = "Successfully Added Schedule";
            }catch(Exception e)
            {
                oResult.result = 0;
                oResult.message = "Validation error.";
            }
            return oResult; ;
        }

        public async Task<RResult<ValidateMachineScheduleRM>> ValidateMachineSchedule(string validateData, CancellationToken cancellationToken)
        {
            return await _maintenanceSchedule_SetupRepository.ValidateMachineSchedule(validateData,cancellationToken);
        }
    }
}
