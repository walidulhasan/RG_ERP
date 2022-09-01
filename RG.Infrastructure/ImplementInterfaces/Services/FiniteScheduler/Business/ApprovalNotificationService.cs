using Hangfire;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.Models;
using RG.Application.Common.Utilities;
using RG.Application.Contracts.FiniteScheduler.Business.ApprovalNotifications.Queries.RequestResponseModel;
using RG.Application.Enums;
using RG.Application.Interfaces.Repositories.AlgoHR;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Business;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Setup;
using RG.Application.Interfaces.Services.FiniteScheduler.Business;
using RG.DBEntities.AlgoHR.DBViews;
using RG.DBEntities.FiniteScheduler.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.FiniteScheduler.Business
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

        public ApprovalNotificationService(IApprovalNotificationRepository _approvalNotificationRepository
            , IApprovalConfigMasterRepository _approvalConfigMasterRepository
            , IMT_MachineAndMaintenanceCheckListMasterRepository _machineAndMaintenanceCheckListMasterRepository
             , Ivw_ERP_EmpShortInfoRepository vw_ERP_EmpShortInfoRepository, IEmailSenderService emailSenderService
            , IMT_Machine_SetupRepository mt_Machine_SetupRepository
            , ITbl_EmpLeavesRepository _tbl_EmpLeavesRepository
            , ITbl_LeavesRepository _tbl_LeavesRepository
            , ICurrentUserService _currentUserService
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
                    notification.CheckedStatus = (int)enum_ApprovalNotificationStatus.Approved; ;
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
                                    BackgroundJob.Enqueue(() => SendNotificationEmail(notification.ModuleName, nextLevelApprover.ApproverEmployeeID.Value, "", "", ""));
                                }
                                break;
                            }
                        case ApprovalModules.LeaveApplication:
                            {
                                if (nextLevelApprover == null)
                                {

                                    var entity = await tbl_EmpLeavesRepository.GetByIdAsync(Convert.ToInt64(notification.ApplicationID));
                                    entity.Leave_Approved = true;
                                    rResult = await tbl_EmpLeavesRepository.UpdateTbl_EmpLeaves(entity);


                                }
                                if (_env.IsDevelopment() == false)
                                {
                                    //BackgroundJob.Enqueue(() => SendNotificationEmail(notification.ModuleName, nextLevelApprover.ApproverEmployeeID.Value, "", "", ""));
                                }
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

        public async Task<List<NotificationRM>> GetAllNotifications()
        {
            return await approvalNotificationRepository.GetAllNotifications();
        }

        public async Task<List<LeaveApplicationNotificationRM>> GetLeaveApplicationNotification(CancellationToken cancellationToken)
        {
            var leaveNotifications = await approvalNotificationRepository.GetLeaveApplicationNotification(currentUserService.EmployeeID, cancellationToken);
            var leavesToApprove = await tbl_EmpLeavesRepository.GetLeaveApplicationsWaitingForApproval(cancellationToken);

            var data = (from ln in leaveNotifications
                        join la in leavesToApprove on ln.ApplicationID.Value equals la.ID
                        select new LeaveApplicationNotificationRM
                        {
                            NotificationID = ln.NotificationID,
                            ApplicationID = ln.ApplicationID.Value,
                            EmployeeID = la.Leave_Emp.Value,
                            EmployeeCode = la.Leave_EmpCD,
                            EmployeeName = la.Leave_EmpName,
                            LeaveType = la.Leave_Type,
                            LeaveFromMsg = la.Leave_FromMsg,
                            LeaveToMsg = la.Leave_ToMsg,
                            LeaveCreatedMsg = la.Leave_CreatedMsg,
                            LeaveReason = la.Leave_Reason,
                            LeaveApproved = la.Leave_Approved,
                            LeaveAddress = la.Leave_Address,
                            CompanyName = la.CompanyName,
                            DivisionName = la.DivisionName,
                            DepartmentName = la.DepartmentName,
                            SectionName = la.SectionName,
                            LeaveDays = la.LeaveDays
                        }).ToList();
            return data;
        }

        public async Task<List<MachineMaintenanceNotificationDetailRM>> GetMachineAndMaintenanceCheckListDetail(int masterID, CancellationToken cancellationToken)
        {
            return await approvalNotificationRepository.GetMachineAndMaintenanceCheckListDetail(masterID, cancellationToken);
        }

        public async Task<List<MachineMaintenanceNotificationRM>> GetMachineMaintenanceNotification(int designationID, int employeeID, CancellationToken cancellationToken)
        {
            return await approvalNotificationRepository.GetMachineMaintenanceNotification(designationID, employeeID, cancellationToken);
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
                            var entity = await tbl_EmpLeavesRepository.GetByIdAsync(notification.ApplicationID);
                            entity.Leave_Approved = false;
                            rResult = await tbl_EmpLeavesRepository.UpdateTbl_EmpLeaves(entity);
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
    }
}
