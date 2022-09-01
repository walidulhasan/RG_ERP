using Microsoft.EntityFrameworkCore;
using RG.Application.Common.CommonInterfaces;
using RG.DBEntities;
using RG.DBEntities.AOP.Business;
using RG.DBEntities.AOP.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.Persistence.AOPDB
{
    //class AOPDBContext
    //{
    //}
    public class AOPDBContext : DbContext
    {
        private readonly ICurrentUserService currentUserService;

        public AOPDBContext(DbContextOptions<AOPDBContext> options, ICurrentUserService _currentUserService)
       : base(options)
        {
            currentUserService = _currentUserService;
        }

        public DbSet<Tbl_Issuance_Master> Tbl_Issuance_Master { get; set; }
        public DbSet<Tbl_Issuance_Details> Tbl_Issuance_Details { get; set; }
        public DbSet<Tbl_PaymentType> Tbl_PaymentType { get; set; }
        public DbSet<tbl_challan_master> tbl_challan_master { get; set; }
        

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
