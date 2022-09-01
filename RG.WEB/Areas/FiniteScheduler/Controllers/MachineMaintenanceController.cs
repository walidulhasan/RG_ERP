using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.Models;
using RG.Application.Constants;
using RG.Application.Contracts.Embro.CompanyInfos.Queries;
using RG.Application.Contracts.FiniteScheduler.Business.MT_MachineAndMaintenanceCheckListMasters.Commands.Create;
using RG.Application.Contracts.FiniteScheduler.Business.MT_MachineAndMaintenanceCheckListMasters.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Business.MT_MachineAndMaintenanceCheckListMasters.Commands.Update;
using RG.Application.Contracts.FiniteScheduler.Business.MT_MachineAndMaintenanceCheckListMasters.Queries;
using RG.Application.Contracts.FiniteScheduler.Business.MT_MachineAndMaintenanceCheckListMasters.Queries.RequestResponseModel;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MachineAndMaintenanceItemAssociations.Queries;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MaintenanceSchedule_Setups.Queries;
using RG.Application.Enums;
using RG.Application.ViewModel.FiniteScheduler.Business.MachineMaintenance;
using RG.WEB.Controllers;
using SSRSReport.Library;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.Areas.FiniteScheduler.Controllers
{
    [Area("FiniteScheduler")]
    [Route("FiniteScheduler/[controller]/[action]")]
    public class MachineMaintenanceController : BaseController
    {
        private readonly IDropdownService dropdownService;

        public MachineMaintenanceController(IDropdownService _dropdownService)
        {
            dropdownService = _dropdownService;
        }
        #region Actions
        public async Task<IActionResult> Index()
        {
            DateTime dateCondition = DateTime.Now;
            DateTime firstDate = dateCondition.AddDays(-7).Month == dateCondition.Month ? dateCondition.AddDays(-3) : new DateTime(dateCondition.Year, dateCondition.Month, 1);
            MachineMaintenanceIndexVM model = new()
            {
                DateFrom = firstDate.ToString("dd-MMM-yyyy"),
                DateTo = DateTime.Now.ToString("dd-MMM-yyyy"),
                DDLCompany = dropdownService.RenderDDL(await Mediator.Send(new GetDDLCompanyInfoQuery()), true),
                DDLLocation = dropdownService.DefaultDDL(),
                DDLMachine = dropdownService.DefaultDDL()
            };

            return View(model);
        }
        public async Task<IActionResult> Create()
        {
            MachineMaintenanceCheckVM model = new()
            {
                DDLCompany = dropdownService.RenderDDL(await Mediator.Send(new GetDDLCompanyInfoQuery()), true),
                DDLLocation = dropdownService.DefaultDDL(),
                DDLMachine = dropdownService.DefaultDDL(),
                DDLScheduleDates = dropdownService.DefaultDDL()
            };
            return View(model);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var data = await Mediator.Send(new GetMachineAndMaintenanceCheckListMasterQuery { ID = id });

            MachineMaintenanceCheckVM model = new()
            {
                MasterID = data.MasterID,
                CompanyID = data.CompanyID,
                LocationID = data.LocationID,
                MachineID = data.MachineID,
                ScheduleDate = data.ScheduleDate.ToString("dd-MMM-yyyy"),
                CheckDate = data.CheckDate.Value.ToString("dd-MMM-yyyy"),
                //NextPreventativeDate = data.NextPreventativeDate,
                MechanicalTaskTeamMember = data.MechanicalTaskTeamMember,
                MechanicalSupervisor = data.MechanicalSupervisor,
                MechanicalWorkerComments = data.MechanicalWorkerComments,
                ElectricalTaskTeamMember = data.ElectricalTaskTeamMember,
                ElectricalSupervisor = data.ElectricalSupervisor,
                ElectricalWorkerComments = data.ElectricalWorkerComments,
                DDLCompany = dropdownService.RenderDDL(await Mediator.Send(new GetDDLCompanyInfoQuery()), true),
                DDLLocation = dropdownService.DefaultDDL(),
                DDLMachine = dropdownService.DefaultDDL()
            };
            return View("Create", model);
        }
        [AllowAnonymous]
        public async Task<IActionResult> MonthlyMachineMaintaince()
        {
            var model = new MonthlyMachineMaintainceVM
            {
                DDLCompany = dropdownService.RenderDDL(await Mediator.Send(new GetDDLCompanyInfoQuery()), true),
                DDLMonth = Enumerable.Range(1, 12).Select(i => new SelectListItem() { Value = i.ToString(), Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(i) }).ToList(),
                DDLYear = dropdownService.NumberDDL(DateTime.Now.Year - 1, DateTime.Now.Year, false, DateTime.Now.Year).OrderByDescending(x => x.Value).ToList(),
                DDLLocation = dropdownService.DefaultDDL(),
                MonthID = DateTime.Now.Month,
                YearID = DateTime.Now.Year
            };
            return View(model);
        }
        public async Task<IActionResult> MonthlyMachineMaintainceItems()
        {
            var model = new MonthlyMachineMaintainceItemsVM
            {
                DDLCompany = dropdownService.RenderDDL(await Mediator.Send(new GetDDLCompanyInfoQuery()), true),
                DDLMonth = Enumerable.Range(1, 12).Select(i => new SelectListItem() { Value = i.ToString(), Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(i) }).ToList(),
                DDLYear = dropdownService.NumberDDL(DateTime.Now.Year - 1, DateTime.Now.Year, false, DateTime.Now.Year).OrderByDescending(x => x.Value).ToList(),
                DDLLocation = dropdownService.DefaultDDL(),
                DDLMachine= dropdownService.DefaultDDL(),
                MonthID = DateTime.Now.Month,
                YearID = DateTime.Now.Year
            };
            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> MachineMaintainceItemDetail(int LocationID, int MachineID, int Month, int Year)
        {
            var returnData = new List<MonthlyMachineMaintainceItemsVCVM>();
            var data = await Mediator.Send(new GetMachineMaintainceItemDetailInfoQuery { LocationID = LocationID, MachineID = MachineID, Month = Month, Year = Year });

            var machineGroups = data.Select(x => new
            {
                x.MachineGroupID,
                x.MachineGroup
            }).Distinct().ToList();

            foreach (var machineGroup in machineGroups)
            {
                var grpWiseDataList = new List<GroupWiseMonthlyMachineMaintainceItemsVM>();
                var locationWiseMachines = data.Where(x => x.MachineGroupID == machineGroup.MachineGroupID).Select(x => new
                {
                    x.LocationID,
                    x.LocationName,
                    x.MachineID,
                    x.MachineName
                }).Distinct().ToList();                

                foreach (var itemLocationMachine in locationWiseMachines)
                {


                    var rtnChkDates = data.Where(x => x.MachineID == itemLocationMachine.MachineID)
                        .GroupBy(y => new { y.CheckDate, y.ScheduleDate, y.CheckDayDifference })
                        .Select(r => new MonthlyMachineMaintainceCheckDates
                        {
                            CheckDate = r.Key.CheckDate,
                            ScheduleDate = r.Key.ScheduleDate,
                            CheckDayDifference = r.Key.CheckDayDifference
                        }).ToList();

                    var missedScheduleDates = rtnChkDates.Where(x => x.CheckDate == null && x.ScheduleDate.Value.Date < DateTime.Now.Date).ToList();

                    var nextImmediateScheduleDates = rtnChkDates.Where(x => x.CheckDate == null && x.ScheduleDate.Value.Date >= DateTime.Now.Date).FirstOrDefault();
                    if(nextImmediateScheduleDates!=null)
                    missedScheduleDates.Add(nextImmediateScheduleDates);

                    if (missedScheduleDates.Count == 0 && nextImmediateScheduleDates == null)
                    {
                        var chekedScheduleDates = rtnChkDates.Where(x => x.CheckDate != null && x.ScheduleDate.Value.Date < DateTime.Now.Date).OrderByDescending(x=>x.ScheduleDate).FirstOrDefault();
                        missedScheduleDates.Add(chekedScheduleDates);
                    }

                    foreach (var dates in missedScheduleDates)
                    {
                        var rtnItems = data.Where(x =>  x.MachineID == itemLocationMachine.MachineID
                                                     && x.ScheduleDate == dates.ScheduleDate)
                            .Select(r => new CheckDateWiseItems
                            {
                                ItemName = r.ItemName,
                                SerialNo = r.SerialNo,
                                MechanicalChecked = r.MechanicalChecked,
                                ElectricalChecked = r.ElectricalChecked,
                                MechanicalComments = r.MechanicalComments,
                                ElectricalComments = r.ElectricalComments,
                                MechanicalTaskCompletedBy = r.MechanicalTaskCompletedBy,
                                ElectricalTaskCompletedBy = r.ElectricalTaskCompletedBy,
                                MechanicalTaskSupervisor = r.MechanicalTaskSupervisor,
                                ElectricalTaskSupervisor = r.ElectricalTaskSupervisor
                            }).Distinct().OrderBy(y => y.SerialNo).ToList();

                        dates.CheckDateWiseItems = rtnItems;
                    }

                    var rtnGrpWiseData = new GroupWiseMonthlyMachineMaintainceItemsVM()
                    {
                        LocationID = itemLocationMachine.LocationID,
                        LocationName = itemLocationMachine.LocationName,
                        MachineID = itemLocationMachine.MachineID,
                        MachineName = itemLocationMachine.MachineName,

                        MonthlyMachineMaintainceCheckDates = missedScheduleDates.OrderBy(x=>x.ScheduleDate).ToList()
                    };
                    grpWiseDataList.Add(rtnGrpWiseData);
                }
                var MonthName = new DateTime(Year, Month, 1).ToString("MMMM");
                var rtnData = new MonthlyMachineMaintainceItemsVCVM()
                {
                    MachineGroupID = machineGroup.MachineGroupID,
                    MachineGroup = machineGroup.MachineGroup,
                    ReportHeader = $"Machine Maintenance Status For The Month {MonthName}, {Year} ",                    
                    GroupWiseMonthlyMachineMaintainceItems = grpWiseDataList
                };

                returnData.Add(rtnData);
            }
            return View(returnData);
        }
        public ActionResult CallViewComponents(string viewComponentName, MachineMaintainceItemDetailQM queryModel)
        {
            return ViewComponent(viewComponentName, queryModel);
        }
        #endregion

        #region Json Functions
        public async Task<JsonResult> GetMachineAndMaintenanceCheckList(int? machineID, DateTime dateFrom, DateTime dateTo)
        {
            var data = await Mediator.Send(new GetMachineAndMaintenanceCheckListQuery { MachineID = machineID, DateFrom = dateFrom, DateTo = dateTo });
            return Json(data);
        }
        [HttpPost]
        public async Task<JsonResult> Create(CheckListMasterDTM model)
        {
            var data = new RResult();
            if (model.MasterID > 0)
            {
                data = await Mediator.Send(new MachineAndMaintenanceCheckListMastersUpdateCommand { CheckListMaster = model });
            }
            else
            {
                data = await Mediator.Send(new MachineAndMaintenanceCheckListMastersCreateCommand { CheckListMaster = model });
            }
            return Json(data);
        }
        public async Task<JsonResult> GetMachineWiseMaintenanceItemDetail(int machineID, int masterID)
        {
            var data = await Mediator.Send(new GetMachineWiseMaintenanceItemDetailListQuery { MachineID = machineID, MasterID = masterID });
            return Json(data);
        }
        public async Task<JsonResult> GetMonthlyMachineMaintainceReport(int locationID, int month, int year)
        {
            var data = await Mediator.Send(new GetMonthlyMachineMaintainceReportQuery() { LocationID = locationID, Month = month, YearID = year });
            return Json(data);
        }
        #endregion


        #region Report

        public async Task<IActionResult> MonthlyMachineMaintainceReport(int locationID, int Month, int Year, string ReportFormat)
        {
            var report = new CallSSRSReport();
            string reportName = $"/{ReportFolder.FiniteSchedulerFolder}/LocationMonthlyScheduleMaintence";

            IDictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("LocationID", locationID);
            parameters.Add("Month", Month);
            parameters.Add("Year", Year);
            var connectionString = (int)enum_ServerType.FiniteSchedulerConnection;
            return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);

        }
        public async Task<IActionResult> MachineAndMaintenanceCheckReport(int id, string ReportFormat)
        {            
            string reportName = $"/{ReportFolder.FiniteSchedulerFolder}/MachineAndMaintenanceCheckReport";

            IDictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("MasterID", id);
            var connectionString = (int)enum_ServerType.FiniteSchedulerConnection;


            return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);

        }
        [AllowAnonymous]
        public async Task<JsonResult> GetMachineMaintenanceSchedule(int machineID)
        {
            var data = await Mediator.Send(new GetMachineMaintenanceScheduleQuery { MachineID = machineID });
            return Json(data);
        }
        #endregion


    }
}
