#pragma checksum "E:\TFS Project\RG_ERP\RG.WEB\Areas\Maxco\Views\OrderPlanReports\DyeingProductionFinishFabricWeekReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "462885da15a19cd6c64f9d2ed2bb7c321d9fca95"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Maxco_Views_OrderPlanReports_DyeingProductionFinishFabricWeekReport), @"mvc.1.0.view", @"/Areas/Maxco/Views/OrderPlanReports/DyeingProductionFinishFabricWeekReport.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"462885da15a19cd6c64f9d2ed2bb7c321d9fca95", @"/Areas/Maxco/Views/OrderPlanReports/DyeingProductionFinishFabricWeekReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"579f12fddde6ad7d5e2e7207f508f2b104c1f8c2", @"/Areas/_ViewImports.cshtml")]
    public class Areas_Maxco_Views_OrderPlanReports_DyeingProductionFinishFabricWeekReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<RG.Application.Contracts.Maxco.Buisness.OrderPlanReports.Queries.RequestResponseModel.DyeingUnitProductionFabricWeekRM>>
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Maxco\Views\OrderPlanReports\DyeingProductionFinishFabricWeekReport.cshtml"
  
    Layout = null;
    var unitSum = Model.GroupBy(g => g.DyeingProductinUnit)
.Select(x => new
{
    DyeingProductinUnit = x.Key,
    UnitTotal = x.Sum(s => s.UnitWiseBuyerTotal)
});

    var unitBuyerSum = Model.GroupBy(g => new { g.DyeingProductinUnit, g.Buyer })
       .Select(x => new
       {
           DyeingProductinUnit = x.Key.DyeingProductinUnit,
           Buyer = x.Key.Buyer,
           BuyerTotal = x.Sum(s => s.UnitWiseBuyerTotal)
       });

    var grandSum = Model.Sum(x => x.UnitWiseBuyerTotal);

#line default
#line hidden
#nullable disable
            WriteLiteral("<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "462885da15a19cd6c64f9d2ed2bb7c321d9fca958145", async() => {
                WriteLiteral("\r\n    <title>Dyeing Product Report</title>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "462885da15a19cd6c64f9d2ed2bb7c321d9fca958451", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "462885da15a19cd6c64f9d2ed2bb7c321d9fca959629", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "462885da15a19cd6c64f9d2ed2bb7c321d9fca9510807", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "462885da15a19cd6c64f9d2ed2bb7c321d9fca9511907", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "462885da15a19cd6c64f9d2ed2bb7c321d9fca9513007", async() => {
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
                WriteLiteral("<style>\r\n        .header {\r\n            position: sticky;\r\n            top: 0;\r\n        }\r\n    </style>\r\n");
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "462885da15a19cd6c64f9d2ed2bb7c321d9fca9516020", async() => {
                WriteLiteral(@"

    <div class=""container-fluid"">
        <div class=""row"" style=""height:50px;"">
            <div class=""col-12 text-center"">
                <h5 class=""mb-0"">Robintex Group Bangladesh</h5>
                <h6>Order Dyeing Product</h6>

            </div>
        </div>
        <div class=""row"">
            <div class=""col-12"">
                <table class=""table table-sm table-bordered table-striped text-sm text-center display nowrap"" id=""tblDyeingProductionWeekReport"" style=""font-size:11px;"">
                    <thead class=""bg-dark text-white header"">
                        <tr>
                            <th>SL#</th>
                            <th>Dyeing Unit</th>
                            <th>Buyer</th>
                            <th>Fabric Week</th>
                            <th>Total</th>
                            <th>Remarks</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 72 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Maxco\Views\OrderPlanReports\DyeingProductionFinishFabricWeekReport.cshtml"
                          
                            var sl = 0;
                            var previousUnit = "";
                            var previousUnitBuyer = "";

                            var lastItem = Model.Last();


                            foreach (var item in Model.OrderBy(x => x.DyeingProductinUnit).ThenBy(x => x.BuyerID))
                            {
                                var sameUnit = Model.Where(x => x.DyeingProductinUnit == item.DyeingProductinUnit).Count();
                                var sameUnitBuyerCount = Model.Where(x => x.DyeingProductinUnit == item.DyeingProductinUnit).Select(x => x.Buyer).Distinct().Count();
                                var sameUnitSameBuyer = Model.Where(x => x.DyeingProductinUnit == item.DyeingProductinUnit && x.BuyerID == item.BuyerID).Count();


                                //2nd
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 88 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Maxco\Views\OrderPlanReports\DyeingProductionFinishFabricWeekReport.cshtml"
                                 if (previousUnitBuyer != "" && previousUnit != "" && (previousUnit != item.DyeingProductinUnit || previousUnitBuyer != item.Buyer))
                                {
                                    var buyerTotal = unitBuyerSum.Where(x => x.DyeingProductinUnit == previousUnit && x.Buyer == previousUnitBuyer).First().BuyerTotal;

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <tr style=\"background-color:cornflowerblue !important;font-weight:bold !important;color:white\">\r\n                                        <td colspan=\"2\">");
#nullable restore
#line 92 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Maxco\Views\OrderPlanReports\DyeingProductionFinishFabricWeekReport.cshtml"
                                                   Write(previousUnitBuyer);

#line default
#line hidden
#nullable disable
                WriteLiteral(" Total</td>\r\n                                        <td>");
#nullable restore
#line 93 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Maxco\Views\OrderPlanReports\DyeingProductionFinishFabricWeekReport.cshtml"
                                       Write(String.Format("{0:n2}", buyerTotal));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                        <td></td>\r\n                                    </tr>\r\n");
#nullable restore
#line 96 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Maxco\Views\OrderPlanReports\DyeingProductionFinishFabricWeekReport.cshtml"

                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 97 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Maxco\Views\OrderPlanReports\DyeingProductionFinishFabricWeekReport.cshtml"
                                 
                                if (previousUnit != "" && previousUnit != item.DyeingProductinUnit)
                                {
                                    var unitTotal = unitSum.Where(x => x.DyeingProductinUnit == previousUnit).First().UnitTotal;

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <tr>\r\n                                        <td colspan=\"4\">");
#nullable restore
#line 102 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Maxco\Views\OrderPlanReports\DyeingProductionFinishFabricWeekReport.cshtml"
                                                   Write(previousUnit);

#line default
#line hidden
#nullable disable
                WriteLiteral(" Total</td>\r\n                                        <td>");
#nullable restore
#line 103 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Maxco\Views\OrderPlanReports\DyeingProductionFinishFabricWeekReport.cshtml"
                                       Write(unitTotal);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                        <td></td>\r\n                                    </tr>\r\n");
#nullable restore
#line 106 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Maxco\Views\OrderPlanReports\DyeingProductionFinishFabricWeekReport.cshtml"
                                }
                                //1st +sameUnitBuyerCount

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <tr>\r\n");
#nullable restore
#line 109 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Maxco\Views\OrderPlanReports\DyeingProductionFinishFabricWeekReport.cshtml"
                                     if (previousUnit != item.DyeingProductinUnit)
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <td");
                BeginWriteAttribute("rowspan", " rowspan=\"", 5833, "\"", 5873, 1);
#nullable restore
#line 111 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Maxco\Views\OrderPlanReports\DyeingProductionFinishFabricWeekReport.cshtml"
WriteAttributeValue("", 5843, sameUnit+sameUnitBuyerCount, 5843, 30, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" style=\"vertical-align: middle;\">");
#nullable restore
#line 111 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Maxco\Views\OrderPlanReports\DyeingProductionFinishFabricWeekReport.cshtml"
                                                                                                                 Write(++sl);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n");
#nullable restore
#line 112 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Maxco\Views\OrderPlanReports\DyeingProductionFinishFabricWeekReport.cshtml"
                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 113 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Maxco\Views\OrderPlanReports\DyeingProductionFinishFabricWeekReport.cshtml"
                                     if (previousUnit != item.DyeingProductinUnit)
                                    {
                                        previousUnitBuyer = "";

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <td");
                BeginWriteAttribute("rowspan", " rowspan=\"", 6191, "\"", 6231, 1);
#nullable restore
#line 116 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Maxco\Views\OrderPlanReports\DyeingProductionFinishFabricWeekReport.cshtml"
WriteAttributeValue("", 6201, sameUnit+sameUnitBuyerCount, 6201, 30, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" style=\"vertical-align: middle;\">");
#nullable restore
#line 116 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Maxco\Views\OrderPlanReports\DyeingProductionFinishFabricWeekReport.cshtml"
                                                                                                                Write(item.DyeingProductinUnit);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n");
#nullable restore
#line 117 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Maxco\Views\OrderPlanReports\DyeingProductionFinishFabricWeekReport.cshtml"

                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 119 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Maxco\Views\OrderPlanReports\DyeingProductionFinishFabricWeekReport.cshtml"
                                     if (previousUnitBuyer != item.Buyer)
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <td");
                BeginWriteAttribute("rowspan", " rowspan=\"", 6495, "\"", 6523, 1);
#nullable restore
#line 121 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Maxco\Views\OrderPlanReports\DyeingProductionFinishFabricWeekReport.cshtml"
WriteAttributeValue("", 6505, sameUnitSameBuyer, 6505, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" style=\"vertical-align: middle;\">");
#nullable restore
#line 121 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Maxco\Views\OrderPlanReports\DyeingProductionFinishFabricWeekReport.cshtml"
                                                                                                    Write(item.Buyer);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n");
#nullable restore
#line 122 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Maxco\Views\OrderPlanReports\DyeingProductionFinishFabricWeekReport.cshtml"
                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    <td>Week- ");
#nullable restore
#line 124 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Maxco\Views\OrderPlanReports\DyeingProductionFinishFabricWeekReport.cshtml"
                                         Write(item.FabricWeek);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 125 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Maxco\Views\OrderPlanReports\DyeingProductionFinishFabricWeekReport.cshtml"
                                   Write(String.Format("{0:n2}", item.UnitWiseBuyerTotal));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                    <td> </td>\r\n                                </tr>\r\n");
#nullable restore
#line 128 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Maxco\Views\OrderPlanReports\DyeingProductionFinishFabricWeekReport.cshtml"

                                //3rd
                                if (lastItem.Equals(item))
                                {
                                    var unitTotal = unitSum.Where(x => x.DyeingProductinUnit == item.DyeingProductinUnit).First().UnitTotal;
                                    var buyerTotal = unitBuyerSum.Where(x => x.DyeingProductinUnit == item.DyeingProductinUnit && x.Buyer == item.Buyer).First().BuyerTotal;

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <tr style=\"background-color:cornflowerblue !important;font-weight:bold !important;color:white\">\r\n                                        <td colspan=\"2\">");
#nullable restore
#line 135 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Maxco\Views\OrderPlanReports\DyeingProductionFinishFabricWeekReport.cshtml"
                                                   Write(item.Buyer);

#line default
#line hidden
#nullable disable
                WriteLiteral(" Total</td>\r\n                                        <td>");
#nullable restore
#line 136 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Maxco\Views\OrderPlanReports\DyeingProductionFinishFabricWeekReport.cshtml"
                                       Write(String.Format("{0:n2}", buyerTotal));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</td>
                                        <td></td>
                                    </tr>
                                    <tr class=""text-white"" style=""background-color:deepskyblue !important;font-weight:bold !important"">
                                        <td colspan=""4"">");
#nullable restore
#line 140 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Maxco\Views\OrderPlanReports\DyeingProductionFinishFabricWeekReport.cshtml"
                                                   Write(item.DyeingProductinUnit);

#line default
#line hidden
#nullable disable
                WriteLiteral(" Total</td>\r\n                                        <td>");
#nullable restore
#line 141 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Maxco\Views\OrderPlanReports\DyeingProductionFinishFabricWeekReport.cshtml"
                                       Write(String.Format("{0:n2}", unitTotal));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</td>
                                        <td></td>
                                    </tr>
                                    <tr class=""text-white"" style=""background-color: deepskyblue !important; font-weight: bold !important"">
                                        <td colspan=""4"">Grand Total</td>
                                        <td>");
#nullable restore
#line 146 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Maxco\Views\OrderPlanReports\DyeingProductionFinishFabricWeekReport.cshtml"
                                       Write(String.Format("{0:n2}", grandSum));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                        <td></td>\r\n                                    </tr>\r\n");
#nullable restore
#line 149 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Maxco\Views\OrderPlanReports\DyeingProductionFinishFabricWeekReport.cshtml"
                                }
                                //grandSum
                                previousUnit = item.DyeingProductinUnit;
                                previousUnitBuyer = item.Buyer;
                            }
                        

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                    </tbody>
                </table>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-12"">
                <div class=""text-center"">
                    <input type=""button"" class=""btn btn-sm btn-success"" value=""Excel"" id=""btnPdf"" onclick=""exportToExcel()"" />
                </div>
            </div>
        </div>
    </div>
    <script type=""text/javascript"">
        function bodyOnload() {
            //   $(""body"").removeClass(""loading"");

        }

        function exportToExcel() {
            var htmls = """";
            var uri = 'data:application/vnd.ms-excel;base64,';
            var template = '<html xmlns:o=""urn:schemas-microsoft-com:office:office"" xmlns:x=""urn:schemas-microsoft-com:office:excel"" xmlns=""http://www.w3.org/TR/REC-html40""><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksh");
                WriteLiteral(@"eet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head><body><table>{table}</table></body></html>';
            var base64 = function (s) {
                return window.btoa(unescape(encodeURIComponent(s)))
            };

            var format = function (s, c) {
                return s.replace(/{(\w+)}/g, function (m, p) {
                    return c[p];
                })
            };

            htmls = document.getElementById(""tblDyeingProductionWeekReport"").innerHTML;

            var ctx = {
                worksheet: 'Worksheet',
                table: htmls
            }
            var link = document.createElement(""a"");
            link.download = ""DyeingProductionWeekReport.xls"";
            link.href = uri + base64(format(template, ctx));
            link.click();
        }
        $(function () {
            $(document).ready(function () {
                // $(""body"").addClass(""loading"");

            });
        });
    </script>
");
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
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<RG.Application.Contracts.Maxco.Buisness.OrderPlanReports.Queries.RequestResponseModel.DyeingUnitProductionFabricWeekRM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
