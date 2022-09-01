using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using RG.Application.Common.CommonInterfaces;
using RG.Application.IdentityEntities;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace RG.WEB.Hubs
{
    public class NotificationHub : Hub
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IApprovalNotificationService approvalNotificationService;
        private readonly Ivw_ERP_EmpShortInfoService vw_ERP_EmpShortInfoService;
        private readonly ICurrentUserService currentUserService;
        private readonly IApprovalConfigMasterService approvalConfigMasterService;

        public NotificationHub(UserManager<ApplicationUser> _userManager, IApprovalNotificationService _approvalNotificationService,
            Ivw_ERP_EmpShortInfoService _vw_ERP_EmpShortInfoService, ICurrentUserService _currentUserService
            , IApprovalConfigMasterService _approvalConfigMasterService)
        {
            userManager = _userManager;
            approvalNotificationService = _approvalNotificationService;
            vw_ERP_EmpShortInfoService = _vw_ERP_EmpShortInfoService;
            currentUserService = _currentUserService;
            approvalConfigMasterService = _approvalConfigMasterService;
        }
        public async override Task OnConnectedAsync()
        {
            try
            {
                var user = await userManager.FindByNameAsync(Context.User.Identity.Name);
                var userEmployee = await vw_ERP_EmpShortInfoService.Get_ERP_EmpShortInfo(currentUserService.EmployeeCode);
                if (user != null && userEmployee != null)
                {//
                    await AddToGroup(userEmployee.EmployeeID.ToString());
                    //var userApprovalPower = await approvalConfigMasterService.GetUserApprovalPower(userEmployee.DesignationID, (int)userEmployee.EmployeeID, new CancellationToken());
                    //foreach (var item in userApprovalPower)
                    //{
                    //    await AddToGroup(item.ApproverGroup);
                    //}
                }
                else
                {
                    await Clients.Caller.SendAsync("ReceiveNotification", "Connection Error", 0);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
        public async Task SendNotification(string group)
        {
            var allNotifications = await approvalNotificationService.GetAllNotifications();
            var notification = allNotifications.Where(x => x.NotificationGroup == currentUserService.EmployeeID.ToString()).ToList();
            await Clients.Group(currentUserService.EmployeeID.ToString()).SendAsync("ReceiveNotification", JsonSerializer.Serialize(notification));


            //foreach (var item in allNotifications)
            //{
            //    var notification = allNotifications.Where(x => x.NotificationGroup == item.NotificationGroup).ToList();
            // await Clients.Group(item.NotificationGroup).SendAsync("ReceiveNotification", JsonSerializer.Serialize(notification));
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
    }
}
