
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RG.Application.Contracts.MaterialsManagement.Business.YarnStockReport.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.ViewComponents
{
    public class YarnStockReportViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            return View("YarnStockReportVC");
        }
    }
}
