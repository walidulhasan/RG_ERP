using AutoMapper;
using Hangfire;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.Models;
using RG.Application.Common.Utilities;
using RG.Application.Contracts.AlgoHR.Business.ApprovalNotifications.Queries.RequestResponseModel;
using RG.Application.Contracts.AlgoHR.Setups.ApprovalConfigMasters.Queries.RequestResponseModel;
using RG.Application.Contracts.FiniteScheduler.Business.MT_MachineAndMaintenanceCheckListMasters.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Business.MT_MachineAndMaintenanceCheckListMasters.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Business;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Setup;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using RG.Application.Interfaces.Services.FiniteScheduler.Business;
using RG.DBEntities.AlgoHR.Business;
using RG.DBEntities.FiniteScheduler.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.FiniteScheduler.Business
{
    public class MT_MachineAndMaintenanceCheckListMasterService : IMT_MachineAndMaintenanceCheckListMasterService
    {
        private readonly IMT_MachineAndMaintenanceCheckListMasterRepository mT_MachineAndMaintenanceCheckListMasterRepository;
        private readonly IMapper mapper;
        private readonly IMT_Machine_SetupRepository mt_Machine_SetupRepository;       

        private readonly IApprovalNotificationRepository approvalNotificationRepository;
        private readonly IMT_MaintenanceSchedule_SetupRepository mT_MaintenanceSchedule_SetupRepository;
        private readonly Ivw_ERP_EmpShortInfoRepository _vw_ERP_EmpShortInfoRepository;
        private readonly IEmailSenderService _emailSenderService;
        private readonly ITbl_EmpRepository _tbl_EmpRepository;
        private readonly IWebHostEnvironment _env;
        private readonly IApprovalConfigMasterService approvalConfigMasterService;

        public MT_MachineAndMaintenanceCheckListMasterService(IMT_MachineAndMaintenanceCheckListMasterRepository _mT_MachineAndMaintenanceCheckListMasterRepository
            , IMapper _mapper, IMT_Machine_SetupRepository _mt_Machine_SetupRepository
            , IApprovalNotificationRepository _approvalNotificationRepository, IMT_MaintenanceSchedule_SetupRepository _mT_MaintenanceSchedule_SetupRepository
            , Ivw_ERP_EmpShortInfoRepository vw_ERP_EmpShortInfoRepository, IEmailSenderService emailSenderService
            , ITbl_EmpRepository tbl_EmpRepository, IWebHostEnvironment env, IApprovalConfigMasterService _approvalConfigMasterService)
        {
            mT_MachineAndMaintenanceCheckListMasterRepository = _mT_MachineAndMaintenanceCheckListMasterRepository;
            mapper = _mapper;
            mt_Machine_SetupRepository = _mt_Machine_SetupRepository;
            

            approvalNotificationRepository = _approvalNotificationRepository;
            mT_MaintenanceSchedule_SetupRepository = _mT_MaintenanceSchedule_SetupRepository;
            _vw_ERP_EmpShortInfoRepository = vw_ERP_EmpShortInfoRepository;
            _emailSenderService = emailSenderService;
            _tbl_EmpRepository = tbl_EmpRepository;
            _env = env;
            approvalConfigMasterService = _approvalConfigMasterService;
        }

        public async Task<List<MachineAndMaintenanceCheckRM>> GetMachineAndMaintenanceCheckList(int? machineID, DateTime dateFrom, DateTime dateTo, CancellationToken cancellationToken)
        {
            var dataList = await mT_MachineAndMaintenanceCheckListMasterRepository.GetMachineAndMaintenanceCheckList(machineID, dateFrom, dateTo, cancellationToken);
            var maintenanceEmployees = await _tbl_EmpRepository.MachineMaintenanceEmployees();

            foreach (var d in dataList)
            {
                if (!string.IsNullOrEmpty(d.ElectricalTaskCompletedBy))
                { 
                    d.ElectricalTaskCompletedByName = GetEmployeeNameConcate(maintenanceEmployees, d.ElectricalTaskCompletedBy);// await _tbl_EmpRepository.GetEmployeeNameConcate(d.ElectricalTaskCompletedBy, cancellationToken);
                }
                if (!string.IsNullOrEmpty(d.ElectricalTaskSupervisor))
                {
                    d.ElectricalTaskSupervisorName = GetEmployeeNameConcate(maintenanceEmployees, d.ElectricalTaskSupervisor); //await _tbl_EmpRepository.GetEmployeeNameConcate(d.ElectricalTaskSupervisor, cancellationToken);
                }

                if (!string.IsNullOrEmpty(d.MechanicalTaskCompletedBy))
                {
                    d.MechanicalTaskCompletedByName = GetEmployeeNameConcate(maintenanceEmployees, d.MechanicalTaskCompletedBy); //await _tbl_EmpRepository.GetEmployeeNameConcate(d.MechanicalTaskCompletedBy, cancellationToken);
                }

                if (!string.IsNullOrEmpty(d.MechanicalTaskSupervisor))
                {
                    d.MechanicalTaskSupervisorName = GetEmployeeNameConcate(maintenanceEmployees, d.MechanicalTaskSupervisor); //await _tbl_EmpRepository.GetEmployeeNameConcate(d.MechanicalTaskSupervisor, cancellationToken);
                }
            }
            return dataList;

        }

        private static string GetEmployeeNameConcate(List<SelectListItem> maintenanceEmployees, string electricalTaskCompletedBy)
        {
            electricalTaskCompletedBy = electricalTaskCompletedBy.TrimEnd(' ').TrimEnd(',');
            var empArray = electricalTaskCompletedBy.Split(',').Select(int.Parse).ToList();
           var data = maintenanceEmployees.Where(x => empArray.Contains(Convert.ToInt32(x.Value))).Select(z=>new { z.Text}).ToList();
            return string.Join(",", data.Select(x=>x.Text));
        }

        public async Task<MachineAndMaintenanceCheckMasterRM> GetMachineAndMaintenanceCheckListMasterData(int Id, CancellationToken cancellationToken)
        {
            return await mT_MachineAndMaintenanceCheckListMasterRepository.GetMachineAndMaintenanceCheckListMasterData(Id, cancellationToken);
        }

        public async Task<List<MachineMaintainceItemDetailRM>> GetMachineMaintainceItemDetailInfo(int month, int year, int locationID, int machineID, CancellationToken cancellationToken)
        {
            return await mT_MachineAndMaintenanceCheckListMasterRepository.GetMachineMaintainceItemDetailInfo(month, year, locationID, machineID, cancellationToken);
        }

        public async Task<List<MonthlyMachineMaintainceRM>> GetMonthlyMachineMaintainceReport(int locationID, int month, int year, CancellationToken cancellationToken = default)
        {
            return await mT_MachineAndMaintenanceCheckListMasterRepository.GetMonthlyMachineMaintainceReport(locationID, month, year, cancellationToken);
        }

        public async Task<RResult> MachineMaintenceCheckListSave(CheckListMasterDTM model, bool saveChanges = true)
        {
            RResult rResult = new RResult();
            try
            {
                var machineInfo = await mt_Machine_SetupRepository.GetByIdAsync(model.MachineID);

                var masterObj = await mT_MachineAndMaintenanceCheckListMasterRepository.GetMachineAndMaintenanceCheckListMasterDataByCheckDate(model.MachineID, model.CheckDate);

                if (masterObj == null)
                {
                    var entity = mapper.Map<CheckListMasterDTM, MT_MachineAndMaintenanceCheckListMaster>(model);
                    //entity.ScheduleDate= machineInfo.NextCheckDate.HasValue == true ? machineInfo.NextCheckDate.Value : DateTime.Now;

                    entity.MachineAndMaintenanceCheckListDetails.ForEach(x => { x.MechanicalCommentsDate = DateTime.Now; x.ElectricalCommentsDate = DateTime.Now; });
                    //await mt_Machine_SetupRepository.UpdateMachineNextPreventativeDate(model.MachineID, model.CheckDate, nextpreventativeDate, false);

                    rResult = await mT_MachineAndMaintenanceCheckListMasterRepository.MachineMaintenceCheckListSave(entity, saveChanges);

                    var schedule = await mT_MaintenanceSchedule_SetupRepository.GetByIdAsync(model.ScheduleID);
                    schedule.CheckDate = model.CheckDate;
                    schedule.CheckedStatus = 1;
                    await mT_MaintenanceSchedule_SetupRepository.UpdateMaintenanceSchedule(schedule, saveChanges);

                    ModuleWiseApprovalConfigQM queryModel = new()
                    {
                        ModuleName = ApprovalModules.MachineMaintenance
                    };

                    var approvalConfig = await approvalConfigMasterService.GetEmployeeModuleWiseApprovalConfig(queryModel);
                    if (approvalConfig != null && approvalConfig.ApprovalConfigDetail.Count > 0)
                    {
                        var firstApprover = approvalConfig.ApprovalConfigDetail.ToList().Where(x => x.ApprovalLevel == 1).First();
                        var notification = new ApprovalNotification
                        {
                            ModuleName = ApprovalModules.MachineMaintenance,
                            ApprovalMasterID = approvalConfig.ConfigMasterID,
                            ApprovalDetailID = firstApprover.ConfigDetailID,
                            ApproverEmployeeID = firstApprover.ApproverEmployeeID,
                            ApplicationID = rResult.statusCode,
                            CreatedDateOnly = DateTime.Now,
                        };
                        rResult = await approvalNotificationRepository.SaveApprovalNotification(notification);

                        // await SendMachineMaintenanceNotificationEmail(firstApprover.ApproverEmployeeID.Value, machineInfo.MachineName, schedule.ScheduleDate.ToString("dd-MMM-yyyy"), model.CheckDate.ToString("dd-MMM-yyyy"));
                        if (_env.IsDevelopment() == false)
                        {
                            BackgroundJob.Enqueue(() => SendMachineMaintenanceNotificationEmail(firstApprover.ApproverEmployeeID.Value, machineInfo.MachineName, schedule.ScheduleDate.ToString("dd-MMM-yyyy"), model.CheckDate.ToString("dd-MMM-yyyy")));
                        }

                    }

                }
                else
                {
                    rResult.message = "Checking Item Already Issue in This Date Please Edit This Item";
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


            return rResult;
        }

        public async Task<RResult> MachineMaintenceCheckListUpdate(CheckListMasterDTM model, bool saveChanges = true)
        {
            return await mT_MachineAndMaintenanceCheckListMasterRepository.MachineMaintenceCheckListUpdate(model, saveChanges);
        }

        public async Task SendMachineMaintenanceNotificationEmail(int EmployeeID, string MachineName, string ScheduleDate, string CheckDate)
        {
            var empShortInfo = await _vw_ERP_EmpShortInfoRepository.Get_ERP_EmpShortInfo(null, EmployeeID);
            if (!string.IsNullOrEmpty(empShortInfo.Office_Email))
            {
                List<string> email = new List<string>();
                email.Add(empShortInfo.Office_Email);
                string subject = $"\"{MachineName}\" Machine Maintenance Check List Schedule Date : {ScheduleDate} & Check Date : {CheckDate}";
                StringBuilder sbContent = new StringBuilder();

                sbContent.Append($"<b>Mr. {empShortInfo.EmployeeName}</b>");
                sbContent.Append("<br/>");
                sbContent.AppendLine($"You have a Machine Mainteance approval notification for the <b>\"{MachineName}\" schedule date:{ScheduleDate} & check date :{CheckDate}</b>");
                sbContent.Append("<br/>");
                sbContent.Append("<br/>");
                sbContent.Append($"Please check  <a href=\"{StaticConfigs.GetConfig("ProjectLiveURL")}\"><b> Robintex ERP </b></a> ");
                sbContent.Append("<br/>");
                sbContent.Append("<br/>");
                sbContent.Append("For any difficulty please contact with <b>Robintex IT Department.</b>");
                sbContent.Append("<br/>");
                sbContent.AppendLine("<em><b>Thanks</b></em>");

                var emailMessage = new EmailMessageAttachment(subject, sbContent.ToString(), email);
                await _emailSenderService.SendEmailAsync(emailMessage);
            }
        }
        public async Task<List<MachineMaintenanceNotificationDetailRM>> GetMachineAndMaintenanceCheckListDetail(int masterID, CancellationToken cancellationToken)
        {
            return await mT_MachineAndMaintenanceCheckListMasterRepository.GetMachineAndMaintenanceCheckListDetail(masterID, cancellationToken);
        }

        public async Task GenerateMonthlyMaintenanceSchedule()
        {
            await mT_MachineAndMaintenanceCheckListMasterRepository.GenerateMonthlyMaintenanceSchedule();
        }
    }
}
