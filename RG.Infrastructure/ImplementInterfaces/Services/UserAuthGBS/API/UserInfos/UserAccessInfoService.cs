using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.Models;
using RG.Application.Contracts.UserAuthGBS.API.UserInfos.Queries;
using RG.Application.Contracts.UserAuthGBS.Setup.DeviceMacWiseUser.RequestResponseModel;
using RG.Application.Contracts.UserAuthGBS.Setup.UsersDeviceDependency.RequestResponseModel;
using RG.Application.Interfaces.Services.UserAuthGBS.API.UserInfos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.UserAuthGBS.API.UserInfos
{
    public class UserAccessInfoService : IUserAccessInfoService
    {
        private readonly IWebHostEnvironment _env;
        private readonly ICurrentUserService _currentUserService;
        private readonly ILogger<UserAccessInfoService> _logger;

        public UserAccessInfoService(IWebHostEnvironment env, ICurrentUserService currentUserService
            , ILogger<UserAccessInfoService> logger)
        {
            _env = env;
            _currentUserService = currentUserService;
            _logger = logger;
        }
        public async Task<List<SelectListItem>> GetDDLCompany()
        {
            List<SelectListItem> rtexERPUserCompany = new();
            using (var httpClient = new HttpClient())
            {
                var secretKey = StaticConfigs.GetConfig("RTEXERP_Secret");
                var projectID = StaticConfigs.GetConfig("ApplicationID");
                string authenticationURL = "";
                if (_env.IsDevelopment())
                {
                    authenticationURL = StaticConfigs.GetConfig("AuthenticationDevelopmentURL");
                }
                else
                {
                    authenticationURL = StaticConfigs.GetConfig("AuthenticationProductionURL");
                }

                var apiUrl = $"{authenticationURL}UserInfoForOther/RtexERPUserCompany?Secret={secretKey}&UserID={_currentUserService.UserID}&ProjectID={projectID}";
                using var response = await httpClient.GetAsync(apiUrl);
                if (response != null)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    rtexERPUserCompany = JsonConvert.DeserializeObject<List<SelectListItem>>(apiResponse);
                }
            }
            return rtexERPUserCompany;
        }

        public async Task<List<SelectListItem>> GetDDLUserBusiness(int UserID, int companyID)
        {
            List<SelectListItem> rtexERPUserCompany = new();
            using (var httpClient = new HttpClient())
            {
                var secretKey = StaticConfigs.GetConfig("RTEXERP_Secret");
                var projectID = StaticConfigs.GetConfig("ApplicationID");
                string authenticationURL = "";
                if (_env.IsDevelopment())
                {
                    authenticationURL = StaticConfigs.GetConfig("AuthenticationDevelopmentURL");
                }
                else
                {
                    authenticationURL = StaticConfigs.GetConfig("AuthenticationProductionURL");
                }
                int _userID = _currentUserService.UserID == 0 ? UserID : _currentUserService.UserID;
                var apiUrl = $"{authenticationURL}UserInfoForOther/RtexERPUserBusiness?Secret={secretKey}&UserID={_userID}&ProjectID={projectID}&AlgoCompanyID={companyID}";
                using var response = await httpClient.GetAsync(apiUrl);
                if (response != null)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    rtexERPUserCompany = JsonConvert.DeserializeObject<List<SelectListItem>>(apiResponse);
                }
            }
            return rtexERPUserCompany;
        }

        public async Task<List<LoggedUserInfoResponseModel>> GetLoggedUserInfo(string UserName, int ProjectID, int? CompanyID, int? BusinessID)
        {
            var model = new List<LoggedUserInfoResponseModel>();
            using (var httpClient = new HttpClient())
            {
                var secretKey = StaticConfigs.GetConfig("RTEXERP_Secret");
                string authenticationURL = "";
                if (_env.IsDevelopment())
                {
                    authenticationURL = StaticConfigs.GetConfig("AuthenticationDevelopmentURL");
                }
                else
                {
                    authenticationURL = StaticConfigs.GetConfig("AuthenticationProductionURL");
                }
                //UserName,int ProjectID,int? CompanyID,int? BusinessID, string Secret
                var apiUrl = $"{authenticationURL}UserInfoForOther?Secret={secretKey}&UserName={UserName}&ProjectID={ProjectID}&CompanyID={CompanyID}&BusinessID={BusinessID}";
                using (var response = await httpClient.GetAsync(apiUrl))
                {
                    if (response != null)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        //if(response.)
                        model = JsonConvert.DeserializeObject<List<LoggedUserInfoResponseModel>>(apiResponse);

                        if (model.Count == 0)
                        {
                            throw new Exception("User is not set currect format");
                        }
                        if (model.Count == 1 && model[0].UserID == 0)
                        {
                            throw new Exception("User is not set currect format");
                        }
                    }
                    else
                    {
                        throw new Exception("User is not set currect format");
                    }
                }
            }
            return model;
        }

        public async Task<List<UserDashboardAccessRM>> GetUserDashboardAccessItems()
        {
            List<UserDashboardAccessRM> userDashboardAccess = new();
            using (var httpClient = new HttpClient())
            {
                var secretKey = StaticConfigs.GetConfig("RTEXERP_Secret");
                var projectID = StaticConfigs.GetConfig("ApplicationID");
                string authenticationURL = "";
                if (_env.IsDevelopment())
                {
                    authenticationURL = StaticConfigs.GetConfig("AuthenticationDevelopmentURL");
                }
                else
                {
                    authenticationURL = StaticConfigs.GetConfig("AuthenticationProductionURL");
                }

                var apiUrl = $"{authenticationURL}UserInfoForOther/RtexERPUserDashboardAccess?Secret={secretKey}&ProjectID={projectID}&UserID={_currentUserService.UserID}";
                using var response = await httpClient.GetAsync(apiUrl);
                if (response != null)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    userDashboardAccess = JsonConvert.DeserializeObject<List<UserDashboardAccessRM>>(apiResponse);
                }
            }
            return userDashboardAccess;
        }

        public async Task<string> GetUserMenu()
        {
            var menu = "";
            using (var httpClient = new HttpClient())
            {
                var secretKey = StaticConfigs.GetConfig("RTEXERP_Secret");
                var projectID = StaticConfigs.GetConfig("ApplicationID");
                string authenticationURL = "";
                if (_env.IsDevelopment())
                {
                    authenticationURL = StaticConfigs.GetConfig("AuthenticationDevelopmentURL");
                }
                else
                {
                    authenticationURL = StaticConfigs.GetConfig("AuthenticationProductionURL");
                }

                var apiUrl = $"{authenticationURL}UserInfoForOther/UserMenu?Secret={secretKey}&ProjectID={projectID}&RoleID={_currentUserService.RoleID}&UserID={_currentUserService.UserID}";//currentUserService.RoleID
                using var response = await httpClient.GetAsync(apiUrl);
                if (response != null)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    menu = apiResponse;
                }
            }
            return menu;
        }

        public async Task<string> AutoGenerateUserScheduler()
        {
            var menu = "";
            using (var httpClient = new HttpClient())
            {
                var secretKey = StaticConfigs.GetConfig("RTEXERP_Secret");
                var projectID = StaticConfigs.GetConfig("ApplicationID");
                string authenticationURL = "";
                if (_env.IsDevelopment())
                {
                    authenticationURL = StaticConfigs.GetConfig("AuthenticationDevelopmentURL");
                }
                else
                {
                    authenticationURL = StaticConfigs.GetConfig("AuthenticationProductionURL");
                }

                var apiUrl = $"{authenticationURL}UserInfoForOther/AutoGenerateUserScheduler?Secret={secretKey}";
                using var response = await httpClient.GetAsync(apiUrl);
                if (response != null)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    menu = apiResponse;
                }
            }
            return menu;
        }

        public async Task<UsersRM> GetUserInfo(int userID, int sourceUserID)
        {
            UsersRM userInfo = new();
            using (var httpClient = new HttpClient())
            {
                var secretKey = StaticConfigs.GetConfig("RTEXERP_Secret");
                string authenticationURL = "";
                if (_env.IsDevelopment())
                {
                    authenticationURL = StaticConfigs.GetConfig("AuthenticationDevelopmentURL");
                }
                else
                {
                    authenticationURL = StaticConfigs.GetConfig("AuthenticationProductionURL");
                }

                var apiUrl = $"{authenticationURL}UserInfoForOther/RtexERPUserInfo?userID={userID}&sourceUserID={sourceUserID}&secret={secretKey}";
                using var response = await httpClient.GetAsync(apiUrl);
                if (response != null)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    userInfo = JsonConvert.DeserializeObject<UsersRM>(apiResponse);
                }
            }
            return userInfo;
        }

        public async Task<bool> AuthenticateUserDevice(int userID, string deviceIdentity, string deviceType,string AppVersion=null)
        {
            using (var httpClient = new HttpClient())
            {
                var secretKey = StaticConfigs.GetConfig("RTEXERP_Secret");
                string authenticationURL = "";
                if (_env.IsDevelopment())
                {
                    authenticationURL = StaticConfigs.GetConfig("AuthenticationDevelopmentURL");
                }
                else
                {
                    authenticationURL = StaticConfigs.GetConfig("AuthenticationProductionURL");
                }

                var apiUrl = $"{authenticationURL}UserInfoForOther/RtexERPUserDeviceAuthentication?userID={userID}&deviceIdentity={deviceIdentity}&deviceType={deviceType}&secret={secretKey}&AppVersion={AppVersion}";
                using var response = await httpClient.GetAsync(apiUrl);
                if (response != null)
                {
                    string isuthenticated = await response.Content.ReadAsStringAsync();
                    return Convert.ToBoolean(isuthenticated);
                }
                else
                {
                    return false;
                }
            }
        }
        public async Task<string> AuthenticatedUserDeviceIdentity(string deviceType)
        {
            using (var httpClient = new HttpClient())
            {
                var secretKey = StaticConfigs.GetConfig("RTEXERP_Secret");
                string authenticationURL = "";
                if (_env.IsDevelopment())
                {
                    authenticationURL = StaticConfigs.GetConfig("AuthenticationDevelopmentURL");
                }
                else
                {
                    authenticationURL = StaticConfigs.GetConfig("AuthenticationProductionURL");
                }
                var userID = _currentUserService.UserID;
                var apiUrl = $"{authenticationURL}UserInfoForOther/RtexERPUserDeviceIdentity?userID={userID}&deviceType={deviceType}&secret={secretKey}";
                using var response = await httpClient.GetAsync(apiUrl);
                if (response != null)
                {
                    string deviceIdentity = await response.Content.ReadAsStringAsync();
                    return deviceIdentity;
                }
                else
                {
                    return null;
                }
            }
        }
        public async Task<List<SelectListItem>> DDLUsersDeviceDependencyType()
        {
            using (var httpClient = new HttpClient())
            {
                var secretKey = StaticConfigs.GetConfig("RTEXERP_Secret");
                string authenticationURL = "";
                if (_env.IsDevelopment())
                {
                    authenticationURL = StaticConfigs.GetConfig("AuthenticationDevelopmentURL");
                }
                else
                {
                    authenticationURL = StaticConfigs.GetConfig("AuthenticationProductionURL");
                }

                var apiUrl = $"{authenticationURL}UserInfoForOther/RtexERPDDLUserDeviceDependencyType?secret={secretKey}";
                using var response = await httpClient.GetAsync(apiUrl);
                if (response != null)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var dependencyType = JsonConvert.DeserializeObject<List<SelectListItem>>(apiResponse);
                    return dependencyType;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<List<SelectListItem>> DDLUsers(string predict)
        {
            using (var httpClient = new HttpClient())
            {
                var secretKey = StaticConfigs.GetConfig("RTEXERP_Secret");
                string authenticationURL = "";
                if (_env.IsDevelopment())
                {
                    authenticationURL = StaticConfigs.GetConfig("AuthenticationDevelopmentURL");
                }
                else
                {
                    authenticationURL = StaticConfigs.GetConfig("AuthenticationProductionURL");
                }

                var apiUrl = $"{authenticationURL}UserInfoForOther/RtexERPDDLUsers?Secret={secretKey}&Predict={predict}";
                using var response = await httpClient.GetAsync(apiUrl);
                if (response != null)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var dependencyType = JsonConvert.DeserializeObject<List<SelectListItem>>(apiResponse);
                    return dependencyType;
                }
                else
                {
                    return null;
                }
            }
        }
        public async Task<UserWiseDeviceDependencyRM> UserWiseDeviceDependency(int userID)
        {
            using (var httpClient = new HttpClient())
            {
                var secretKey = StaticConfigs.GetConfig("RTEXERP_Secret");
                string authenticationURL = "";
                if (_env.IsDevelopment())
                {
                    authenticationURL = StaticConfigs.GetConfig("AuthenticationDevelopmentURL");
                }
                else
                {
                    authenticationURL = StaticConfigs.GetConfig("AuthenticationProductionURL");
                }

                var apiUrl = $"{authenticationURL}UserInfoForOther/RtexERPUserWiseDeviceDependency?userID={userID}&secret={secretKey}";
                using var response = await httpClient.GetAsync(apiUrl);
                if (response != null)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var deviceDependency = JsonConvert.DeserializeObject<UserWiseDeviceDependencyRM>(apiResponse);
                    return deviceDependency;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<RResult> UpdateUserWiseDeviceDependency(int userID, int deviceDependencyTypeID)
        {
            using (var httpClient = new HttpClient())
            {
                var secretKey = StaticConfigs.GetConfig("RTEXERP_Secret");
                string authenticationURL = "";
                if (_env.IsDevelopment())
                {
                    authenticationURL = StaticConfigs.GetConfig("AuthenticationDevelopmentURL");
                }
                else
                {
                    authenticationURL = StaticConfigs.GetConfig("AuthenticationProductionURL");
                }

                var apiUrl = $"{authenticationURL}UserInfoForOther/RtexERPUpdateUserDeviceDependency?userID={userID}&deviceDependencyTypeID={deviceDependencyTypeID}&secret={secretKey}";
                using var response = await httpClient.GetAsync(apiUrl);
                if (response != null)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<RResult>(apiResponse);
                    return result;
                }
                else
                {
                    return null;
                }
            }
        }
        public async Task<RResult> RemoveUserDeviceAuth(int userID)
        {
            using (var httpClient = new HttpClient())
            {
                var secretKey = StaticConfigs.GetConfig("RTEXERP_Secret");
                string authenticationURL = "";
                if (_env.IsDevelopment())
                {
                    authenticationURL = StaticConfigs.GetConfig("AuthenticationDevelopmentURL");
                }
                else
                {
                    authenticationURL = StaticConfigs.GetConfig("AuthenticationProductionURL");
                }

                var apiUrl = $"{authenticationURL}UserInfoForOther/RtexERPRemoveUserDeviceAuth?userID={userID}&secret={secretKey}";
                using var response = await httpClient.GetAsync(apiUrl);
                if (response != null)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<RResult>(apiResponse);
                    return result;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<DeviceMacWiseUserRM> DeviceMacWiseUser(string deviceMac)
        {
            using (var httpClient = new HttpClient())
            {
                var secretKey = StaticConfigs.GetConfig("RTEXERP_Secret");
                string authenticationURL = "";
                if (_env.IsDevelopment())
                {
                    authenticationURL = StaticConfigs.GetConfig("AuthenticationDevelopmentURL");
                }
                else
                {
                    authenticationURL = StaticConfigs.GetConfig("AuthenticationProductionURL");
                }

                var apiUrl = $"{authenticationURL}UserInfoForOther/DeviceMacWiseUserInfo?deviceMac={deviceMac}&Secret={secretKey}";
                using var response = await httpClient.GetAsync(apiUrl);
                if (response != null)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var userInfo = JsonConvert.DeserializeObject<DeviceMacWiseUserRM>(apiResponse);
                    return userInfo;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<RResult> RemoveDeviceMacWiseDevice(string deviceMac,int UserID)
        {
            using (var httpClient = new HttpClient())
            {
                var secretKey = StaticConfigs.GetConfig("RTEXERP_Secret");
                string authenticationURL = "";
                if (_env.IsDevelopment())
                {
                    authenticationURL = StaticConfigs.GetConfig("AuthenticationDevelopmentURL");
                }
                else
                {
                    authenticationURL = StaticConfigs.GetConfig("AuthenticationProductionURL");
                }

                var apiUrl = $"{authenticationURL}UserInfoForOther/RemoveDeviceMacWiseDevice?deviceMac={deviceMac}&UserID={UserID}&Secret={secretKey}";
                using var response = await httpClient.GetAsync(apiUrl);
                if (response != null)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<RResult>(apiResponse);
                    return result;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
