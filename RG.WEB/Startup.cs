using FluentValidation.AspNetCore;
using Hangfire;
using Hangfire.Storage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using RG.Application;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.Models;
using RG.Application.Common.Utilities;
using RG.Application.Constants;
using RG.Application.HangfireActive;
using RG.Application.IdentityEntities;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Business;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using RG.Application.Interfaces.Services.FiniteScheduler.Business;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using RG.Application.Interfaces.Services.Maxco.Business;
using RG.Application.Interfaces.Services.UserAuthGBS.API.UserInfos;
using RG.Infrastructure;
using RG.WEB.Helper;
using RG.WEB.Hubs;
using RG.WEB.Permission;
using RG.WEB.Services;
using System;
using System.Threading;

namespace RG.WEB
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var serverIP = StaticConfigs.GetConfig("ServerIPAddress");
            services.AddApplication();
            services.AddInfrastructure(Configuration);

            services.AddDetection();

            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddSingleton<ICurrentUserService, CurrentUserService>();
            services.AddSingleton<IEmailSenderService, EmailSenderService>();
            services.AddHttpContextAccessor();
            //services.AddTransient<IClaimsTransformation, ClaimsTransformer>();
            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, AdditionalUserClaimsPrincipalFactory>();
            //services.AddControllersWithViews(options =>
            //               options.Filters.Add<ApiExceptionFilterAttribute>())
            //                   .AddFluentValidation(x => x.AutomaticValidationEnabled = false);


            //services.AddTransient<CustomClaimsCookieSignInHelper<ApplicationUser>>();

            services.Configure<FormOptions>(options =>
            {
                options.ValueCountLimit = int.MaxValue;
                options.ValueLengthLimit = int.MaxValue;
            });

            services.AddControllersWithViews(options => options.Filters.Add<AppExceptionFilterAttribute>())
                .AddNewtonsoftJson(option =>
                {
                    option.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                })
                .AddFluentValidation(x =>
                {
                    //x.ImplicitlyValidateChildProperties = true;
                    x.AutomaticValidationEnabled = false;
                });

            services.AddRazorPages()
                .AddNewtonsoftJson(option =>
                {
                    option.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
            //.AddNewtonsoftJson(option => option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            #region Session
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(300);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            #endregion Session
            services.AddSignalR();

            services.AddAntiforgery(options =>
            {
                options.Cookie.Name = "X-CSRF-TOKEN-AJT-ERP";
                options.HeaderName = "X-CSRF-TOKEN-AJT-ERP";
                options.FormFieldName = "X-CSRF-TOKEN-AJT-ERP";
            });

            services.AddSingleton<IAuthorizationPolicyProvider, AuthorizationPolicyProvider>();
            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider, ILogger<Startup> _logger)
        {
            var serverIP = StaticConfigs.GetConfig("ServerIPAddress");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseDetection();
            app.UseRouting();

            var cookiePolicyOptions = new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
                HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always,
                Secure = CookieSecurePolicy.None,

            };
            app.UseCookiePolicy(cookiePolicyOptions);
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                            name: "areas", "areas",
                            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapHub<NotificationHub>("/NotificationHub");
                endpoints.MapHub<NoticeHub>("/NoticeHub");
                endpoints.MapRazorPages();

                if (env.IsDevelopment() == false && serverIP == Utilitys.GetLocalIPAddress())
                {
                    app.UseHangfireDashboard("/ScheduleConfig", new DashboardOptions
                    {
                        Authorization = new[] { new HangfireAuthorizationFilter() }
                    });
                }
            });
            if (env.IsDevelopment() == false && serverIP == Utilitys.GetLocalIPAddress())
            {
                GlobalConfiguration.Configuration.UseActivator(new HangfireActivator(serviceProvider));
            }

            /*
              if schedule is test than  add outside on live schede block.
            when it's done than add in live schedule block.
            */
            #region Live Schedule

            _logger.LogInformation($"Start up Schedule Generate At {DateTime.Now} and IP: {Utilitys.GetLocalIPAddress()}");

            //// this IP condtion ADD for generate only in server.
            if (env.IsDevelopment() == false && serverIP == Utilitys.GetLocalIPAddress())
            {
                _logger.LogInformation($"Start up Schedule Generate At {DateTime.Now} and IP: {Utilitys.GetLocalIPAddress()}");
                /*
                using (var connection = JobStorage.Current.GetConnection())
                {
                    foreach (var recurringJob in StorageConnectionExtensions.GetRecurringJobs(connection))
                    {
                        RecurringJob.RemoveIfExists(recurringJob.Id);
                    }
                }
                */
                RecurringJob.AddOrUpdate<IDFS_StockTransactionService>("Excess Dyeing Printing Wastage", r => r.GetDailyOrderFabricWastageExceededLot(DateTime.Now.AddDays(-1)), Cron.Daily(10, 00), TimeZoneInfo.Local);
                RecurringJob.AddOrUpdate<IOrderPlanReportsService>("Order Fabric Plan Data Generate at 8.00 AM", r => r.Plan_GenerateReportData_Schedue(), Cron.Daily(8, 00), TimeZoneInfo.Local);
                RecurringJob.AddOrUpdate<IOrderPlanReportsService>("Order Fabric Plan Data Generate 01.30 PM", r => r.Plan_GenerateReportData_Schedue(), Cron.Daily(13, 30), TimeZoneInfo.Local);
                RecurringJob.AddOrUpdate<IMT_MachineAndMaintenanceCheckListMasterRepository>("Generate Monthly Machine Maintenance Schedule every month of Day: 26 at 05.15 AM ", r => r.GenerateMonthlyMaintenanceSchedule(), Cron.Monthly(26, 5, 15), TimeZoneInfo.Local);
                RecurringJob.AddOrUpdate<IUserAccessInfoService>("New Employee ERP User Generate", r => r.AutoGenerateUserScheduler(), Cron.Daily(01, 15), TimeZoneInfo.Local);
                RecurringJob.AddOrUpdate<IDailyMailService>(Constants_EmailReport.DailyKnittingProductionReport, r => r.GetKnittingDailyProduction(DateTime.Now.AddDays(-1).Date), Cron.Daily(09, 45), TimeZoneInfo.Local);
                RecurringJob.AddOrUpdate<IDailyMailService>(Constants_EmailReport.KnittingProductionDefectNotification, r => r.KnittingProductionDefect(DateTime.Now.AddDays(-1).Date), Cron.Daily(09, 46), TimeZoneInfo.Local);
                RecurringJob.AddOrUpdate<IDailyMailService>(Constants_EmailReport.OverdueHnMInvoicesNotification, r => r.OverdueHnMInvoicesNotification(), Cron.Daily(09, 47), TimeZoneInfo.Local);
                RecurringJob.AddOrUpdate<IDailyMailService>(Constants_EmailReport.SubContractReturnableGatepass, r => r.SubContractGatePass(DateTime.Now.AddDays(-1).Date, DateTime.Now.AddDays(-1).Date), Cron.Daily(09, 48), TimeZoneInfo.Local);
                RecurringJob.AddOrUpdate<IDailyMailService>(Constants_EmailReport.RBLDelayedVoucherPostingERPFinancials, r => r.DelayedVoucherPostingRBL(DateTime.Now.AddDays(-6).Date), Cron.Daily(09, 48), TimeZoneInfo.Local);
                RecurringJob.AddOrUpdate<IDailyMailService>(Constants_EmailReport.CBLDelayedVoucherPostingERPFinancials, r => r.DelayedVoucherPostingCBL(DateTime.Now.AddDays(-6).Date), Cron.Daily(09, 49), TimeZoneInfo.Local);
                RecurringJob.AddOrUpdate<IDailyMailService>(Constants_EmailReport.RBLPendingDyeingLot, r => r.PendingDyeingLotsRBL(DateTime.Now.Date), Cron.Daily(09, 50), TimeZoneInfo.Local);
                RecurringJob.AddOrUpdate<IDailyMailService>(Constants_EmailReport.CBLPendingDyeingLot, r => r.PendingDyeingLotsCBL(DateTime.Now.Date), Cron.Daily(09, 51), TimeZoneInfo.Local);
                RecurringJob.AddOrUpdate<IDailyMailService>(Constants_EmailReport.UnsatisfiedReturnableGoods, r => r.UnsatisfiedReturnableGoods(), Cron.Daily(09, 52), TimeZoneInfo.Local);
                RecurringJob.AddOrUpdate<IDailyMailService>(Constants_EmailReport.DailyYarnTransaction, r => r.DailyYarnStockReport(DateTime.Now.AddDays(-1).Date, DateTime.Now.AddDays(-1).Date), Cron.Daily(09, 52), TimeZoneInfo.Local);
                RecurringJob.AddOrUpdate<IDailyMailService>(Constants_EmailReport.BTBCashLCOverdueMaturityNotification, r => r.BTB_Cash_LC_OverdueMaturityNotification(), Cron.Daily(09, 52), TimeZoneInfo.Local);
                RecurringJob.AddOrUpdate<IDailyMailService>(Constants_EmailReport.FDBPFDBC_EntryNotification, r => r.FDBP_FDBCEntryNotification(), Cron.Daily(09, 53), TimeZoneInfo.Local);
                RecurringJob.AddOrUpdate<IDailyMailService>(Constants_EmailReport.DailyKnittingShiftAndMachineWiseOverallPerformance, r => r.DailyKnittingShiftAndMachineWiseOverallPerformance(DateTime.Now.AddDays(-1).Date, DateTime.Now.AddDays(-1).Date), Cron.Daily(09, 54), TimeZoneInfo.Local);
                RecurringJob.AddOrUpdate<IDailyMailService>(Constants_EmailReport.DailyKnittingShiftAndMachineWiseKnittingDefects, r => r.DailyKnittingShiftAndMachineWiseKnittingDefects(DateTime.Now.AddDays(-1).Date, DateTime.Now.AddDays(-1).Date), Cron.Daily(09, 55), TimeZoneInfo.Local);
                RecurringJob.AddOrUpdate<IDailyMailService>(Constants_EmailReport.TopCuttingDefectsNotification, r => r.Top_Cutting_Defects(DateTime.Now.AddDays(-1).Date, DateTime.Now.AddDays(-1).Date), Cron.Daily(09, 56), TimeZoneInfo.Local);
                RecurringJob.AddOrUpdate<IDailyMailService>(Constants_EmailReport.LateDeliveryReportAccessoriesHnm, r => r.LateDeliveries_HNM(), Cron.Daily(09, 57), TimeZoneInfo.Local);
                RecurringJob.AddOrUpdate<IDailyMailService>(Constants_EmailReport.LateDeliveryReportAccessoriesResOfBuyer, r => r.LateDeliveries_Others(), Cron.Daily(09, 57), TimeZoneInfo.Local);
                RecurringJob.AddOrUpdate<IDailyMailService>(Constants_EmailReport.LateDeliveryReportConsumablesCBL, r => r.LateDeliveries_ConsumablesCBL(), Cron.Daily(09, 58), TimeZoneInfo.Local);
                RecurringJob.AddOrUpdate<IDailyMailService>(Constants_EmailReport.LateDeliveryReportConsumablesRBL, r => r.LateDeliveries_ConsumablesRBL(), Cron.Daily(09, 59), TimeZoneInfo.Local);
                RecurringJob.AddOrUpdate<IAssetInfoService>("Asset Deprication Generate", r => r.GenerateAssetDepreciation(null, new CancellationToken()), Cron.Yearly(6, 30, 22), TimeZoneInfo.Local);
                RecurringJob.AddOrUpdate<ISchedulerTaskService>("Modify Employee Attendance", r => r.ModifyAttendanceByShortLeaveAndOutsideDuty(new CancellationToken()), Cron.Daily(11, 0), TimeZoneInfo.Local);

            }


            #endregion Live Schedule

        }
    }
}
