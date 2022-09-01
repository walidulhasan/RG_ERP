using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.AlgoHR.Setups.SystemNotices.Queries.RequestResponseModel;
using RG.Application.IdentityEntities;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace RG.WEB.Hubs
{
    public class NoticeHub : Hub
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly ISystemNoticeService _systemNoticeService;
        private readonly Ivw_ERP_EmpShortInfoService _vw_ERP_EmpShortInfoService;

        public NoticeHub(ICurrentUserService currentUserService, ISystemNoticeService systemNoticeService
            , Ivw_ERP_EmpShortInfoService vw_ERP_EmpShortInfoService)
        {
            _currentUserService = currentUserService;
            _systemNoticeService = systemNoticeService;
            _vw_ERP_EmpShortInfoService = vw_ERP_EmpShortInfoService;
        }
        public async override Task OnConnectedAsync()
        {
            try
            {
                var userID = _currentUserService.UserID;
                var employeeID = _currentUserService.EmployeeID;
                if (userID >0 && employeeID > 0)
                {//employeeID.ToString()
                    await AddToGroup("all");
                }
                else
                {
                    await Clients.Caller.SendAsync("ReceiveNotice", "Connection Error", 0);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task SendNotice(string group)
        {
            var userDetail = await _vw_ERP_EmpShortInfoService.Get_ERP_EmpShortInfo(_currentUserService.EmployeeCode);
            var allNotices = await _systemNoticeService.GetAllNotices(userDetail.EmbroCompanyID.Value, userDetail.DivisionID, userDetail.DepartmentID, userDetail.SectionID);
            var noticeGroup = "Company0";
            //_currentUserService.EmployeeID.ToString()
            await Clients.Group("all").SendAsync("ReceiveNotice", JsonSerializer.Serialize(allNotices));

            //List<SystemNoticeRM> userNotice = new();
            //foreach (var item in allNotices)
            //{
            //    if (item.SectionID > 0 && item.SectionID== userDetail.SectionID)
            //    {
            //        userNotice.Add(item);
            //    }
            //    else
            //    {

            //    }


            //    var notification = allNotifications.Where(x => x.NotificationGroup == item.NotificationGroup).ToList();
            //    await Clients.Group(item.NotificationGroup).SendAsync("ReceiveNotification", JsonSerializer.Serialize(notification));
            //}

        }
        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task RemoveFromGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
