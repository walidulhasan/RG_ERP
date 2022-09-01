using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.Models;
using RG.Application.Common.Utilities;
using RG.Application.IdentityEntities;
using RG.Application.Interfaces.Repositories;
using RG.Application.Interfaces.Repositories.AlgoHR;
using RG.Application.Interfaces.Repositories.Embro;
using RG.Application.Interfaces.Repositories.FiniteScheduler;
using RG.Application.Interfaces.Repositories.MaterialsManagement;
using RG.Infrastructure.ImplementInterfaces.CommonServices;
using RG.Infrastructure.ImplementInterfaces.Repositories;
using RG.Infrastructure.ImplementInterfaces.Repositories.MaterialsManagement.Setups;
using RG.Infrastructure.ImplementInterfaces.Services.MaterialsManagement.Setups;
using RG.Infrastructure.Persistence.AlgoHRDB;
using RG.Infrastructure.Persistence.AOPDB;
using RG.Infrastructure.Persistence.EmbroDB;
using RG.Infrastructure.Persistence.EMSDB;
using RG.Infrastructure.Persistence.FiniteSchedulerDB;
using RG.Infrastructure.Persistence.MaterialsManagementDB;
using RG.Infrastructure.Persistence.MaxcoDB;
using RG.Infrastructure.Persistence.UserAuthDB;
using System;
using System.Reflection;

namespace RG.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var serverIP = StaticConfigs.GetConfig("ServerIPAddress");
            #region DbConnection 

            services.AddDbContext<UserAuthDBContext>(options =>
                      options.UseSqlServer(
                      configuration.GetConnectionString("AuthConnection")));

            services.AddIdentity<ApplicationUser, ApplicationRole>(
                options =>
                {
                    options.SignIn.RequireConfirmedEmail = false;
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
                    options.Lockout.MaxFailedAccessAttempts = 5;
                })
                .AddEntityFrameworkStores<UserAuthDBContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";

                options.User.RequireUniqueEmail = false;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings

                options.Cookie.Name = "RG_ERP_APP_COOKIE";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(2);
                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            #region DB
            services.AddDbContext<MaxcoDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MaxcoConnection"));
                options.EnableSensitiveDataLogging();
            });
            services.AddDbContext<MaterialsManagementDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MaterialsManagementConnection"));
                options.EnableSensitiveDataLogging();
            });
            services.AddDbContext<FiniteSchedulerDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("FiniteSchedulerConnection"));
                options.EnableSensitiveDataLogging();
            });
            services.AddScoped<IFiniteSchedulerDBContext>(provider => provider.GetService<FiniteSchedulerDBContext>());
            services.AddScoped<IEmbroDBContext>(provider => provider.GetService<EmbroDBContext>());
            services.AddScoped<IMaterialsManagementDBContext>(provider => provider.GetService<MaterialsManagementDBContext>());

            services.AddDbContext<EmbroDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("EmbroConnection"));
                options.EnableSensitiveDataLogging();
            });
            services.AddDbContext<AlgoHRDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("AlgoHRConnection"));
                options.EnableSensitiveDataLogging();
            });
            services.AddScoped<IAlgoHRDBContext>(provider => provider.GetService<AlgoHRDBContext>());

            services.AddDbContext<AOPDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("AOPConnection"));
                options.EnableSensitiveDataLogging();
            });
            services.AddDbContext<EMSDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("EMSConnection"));
                options.EnableSensitiveDataLogging();
            });
            #endregion DB

            #endregion
            services.AddTransient<IIdentityService, IdentityService>();

            var IsDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if (IsDevelopment != "Development" && serverIP == Utilitys.GetLocalIPAddress())
            {
                //services.AddHangfire(x => x.UseSqlServerStorage(configuration.GetConnectionString("AuthConnection")));
                services.AddHangfire(config =>
                config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseMemoryStorage()); 
                services.AddHangfireServer();
            }
            //services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            //services.AddScoped<IDomainEventService, DomainEventService>();

            //services
            //    .AddDefaultIdentity<ApplicationUser>()
            //    .AddRoles<IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            //services.AddIdentityServer()
            //    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            //services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            Dependency(services, configuration);
            services.AddAuthentication(defaultScheme: CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.Name = "RG_ERP_APP_COOKIE";
                    options.Cookie.HttpOnly = true;
                    options.ExpireTimeSpan = TimeSpan.FromDays(2);
                    options.LoginPath = "/Identity/Account/Login";
                    options.LogoutPath = "/Identity/Account/LogOut";
                    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                    options.Cookie.SameSite = SameSiteMode.Lax;
                    options.SlidingExpiration = true;
                });

            //.AddIdentityServerJwt();

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator"));
            //});

            return services;
        }

        public static void Dependency(this IServiceCollection services, IConfiguration configuration)
        {


            #region Assembly Repository
            var assembliesToScan = new[]
                   {
                        Assembly.GetExecutingAssembly(),
                               Assembly.GetAssembly(typeof(MM_MRPItemRepository)),
                        Assembly.GetAssembly(typeof(MM_MRPItemService)),

                   };

            //This registers the service layer: I only register the classes who name ends with "Service" (at the moment)
            services.RegisterAssemblyPublicNonGenericClasses(assembliesToScan)
                .Where(s => s.Name.EndsWith("Repository")
                         || s.Name.EndsWith("Service"))
                .AsPublicImplementedInterfaces();

            //  Now I register the  assembly used by DevModService
            // services.RegisterAssemblyPublicNonGenericClasses(
            //          Assembly.GetAssembly(typeof(Tbl_CompanyService)))
            //     .AsPublicImplementedInterfaces();

            // services.RegisterAssemblyPublicNonGenericClasses(
            //     Assembly.GetAssembly(typeof(Tbl_CompanyRepository)))
            //.AsPublicImplementedInterfaces();


            //Put any code here to initialise values from the configuration parameter
            #endregion Assembly Repository

        }
    }
}
