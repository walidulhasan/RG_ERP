using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RG.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.Areas.MDSir.Controllers
{
    [Area("MDSir")]
    [Route("MDSir/[controller]/[action]")]
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
