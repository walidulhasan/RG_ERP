#pragma checksum "E:\TFS Project\RG_ERP\RG.WEB\Areas\Embro\Views\GeneralLedger\Components\VoucherShortInfoTB\VoucherShortInfoTBVC.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fe61699f77ae48de06867a7e32cdff78ce58046f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Embro_Views_GeneralLedger_Components_VoucherShortInfoTB_VoucherShortInfoTBVC), @"mvc.1.0.view", @"/Areas/Embro/Views/GeneralLedger/Components/VoucherShortInfoTB/VoucherShortInfoTBVC.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe61699f77ae48de06867a7e32cdff78ce58046f", @"/Areas/Embro/Views/GeneralLedger/Components/VoucherShortInfoTB/VoucherShortInfoTBVC.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"579f12fddde6ad7d5e2e7207f508f2b104c1f8c2", @"/Areas/_ViewImports.cshtml")]
    public class Areas_Embro_Views_GeneralLedger_Components_VoucherShortInfoTB_VoucherShortInfoTBVC : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<RG.Application.Contracts.Embro.AccountsReports.Vouchers.Queries.QueryResponseModel.VoucherShortInfoTBRM>>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("<!doctype html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fe61699f77ae48de06867a7e32cdff78ce58046f5001", async() => {
                WriteLiteral("\r\n    <meta charset=\"utf-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1, shrink-to-fit=no\">\r\n    <meta name=\"description\"");
                BeginWriteAttribute("content", " content=\"", 320, "\"", 330, 0);
                EndWriteAttribute();
                WriteLiteral(@">
    <meta name=""author"" content=""Robintex comptex"">
    <meta name=""generator"" content=""Jekyll v3.8.6"">
    <title></title>


    <meta name=""theme-color"" content=""#563d7c"">

    <link rel=""stylesheet"" href=""https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css"" integrity=""sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh"" crossorigin=""anonymous"">


    <style>
        .header {
            position: sticky;
            top: 0;
        }
    </style>


");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fe61699f77ae48de06867a7e32cdff78ce58046f6823", async() => {
                WriteLiteral("\r\n\r\n\r\n\r\n");
#nullable restore
#line 35 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Embro\Views\GeneralLedger\Components\VoucherShortInfoTB\VoucherShortInfoTBVC.cshtml"
     if (Model.Count > 0)
    {


#line default
#line hidden
#nullable disable
                WriteLiteral("        <div");
                BeginWriteAttribute("class", " class=\"", 921, "\"", 929, 0);
                EndWriteAttribute();
                WriteLiteral(@">
            <main role=""main"" class=""col-md-12 ml-sm-auto col-lg-12 px-4"">
                <div class=""row pb-2"">
                    <div class=""col-md-12"" style=""text-align:center;"">
                        <span class=""col-md-12"" style=""text-align:center;font-weight:bold;"">");
#nullable restore
#line 42 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Embro\Views\GeneralLedger\Components\VoucherShortInfoTB\VoucherShortInfoTBVC.cshtml"
                                                                                       Write(Model.Last().CompanyName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                        <br />\r\n                        <span class=\"col-md-12\" style=\"text-align:center;font-weight:bold;\">");
#nullable restore
#line 44 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Embro\Views\GeneralLedger\Components\VoucherShortInfoTB\VoucherShortInfoTBVC.cshtml"
                                                                                       Write(Model.Last().AccountName);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</span>
                        <br />

                    </div>
                </div>

                <div class=""row"" style=""font-size:12px; max-height:450px;overflow:scroll;"">
                    <div class=""col-md-12 p-0"">
                        <table class=""table table-bordered table-striped table-sm text-center m-0""");
                BeginWriteAttribute("id", " id=\"", 1733, "\"", 1738, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                            <thead class=""header bg-dark text-white"">
                                <tr>
                                    <th>SL</th>
                                    <th>Voucher No</th>
                                    <th>Date</th>
                                    <th>Description</th>
                                    <th>Cost Center</th>
                                    <th>Activity</th>
                                    <th>Debit</th>
                                    <th>Credit</th>
                                    <th>Balance</th>
                                </tr>

                            </thead>
                            <tbody>
");
#nullable restore
#line 68 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Embro\Views\GeneralLedger\Components\VoucherShortInfoTB\VoucherShortInfoTBVC.cshtml"
                                  
                                    var sl = 1;
                                    decimal runningSum = 0;
                                    string drOrCr = "";
                                    foreach (var voucher in Model)
                                    {
                                            runningSum += voucher.Amount;
                                        if (voucher.VoucherId == 0)
                                        {
                                            if (voucher.Debit>0) { drOrCr = "Dr."; }
                                            else
                                            {
                                                drOrCr = "Cr.";
                                            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                            <tr style=""vertical-align:middle;"" class=""bg-info text-white"">
                                                <td colspan=""6"">Account Opening Balance</td>

                                                <td>");
#nullable restore
#line 85 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Embro\Views\GeneralLedger\Components\VoucherShortInfoTB\VoucherShortInfoTBVC.cshtml"
                                               Write(String.Format("{0:n2}", voucher.Debit));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 86 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Embro\Views\GeneralLedger\Components\VoucherShortInfoTB\VoucherShortInfoTBVC.cshtml"
                                               Write(String.Format("{0:n2}", voucher.Credit));

#line default
#line hidden
#nullable disable
                WriteLiteral(" </td>\r\n                                                <td>");
#nullable restore
#line 87 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Embro\Views\GeneralLedger\Components\VoucherShortInfoTB\VoucherShortInfoTBVC.cshtml"
                                               Write(String.Format("{0:n2}", Math.Abs(runningSum)));

#line default
#line hidden
#nullable disable
                WriteLiteral(" <sub class=\"pl-1 fw-bold\">");
#nullable restore
#line 87 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Embro\Views\GeneralLedger\Components\VoucherShortInfoTB\VoucherShortInfoTBVC.cshtml"
                                                                                                                        Write(drOrCr);

#line default
#line hidden
#nullable disable
                WriteLiteral("</sub></td>\r\n                                          \r\n                                            </tr>\r\n");
#nullable restore
#line 90 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Embro\Views\GeneralLedger\Components\VoucherShortInfoTB\VoucherShortInfoTBVC.cshtml"
                                        }
                                        else
                                        {
                                            //runningSum += voucher.Amount;
                                            if (runningSum > 0)
                                            {
                                                drOrCr = "Dr.";
                                            }
                                            else
                                            {
                                                drOrCr = "Cr.";
                                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <tr style=\"vertical-align:middle;\">\r\n                                                <td>");
#nullable restore
#line 103 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Embro\Views\GeneralLedger\Components\VoucherShortInfoTB\VoucherShortInfoTBVC.cshtml"
                                               Write(sl);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 104 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Embro\Views\GeneralLedger\Components\VoucherShortInfoTB\VoucherShortInfoTBVC.cshtml"
                                               Write(voucher.VoucherNumber);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 105 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Embro\Views\GeneralLedger\Components\VoucherShortInfoTB\VoucherShortInfoTBVC.cshtml"
                                               Write(voucher.VDateMsg);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                <td style=\"font-size:8px;\"");
                BeginWriteAttribute("title", " title=\"", 4904, "\"", 4939, 1);
#nullable restore
#line 106 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Embro\Views\GeneralLedger\Components\VoucherShortInfoTB\VoucherShortInfoTBVC.cshtml"
WriteAttributeValue("", 4912, voucher.VoucherDescription, 4912, 27, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 106 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Embro\Views\GeneralLedger\Components\VoucherShortInfoTB\VoucherShortInfoTBVC.cshtml"
                                                                                                           Write(voucher.VoucherDescription.Length > 50 ? voucher.VoucherDescription.Substring(0, 50) : voucher.VoucherDescription);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 107 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Embro\Views\GeneralLedger\Components\VoucherShortInfoTB\VoucherShortInfoTBVC.cshtml"
                                               Write(voucher.CostcenterName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 108 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Embro\Views\GeneralLedger\Components\VoucherShortInfoTB\VoucherShortInfoTBVC.cshtml"
                                               Write(voucher.ActivityName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 109 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Embro\Views\GeneralLedger\Components\VoucherShortInfoTB\VoucherShortInfoTBVC.cshtml"
                                               Write(String.Format("{0:n2}", voucher.Debit));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 110 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Embro\Views\GeneralLedger\Components\VoucherShortInfoTB\VoucherShortInfoTBVC.cshtml"
                                               Write(String.Format("{0:n2}", voucher.Credit));

#line default
#line hidden
#nullable disable
                WriteLiteral(" </td>\r\n                                                <td>");
#nullable restore
#line 111 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Embro\Views\GeneralLedger\Components\VoucherShortInfoTB\VoucherShortInfoTBVC.cshtml"
                                               Write(String.Format("{0:n2}", Math.Abs(runningSum)));

#line default
#line hidden
#nullable disable
                WriteLiteral(" <sub class=\"pl-1 fw-bold\">");
#nullable restore
#line 111 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Embro\Views\GeneralLedger\Components\VoucherShortInfoTB\VoucherShortInfoTBVC.cshtml"
                                                                                                                        Write(drOrCr);

#line default
#line hidden
#nullable disable
                WriteLiteral("</sub></td>\r\n                                               \r\n                                            </tr>\r\n");
#nullable restore
#line 114 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Embro\Views\GeneralLedger\Components\VoucherShortInfoTB\VoucherShortInfoTBVC.cshtml"
                                            sl++;
                                        }
                                    }
                                

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                            </tbody>
                            <tfoot>
                                <tr style=""vertical-align:middle;"">
                                    <td colspan=""6"" class=""fw-bold"">Total</td>

                                    <td style=""font-size:9px;"" class=""fw-bold"">");
#nullable restore
#line 123 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Embro\Views\GeneralLedger\Components\VoucherShortInfoTB\VoucherShortInfoTBVC.cshtml"
                                                                          Write(String.Format("{0:n2}", Model.Sum(x => x.Debit)));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                    <td style=\"font-size:9px;\" class=\"fw-bold\">");
#nullable restore
#line 124 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Embro\Views\GeneralLedger\Components\VoucherShortInfoTB\VoucherShortInfoTBVC.cshtml"
                                                                          Write(String.Format("{0:n2}", Model.Sum(x => x.Credit)));

#line default
#line hidden
#nullable disable
                WriteLiteral(@" </td>

                                    <td></td>
                                </tr>
                            </tfoot>
                        </table>
                    </div>


                </div>
                <script>

                </script>
            </main>
        </div>
");
#nullable restore
#line 139 "E:\TFS Project\RG_ERP\RG.WEB\Areas\Embro\Views\GeneralLedger\Components\VoucherShortInfoTB\VoucherShortInfoTBVC.cshtml"
    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
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
<!--<script src=""~/AdminLTE-3.1.0/plugins/jquery/jquery.min.js""></script>
<script src=""~/js/customScripts/GenericHTTPRequest.js""></script>
<link href=""~/lib/jquery-alert/css/alert.css"" rel=""stylesheet"" />
<link href=""~/lib/jquery-alert/themes/default/theme.css"" rel=""stylesheet"" />-->

<script type=""text/javascript"">
    $(function () {

    });

</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<RG.Application.Contracts.Embro.AccountsReports.Vouchers.Queries.QueryResponseModel.VoucherShortInfoTBRM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
