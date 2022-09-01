using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.ApprovalNotifications.Queries.RequestResponseModel;
using RG.Application.Contracts.FiniteScheduler.Business.MT_MachineAndMaintenanceCheckListMasters.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Business.MT_MachineAndMaintenanceCheckListMasters.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Business;
using RG.DBEntities.FiniteScheduler.Business;
using RG.Infrastructure.Persistence.FiniteSchedulerDB;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.FiniteScheduler.Business
{
    public class MT_MachineAndMaintenanceCheckListMasterRepository : GenericRepository<MT_MachineAndMaintenanceCheckListMaster>, IMT_MachineAndMaintenanceCheckListMasterRepository
    {
        private FiniteSchedulerDBContext dbCon;

        private readonly ILogger<MT_MachineAndMaintenanceCheckListMasterRepository> _logger;
        private readonly IMapper mapper;

        public MT_MachineAndMaintenanceCheckListMasterRepository(FiniteSchedulerDBContext context
            , ILogger<MT_MachineAndMaintenanceCheckListMasterRepository> logger, IMapper _mapper)
            : base(context)
        {
            dbCon = context;
            _logger = logger;
            mapper = _mapper;
        }

        public async Task<RResult> MachineMaintenceCheckListSave(MT_MachineAndMaintenanceCheckListMaster entity, bool saveChanges = true)
        {
            RResult oResult = new RResult();
            try
            {
                //dbCon.MT_MachineAndMaintenanceCheckListMaster.Add(model);
                //var result = await dbCon.SaveChangesAsync();
                await InsertAsync(entity, saveChanges);
                oResult.result = 1;
                oResult.message = ReturnMessage.InsertMessage;
                oResult.statusCode = entity.ID;
            }
            catch (Exception e)
            {
                oResult.result = 0;
                oResult.message = "Problem occurred when save machine Maintence check list.";
                _logger.LogError(e.Message);
            }
            return oResult;
        }
        public async Task<List<MachineAndMaintenanceCheckRM>> GetMachineAndMaintenanceCheckList(int? machineID, DateTime dateFrom, DateTime dateTo, CancellationToken cancellationToken)
        {
            try
            {
                var query = from lo in dbCon.MT_Location_Setup
                                     join machine in dbCon.MT_Machine_Setup on lo.ID equals machine.LocationID
                                     join machineAndMantenance in dbCon.MT_MachineAndMaintenanceCheckListMaster on machine.MachineID equals machineAndMantenance.MachineID
                                     join ms in dbCon.MT_MaintenanceSchedule_Setup on machineAndMantenance.ScheduleID equals ms.ID
                                     join sts in dbCon.MT_MachineMaintenanceStatus on machineAndMantenance.StatusID equals sts.StatusID into tblStatus
                                     from status in tblStatus.DefaultIfEmpty()
                                     where machineAndMantenance.IsActive == true && machineAndMantenance.IsRemoved == false
                                     && (machineID == 0 || machineAndMantenance.MachineID == machineID)
                                     && (ms.CheckDate >= dateFrom && ms.CheckDate <= dateTo)

                                     select new MachineAndMaintenanceCheckRM()
                                     {
                                         ID = machineAndMantenance.ID,
                                         LocationName = lo.LocationName,
                                         MachineName = machine.MachineName,
                                         ScheduleDate = ms.ScheduleDate.ToString("dd-MMM-yyyy"),
                                         CheckedDate = ms.CheckDate.Value.ToString("dd-MMM-yyyy"),
                                         StatusName = status == null ? "" : status.StatusName,
                                         DayDifference = (int)(ms.ScheduleDate - ms.CheckDate.Value).TotalDays,

                                         ElectricalTaskCompletedBy = machineAndMantenance.ElectricalTaskCompletedBy ?? "",
                                         ElectricalTaskSupervisor = machineAndMantenance.ElectricalTaskSupervisor ?? "",

                                         MechanicalTaskCompletedBy = machineAndMantenance.MechanicalTaskCompletedBy ?? "",
                                         MechanicalTaskSupervisor = machineAndMantenance.MechanicalTaskSupervisor ?? "",

                                         FirstAuthorityComments = machineAndMantenance.FirstAuthorityComments ?? "N/A",
                                         LastAuthorityComments = machineAndMantenance.LastAuthorityComments ?? "N/A"
                                     };
               //var queryString = query.ToQueryString();
               var rtnList =await query.ToListAsync(cancellationToken);
                return rtnList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public async Task<MachineAndMaintenanceCheckMasterRM> GetMachineAndMaintenanceCheckListMasterData(int Id, CancellationToken cancellationToken)
        {
            var data = await (from cm in dbCon.MT_MachineAndMaintenanceCheckListMaster
                              join mms in dbCon.MT_MaintenanceSchedule_Setup on cm.ScheduleID equals mms.ID
                              join ms in dbCon.MT_Machine_Setup on cm.MachineID equals ms.MachineID
                              join l in dbCon.MT_Location_Setup on ms.LocationID equals l.ID
                              where cm.ID == Id
                              select new MachineAndMaintenanceCheckMasterRM
                              {
                                  MasterID = cm.ID,
                                  CompanyID = l.CompanyID,
                                  LocationID = ms.LocationID,
                                  MachineID = cm.MachineID,
                                  CheckDate = mms.CheckDate,
                                  ScheduleDate = mms.ScheduleDate,
                                  MechanicalTaskTeamMember = cm.MechanicalTaskCompletedBy,
                                  MechanicalSupervisor = cm.MechanicalTaskSupervisor,
                                  MechanicalWorkerComments = cm.MechanicalWorkerComments,
                                  ElectricalTaskTeamMember = cm.ElectricalTaskCompletedBy,
                                  ElectricalSupervisor = cm.ElectricalTaskSupervisor,
                                  ElectricalWorkerComments = cm.ElectricalWorkerComments

                              }).FirstOrDefaultAsync(cancellationToken);
            return data;
        }

        /* public async Task<RResult> MachineMaintenceCheckListMasterUpdate(MT_MachineAndMaintenanceCheckListMasterEditViewModel model)
         {
             var rResult = new RResult();
             var dbObj = await dbCon.MT_MachineAndMaintenanceCheckListMaster.FindAsync(model.ID);
             if (dbObj.StatusID == null)
             {
                 dbObj.ElectricalTaskCompletedBy = model.ElectricalTaskCompletedBy;
                 dbObj.ElectricalTaskSupervisor = model.ElectricalTaskSupervisor;
                 dbObj.MechanicalTaskCompletedBy = model.MechanicalTaskCompletedBy;
                 dbObj.MechanicalTaskSupervisor = model.MechanicalTaskSupervisor;
                 dbObj.LastModifedDate = DateTime.Now;
                 dbObj.LastModifiedBy = model.LastModifiedBy;
                 var listOfDetails = new List<MT_MachineAndMaintenanceCheckListDetails>();
                 foreach (var item in model.MachineAndMaintenanceCheckListDetails)
                 {
                     var dbDetails = await dbCon.MT_MachineAndMaintenanceCheckListDetails.FindAsync(item.ID);
                     dbDetails.MechanicalComments = item.MechanicalComments;
                     dbDetails.ElectricalComments = item.ElectricalComments;
                     dbDetails.LastModifedDate = DateTime.Now;
                     dbDetails.LastModifiedBy = model.LastModifiedBy;
                     listOfDetails.Add(dbDetails);
                 }
                 dbObj.MachineAndMaintenanceCheckListDetails = listOfDetails;
                 await dbCon.SaveChangesAsync();
                 rResult.result = 1;
                 rResult.message = ReturnMessage.UpdateMessage;
             }
             else
             {
                 rResult.message = "Checking Item Processing its will not be Updated";
             }

             return rResult;
         }
        */
        public async Task<List<MonthlyMachineMaintainceRM>> GetMonthlyMachineMaintainceReport(int locationID, int month, int year, CancellationToken cancellationToken = default)
        {

            var cheekListStatus = new List<MonthlyMachineMaintainceRM>();
            try
            {
                await dbCon.LoadStoredProc("rpt.MT_MachineMaintaincePreventativeCheckListStatus")
                .WithSqlParam("LocationID", locationID)
                .WithSqlParam("Month", month)
                .WithSqlParam("Year", year)
                .ExecuteStoredProcAsync((handler) =>
                {
                    cheekListStatus = handler.ReadToList<MonthlyMachineMaintainceRM>() as List<MonthlyMachineMaintainceRM>;
                });

                cheekListStatus.ForEach(s =>
                {
                    if (s.ScheduleDate != null && s.CheckedDate != null)
                    {

                        s.ScheduleDayDifference = (s.ScheduleDate.Value.Day - s.CheckedDate.Value.Day).ToString();
                    }
                    else
                    {
                        s.ScheduleDayDifference = null;
                    }
                    if (s.NextCheckDate != null)
                    {
                        s.NextDayDifference = (s.NextCheckDate.Value.Day - DateTime.Now.Day).ToString();
                    }
                    else
                    {
                        s.NextDayDifference = null;
                    }


                });



            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return cheekListStatus;
        }

        public async Task<MT_MachineAndMaintenanceCheckListMaster> GetMachineAndMaintenanceCheckListMasterDataByCheckDate(int machineID, DateTime checkDate)
        {
            var rtnObjQuery = from mm in dbCon.MT_MachineAndMaintenanceCheckListMaster
                         join ms in dbCon.MT_MaintenanceSchedule_Setup on  mm.MachineID  equals  ms.MachineID
                         where mm.IsActive == true && mm.IsRemoved == false && ms.IsActive == true && ms.IsRemoved == false && ms.CheckDate==checkDate
                         && ms.MachineID == machineID && (ms.CheckedStatus ==null ||ms.CheckedStatus==0)
                         select new MT_MachineAndMaintenanceCheckListMaster()
                         {
                             ID = mm.ID,
                             ScheduleID = ms.ID,
                             MachineID = mm.MachineID,
                             StatusID = mm.StatusID,
                             StatusDate = mm.StatusDate,
                             ElectricalTaskCompletedBy = mm.ElectricalTaskCompletedBy,
                             ElectricalTaskSupervisor = mm.ElectricalTaskSupervisor,
                             MechanicalTaskCompletedBy = mm.MechanicalTaskCompletedBy,
                             MechanicalTaskSupervisor = mm.MechanicalTaskSupervisor

                         };
            var qry = rtnObjQuery.ToQueryString();
            var rtnObj = await rtnObjQuery.FirstOrDefaultAsync();

            return rtnObj;
        }

        public async Task<RResult> MachineMaintenceCheckListUpdate(CheckListMasterDTM model, bool saveChanges = true)
        {
            var rResult = new RResult();
            try
            {

                var entity = await dbCon.MT_MachineAndMaintenanceCheckListMaster
                    .Include(x => x.MachineAndMaintenanceCheckListDetails.Where(y => y.IsActive == true && y.IsRemoved == false))
                    .Where(x => x.ID == model.MasterID && x.IsActive == true && x.IsRemoved == false).FirstAsync();

                entity.MechanicalTaskCompletedBy = model.MechanicalTaskCompletedBy;
                entity.MechanicalTaskSupervisor = model.MechanicalTaskSupervisor;
                entity.MechanicalWorkerComments = model.MechanicalWorkerComments;

                entity.ElectricalTaskCompletedBy = model.ElectricalTaskCompletedBy;
                entity.ElectricalTaskSupervisor = model.ElectricalTaskSupervisor;
                entity.ElectricalWorkerComments = model.ElectricalWorkerComments;

                // Delete children
                foreach (var detail in entity.MachineAndMaintenanceCheckListDetails)
                {
                    if (!model.MachineAndMaintenanceCheckListDetails.Any(c => c.DetailID == detail.ID))
                    {
                        detail.IsRemoved = true;
                        dbCon.Update(detail);
                    }
                }

                //Update and Insert children
                foreach (var detail in model.MachineAndMaintenanceCheckListDetails)
                {
                    var existingChild = entity.MachineAndMaintenanceCheckListDetails
                        .Where(c => c.ID == detail.DetailID).FirstOrDefault();
                    // Update child
                    if (existingChild != null)
                    {
                        existingChild.MechanicalChecked = detail.MechanicalChecked;
                        existingChild.MechanicalComments = detail.MechanicalComments;
                        existingChild.MechanicalCommentsDate = DateTime.Now;

                        existingChild.ElectricalChecked = detail.ElectricalChecked;
                        existingChild.ElectricalComments = detail.ElectricalComments;
                        existingChild.ElectricalCommentsDate = DateTime.Now;
                        dbCon.Update(existingChild);
                    }
                    else
                    {
                        var newChild = mapper.Map<CheckListDetailsDTM, MT_MachineAndMaintenanceCheckListDetails>(detail);
                        newChild.MasterID = model.MasterID;
                        dbCon.Add(newChild);
                    }
                }
                if (saveChanges)
                    await dbCon.SaveChangesAsync();
                rResult.result = 1;
                rResult.message = ReturnMessage.InsertMessage;
                return rResult;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public async Task<List<MachineMaintainceItemDetailRM>> GetMachineMaintainceItemDetailInfo(int month, int year, int locationID, int machineID, CancellationToken cancellationToken)
        {
            List<MachineMaintainceItemDetailRM> notifications = new();
            try
            {
                await dbCon.LoadStoredProc("rpt.USP_GetMachineMaintainceItemReport")
                    .WithSqlParam("MonthID", month)
                    .WithSqlParam("YearID", year)
                    .WithSqlParam("LocationID", locationID)
                    .WithSqlParam("MachineID", machineID)
                    .ExecuteStoredProcAsync((handler) =>
                    {
                        notifications = handler.ReadToList<MachineMaintainceItemDetailRM>() as List<MachineMaintainceItemDetailRM>;
                    });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return notifications;
        }

        public async Task<RResult> UpdateMT_MachineAndMaintenanceCheckListMaster(MT_MachineAndMaintenanceCheckListMaster entity)
        {
            RResult rResult = new RResult();
            dbCon.MT_MachineAndMaintenanceCheckListMaster.Update(entity);
            await dbCon.SaveChangesAsync();
            rResult.result = 1;
            rResult.message = ReturnMessage.UpdateMessage;
            return rResult;

        }
        public async Task<List<MachineMaintenanceNotificationRM>> GetMachineMaintenanceCheckListByNotification(List<MachineMaintenanceNotificationRM> notifications, CancellationToken cancellationToken)
        {
            var _data = await (from lm in dbCon.MT_MachineAndMaintenanceCheckListMaster
                              //join n in notifications on lm.ID equals n.ApplicationID
                              join ms in dbCon.MT_MaintenanceSchedule_Setup on lm.ScheduleID equals ms.ID
                              join m in dbCon.MT_Machine_Setup on lm.MachineID equals m.MachineID
                              where (notifications.Select(b=>b.ApplicationID).ToList().Contains(lm.ID))
                              select new MachineMaintenanceNotificationRM()
                              {
                                  ApplicationID =lm.ID,
                                  MaintenanceCheckMasterID = lm.ID,
                                  MachineName = m.MachineName,
                                  CheckedDate = ms.CheckDate == null ? "" : ms.CheckDate.Value.ToString("dd-MMM-yyyy"),
                                  ScheduleDate = ms.ScheduleDate.ToString("dd-MMM-yyyy"),
                                  ElectricalTaskCompletedBy = lm.ElectricalTaskCompletedBy,
                                  ElectricalTaskSupervisor = lm.ElectricalTaskSupervisor,
                                  MechanicalTaskCompletedBy = lm.MechanicalTaskCompletedBy,
                                  MechanicalTaskSupervisor = lm.MechanicalTaskSupervisor,
                                  FirstAuthorityCommentsDate = $"{lm.FirstAuthorityComments} - {(lm.FirstAuthorityCommentsDate != null ? lm.FirstAuthorityCommentsDate.Value.ToString("dd-MMM-yyyy") : "")}",
                                  LastAuthorityCommentsDate = $"{lm.LastAuthorityComments} - {(lm.LastAuthorityCommentsDate != null ? lm.LastAuthorityCommentsDate.Value.ToString("dd-MMM-yyyy") : "")}",
                              }).ToListAsync(cancellationToken);

            var data = from main in _data
                       join not in notifications on main.ApplicationID equals not.ApplicationID
                       select new MachineMaintenanceNotificationRM()
                       {
                           ApplicationID = main.ApplicationID,
                           NotificationID = not.NotificationID,
                           MaintenanceCheckMasterID = main.ApplicationID,
                           MachineName = main.MachineName,
                           CheckedDate = main.CheckedDate,
                           ScheduleDate = main.ScheduleDate,
                           ElectricalTaskCompletedBy = main.ElectricalTaskCompletedBy,
                           ElectricalTaskSupervisor = main.ElectricalTaskSupervisor,
                           MechanicalTaskCompletedBy = main.MechanicalTaskCompletedBy,
                           MechanicalTaskSupervisor = main.MechanicalTaskSupervisor,
                           FirstAuthorityCommentsDate = main.FirstAuthorityCommentsDate,
                           LastAuthorityCommentsDate = main.LastAuthorityCommentsDate
                       };

            return data.ToList();

        }
        public async Task<List<MachineMaintenanceNotificationDetailRM>> GetMachineAndMaintenanceCheckListDetail(int masterID, CancellationToken cancellationToken)
        {
            var data = await (from m in dbCon.MT_MachineAndMaintenanceCheckListMaster
                              join d in dbCon.MT_MachineAndMaintenanceCheckListDetails on m.ID equals d.MasterID
                              join a in dbCon.MT_MachineAndMaintenanceItemAssociation on d.AssociationID equals a.AssociationID
                              join i in dbCon.MT_MaintenanceItem_Setup on a.MaintenanceItemID equals i.ID
                              where m.ID == masterID && d.IsActive == true && d.IsRemoved == false
                              select new MachineMaintenanceNotificationDetailRM
                              {
                                  ItemName = i.ItemName,
                                  ElectricalComments = $"{d.ElectricalComments} - {(d.ElectricalCommentsDate != null ? d.ElectricalCommentsDate.Value.ToString("dd-MMM-yyyy") : "")}",
                                  MechanicalComments = $"{d.MechanicalComments} - {(d.MechanicalCommentsDate != null ? d.MechanicalCommentsDate.Value.ToString("dd-MMM-yyyy") : "")}",
                                  SerialNo = a.SerialNo.Value,
                                  ElectricalWorkerComments=m.ElectricalWorkerComments,
                                  MechanicalWorkerComments=m.MechanicalWorkerComments
                              }).OrderBy(x => x.SerialNo).ToListAsync(cancellationToken);
            return data;
        }

        public async Task GenerateMonthlyMaintenanceSchedule()
        {
            try
            {
                   await dbCon.LoadStoredProc("ajt.GenerateMT_MaintenanceSchedule")
                       .ExecuteStoredNonQueryAsync();
                _logger.LogInformation($"MT_MachineAndMaintenanceCheckListMasterRepository function GenerateMonthlyMaintenanceSchedule :Schedule Generate at {DateTime.Now}");
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"MT_MachineAndMaintenanceCheckListMasterRepository function GenerateMonthlyMaintenanceSchedule: problem occured :{e.Message}");
            }

           
        }
    }
}
