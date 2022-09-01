using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RG.Application.Common.CommonInterfaces;
using RG.Application.IdentityEntities;
using RG.DBEntities;
using RG.DBEntities.UserAuthentication.DBViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.Persistence.UserAuthDB
{
    public class UserAuthDBContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserClaim,
             ApplicationUserRoles,
             IdentityUserLogin<int>,
             ApplicationRoleClaims,
             IdentityUserToken<int>>
    {
        private readonly ICurrentUserService _currentUserService;

        public UserAuthDBContext(DbContextOptions<UserAuthDBContext> options, ICurrentUserService currentUserService) : base(options)
        {
            _currentUserService = currentUserService;

        }

        #region tables
        //public DbSet<UserCompany> UserCompany { get; set; }
        //public DbSet<EmployeeInfo> EmployeeInfo { get; set; }
        //public DbSet<ProjectMenus> ProjectMenus { get; set; }
        //public DbSet<ProjectRoles> ProjectRoles { get; set; }
        //public DbSet<Projects> Projects { get; set; }
        //public DbSet<RoleWiseProjectMenus> RoleWiseProjectMenus { get; set; }
        //public DbSet<CompanyInfo> CompanyInfo { get; set; }
        //public DbSet<MenuGroups> MenuGroups { get; set; }
        //public DbSet<CompanyWiseProjects> CompanyWiseProjects { get; set; }
        //public DbSet<SecurityCheck> SecurityCheck { get; set; }
        //public DbSet<PageAccessability> PageAccessability { get; set; }
        //public DbSet<UserProjectBusiness> UserProjectBusiness { get; set; }

        #endregion tables

        #region Views
        public DbSet<Vw_UserEmployees> Vw_UserEmployees { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUserRoles>(b =>
            {
                b.HasKey(ur => new { ur.UserId, ur.RoleId, ur.ProjectID, ur.CompanyID });
            });

            //modelBuilder.Entity<EmployeeInfo>(entity =>
            //{
            //    entity.HasKey();
            //    entity.ToTable("EmployeeInfo", "dbo");
            //});            
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<DefaultTableProperties> entry in ChangeTracker.Entries<DefaultTableProperties>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.IsActive = true;
                        entry.Entity.IsRemoved = false;
                        entry.Entity.CreatedBy = _currentUserService.UserID;
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserID;
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }

            int result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
