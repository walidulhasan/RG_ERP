using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.Embro.Setups.SupplierSetups.Queries;
using RG.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.Areas.Embro.Controllers
{
    [Area("Embro")]
    [Route("Embro/[controller]/[action]")]
    public class SupplierSetupController : BaseController
    {
        private readonly IDropdownService _dropdownService;
        private readonly ICurrentUserService _currentUserService;
        public SupplierSetupController(IDropdownService dropdownService, ICurrentUserService currentUserService)
        {
            _dropdownService = dropdownService;
            _currentUserService = currentUserService;
        }
        public IActionResult Index()
        {
            return View();
        }



        #region Json DropDown 
        public async Task<JsonResult> DDLSupplier(int CompanyID = 0, List<int> AccCategoryID = null, List<int> NotInSupplier = null, string predict = null)
        {
            if (CompanyID == 0)
            {
                CompanyID = _currentUserService.CompanyID;
            }
            var data = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLSupplierQuery
            {
                CompanyID = CompanyID,
                AccCategoryID = AccCategoryID,
                NotInSupplier = NotInSupplier,
                Predict = predict
            }), true);
            return Json(data);

        }
        public async Task<JsonResult> DDLSuppliers(int CompanyID = 0, List<int> AccCategoryID = null, List<int> NotInSupplier = null, string predict = null)
        {
            if (CompanyID == 0)
            {
                CompanyID = _currentUserService.CompanyID;
            }
            var data = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLSuppliersQuery
            {
                CompanyID = CompanyID,
                AccCategoryID = AccCategoryID,
                NotInSupplier = NotInSupplier,
                Predict = predict
            }), true);
            return Json(data);

        }
        #endregion
    }
}
