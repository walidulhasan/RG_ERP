using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MaintenanceSchedule_Setups.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MaintenanceSchedule_Setups.Queries.DataResponseModel;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Setup;
using RG.DBEntities.FiniteScheduler.Setup;
using RG.Infrastructure.Persistence.FiniteSchedulerDB;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.FiniteScheduler.Setup
{
   public class MT_MaintenanceSchedule_SetupRepository : GenericRepository<MT_MaintenanceSchedule_Setup>,IMT_MaintenanceSchedule_SetupRepository
    {
        private readonly FiniteSchedulerDBContext _dbCon;

        public MT_MaintenanceSchedule_SetupRepository(FiniteSchedulerDBContext finiteSchedulerDbContext):base(finiteSchedulerDbContext)
        {
            _dbCon = finiteSchedulerDbContext;

        }
        public async Task<List<SelectListItem>> DDLMachineWiseMaintenanceSchedule(int machineID, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _dbCon.MT_MaintenanceSchedule_Setup
                .Where(x => x.MachineID == machineID && x.CheckedStatus == null)
                .OrderBy(y=>y.ScheduleDate)
                .Select(r => new SelectListItem
                {
                    Text = r.ScheduleDate.ToString("dd-MMM-yyyy"),
                    Value = r.ID.ToString(),

                }).ToListAsync();
                return data;
            }
            catch (Exception e)
            {
                throw;
            }            
        }

        public async Task<List<MachineMaintenanceScheduleRM>> GetMachineMaintenanceSchedule(int machineID, CancellationToken cancellationToken)
        {
            List<MachineMaintenanceScheduleRM> schedule = new();
            try
            {
                await _dbCon.LoadStoredProc("rpt.usp_MachineMaintenanceSchedule")
                    .WithSqlParam("MachineID", machineID)                    
                    .ExecuteStoredProcAsync((handler) =>
                    {
                        schedule = handler.ReadToList<MachineMaintenanceScheduleRM>() as List<MachineMaintenanceScheduleRM>;
                    });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return schedule;
        }

        public Task<RResult> SaveSchedule(CreateMT_MaintenanceSchedule_SetupDTM model)
        {
            throw new NotImplementedException();
        }

        public async Task<RResult> UpdateMaintenanceSchedule(MT_MaintenanceSchedule_Setup entity, bool saveChange = true)
        {
            RResult rResult = new();
            _dbCon.MT_MaintenanceSchedule_Setup.Update(entity);
            if(saveChange)
            await _dbCon.SaveChangesAsync();
            rResult.result = 1;
            rResult.message = ReturnMessage.UpdateMessage;
            return rResult;
        }

        public async Task<RResult<ValidateMachineScheduleRM>> ValidateMachineSchedule(string validateData, CancellationToken cancellationToken)
        {
            RResult<ValidateMachineScheduleRM> rData = new RResult<ValidateMachineScheduleRM>();
            try
            {
                rData.result = 1;
                await _dbCon.LoadStoredProc("ajt.usp_ValidationMachineSchedeDate")
                    .WithSqlParam("ScheduleData",validateData)
                  .ExecuteStoredProcAsync((handler) =>
                  {
                      rData.dataList = handler.ReadToList<ValidateMachineScheduleRM>() as List<ValidateMachineScheduleRM>;
                  });
            }catch(Exception e)
            {
                throw new Exception("Data problem");
            }
            return rData;
        }
    }
}
