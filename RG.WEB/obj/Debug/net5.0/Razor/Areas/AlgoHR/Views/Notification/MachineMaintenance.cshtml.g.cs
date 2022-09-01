#pragma checksum "E:\TFS Project\RG_ERP\RG.WEB\Areas\AlgoHR\Views\Notification\MachineMaintenance.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4789042619b5529e1e4bbe70e7364fbe12c92e29"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_AlgoHR_Views_Notification_MachineMaintenance), @"mvc.1.0.view", @"/Areas/AlgoHR/Views/Notification/MachineMaintenance.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4789042619b5529e1e4bbe70e7364fbe12c92e29", @"/Areas/AlgoHR/Views/Notification/MachineMaintenance.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"579f12fddde6ad7d5e2e7207f508f2b104c1f8c2", @"/Areas/_ViewImports.cshtml")]
    public class Areas_AlgoHR_Views_Notification_MachineMaintenance : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\TFS Project\RG_ERP\RG.WEB\Areas\AlgoHR\Views\Notification\MachineMaintenance.cshtml"
  
    ViewData[PageInfo.PageTitle] = "Machine Maintenance Notification";
    ViewData[PageInfo.PageHeader] = "Machine Maintenance Notification";

    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-md-12 col-sm-12"">
        <div id=""grid"">
        </div>
    </div>
</div>
<!-- Modal -->
<div id=""notificationDetailModal"" class=""modal fade"" role=""dialog"" style=""z-index:1050"">
    <div class=""modal-dialog modal-lg"">        
        <!-- Modal content-->
        <div class=""modal-content"">
            <div class=""modal-header p-2"">
                <h5 class=""modal-title"">Maintenance Detail</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
                <input type=""hidden"" id=""hdnNotificationID"" />
            </div>
            <div class=""modal-body"">
                <table id=""tblNotificationDetail"" class=""table table-sm table-striped table-bordered text-sm text-center"">
                    <thead class=""bg-dark"">
                        <tr>
                            <th>SL #</th>
                            <th>Item Name</th>
                            <th>Mechanical Comment</th>
           ");
            WriteLiteral(@"                 <th>Electrical Comment</th>
                        </tr>
                    </thead>
                    <tbody id=""tbodyNotificationDetail"">
                    </tbody>
                </table>
                <table class=""table table-sm table-striped table-bordered text-sm text-center"">
                    <thead class=""bg-dark"">
                        <tr>                           
                            <th>Final Mechanical Comment</th>
                            <th>Final Electrical Comment</th>
                        </tr>
                    </thead>
                    <tbody id=""tbodyCommentDetail"">
                    </tbody>
                </table>
            </div>
            <div class=""modal-footer p-1"">
                <button type=""button"" class=""btn btn-xs btn-danger mr-auto"" onclick=""ApproveRejectNotification('reject')"">Reject</button>
                <button type=""button"" class=""btn btn-xs btn-success"" onclick=""ApproveRejectNotification('");
            WriteLiteral("approve\')\">Approve</button>");
            WriteLiteral("\r\n\r\n            </div>\r\n        </div>\r\n\r\n    </div>\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        function saveSuccess(data) {

            if (data.result == 1) {

                $.alert.open({
                    type: 'Success',
                    content: data.message,
                    callback: function () {
                        $('#notificationDetailModal').modal('toggle');
                        NotificationList();
                    }
                });
            }
            else {
                $.alert.open(""error"", data.message);

            }
        }
        function ApproveRejectNotification(type) {

            $.alert.open('prompt', 'Are you sure to ' + type + ' this record?<br/>Enter your comment here :', function (button, value) {
              debugger
                if (button == 'ok') {
                    debugger;
                    if (value != """") {
                        let notificationIDs = new Array();
                        let notificationID = $(""#hdnNotificationID"").val();
                        notif");
                WriteLiteral(@"icationIDs.push(notificationID);

                        if (notificationIDs.length > 0) {
                            if (type=='approve') {
                                HttpRequest.Ajax(""POST"", '/AlgoHR/Notification/ApproveNotification', { ""notificationIDs"": notificationIDs, 'comment': value}, saveSuccess, true);
                            } else {
                                HttpRequest.Ajax(""POST"", '/AlgoHR/Notification/RejectNotification', { ""notificationID"": notificationID, 'comment': value}, saveSuccess, true);
                            }
                        }
                    } else {
                        $.alert.open('You must write a comment');
                    }

                }

            });
        }
        function NotificationDetails(data) {

            $(""#tbodyNotificationDetail"").html('');
            $(""#hdnNotificationID"").val(0);
            var dataDetail = HttpRequest.AjaxData('GET', '/AlgoHR/Notification/GetMachineAndMaintenanceCheckL");
                WriteLiteral(@"istDetail', { masterID: data.MaintenanceCheckMasterID });
            if (dataDetail.length > 0) {

                let electricalWorkerComments = dataDetail[0].ElectricalWorkerComments;
                let mechanicalWorkerComments = dataDetail[0].MechanicalWorkerComments;

                let tr = '';
                $.each(dataDetail, function (i, v) {
                    tr = tr + `<tr>
                            <td>${i + 1}</td>
                            <td>${v.ItemName}</td>
                            <td>${v.MechanicalComments}</td>
                            <td>${v.ElectricalComments}</td>
                        </tr>`;
                });
                $(""#hdnNotificationID"").val(data.NotificationID);
                $(""#tbodyNotificationDetail"").html(tr);

                let commentTr = `<tr><td>${mechanicalWorkerComments}</td><td>${electricalWorkerComments}</td></tr>`
                $(""#tbodyCommentDetail"").html(commentTr);
                $('#notificationDetailModal");
                WriteLiteral(@"').modal('toggle');
            }

        }
    function NotificationList() {
        var dataGrid = $(""#grid"").dxDataGrid({
        height: 510,
        remoteOperations: { paging: true, filtering: true, sorting: true, grouping: false, summary: false, groupPaging: false },
                dataSource: DevExpress.data.AspNet.createStore({
                    key: ""NotificationID"",
                    loadUrl: ""/AlgoHR/Notification/GetMachineMaintenanceNotificationList""
                }),
                hoverStateEnabled: true,

                showBorders: true,
               columnAutoWidth: true,
                 sorting: {
                   mode: ""multiple""
                 },
                filterRow: { visible: true },
                pager: { visible: true, showInfo: true, allowedPageSizes: [10, 20, 50, 100, 500], showPageSizeSelector: true, },
                paging: { pageSize: 10 },
                selection: { mode: 'single' },
                export: {
                 ");
                WriteLiteral(@"   //   enabled: true
                },
                columns: [
                    {
                        width: ""auto"",
                        caption: ""SL #"",
                        alignment: 'center',
                        headerCellTemplate: function (header, info) {
                            $('<div>').html(info.column.caption).css('font-weight', 'bold').appendTo(header);
                        },
                        cellTemplate: function (container, e) {
                            var index = dataGrid.pageIndex() * dataGrid.pageSize() + e.rowIndex + 1;
                            container.text(index);
                        }

                    },
                    {
                        dataField: ""NotificationID"",
                        visible: false,

                    },
                    //    {
                    //    dataField: ""CreationDate"",
                    //        visible: false,
                    //     sortOrder: ""desc"",");
                WriteLiteral(@"

                    //},
                    {
                        dataField: ""MachineName"",
                        alignment: 'center',
                        caption: 'Machine',
                        headerCellTemplate: function (header, info) {
                            $('<div>').html(info.column.caption).css('font-weight', 'bold').appendTo(header);
                        }
                    },
                    {
                        dataField: ""CheckedDate"",
                        alignment: 'center',
                        caption: 'Checked Date',
                        headerCellTemplate: function (header, info) {
                            $('<div>').html(info.column.caption).css('font-weight', 'bold').appendTo(header);
                        }
                    },
                    {
                        dataField: ""ScheduleDate"",
                        alignment: 'center',
                        caption: 'Schedule Date',
                      ");
                WriteLiteral(@"  headerCellTemplate: function (header, info) {
                            $('<div>').html(info.column.caption).css('font-weight', 'bold').appendTo(header);
                        }
                    },
                    {
                        dataField: ""TaskCompletedBy"",
                        alignment: 'center',
                        caption: 'Completed By',
                        headerCellTemplate: function (header, info) {
                            $('<div>').html(info.column.caption).css('font-weight', 'bold').appendTo(header);
                        }
                    },
                    {
                        dataField: ""TaskSupervisor"",
                        alignment: 'center',
                        caption: 'Supervised By',
                        headerCellTemplate: function (header, info) {
                            $('<div>').html(info.column.caption).css('font-weight', 'bold').appendTo(header);
                        }
                    },");
                WriteLiteral(@"
                    {
                        dataField: ""FirstAuthorityCommentsDate"",
                        alignment: 'center',
                        caption: 'First Comment',
                        headerCellTemplate: function (header, info) {
                            $('<div>').html(info.column.caption).css('font-weight', 'bold').appendTo(header);
                        }
                    },
                    {
                        dataField: ""LastAuthorityCommentsDate"",
                        alignment: 'center',
                        caption: 'Last Comment',
                        headerCellTemplate: function (header, info) {
                            $('<div>').html(info.column.caption).css('font-weight', 'bold').appendTo(header);
                        }
                    },
                    {
                        caption: ""Action"",
                        alignment: 'center',
                        headerCellTemplate: function (header, info) {
   ");
                WriteLiteral("                         $(\'<div>\').html(info.column.caption).css(\'font-weight\', \'bold\').appendTo(header);\r\n                        },\r\n                        cellTemplate: function (container, options) {\r\n");
                WriteLiteral(@"
                            var returnText = '<span>&nbsp;</span><button class=""btn btn-xs btn-info""><i class=""fa fa-bars""></i></button>';
                            returnText = returnText + '</div>';
                            $(returnText).on('dxclick', function () {
                                NotificationDetails(options.data);
                            }).appendTo(container);
                        }
                    }

                ]

            }).dxDataGrid(""instance"");
    }

    //    function DeleteRow(Id) {

    //    GenericDeleteAndGridLoad(""POST"", ""/Maxco/OrderInfo/DeleteOrder"", Id, OrderInfoList);
    //};
    $(document).ready(function () {
        NotificationList();
    });
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
