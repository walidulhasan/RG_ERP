#pragma checksum "E:\TFS Project\RG_ERP\RG.WEB\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4b616e23e8e2204cb66d95cd05bfc5095833e929"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "E:\TFS Project\RG_ERP\RG.WEB\Views\_ViewImports.cshtml"
using RG.WEB;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\TFS Project\RG_ERP\RG.WEB\Views\_ViewImports.cshtml"
using RG.WEB.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\TFS Project\RG_ERP\RG.WEB\Views\_ViewImports.cshtml"
using RG.Application.IdentityEntities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\TFS Project\RG_ERP\RG.WEB\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\TFS Project\RG_ERP\RG.WEB\Views\_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\TFS Project\RG_ERP\RG.WEB\Views\_ViewImports.cshtml"
using RG.Application.Constants;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\TFS Project\RG_ERP\RG.WEB\Views\_ViewImports.cshtml"
using RG.Application.Common.Utilities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\TFS Project\RG_ERP\RG.WEB\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Antiforgery;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\TFS Project\RG_ERP\RG.WEB\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b616e23e8e2204cb66d95cd05bfc5095833e929", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"42631b0f817df650a0c2ed79c0e487a7618822e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<RG.Application.Contracts.UserAuthGBS.API.UserInfos.Queries.UserDashboardAccessRM>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("User Image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-circle"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/AlgoHR/PaySlip/Salary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/AlgoHR/OutsideDuty/Application"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("dropdown-item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/AlgoHR/Training/UserTraining"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/AlgoHR/Training/TrainingCalendar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "E:\TFS Project\RG_ERP\RG.WEB\Views\Home\Index.cshtml"
  
    ViewData[PageInfo.PageTitle] = "Robintex Group";
    ViewData[PageInfo.PageHeader] = "Dashboard";

    var employeeCode = User.FindFirstValue(SessionKey.User_EMPLOYEE_Code) ?? "";
    var employeeName = User.FindFirstValue(SessionKey.EMPLOYEE_NAME) ?? "";
    var designation = User.FindFirstValue(SessionKey.USER_Designation_Name) ?? "";
    var department = User.FindFirstValue(SessionKey.USER_Department_Name) ?? "";

    var deviceType = DetectionService.Device.Type.ToString();



#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 22 "E:\TFS Project\RG_ERP\RG.WEB\Views\Home\Index.cshtml"
 if (deviceType == "Mobile")
{


#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""row border border-primary"">
        <div class=""col-12 col-sm-12 col-md-12 d-flex align-items-stretch flex-column"">
            <div class=""card bg-light d-flex flex-fill"">
                <div class=""card-header text-muted border-bottom-0 p-2"">
                    Profile
                </div>
                <div class=""card-body pt-0"">
                    <div class=""row"">
                        <div class=""col-5 col-sm-2 col-md-2 text-center "">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "4b616e23e8e2204cb66d95cd05bfc5095833e9298858", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1454, "~/HRemployee/", 1454, 13, true);
#nullable restore
#line 34 "E:\TFS Project\RG_ERP\RG.WEB\Views\Home\Index.cshtml"
AddHtmlAttributeValue("", 1467, employeeCode, 1467, 15, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("", 1482, ".jpg", 1482, 4, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"col-7 col-sm-10 col-md-10\">\r\n                            <h2 class=\"lead mb-0\"><b>");
#nullable restore
#line 37 "E:\TFS Project\RG_ERP\RG.WEB\Views\Home\Index.cshtml"
                                                 Write(employeeName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></h2>\r\n");
            WriteLiteral("                            <p class=\"text-muted text-sm text-xs mb-0\">");
#nullable restore
#line 39 "E:\TFS Project\RG_ERP\RG.WEB\Views\Home\Index.cshtml"
                                                                   Write(designation);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n                            <p class=\"text-muted text-sm text-xs\">");
#nullable restore
#line 40 "E:\TFS Project\RG_ERP\RG.WEB\Views\Home\Index.cshtml"
                                                              Write(department);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
            WriteLiteral("                        </div>\r\n\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            WriteLiteral("    <div class=\"row  border border-primary\">\r\n\r\n\r\n");
#nullable restore
#line 58 "E:\TFS Project\RG_ERP\RG.WEB\Views\Home\Index.cshtml"
           if (Model != null && Model.Any())
            {
                foreach (var itemAccessType in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""row"">
                        <div class=""col-sm-12 col-md-12"">
                            <div class=""card card-dark"">
                                <div class=""card-header m-0 p-1"">
                                    <h5 class=""card-title"">");
#nullable restore
#line 65 "E:\TFS Project\RG_ERP\RG.WEB\Views\Home\Index.cshtml"
                                                      Write(itemAccessType.AccessTypeName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                </div>\r\n                                <div class=\"card-body p-1 mb-0\">\r\n                                    <div class=\"row\">\r\n");
#nullable restore
#line 69 "E:\TFS Project\RG_ERP\RG.WEB\Views\Home\Index.cshtml"
                                         foreach (var item in itemAccessType.DDLAccessItems)
                                        {
                                            if (item.Text == "Leave")
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                <div class=""col-6 col-xl-3 col-md-3 col-sm-6 col-xs-6"">
                                                    <div class=""info-box"">
                                                        <span class=""info-box-icon bg-info elevation-1"" style=""border-radius:50%;""><a href=""/AlgoHR/EmployeeLeave/Application""><i class=""fas fa-calendar-alt""></i></a></span>
                                                        <div class=""info-box-content pr-0"">
                                                            <span class=""info-box-text"">");
#nullable restore
#line 77 "E:\TFS Project\RG_ERP\RG.WEB\Views\Home\Index.cshtml"
                                                                                   Write(item.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
            WriteLiteral(@"                                                        </div>
                                                        <!-- /.info-box-content -->
                                                    </div>
                                                    <!-- /.info-box -->
                                                </div>
");
#nullable restore
#line 85 "E:\TFS Project\RG_ERP\RG.WEB\Views\Home\Index.cshtml"
                                            }
                                            if (item.Text == "Leave History")
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                <div class=""col-6 col-xl-3 col-md-3 col-sm-6 col-xs-6"">
                                                    <div class=""info-box mb-3"">
                                                        <span class=""info-box-icon bg-blue elevation-1"" style=""border-radius:50%;""><a href=""/AlgoHR/EmployeeLeave/IndividualLeaveHistory""><i class=""fas fa-list-alt""></i></a></span>

                                                        <div class=""info-box-content pr-0"">
                                                            <span class=""info-box-text"">");
#nullable restore
#line 93 "E:\TFS Project\RG_ERP\RG.WEB\Views\Home\Index.cshtml"
                                                                                   Write(item.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
            WriteLiteral(@"                                                        </div>
                                                        <!-- /.info-box-content -->
                                                    </div>
                                                    <!-- /.info-box -->
                                                </div>
");
#nullable restore
#line 101 "E:\TFS Project\RG_ERP\RG.WEB\Views\Home\Index.cshtml"
                                            }
                                            else if (item.Text == "Attendance")
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                <div class=""col-6 col-xl-3 col-md-3 col-sm-6 col-xs-6"">
                                                    <div class=""info-box mb-3"">
                                                        <span class=""info-box-icon bg-danger elevation-1"" style=""border-radius:50%;""><a href=""/AlgoHR/EmployeeAttendance/MyAttendanceInfo""><i class=""far fa-clock""></i></a></span>

                                                        <div class=""info-box-content pr-0"">
                                                            <span class=""info-box-text"">");
#nullable restore
#line 109 "E:\TFS Project\RG_ERP\RG.WEB\Views\Home\Index.cshtml"
                                                                                   Write(item.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
            WriteLiteral(@"                                                        </div>
                                                        <!-- /.info-box-content -->
                                                    </div>
                                                    <!-- /.info-box -->
                                                </div>
");
#nullable restore
#line 117 "E:\TFS Project\RG_ERP\RG.WEB\Views\Home\Index.cshtml"
                                            }
                                            else if (item.Text == "Salary")
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                <div class=""col-6 col-xl-3 col-md-3 col-sm-6 col-xs-6"">
                                                    <div class=""info-box mb-3"">
                                                        <span class=""info-box-icon bg-success elevation-1"" style=""border-radius:50%;"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4b616e23e8e2204cb66d95cd05bfc5095833e92918636", async() => {
                WriteLiteral("<i class=\"fas fa-hand-holding-usd\"></i>");
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
            WriteLiteral("</span>\r\n\r\n                                                        <div class=\"info-box-content\">\r\n                                                            <span class=\"info-box-text\">");
#nullable restore
#line 125 "E:\TFS Project\RG_ERP\RG.WEB\Views\Home\Index.cshtml"
                                                                                   Write(item.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
            WriteLiteral(@"                                                        </div>
                                                        <!-- /.info-box-content -->
                                                    </div>
                                                    <!-- /.info-box -->
                                                </div>
");
#nullable restore
#line 132 "E:\TFS Project\RG_ERP\RG.WEB\Views\Home\Index.cshtml"
                                            }
                                            else if (item.Text == "Outside Duty")
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                <div class=""col-6 col-xl-3 col-md-3 col-sm-6 col-xs-6"">
                                                    <div class=""info-box mb-3"">
                                                        <span class=""info-box-icon bg-purple elevation-1"" style=""border-radius:50%;"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4b616e23e8e2204cb66d95cd05bfc5095833e92921260", async() => {
                WriteLiteral("<i class=\"fas fa-external-link-alt\"></i>");
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
            WriteLiteral("</span>\r\n\r\n                                                        <div class=\"info-box-content\">\r\n                                                            <span class=\"info-box-text\">");
#nullable restore
#line 140 "E:\TFS Project\RG_ERP\RG.WEB\Views\Home\Index.cshtml"
                                                                                   Write(item.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n\r\n                                                        </div>\r\n\r\n                                                    </div>\r\n\r\n                                                </div>\r\n");
#nullable restore
#line 147 "E:\TFS Project\RG_ERP\RG.WEB\Views\Home\Index.cshtml"
                                            }
                                            else if (item.Text == "Training")
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                <div class=""col-6 col-xl-3 col-md-3 col-sm-6 col-xs-6"">
                                                    <div class=""info-box mb-3"">
                                                        <span class=""info-box-icon elevation-1"" style=""border-radius: 50%; background-color: #d5a38bfa""><i class=""fa-solid fa-chalkboard-user""></i></span>
                                                        <div class=""dropdown mt-4"">
                                                            <button class=""btn dropdown-toggle"" type=""button"" data-toggle=""dropdown"" aria-expanded=""false"">
                                                           Training
                                                            </button>
                                                            <div class=""dropdown-menu"">
                                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4b616e23e8e2204cb66d95cd05bfc5095833e92924329", async() => {
                WriteLiteral("Training List");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" \r\n                                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4b616e23e8e2204cb66d95cd05bfc5095833e92925560", async() => {
                WriteLiteral("Training Calendar");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                             \r\n                                                            </div>\r\n                                                        </div>\r\n");
            WriteLiteral("\r\n                                                    </div>\r\n\r\n                                                </div>\r\n");
#nullable restore
#line 171 "E:\TFS Project\RG_ERP\RG.WEB\Views\Home\Index.cshtml"
                                            }
                                          
                                            else
                                            {
                                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 186 "E:\TFS Project\RG_ERP\RG.WEB\Views\Home\Index.cshtml"
                        
                                            }

                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </div>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 222 "E:\TFS Project\RG_ERP\RG.WEB\Views\Home\Index.cshtml"
                }
            }


        

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
#nullable restore
#line 228 "E:\TFS Project\RG_ERP\RG.WEB\Views\Home\Index.cshtml"

}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    <!--<script type=\"text/javascript\">\r\n\r\n        $(function () {-->\r\n\r\n\r\n");
                WriteLiteral("\r\n            <!--if (\'");
#nullable restore
#line 243 "E:\TFS Project\RG_ERP\RG.WEB\Views\Home\Index.cshtml"
                Write(Model[0].IsMaxcoTestServer);

#line default
#line hidden
#nullable disable
                WriteLiteral("\' === \'True\') {\r\n                $(\'.isMaxcoInDevMode\').removeClass(\'d-none\');\r\n        } else {\r\n                $(\'.isMaxcoInDevMode\').addClass(\'d-none\');\r\n            }\r\n            if (\'");
#nullable restore
#line 248 "E:\TFS Project\RG_ERP\RG.WEB\Views\Home\Index.cshtml"
            Write(Model[0].IsMaterialsManagementTestServer);

#line default
#line hidden
#nullable disable
                WriteLiteral("\' === \'True\') {\r\n                $(\'.isMaterialsManagementInDevMode\').removeClass(\'d-none\');\r\n        } else {\r\n                $(\'.isMaterialsManagementInDevMode\').addClass(\'d-none\');\r\n            }\r\n            if (\'");
#nullable restore
#line 253 "E:\TFS Project\RG_ERP\RG.WEB\Views\Home\Index.cshtml"
            Write(Model[0].IsFiniteSchedulerTestServer);

#line default
#line hidden
#nullable disable
                WriteLiteral("\' === \'True\') {\r\n                $(\'.isFiniteSchedulerInDevMode\').removeClass(\'d-none\');\r\n        } else {\r\n                $(\'.isFiniteSchedulerInDevMode\').addClass(\'d-none\');\r\n            }\r\n            if (\'");
#nullable restore
#line 258 "E:\TFS Project\RG_ERP\RG.WEB\Views\Home\Index.cshtml"
            Write(Model[0].IsEmbroTestServer);

#line default
#line hidden
#nullable disable
                WriteLiteral("\' === \'True\') {\r\n                $(\'.isEmbroInDevMode\').removeClass(\'d-none\');\r\n        } else {\r\n                $(\'.isEmbroInDevMode\').addClass(\'d-none\');\r\n        }\r\n        if (\'");
#nullable restore
#line 263 "E:\TFS Project\RG_ERP\RG.WEB\Views\Home\Index.cshtml"
        Write(Model[0].IsAOPTestServer);

#line default
#line hidden
#nullable disable
                WriteLiteral("\' === \'True\') {\r\n            $(\'.isAOPInDevMode\').removeClass(\'d-none\');\r\n        } else {\r\n            $(\'.isAOPInDevMode\').addClass(\'d-none\');\r\n            }\r\n            if (\'");
#nullable restore
#line 268 "E:\TFS Project\RG_ERP\RG.WEB\Views\Home\Index.cshtml"
            Write(Model[0].IsEMSTestServer);

#line default
#line hidden
#nullable disable
                WriteLiteral("\' === \'True\') {\r\n                $(\'.isEMSInDevMode\').removeClass(\'d-none\');\r\n        } else {\r\n                $(\'.isEMSInDevMode\').addClass(\'d-none\');\r\n            }\r\n            if (\'");
#nullable restore
#line 273 "E:\TFS Project\RG_ERP\RG.WEB\Views\Home\Index.cshtml"
            Write(Model[0].IsAlgoHRTestServer);

#line default
#line hidden
#nullable disable
                WriteLiteral("\' === \'True\') {\r\n                $(\'.isAlgoHRInDevMode\').removeClass(\'d-none\');\r\n        } else {\r\n                $(\'.isAlgoHRInDevMode\').addClass(\'d-none\');\r\n        }\r\n    });\r\n    </script>-->\r\n");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Wangkanai.Detection.Services.IDetectionService DetectionService { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<RG.Application.Contracts.UserAuthGBS.API.UserInfos.Queries.UserDashboardAccessRM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
