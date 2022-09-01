using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.DevExtremeModelBinds;
using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.ApprovalNotifications.Commands.Update;
using RG.Application.Contracts.AlgoHR.Business.ApprovalNotifications.Queries;
using RG.Application.Contracts.AlgoHR.Business.Tbl_Emp.Query;
using RG.Application.Contracts.AlgoHR.Business.Tbl_EmpLeavess.Commands.Update;
using RG.Application.Contracts.AlgoHR.Business.Tbl_EmpLeavess.Query.RequestResponseModel;
using RG.Application.Contracts.FiniteScheduler.Business.MT_MachineAndMaintenanceCheckListMasters.Queries;
using RG.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RG.WEB.Areas.AlgoHR.Controllers
{
    [Area("AlgoHR")]
    [Route("AlgoHR/[controller]/[action]")]
    public class NotificationController : BaseController
    {
        private readonly ICurrentUserService _currentUserService;

        public NotificationController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }
        public IActionResult MachineMaintenance()
        {
            return View();
        }
        public IActionResult LeaveApplication()
        {
            return View();
        }

        public IActionResult Outsidework()
        {
            return View();
        }
        #region Json Functions
        #region MachineMaintenance
        public async Task<JsonResult> GetMachineMaintenanceNotificationList(DataSourceLoadOptions loadOptions)
        {
            var userEmployee = await Mediator.Send(new GetEmpShortInfoByCodeQuery() { EmployeeCode = _currentUserService.EmployeeCode });
            var list = await Mediator.Send(new GetMachineMaintenanceNotificationListQurey { DesignationID = userEmployee.DesignationID, EmployeeID = (int)userEmployee.EmployeeID });
            loadOptions.PrimaryKey = new[] { "NotificationID" };
            loadOptions.PaginateViaPrimaryKey = true;
            var dataList = DataSourceLoader.Load(list, loadOptions);
            return Json(dataList);
        }
        public async Task<JsonResult> GetMachineAndMaintenanceCheckListDetail(int masterID)
        {
            var data = await Mediator.Send(new GetMachineAndMaintenanceCheckListDetailQuery { MasterID = masterID });
            return Json(data);
        }
        #endregion MachineMaintenance
        #region LeaveApplication
        public async Task<JsonResult> GetLeaveApplicationNotificationList(DataSourceLoadOptions loadOptions)
        {

            var list = await Mediator.Send(new GetLeaveApplicationNotificationListQuery { });
            loadOptions.PrimaryKey = new[] { "NotificationID" };
            loadOptions.SortByPrimaryKey = false;
            loadOptions.PaginateViaPrimaryKey = true;
            var dataList = DataSourceLoader.Load(list, loadOptions);
            return Json(dataList);
        }
        public async Task<JsonResult> GetOutsideWorkNotificationList(DataSourceLoadOptions loadOptions)
        {
            var list = await Mediator.Send(new GetOutsideWorkNotificationListQuery { });
            loadOptions.PrimaryKey = new[] { "NotificationID" };
            loadOptions.PaginateViaPrimaryKey = true;
            var dataList = DataSourceLoader.Load(list, loadOptions);
            return Json(dataList);
        }

        #endregion LeaveApplication

        [HttpPost]
        //[Authorize(Policy = "Permission_FiniteScheduler_Notification_Approve")]
        public async Task<JsonResult> ApproveNotification(List<int> notificationIDs, string comment, bool isAdjusted, int applicationID, DateTime? adjustedDateFrom, DateTime? adjustedDateTo)
        {
            RResult adjust = new();
            RResult data = new();
            if (isAdjusted)
            {
                adjust = await Mediator.Send(new AdjustEmpLeaveCommand { LeaveID = applicationID, AdjustedDateFrom = adjustedDateFrom.Value, AdjustedDateTo = adjustedDateTo.Value });
            }
            if (!isAdjusted || adjust.result == 1)
            {
                data = await Mediator.Send(new ApproveNotificationCommand { NotificationIDs = notificationIDs, Comment = comment });
            }
            else
            {
                data.result = 0;
                data.message = ReturnMessage.ErrorMessage;
            }

            return Json(data);
        }
        [HttpPost]
        //[Authorize(Policy = "Permission_FiniteScheduler_Notification_Approve")]
        public async Task<JsonResult> RejectNotification(int notificationID, string comment)
        {
            var data = await Mediator.Send(new RejectNotificationCommand { NotificationID = notificationID, Comment = comment });
            return Json(data);
        }
        [HttpPost]
        public async Task<JsonResult> EmpLeaveDetailInfo(LeaveHistoryDetailInfoQM queryModel)
        {
            var data = await Mediator.Send(new GetEmpLeaveDetailInfoQuery
            {
                QueryModel = new LeaveHistoryDetailInfoQM
                { EmployeeID = queryModel.EmployeeID, LeaveTypeID = queryModel.LeaveTypeID, SearchYear = queryModel.SearchYear, LeaveStatus = queryModel.LeaveStatus, LeaveStatusIndependent = queryModel.LeaveStatusIndependent }
            });
            return Json(data);
        }


        #endregion
    }
}
