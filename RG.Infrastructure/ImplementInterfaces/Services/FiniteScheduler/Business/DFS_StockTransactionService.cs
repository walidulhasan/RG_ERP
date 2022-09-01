using Microsoft.Extensions.Logging;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.Models;
using RG.Application.Constants;
using RG.Application.Contracts.FiniteScheduler.Business.DFS_StockTransactions.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Business;
using RG.Application.Interfaces.Repositories.Maxco.Setup;
using RG.Application.Interfaces.Services.FiniteScheduler.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.FiniteScheduler.Business
{
    public class DFS_StockTransactionService : IDFS_StockTransactionService
    {
        private readonly IDFS_StockTransactionRepository _dFS_StockTransactionRepository;
        private readonly IEmailSenderService _emailSenderService;
        private readonly ISchedularReportEmailRepository _schedularReportEmailRepository;
        private readonly ILogger<DFS_StockTransactionService> _logger;
        public DFS_StockTransactionService(IDFS_StockTransactionRepository dFS_StockTransactionRepository, IEmailSenderService emailSenderService
            , ISchedularReportEmailRepository schedularReportEmailRepository, ILogger<DFS_StockTransactionService> logger)
        {
            _dFS_StockTransactionRepository = dFS_StockTransactionRepository;
            _emailSenderService = emailSenderService;
            _schedularReportEmailRepository =schedularReportEmailRepository;
            _logger = logger;
        }
        public async Task GetDailyOrderFabricWastageExceededLot(DateTime? CurrentDate = null)
        {
            var data = await _dFS_StockTransactionRepository.GetDailyOrderFabricWastageExceededLot(CurrentDate);

            if (data.OrderFabrincWithLot.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                string htmlBody = @"<!DOCTYPE html>
                                    <head><meta content=""text/html; charset=utf-8"" http-equiv=""Content-Type"">
                                        <title>Fabric Wastage Exceed Lot</title> 
                                    </head>";
                sb.AppendLine(htmlBody);
                sb.Append(@"<body style='font-size:12px;'><table style='font-family: arial, sans-serif;border-collapse:collapse;font-size:8pt;width: 100%;'>");
              sb.Append(@"<thead style='text-align:center;'><tr>");
                sb.Append("<th style='border:1px solid black;'>SL#</th>");
                sb.Append("<th style='border:1px solid black;' width='8%'>Buyer</th>");
                sb.Append("<th style='border:1px solid black;' width='10%'>Order No</th>");
                sb.Append("<th style='border:1px solid black;'>Type</th>");
                sb.Append("<th style='border:1px solid black;'>Quality</th>");
                sb.Append("<th style='border:1px solid black;' width='15%'>Composition</th>");
                sb.Append("<th style='border:1px solid black;'>Required Finish Fabric</th>");
                sb.Append("<th style='border:1px solid black;background-color:#347C17;color:#FFF;'>Allowed Wastage Percent</th>");
                sb.Append("<th style='border:1px solid black;'>Additional Fabric</th>");
                sb.Append("<th style='border:1px solid black;'>Required Greige</th>");
                sb.Append("<th style='border:1px solid black;'>Total Knitting</th>");
                sb.Append("<th style='border:1px solid black;'>Total Batch</th>");
                sb.Append("<th style='border:1px solid black;'>Total Finished</th>");
                sb.Append("</thead></tr>");
                int fsl = 1;
                foreach (var fab in data.OrderFabrincWithLot)
                {
                    sb.Append("<tr>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{fsl}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{fab.Buyer}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{fab.OrderNo}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{fab.FabricType}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{fab.FabricQuality}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{fab.FabricComposition}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{fab.LastRequiredQty}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;background-color:#347C17;color:#FFF;'>{String.Format("{0:n2}",fab.GWS_PERCENTAGE)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{fab.FabricVersionDiff}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{fab.KRSQuantityWithWastage}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{fab.GreigeQty}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{fab.BatchQty}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{fab.FinishQty}</td>");
                    sb.Append("</tr>");

                    /*Lot*/
                    sb.Append("<tr><td colspan='13' style='border:1px solid Gray;'>");
                    sb.Append("<div><table style='font-family: arial, sans-serif;font-size:8pt;border-collapse: collapse; width:70%;margin:0 auto;'>");

                    /*Lot Header */
                    sb.Append("<thead style='text-align:center;'><tr><td colspan='8'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td></tr><tr style='background-color:#F5F5F5'>");
                    sb.Append("<th width='150px'>&nbsp;</th>");
                    sb.Append("<th style='border:1px solid Gray;'>SL#</th>");
                    sb.Append("<th style='border:1px solid Gray;text-align:center;'>Lot No</th>");
                    sb.Append("<th style='border:1px solid Gray;'>Greige Qty</th>");
                    sb.Append("<th style='border:1px solid Gray;'>Finish Qty</th>");
                    sb.Append("<th style='border:1px solid Gray;'>Wastage Qty</th>");
                    sb.Append("<th style='border:1px solid Gray;'>Wastage %</th>");
                    sb.Append("<th style='border:1px solid Gray;'>Wastage Exceed Qty</th>");
                    sb.Append("<th style='border:1px solid Gray;'>Wastage Exceed %</th>");
                    sb.Append("<th style='border:1px solid Gray;text-align:center;' width='10%;'>Delivery Date</th>");
                    sb.Append("</tr></thead><tbody>");
                    /* End lot Header*/
                  
                    int lsl = 1;
                    foreach (var lot in fab.FabricLot)
                    {
                        decimal lotExceedQty = lot.WastageQty.Value-(lot.GreigeQty*fab.GWS_PERCENTAGE.Value/100);
                        decimal lotExceedPercent = lot.WestagePercent.Value-fab.GWS_PERCENTAGE.Value;
                        string ExceedColor = lotExceedPercent>2? " background-color:#ea0909;color:#fff;" : " background-color:#ff6347;color:#fff;";
                        sb.Append("<tr>");
                        sb.Append("<td width='70px'>&nbsp;</td>");
                        sb.Append($"<td style='border:1px solid Gray;text-align:center;'>{fsl}.{lsl}</td>");
                        sb.Append($"<td style='border:1px solid Gray;text-align:center;' width='15%'>{lot.LotNo}</td>");
                        sb.Append($"<td style='border:1px solid Gray;text-align:right;'>{lot.GreigeQty}</td>");
                        sb.Append($"<td style='border:1px solid Gray;text-align:right;'>{lot.FinishQty}</td>");
                        sb.Append($"<td style='border:1px solid Gray;text-align:right;'>{lot.WastageQty}</td>");
                        sb.Append($"<td style='border:1px solid Gray;text-align:center;'>{String.Format("{0:n2}",lot.WestagePercent)}</td>");
                        sb.Append($"<td style='border:1px solid Gray;text-align:center;{ExceedColor}'>{String.Format("{0:n2}", lotExceedQty)}</td>");
                        sb.Append($"<td style='border:1px solid Gray;text-align:center;{ExceedColor}'>{String.Format("{0:n3}", lotExceedPercent)}</td>");
                        sb.Append($"<td style='border:1px solid Gray;text-align:center;'>{lot.DeliveryDateST}</td>");
                        sb.Append("</tr>");
                        lsl++;
                    }
                    sb.Append("<tr><td colspan='8'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td></tr>");
                    fsl++;
                    sb.Append("<tbody></table>");
                    sb.Append("</div></td></tr>");
                }

                sb.Append("</table><body><html>");

                var rawData = sb.ToString();
                var mailItem = await _schedularReportEmailRepository.GetMailRecipients(Constants_EmailReport.ExcessDyeingPrintingWastage);
                    /*.FindAsync(b=>b.EmailReportKey == Constants_EmailReport.ExcessDyeingPrintingWastage);
                List<string> emailTo = new List<string>();
                List<string> emailCc = new List<string>();
                List<string> emailBcc = new List<string>();
                if (mailItem.EmailTO != null)
                {
                    emailTo = mailItem.EmailTO.Split(',').ToList();
                }
                if (mailItem.EmailCC != null)
                {
                    emailCc = mailItem.EmailCC.Split(',').ToList();
                }
                if (mailItem.EmailBCC != null)
                {
                    emailBcc = mailItem.EmailBCC.Split(',').ToList();
                }*/
                //email.Add("akbar@comptexbd.com");
                //email.Add("jobayershoaib@gmail.com");
                //email.Add("habib@robintexbd.com");
                var reportDate = CurrentDate.HasValue == false ? DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy") : CurrentDate.Value.ToString("dd-MMM-yyyy");
                var emailMessage = new EmailMessageAttachment($"ERP Report For Excess Dyeing/Printing Wastage inspection Date:{reportDate}", rawData, mailItem.Item1, mailItem.Item2,mailItem.Item3);
                try
                {

                    await _emailSenderService.SendEmailAsync(emailMessage);
                    _logger.LogInformation($"Mail Send at {DateTime.Now.ToString("dd MMM yyyy HH:mm:ss")}");
                }
                catch (Exception e)
                {
                    var aa = e.Message;
                    _logger.LogError(e, "GetDailyOrderFabricWastageExceededLot");
                }
            }
        }

        public async Task<RResult> GetFabricQuantityAndPantoneByLotID(long LotID)
        {
            return await _dFS_StockTransactionRepository.GetFabricQuantityAndPantoneByLotID(LotID);
        }
    }
}
