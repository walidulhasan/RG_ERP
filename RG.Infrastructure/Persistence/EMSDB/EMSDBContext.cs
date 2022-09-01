using Microsoft.EntityFrameworkCore;
using RG.Application.Common.CommonInterfaces;
using RG.DBEntities;
using RG.DBEntities.EMS.Setup;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.Persistence.EMSDB
{

    public class EMSDBContext : DbContext
    {
        private readonly ICurrentUserService currentUserService;

        public EMSDBContext(DbContextOptions<EMSDBContext> options, ICurrentUserService _currentUserService)
       : base(options)
        {
            currentUserService = _currentUserService;
        }
        #region Setup
        public virtual DbSet<Tbl_Period> Tbl_Period { get; set; }
        #endregion
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<DefaultTableProperties>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.IsActive = true;
                        entry.Entity.IsRemoved = false;
                        entry.Entity.CreatedBy = currentUserService.UserID;
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = currentUserService.UserID;
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
