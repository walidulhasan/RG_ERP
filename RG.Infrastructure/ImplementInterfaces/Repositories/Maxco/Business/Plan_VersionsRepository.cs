using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.Maxco.Business;
using RG.DBEntities.Maxco.Business;
using RG.Infrastructure.Persistence.MaxcoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.Maxco.Business
{
    public class Plan_VersionsRepository : GenericRepository<Plan_Versions>, IPlan_VersionsRepository
    {
        private readonly MaxcoDBContext dbCon;
        public Plan_VersionsRepository(MaxcoDBContext _dbCon) : base(_dbCon)
        {
            dbCon = _dbCon;
        }

        public async Task<Plan_Versions> GetOrderWiseActivePlanVersion(int orderID, CancellationToken cancellationToken)
        {
            var data = await(from pv in dbCon.Plan_Versions
                             join p in dbCon.Plan_OrderMaster on pv.PlanID equals p.PlanID
                             where pv.IsActive==true && pv.IsRemoved == false && p.IsActive == true && p.IsRemoved == false
                             && p.OrderID == orderID
                             select pv).OrderByDescending(x=>x.PlanVersionID).FirstAsync(cancellationToken);
            return data;
        }

        public async Task<List<Plan_Versions>> GetOrderWisePlanVersions(int orderID, CancellationToken cancellationToken)
        {
            var data = await (from pv in dbCon.Plan_Versions
                              join p in dbCon.Plan_OrderMaster on pv.PlanID equals p.PlanID
                              where pv.IsRemoved == false && p.IsActive == true && p.IsRemoved == false
                              && p.OrderID == orderID
                              select pv).ToListAsync(cancellationToken);
            return data;
        }
    }
}
