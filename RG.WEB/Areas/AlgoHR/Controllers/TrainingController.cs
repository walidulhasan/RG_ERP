using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.DevExtremeModelBinds;
using RG.Application.Common.Models;
using RG.Application.Common.Utilities;
using RG.Application.Contracts.AlgoHR.Business.CalenderEventDetail.Queries;
using RG.Application.Contracts.AlgoHR.Business.CalenderEventDetail.Queries.RequestResponseModel;
using RG.Application.Contracts.AlgoHR.Business.CalenderEventFeedbacks.Commands.Create;
using RG.Application.Contracts.AlgoHR.Business.CalenderEventFeedbacks.Commands.DataTransferModel;
using RG.Application.Contracts.AlgoHR.Business.CalenderEventFeedbacks.Queries;
using RG.Application.Contracts.AlgoHR.Business.CalenderEventMasters.Commands.Create;
using RG.Application.Contracts.AlgoHR.Business.CalenderEventMasters.Commands.DataTransferModel;
using RG.Application.Contracts.AlgoHR.Business.CalenderEventMasters.Commands.Update;
using RG.Application.Contracts.AlgoHR.Business.CalenderEventMasters.Query;
using RG.Application.Contracts.AlgoHR.Business.TrainingCalendars.Queries;
using RG.Application.Contracts.AlgoHR.Business.TrainingDocumentsComment.Commands.Create;
using RG.Application.Contracts.AlgoHR.Business.TrainingDocumentsComment.Commands.DataTransferModel;
using RG.Application.Contracts.AlgoHR.Business.TrainingDocumentsComment.Queries;
using RG.Application.Contracts.AlgoHR.Business.TrainingInfos.Commands.Create;
using RG.Application.Contracts.AlgoHR.Business.TrainingInfos.Commands.DataTransferModel;
using RG.Application.Contracts.AlgoHR.Business.TrainingInfos.Commands.Update;
using RG.Application.Contracts.AlgoHR.Business.TrainingInfos.Queries;
using RG.Application.Contracts.AlgoHR.Business.TrainingTypes.Queries;
using RG.Application.Contracts.AlgoHR.Setups.UploadedDocumentTypes.Queries;
using RG.Application.ViewModel.AlgoHR.Business.Training;
using RG.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RG.WEB.Areas.AlgoHR.Controllers
{
    [Area("AlgoHR")]
    [Route("AlgoHR/[controller]/[action]")]
    public class TrainingController : BaseController
    {
        private readonly IDropdownService _dropdownService;

        public TrainingController(IDropdownService dropdownService)
        {
            _dropdownService = dropdownService;
        }
        public IActionResult Index()
        {



            var Traineefeedback = new List<SelectListItem>()
            {
                new SelectListItem{ Text="Select",Value="" },
                new SelectListItem{ Text="Good",Value="Good" },
                new SelectListItem{ Text="Understand",Value="Understand" },
                new SelectListItem{ Text="Other",Value="Other" },

            };
            var model = new TrainingIndexVM();
            model.DDLTraineefeedback = Traineefeedback;
            return View(model);
        }
        public async Task<IActionResult> UserTraining()
        {
            var Traineefeedback = new List<SelectListItem>()
            {
                new SelectListItem{ Text="Select",Value="" },
                new SelectListItem{ Text="Good",Value="Good" },
                new SelectListItem{ Text="Understand",Value="Understand" },
                new SelectListItem{ Text="Other",Value="Other" },

            };
            var model = new TrainingIndexVM()
            {
                DDLTrainingType = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLTrainingTypeQuery { }), false),
                DDLTraineefeedback = Traineefeedback

            };
            return View(model);
        }
        public async Task<IActionResult> Create(int id)
        {
            var model = new TrainingCreateVM
            {
                ID = id,
                DDLDocumentType = await Mediator.Send(new GetDDLUploadedDocumentTypeQuery { ModuleName = ApprovalModules.HRTraining }),
                DDLFileSerial = _dropdownService.NumberDDL(1, 10, true),
                DDLFileExtension = _dropdownService.RenderDDL(GetDDLFileExtension(), true),
                DDLTrainingType = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLTrainingTypeQuery { }), true)
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(TrainingInfoDTM trainingInfo)
        {
            RResult rResult = new();
            try
            {
                // var files = Request.Form.Files;
                rResult = await Mediator.Send(new TrainingInfoCreateCommand { TrainingInfo = trainingInfo, Files = Request.Form.Files });
            }
            catch (Exception e)
            {
                throw;
            }
            return Json(rResult);
        }

        public async Task<JsonResult> GetAllTrainingInfo(DataSourceLoadOptions loadOptions, int trainingTypeID)
        {
            var _data = await Mediator.Send(new GetAllTrainingInfoQuery { TrainingTypeID = trainingTypeID });
            loadOptions.PrimaryKey = new[] { "ID" };
            loadOptions.PaginateViaPrimaryKey = true;
            var data = DataSourceLoader.Load(_data, loadOptions);
            return Json(data);
        }
        public async Task<JsonResult> GetTrainingDocumentsByTraining(int trainingID)
        {
            var data = await Mediator.Send(new GetTrainingDocumentsByTrainingQuery { TrainingID = trainingID });
            return Json(data);
        }
        public async Task<JsonResult> GetTrainingInfo(int trainingID)
        {
            var data = await Mediator.Send(new GetTrainingInfoQuery { ID = trainingID });
            return Json(data);
        }
        public async Task<JsonResult> DeleteTraining(int id)
        {
            var data = await Mediator.Send(new DeleteTrainingCommand { ID = id });
            return Json(data);
        }
        public async Task<JsonResult> DeleteDocument(int id)
        {
            var data = await Mediator.Send(new DeleteTrainingDocumentCommand { ID = id });
            return Json(data);
        }

        private List<SelectListItem> GetDDLFileExtension()
        {
            var data = new List<SelectListItem>()
            {
                new SelectListItem{ Text="doc",Value="doc" },
                new SelectListItem{ Text="docx",Value="docx" },
                new SelectListItem{ Text="pdf",Value="pdf" },
                new SelectListItem{ Text="mp4",Value="mp4" },
                new SelectListItem{ Text="jpg",Value="jpg" },
                new SelectListItem{ Text="jpeg",Value="jpeg" },
                new SelectListItem{ Text="png",Value="png" },
                new SelectListItem{ Text="pptx",Value="pptx" },
                new SelectListItem{ Text="xls",Value="xls" },
                new SelectListItem{ Text="xlsx",Value="xlsx" },
            };
            return data;
        }

        public async Task<IActionResult> TrainingCalendar()
        {
            var trainingType = new List<SelectListItem>()
            {
                new SelectListItem{ Text="Select",Value="" },
                new SelectListItem{ Text="Online",Value="Online" },
                new SelectListItem{ Text="Offline",Value="Offline" },

            };
            var Traineefeedback = new List<SelectListItem>()
            {
                new SelectListItem{ Text="Select",Value="" },
                new SelectListItem{ Text="Good",Value="Good" },
                new SelectListItem{ Text="Understand",Value="Understand" },
                new SelectListItem{ Text="Other",Value="Other" },

            };
            var model = new TrainingCalendarVM();
            model.YearList = _dropdownService.NumberDDL(DateTime.Now.Year, DateTime.Now.Year + 1, false);
            model.Date = DateTime.Now.ToString("HH:mm");
            model.DDLTrainingTypes = trainingType;
            model.DDLTraineefeedback = Traineefeedback;
            model.DDLTrainingCategory = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLTrainingTypeQuery { }), true);
            return View(model);
        }

        public async Task<IActionResult> GetTrainingCalendarViewComponents(int year)
        {
            var calendar = await Mediator.Send(new GetTrainingCalendarQuery() { Year = year });
            return ViewComponent("TrainingCalendar", calendar);
        }


        [HttpPost]
        public async Task<JsonResult> TrainingCreate(CalenderEventMastersDTM trainingCreate)
        {
            RResult rResult = new RResult();
            rResult = await Mediator.Send(new CalenderEventMasterCreateCommand { dtModel = trainingCreate });
            return Json(rResult);
        }

        [HttpPost]
        public async Task<IActionResult> GetListCalenderEventDetails(DateTime date)
        {
            var data = await Mediator.Send(new GetListCalenderEventDetailsQuery { scheduleDate = date });
            return Json(data);
        }


        public async Task<IActionResult> CalenderEventDetailsRemove(int id)
        {
            var rResult = new RResult();
            rResult = await Mediator.Send(new CalenderEventDetailsRemove { id = id });
            return Json(rResult);
        }

        [HttpPost]
        public async Task<IActionResult> TrainingDocumentsCommentCreate(TrainingDocumentsCommentDTM model)
        {
            var result = await Mediator.Send(new TrainingDocumentsCommentCreateCommand { dtModel = model });
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> CalenderEventFeedbackCreate(CalenderEventFeedbackDTM dtModel)
        {
            var result = await Mediator.Send(new CalenderEventFeedbackCreateCommand { model = dtModel });
            return Json(result);
        }

        public async Task<IActionResult> TrainingSchedule()
        {
            TrainingScheduleVM model = new()
            {
                DDLYear = _dropdownService.NumberDDL(DateTime.Now.AddYears(-1).Year, DateTime.Now.Year, true),
                Year = DateTime.Now.Year,
                DDLMonth = _dropdownService.DDLMonth(DateTime.Now.Month),
                Month = DateTime.Now.Month,
                DDLTrainingCategory = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLTrainingTypeQuery { }), true)
            };
            return View(model);
        }

        [HttpGet]
        public async Task<JsonResult> GetAllCalenderEventDetails(DataSourceLoadOptions loadOptions, int trainingCategoryId, int year, int month)
        {
            GetAllCalenderEventDetailsQM queryModel = new GetAllCalenderEventDetailsQM
            {
                TrainingCategoryID = trainingCategoryId,
                Year = year,
                Month = month
            };
            var _data = await Mediator.Send(new GetAllCalenderEventDetailsQuery { queryModel = queryModel });
            loadOptions.PrimaryKey = new[] { "ID" };
            loadOptions.PaginateViaPrimaryKey = true;
            var data = DataSourceLoader.Load(_data, loadOptions);
            return Json(data);
        }


        [HttpPost]
        public async Task<JsonResult> GetListTraineeFeedbackByEventDetailsid(int id)
        {
            var data = await Mediator.Send(new GetListCalenderEventFeedbackQuery { id = id });
            return Json(data);
        }

        [HttpPost]
        public async Task<JsonResult> TraineeWiseGetFeedbackList(int id)
        {
            var data = await Mediator.Send(new TraineeWiseGetFeedbackListQuery { id = id });
            return Json(data);
        }
        [HttpPost]
        public async Task<JsonResult> GetListTrainingDocumentsCommentsList(int id)
        {
            var data = await Mediator.Send(new GetListTrainingDocumentsCommentsListQuery { id = id });
            return Json(data);
        }
    }
}
