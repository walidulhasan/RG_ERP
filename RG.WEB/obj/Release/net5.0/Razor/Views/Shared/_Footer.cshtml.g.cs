#pragma checksum "E:\TFS Project\RG_ERP\RG.WEB\Views\Shared\_Footer.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f46c805679cc5e82c5a4d97eb6aeb30014ab5d5d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Footer), @"mvc.1.0.view", @"/Views/Shared/_Footer.cshtml")]
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
#nullable restore
#line 1 "E:\TFS Project\RG_ERP\RG.WEB\Views\Shared\_Footer.cshtml"
using RG.Application.Common.CommonInterfaces;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f46c805679cc5e82c5a4d97eb6aeb30014ab5d5d", @"/Views/Shared/_Footer.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"42631b0f817df650a0c2ed79c0e487a7618822e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Footer : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "E:\TFS Project\RG_ERP\RG.WEB\Views\Shared\_Footer.cshtml"
string companyName = "Robintex-Group Bangladesh";
    if (!String.IsNullOrEmpty(_currentUserService.CompanyName))
    {
        companyName= _currentUserService.CompanyName;
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("<footer class=\"main-footer\">\r\n    <strong class=\"text-xs text-sm text-md\">Copyright &copy; ");
#nullable restore
#line 12 "E:\TFS Project\RG_ERP\RG.WEB\Views\Shared\_Footer.cshtml"
                                                        Write(DateTime.Now.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <a href=\"http://www.robintexbd.com/\">");
#nullable restore
#line 12 "E:\TFS Project\RG_ERP\RG.WEB\Views\Shared\_Footer.cshtml"
                                                                                                                Write(companyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>.</strong>\r\n    All rights reserved.\r\n    <div class=\"float-right d-none d-sm-inline-block\">\r\n        <b>Version</b> 0.0.1.0\r\n    </div>\r\n</footer>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ICurrentUserService _currentUserService { get; private set; }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
