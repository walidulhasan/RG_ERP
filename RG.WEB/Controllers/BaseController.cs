using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using RG.Application.Constants;
using SSRSReport.Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace RG.WEB.Controllers
{
    [Authorize]
    public abstract class BaseController : Controller
    {
        
        private ISender _mediator;
    
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();
         
        #region SSRS Report Call
        [NonAction]
        protected async Task<FileStreamResult> PrintSSRSReport(string reportName, IDictionary<string, object> parameters, string ReportFormat, int ConnectionString)
        {
            try
            {
                string languageCode = "en-us";
                byte[] reportContent = await new CallSSRSReport().RenderReport(reportName, parameters, languageCode, ReportFormat, ConnectionString);
                var ContentType = "";
                Stream stream = new MemoryStream(reportContent);
                if (ReportFormat == ReportExportFormat.ExcelFormat)
                {
                    ContentType = "application/vnd.ms-excel";

                }
                else if (ReportFormat == ReportExportFormat.PdfFormat)
                {
                    ContentType = "application/pdf";
                }
                return new FileStreamResult(stream, ContentType);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion
    }
}
