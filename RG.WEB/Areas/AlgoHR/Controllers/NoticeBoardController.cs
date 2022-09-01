using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.DevExtremeModelBinds;
using RG.Application.Contracts.AlgoHR.Setups.SystemNotices.Commands.Create;
using RG.Application.Contracts.AlgoHR.Setups.SystemNotices.Commands.DataTransferModel;
using RG.Application.Contracts.AlgoHR.Setups.SystemNotices.Commands.Update;
using RG.Application.Contracts.AlgoHR.Setups.SystemNotices.Queries;
using RG.Application.Contracts.Embro.CompanyInfos.Queries;
using RG.Application.ViewModel.AlgoHR.Setup.SystemNotice;
using RG.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.Areas.AlgoHR.Controllers
{
    [Area("AlgoHR")]
    [Route("AlgoHR/[controller]/[action]")]
    public class NoticeBoardController : BaseController
    {
        private readonly IDropdownService _dropdownService;

        public NoticeBoardController(IDropdownService dropdownService)
        {
            _dropdownService = dropdownService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            var model = new SystemNoticeVM() { };
            return View(model);
        }
        [HttpPost]
        public async Task<JsonResult> Create(SystemNoticeDTM notice)
        {
            var data = await Mediator.Send(new SystemNoticeCreateCommand { SystemNotice = notice });
            return Json(data);
        }

        public async Task<IActionResult>Edit(int noticeID)
        {
            var model = new SystemNoticeVM() { };
            var modelRM= await Mediator.Send(new GetSystemNoticeQuery { NoticeID=noticeID});
            model.NoticeID = modelRM.NoticeID;
            model.NoticeTitle = modelRM.NoticeTitle;
            model.NoticeDescription = modelRM.NoticeDescription;
            model.ValidDateFrom = modelRM.ValidDateFrom.ToString("dd-MMM-yyyy");
            model.ValidTimeFrom = modelRM.ValidDateFrom.ToString("hh:mm tt");
            model.ValidDateTo = modelRM.ValidDateTo.ToString("dd-MMM-yyyy");
            model.ValidTimeTo = modelRM.ValidDateTo.ToString("hh:mm tt");
            model.ShowDetail = modelRM.ShowDetail;
            foreach (var item in modelRM.CustomCasting)
            {
                model.CustomCusting.Add(new SystemNoticeCustomCustingVM
                {
                    CustingID=item.CustingID,
                    NoticeID=item.NoticeID,
                    CompanyID=item.CompanyID,
                    DivisionID=item.DivisionID,
                    DepartmentID=item.DepartmentID,
                    SectionID=item.SectionID
                });
            }
            return View("Create", model);
        }
        public async Task<JsonResult> Remove(int noticeID)
        {
            var data = await Mediator.Send(new SystemNoticeRemoveCommand { NoticeID = noticeID });
            return Json(data);
        }
        public async Task<JsonResult> GetDDLCompany()
        {
            var data = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLCompanyInfoQuery()), true);
            return Json(data);
        }
        public async Task<JsonResult> GetNoticeList(DataSourceLoadOptions loadOptions)
        {
            loadOptions.PrimaryKey = new[] { "NoticeID" };
            loadOptions.PaginateViaPrimaryKey = true;
            var data = await Mediator.Send(new GetNoticeListQuery { LoadOptions = loadOptions });
            return Json(data);
        }
        



    }
}
