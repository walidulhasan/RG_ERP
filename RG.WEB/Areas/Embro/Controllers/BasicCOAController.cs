using MediatR;
using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.Embro.Setups.BasicCOAs.Queries;
using RG.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.Areas.Embro.Controllers
{
    [Area("Embro")]
    [Route("Embro/[controller]/[action]")]
    public class BasicCOAController :  BaseController
    {
        private readonly IDropdownService _dropdownService;

        public BasicCOAController(IDropdownService dropdownService)
        {
            _dropdownService = dropdownService;
        }


        #region Json
        public async Task<JsonResult> GetDDLBasicCOAByParent(int parentID,int levelID=0 ,string predict=null,bool isDefaultSelect=true)
        {
            
            var data = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLBasicCoaQuery { ParentID = parentID, LevelID=levelID,Predict = predict }), isDefaultSelect);
            return Json(data);
        }
        public async Task<JsonResult> GetDDLChartOfAccountsCategoryQuery(int CompanyID, int LevelID, string Category = null, string Predict = null)
        {
             
            var data = _dropdownService.RenderDDL(await Mediator.Send(new DDLChartOfAccountsCategoryQuery { CompanyID = CompanyID, LevelID = LevelID, Category= Category, Predict = Predict }),true);
            return Json(data);
        }

        public async Task<JsonResult> GetDDLCompanyWiseChartOfAccountsQuery(int ParentID,int LevelID,string Predict=null)
        {
            var data = _dropdownService.RenderDDL(await Mediator.Send(new DDLCompanyWiseChartOfAccountsQuery { ParentID = ParentID, LevelID = LevelID, Predict = Predict }),true);
            return Json(data);
        }
        #endregion Json
    }
}
