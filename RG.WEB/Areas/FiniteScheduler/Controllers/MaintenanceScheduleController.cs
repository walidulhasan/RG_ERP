using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MaintenanceSchedule_Setups.Commands.Create;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MaintenanceSchedule_Setups.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MaintenanceSchedule_Setups.Queries;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MaintenanceSchedule_Setups.Queries.DataResponseModel;
using RG.Application.ViewModel.FiniteScheduler.Setup.MaintenanceSchedule;
using RG.WEB.Controllers;

namespace RG.WEB.Areas.FiniteScheduler.Controllers
{
    [Area("FiniteScheduler")]
    [Route("FiniteScheduler/[controller]/[action]")]
    public class MaintenanceScheduleController : BaseController
    {
        private readonly IDropdownService _dropdownService;
        private readonly ILogger<MaintenanceScheduleController> _logger;

        public MaintenanceScheduleController(IDropdownService dropdownService,ILogger<MaintenanceScheduleController> logger)
        {
            _dropdownService = dropdownService;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GenerateFromExcel()
        {
            var model = new GenerateFromExcelVM();
            var toYear = DateTime.Now.Year;
            model.DDLMonths = Enumerable.Range(1, 12).Select(i => new SelectListItem() { Value = i.ToString(), Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(i) }).ToList();
            if (DateTime.Now.Month > 11)
            {
                toYear = DateTime.Now.Year + 1;
            }
            model.DDLYears = _dropdownService.NumberDDL(DateTime.Now.Year, DateTime.Now.Year, false,DateTime.Now.Year).OrderByDescending(x => x.Value).ToList();
            model.MonthID = DateTime.Now.Month;

            return View(model);
        }


        #region Ajax
        public async Task<JsonResult> ValidateMachineSchedule(string ScheduleExcelData)
        {
            RResult _result = new RResult();
            try
            {
                List<ValidateMachineScheduleRM> rData = new List<ValidateMachineScheduleRM>();
                if(string.IsNullOrEmpty(ScheduleExcelData)==false && ScheduleExcelData.Length > 0)
                {
                    StringBuilder machineXml = new StringBuilder();
                    machineXml.Append("<machineXml>"); 
                    foreach (var row in ScheduleExcelData.Split("\n"))
                    {
                        var rRows = new ValidateMachineScheduleRM();
                        if (!string.IsNullOrEmpty(row))
                        {
                           
                            string MachineName = string.Empty;
                            string status = string.Empty;
                            DateTime scheduleDate;
                            var column = row.Split("\t");
                            var excelscheduleDate = column[1].ToString();
                            string[] dateFromate = { "dd-MM-yyyy", "dd-MMM-yyyy", "d-MM-yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "dd/MMM/yyyy"
                            , "dd-MM-yy", "dd-MMM-yy", "d-MM-yy", "MM-dd-yy", "MM/dd/yy", "dd/MMM/yy"};
                           var dateConverted = DateTime.TryParseExact(excelscheduleDate, dateFromate, CultureInfo.InvariantCulture, DateTimeStyles.None, out scheduleDate);

                            if (dateConverted==false)// excelscheduleDate, out scheduleDate))
                            {
                                status = $"{column[0].ToString()} is not valid schedule Data = {excelscheduleDate}";
                            }
                            MachineName = column[0].ToString();
                            machineXml.Append($"<Schedules MachineName=\"{MachineName}\" ScheduleDate=\"{scheduleDate.ToString("dd-MMM-yyyy")}\" Status=\"{status}\" ></Schedules>");

                        }
                    }
    
                    machineXml.Append("</machineXml>");
                    _logger.LogInformation(machineXml.ToString());
                    var data = await Mediator.Send(new ValidateMachineScheduleQuery() {Data=machineXml.ToString() });
                    _result.result = 1;
                    _result.data = data.dataList;
                }
                else
                {
                    _result.result = 0;
                    _result.message = "No Data found";
                }
            }
            catch(Exception e)
            {
                _result.result = 0;
                _result.message = "Data is Valid";
            }
            return Json(_result);
        }

        public  async Task<JsonResult> SaveSchedule(List<CreateMT_MaintenanceSchedule_SetupDTM> model)
        {
            var ss = await Mediator.Send(new CreateMT_MaintenanceSchedule_SetupCommand() { MT_MaintenanceSchedule_Setup = model });
            return Json(ss);
        }
            

        #endregion
    }
}
