using Hangfire;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.Models;
using RG.Application.Common.Utilities;
using RG.Application.Contracts.AlgoHR.Business.ApprovalNotifications.Queries.RequestResponseModel;
using RG.Application.Contracts.AlgoHR.Business.Tbl_EmpLeavess.Query.RequestResponseModel;
using RG.Application.Contracts.AlgoHR.Tbl_EmpLeavess.Query.RequestResponseModel;
using RG.Application.Enums;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.Application.Interfaces.Repositories.AlgoHR.Setup;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Business;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Setup;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using RG.DBEntities.AlgoHR.Business;
using RG.DBEntities.AlgoHR.DBViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AlgoHR.Business
{
    public class ApprovalNotificationService : IApprovalNotificationService
    {
        private readonly IApprovalNotificationRepository approvalNotificationRepository;
        private readonly IApprovalConfigMasterRepository approvalConfigMasterRepository;
        private readonly IMT_MachineAndMaintenanceCheckListMasterRepository machineAndMaintenanceCheckListMasterRepository;
        private readonly Ivw_ERP_EmpShortInfoRepository _vw_ERP_EmpShortInfoRepository;
        private readonly IEmailSenderService _emailSenderService;
        private readonly IMT_Machine_SetupRepository _mt_Machine_SetupRepository;
        private readonly IWebHostEnvironment _env;

        private readonly ITbl_EmpLeavesRepository tbl_EmpLeavesRepository;
        private readonly ITbl_LeavesRepository tbl_LeavesRepository;
        private readonly ICurrentUserService currentUserService;
        private readonly ITbl_EmpOutSideTaskRepository empOutSideTaskRepository;
        private readonly ITbl_EmpAttendanceRepository _empAttendanceRepository;
        private readonly IEmployeeShortLeaveRepository _employeeShortLeaveRepository;

        public ApprovalNotificationService(IApprovalNotificationRepository _approvalNotificationRepository
            , IApprovalConfigMasterRepository _approvalConfigMasterRepository
            , IMT_MachineAndMaintenanceCheckListMasterRepository _machineAndMaintenanceCheckListMasterRepository
             , Ivw_ERP_EmpShortInfoRepository vw_ERP_EmpShortInfoRepository, IEmailSenderService emailSenderService
            , IMT_Machine_SetupRepository mt_Machine_SetupRepository
            , ITbl_EmpLeavesRepository _tbl_EmpLeavesRepository
            , ITbl_LeavesRepository _tbl_LeavesRepository
            , ICurrentUserService _currentUserService
            , ITbl_EmpOutSideTaskRepository _empOutSideTaskRepository
            , ITbl_EmpAttendanceRepository EmpAttendanceRepository
            , IEmployeeShortLeaveRepository employeeShortLeaveRepository
           


       , IWebHostEnvironment env)
        {
            approvalNotificationRepository = _approvalNotificationRepository;
            approvalConfigMasterRepository = _approvalConfigMasterRepository;
            machineAndMaintenanceCheckListMasterRepository = _machineAndMaintenanceCheckListMasterRepository;
            _vw_ERP_EmpShortInfoRepository = vw_ERP_EmpShortInfoRepository;
            _emailSenderService = emailSenderService;
            _mt_Machine_SetupRepository = mt_Machine_SetupRepository;
            tbl_EmpLeavesRepository = _tbl_EmpLeavesRepository;
            tbl_LeavesRepository = _tbl_LeavesRepository;
            currentUserService = _currentUserService;
            empOutSideTaskRepository = _empOutSideTaskRepository;
            _empAttendanceRepository = EmpAttendanceRepository;
            _employeeShortLeaveRepository = employeeShortLeaveRepository;
            _env = env;

        }
        public async Task<RResult> ApproveNotification(List<int> notificationIDs, string comment)
        {
            try
            {
                RResult rResult = new();
                foreach (var notificationID in notificationIDs)
                {

                    var nextLevelNotification = new ApprovalNotification();
                    var notification = await approvalNotificationRepository.GetByIdAsync(notificationID);
                    var approvalConfig = await approvalConfigMasterRepository.GetModuleWiseApprovalConfig(notification.ApprovalMasterID);
                    var currentApprover = approvalConfig.ApprovalConfigDetail.Where(y => y.ConfigDetailID == notification.ApprovalDetailID).First();
                    var nextLevelApprover = approvalConfig.ApprovalConfigDetail
                        .Where(x => x.ApprovalLevel == currentApprover.ApprovalLevel + 1).FirstOrDefault();

                    notification.ApproverEmployeeID = currentUserService.EmployeeID;
                    notification.IsChecked = true;
                    notification.CheckedStatus = (int)enum_ApprovalNotificationStatus.Approved; 
                    notification.CheckedDate = DateTime.Now;
                    notification.Remarks = comment;

                    rResult = await approvalNotificationRepository.UpdateNotification(notification);
                    if (nextLevelApprover != null)
                    {
                        var newNotification = new ApprovalNotification
                        {
                            ModuleName = notification.ModuleName,
                            ApprovalMasterID = nextLevelApprover.ConfigMasterID,
                            ApprovalDetailID = nextLevelApprover.ConfigDetailID,
                            //ApproverEmployeeID = nextLevelApprover.ApproverEmployeeID,
                            IsShortLeave = notification.IsShortLeave,
                            ApplicationID = notification.ApplicationID,
                            CreatedDateOnly = DateTime.Now,
                        };
                        rResult = await approvalNotificationRepository.SaveApprovalNotification(newNotification);

                    }
                    switch (notification.ModuleName)
                    {
                        case ApprovalModules.MachineMaintenance:
                            {
                                if (currentApprover.ApprovalLevel == 1 || (currentApprover.ApprovalLevel != 1 && nextLevelApprover == null))
                                {
                                    var entity = await machineAndMaintenanceCheckListMasterRepository.GetByIdAsync(notification.ApplicationID);
                                    if (currentApprover.ApprovalLevel == 1)
                                    {
                                        entity.FirstAuthorityComments = comment;
                                        entity.FirstAuthorityCommentsDate = DateTime.Now;
                                        if (nextLevelApprover != null)
                                            entity.StatusID = (int)enum_MachineMaintenanceStatus.Processing;
                                        else
                                            entity.StatusID = (int)enum_MachineMaintenanceStatus.Approved;

                                    }
                                    else
                                    {
                                        entity.LastAuthorityComments = comment;
                                        entity.LastAuthorityCommentsDate = DateTime.Now;
                                        entity.StatusID = (int)enum_MachineMaintenanceStatus.Approved;
                                    }
                                    entity.StatusDate = DateTime.Now;
                                    rResult = await machineAndMaintenanceCheckListMasterRepository.UpdateMT_MachineAndMaintenanceCheckListMaster(entity);

                                }
                                if (_env.IsDevelopment() == false)
                                {
                                    if (nextLevelApprover != null)
                                        BackgroundJob.Enqueue(() => SendNotificationEmail(notification.ModuleName, nextLevelApprover.ApproverEmployeeID.Value, "", "", ""));
                                }
                                break;
                            }
                        case ApprovalModules.LeaveApplication:
                            {
                                if (nextLevelApprover == null)
                                {
                                    if (!notification.IsShortLeave)
                                    {
                                        var entity = await tbl_EmpLeavesRepository.GetByIdAsync(Convert.ToInt64(notification.ApplicationID));
                                        entity.Leave_Approved = true;
                                        entity.Leave_Code = "Approved";
                                        rResult = await tbl_EmpLeavesRepository.UpdateTbl_EmpLeaves(entity, true);
                                        await UpdateLeaveAttendanceStatus(entity.Leave_Emp.Value, entity.Leave_From.Value, entity.Leave_To.Value,(short)enum_AttendanceStatus.LeaveWithPay,false, true);
                                        //await tbl_EmpLeavesRepository.CommitAsync();
                                        rResult.result = 1;
                                        rResult.message = "Approved Successfully";
                                    }
                                    else
                                    {
                                        var entity = await _employeeShortLeaveRepository.GetByIdAsync(notification.ApplicationID);
                                        entity.IsApproved = true;
                                        rResult = await _employeeShortLeaveRepository.UpdateEmployeeShortLeave(entity);
                                        await UpdateLeaveAttendanceStatus(entity.EmployeeID, entity.LeaveDate, entity.LeaveDate, (short)enum_AttendanceStatus.Present,true, true);
                                    }
                                }
                                if (_env.IsDevelopment() == false)
                                {
                                    //BackgroundJob.Enqueue(() => SendNotificationEmail(notification.ModuleName, nextLevelApprover.ApproverEmployeeID.Value, "", "", ""));
                                }
                                break;
                            }
                        case ApprovalModules.OutsideOfficeWork:
                            {
                                if (currentApprover.ApprovalLevel == 1 || (currentApprover.ApprovalLevel != 1 && nextLevelApprover == null))
                                {
                                    var entity = await empOutSideTaskRepository.GetByIdAsync(notification.ApplicationID);
                                    if (currentApprover.ApprovalLevel == 1)
                                    {
                                        if (nextLevelApprover != null)
                                            entity.IsApproved = (int)enum_ApprovalNotificationStatus.Processing;
                                        else
                                            entity.IsApproved = (int)enum_ApprovalNotificationStatus.Approved;
                                    }
                                    else
                                    {
                                        entity.IsApproved = (int)enum_ApprovalNotificationStatus.Approved;
                                    }

                                    rResult = await empOutSideTaskRepository.UpdateTbl_EmpOutSideTask(entity);

                                    // Is Approved thn update attendance table with Outside Duty
                                    if (rResult.result == 1 && entity.IsApproved == (int)enum_ApprovalNotificationStatus.Approved)
                                    {
                                        rResult = await UpdateAttendanceDataWithOutSideDuty(entity);
                                    }
                                }
                                //if (_env.IsDevelopment() == false)
                                //{
                                //    if (nextLevelApprover != null)
                                //        BackgroundJob.Enqueue(() => SendNotificationEmail(notification.ModuleName, nextLevelApprover.ApproverEmployeeID.Value, "", "", ""));
                                //}
                                break;
                            }
                        default:
                            break;
                    }
                }
                return rResult;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private async Task<RResult> UpdateAttendanceDataWithOutSideDuty(Tbl_EmpOutSideTask outSideTask)
        {
            var attendance = await _empAttendanceRepository.GetEmpAttendance(outSideTask.EmployeeID, outSideTask.OutsideTaskDate.Date);
            if (attendance.Att_InTime == null)
            {
                attendance.Att_InTime = outSideTask.OutsideTaskDate.Date + Convert.ToDateTime(outSideTask.TimeFrom).TimeOfDay;
            }
            if (attendance.Att_OutTime == null)
            {
                attendance.Att_OutTime = outSideTask.OutsideTaskDate.Date + Convert.ToDateTime(outSideTask.TimeTo).TimeOfDay;
            }
            attendance.Att_Status = 3;//Present from HRTEST
            attendance.Att_Remarks = $"Outside Duty ({outSideTask.TaskDurationType} From {outSideTask.TimeFrom} To {outSideTask.TimeTo})";
            return await _empAttendanceRepository.UpdateEmpAttendance(attendance);
        }

        public async Task<List<NotificationRM>> GetAllNotifications()
        {
            return await approvalNotificationRepository.GetAllNotifications();
        }

        public async Task<List<LeaveApplicationNotificationRM>> GetLeaveApplicationNotification(CancellationToken cancellationToken)
        {
            var leaveNotifications = await approvalNotificationRepository.GetLeaveApplicationNotification(currentUserService.EmployeeID, cancellationToken);
            var leavesToApprove = await tbl_EmpLeavesRepository.GetLeaveApplicationsWaitingForApproval(cancellationToken);

            var shortLeavesToApprove = await _employeeShortLeaveRepository.GetShortLeaveApplicationsWaitingForApproval(cancellationToken);

            var fullLeaveNotifications = leaveNotifications.Where(x => x.IsShortLeave == false).ToList();
            var shortLeaveNotifications = leaveNotifications.Where(x => x.IsShortLeave == true).ToList();

            List<LeaveApplicationNotificationRM> data = await GetLeaveDataList(leavesToApprove, fullLeaveNotifications, cancellationToken);
            List<LeaveApplicationNotificationRM> shortData = await GetShortLeaveDataList(shortLeavesToApprove, shortLeaveNotifications, cancellationToken);

            data.AddRange(shortData);

            return data.OrderBy(b=>b.EmployeeID).ThenBy(s=>s.LeaveDate).ToList();
        }

        private async Task<List<LeaveApplicationNotificationRM>> GetShortLeaveDataList(List<EmpLeavesRM> shortLeavesToApprove, List<ApprovalNotification> shortLeaveNotifications, CancellationToken cancellationToken)
        {
            var shortData = (from ln in shortLeaveNotifications
                             join la in shortLeavesToApprove on ln.ApplicationID equals la.ID

                             select new LeaveApplicationNotificationRM
                             {
                                 NotificationID = ln.NotificationID,
                                 ApplicationID = ln.ApplicationID,
                                 EmployeeID = la.Leave_Emp.Value,
                                 EmployeeCode = la.Leave_EmpCD,
                                 EmployeeName = la.Leave_EmpName,
                                 LeaveTypeID = la.Leave_TypeID,
                                 LeaveType = la.Leave_Type,
                                 LeaveFromMsg = la.Leave_FromMsg,
                                 LeaveDate = $"{la.Leave_FromMsg}{la.Leave_ToMsg}",
                                 LeaveDateSort = $"{la.Leave_From.Value.ToString("dd-MMM")} {la.Leave_ToMsg}",
                                 LeaveToMsg = la.Leave_ToMsg,
                                 LeaveCreatedMsg = la.Leave_CreatedMsg,
                                 LeaveReason = la.Leave_Reason,
                                 LeaveApproved = la.Leave_Approved,
                                 LeaveAddress = la.Leave_Address,
                                 CompanyName = la.CompanyName,
                                 DivisionName = la.DivisionName,
                                 DepartmentName = la.DepartmentName,
                                 SectionName = la.SectionName,
                                 LeaveDays = la.LeaveDays,
                                 Designation = la.Designation,
                                 AttendanceDateStr = la.AttendanceDateStr,
                                 AttendanceInTime = la.AttendanceInTime,
                                 AttendanceOutTime = la.AttendanceOutTime,
                                 ShortLeaveOutTimeStatus = la.AttendanceDateAndOutTime.HasValue == true ? ShortLeaveOutStatus(la.ShortLeaveFromTime,la.AttendanceDateAndOutTime.Value) : ""
                             }).ToList();


            var empWithShortLeave = shortData.Select(x => new EmpLeavesEnjoyedQM { EmployeeID = x.EmployeeID, LeaveDate = Convert.ToDateTime(x.LeaveFromMsg) }).Distinct().ToList();

            var shortLeavesEnjoyed = await _employeeShortLeaveRepository.EmpShortLeavesEnjoyed(empWithShortLeave, cancellationToken);


            foreach (var item in shortData)
            {
                var enjoyedLeave = shortLeavesEnjoyed.Where(y => y.EmployeeID == item.EmployeeID && y.LeaveDate == item.LeaveFromMsg).FirstOrDefault();
                if (enjoyedLeave != null)
                    item.LeaveEnjoyed = enjoyedLeave.LeaveEnjoyed;
            }

            return shortData;
        }

        private async Task<List<LeaveApplicationNotificationRM>> GetLeaveDataList(List<EmpLeavesRM> leavesToApprove, List<ApprovalNotification> fullLeaveNotifications, CancellationToken cancellationToken)
        {
            var data = (from ln in fullLeaveNotifications
                        join la in leavesToApprove on ln.ApplicationID equals la.ID

                        select new LeaveApplicationNotificationRM
                        {
                            NotificationID = ln.NotificationID,
                            ApplicationID = ln.ApplicationID,
                            EmployeeID = la.Leave_Emp.Value,
                            EmployeeCode = la.Leave_EmpCD,
                            EmployeeName = la.Leave_EmpName,
                            LeaveTypeID = la.Leave_TypeID,
                            LeaveType = la.Leave_Type,
                            LeaveFromMsg = la.Leave_FromMsg,
                            LeaveDate = $"{la.Leave_FromMsg} to {la.Leave_ToMsg}",
                            LeaveDateSort = la.Leave_From.Value == la.Leave_To.Value ? $"{la.Leave_FromMsg}" : $"{la.Leave_From.Value:dd-MMM}  to  {la.Leave_To.Value:dd-MMM}",
                            LeaveToMsg = la.Leave_ToMsg,
                            LeaveCreatedMsg = la.Leave_CreatedMsg,
                            LeaveReason = la.Leave_Reason,
                            LeaveApproved = la.Leave_Approved,
                            LeaveAddress = la.Leave_Address,
                            CompanyName = la.CompanyName,
                            DivisionName = la.DivisionName,
                            DepartmentName = la.DepartmentName,
                            SectionName = la.SectionName,
                            LeaveDays = la.LeaveDays,
                            Designation = la.Designation,

                            ComplimentaryLeaveDate = la.ComplimentaryLeaveDate,
                            HolidayType = la.HolidayType,
                            AttendanceInTime = la.AttendanceInTime,
                            AttendanceOutTime = la.AttendanceOutTime
                        }).ToList();


            var empWithLeaveType = data.Select(x => new EmpLeavesEnjoyedQM { EmployeeID = x.EmployeeID, LeaveTypeID = x.LeaveTypeID }).Distinct().ToList();

            var leavesEnjoyed = await tbl_EmpLeavesRepository.EmpLeavesEnjoyed(empWithLeaveType, cancellationToken);


            foreach (var item in data)
            {
                var enjoyedLeave = leavesEnjoyed.Where(y => y.EmployeeID == item.EmployeeID && y.LeaveTypeID == item.LeaveTypeID).FirstOrDefault();
                if (enjoyedLeave != null)
                    item.LeaveEnjoyed = enjoyedLeave.LeaveEnjoyed;
            }

            return data;
        }

        public async Task<List<MachineMaintenanceNotificationRM>> GetMachineMaintenanceNotification(int designationID, int employeeID, CancellationToken cancellationToken)
        {
            var notApprovedApplications = await approvalNotificationRepository.GetMachineMaintenanceNotification(designationID, employeeID, cancellationToken);
            var data = await machineAndMaintenanceCheckListMasterRepository.GetMachineMaintenanceCheckListByNotification(notApprovedApplications, cancellationToken);
            return data;
        }

        public async Task<RResult> RejectNotification(int notificationID, string comment)
        {
            RResult rResult = new();
            try
            {
                var notification = await approvalNotificationRepository.GetByIdAsync(notificationID);
                notification.IsChecked = true;
                notification.CheckedStatus = (int)enum_ApprovalNotificationStatus.Rejected;
                notification.CheckedDate = DateTime.Now;
                notification.Remarks = comment;
                notification.ApproverEmployeeID = currentUserService.EmployeeID;
                rResult = await approvalNotificationRepository.UpdateNotification(notification);

                switch (notification.ModuleName)
                {
                    case ApprovalModules.MachineMaintenance:
                        {
                            var entity = await machineAndMaintenanceCheckListMasterRepository.GetByIdAsync(notification.ApplicationID);
                            entity.LastAuthorityComments = comment;
                            entity.LastAuthorityCommentsDate = DateTime.Now;
                            entity.StatusID = (int)enum_MachineMaintenanceStatus.Rejected;
                            entity.StatusDate = DateTime.Now;
                            rResult = await machineAndMaintenanceCheckListMasterRepository.UpdateMT_MachineAndMaintenanceCheckListMaster(entity);
                            break;
                        }
                    case ApprovalModules.LeaveApplication:
                        {
                            if (!notification.IsShortLeave)
                            {
                                var entity = await tbl_EmpLeavesRepository.GetByIdAsync((long)notification.ApplicationID);
                                entity.Leave_Approved = false;
                                entity.Leave_Code = "Reject";
                                rResult = await tbl_EmpLeavesRepository.UpdateTbl_EmpLeaves(entity, true);
                            }
                            else
                            {
                                var entity = await _employeeShortLeaveRepository.GetByIdAsync(notification.ApplicationID);
                                entity.IsApproved = false;
                                rResult = await _employeeShortLeaveRepository.UpdateEmployeeShortLeave(entity);
                            }
                            break;
                        }
                    case ApprovalModules.OutsideOfficeWork:
                        {
                            var entity = await empOutSideTaskRepository.GetByIdAsync(notification.ApplicationID);                           
                            entity.IsApproved = (int)enum_ApprovalNotificationStatus.Rejected;                          
                            rResult = await empOutSideTaskRepository.UpdateTbl_EmpOutSideTask(entity);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return rResult;
        }


        public async Task SendNotificationEmail(string ModuleName, int EmployeeID, string MachineNmae, string ScheduleDate, string CheckDate)
        {
            var empShortInfo = await _vw_ERP_EmpShortInfoRepository.Get_ERP_EmpShortInfo(null, EmployeeID);
            if (!string.IsNullOrEmpty(empShortInfo.Office_Email))
            {
                List<string> email = new()
                {
                    empShortInfo.Office_Email
                };
                string subject = "";
                string content = "";

                if (ModuleName == ApprovalModules.MachineMaintenance)
                {
                    subject = $"Machine Maintenance Check";
                    content = MachineMaintenanceEmailBodyContent(empShortInfo);
                }
                else if (ModuleName == ApprovalModules.LeaveApplication)
                {
                    subject = $"Leave Approval Check";
                    content = LeaveApprovalEmailBodyContent(empShortInfo);
                }


                var emailMessage = new EmailMessageAttachment(subject, content, email);
                await _emailSenderService.SendEmailAsync(emailMessage);
            }
        }

        private string LeaveApprovalEmailBodyContent(vw_ERP_EmpShortInfo empShortInfo)
        {
            throw new NotImplementedException();
        }

        private static string MachineMaintenanceEmailBodyContent(vw_ERP_EmpShortInfo empShortInfo)
        {
            StringBuilder sbContent = new();

            sbContent.Append($"<b>Mr. {empShortInfo.EmployeeName}</b>");
            sbContent.Append("<br/>");
            sbContent.AppendLine($"You have a Machine Mainteance approval notification");
            sbContent.Append("<br/>");
            sbContent.Append("<br/>");
            sbContent.Append($"Please check  <a href=\"{StaticConfigs.GetConfig("ProjectLiveURL")}\"><b> Robintex ERP </b></a> ");
            sbContent.Append("<br/>");
            sbContent.Append("<br/>");
            sbContent.Append("For any difficulty please contact with <b>Robintex IT Department.</b>");
            sbContent.Append("<br/>");

            sbContent.AppendLine("<em><b>Thanks</b></em>");

            return sbContent.ToString();
        }
        public async Task<List<LeaveApplicationsApprovalPendingLevelRM>> GetLeaveApplicationsApprovalPendingLevel(CancellationToken cancellationToken)
        {
            return await approvalNotificationRepository.GetLeaveApplicationsApprovalPendingLevel(cancellationToken);
        }

        public async Task<List<OutsideTaskNotificationRM>> GetOutSideTaskNotification(CancellationToken cancellationToken)
        {
            return await approvalNotificationRepository.GetOutSideTaskNotification(currentUserService.EmployeeID, currentUserService.UserID, cancellationToken);
        }



        private async Task UpdateLeaveAttendanceStatus(long EmpID, DateTime DateFrom, DateTime DateTo,short AttendanceStatus,bool IsShortLeave=false, bool saveChanges = false)
        {
            while (DateFrom <= DateTo)
            {
                var attendanceData = await _empAttendanceRepository.FindAsync(b => b.Att_Emp == EmpID && b.Att_Date == DateFrom);
                if (attendanceData != null)
                {
                    attendanceData.Att_Status = AttendanceStatus;// enum_AttendanceStatus.LeaveWithPay;
                    if (IsShortLeave == true)
                    {
                        attendanceData.Att_Adjusted = true;
                        attendanceData.Att_Remarks = "Short Leave";
                    }
                    await _empAttendanceRepository.UpdateAsync(attendanceData, saveChanges);
                }
                else
                {
                    break;
                }
                DateFrom = DateFrom.AddDays(1);
            }
        }

        public async Task<RResult> ApprovalNotificationCancel(int applicationID,string Commant,string status, string ModuleName, bool saveChanges = true)
        {
            try
            {
                RResult result = new();
                var dbModel = await approvalNotificationRepository.FindAsync(x => x.ApplicationID == applicationID && x.ModuleName == ModuleName && x.IsChecked == false);
                if (dbModel.ApplicationID > 0)
                {
                    
                    dbModel.IsActive = false;
                    await approvalNotificationRepository.UpdateAsync(dbModel, saveChanges);
                    result.result = 1;
                    result.message = ReturnMessage.UpdateMessage;

                }
                else
                {
                    result.result = 0;
                    result.message = ReturnMessage.NoDataFound;
                }
                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private string ShortLeaveOutStatus(DateTime shortLeaveOutTime,DateTime attendanceOutTime)
        {
            string status = "intime";
            if(attendanceOutTime>= shortLeaveOutTime)
            {
                return status;
            }
            var timeDifference = (shortLeaveOutTime- attendanceOutTime).TotalMinutes;
            if (timeDifference > 0 && timeDifference > 100) 
            {
                status = "earlytime";
            }
          
            return status;
        }
    }
}
