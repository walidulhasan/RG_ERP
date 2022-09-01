using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.AlgoHR.Business.Tbl_Emp.Commands.DataTransferModel;
using RG.Application.Contracts.AlgoHR.Business.Tbl_Emp.Commands.Update;
using RG.Application.Contracts.AlgoHR.Business.Tbl_Emp.Query;
using RG.Application.Contracts.AlgoHR.Setups.ITbl_Religion.Queries;
using RG.Application.Contracts.AlgoHR.Setups.Tbl_Country.Query;
using RG.Application.Contracts.AlgoHR.Setups.Tbl_EmpType.Queries;
using RG.Application.Contracts.Maxco.Setup.Country_Assorment_Setups.Queries;
using RG.Application.ViewModel.AlgoHR.Business.Employee;
using RG.WEB.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RG.WEB.Areas.AlgoHR.Controllers
{
    [Area("AlgoHR")]
    [Route("AlgoHR/[controller]/[action]")]
    public class EmployeeController : BaseController
    {
        private readonly IDropdownService _dropDownService;

        public EmployeeController(IDropdownService dropDownService)
        {
            _dropDownService = dropDownService;
        }

        public async Task<IActionResult> DetailInfo()
        {
            List<SelectListItem> GenderList = new List<SelectListItem>();
            GenderList.Add(new SelectListItem() { Text = "Male", Value = "M" });
            GenderList.Add(new SelectListItem() { Text = "Female", Value = "F" });

            var model = new DetailInfoVM
            {
                DDLReligion = _dropDownService.RenderDDL(await Mediator.Send(new GetDDLReligionQuery()), true),
                DDLEmployeeType = _dropDownService.RenderDDL(await Mediator.Send(new GetDDLTbl_EmpTypeQuery()), true),
                DDLCountryList = _dropDownService.RenderDDL(await Mediator.Send(new DDLGetOnlyCountryListQuery())),
                DDLGender =_dropDownService.RenderDDL(GenderList,true) 
            };
            
            return View(model);
        }
        #region Json
        public async Task<JsonResult> EmployeePersonalInfo(string EmployeeCode)
        {
            var data = await Mediator.Send(new GetEmployeePersonalInfoQuery { EmployeeCode = EmployeeCode });
            return Json(data);
        }
        public async Task<JsonResult> EmployeeAddressInfo(string EmployeeCode)
        {
            var data = await Mediator.Send(new GetEmployeeAddressInfoQuery { EmployeeCode = EmployeeCode });
            return Json(data);
        }
        [HttpPost]
        public async Task<JsonResult> UpdateEmployeePersonalInfo(EmployeePersonalInfoDTM PersonalInfo)
        {
            var data = await Mediator.Send(new EmployeePersonalInfoUpdateCommand { PersonalInfo = PersonalInfo });
            return Json(data);
        }
        [HttpPost]
        public async Task<JsonResult> UpdateEmployeeAddressInfo(EmployeeAddressInfoDTM addressInfo)
        {
            var data = await Mediator.Send(new EmployeeAddressInfoUpdateCommand { employeeAddressInfo = addressInfo });
            return Json(data);
        }


        #endregion
    }
}
