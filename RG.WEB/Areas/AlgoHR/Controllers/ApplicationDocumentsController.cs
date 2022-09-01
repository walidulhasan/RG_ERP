using Microsoft.AspNetCore.Mvc;
using RG.Application.Contracts.AlgoHR.Business.ApplicationDocumentss.Queries;
using RG.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.Areas.AlgoHR.Controllers
{
    [Area("AlgoHR")]
    [Route("AlgoHR/[controller]/[action]")]
    public class ApplicationDocumentsController : BaseController
    {

        public async Task<JsonResult> GetApplicationDocuments(int applicationID)
        {
            var data = await Mediator.Send(new GetApplicationDocumentsQuery { ApplicationID = applicationID });
            return Json(data);
        }
    }
}
