#pragma checksum "E:\TFS Project\RG_ERP\RG.WEB\Areas\MaterialsManagement\Views\GatePassIssue\GatePassApprove.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5ab358124ac0ebeca006abc5910addd93b1bb079"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_MaterialsManagement_Views_GatePassIssue_GatePassApprove), @"mvc.1.0.view", @"/Areas/MaterialsManagement/Views/GatePassIssue/GatePassApprove.cshtml")]
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
#line 10 "E:\TFS Project\RG_ERP\RG.WEB\Areas\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "E:\TFS Project\RG_ERP\RG.WEB\Areas\MaterialsManagement\Views\GatePassIssue\GatePassApprove.cshtml"
using Microsoft.AspNetCore.Antiforgery;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ab358124ac0ebeca006abc5910addd93b1bb079", @"/Areas/MaterialsManagement/Views/GatePassIssue/GatePassApprove.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"579f12fddde6ad7d5e2e7207f508f2b104c1f8c2", @"/Areas/_ViewImports.cshtml")]
    public class Areas_MaterialsManagement_Views_GatePassIssue_GatePassApprove : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RG.Application.ViewModel.MaterialsManagement.Business.GatePassIssue.GatePassApproveVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("col-form-label-sm m-0 required"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control form-control-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("span-form-validation"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control form-control-sm dateField"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString("Date From"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "E:\TFS Project\RG_ERP\RG.WEB\Areas\MaterialsManagement\Views\GatePassIssue\GatePassApprove.cshtml"
  
    var token = antiForgeryToken.GetAndStoreTokens(Context);
    ViewData[PageInfo.PageHeader] = "Gate Pass Approve";
    ViewData[PageInfo.PageTitle] = "Gate Pass Approve";
    Layout = "~/Views/Shared/_Layout.cshtml";
    var deviceType = DetectionService.Device.Type.ToString();

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"card card-primary\">\r\n    <div class=\"row m-0\">\r\n        <div class=\"col-6 col-sm-3 col-md-3 col-lg-3\">\r\n            <div class=\"form-group\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ab358124ac0ebeca006abc5910addd93b1bb0797884", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
#nullable restore
#line 16 "E:\TFS Project\RG_ERP\RG.WEB\Areas\MaterialsManagement\Views\GatePassIssue\GatePassApprove.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.CategoryID);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ab358124ac0ebeca006abc5910addd93b1bb0799440", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#nullable restore
#line 17 "E:\TFS Project\RG_ERP\RG.WEB\Areas\MaterialsManagement\Views\GatePassIssue\GatePassApprove.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.CategoryID);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 17 "E:\TFS Project\RG_ERP\RG.WEB\Areas\MaterialsManagement\Views\GatePassIssue\GatePassApprove.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = Model.CategoryList;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ab358124ac0ebeca006abc5910addd93b1bb07911486", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 18 "E:\TFS Project\RG_ERP\RG.WEB\Areas\MaterialsManagement\Views\GatePassIssue\GatePassApprove.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.CategoryID);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"col-6 col-sm-3 col-md-3 col-lg-3\">\r\n            <div class=\"form-group\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ab358124ac0ebeca006abc5910addd93b1bb07913255", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
#nullable restore
#line 23 "E:\TFS Project\RG_ERP\RG.WEB\Areas\MaterialsManagement\Views\GatePassIssue\GatePassApprove.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ApprovalType);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ab358124ac0ebeca006abc5910addd93b1bb07914814", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#nullable restore
#line 24 "E:\TFS Project\RG_ERP\RG.WEB\Areas\MaterialsManagement\Views\GatePassIssue\GatePassApprove.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ApprovalType);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 24 "E:\TFS Project\RG_ERP\RG.WEB\Areas\MaterialsManagement\Views\GatePassIssue\GatePassApprove.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = Model.ApprovalTypeList;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ab358124ac0ebeca006abc5910addd93b1bb07916867", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 25 "E:\TFS Project\RG_ERP\RG.WEB\Areas\MaterialsManagement\Views\GatePassIssue\GatePassApprove.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ApprovalType);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
        </div>
        <div class=""col-12 col-sm-3 col-md-3 col-lg-3"">
            <div class=""input-group"">
                <div class=""col-6 col-sm-6 col-md-6 col-lg-6 p-0"">
                    <div class=""form-group"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ab358124ac0ebeca006abc5910addd93b1bb07918757", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
#nullable restore
#line 32 "E:\TFS Project\RG_ERP\RG.WEB\Areas\MaterialsManagement\Views\GatePassIssue\GatePassApprove.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.DateFrom);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "5ab358124ac0ebeca006abc5910addd93b1bb07920320", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
#nullable restore
#line 33 "E:\TFS Project\RG_ERP\RG.WEB\Areas\MaterialsManagement\Views\GatePassIssue\GatePassApprove.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.DateFrom);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("readonly", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ab358124ac0ebeca006abc5910addd93b1bb07922480", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 34 "E:\TFS Project\RG_ERP\RG.WEB\Areas\MaterialsManagement\Views\GatePassIssue\GatePassApprove.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.DateFrom);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"col-6 col-sm-6 col-md-6 col-lg-6 p-0 pl-2\">\r\n                    <div class=\"form-group\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ab358124ac0ebeca006abc5910addd93b1bb07924296", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
#nullable restore
#line 39 "E:\TFS Project\RG_ERP\RG.WEB\Areas\MaterialsManagement\Views\GatePassIssue\GatePassApprove.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.DateTo);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "5ab358124ac0ebeca006abc5910addd93b1bb07925857", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
#nullable restore
#line 40 "E:\TFS Project\RG_ERP\RG.WEB\Areas\MaterialsManagement\Views\GatePassIssue\GatePassApprove.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.DateTo);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("readonly", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ab358124ac0ebeca006abc5910addd93b1bb07928015", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 41 "E:\TFS Project\RG_ERP\RG.WEB\Areas\MaterialsManagement\Views\GatePassIssue\GatePassApprove.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.DateTo);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <div class=\"col-sm-3 col-md-3 col-lg-3\">\r\n");
#nullable restore
#line 47 "E:\TFS Project\RG_ERP\RG.WEB\Areas\MaterialsManagement\Views\GatePassIssue\GatePassApprove.cshtml"
             if (deviceType != "Mobile")
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <label class=\"col-form-label-sm m-0\">&nbsp;</label>\r\n");
#nullable restore
#line 50 "E:\TFS Project\RG_ERP\RG.WEB\Areas\MaterialsManagement\Views\GatePassIssue\GatePassApprove.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""form-group"">
                <input type=""button"" class=""btn btn-sm btn-warning"" value=""Search"" id=""btnSearch"" />
            </div>
        </div>
    </div>
    <div class=""row m-0"">
        <div class=""col-md-12 col-sm-12 col-xs-12"">
            <div class=""table-responsive-sm"" id=""grid"">
            </div>
        </div>
    </div>
</div>


");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">
        $(function () {
            GatePassList();
            $(""#btnSearch"").click(function () {
                GatePassList();
            })
        });
        function saveSuccess(data) {
            
            if (data.result == 1) {
                $.alert.open({
                    type: 'Success',
                    content: data.message,
                    callback: function () {
                        GatePassAccountIssueList();
                    }
                });
            }
            else {
                $.alert.open(""error"", data.message);
            }
        }
        function ApproveGatePass(gatePassId) {
            if (gatePassId > 0) {
                $.alert.open('confirm', 'Are you sure to approve this record', function (button) {
                    if (button == 'yes')
                        HttpRequest.Ajax(""Get"", ""/MaterialsManagement/GatePassIssue/AccountsApprove"", { gatePassID: gatePassId }, saveS");
                WriteLiteral(@"uccess);
                });
            }
        }
        function RejectGatePass(gatePassId) {
            if (gatePassId > 0) {
                $.alert.open('confirm', 'Are you sure to remove this record', function (button) {
                    if (button == 'yes')
                        HttpRequest.Ajax(""Get"", ""/MaterialsManagement/GatePassIssue/AccountsReject"", { gatePassID: gatePassId }, saveSuccess);
                });
            }
        }
        function GatePassList() {
            
            var url = ""/MaterialsManagement/GatePassIssue/GetGatePassApproveList"";
            let categoryID = RtnNumber($(""#CategoryID"").val());
            let category = $(""#CategoryID option:selected"").text();
            let approvalType = $(""#ApprovalType"").val();
            let dateFrom = $(""#DateFrom"").val();
            let dateTo = $(""#DateTo"").val();

            var reqModel = {
                CategoryID: categoryID,
                Category: category,
                Approv");
                WriteLiteral(@"alType: approvalType,
                StartDate: dateFrom,
                EndDate: dateTo,
                isApproved: approvalType
            }
            var dataGrid = $(""#grid"").dxDataGrid({

                dataSource: DevExpress.data.AspNet.createStore({
                    key: ""GatePassID"",
                    loadUrl: url,
                    loadParams: reqModel
                }),

                remoteOperations: {
                    paging: true,
                    sorting: true,
                    filtering: true,
                },

                showColumnLines: true,
                showRowLines: true,
                showBorders: true,
                pager: {
                    showInfo: true,
                    allowedPageSizes: [10, 20, 40, 100, 500],
                    showPageSizeSelector: true,
                },
                loadingIndicator: {
                    enabled: true
                },
                paging: { pageSize: 20 },
 ");
                WriteLiteral(@"               selection: { mode: 'single' },
                headerFilter: { visible: false, allowSearch: true },
                filterRow: { visible: true, applyFilter: 'auto' },
                wordWrapEnabled: true,
                columns: [
                    {
                        width: ""5%"",
                        caption: ""SL #"",
                        alignment: 'center',
                        headerCellTemplate: function (header, info) {
                            $('<div>').html(info.column.caption).css('font-weight', 'bold').appendTo(header);
                        },
                        cellTemplate: function (container, e) {

                            var index = e.rowIndex + 1;
                            container.text(index);
                        }

                    },

                    {
                        dataField: ""GatePassID"",
                        visible: false,
                    },
                    {
                    ");
                WriteLiteral(@"    width: ""10%"",
                        dataField: ""Category"",
                        alignment: 'center',
                        caption: 'Category',
                        dataField: ""CategoryName"",
                        cellTemplate: function (cellElement, options) {                            
                            var url = `<a style=""padding:0px;margin:0px;"" title=""Gate Pass"" target=""_blank"" class=""dx-link"" href=""/MaterialsManagement/GatePass/GatePassChallan?gatePassID=${options.data.GatePassID}&categoryID=${options.data.CategoryID}&reportType=1"">${options.data.CategoryName}</a>`;
                            cellElement.append(url);
                        }
                    },
                    {
                        width: ""12%"",                       
                        alignment: 'center',
                        caption: 'Serial No',                      
                        dataField:""Serial"",
                        cellTemplate: function (cellElement,");
                WriteLiteral(@" options) {
                             var url = `<a style=""padding:0px;margin:0px;"" title=""Challan""  target=""_blank"" class=""dx-link"" href=""/MaterialsManagement/GatePass/GatePassChallan?gatePassID=${options.data.GatePassID}&categoryID=${options.data.CategoryID}&reportType=2"">${options.data.Serial}</a>`;
                            cellElement.append(url);
                        }
                    },
                    {
                        width: ""10%"",
                        dataField: ""Date"",
                        alignment: 'center',
                        caption: 'Created Date',                        
                    },
                    {
                        width: ""10%"",
                        dataField: ""Time"",
                        alignment: 'center',
                        caption: 'Time',
                        hidingPriority: 0,
                        
                    },
                    {
                        width: ""15%"",
          ");
                WriteLiteral(@"              dataField: ""DepartmentName"",
                        alignment: 'center',
                        caption: 'Department',
                        hidingPriority: 1,
                        
                    },
                    {
                        width: ""15%"",
                        caption: ""Issed By"",
                        alignment: 'center',
                        allowFiltering: false,
                        dataField: ""CreatedEmployee"",

                    },
                    {
                        width: ""10%"",
                        caption: ""Department"",
                        alignment: 'center',
                        allowFiltering: false,
                        dataField: ""CreatedEmployeeDept"",
                        hidingPriority: 1,
                    },
                    {
                        width: ""10%"",
                        caption: ""Designation"",
                        alignment: 'center',
                     ");
                WriteLiteral(@"   allowFiltering: false,
                        dataField: ""CreatedEmployeeDesig"",
                        hidingPriority: 1,
                    },

                ],

                //headerFilter: {
                //    visible: true
                //},
                groupPanel: { visible: false },

                //scrolling: {
                //    mode: ""virtual""
                //},
                // width:1000,

                height: 520,
                showColumnLines: true,
                showRowLines: true,
                showBorders: true,
            }).dxDataGrid(""instance"");
        }
    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Wangkanai.Detection.Services.IDetectionService DetectionService { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IAntiforgery antiForgeryToken { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RG.Application.ViewModel.MaterialsManagement.Business.GatePassIssue.GatePassApproveVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
