using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.MaterialsManagement.Setups.YarnSubRackSetup.Queries;
using RG.WEB.Controllers;
using System.Threading.Tasks;

namespace RG.WEB.Areas.MaterialsManagement.Controllers
{
    [Area("MaterialsManagement")]
    [Route("MaterialsManagement/[controller]/[action]")]
    public class YarnSubRackController : BaseController
    {
        private readonly IDropdownService _dropdownService;

        public YarnSubRackController(IDropdownService dropdownService)
        {
            _dropdownService = dropdownService;
        }
       
        public IActionResult Index()
        {
            return View();
        }
        public async Task<JsonResult> GetDDLRackWiseSubRack(int rackID,bool withStorageLimit=false)
        {
            var data = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLRackWiseSubRackQuery { RackID = rackID,WithStorageLimit= withStorageLimit }),true);
            return Json(data);
        }
        public async Task<JsonResult> GetCustomDDLRackWiseSubRack(int rackID, bool withStorageLimit = false)
        {
            var data = _dropdownService.RenderCustomDDL(await Mediator.Send(new GetCustomDDLRackWiseSubRackQuery { RackID = rackID, WithStorageLimit = withStorageLimit }), true);
            return Json(data);
        }
        
    }
}
