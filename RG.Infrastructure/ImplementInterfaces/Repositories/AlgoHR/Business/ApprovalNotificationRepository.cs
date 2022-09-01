using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Models;
using RG.Application.Common.Utilities;
using RG.Application.Contracts.AlgoHR.Business.ApprovalNotifications.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.DBEntities.AlgoHR.Business;
using RG.DBEntities.AlgoHR.DBViews;
using RG.Infrastructure.Persistence.AlgoHRDB;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Business
{
    public class ApprovalNotificationRepository : GenericRepository<ApprovalNotification>, IApprovalNotificationRepository
    {
        private AlgoHRDBContext dbCon;
        public ApprovalNotificationRepository(AlgoHRDBContext context)
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

        public async Task<List<MachineMaintenanceNotificationRM>> GetMachineMaintenanceNotification(int designationID, int employeeID, CancellationToken cancellationToken)
        {
            var data = await (from an in dbCon.ApprovalNotification
                              join ad in dbCon.ApprovalConfigDetail on an.ApprovalDetailID equals ad.ConfigDetailID

                              where an.ModuleName == ApprovalModules.MachineMaintenance && an.IsChecked == false
                              && (designationID == 0 || designationID == ad.ApproverJobTitleID) && (employeeID == 0 || employeeID == ad.ApproverEmployeeID)
                              select new MachineMaintenanceNotificationRM()
                              {
                                  NotificationID = an.NotificationID,
                                  ApplicationID = an.ApplicationID
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

        public async Task<List<ApprovalNotification>> GetLeaveApplicationNotification(int approverEmployeeID, CancellationToken cancellationToken=default)
        {
            var dataQuery = (from an in dbCon.ApprovalNotification
                             join la in dbCon.Tbl_EmpLeaves on an.ApplicationID equals la.ID
                             join e in dbCon.Tbl_Emp on la.Leave_Emp equals e.Emp_ID
                             join acd in dbCon.ApprovalConfigDetail on an.ApprovalDetailID equals acd.ConfigDetailID
                             where e.Emp_Active == true && an.ModuleName == ApprovalModules.LeaveApplication && an.IsShortLeave==false && an.IsChecked == false
                               && acd.ApproverEmployeeID == approverEmployeeID && an.IsActive == true && an.IsRemoved == false
                             select new ApprovalNotification
                             {
                                 NotificationID = an.NotificationID,
                                 ModuleName = an.ModuleName,
                                 ApprovalMasterID = an.ApprovalMasterID,
                                 ApprovalDetailID = an.ApprovalDetailID,
                                 ApproverEmployeeID = an.ApproverEmployeeID,
                                 ApplicationID = an.ApplicationID,
                                 IsChecked = an.IsChecked,
                                 Remarks = an.Remarks,
                                 CheckedStatus = an.CheckedStatus,
                                 CheckedDate = an.CheckedDate,
                                 IsShortLeave = an.IsShortLeave
                             });
            var shortLeaveDataQuery = (from an in dbCon.ApprovalNotification
                             join la in dbCon.EmployeeShortLeave on an.ApplicationID equals la.ShortLeaveID
                             join e in dbCon.Tbl_Emp on la.EmployeeID equals e.Emp_ID
                             join acd in dbCon.ApprovalConfigDetail on an.ApprovalDetailID equals acd.ConfigDetailID
                             where e.Emp_Active == true && an.ModuleName == ApprovalModules.LeaveApplication && an.IsShortLeave==true && an.IsChecked == false
                               && acd.ApproverEmployeeID == approverEmployeeID && an.IsActive == true && an.IsRemoved == false
                             select new ApprovalNotification
                             {
                                 NotificationID = an.NotificationID,
                                 ModuleName = an.ModuleName,
                                 ApprovalMasterID = an.ApprovalMasterID,
                                 ApprovalDetailID = an.ApprovalDetailID,
                                 ApproverEmployeeID = an.ApproverEmployeeID,
                                 ApplicationID = an.ApplicationID,
                                 IsChecked = an.IsChecked,
                                 Remarks = an.Remarks,
                                 CheckedStatus = an.CheckedStatus,
                                 CheckedDate = an.CheckedDate,
                                 IsShortLeave = an.IsShortLeave
                             });
            //var qs = dataQuery.ToQueryString();
                var data= await dataQuery.ToListAsync(cancellationToken);
            var shortLeaveData = await shortLeaveDataQuery.ToListAsync(cancellationToken);
            data.AddRange(shortLeaveData);
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
                                  ApplicationID = n.ApplicationID,
                                  ApprovalMasterID = n.ApprovalMasterID,
                                  ApprovalDetailID = n.ApprovalDetailID,
                                  ApproverEmployeeID = cd.ApproverEmployeeID.Value
                              }).ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<OutsideTaskNotificationRM>> GetOutSideTaskNotification(int approverEmployeeID,int caUserID, CancellationToken cancellationToken)
        {
            try
            {
                var data = await (from n in dbCon.ApprovalNotification
                                  join cd in dbCon.ApprovalConfigDetail on n.ApprovalDetailID equals cd.ConfigDetailID
                                  join vw in dbCon.Vw_OutSideTask on n.ApplicationID equals vw.OutSideTaskID
                                  //join ud in dbCon.UserDepartmentAccess on vw.SectionID equals ud.SectionID
                                  where cd.ApproverEmployeeID==approverEmployeeID
                                  //ud.CA_UserID == caUserID 
                                  && n.ModuleName == ApprovalModules.OutsideOfficeWork && n.IsActive == true && n.IsRemoved == false && n.IsChecked == false
                                  select new OutsideTaskNotificationRM
                                  {
                                      NotificationID = n.NotificationID,
                                      OutSideTaskID = vw.OutSideTaskID,
                                      EmployeeID = vw.EmployeeID,
                                      EmployeeCode = vw.EmployeeCode,
                                      TaskDurationType = vw.TaskDurationType,
                                      OutsideTaskDate = vw.OutsideTaskDate.ToString("dd-MMM-yyyy"),
                                      TimeFrom = vw.TimeFrom,
                                      TimeTo = vw.TimeTo,
                                      EmbroCompanyID = vw.EmbroCompanyID,
                                      Company = vw.Company,
                                      DivisionID = vw.DivisionID,
                                      Division = vw.Division,
                                      DepartmentID = vw.DepartmentID,
                                      Department = vw.Department,
                                      SectionID = vw.SectionID,
                                      Section = vw.Section,
                                      Designation = vw.Designation,
                                      DesignationID = vw.DesignationID,
                                      ApplicantName = vw.ApplicantName,
                                      Reason = vw.Reason,
                                      TaskAddress = vw.TaskAddress

                                  }).ToListAsync(cancellationToken);
                return data;
            }
            catch (Exception e)
            {
                throw;
            }            
        }
    }
}
