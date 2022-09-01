using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Business.ApprovalNotifications.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Business;
using RG.DBEntities.FiniteScheduler.Business;
using RG.Infrastructure.Persistence.FiniteSchedulerDB;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using RG.Application.Common.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.FiniteScheduler.Business
{
    public class ApprovalNotificationRepository : GenericRepository<ApprovalNotification>, IApprovalNotificationRepository
    {
        private FiniteSchedulerDBContext dbCon;
        public ApprovalNotificationRepository(FiniteSchedulerDBContext context)
            : base(context)
        {
            dbCon = context;

        }
        public async Task<RResult> UpdateNotification(ApprovalNotification entity)
        {
            RResult rResult = new();
            dbCon.ApprovalNotification.Update(entity);
            await dbCon.SaveChangesAsync();
            rResult.result = 1;
            rResult.message = ReturnMessage.UpdateMessage;
            return rResult;
        }
        public async Task<List<MachineMaintenanceNotificationDetailRM>> GetMachineAndMaintenanceCheckListDetail(int masterID, CancellationToken cancellationToken)
        {
            var data = await (from d in dbCon.MT_MachineAndMaintenanceCheckListDetails
                              join a in dbCon.MT_MachineAndMaintenanceItemAssociation on d.AssociationID equals a.AssociationID
                              join i in dbCon.MT_MaintenanceItem_Setup on a.MaintenanceItemID equals i.ID
                              where d.MasterID == masterID && d.IsActive == true && d.IsRemoved == false
                              select new MachineMaintenanceNotificationDetailRM
                              {
                                  ItemName = i.ItemName,
                                  ElectricalComments = $"{d.ElectricalComments} - {(d.ElectricalCommentsDate != null ? d.ElectricalCommentsDate.Value.ToString("dd-MMM-yyyy") : "")}",
                                  MechanicalComments = $"{d.MechanicalComments} - {(d.MechanicalCommentsDate != null ? d.MechanicalCommentsDate.Value.ToString("dd-MMM-yyyy") : "")}",
                                  SerialNo = a.SerialNo.Value
                              }).OrderBy(x => x.SerialNo).ToListAsync(cancellationToken);
            return data;
        }
        public async Task<List<MachineMaintenanceNotificationRM>> GetMachineMaintenanceNotification(int designationID, int employeeID, CancellationToken cancellationToken)
        {
            var data = await (from an in dbCon.ApprovalNotification
                              join ad in dbCon.ApprovalConfigDetail on an.ApprovalDetailID equals ad.ConfigDetailID
                              join lm in dbCon.MT_MachineAndMaintenanceCheckListMaster on an.ApplicationID equals lm.ID
                              join ms in dbCon.MT_MaintenanceSchedule_Setup on lm.ScheduleID equals ms.ID
                              join m in dbCon.MT_Machine_Setup on lm.MachineID equals m.MachineID
                              where an.ModuleName == ApprovalModules.MachineMaintenance && an.IsChecked == false
                              && (designationID == 0 || designationID == ad.ApproverJobTitleID) && (employeeID == 0 || employeeID == ad.ApproverEmployeeID)
                              select new MachineMaintenanceNotificationRM()
                              {
                                  NotificationID = an.NotificationID,
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
            return data;

        }
        public async Task<RResult> SaveApprovalNotification(ApprovalNotification entity)
        {
            var rResult = new RResult();
            try
            {
                await dbCon.ApprovalNotification.AddAsync(entity);
                await dbCon.SaveChangesAsync();
                rResult.result = 1;
                rResult.message = ReturnMessage.InsertMessage;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return rResult;
        }
        public async Task<List<NotificationRM>> GetAllNotifications()
        {
            List<NotificationRM> notifications = new();
            try
            {
                await dbCon.LoadStoredProc("ajt.GetCurrentNotificationCount")
                                  .ExecuteStoredProcAsync((handler) =>
                                  {
                                      notifications = handler.ReadToList<NotificationRM>() as List<NotificationRM>;
                                  });

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return notifications;
        }

        public async Task<List<ApprovalNotification>> GetLeaveApplicationNotification(int approverEmployeeID, CancellationToken cancellationToken)
        {
            var data = await(from an in dbCon.ApprovalNotification
                            join acd in dbCon.ApprovalConfigDetail on an.ApprovalDetailID equals acd.ConfigDetailID 
                             where an.ModuleName == ApprovalModules.LeaveApplication && an.IsChecked == false
                       && acd.ApproverEmployeeID == approverEmployeeID && an.IsActive == true && an.IsRemoved == false
                       select new ApprovalNotification { 
                       NotificationID=an.NotificationID,
                       ModuleName=an.ModuleName,
                       ApprovalMasterID=an.ApprovalMasterID,
                       ApprovalDetailID=an.ApprovalDetailID,
                       ApproverEmployeeID=an.ApproverEmployeeID,
                       ApplicationID=an.ApplicationID,
                       IsChecked=an.IsChecked,
                       Remarks=an.Remarks,
                       CheckedStatus=an.CheckedStatus,
                       CheckedDate=an.CheckedDate
                       }).ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<LeaveApplicationsApprovalPendingLevelRM>> GetLeaveApplicationsApprovalPendingLevel(CancellationToken cancellationToken)
        {
            var data = await (from n in dbCon.ApprovalNotification
                              join cd in dbCon.ApprovalConfigDetail on n.ApprovalDetailID equals cd.ConfigDetailID                              
                              where n.ModuleName == ApprovalModules.LeaveApplication && n.IsActive == true && n.IsRemoved == false && n.IsChecked == false
                              select new LeaveApplicationsApprovalPendingLevelRM
                              {
                                  NotificationID = n.NotificationID,
                                  ApplicationID = n.ApplicationID.Value,
                                  ApprovalMasterID = n.ApprovalMasterID,
                                  ApprovalDetailID = n.ApprovalDetailID,
                                  ApproverEmployeeID = cd.ApproverEmployeeID.Value
                              }).ToListAsync(cancellationToken);
            return data;
        }
    }
}
