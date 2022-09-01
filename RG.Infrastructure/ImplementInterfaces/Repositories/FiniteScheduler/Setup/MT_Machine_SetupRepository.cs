using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_Machine_Setups.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Setup;
using RG.Application.ViewModel.FiniteScheduler.Setup.MTMachineSetup;
using RG.DBEntities.FiniteScheduler.Setup;
using RG.Infrastructure.Persistence.FiniteSchedulerDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.FiniteScheduler.Setup
{
    public class MT_Machine_SetupRepository : GenericRepository<MT_Machine_Setup>, IMT_Machine_SetupRepository
    {
        private FiniteSchedulerDBContext dbCon;
        public MT_Machine_SetupRepository(FiniteSchedulerDBContext context)
            : base(context)
        {
            dbCon = context;
        }
        public async Task<List<SelectListItem>> DDLLocationWiseMachine(int locationID, CancellationToken cancellationToken)
        {
            var data = await dbCon.MT_Machine_Setup.Where(b => b.LocationID == locationID)
               .Select(X => new SelectListItem()
               {
                   Text = X.MachineName,
                   Value = X.MachineID.ToString()
               }).ToListAsync(cancellationToken);
            return data;
        }

        public async Task<RResult> UpdateMachineNextPreventativeDate(int machineID, DateTime currentCheckDate, DateTime nextPreventativeDate, bool saveChange)
        {
            RResult rResult = new();
            var machineInfo = await dbCon.MT_Machine_Setup.Where(b => b.IsRemoved == false && b.IsActive == true && b.MachineID == machineID).FirstOrDefaultAsync();
            if (machineInfo != null)
            {
                machineInfo.NextCheckDate = nextPreventativeDate;
                machineInfo.CheckedDate = currentCheckDate;
            }
            if (saveChange == true)
            {
                await UpdateAsync(machineInfo, saveChange);
            }
            rResult.result = 1;
            rResult.message = ReturnMessage.UpdateMessage;
            return rResult;
        }

        public async Task<RResult> SaveMachine(MT_Machine_Setup model, bool saveChange)
        {

            var rResult = new RResult();

            try
            {
                await InsertAsync(model, saveChange);
                rResult.result = 1;
                rResult.message = ReturnMessage.InsertMessage;
            }
            catch (Exception e)
            {

                throw new(e.Message);
            }

            return rResult;
        }

        public async Task<RResult> UpdateMachine(MT_Machine_Setup model, bool saveChange)
        {
            var rResult = new RResult();
            try
            {
                await UpdateAsync(model, saveChange);
                rResult.result = 1;
                rResult.message = ReturnMessage.UpdateMessage;
            }
            catch (Exception e)
            {
                throw new(e.Message);
            }
            return rResult;
        }

        public IQueryable<MachinesRM> GetListOfMachine( int companyID, int locationID, int machineGroupID)
        {
            var rtnList = from lo in dbCon.MT_Location_Setup
                          join ma in dbCon.MT_Machine_Setup on lo.ID equals ma.LocationID
                          join mg in dbCon.MT_MachineGroup on ma.MachineGroupID equals mg.ID
                          where ma.IsActive == true && ma.IsRemoved == false && (companyID == 0 || lo.CompanyID == companyID) && (locationID == 0 || lo.ID == locationID) && (machineGroupID == 0 || mg.ID == machineGroupID)
                          select new MachinesRM()
                          {
                              CompanyID = lo.CompanyID,
                              MachineID = ma.MachineID,
                              MachineCode = ma.MachineCode,
                              MachineName = ma.MachineName,
                              MachineGroupID = mg.ID,
                              MachineGroup = mg.MachineGroup,
                              LocationID = ma.LocationID,
                              LocationName = lo.LocationName,
                              MinMaintainceDurationDays = ma.MinMaintainceDurationDays
                          };

            return rtnList;
        }

        public async Task<RResult> CheckDuplicateMachine(string machineName,int machineID)
        {
            var rResult = new RResult();
            var data = await dbCon.MT_Machine_Setup.Where(x => x.IsActive == true && x.IsRemoved == false && x.MachineName == machineName && x.MachineID!=machineID).FirstOrDefaultAsync();
            if (data == null)
                rResult.isDuplicate = false;
            else
                rResult.isDuplicate = true;
            return rResult;
        }
    }
}
