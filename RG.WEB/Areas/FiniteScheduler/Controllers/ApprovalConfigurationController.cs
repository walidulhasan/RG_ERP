using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.Tbl_Emp.Query;
using RG.Application.Contracts.AlgoHR.Setups.ApprovalConfigMasters.Commands.Create;
using RG.Application.Contracts.AlgoHR.Setups.ApprovalConfigMasters.Commands.DataTransferModel;
using RG.Application.Contracts.AlgoHR.Setups.ApprovalConfigMasters.Commands.Update;
using RG.Application.Contracts.AlgoHR.Setups.ApprovalConfigMasters.Queries;
using RG.Application.Contracts.AlgoHR.Setups.ApprovalConfigMasters.Queries.RequestResponseModel;
using RG.Application.Contracts.AlgoHR.Setups.ApprovalModule.Queries;
using RG.Application.Contracts.Embro.CompanyInfos.Queries;
using RG.Application.ViewModel.FiniteScheduler.Setup.ApprovalConfiguration;
using RG.WEB.Controllers;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.Areas.FiniteScheduler.Controllers
{
    [Area("FiniteScheduler")]
    [Route("FiniteScheduler/[controller]/[action]")]
    public class ApprovalConfigurationController : BaseController
    {
        private readonly IDropdownService _dropdownService;
        public ApprovalConfigurationController(IDropdownService dropdownService)
        {
            _dropdownService = dropdownService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new ApprovalConfigMasterVM();
            model.DDLCompanyList = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLCompanyInfoQuery()), true);
            model.DDLOfficeDivisionList = _dropdownService.DefaultDDL();
            model.DDLDepartmentList = _dropdownService.DefaultDDL();
            model.DDLSectionList = _dropdownService.DefaultDDL();
            model.DDLJobTitleList = _dropdownService.DefaultDDL();            
            model.DDLApprovalModulesList = _dropdownService.RenderCustomDDL(await Mediator.Send(new GetDDLCustomApprovalModuleAllQuery()), true);
            model.DDLApprovalLevelList = _dropdownService.NumberDDL(1, 5, false);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateApprovalConfigMasterDTM model)
        {
            RResult data = new();
            bool dataOk = true;
            var detailApproverCount = model.ApprovalConfigDetail.Count;
            var chkSl = 1;
            foreach (var item in model.ApprovalConfigDetail.OrderBy(x=>x.ApprovalLevel))
            {
                if (item.ApprovalLevel== chkSl)                
                    chkSl += 1;                
                else                
                    dataOk = false;                
            }

            if (dataOk)
            {
                data = await Mediator.Send(new CreateApprovalConfigMasterCommand() { CreateApprovalConfigMasterDTM = model });
                
            }
            else
            {
                data.result = 0;
                data.message = "Please Check Approval Levels Then Try Again";
            }
            return Json(data);
        }
        //[Authorize(Policy = "Permission_FiniteScheduler_ApprovalConfiguration_Update")]
        public async Task<JsonResult> RemoveApprovalConfigMasterByDetail(int masterID, int detailID)
        {
            var data = await Mediator.Send(new RemoveApprovalConfigMasterByDetailCommand() { MasterID = masterID, DetailID = detailID });
            return Json(data);
        }

        [HttpPost]
        //[Authorize(Policy = "Permission_FiniteScheduler_ApprovalConfiguration_GET")]
        public async Task<JsonResult> GetModuleWiseApprovalConfigDetail(ModuleWiseApprovalConfigQM queryModel)
        {
            var data = await Mediator.Send(new GetModuleWiseApprovalConfigDetailQuery() { QueryModel = queryModel });
            return Json(data);
        }
        public async Task<JsonResult> GetEmployeeShortInfo(int employeeID)
        {
            var empShortInfo = await Mediator.Send(new GetEmpShortInfoByCodeQuery { EmployeeID = employeeID });
            return Json(empShortInfo);
        }
        [HttpPost]
        public async Task<JsonResult> ReplaceApprover(UpdateReplaceApproverDTM model)
        {
            var data = await Mediator.Send(new ReplaceApproverUpdateCommand { ReplaceApprover = model });
            return Json(data);

        }
    }
}
