#pragma checksum "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f0e0601e4d1ce029dc08405785315162a28034d0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_EMS_Views_ShipmentReport_DocumentPurchasePercentReport), @"mvc.1.0.view", @"/Areas/EMS/Views/ShipmentReport/DocumentPurchasePercentReport.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "E:\TFS Project\RG_ERP\RG.WEB\Areas\_ViewImports.cshtml"
using RG.WEB;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\TFS Project\RG_ERP\RG.WEB\Areas\_ViewImports.cshtml"
using RG.WEB.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\TFS Project\RG_ERP\RG.WEB\Areas\_ViewImports.cshtml"
using RG.Application.IdentityEntities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\TFS Project\RG_ERP\RG.WEB\Areas\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\TFS Project\RG_ERP\RG.WEB\Areas\_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\TFS Project\RG_ERP\RG.WEB\Areas\_ViewImports.cshtml"
using RG.Application.Constants;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\TFS Project\RG_ERP\RG.WEB\Areas\_ViewImports.cshtml"
using RG.Application.Common.Utilities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\TFS Project\RG_ERP\RG.WEB\Areas\_ViewImports.cshtml"
using RG.Application.Contracts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\TFS Project\RG_ERP\RG.WEB\Areas\_ViewImports.cshtml"
using Microsoft.AspNetCore.Antiforgery;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "E:\TFS Project\RG_ERP\RG.WEB\Areas\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0e0601e4d1ce029dc08405785315162a28034d0", @"/Areas/EMS/Views/ShipmentReport/DocumentPurchasePercentReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"579f12fddde6ad7d5e2e7207f508f2b104c1f8c2", @"/Areas/_ViewImports.cshtml")]
    public class Areas_EMS_Views_ShipmentReport_DocumentPurchasePercentReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<RG.Application.Contracts.EMS.Business.ExportDocuments.Queries.RequestResponseModel.DocumentsPurchaseRatioRM>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/AdminLTE-3.1.0/plugins/jquery-ui/jquery-ui.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap-5.0.2/css/bootstrap.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/AdminLTE-3.1.0/plugins/jquery/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/AdminLTE-3.1.0/plugins/jquery-ui/jquery-ui.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap-5.0.2/js/bootstrap.bundle.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
  

    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f0e0601e4d1ce029dc08405785315162a28034d07492", async() => {
                WriteLiteral("\r\n    <title>Document Purchase Ratio</title>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f0e0601e4d1ce029dc08405785315162a28034d07800", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f0e0601e4d1ce029dc08405785315162a28034d08978", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f0e0601e4d1ce029dc08405785315162a28034d010156", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f0e0601e4d1ce029dc08405785315162a28034d011256", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f0e0601e4d1ce029dc08405785315162a28034d012356", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"


    <link rel=""stylesheet"" href=""https://cdn.datatables.net/1.10.12/css/jquery.dataTables.min.css"" />
    <link rel=""stylesheet"" href=""https://cdn.datatables.net/buttons/1.2.2/css/buttons.dataTables.min.css"" />
    <script type=""text/javascript"" src=""https://code.jquery.com/jquery-1.12.3.js""></script>
    <script type=""text/javascript"" src=""https://cdn.datatables.net/1.10.12/js/jquery.dataTables.min.js""></script>
    <script type=""text/javascript"" src=""https://cdn.datatables.net/buttons/1.2.2/js/dataTables.buttons.min.js""></script>
    <script type=""text/javascript"" src=""https://cdnjs.cloudflare.com/ajax/libs/jszip/2.5.0/jszip.min.js""></script>
    <script type=""text/javascript"" src=""https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/pdfmake.min.js""></script>
    <script type=""text/javascript"" src=""https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/vfs_fonts.js""></script>
    <script type=""text/javascript"" src=""https://cdn.datatables.net/buttons/1.2.2/js/buttons.html5.min.js""></script>

  ");
                WriteLiteral("  <style>\r\n        .header {\r\n            position: sticky;\r\n            top: 0;\r\n        }\r\n    </style>\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f0e0601e4d1ce029dc08405785315162a28034d015379", async() => {
                WriteLiteral(@"
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-12 text-center"">
                <h5 class=""mb-0"">Robintex (Bangladesh) Limited</h5>
                <h6>Bhulta,Rupganj,Narayanganj</h6>
                <h6>Document Purchase Ratio</h6>
            </div>
        </div>
        <table class=""table table-sm table-bordered table-striped text-sm text-center display nowrap"" id=""tblDocuments"" style=""font-size:11px;"">
            <thead class=""bg-dark text-white header font-weight-bold"">
                <tr>
                    <td>Sl#</td>
                    <td>Year</td>
                    <td>Month</td>
                    <td>Company</td>
                    <td>Buyer</td>
                    <td>Bank</td>
                    <td>Master LC#</td>
                    <td>Document No</td>
                    <td>Document Date</td>
                    <td>Document Amt</td>
                    <td>Margin %</td>
                    <td>Margin Amt</td>
  ");
                WriteLiteral("                  <td>Purchase Amt</td>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 65 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                   var sl = 0;
                    var prevYear = 0;
                    var prevMonth = "";
                    var prevYearMonth = 0;

                    foreach (var item in Model)
                    {

                        sl++;
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 74 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                         if (prevYearMonth != 0 && prevYearMonth != item.YearMonth)
                        {
                            var yearMonthData = Model.Where(x => x.YearMonth == prevYearMonth).ToList();
                            var totalDocAmt = yearMonthData.Sum(x => x.DocumentAmt);

                            var totalPurRatAmt = yearMonthData.Sum(x => x.PurchaseRatioAmt);
                            var totalPurAmt = yearMonthData.Sum(x => x.PurchaseAmt);

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <tr class=\"bg-primary text-white\">\r\n                                <td></td>\r\n\r\n                                <td colspan=\"7\"><b>");
#nullable restore
#line 84 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                                              Write(prevMonth);

#line default
#line hidden
#nullable disable
                WriteLiteral(" Total</b></td>\r\n                                <td class=\"text-end\"><b>");
#nullable restore
#line 85 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                                                    Write(String.Format("{0:n2}", totalDocAmt));

#line default
#line hidden
#nullable disable
                WriteLiteral("</b></td>\r\n                                <td></td>\r\n                                <td class=\"text-end\"><b>");
#nullable restore
#line 87 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                                                    Write(String.Format("{0:n2}", totalPurRatAmt));

#line default
#line hidden
#nullable disable
                WriteLiteral("</b></td>\r\n                                <td class=\"text-end\"><b>");
#nullable restore
#line 88 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                                                    Write(String.Format("{0:n2}", totalPurAmt));

#line default
#line hidden
#nullable disable
                WriteLiteral("</b></td>\r\n                            </tr>\r\n");
#nullable restore
#line 90 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 91 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                         if (prevYear != 0 && prevYear != item.Year)
                        {
                            var yearData = Model.Where(x => x.Year == prevYear).ToList();
                            var totalDocAmt = yearData.Sum(x => x.DocumentAmt);

                            var totalPurRatAmt = yearData.Sum(x => x.PurchaseRatioAmt);
                            var totalPurAmt = yearData.Sum(x => x.PurchaseAmt);

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <tr class=\"bg-info\">\r\n                                <td colspan=\"9\"><b>");
#nullable restore
#line 99 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                                              Write(prevYear);

#line default
#line hidden
#nullable disable
                WriteLiteral(" Total</b></td>\r\n                                <td class=\"text-end\"><b>");
#nullable restore
#line 100 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                                                    Write(String.Format("{0:n2}", totalDocAmt));

#line default
#line hidden
#nullable disable
                WriteLiteral("</b></td>\r\n                                <td></td>\r\n                                <td class=\"text-end\"><b>");
#nullable restore
#line 102 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                                                    Write(String.Format("{0:n2}", totalPurRatAmt));

#line default
#line hidden
#nullable disable
                WriteLiteral("</b></td>\r\n                                <td class=\"text-end\"><b>");
#nullable restore
#line 103 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                                                    Write(String.Format("{0:n2}", totalPurAmt));

#line default
#line hidden
#nullable disable
                WriteLiteral("</b></td>\r\n                            </tr>\r\n");
#nullable restore
#line 105 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 110 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                           Write(sl);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n");
#nullable restore
#line 111 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                             if (prevYear == 0 || prevYear != item.Year)
                            {
                                var yearRowCount = Model.Where(x => x.Year == item.Year).ToList().Count();
                                var yearMonthCount = Model.Where(x => x.Year == item.Year).Select(x => x.YearMonth).Distinct().ToList().Count();

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <td");
                BeginWriteAttribute("rowspan", " rowspan=\"", 5744, "\"", 5784, 1);
#nullable restore
#line 115 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
WriteAttributeValue("", 5754, yearRowCount+yearMonthCount, 5754, 30, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"font-weight-bold\"");
                BeginWriteAttribute("title", " title=\"", 5810, "\"", 5828, 1);
#nullable restore
#line 115 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
WriteAttributeValue("", 5818, item.Year, 5818, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 115 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                                                                                                                    Write(item.Year);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n");
#nullable restore
#line 116 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 117 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                             if (prevYear == 0 || prevYearMonth != item.YearMonth)
                            {
                                var yearMonthRowCount = Model.Where(x => x.YearMonth == item.YearMonth).ToList().Count();
                                var title = $"{item.MonthName}-{item.Year}";

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <td");
                BeginWriteAttribute("rowspan", " rowspan=\"", 6229, "\"", 6259, 1);
#nullable restore
#line 121 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
WriteAttributeValue("", 6239, yearMonthRowCount, 6239, 20, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"font-weight-bold\"");
                BeginWriteAttribute("title", " title=\"", 6285, "\"", 6299, 1);
#nullable restore
#line 121 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
WriteAttributeValue("", 6293, title, 6293, 6, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 121 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                                                                                                      Write(item.MonthName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n");
#nullable restore
#line 122 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <td>");
#nullable restore
#line 123 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                           Write(item.CompanyShortName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 124 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                           Write(item.Buyer);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 125 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                           Write(item.BankName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 126 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                           Write(item.LOM_CODE);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>                            \r\n                            <a style=\"cursor:pointer;\" class=\"text-primary\"");
                BeginWriteAttribute("onclick", "\r\n                               onclick=\"", 6708, "\"", 6913, 5);
                WriteAttributeValue("", 6750, "window.open(`http://119.148.55.92/erp/lcm/md/MLC_Template_CTX.asp?id=${", 6750, 71, true);
#nullable restore
#line 129 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
WriteAttributeValue("", 6821, item.FDBPP_ID, 6821, 14, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 6835, "}`,", 6835, 3, true);
                WriteAttributeValue(" ", 6838, "\'_blank\',", 6839, 10, true);
                WriteAttributeValue(" ", 6848, "\'location=yes,height=570,width=1000,scrollbars=yes,status=yes\');", 6849, 65, true);
                EndWriteAttribute();
                WriteLiteral(">\r\n                                ");
#nullable restore
#line 130 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                           Write(item.DocumentNo);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </a>\r\n                            </td>\r\n                            <td>");
#nullable restore
#line 133 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                           Write(item.DocumentDateMsg);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td class=\"text-end bg-success text-white\">");
#nullable restore
#line 134 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                                                                   Write(String.Format("{0:n2}", item.DocumentAmt));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td class=\"bg-warning\">");
#nullable restore
#line 135 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                                               Write(String.Format("{0:n2}", item.PurchasePercent));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td class=\"text-end bg-info\">");
#nullable restore
#line 136 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                                                     Write(String.Format("{0:n2}", item.PurchaseRatioAmt));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td class=\"text-end \">");
#nullable restore
#line 137 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                                              Write(String.Format("{0:n2}", item.PurchaseAmt));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        </tr>\r\n");
#nullable restore
#line 139 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                        prevYear = item.Year;
                        prevYearMonth = item.YearMonth;
                        prevMonth = item.MonthName;
                        if (Model.Last() == item)
                        {
                            var yearData = Model.Where(x => x.Year == item.Year).ToList();
                            var totalDocAmt = yearData.Sum(x => x.DocumentAmt);

                            var totalPurRatAmt = yearData.Sum(x => x.PurchaseRatioAmt);
                            var totalPurAmt = yearData.Sum(x => x.PurchaseAmt);

                            var yearMonthData = Model.Where(x => x.YearMonth == prevYearMonth).ToList();
                            var totalMonthDocAmt = yearMonthData.Sum(x => x.DocumentAmt);

                            var totalMonthPurRatAmt = yearMonthData.Sum(x => x.PurchaseRatioAmt);
                            var totalMonthPurAmt = yearMonthData.Sum(x => x.PurchaseAmt);

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <tr class=\"bg-primary text-white\">\r\n                                <td></td>\r\n                                <td colspan=\"7\"><b>");
#nullable restore
#line 157 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                                              Write(item.MonthName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" Total</b></td>\r\n                                <td class=\"text-end\"><b>");
#nullable restore
#line 158 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                                                    Write(String.Format("{0:n2}", totalMonthDocAmt));

#line default
#line hidden
#nullable disable
                WriteLiteral("</b></td>\r\n                                <td></td>\r\n                                <td class=\"text-end\"><b>");
#nullable restore
#line 160 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                                                    Write(String.Format("{0:n2}", totalMonthPurRatAmt));

#line default
#line hidden
#nullable disable
                WriteLiteral("</b></td>\r\n                                <td class=\"text-end\"><b>");
#nullable restore
#line 161 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                                                    Write(String.Format("{0:n2}", totalMonthPurAmt));

#line default
#line hidden
#nullable disable
                WriteLiteral("</b></td>\r\n                            </tr>\r\n");
                WriteLiteral("                            <tr class=\"bg-info\">\r\n                                <td colspan=\"9\"><b>");
#nullable restore
#line 165 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                                              Write(item.Year);

#line default
#line hidden
#nullable disable
                WriteLiteral(" Total</b></td>\r\n                                <td class=\"text-end\"><b>");
#nullable restore
#line 166 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                                                    Write(String.Format("{0:n2}", totalDocAmt));

#line default
#line hidden
#nullable disable
                WriteLiteral("</b></td>\r\n                                <td></td>\r\n                                <td class=\"text-end\"><b>");
#nullable restore
#line 168 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                                                    Write(String.Format("{0:n2}", totalPurRatAmt));

#line default
#line hidden
#nullable disable
                WriteLiteral("</b></td>\r\n                                <td class=\"text-end\"><b>");
#nullable restore
#line 169 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                                                    Write(String.Format("{0:n2}", totalPurAmt));

#line default
#line hidden
#nullable disable
                WriteLiteral("</b></td>\r\n                            </tr>\r\n");
#nullable restore
#line 171 "E:\TFS Project\RG_ERP\RG.WEB\Areas\EMS\Views\ShipmentReport\DocumentPurchasePercentReport.cshtml"
                        }
                    }
                

#line default
#line hidden
#nullable disable
                WriteLiteral("            </tbody>\r\n        </table>\r\n        <div class=\"text-center\">\r\n            <input type=\"button\" class=\"btn btn-sm btn-success\" value=\"Excel\" id=\"btnExcel\" onclick=\"exportToExcel()\" />\r\n        </div>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</html>

<script type=""text/javascript"">
    function exportToExcel() {
        var htmls = """";
        var uri = 'data:application/vnd.ms-excel;base64,';
        var template = '<html xmlns:o=""urn:schemas-microsoft-com:office:office"" xmlns:x=""urn:schemas-microsoft-com:office:excel"" xmlns=""http://www.w3.org/TR/REC-html40""><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head><body><table>{table}</table></body></html>';
        var base64 = function (s) {
            return window.btoa(unescape(encodeURIComponent(s)))
        };

        var format = function (s, c) {
            return s.replace(/{(\w+)}/g, function (m, p) {
                return c[p];
            })
        };

        htmls = document.getElementById(""tblDocuments"").innerHTML;

        var ctx = {
            worksheet: ");
            WriteLiteral("\'Worksheet\',\r\n            table: htmls\r\n        }\r\n        var link = document.createElement(\"a\");\r\n        link.download = \"PurchaseDocumentsReport.xls\";\r\n        link.href = uri + base64(format(template, ctx));\r\n        link.click();\r\n    }\r\n</script>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<RG.Application.Contracts.EMS.Business.ExportDocuments.Queries.RequestResponseModel.DocumentsPurchaseRatioRM>> Html { get; private set; }
    }
}
#pragma warning restore 1591