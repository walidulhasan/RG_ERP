using Microsoft.Extensions.Logging;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.Models;
using RG.Application.Constants;
using RG.Application.Contracts.Maxco.Buisness.DailyMail.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.Embro.Business;
using RG.Application.Interfaces.Repositories.EMS.Business;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Business;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Business;
using RG.Application.Interfaces.Repositories.Maxco.Business;
using RG.Application.Interfaces.Repositories.Maxco.Setup;
using RG.Application.Interfaces.Services.Maxco.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.Maxco.Business
{
    public class DailyMailService : IDailyMailService
    {
        private readonly IDailyMailFiniteSchedulerRepository _dailyMailFiniteSchedulerRepository;
        private readonly IDailyMailMaterialManagementRepository _dailyMailMaterialManagementRepository;
        private readonly ISchedularReportEmailRepository _schedularReportEmailRepository;
        private readonly ILogger<DailyMailService> _logger;
        private readonly IEmailSenderService _emailSenderService;
        private readonly IDailyMailEMSRepository _dailyMailEMSRepository;
        private readonly IDailyMailEmbroRepository _dailyMailEmbroRepository;
        private readonly IDailyMailMaxcoRepository _dailyMailMaxcoRepository;

        public DailyMailService(IDailyMailFiniteSchedulerRepository dailyMailFiniteSchedulerRepository
            , IDailyMailMaterialManagementRepository dailyMailMaterialManagementRepository
            , ISchedularReportEmailRepository schedularReportEmailRepository
            , ILogger<DailyMailService> logger
            , IEmailSenderService emailSenderService
            , IDailyMailEMSRepository dailyMailEMSRepository
            , IDailyMailEmbroRepository dailyMailEmbroRepository
            ,IDailyMailMaxcoRepository dailyMailMaxcoRepository)
        {
            _dailyMailFiniteSchedulerRepository = dailyMailFiniteSchedulerRepository;
            _dailyMailMaterialManagementRepository = dailyMailMaterialManagementRepository;
            _schedularReportEmailRepository = schedularReportEmailRepository;
            _logger = logger;
            _emailSenderService = emailSenderService;
            _dailyMailEMSRepository = dailyMailEMSRepository;
            _dailyMailEmbroRepository = dailyMailEmbroRepository;
            _dailyMailMaxcoRepository = dailyMailMaxcoRepository;
        }

        public async Task BTB_Cash_LC_OverdueMaturityNotification()
        {
            var btbOverDue = await _dailyMailEMSRepository.BTB_Cash_LC_OverdueMaturityNotification();

            var ReportDateMsg = DateTime.Now.ToString("dd-MMM-yyyy");

            StringBuilder sb = new StringBuilder();
            string htmlBody = @$"<!DOCTYPE html>
                                    <head><meta content=""text/html; charset=utf-8"" http-equiv=""Content-Type"">
                                        <title>  BTB/Cash LC Overdue Maturity Notification. </title> 
                                    </head>";
            sb.AppendLine(htmlBody);
            sb.Append(@"<body style='font-size:13px;'>");
            sb.Append(@"<h2 style='text-align:center;padding-bottom:1px;margin-bottom:0px;'>BTB/Cash LC Overdue Maturity Notification</h2>");
            sb.Append($@"<h3 style='text-align:center;padding-top:1px;padding-bottom:1px;margin-bottom:0px;;margin-top:1px;'>Robintex Group</h3>");
            sb.Append(@$"<h4 style='text-align:center;padding-top:1px;padding-bottom:1px;margin-bottom:0px;;margin-top:1px;'>Date From:{ReportDateMsg}</h4>");

            if (btbOverDue.Count > 0)
            {

                sb.Append(@"<table style='font-family: arial, sans-serif;border-collapse:collapse;font-size:9pt;width: 100%;'>");
                sb.Append(@"<thead style='text-align:center;'>");
                sb.Append("<tr>");
                sb.Append("<th style='border:1px solid black;' width='3%'>SL#</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Voucher SL</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Company</ th>");
                sb.Append("<th style='border:1px solid black;' width=''>Supplier </th>");
                sb.Append("<th style='border:1px solid black;' width=''>LC Type</th>");
                sb.Append("<th style='border:1px solid black;' width=''>LC Number</th>"); 
                sb.Append("<th style='border:1px solid black;' width=''>Exceed<br/>Days</th>"); 
                sb.Append("<th style='border:1px solid black;' width=''>Bank Name</th>");
                sb.Append("<th style='border:1px solid black;' width=''>LC Date</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Acceptance<br/>Date</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Bank<br/>Date</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Maturity<br/>Date</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Master<br/>LC</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Cur.</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Value<br/>FC</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Value<br/>BDT</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Remarks</th>");
                sb.Append("</thead></tr>");
                int fsl = 1;
                string overDuestyle = "";
                foreach (var cbl in btbOverDue)
                {
                    if (cbl.ExceedDays >= 99)
                    {
                        overDuestyle = "background-color:#e60000;color:#fff";
                    }
                    else if (cbl.ExceedDays > 74)
                    {
                        overDuestyle = "background-color:#ff4d4d;color:#111";
                    }
                    else if (cbl.ExceedDays > 49)
                    {
                        overDuestyle = "background-color:#ff8080;color:#111";
                    }
                    else if (cbl.ExceedDays > 15)
                    {
                        overDuestyle = "background-color:#ff9999;color:#111";
                    }
                    else if (cbl.ExceedDays > 5)
                    {
                        overDuestyle = "background-color:#ffcccc;color:#111";
                    }
                    else
                    {
                        overDuestyle = "";
                    }
                    sb.Append("<tr>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{fsl}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{cbl.Voucherid}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{cbl.CompanyShortName}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{cbl.Supplier}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{cbl.LCType}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{cbl.LCNumber}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;{overDuestyle}'>{cbl.ExceedDays}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{cbl.BankName}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{cbl.LCDate}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{cbl.AcceptanceDate}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{cbl.BankDate}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{cbl.MaturityDate}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{cbl.MasterLC}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{cbl.Currency}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}",cbl.ValueFC)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", cbl.ValueBDT)}</td>");  
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{cbl.Remarks}</td>");

                    sb.Append("</tr>");

                    fsl++;
                }


                sb.Append("</tr>");
                sb.Append("</table>");
            }
            else
            {
                sb.Append($@"<h2 style='text-align:center;padding-bottom:1px;margin-bottom:0px;color:green;'> , No data found Date :{ReportDateMsg}</h2>");
            }

            sb.Append(@$"<div style='margin-top:50px;background:#C0C0C0;color:#111;font-size:10px;'>ERP Automatic generated Report, Generated at : {DateTime.Now.ToString("dd:MMM:yyyy hh:mm:ss")}</div>");
            sb.Append("<body><html>");

            var rawData = sb.ToString();
            var mailItem = await _schedularReportEmailRepository.GetMailRecipients(Constants_EmailReport.BTBCashLCOverdueMaturityNotification);
            List<string> to = new List<string>();
            List<string> cc = new List<string>();
            List<string> bcc = new List<string>();
            to = mailItem.Item1;
            cc = mailItem.Item2;
            bcc = mailItem.Item3;

            //to.Add("akbar@comptexbd.com");
            //cc.Add("jobayershoaib@gmail.com");
            //cc.Add("jobayer@robintexbd.com");

            //email.Add("habib@robintexbd.com");
            //var mailBody = sb.ToString();
            var emailMessage = new EmailMessageAttachment($"ERP Report For BTB/Cash LC Overdue Maturity Notification Date :{ReportDateMsg}", rawData, to, cc, bcc);
            try
            {
                await _emailSenderService.SendEmailAsync(emailMessage);
                _logger.LogInformation($"SubContractGatePass Mail Send at {DateTime.Now.ToString("dd MMM yyyy HH:mm:ss")}");
            }
            catch (Exception e)
            {
                var aa = e.Message;
                _logger.LogError(e, "DelayedVoucherPostingRBL");
            }
        }

        public async Task DailyKnittingShiftAndMachineWiseKnittingDefects(DateTime? DtFrom = null, DateTime? DtTo = null)
        {
            var ReportDateMsg = DtFrom.Value.ToString("dd-MMM-yyyy");
            var knittingPerformance = await _dailyMailEMSRepository.DailyKnittingShiftAndMachineWiseKnittingDefects(DtFrom, DtTo);
            //IE Report-2, Daily Knitting Shift & Machine Wise Knitting Defect(s)
            var rawData = knittingPerformance.Select(s => s.ReportData).FirstOrDefault();
            var mailItem = await _schedularReportEmailRepository.GetMailRecipients(Constants_EmailReport.DailyKnittingShiftAndMachineWiseKnittingDefects);
            List<string> to = new List<string>();
            List<string> cc = new List<string>();
            List<string> bcc = new List<string>();
            to = mailItem.Item1;
            cc = mailItem.Item2;
            bcc = mailItem.Item3;

            //to.Add("akbar@comptexbd.com");
            //cc.Add("jobayershoaib@gmail.com");
            //cc.Add("jobayer@robintexbd.com");

            //email.Add("habib@robintexbd.com");
            //var mailBody = sb.ToString();
            var emailMessage = new EmailMessageAttachment($"IE Report-2, Daily Knitting Shift & Machine Wise Knitting Defect(s), Date:{ReportDateMsg}", rawData, to, cc, bcc);
            try
            {

                await _emailSenderService.SendEmailAsync(emailMessage);
                _logger.LogInformation($"DailyKnittingShiftAndMachineWiseKnittingDefects Mail Send at {DateTime.Now.ToString("dd MMM yyyy HH:mm:ss")}");
            }
            catch (Exception e)
            {
                var aa = e.Message;
                _logger.LogError(e, "DailyKnittingShiftAndMachineWiseKnittingDefects");
            }
        }

        public async Task DailyKnittingShiftAndMachineWiseOverallPerformance(DateTime? DtFrom = null, DateTime? DtTo = null)
        {
            var ReportDateMsg = DtFrom.Value.ToString("dd-MMM-yyyy");
            var knittingPerformance = await _dailyMailFiniteSchedulerRepository.DailyKnittingShiftAndMachineWiseOverallPerformance(DtFrom, DtTo);
            //IE Report-2, Daily Knitting Shift & Machine Wise Knitting Defect(s)
            var rawData = knittingPerformance.Select(s => s.ReportData).FirstOrDefault();
            var mailItem = await _schedularReportEmailRepository.GetMailRecipients(Constants_EmailReport.DailyKnittingShiftAndMachineWiseOverallPerformance);
            List<string> to = new List<string>();
            List<string> cc = new List<string>();
            List<string> bcc = new List<string>();
            to = mailItem.Item1;
            cc = mailItem.Item2;
            bcc = mailItem.Item3;

            //to.Add("akbar@comptexbd.com");
            //cc.Add("jobayershoaib@gmail.com");
            //cc.Add("jobayer@robintexbd.com");

            //email.Add("habib@robintexbd.com");
            //var mailBody = sb.ToString();
            var emailMessage = new EmailMessageAttachment($"IE Report-1, Daily Knitting Shift & Machine Wise overall Performance, Date:{ReportDateMsg}", rawData, to, cc, bcc);
            try
            {

                await _emailSenderService.SendEmailAsync(emailMessage);
                _logger.LogInformation($"DailyKnittingShiftAndMachineWiseKnittingDefects Mail Send at {DateTime.Now.ToString("dd MMM yyyy HH:mm:ss")}");
            }
            catch (Exception e)
            {
                var aa = e.Message;
                _logger.LogError(e, "DailyKnittingShiftAndMachineWiseKnittingDefects");
            }
        }

        public async Task DailyYarnStockReport(DateTime? DtFrom = null, DateTime? DtTo = null)
        {
            if (DtFrom.HasValue == false || DtTo.HasValue == false)
            {
                DtFrom = DateTime.Now.AddDays(-1).Date;
                DtTo = DtFrom;
            }
            var yarnData = await _dailyMailMaterialManagementRepository.DailyYarnStockReport(DtFrom, DtTo);

            var ReportDateMsg = DtFrom.Value.ToString("dd-MMM-yyyy");
            StringBuilder sb = new StringBuilder();
            string htmlBody = @$"<!DOCTYPE html>
                                    <head><meta content=""text/html; charset=utf-8"" http-equiv=""Content-Type"">
                                        <title> Daily Yarn Stock Report . </title> 
                                    </head>";
            sb.AppendLine(htmlBody);
            sb.Append(@"<body style='font-size:13px;'>");
            sb.Append(@"<h2 style='text-align:center;padding-bottom:1px;margin-bottom:0px;'> Daily Yarn Transaction. </h2>");
            sb.Append(@$"<h4 style='text-align:center;padding-top:1px;padding-bottom:1px;margin-bottom:0px;;margin-top:1px;'>Date:{ReportDateMsg}</h4>");

            if (yarnData.Count > 0)
            {
                sb.Append(@"<table style='font-family: arial, sans-serif;border-collapse:collapse;font-size:9pt;width: 100%;'>");
                sb.Append(@"<thead style='text-align:center;'>");
                sb.Append("<tr>");
                sb.Append("<th style='border:1px solid black;' width='2%'>SL#</th>");
                //Company 	Machine 	Brand	Fabric Type 	Fabric Quality 	Fabric Composition	GSM 	Width 	Shift A 	Shift B 	Shift C	Total Qty
                sb.Append("<th style='border:1px solid black;' width=''>Supplier</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Lot No</ th>");
                sb.Append("<th style='border:1px solid black;' width=''>Yarn</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Quality</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Opening</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Op. Value</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Receive Qty</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Rcv Value</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Issue Qty</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Iss. Value</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Closing Qty</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Closing Value</th>");
                sb.Append("</thead></tr>");
                int fsl = 1;

                //SubContract
                foreach (var sub in yarnData)
                {
                    sb.Append("<tr>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{fsl}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{sub.CompanyName}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{sub.LotNo}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'><b style='color:green;'>{sub.YarnCount},</b> {sub.YarnComposition}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{sub.YarnQuality}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", sub.OPB)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", sub.OPBValue)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", sub.Rec)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", sub.RecValue)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", Math.Abs(sub.Iss))}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", sub.IssValue)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", sub.OPB + sub.Rec + sub.Iss)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", sub.OPBValue + sub.RecValue - sub.IssValue)}</td>");
                    sb.Append("</tr>");

                    fsl++;
                }
                // Sub Contract
                sb.Append("<tr style='font-weight:bold;font-size:7pt;'>");
                sb.Append($"<th style='border:1px solid black;text-align:right;padding:5px;' colspan='5'>Total</th>");

                sb.Append($"<th style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", yarnData.Sum(b => b.OPB))}</th>");
                sb.Append($"<th style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", yarnData.Sum(b => b.OPBValue))}</th>");
                sb.Append($"<th style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", yarnData.Sum(b => b.Rec))}</th>");
                sb.Append($"<th style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", yarnData.Average(b => b.RecValue))}</th>");
                sb.Append($"<th style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", yarnData.Sum(b => Math.Abs(b.Iss)))}</th>");
                sb.Append($"<th style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", yarnData.Sum(b => b.IssValue))}</th>");
                sb.Append($"<th style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", yarnData.Sum(b => b.OPB + b.Rec + Math.Abs(b.Iss)))}</th>");
                sb.Append($"<th style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", yarnData.Sum(b => b.OPBValue + b.RecValue - b.IssValue))}</th>");
                sb.Append("</tr>");
                sb.Append("</table>");

            }
            else
            {
                sb.Append($@"<h2 style='text-align:center;padding-bottom:1px;margin-bottom:0px;color:green;'>Daily Yarn Transaction ,No data found Date :{ReportDateMsg}</h2>");
            }

            sb.Append(@$"<div style='margin-top:50px;background:#C0C0C0;color:#111;font-size:10px;'>ERP Automatic generated Report, Generated at : {DateTime.Now.ToString("dd:MMM:yyyy hh:mm:ss")}</div>");

            sb.Append("<body><html>");

            var rawData = sb.ToString();
            var mailItem = await _schedularReportEmailRepository.GetMailRecipients(Constants_EmailReport.DailyYarnTransaction);
            List<string> to = new List<string>();
            List<string> cc = new List<string>();
            List<string> bcc = new List<string>();
            to = mailItem.Item1;
            cc = mailItem.Item2;
            bcc = mailItem.Item3;

            //to.Add("akbar@comptexbd.com");
            //cc.Add("jobayershoaib@gmail.com");
            //cc.Add("jobayer@robintexbd.com"); 
            //email.Add("habib@robintexbd.com");
            //var mailBody = sb.ToString();
            var emailMessage = new EmailMessageAttachment($"ERP Report For Daily Yarn Transaction, Date:{ReportDateMsg}", rawData, to, cc, bcc);
            try
            {

                await _emailSenderService.SendEmailAsync(emailMessage);
                _logger.LogInformation($"DailyYarnStockReport Mail Send at {DateTime.Now.ToString("dd MMM yyyy HH:mm:ss")}");
            }
            catch (Exception e)
            {
                var aa = e.Message;
                _logger.LogError(e, "DailyYarnStockReport");
            }


        }

        public async Task DelayedVoucherPostingCBL(DateTime DateFrom)
        {

            var cblVoucher = await _dailyMailEmbroRepository.DelayedVoucherPostingCBL(DateFrom);
            
            var ReportDateMsg = DateFrom.ToString("dd-MMM-yyyy");

            StringBuilder sb = new StringBuilder();
            string htmlBody = @$"<!DOCTYPE html>
                                    <head><meta content=""text/html; charset=utf-8"" http-equiv=""Content-Type"">
                                        <title> Delayed Voucher Posting in ERP Financials. </title> 
                                    </head>";
            sb.AppendLine(htmlBody);
            sb.Append(@"<body style='font-size:13px;'>");
            sb.Append(@"<h2 style='text-align:center;padding-bottom:1px;margin-bottom:0px;'>Delayed Voucher Posting in ERP Financials</h2>");
            sb.Append($@"<h3 style='text-align:center;padding-top:1px;padding-bottom:1px;margin-bottom:0px;;margin-top:1px;'>Comptex Bangladesh Limited</h3>");
            sb.Append(@$"<h4 style='text-align:center;padding-top:1px;padding-bottom:1px;margin-bottom:0px;;margin-top:1px;'>Date From:{ReportDateMsg}</h4>");

            if (cblVoucher.Count > 0)
            {

                sb.Append(@"<table style='font-family: arial, sans-serif;border-collapse:collapse;font-size:9pt;width: 100%;'>");
                sb.Append(@"<thead style='text-align:center;'>");
                sb.Append("<tr>");
                sb.Append("<th style='border:1px solid black;' width='3%'>SL#</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Voucher Number</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Reference</ th>");
                sb.Append("<th style='border:1px solid black;' width=''>Creation Date </th>");
                sb.Append("<th style='border:1px solid black;' width=''>Voucher Date</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Approved Date</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Prepared by</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Approved by</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Description</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Days Difference</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Approved<br/>In Days </th>");
                sb.Append("</thead></tr>");
                int fsl = 1;
                foreach (var cbl in cblVoucher)
                {
                    sb.Append("<tr>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{fsl}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{cbl.VoucherNumber}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{cbl.Reference}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{cbl.CreationDate}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{cbl.VoucherDate}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{cbl.ApprovedDate}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{cbl.PreparedBy}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{cbl.ApprovedBy}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:left;'>{cbl.Description}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{cbl.DaysDifference}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{cbl.ApprovedInDays}</td>");

                    sb.Append("</tr>");

                    fsl++;
                }


                sb.Append("</tr>");
                sb.Append("</table>");
            }
            else
            {
                sb.Append($@"<h2 style='text-align:center;padding-bottom:1px;margin-bottom:0px;color:green;'>CBL, No data found from :{ReportDateMsg}</h2>");
            }

            sb.Append(@$"<div style='margin-top:50px;background:#C0C0C0;color:#111;font-size:10px;'>ERP Automatic generated Report, Generated at : {DateTime.Now.ToString("dd:MMM:yyyy hh:mm:ss")}</div>");
            sb.Append("<body><html>");

            var rawData = sb.ToString();
            var mailItem = await _schedularReportEmailRepository.GetMailRecipients(Constants_EmailReport.CBLDelayedVoucherPostingERPFinancials);
            List<string> to = new List<string>();
            List<string> cc = new List<string>();
            List<string> bcc = new List<string>();
            to = mailItem.Item1;
            cc = mailItem.Item2;
            bcc = mailItem.Item3;

            //to.Add("akbar@comptexbd.com");
            //cc.Add("jobayershoaib@gmail.com");
            //cc.Add("jobayer@robintexbd.com");

            //email.Add("habib@robintexbd.com");
            //var mailBody = sb.ToString();
            var emailMessage = new EmailMessageAttachment($"ERP Report For Delayed Voucher Posting CBL,Date From:{ReportDateMsg}", rawData, to, cc, bcc);
            try
            {
                await _emailSenderService.SendEmailAsync(emailMessage);
                _logger.LogInformation($"Delayed Voucher Posting CBL Mail Send at {DateTime.Now.ToString("dd MMM yyyy HH:mm:ss")}");
            }
            catch (Exception e)
            {
                var aa = e.Message;
                _logger.LogError(e, "DelayedVoucherPostingCBL");
            }
        }

        public async Task DelayedVoucherPostingRBL(DateTime DateFrom)
        {
            var rblVoucher = await _dailyMailEmbroRepository.DelayedVoucherPostingRBL(DateFrom);

            var ReportDateMsg = DateFrom.ToString("dd-MMM-yyyy");

            StringBuilder sb = new StringBuilder();
            string htmlBody = @$"<!DOCTYPE html>
                                    <head><meta content=""text/html; charset=utf-8"" http-equiv=""Content-Type"">
                                        <title> Delayed Voucher Posting in ERP Financials. </title> 
                                    </head>";
            sb.AppendLine(htmlBody);
            sb.Append(@"<body style='font-size:13px;'>");

            if (rblVoucher.Count > 0)
            {

                sb.Append(@"<h2 style='text-align:center;padding-bottom:1px;margin-bottom:0px;'>Delayed Voucher Posting in ERP Financials</h2>");
                sb.Append($@"<h3 style='text-align:center;padding-top:1px;padding-bottom:1px;margin-bottom:0px;;margin-top:1px;'>{rblVoucher[0].Companyname}</h3>");
                sb.Append(@$"<h4 style='text-align:center;padding-top:1px;padding-bottom:1px;margin-bottom:0px;;margin-top:1px;'>Date From:{ReportDateMsg}</h4>");

                sb.Append(@"<table style='font-family: arial, sans-serif;border-collapse:collapse;font-size:9pt;width: 100%;'>");
                sb.Append(@"<thead style='text-align:center;'>");
                sb.Append("<tr>");
                sb.Append("<th style='border:1px solid black;' width='3%'>SL#</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Voucher Number</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Reference</ th>");
                sb.Append("<th style='border:1px solid black;' width=''>Creation Date </th>");
                sb.Append("<th style='border:1px solid black;' width=''>Voucher Date</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Approved Date</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Prepared by</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Approved by</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Description</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Days Difference</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Approved<br/>In Days </th>");
                sb.Append("</thead></tr>");
                int fsl = 1;
                foreach (var rtn in rblVoucher)
                {
                    sb.Append("<tr>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{fsl}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{rtn.VoucherNumber}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{rtn.Reference}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{rtn.CreationDate}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{rtn.VoucherDate}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{rtn.ApprovedDate}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{rtn.PreparedBy}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{rtn.ApprovedBy}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:left;'>{rtn.Description}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{rtn.DaysDifference}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{rtn.ApprovedInDays}</td>");

                    sb.Append("</tr>");

                    fsl++;
                }


                sb.Append("</tr>");
                sb.Append("</table>");
            }
            else
            {
                sb.Append($@"<h2 style='text-align:center;padding-bottom:1px;margin-bottom:0px;color:green;'>RBL, No data found from :{ReportDateMsg}</h2>");
            }

            sb.Append(@$"<div style='margin-top:50px;background:#C0C0C0;color:#111;font-size:10px;'>ERP Automatic generated Report, Generated at : {DateTime.Now.ToString("dd:MMM:yyyy hh:mm:ss")}</div>");
            sb.Append("<body><html>");

            var rawData = sb.ToString();
            var mailItem = await _schedularReportEmailRepository.GetMailRecipients(Constants_EmailReport.RBLDelayedVoucherPostingERPFinancials);
            List<string> to = new List<string>();
            List<string> cc = new List<string>();
            List<string> bcc = new List<string>();
            to = mailItem.Item1;
            cc = mailItem.Item2;
            bcc = mailItem.Item3;

            //to.Add("akbar@comptexbd.com");
            //cc.Add("jobayershoaib@gmail.com");
            //cc.Add("jobayer@robintexbd.com");

            //email.Add("habib@robintexbd.com");
            //var mailBody = sb.ToString();
            var emailMessage = new EmailMessageAttachment($"ERP Report For Delayed Voucher Posting Date From:{ReportDateMsg}", rawData, to, cc, bcc);
            try
            {
                await _emailSenderService.SendEmailAsync(emailMessage);
                _logger.LogInformation($"SubContractGatePass Mail Send at {DateTime.Now.ToString("dd MMM yyyy HH:mm:ss")}");
            }
            catch (Exception e)
            {
                var aa = e.Message;
                _logger.LogError(e, "DelayedVoucherPostingRBL");
            }
        }

        public async Task FDBP_FDBCEntryNotification()
        {
            var fdbpData = await _dailyMailMaxcoRepository.FDBP_FDBCEntryNotification();

            var ReportDateMsg = DateTime.Now.ToString("dd-MMM-yyyy");

            StringBuilder sb = new StringBuilder();
            string htmlBody = @$"<!DOCTYPE html>
                                    <head><meta content=""text/html; charset=utf-8"" http-equiv=""Content-Type"">
                                        <title> FDBP/FDBC Entry Notification. </title> 
                                    </head>";
            sb.AppendLine(htmlBody);
            sb.Append(@"<body style='font-size:13px;'>");

            if (fdbpData.Count > 0)
            {
                sb.Append(@"<h2 style='text-align:center;padding-bottom:1px;margin-bottom:0px;'> FDBP/FDBC Entry Notification   </h2>");
                sb.Append(@$"<h4 style='text-align:center;padding-top:1px;padding-bottom:1px;margin-bottom:0px;;margin-top:1px;'>Reporting Date - {ReportDateMsg}</h4>");

                sb.Append(@"<table style='font-family: arial, sans-serif;border-collapse:collapse;font-size:9pt;width: 100%;'>");
                sb.Append(@"<thead style='text-align:center;'>");
                sb.Append("<tr>");
                sb.Append("<th style='border:1px solid black;' width='3%'>SL#</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Company</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Bank</ th>");
                sb.Append("<th style='border:1px solid black;' width=''>Document Number</ th>");
                sb.Append("<th style='border:1px solid black;' width=''>Create Date</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Approval Date</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Document Value</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Exceed Days</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Remarks</th>");
                sb.Append("</thead></tr>");
                int fsl = 1;
                string excedDaysStyle = "";
                foreach (var ung in fdbpData)
                {
                    excedDaysStyle = "";
                    sb.Append("<tr>");
                    
                    if (ung.ExceedDays >= 74)
                    {
                        excedDaysStyle = "background-color:#e60000;color:#fff";
                    }
                    else if (ung.ExceedDays > 49)
                    {
                        excedDaysStyle = "background-color:#ff4d4d;color:#111";
                    }
                    else if (ung.ExceedDays > 24)
                    {
                        excedDaysStyle = "background-color:#ff8080;color:#111";
                    }
                    else if (ung.ExceedDays > 15)
                    {
                        excedDaysStyle = "background-color:#ff9999;color:#111";
                    }
                    else if (ung.ExceedDays > 5)
                    {
                        excedDaysStyle = "background-color:#ffcccc;color:#111";
                    }
                    else
                    {
                        excedDaysStyle = "";
                    }

                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{fsl}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.CompanyName}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.BankName}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.DocumentNumber}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.CreationDate}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.ApprovalDate}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", ung.DocumentValue)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;{excedDaysStyle}'><b>{ung.ExceedDays}</b></td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.Remarks}</td>");

                    sb.Append("</tr>");

                    fsl++;
                }
                #region Total
                sb.Append("<tr>");
                sb.Append($"<th style='border:1px solid black;text-align:right;padding:4px;' colspan='6'>Total</th>");
                sb.Append($"<th style='border:1px solid black;text-align:right;font-size:8pt;'>{String.Format("{0:n2}", fdbpData.Sum(b=>b.DocumentValue))}</th>");
                sb.Append($"<td style='border:1px solid black;text-align:center;'>&nbsp;</td>");
                sb.Append($"<td style='border:1px solid black;text-align:center;'>&nbsp;</td>");
                sb.Append("</tr>");

                #endregion Total 
                sb.Append("</table>");
            }
            else
            {
                sb.Append(@"<h2 style='text-align:center;padding-bottom:1px;margin-bottom:0px;'>No FDBP/FDBC Entry found.  </h2>");
            }

            sb.Append(@$"<div style='margin-top:50px;background:#C0C0C0;color:#111;font-size:10px;'>ERP Automatic generated Report, Generated at : {DateTime.Now.ToString("dd:MMM:yyyy hh:mm:ss")}</div>");
            sb.Append("<body><html>");

            var rawData = sb.ToString();
            var mailItem = await _schedularReportEmailRepository.GetMailRecipients(Constants_EmailReport.FDBPFDBC_EntryNotification);
            List<string> to = new List<string>();
            List<string> cc = new List<string>();
            List<string> bcc = new List<string>();
            to = mailItem.Item1;
            cc = mailItem.Item2;
            bcc = mailItem.Item3;

            //to.Add("akbar@comptexbd.com");
            //cc.Add("jobayershoaib@gmail.com");
            //cc.Add("jobayer@robintexbd.com");

            //email.Add("habib@robintexbd.com");
            //var mailBody = sb.ToString();
            var emailMessage = new EmailMessageAttachment($"FDBP/FDBC Entry Notification. Date : {ReportDateMsg}", rawData, to, cc, bcc);
            try
            {
                await _emailSenderService.SendEmailAsync(emailMessage);
                _logger.LogInformation($"FDBP/FDBC Entry Notification Send at {DateTime.Now.ToString("dd MMM yyyy HH:mm:ss")}");
            }
            catch (Exception e)
            {
                var aa = e.Message;
                _logger.LogError(e, "SubContractGatePass");
            }

        }

        public async Task GetKnittingDailyProduction(DateTime ReportDate)
        {
            var data = await _dailyMailMaterialManagementRepository.GetKnittingDailyProduction(ReportDate);
            var ReportDateMsg = ReportDate.ToString("dd-MMM-yyyy");
            if (data.Count > 0)
            {
                var subContactList = data.Where(b => b.CompanyID == 0).ToList();
                var InHouseList = data.Where(b => b.CompanyID > 0).ToList();

                StringBuilder sb = new StringBuilder();
                string htmlBody = @$"<!DOCTYPE html>
                                    <head><meta content=""text/html; charset=utf-8"" http-equiv=""Content-Type"">
                                        <title>Knitting Daily Production {ReportDateMsg} [Auto Generated ERP Report]</title> 
                                    </head>";
                sb.AppendLine(htmlBody);
                sb.Append(@"<body style='font-size:13px;'>");
                sb.Append(@"<h2 style='text-align:center;padding-bottom:1px;margin-bottom:0px;'>Daily Knitting Production Report (Knitting Department)</h2>");
                sb.Append(@$"<h4 style='text-align:center;padding-top:1px;padding-bottom:1px;margin-bottom:0px;;margin-top:1px;'>Date:{ReportDateMsg}</h4>");
                sb.Append(@$"<div style='font-size:14px;font-weight:bold;background-color:#EDE6D6;'>
                         <div style='width:30%;Float:left !important;padding-Top:5px;padding-bottom:5px;'>Sub-Contact : {String.Format("{0:n2}", subContactList.Sum(b => b.TotalQty))}</div>");
                sb.Append(@$"<div style='width:30%;Float:left !important;padding-Top:5px;padding-bottom:5px;'>In-House : {String.Format("{0:n2}", InHouseList.Sum(b => b.TotalQty))}</div>");
                sb.Append(@$"<div style='width:30%;Float:left !important;padding-Top:5px;padding-bottom:5px;'>Total Production : {String.Format("{0:n2}", data.Sum(b => b.TotalQty))}</div></div><br/>");

                sb.Append(@"<table style='font-family: arial, sans-serif;border-collapse:collapse;font-size:9pt;width: 100%;'>");
                sb.Append(@"<thead style='text-align:center;'>");
                sb.Append("<tr style='border:0px;'><th colspan='13' style='border:0px;text-align:left;'>Sub-Contract Production</th></tr>");
                sb.Append("<tr>");
                sb.Append("<th style='border:1px solid black;' width='3%'>SL#</th>");
                //Company 	Machine 	Brand	Fabric Type 	Fabric Quality 	Fabric Composition	GSM 	Width 	Shift A 	Shift B 	Shift C	Total Qty
                sb.Append("<th style='border:1px solid black;' width='13%'>Company</th>");
                sb.Append("<th style='border:1px solid black;' width='4%'>Machine</th>");
                sb.Append("<th style='border:1px solid black;' width='6%'>Brand</th>");
                sb.Append("<th style='border:1px solid black;' width='7%'>Fabric Type</th>");
                sb.Append("<th style='border:1px solid black;' width='10%'>Fabric Quality</th>");
                sb.Append("<th style='border:1px solid black;' width='20%'>Composition</th>");
                sb.Append("<th style='border:1px solid black;' width='4%'>GSM</th>");
                sb.Append("<th style='border:1px solid black;' width='4%'>Width</th>");
                sb.Append("<th style='border:1px solid black;' width='4%'>Shift A</th>");
                sb.Append("<th style='border:1px solid black;' width='4%'>Shift B</th>");
                sb.Append("<th style='border:1px solid black;' width='4%'>Shift C</th>");
                sb.Append("<th style='border:1px solid black;' width='4%'>Total Qty</th>");
                sb.Append("</thead></tr>");
                int fsl = 1;

                //SubContract
                foreach (var sub in subContactList)
                {
                    sb.Append("<tr>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{sub.SerialNo}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{sub.CompanyName}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{sub.Machine}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{sub.Brand}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{sub.FabricType}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{sub.FabricQuality}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{sub.FabricComposition}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{sub.Gsm}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{sub.Width}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", sub.ShiftA)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", sub.ShiftB)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", sub.ShiftC)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", sub.TotalQty)}</td>");
                    sb.Append("</tr>");
                }
                // Sub Contract
                sb.Append("<tr style='font-weight:bold;font-size:8pt;'>");
                sb.Append($"<td style='border:1px solid black;text-align:right;' colspan='9'>Sub-Contract Production Total</td>");
                sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", subContactList.Sum(b => b.ShiftA))}</td>");
                sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", subContactList.Sum(b => b.ShiftB))}</td>");
                sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", subContactList.Sum(b => b.ShiftC))}</td>");
                sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", subContactList.Sum(b => b.TotalQty))}</td>");
                sb.Append("</tr>");

                fsl = 1;
                sb.Append("<tr style='border:0px;'><td colspan='13' style='border:0px;'>&nbsp;</td></tr>");
                sb.Append("<tr style='border:0px;'><th colspan='13' style='border:0px;'>In-House Production</th></tr>");

                //In House
                foreach (var inh in InHouseList)
                {
                    sb.Append("<tr>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{inh.SerialNo}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{inh.CompanyName}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{inh.Machine}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{inh.Brand}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{inh.FabricType}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{inh.FabricQuality}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{inh.FabricComposition}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{inh.Gsm}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{inh.Width}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", inh.ShiftA)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", inh.ShiftB)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", inh.ShiftC)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", inh.TotalQty)}</td>");
                    sb.Append("</tr>");
                }
                // Sub Contract
                sb.Append("<tr style='font-weight:bold;font-size:8pt;'>");
                sb.Append($"<td style='border:1px solid black;text-align:right;' colspan='9'>In-House Production Total</td>");
                sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", InHouseList.Sum(b => b.ShiftA))}</td>");
                sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", InHouseList.Sum(b => b.ShiftB))}</td>");
                sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", InHouseList.Sum(b => b.ShiftC))}</td>");
                sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", InHouseList.Sum(b => b.TotalQty))}</td>");
                sb.Append("</tr>");
                sb.Append("</table>");

                sb.Append(@$"<div style='margin-top:50px;background:#C0C0C0;color:#111;font-size:10px;'>ERP Automatic generated Report, Generated at : {DateTime.Now.ToString("dd:MMM:yyyy hh:mm:ss")}</div>");
                sb.Append("<body><html>");

                var rawData = sb.ToString();
                var mailItem = await _schedularReportEmailRepository.GetMailRecipients(Constants_EmailReport.DailyKnittingProductionReport);
                List<string> to = new List<string>();
                List<string> cc = new List<string>();
                List<string> bcc = new List<string>();
                to = mailItem.Item1;
                cc = mailItem.Item2;
                bcc = mailItem.Item3;
                /*
                to.Add("akbar@comptexbd.com");
                cc.Add("jobayershoaib@gmail.com");
                cc.Add("jobayer@robintexbd.com");
                */
                //email.Add("habib@robintexbd.com");
                //var mailBody = sb.ToString();
                var emailMessage = new EmailMessageAttachment($"ERP Report For Daily Knitting Production Report (Knitting Department) Date:{ReportDateMsg}", rawData, to, cc, bcc);
                try
                {

                    await _emailSenderService.SendEmailAsync(emailMessage);
                    _logger.LogInformation($"Mail Send at {DateTime.Now:dd MMM yyyy HH:mm:ss}");
                }
                catch (Exception e)
                {
                    var aa = e.Message;
                    _logger.LogError(e, "GetDailyOrderFabricWastageExceededLot");
                }
            }
        }

        public async Task KnittingProductionDefect(DateTime DtFrom)
        {
            var data = await _dailyMailFiniteSchedulerRepository.KnittingProductionDefect(DtFrom);
            var ReportDateMsg = DtFrom.ToString("dd-MMM-yyyy");
            if (data.Count > 0)
            {

                StringBuilder sb = new StringBuilder();
                string htmlBody = @$"<!DOCTYPE html>
                                    <head><meta content=""text/html; charset=utf-8"" http-equiv=""Content-Type"">
                                        <title> Notification is based on Data Recorded in ERP BY IE Deparmtent. </title> 
                                    </head>";
                sb.AppendLine(htmlBody);
                sb.Append(@"<body style='font-size:13px;'>");
                sb.Append(@"<h2 style='text-align:center;padding-bottom:1px;margin-bottom:0px;'> Knitting Production Defect(s). </h2>");
                sb.Append(@$"<h4 style='text-align:center;padding-top:1px;padding-bottom:1px;margin-bottom:0px;;margin-top:1px;'>Date:{ReportDateMsg}</h4>");

                sb.Append(@"<table style='font-family: arial, sans-serif;border-collapse:collapse;font-size:9pt;width: 100%;'>");
                sb.Append(@"<thead style='text-align:center;'>");
                sb.Append("<tr>");
                sb.Append("<th style='border:1px solid black;' width='2%'>SL#</th>");
                //Company 	Machine 	Brand	Fabric Type 	Fabric Quality 	Fabric Composition	GSM 	Width 	Shift A 	Shift B 	Shift C	Total Qty
                sb.Append("<th style='border:1px solid black;' width=''>Shift</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Fabric Qty<br/>(Kgs)</ th>");
                sb.Append("<th style='border:1px solid black;' width=''>No. of<br/>Rolls</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Linear<br/>Length<br/> (m)</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Avg<br/>Width</th>");
                sb.Append("<th style='border:1px solid black;' width=''>NEEDLE<br/>HOLE</th>");
                sb.Append("<th style='border:1px solid black;' width=''>SINKER<br/>MARK</th>");
                sb.Append("<th style='border:1px solid black;' width=''>OIL<br/>STAIN</th>");
                sb.Append("<th style='border:1px solid black;' width=''>LOOP</th>");
                sb.Append("<th style='border:1px solid black;' width=''>LYCRA<br/>OUT</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Pin<br/>Hole</th>");
                sb.Append("<th style='border:1px solid black;' width=''>STRIPE<br/>Y/D</th>");
                sb.Append("<th style='border:1px solid black;' width=''>YARN<br/>CONTAMINATION</th>");
                sb.Append("<th style='border:1px solid black;' width=''>SLUB</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Needle<br/>Mark</th>");
                sb.Append("<th style='border:1px solid black;' width=''>PRESS<br/>OFF</th>");
                sb.Append("<th style='border:1px solid black;' width=''>N/B</th>");
                sb.Append("<th style='border:1px solid black;' width=''>LYCRA<br/>DROP</th>");
                sb.Append("</thead></tr>");
                int fsl = 1;

                //SubContract
                foreach (var sub in data)
                {
                    sb.Append("<tr>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{fsl}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{sub.ShiftCode}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", sub.ttl_qty)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{sub.r_qty}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", sub.ttl_Length)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{sub.Width}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{sub.ttl_NEEDLE_HOLE}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{sub.ttl_SINKER_MARK}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{sub.ttl_OIL_STAIN}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{sub.ttl_loop}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{sub.ttl_LYCRA_OUT}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{sub.ttl_MISSING_YARN}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{sub.ttl_STRIPE_YD}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{sub.ttl_YARN_CONTAM}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{sub.ttl_SLUB}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{sub.ttl_BARRIE}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{sub.ttl_PRESS_OFF}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{sub.ttl_NB}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{sub.ttl_LYCRA_DROP}</td>");

                    sb.Append("</tr>");

                    fsl++;
                }
                // Sub Contract
                sb.Append("<tr style='font-weight:bold;font-size:8pt;'>");
                sb.Append($"<td style='border:1px solid black;text-align:center;' colspan='2'>Total</td>");

                sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", data.Sum(b => b.ttl_qty))}</td>");
                sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", data.Sum(b => b.r_qty))}</td>");
                sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", data.Sum(b => b.ttl_Length))}</td>");
                sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", data.Average(b => b.Width))}</td>");
                sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", data.Sum(b => b.ttl_NEEDLE_HOLE))}</td>");
                sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", data.Sum(b => b.ttl_SINKER_MARK))}</td>");
                sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", data.Sum(b => b.ttl_OIL_STAIN))}</td>");
                sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", data.Sum(b => b.ttl_loop))}</td>");
                sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", data.Sum(b => b.ttl_LYCRA_OUT))}</td>");
                sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", data.Sum(b => b.ttl_MISSING_YARN))}</td>");
                sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", data.Sum(b => b.ttl_STRIPE_YD))}</td>");
                sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", data.Sum(b => b.ttl_YARN_CONTAM))}</td>");
                sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", data.Sum(b => b.ttl_SLUB))}</td>");
                sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", data.Sum(b => b.ttl_BARRIE))}</td>");
                sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", data.Sum(b => b.ttl_PRESS_OFF))}</td>");
                sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", data.Sum(b => b.ttl_NB))}</td>");
                sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", data.Sum(b => b.ttl_LYCRA_DROP))}</td>");

                sb.Append("</tr>");
                sb.Append("</table>");


                sb.Append(@$"<div style='margin-top:50px;background:#C0C0C0;color:#111;font-size:10px;'>ERP Automatic generated Report, Generated at : {DateTime.Now.ToString("dd:MMM:yyyy hh:mm:ss")}</div>");
                sb.Append("<body><html>");

                var rawData = sb.ToString();
                var mailItem = await _schedularReportEmailRepository.GetMailRecipients(Constants_EmailReport.DailyKnittingProductionReport);
                List<string> to = new List<string>();
                List<string> cc = new List<string>();
                List<string> bcc = new List<string>();
                to = mailItem.Item1;
                cc = mailItem.Item2;
                bcc = mailItem.Item3;
                /*
                to.Add("akbar@comptexbd.com");
                cc.Add("jobayershoaib@gmail.com");
                cc.Add("jobayer@robintexbd.com");
                */
                //email.Add("habib@robintexbd.com");
                //var mailBody = sb.ToString();
                var emailMessage = new EmailMessageAttachment($"ERP Report For Knitting Production Defect(s) Date:{ReportDateMsg}", rawData, to, cc, bcc);
                try
                {

                    await _emailSenderService.SendEmailAsync(emailMessage);
                    _logger.LogInformation($"KnittingProductionDefect Mail Send at {DateTime.Now.ToString("dd MMM yyyy HH:mm:ss")}");
                }
                catch (Exception e)
                {
                    var aa = e.Message;
                    _logger.LogError(e, "KnittingProductionDefect");
                }
            }
        }

        public async Task LateDeliveries_ConsumablesCBL()
        {
            var ReportDateMsg = DateTime.Now.ToString("dd-MMM-yyyy");
            var cblCons = await _dailyMailMaterialManagementRepository.LateDeliveries_ConsumablesCBL();

            StringBuilder sb = new StringBuilder();
            string htmlBody = @$"<!DOCTYPE html>
                                    <head><meta content=""text/html; charset=utf-8"" http-equiv=""Content-Type"">
                                        <title> Late Delivery Report Consumables, CBL </title> 
                                    </head>";
            sb.AppendLine(htmlBody);
            sb.Append(@"<body style='font-size:13px;'>");

            if (cblCons.Count > 0)
            {
                sb.Append(@"<h2 style='text-align:center;padding-bottom:1px;margin-bottom:0px;'> Late Delivery Report Consumables, CBL </h2>");
                sb.Append(@$"<h4 style='text-align:center;padding-top:1px;padding-bottom:1px;margin-bottom:0px;;margin-top:1px;'>Reporting Date - {ReportDateMsg}</h4>");

                sb.Append(@"<table style='font-family: arial, sans-serif;border-collapse:collapse;font-size:9pt;width: 100%;'>");
                sb.Append(@"<thead style='text-align:center;'>");
                sb.Append("<tr>");
                /*
                Supplier PurchaseOrderNo PODate ItemName    POQuantity
                ReceivedQty BalanceToDeliver DeliveryDate    OverDue
                    */
     
                sb.Append("<th style='border:1px solid black;' width='3%'>SL#</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Supplier</ th>");
                sb.Append("<th style='border:1px solid black;' width=''>Purchase<br/>Order No</ th>");
                sb.Append("<th style='border:1px solid black;' width=''>Payment<br/>Mode</th>");
                sb.Append("<th style='border:1px solid black;' width=''>PO Date</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Item</th>");
                sb.Append("<th style='border:1px solid black;' width=''>PO Quantity</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Received<br/>Qty</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Receivable<br/>Qty</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Receivable<br/> Date</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Exced<br/>Dayes</th>");
                sb.Append("</thead></tr>");
                int fsl = 1;
                string excedDaysStyle = "";
                string advancePOStyle = "";
                foreach (var ung in cblCons)
                {
                    excedDaysStyle = "";
                    advancePOStyle = ung.PaymentMode == "Advance" ? " background:#A52A2A;color:#fff" : "";
                    sb.Append("<tr>");

                    if (ung.OverDue >= 100)
                    {
                        excedDaysStyle = "background-color:#e60000;color:#fff";
                    }
                    else if (ung.OverDue > 75)
                    {
                        excedDaysStyle = "background-color:#ff4d4d;color:#111";
                    }
                    else if (ung.OverDue > 50)
                    {
                        excedDaysStyle = "background-color:#ff8080;color:#111";
                    }
                    else if (ung.OverDue > 25)
                    {
                        excedDaysStyle = "background-color:#ff9999;color:#111";
                    }
                    else if (ung.OverDue > 5)
                    {
                        excedDaysStyle = "background-color:#ffcccc;color:#111";
                    }
                    else
                    {
                        excedDaysStyle = "";
                    }

                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{fsl}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.Supplier}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.PurchaseOrderNo}</td>");
                    if (ung.AdvancePercentage==0)
                    {

                        sb.Append($"<td style='border:1px solid black;text-align:center;{advancePOStyle}'>{ung.PaymentMode}</td>");
                    }
                    else
                    {
                        sb.Append($"<td style='border:1px solid black;text-align:center; {advancePOStyle};'title='PO Advance Payment:{ung.AdvancePercentage}'>{ung.PaymentMode}-{ung.AdvancePercentage}</td>");
                    }
                   
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.PODate}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.ItemName}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", ung.POQuantity)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", ung.ReceivedQty)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;{excedDaysStyle}'>{String.Format("{0:n2}", ung.BalanceToDeliver)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.DeliveryDate}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;{excedDaysStyle}'><b>{ung.OverDue}</b></td>");
                    sb.Append("</tr>");

                    fsl++;
                }
                #region Total
                sb.Append("<tr>");
                sb.Append($"<th style='border:1px solid black;text-align:right;padding:4px;' colspan='6'>Total</th>");
                sb.Append($"<th style='border:1px solid black;text-align:right;font-size:8pt;'>{String.Format("{0:n2}", cblCons.Sum(b => b.POQuantity))}</th>");
                sb.Append($"<th style='border:1px solid black;text-align:right;font-size:8pt;'>{String.Format("{0:n2}", cblCons.Sum(b => b.ReceivedQty))}</th>");
                sb.Append($"<th style='border:1px solid black;text-align:right;font-size:8pt;'>{String.Format("{0:n2}", cblCons.Sum(b => b.BalanceToDeliver))}</th>");
                sb.Append($"<td style='border:1px solid black;text-align:center;'>&nbsp;</td>");
                sb.Append($"<td style='border:1px solid black;text-align:center;'>&nbsp;</td>");
                sb.Append("</tr>");

                #endregion Total 
                sb.Append("</table>");
            }
            else
            {
                sb.Append(@"<h2 style='text-align:center;padding-bottom:1px;margin-bottom:0px;'>No Late Delivery Report Consumables, CBL.  </h2>");
            }

            sb.Append(@$"<div style='margin-top:50px;background:#C0C0C0;color:#111;font-size:10px;'>ERP Automatic generated Report, Generated at : {DateTime.Now.ToString("dd:MMM:yyyy hh:mm:ss")}</div>");
            sb.Append("<body><html>");

            var rawData = sb.ToString();
            var mailItem = await _schedularReportEmailRepository.GetMailRecipients(Constants_EmailReport.LateDeliveryReportConsumablesCBL);
            List<string> to = new List<string>();
            List<string> cc = new List<string>();
            List<string> bcc = new List<string>();
            to = mailItem.Item1;
            cc = mailItem.Item2;
            bcc = mailItem.Item3;

            //to.Add("akbar@comptexbd.com");
            //cc.Add("jobayershoaib@gmail.com");
            //cc.Add("jobayer@robintexbd.com");

            //email.Add("habib@robintexbd.com");
            //var mailBody = sb.ToString();
            var emailMessage = new EmailMessageAttachment($"Late Delivery Report Consumables, CBL. Date : {ReportDateMsg}", rawData, to, cc, bcc);
            try
            {
                await _emailSenderService.SendEmailAsync(emailMessage);
                _logger.LogInformation($"LateDeliveries_ConsumablesCBL Send at {DateTime.Now.ToString("dd MMM yyyy HH:mm:ss")}");
            }
            catch (Exception e)
            {
                var aa = e.Message;
                _logger.LogError(e, "LateDeliveries_ConsumablesCBL");
            }
        }

        public async Task LateDeliveries_ConsumablesRBL()
        {

            var ReportDateMsg = DateTime.Now.ToString("dd-MMM-yyyy");
            var rblCons = await _dailyMailMaterialManagementRepository.LateDeliveries_ConsumablesRBL();

            StringBuilder sb = new StringBuilder();
            string htmlBody = @$"<!DOCTYPE html>
                                    <head><meta content=""text/html; charset=utf-8"" http-equiv=""Content-Type"">
                                        <title> Late Delivery Report Consumables, RBL </title> 
                                    </head>";
            sb.AppendLine(htmlBody);
            sb.Append(@"<body style='font-size:13px;'>");

            if (rblCons.Count > 0)
            {
                sb.Append(@"<h2 style='text-align:center;padding-bottom:1px;margin-bottom:0px;'> Late Delivery Report Consumables, RBL </h2>");
                sb.Append(@$"<h4 style='text-align:center;padding-top:1px;padding-bottom:1px;margin-bottom:0px;;margin-top:1px;'>Reporting Date - {ReportDateMsg}</h4>");

                sb.Append(@"<table style='font-family: arial, sans-serif;border-collapse:collapse;font-size:9pt;width: 100%;'>");
                sb.Append(@"<thead style='text-align:center;'>");
                sb.Append("<tr>");
                /*
                Supplier PurchaseOrderNo PODate ItemName    POQuantity
                ReceivedQty BalanceToDeliver DeliveryDate    OverDue
                    */

                sb.Append("<th style='border:1px solid black;' width='3%'>SL#</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Supplier</ th>");
                sb.Append("<th style='border:1px solid black;' width=''>Purchase<br/>Order No</ th>");
                sb.Append("<th style='border:1px solid black;' width=''>Payment<br/>Mode</ th>");
                sb.Append("<th style='border:1px solid black;' width=''>PO Date</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Item</th>");
                sb.Append("<th style='border:1px solid black;' width=''>PO Quantity</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Received<br/>Qty</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Receivable<br/>Qty</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Receivable<br/> Date</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Exced<br/>Dayes</th>");
                sb.Append("</thead></tr>");
                int fsl = 1;
                string excedDaysStyle = "";
                string advancePOStyle = "";
                foreach (var ung in rblCons)
                {
                    excedDaysStyle = "";
                    advancePOStyle = ung.PaymentMode == "Advance" ? " background:#A52A2A;color:#fff" : "";
                    sb.Append("<tr>");

                    if (ung.OverDue >= 100)
                    {
                        excedDaysStyle = "background-color:#e60000;color:#fff";
                    }
                    else if (ung.OverDue > 75)
                    {
                        excedDaysStyle = "background-color:#ff4d4d;color:#111";
                    }
                    else if (ung.OverDue > 50)
                    {
                        excedDaysStyle = "background-color:#ff8080;color:#111";
                    }
                    else if (ung.OverDue > 25)
                    {
                        excedDaysStyle = "background-color:#ff9999;color:#111";
                    }
                    else if (ung.OverDue > 5)
                    {
                        excedDaysStyle = "background-color:#ffcccc;color:#111";
                    }
                    else
                    {
                        excedDaysStyle = "";
                    }

                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{fsl}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.Supplier}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.PurchaseOrderNo}</td>");
                    if (ung.AdvancePercentage == 0)
                    {
                        sb.Append($"<td style='border:1px solid black;text-align:center;{advancePOStyle}'>{ung.PaymentMode}</td>");
                    }
                    else
                    {
                        sb.Append($"<td style='border:1px solid black;text-align:center; {advancePOStyle};'title='PO Advance Payment:{ung.AdvancePercentage}'>{ung.PaymentMode}-{ung.AdvancePercentage}</td>");
                    }
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.PODate}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.ItemName}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", ung.POQuantity)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", ung.ReceivedQty)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;{excedDaysStyle}'>{String.Format("{0:n2}", ung.BalanceToDeliver)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.DeliveryDate}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;{excedDaysStyle}'><b>{ung.OverDue}</b></td>");
                    sb.Append("</tr>");

                    fsl++;
                }
                #region Total
                sb.Append("<tr>");
                sb.Append($"<th style='border:1px solid black;text-align:right;padding:4px;' colspan='6'>Total</th>");
                sb.Append($"<th style='border:1px solid black;text-align:right;font-size:8pt;'>{String.Format("{0:n2}", rblCons.Sum(b => b.POQuantity))}</th>");
                sb.Append($"<th style='border:1px solid black;text-align:right;font-size:8pt;'>{String.Format("{0:n2}", rblCons.Sum(b => b.ReceivedQty))}</th>");
                sb.Append($"<th style='border:1px solid black;text-align:right;font-size:8pt;'>{String.Format("{0:n2}", rblCons.Sum(b => b.BalanceToDeliver))}</th>");
                sb.Append($"<td style='border:1px solid black;text-align:center;'>&nbsp;</td>");
                sb.Append($"<td style='border:1px solid black;text-align:center;'>&nbsp;</td>");
                sb.Append("</tr>");

                #endregion Total 
                sb.Append("</table>");
            }
            else
            {
                sb.Append(@"<h2 style='text-align:center;padding-bottom:1px;margin-bottom:0px;'>No Late Delivery Report Consumables, RBL.  </h2>");
            }

            sb.Append(@$"<div style='margin-top:50px;background:#C0C0C0;color:#111;font-size:10px;'>ERP Automatic generated Report, Generated at : {DateTime.Now.ToString("dd:MMM:yyyy hh:mm:ss")}</div>");
            sb.Append("<body><html>");

            var rawData = sb.ToString();
            var mailItem = await _schedularReportEmailRepository.GetMailRecipients(Constants_EmailReport.LateDeliveryReportConsumablesRBL);
            List<string> to = new List<string>();
            List<string> cc = new List<string>();
            List<string> bcc = new List<string>();
            to = mailItem.Item1;
            cc = mailItem.Item2;
            bcc = mailItem.Item3;

            //to.Add("akbar@comptexbd.com");
            //cc.Add("jobayershoaib@gmail.com");
            //cc.Add("jobayer@robintexbd.com");

            //email.Add("habib@robintexbd.com");
            //var mailBody = sb.ToString();
            var emailMessage = new EmailMessageAttachment($"Late Delivery Report Consumables, RBL. Date : {ReportDateMsg}", rawData, to, cc, bcc);
            try
            {
                await _emailSenderService.SendEmailAsync(emailMessage);
                _logger.LogInformation($"LateDeliveries_ConsumablesRBL Send at {DateTime.Now.ToString("dd MMM yyyy HH:mm:ss")}");
            }
            catch (Exception e)
            {
                var aa = e.Message;
                _logger.LogError(e, "LateDeliveries_ConsumablesRBL");
            }
        }

        public async Task LateDeliveries_HNM()
        {
            var ReportDateMsg = DateTime.Now.ToString("dd-MMM-yyyy");
            var poQtyOther = await _dailyMailMaterialManagementRepository.LateDeliveries_HNM();

            StringBuilder sb = new StringBuilder();
            string htmlBody = @$"<!DOCTYPE html>
                                    <head><meta content=""text/html; charset=utf-8"" http-equiv=""Content-Type"">
                                        <title> Late Delivery Report Accessories, HnM </title> 
                                    </head>";
            sb.AppendLine(htmlBody);
            sb.Append(@"<body style='font-size:13px;'>");

            if (poQtyOther.Count > 0)
            {
                sb.Append(@"<h2 style='text-align:center;padding-bottom:1px;margin-bottom:0px;'> Late Delivery Report Accessories, HnM </h2>");
                sb.Append(@$"<h4 style='text-align:center;padding-top:1px;padding-bottom:1px;margin-bottom:0px;;margin-top:1px;'>Reporting Date - {ReportDateMsg}</h4>");

                sb.Append(@"<table style='font-family: arial, sans-serif;border-collapse:collapse;font-size:9pt;width: 100%;'>");
                sb.Append(@"<thead style='text-align:center;'>");
                sb.Append("<tr>");
                //OrderNo Supplier    PurchaseOrderNo PODate  MRPItemCode ItemName    ItemType Material  
                //    POQuantity BalanceToDeliver    DeliveryDate OverDue Remarks

                sb.Append("<th style='border:1px solid black;' width='3%'>SL#</th>");
                sb.Append("<th style='border:1px solid black;' width=''>OrderNo</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Supplier</ th>");
                sb.Append("<th style='border:1px solid black;' width=''>Purchase<br/>Order No</ th>");
                sb.Append("<th style='border:1px solid black;' width=''>Payment<br/>Mode</ th>");
                sb.Append("<th style='border:1px solid black;' width=''>PO Date</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Code</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Item</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Type</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Material</th>");
                sb.Append("<th style='border:1px solid black;' width=''>PO Quantity</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Receivable<br/>Qty</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Receivable<br/> Date</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Exced<br/>Dayes</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Remarks</th>");
                sb.Append("</thead></tr>");
                int fsl = 1;
                string excedDaysStyle = "";
                string advancePOStyle="";
                foreach (var ung in poQtyOther)
                {
                    excedDaysStyle = "";
                    advancePOStyle = ung.PaymentMode == "Advance" ? " background:#A52A2A;color:#fff" : "";
                    sb.Append("<tr>");
                    if (ung.OverDue >= 100)
                    {
                        excedDaysStyle = "background-color:#e60000;color:#fff";
                    }
                    else if (ung.OverDue > 75)
                    {
                        excedDaysStyle = "background-color:#ff4d4d;color:#111";
                    }
                    else if (ung.OverDue > 50)
                    {
                        excedDaysStyle = "background-color:#ff8080;color:#111";
                    }
                    else if (ung.OverDue > 25)
                    {
                        excedDaysStyle = "background-color:#ff9999;color:#111";
                    }
                    else if (ung.OverDue > 5)
                    {
                        excedDaysStyle = "background-color:#ffcccc;color:#111";
                    }
                    else
                    {
                        excedDaysStyle = "";
                    }

                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{fsl}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.OrderNo}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.Supplier}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.PurchaseOrderNo}</td>");
                    if (ung.AdvancePercentage == 0)
                    {
                        sb.Append($"<td style='border:1px solid black;text-align:center;{advancePOStyle}'>{ung.PaymentMode}</td>");
                    }
                    else
                    {
                        sb.Append($"<td style='border:1px solid black;text-align:center; {advancePOStyle};'title='PO Advance Payment:{ung.AdvancePercentage}'>{ung.PaymentMode}-{ung.AdvancePercentage}</td>");
                    }
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.PODate}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.MRPItemCode}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.ItemName}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.ItemType}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.Material}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", ung.POQuantity)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;{excedDaysStyle}'>{String.Format("{0:n2}", ung.BalanceToDeliver)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.DeliveryDate}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;{excedDaysStyle}'><b>{ung.OverDue}</b></td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.Remarks}</td>");

                    sb.Append("</tr>");

                    fsl++;
                }
                #region Total
                sb.Append("<tr>");
                sb.Append($"<th style='border:1px solid black;text-align:right;padding:4px;' colspan='10'>Total</th>");
                sb.Append($"<th style='border:1px solid black;text-align:right;font-size:8pt;'>{String.Format("{0:n2}", poQtyOther.Sum(b => b.POQuantity))}</th>");
                sb.Append($"<th style='border:1px solid black;text-align:right;font-size:8pt;'>{String.Format("{0:n2}", poQtyOther.Sum(b => b.BalanceToDeliver))}</th>");
                sb.Append($"<td style='border:1px solid black;text-align:center;'>&nbsp;</td>");
                sb.Append($"<td style='border:1px solid black;text-align:center;'>&nbsp;</td>");
                sb.Append($"<td style='border:1px solid black;text-align:center;'>&nbsp;</td>");
                sb.Append("</tr>");

                #endregion Total 
                sb.Append("</table>");
            }
            else
            {
                sb.Append(@"<h2 style='text-align:center;padding-bottom:1px;margin-bottom:0px;'>No Late Delivery Report Accessories, Rest Of Buyer(s) found.  </h2>");
            }

            sb.Append(@$"<div style='margin-top:50px;background:#C0C0C0;color:#111;font-size:10px;'>ERP Automatic generated Report, Generated at : {DateTime.Now.ToString("dd:MMM:yyyy hh:mm:ss")}</div>");
            sb.Append("<body><html>");

            var rawData = sb.ToString();
            var mailItem = await _schedularReportEmailRepository.GetMailRecipients(Constants_EmailReport.LateDeliveryReportAccessoriesHnm);
            List<string> to = new List<string>();
            List<string> cc = new List<string>();
            List<string> bcc = new List<string>();
            to = mailItem.Item1;
            cc = mailItem.Item2;
            bcc = mailItem.Item3;

            //to.Add("akbar@comptexbd.com");
            //cc.Add("jobayershoaib@gmail.com");
            //cc.Add("jobayer@robintexbd.com");

            //email.Add("habib@robintexbd.com");
            //var mailBody = sb.ToString();
            var emailMessage = new EmailMessageAttachment($"Late Delivery Report Accessories, HnM. Date : {ReportDateMsg}", rawData, to, cc, bcc);
            try
            {
                await _emailSenderService.SendEmailAsync(emailMessage);
                _logger.LogInformation($"LateDeliveries_HNM Send at {DateTime.Now.ToString("dd MMM yyyy HH:mm:ss")}");
            }
            catch (Exception e)
            {
                var aa = e.Message;
                _logger.LogError(e, "LateDeliveries_HNM");
            }
        }

        public async Task LateDeliveries_Others()
        {
            var ReportDateMsg = DateTime.Now.ToString("dd-MMM-yyyy");
            var poQtyOther = await _dailyMailMaterialManagementRepository.LateDeliveries_Others();

            StringBuilder sb = new StringBuilder();
            string htmlBody = @$"<!DOCTYPE html>
                                    <head><meta content=""text/html; charset=utf-8"" http-equiv=""Content-Type"">
                                        <title> Late Delivery Report Accessories, Rest Of Buyer(s). </title> 
                                    </head>";
            sb.AppendLine(htmlBody);
            sb.Append(@"<body style='font-size:13px;'>");

            if (poQtyOther.Count > 0)
            {
                sb.Append(@"<h2 style='text-align:center;padding-bottom:1px;margin-bottom:0px;'> Late Delivery Report Accessories, Rest Of Buyer(s)   </h2>");
                sb.Append(@$"<h4 style='text-align:center;padding-top:1px;padding-bottom:1px;margin-bottom:0px;;margin-top:1px;'>Reporting Date - {ReportDateMsg}</h4>");

                sb.Append(@"<table style='font-family: arial, sans-serif;border-collapse:collapse;font-size:9pt;width: 100%;'>");
                sb.Append(@"<thead style='text-align:center;'>");
                sb.Append("<tr>");
                //OrderNo Supplier    PurchaseOrderNo PODate  MRPItemCode ItemName    ItemType Material  
                //    POQuantity BalanceToDeliver    DeliveryDate OverDue Remarks

                sb.Append("<th style='border:1px solid black;' width='3%'>SL#</th>");
                sb.Append("<th style='border:1px solid black;' width=''>OrderNo</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Supplier</ th>");
                sb.Append("<th style='border:1px solid black;' width=''>Purchase<br/>Order No</ th>");
                sb.Append("<th style='border:1px solid black;' width=''>Payment<br/>Mode</th>");
                sb.Append("<th style='border:1px solid black;' width=''>PO Date</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Code</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Item</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Type</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Material</th>");
                sb.Append("<th style='border:1px solid black;' width=''>PO Quantity</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Receivable<br/>Qty</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Receivable<br/> Date</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Exced<br/>Dayes</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Remarks</th>");
                sb.Append("</thead></tr>");
                int fsl = 1;
                string excedDaysStyle = "";
                string advancePOStyle = "";
                foreach (var ung in poQtyOther)
                {
                    excedDaysStyle = "";
                    advancePOStyle = ung.PaymentMode == "Advance" ? " background:#A52A2A;color:#fff" : "";
                    sb.Append("<tr>");

                    if (ung.OverDue >= 100)
                    {
                        excedDaysStyle = "background-color:#e60000;color:#fff";
                    }
                    else if (ung.OverDue > 75)
                    {
                        excedDaysStyle = "background-color:#ff4d4d;color:#111";
                    }
                    else if (ung.OverDue > 50)
                    {
                        excedDaysStyle = "background-color:#ff8080;color:#111";
                    }
                    else if (ung.OverDue > 25)
                    {
                        excedDaysStyle = "background-color:#ff9999;color:#111";
                    }
                    else if (ung.OverDue > 5)
                    {
                        excedDaysStyle = "background-color:#ffcccc;color:#111";
                    }
                    else
                    {
                        excedDaysStyle = "";
                    }

                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{fsl}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.OrderNo}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.Supplier}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.PurchaseOrderNo}</td>");
                    if (ung.AdvancePercentage == 0)
                    {
                        sb.Append($"<td style='border:1px solid black;text-align:center;{advancePOStyle}'>{ung.PaymentMode}</td>");
                    }
                    else
                    {
                        sb.Append($"<td style='border:1px solid black;text-align:center; {advancePOStyle};'title='PO Advance Payment:{ung.AdvancePercentage}'>{ung.PaymentMode}-{ung.AdvancePercentage}</td>");
                    }
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.PODate}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.MRPItemCode}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.ItemName}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.ItemType}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.Material}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", ung.POQuantity)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;{excedDaysStyle}'>{String.Format("{0:n2}", ung.BalanceToDeliver)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.DeliveryDate}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;{excedDaysStyle}'><b>{ung.OverDue}</b></td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.Remarks}</td>");

                    sb.Append("</tr>");

                    fsl++;
                }
                #region Total
                sb.Append("<tr>");
                sb.Append($"<th style='border:1px solid black;text-align:right;padding:4px;' colspan='10'>Total</th>");
                sb.Append($"<th style='border:1px solid black;text-align:right;font-size:8pt;'>{String.Format("{0:n2}", poQtyOther.Sum(b => b.POQuantity))}</th>");
                sb.Append($"<th style='border:1px solid black;text-align:right;font-size:8pt;'>{String.Format("{0:n2}", poQtyOther.Sum(b => b.BalanceToDeliver))}</th>");
                sb.Append($"<td style='border:1px solid black;text-align:center;'>&nbsp;</td>");
                sb.Append($"<td style='border:1px solid black;text-align:center;'>&nbsp;</td>");
                sb.Append($"<td style='border:1px solid black;text-align:center;'>&nbsp;</td>");
                sb.Append("</tr>");

                #endregion Total 
                sb.Append("</table>");
            }
            else
            {
                sb.Append(@"<h2 style='text-align:center;padding-bottom:1px;margin-bottom:0px;'>No Late Delivery Report Accessories, Rest Of Buyer(s) found.  </h2>");
            }

            sb.Append(@$"<div style='margin-top:50px;background:#C0C0C0;color:#111;font-size:10px;'>ERP Automatic generated Report, Generated at : {DateTime.Now.ToString("dd:MMM:yyyy hh:mm:ss")}</div>");
            sb.Append("<body><html>");

            var rawData = sb.ToString();
            var mailItem = await _schedularReportEmailRepository.GetMailRecipients(Constants_EmailReport.LateDeliveryReportAccessoriesResOfBuyer);
            List<string> to = new List<string>();
            List<string> cc = new List<string>();
            List<string> bcc = new List<string>();
            to = mailItem.Item1;
            cc = mailItem.Item2;
            bcc = mailItem.Item3;

            //to.Add("akbar@comptexbd.com");
            //cc.Add("jobayershoaib@gmail.com");
            //cc.Add("jobayer@robintexbd.com");

            //email.Add("habib@robintexbd.com");
            //var mailBody = sb.ToString();
            var emailMessage = new EmailMessageAttachment($"Late Delivery Report Accessories, Rest Of Buyer(s). Date : {ReportDateMsg}", rawData, to, cc, bcc);
            try
            {
                await _emailSenderService.SendEmailAsync(emailMessage);
                _logger.LogInformation($"LateDeliveries_Others Send at {DateTime.Now.ToString("dd MMM yyyy HH:mm:ss")}");
            }
            catch (Exception e)
            {
                var aa = e.Message;
                _logger.LogError(e, "LateDeliveries_Others");
            }

        }

        public async Task OverdueHnMInvoicesNotification()
        {
            var hnmOverDueInvoice = await _dailyMailEMSRepository.OverdueHnMInvoicesNotification();
            var ReportDateMsg = DateTime.Now.ToString("dd-MMM-yyyy");
            if (hnmOverDueInvoice.Count > 0)
            {
                var rblInvoice = hnmOverDueInvoice.Where(b => b.CompanyID == 183).ToList();
                var cblInvoice = hnmOverDueInvoice.Where(b => b.CompanyID == 20183).ToList();

                StringBuilder sb = new StringBuilder();
                string htmlBody = @$"<!DOCTYPE html>
                                    <head><meta content=""text/html; charset=utf-8"" http-equiv=""Content-Type"">
                                        <title>Overdue HnM Invoices Notification  {ReportDateMsg} [Auto Generated ERP Report]</title> 
                                    </head>";
                sb.AppendLine(htmlBody);
                sb.Append(@"<body style='font-size:13px;'>");
                sb.Append(@"<h2 style='text-align:center;padding-bottom:1px;margin-bottom:0px;'>Overdue HnM Invoices Notification </h2>");
                sb.Append(@$"<h3 style='text-align:center;padding-top:1px;padding-bottom:1px;margin-bottom:0px;;margin-top:1px;'>Notification is based on 21-days after Documents Submission to the Buyer</h3>");
                sb.Append(@$"<h4 style='text-align:center;padding-top:1px;padding-bottom:1px;margin-bottom:0px;;margin-top:1px;'>Date:{ReportDateMsg}</h4>");
                /*
                 sb.Append(@$"<div style='font-size:14px;font-weight:bold;background-color:#EDE6D6;'>
                          <div style='width:30%;Float:left !important;padding-Top:5px;padding-bottom:5px;'>Sub-Contact : {String.Format("{0:n2}", subContactList.Sum(b => b.TotalQty))}</div>");
                 sb.Append(@$"<div style='width:30%;Float:left !important;padding-Top:5px;padding-bottom:5px;'>In-House : {String.Format("{0:n2}", InHouseList.Sum(b => b.TotalQty))}</div>");
                 sb.Append(@$"<div style='width:30%;Float:left !important;padding-Top:5px;padding-bottom:5px;'>Total Production : {String.Format("{0:n2}", data.Sum(b => b.TotalQty))}</div></div><br/>");
                 */
                sb.Append(@"<table style='font-family: arial, sans-serif;border-collapse:collapse;font-size:9pt;width: 100%;'>");
                sb.Append(@"<thead style='text-align:center;'>");
                sb.Append("<tr style='border:0px;'><th colspan='14' style='border:0px;text-align:left;'>Robintex Banngladesh Limited</th></tr>");
                sb.Append("<tr>");
                sb.Append("<th style='border:1px solid black;' width='3%'>SL#</th>");
                //S.No	Period 	Country 	Order	Invoice Number 	Invoice Date 	Shipment Mode 	
                //Ex-Factory 	Submission 	Invoice Value 	Received Amount 	Balance 	Received Date 	OverDue Days 	Remarks 
                sb.Append("<th style='border:1px solid black;' width=''>Period</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Country</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Order</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Invoice Number</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Invoice Date</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Shipment Mode</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Ex-Factory</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Submission</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Invoice Value</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Received Amount</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Balance</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Received Date</ th>");
                sb.Append("<th style='border:1px solid black;' width=''>Over Due<br/>Dayes</ th>");
                sb.Append("<th style='border:1px solid black;' width=''>Remarks</ th>");
                sb.Append("</thead></tr>");
                int fsl = 1;

                //RBL
                foreach (var sub in rblInvoice)
                {
                    sb.Append("<tr>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{fsl}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{sub.Period_Name}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{sub.EPIM_SHIPEDTO}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{sub.OrderNo}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{sub.EPIM_INVOICENO}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{sub.EPIM_DATE}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{sub.EPM_SHIPMENTMODE}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{sub.ExFactoryDate}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{sub.SubmissionDate}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{String.Format("{0:n2}", sub.EPIM_AMOUNT)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{String.Format("{0:n2}", sub.Received)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{String.Format("{0:n2}", (sub.EPIM_AMOUNT - (decimal)sub.Received))}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{sub.Paymentdate}</td>");
                    if (sub.Overdue > 100)
                    {
                        sb.Append($"<th style='border:1px solid red;text-align:center;'>{sub.Overdue}</th>");
                    }
                    else
                    {
                        sb.Append($"<td style='border:1px solid black;text-align:center;'>{sub.Overdue}</td>");
                    }
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{sub.Remarks}</td>");
                    sb.Append("</tr>");

                    fsl++;
                }
                if (rblInvoice.Count == 0)
                {
                    sb.Append("<tr><td colspan='15' style='border:1px solid #222;color:red;'>No Data Found</td></tr>");
                }
                //  


                fsl = 1;
                sb.Append("<tr style='border:0px;'><td colspan='15' style='border:0px;'>&nbsp;</td></tr>");
                sb.Append("<tr style='border:0px;'><th colspan='15' style='border:0px;text-align:left;'>Comptex Bangladesh Limited</th></tr>");

                //CBL
                foreach (var inh in cblInvoice)
                {
                    sb.Append("<tr>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{fsl}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{inh.Period_Name}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{inh.EPIM_SHIPEDTO}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{inh.OrderNo}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{inh.EPIM_INVOICENO}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{inh.EPIM_DATE}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{inh.EPM_SHIPMENTMODE}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{inh.ExFactoryDate}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{inh.SubmissionDate}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{String.Format("{0:n2}", inh.EPIM_AMOUNT)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{String.Format("{0:n2}", inh.Received)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{String.Format("{0:n2}", (inh.EPIM_AMOUNT - (decimal)inh.Received))}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{inh.Paymentdate}</td>");
                    if (inh.Overdue > 100)
                    {
                        sb.Append($"<th style='border:1px solid red;text-align:center;background:#FFE4E1'>{inh.Overdue}</th>");
                    }
                    else
                    {
                        sb.Append($"<td style='border:1px solid black;text-align:center;'>{inh.Overdue}</td>");
                    }

                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{inh.Remarks}</td>");
                    sb.Append("</tr>");

                    fsl++;
                }


                sb.Append("</table>");

                sb.Append(@$"<div style='margin-top:50px;background:#C0C0C0;color:#111;font-size:10px;'>ERP Automatic generated Report, Generated at : {DateTime.Now.ToString("dd:MMM:yyyy hh:mm:ss")}</div>");
                sb.Append("<body><html>");

                var rawData = sb.ToString();
                var mailItem = await _schedularReportEmailRepository.GetMailRecipients(Constants_EmailReport.OverdueHnMInvoicesNotification);
                List<string> to = new List<string>();
                List<string> cc = new List<string>();
                List<string> bcc = new List<string>();
                to = mailItem.Item1;
                cc = mailItem.Item2;
                bcc = mailItem.Item3;

                //to.Add("akbar@comptexbd.com");
                //cc.Add("jobayershoaib@gmail.com");
                //cc.Add("jobayer@robintexbd.com");

                //email.Add("habib@robintexbd.com");
                //var mailBody = sb.ToString();
                var emailMessage = new EmailMessageAttachment($"Overdue HnM Invoices Notification Date:{ReportDateMsg}", rawData, to, cc, bcc);
                try
                {

                    await _emailSenderService.SendEmailAsync(emailMessage);
                    _logger.LogInformation($"OverdueHnMInvoicesNotification Mail Send at {DateTime.Now:dd MMM yyyy HH:mm:ss}");
                }
                catch (Exception e)
                {
                    var aa = e.Message;
                    _logger.LogError(e, "OverdueHnMInvoicesNotification");
                }
            }
        }

        public async Task PendingDyeingLotsCBL(DateTime DateFrom)
        {
            var cblLot = await _dailyMailMaterialManagementRepository.PendingDyeingLotsCBL(DateFrom);

            var ReportDateMsg = DateFrom.ToString("dd-MMM-yyyy");

            StringBuilder sb = new StringBuilder();
            string htmlBody = @$"<!DOCTYPE html>
                                    <head><meta content=""text/html; charset=utf-8"" http-equiv=""Content-Type"">
                                        <title> Sub Contract GatePass Report. </title> 
                                    </head>";
            sb.AppendLine(htmlBody);
            sb.Append(@"<body style='font-size:13px;'>");

            if (cblLot.Count > 0)
            {
                sb.Append(@"<h2 style='text-align:center;padding-bottom:1px;margin-bottom:0px;'> Pending Dyeing Lots  </h2>");
                sb.Append($@"<h4 style='text-align:center;padding-top:1px;padding-bottom:1px;margin-bottom:0px;;margin-top:1px;'>{cblLot[0].Companyname}</h4>");
                sb.Append(@$"<h4 style='text-align:center;padding-top:1px;padding-bottom:1px;margin-bottom:0px;;margin-top:1px;'>Reporting Date - {ReportDateMsg}</h4>");

                sb.Append(@"<table style='font-family: arial, sans-serif;border-collapse:collapse;font-size:9pt;width: 100%;'>");
                sb.Append(@"<thead style='text-align:center;'>");
                sb.Append("<tr>");
                sb.Append("<th style='border:1px solid black;' width='3%'>SL#</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Buyer</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Order</ th>");
                sb.Append("<th style='border:1px solid black;' width=''>Lot No</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Color</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Machine</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Greige Qty</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Lot Date</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Finish Qty</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Delivered</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Overdue Days</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Remarks</th>");
                sb.Append("</thead></tr>");
                int fsl = 1;
                string overDuestyle = "";
                foreach (var rtn in cblLot)
                {
                    overDuestyle = "";
                    sb.Append("<tr>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{fsl}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{rtn.BuyerName}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{rtn.OrderNo}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{rtn.LotNo}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{rtn.Color}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{rtn.Machine}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", rtn.GreigeQty)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{rtn.LotDate}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", rtn.FinishQty)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", rtn.Delivered)}</td>");
                    if (rtn.Overdue >= 150)
                    {
                        overDuestyle = "background-color:#e60000;color:#fff";
                    }
                    else if (rtn.Overdue > 99)
                    {
                        overDuestyle = "background-color:#ff4d4d;color:#111";
                    }
                    else if (rtn.Overdue > 49)
                    {
                        overDuestyle = "background-color:#ff8080;color:#111";
                    }
                    else if (rtn.Overdue > 15)
                    {
                        overDuestyle = "background-color:#ff9999;color:#111";
                    }
                    else if (rtn.Overdue > 5)
                    {
                        overDuestyle = "background-color:#ffcccc;color:#111";
                    }
                    else
                    {
                        overDuestyle = "";
                    }
                    sb.Append($"<td style='border:1px solid black;text-align:center;{overDuestyle}'>{rtn.Overdue}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{rtn.Remarks}</td>");

                    sb.Append("</tr>");

                    fsl++;
                }

                /* Start Total */
                sb.Append("<tr style='font-size:10px;'>");
                sb.Append($"<th style='border:1px solid black;text-align:right;' colspan='6'>Total</th>");
                sb.Append($"<th style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", cblLot.Sum(s => s.GreigeQty))}</th>");
                sb.Append($"<td style='border:1px solid black;text-align:center;'>&nbsp;</td>");
                sb.Append($"<th style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", cblLot.Sum(s => s.FinishQty))}</th>");
                sb.Append($"<th style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", cblLot.Sum(s => s.Delivered))}</th>");
                sb.Append($"<td style='border:1px solid black;text-align:center;'>&nbsp;</td>");
                sb.Append($"<td style='border:1px solid black;text-align:center;'>&nbsp;</td>");
                sb.Append("</tr>");
                /* End Total */

                sb.Append("</table>");
            }
            else
            {
                sb.Append(@"<h2 style='text-align:center;padding-bottom:1px;margin-bottom:0px;'>No data found in CBL dying Lot </h2>");
            }

            sb.Append(@$"<div style='margin-top:50px;background:#C0C0C0;color:#111;font-size:10px;'>ERP Automatic generated Report, Generated at : {DateTime.Now.ToString("dd:MMM:yyyy hh:mm:ss")}</div>");
            sb.Append("<body><html>");

            var rawData = sb.ToString();
            var mailItem = await _schedularReportEmailRepository.GetMailRecipients(Constants_EmailReport.CBLPendingDyeingLot);
            List<string> to = new List<string>();
            List<string> cc = new List<string>();
            List<string> bcc = new List<string>();
            to = mailItem.Item1;
            cc = mailItem.Item2;
            bcc = mailItem.Item3;

            //to.Add("akbar@comptexbd.com");
            //cc.Add("jobayershoaib@gmail.com");
            //cc.Add("jobayer@robintexbd.com");

            //email.Add("habib@robintexbd.com");
            //var mailBody = sb.ToString();
            var emailMessage = new EmailMessageAttachment($"ERP Report For CBL Pending Dyeing Lots Date : {ReportDateMsg}", rawData, to, cc, bcc);
            try
            {
                await _emailSenderService.SendEmailAsync(emailMessage);
                _logger.LogInformation($"SubContractGatePass Mail Send at {DateTime.Now.ToString("dd MMM yyyy HH:mm:ss")}");
            }
            catch (Exception e)
            {
                var aa = e.Message;
                _logger.LogError(e, "SubContractGatePass");
            }
        }

        public async Task PendingDyeingLotsRBL(DateTime DateFrom)
        {
            var rblLot = await _dailyMailMaterialManagementRepository.PendingDyeingLotsRBL(DateFrom);

            var ReportDateMsg = DateFrom.ToString("dd-MMM-yyyy");

            StringBuilder sb = new StringBuilder();
            string htmlBody = @$"<!DOCTYPE html>
                                    <head><meta content=""text/html; charset=utf-8"" http-equiv=""Content-Type"">
                                        <title> Sub Contract GatePass Report. </title> 
                                    </head>";
            sb.AppendLine(htmlBody);
            sb.Append(@"<body style='font-size:13px;'>");
            if (rblLot.Count > 0)
            {
                sb.Append(@"<h2 style='text-align:center;padding-bottom:1px;margin-bottom:0px;'> Pending Dyeing Lots  </h2>");
                sb.Append($@"<h4 style='text-align:center;padding-top:1px;padding-bottom:1px;margin-bottom:0px;;margin-top:1px;'>{rblLot[0].Companyname}</h4>");
                sb.Append(@$"<h4 style='text-align:center;padding-top:1px;padding-bottom:1px;margin-bottom:0px;;margin-top:1px;'>Reporting Date - {ReportDateMsg}</h4>");

                sb.Append(@"<table style='font-family: arial, sans-serif;border-collapse:collapse;font-size:9pt;width: 100%;'>");
                sb.Append(@"<thead style='text-align:center;'>");
                sb.Append("<tr>");
                sb.Append("<th style='border:1px solid black;' width='3%'>SL#</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Buyer</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Order</ th>");
                sb.Append("<th style='border:1px solid black;' width=''>Lot No</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Color</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Machine</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Greige Qty</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Lot Date</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Finish Qty</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Delivered</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Overdue Days</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Remarks</th>");
                sb.Append("</thead></tr>");
                int fsl = 1;
                string overDuestyle = "";
                foreach (var rtn in rblLot)
                {
                    overDuestyle = "";
                    sb.Append("<tr>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{fsl}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{rtn.BuyerName}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{rtn.OrderNo}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{rtn.LotNo}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{rtn.Color}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{rtn.Machine}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", rtn.GreigeQty)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{rtn.LotDate}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", rtn.FinishQty)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", rtn.Delivered)}</td>");
                    if (rtn.Overdue >= 150)
                    {
                        overDuestyle = "background-color:#e60000;color:#fff";
                    }
                    else if (rtn.Overdue > 99)
                    {
                        overDuestyle = "background-color:#ff4d4d;color:#111";
                    }
                    else if (rtn.Overdue > 49)
                    {
                        overDuestyle = "background-color:#ff8080;color:#111";
                    }
                    else if (rtn.Overdue > 15)
                    {
                        overDuestyle = "background-color:#ff9999;color:#111";
                    }
                    else if (rtn.Overdue > 5)
                    {
                        overDuestyle = "background-color:#ffcccc;color:#111";
                    }
                    else
                    {
                        overDuestyle = "";
                    }
                    sb.Append($"<td style='border:1px solid black;text-align:center;{overDuestyle}'>{rtn.Overdue}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{rtn.Remarks}</td>");

                    sb.Append("</tr>");

                    fsl++;
                }

                /* Start Total */
                sb.Append("<tr style='font-size:10px;'>");
                sb.Append($"<th style='border:1px solid black;text-align:right;' colspan='6'>Total</th>");
                sb.Append($"<th style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", rblLot.Sum(s => s.GreigeQty))}</th>");
                sb.Append($"<td style='border:1px solid black;text-align:center;'>&nbsp;</td>");
                sb.Append($"<th style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", rblLot.Sum(s => s.FinishQty))}</th>");
                sb.Append($"<th style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", rblLot.Sum(s => s.Delivered))}</th>");
                sb.Append($"<td style='border:1px solid black;text-align:center;'>&nbsp;</td>");
                sb.Append($"<td style='border:1px solid black;text-align:center;'>&nbsp;</td>");
                sb.Append("</tr>");
                /* End Total */

                sb.Append("</table>");
            }
            else
            {
                sb.Append(@$"<div style='margin-top:50px;background:#C0C0C0;color:#111;font-size:10px;'>No Data Found.</div>");
            }


            sb.Append("<body><html>");

            var rawData = sb.ToString();
            var mailItem = await _schedularReportEmailRepository.GetMailRecipients(Constants_EmailReport.RBLPendingDyeingLot);
            List<string> to = new List<string>();
            List<string> cc = new List<string>();
            List<string> bcc = new List<string>();
            to = mailItem.Item1;
            cc = mailItem.Item2;
            bcc = mailItem.Item3;

            //to.Add("akbar@comptexbd.com");
            //cc.Add("jobayershoaib@gmail.com");
            //cc.Add("jobayer@robintexbd.com");

            //email.Add("habib@robintexbd.com");
            //var mailBody = sb.ToString();
            var emailMessage = new EmailMessageAttachment($"ERP Report For RBL Pending Dyeing Lots Date : {ReportDateMsg}", rawData, to, cc, bcc);
            try
            {
                if (rblLot.Count > 0)
                {
                    await _emailSenderService.SendEmailAsync(emailMessage);
                }

                _logger.LogInformation($"SubContractGatePass Mail Send at {DateTime.Now.ToString("dd MMM yyyy HH:mm:ss")}");
            }
            catch (Exception e)
            {
                var aa = e.Message;
                _logger.LogError(e, "SubContractGatePass");
            }
        }

        public async Task SubContractGatePass(DateTime? stdate = null, DateTime? todate = null)
        {
            if (stdate == null)
            {
                stdate = DateTime.Now.AddDays(-1).Date;
                todate = DateTime.Now.AddDays(-1).Date;
            }
            var dataRtnable = await _dailyMailFiniteSchedulerRepository.SubContractGatePass(stdate, todate);
            var ReportDateMsg = stdate.Value.ToString("dd-MMM-yyyy");

            StringBuilder sb = new StringBuilder();
            string htmlBody = @$"<!DOCTYPE html>
                                    <head><meta content=""text/html; charset=utf-8"" http-equiv=""Content-Type"">
                                        <title> Sub Contract GatePass Report. </title> 
                                    </head>";
            sb.AppendLine(htmlBody);
            sb.Append(@"<body style='font-size:13px;'>");

            if (dataRtnable.Count > 0)
            {


                sb.Append(@"<h2 style='text-align:center;padding-bottom:1px;margin-bottom:0px;'> Sub-Contract Returnable Gatepass. </h2>");
                sb.Append(@$"<h4 style='text-align:center;padding-top:1px;padding-bottom:1px;margin-bottom:0px;;margin-top:1px;'>Date:{ReportDateMsg}</h4>");

                sb.Append(@"<table style='font-family: arial, sans-serif;border-collapse:collapse;font-size:9pt;width: 100%;'>");
                sb.Append(@"<thead style='text-align:center;'>");
                sb.Append("<tr>");
                sb.Append("<th style='border:1px solid black;' width='3%'>SL#</th>");
                sb.Append("<th style='border:1px solid black;' width=''>GP No</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Created By</ th>");
                sb.Append("<th style='border:1px solid black;' width=''>Vehicle No </th>");
                sb.Append("<th style='border:1px solid black;' width=''>Issued To</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Representative </th>");
                sb.Append("<th style='border:1px solid black;' width=''>Contact</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Item Name </th>");
                sb.Append("<th style='border:1px solid black;' width=''>Quantity </th>");
                sb.Append("<th style='border:1px solid black;' width=''>Unit</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Remarks</th>");
                sb.Append("</thead></tr>");
                int fsl = 1;
                foreach (var rtn in dataRtnable)
                {
                    sb.Append("<tr>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{fsl}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{rtn.Serial}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{rtn.EmployeeName}<br/><b>{rtn.DepartmentName}</b></td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{rtn.VehicleNo}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{rtn.IssuedTo}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{rtn.Representative}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{rtn.RepresentativeContact}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{rtn.ItemName}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{String.Format("{0:n2}", rtn.Quantity > 0 ? rtn.Quantity : rtn.GrossWeight)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{rtn.Unit}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{rtn.Remarks}</td>");

                    sb.Append("</tr>");

                    fsl++;
                }


                sb.Append("</tr>");
                sb.Append("</table>");
            }
            else
            {
                sb.Append(@"<h2 style='text-align:center;padding-bottom:1px;margin-bottom:0px;'>No data found in returnable gatepass </h2>");
            }

            sb.Append(@$"<div style='margin-top:50px;background:#C0C0C0;color:#111;font-size:10px;'>ERP Automatic generated Report, Generated at : {DateTime.Now.ToString("dd:MMM:yyyy hh:mm:ss")}</div>");
            sb.Append("<body><html>");

            var rawData = sb.ToString();
            var mailItem = await _schedularReportEmailRepository.GetMailRecipients(Constants_EmailReport.SubContractReturnableGatepass);
            List<string> to = new List<string>();
            List<string> cc = new List<string>();
            List<string> bcc = new List<string>();
            to = mailItem.Item1;
            cc = mailItem.Item2;
            bcc = mailItem.Item3;

            //to.Add("akbar@comptexbd.com");
            //cc.Add("jobayershoaib@gmail.com");
            //cc.Add("jobayer@robintexbd.com");

            //email.Add("habib@robintexbd.com");
            //var mailBody = sb.ToString();
            var emailMessage = new EmailMessageAttachment($"ERP Report For Sub-Contract Returnable Gatepass Date:{ReportDateMsg}", rawData, to, cc, bcc);
            try
            {
                await _emailSenderService.SendEmailAsync(emailMessage);
                _logger.LogInformation($"SubContractGatePass Mail Send at {DateTime.Now.ToString("dd MMM yyyy HH:mm:ss")}");
            }
            catch (Exception e)
            {
                var aa = e.Message;
                _logger.LogError(e, "SubContractGatePass");
            }
        }

        public async Task Top_Cutting_Defects(DateTime? DtFrom = null, DateTime? DtTo = null)
        { 
            var ReportDateMsg = DtFrom.Value.ToString("dd-MMM-yyyy");
            var knittingPerformance = await _dailyMailFiniteSchedulerRepository.Top_Cutting_Defects(DtFrom, DtTo);
            //IE Report-2, Daily Knitting Shift & Machine Wise Knitting Defect(s)
            var rawData = knittingPerformance.Select(s => s.ReportData).FirstOrDefault();
            var mailItem = await _schedularReportEmailRepository.GetMailRecipients(Constants_EmailReport.TopCuttingDefectsNotification);
            List<string> to = new List<string>();
            List<string> cc = new List<string>();
            List<string> bcc = new List<string>();
            to = mailItem.Item1;
            cc = mailItem.Item2;
            bcc = mailItem.Item3;

            //to.Add("akbar@comptexbd.com");
            //cc.Add("jobayershoaib@gmail.com");
            //cc.Add("jobayer@robintexbd.com"); 
            //email.Add("habib@robintexbd.com");
            //var mailBody = sb.ToString();
            var emailMessage = new EmailMessageAttachment($"Top Cutting Defects Notification, Date:{ReportDateMsg}", rawData, to, cc, bcc);
            try
            {

                await _emailSenderService.SendEmailAsync(emailMessage);
                _logger.LogInformation($"Top_Cutting_Defects Mail Send at {DateTime.Now.ToString("dd MMM yyyy HH:mm:ss")}");
            }
            catch (Exception e)
            {
                var aa = e.Message;
                _logger.LogError(e, "Top_Cutting_Defects");
            }
        }

        public async Task UnsatisfiedReturnableGoods()
        {
            var unsatisData = await _dailyMailMaterialManagementRepository.UnsatisfiedReturnableGoods();

            var ReportDateMsg = DateTime.Now.ToString("dd-MMM-yyyy");

            StringBuilder sb = new StringBuilder();
            string htmlBody = @$"<!DOCTYPE html>
                                    <head><meta content=""text/html; charset=utf-8"" http-equiv=""Content-Type"">
                                        <title> Unsatisfied Returnable Goods. </title> 
                                    </head>";
            sb.AppendLine(htmlBody);
            sb.Append(@"<body style='font-size:13px;'>");

            if (unsatisData.Count > 0)
            {
                sb.Append(@"<h2 style='text-align:center;padding-bottom:1px;margin-bottom:0px;'> Unsatisfied Returnable Goods   </h2>");
                sb.Append(@$"<h4 style='text-align:center;padding-top:1px;padding-bottom:1px;margin-bottom:0px;;margin-top:1px;'>Reporting Date - {ReportDateMsg}</h4>");

                sb.Append(@"<table style='font-family: arial, sans-serif;border-collapse:collapse;font-size:9pt;width: 100%;'>");
                sb.Append(@"<thead style='text-align:center;'>");
                sb.Append("<tr>");
                sb.Append("<th style='border:1px solid black;' width='3%'>SL#</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Gate Pass</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Date</ th>");
                sb.Append("<th style='border:1px solid black;' width=''>Return<br/>Date</ th>");
                sb.Append("<th style='border:1px solid black;' width=''>Exceed<br/>Days</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Supplier</th>");
                sb.Append("<th style='border:1px solid black;' width='10%'>Item</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Quantity</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Unit</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Received</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Balance</th>");
                sb.Append("<th style='border:1px solid black;' width='12%'>Remarks</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Employee<br/>Department</th>");
                sb.Append("<th style='border:1px solid black;' width=''>Mark Out</th>");
                sb.Append("</thead></tr>");
                int fsl = 1;
                string overDuestyle = "";
                foreach (var ung in unsatisData)
                {
                    overDuestyle = "";
                    sb.Append("<tr>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{fsl}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.GatePassNo}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.GatePassDate}</td>");
                    if (ung.ExceedDays >= 150)
                    {
                        overDuestyle = "background-color:#e60000;color:#fff";
                    }
                    else if (ung.ExceedDays > 99)
                    {
                        overDuestyle = "background-color:#ff4d4d;color:#111";
                    }
                    else if (ung.ExceedDays > 49)
                    {
                        overDuestyle = "background-color:#ff8080;color:#111";
                    }
                    else if (ung.ExceedDays > 15)
                    {
                        overDuestyle = "background-color:#ff9999;color:#111";
                    }
                    else if (ung.ExceedDays > 5)
                    {
                        overDuestyle = "background-color:#ffcccc;color:#111";
                    }
                    else
                    {
                        overDuestyle = "";
                    }
                    sb.Append($"<td style='border:1px solid black;text-align:center;{overDuestyle}'><b>{ung.ExpectedReturnDate}</b></td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;{overDuestyle}'><b>{ung.ExceedDays}</b></td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.Supplier}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.ItemName}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", ung.Quantity > 0 ? ung.Quantity : ung.GrossWeight)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.Unit}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", ung.RecieveQuantity)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:right;'>{String.Format("{0:n2}", ung.Balance)}</td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.Remarks}</b></td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.CreatorEmployee}<br/><b>{ung.CreatorDepartment}</b></td>");
                    sb.Append($"<td style='border:1px solid black;text-align:center;'>{ung.MarkOutEmployee}<br/><b>{ung.MarkedOutOn}</b></td>");
                    sb.Append("</tr>");

                    fsl++;
                }
                sb.Append("</table>");
            }
            else
            {
                sb.Append(@"<h2 style='text-align:center;padding-bottom:1px;margin-bottom:0px;'>No Unsatisfied Returnable Goods found.  </h2>");
            }

            sb.Append(@$"<div style='margin-top:50px;background:#C0C0C0;color:#111;font-size:10px;'>ERP Automatic generated Report, Generated at : {DateTime.Now.ToString("dd:MMM:yyyy hh:mm:ss")}</div>");
            sb.Append("<body><html>");

            var rawData = sb.ToString();
            var mailItem = await _schedularReportEmailRepository.GetMailRecipients(Constants_EmailReport.UnsatisfiedReturnableGoods);
            List<string> to = new List<string>();
            List<string> cc = new List<string>();
            List<string> bcc = new List<string>();
            to = mailItem.Item1;
            cc = mailItem.Item2;
            bcc = mailItem.Item3;

            //to.Add("akbar@comptexbd.com");
            //cc.Add("jobayershoaib@gmail.com");
            //cc.Add("jobayer@robintexbd.com");

            //email.Add("habib@robintexbd.com");
            //var mailBody = sb.ToString();
            var emailMessage = new EmailMessageAttachment($"Unsatisfied Returnable Goods. Date : {ReportDateMsg}", rawData, to, cc, bcc);
            try
            {
                await _emailSenderService.SendEmailAsync(emailMessage);
                _logger.LogInformation($"SubContractGatePass Mail Send at {DateTime.Now.ToString("dd MMM yyyy HH:mm:ss")}");
            }
            catch (Exception e)
            {
                var aa = e.Message;
                _logger.LogError(e, "SubContractGatePass");
            }
        }
    }
}

