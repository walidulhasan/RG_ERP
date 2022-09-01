using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.Maxco.Setup;
using RG.DBEntities.Maxco.Setup;
using RG.Infrastructure.Persistence.MaxcoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.Maxco.Setup
{
    public class Buyer_SetupRepository : GenericRepository<Buyer_Setup>, IBuyer_SetupRepository
    {
        private readonly MaxcoDBContext _dbCon;
        public Buyer_SetupRepository(MaxcoDBContext maxcoDBContext) : base(maxcoDBContext)
        {
            _dbCon = maxcoDBContext;
        }

        public async Task<List<SelectListItem>> DDLBuyerAllQuery(DateTime? OrderDateLimit=null,CancellationToken cancellationToken=default)
        {
            if (OrderDateLimit == null)
            {
                OrderDateLimit = DateTime.Now.AddYears(-2);
            }
            var dataQuery = from b in _dbCon.Buyer_Setup
                            join c in _dbCon.Collection on b.ID equals c.BuyerID
                            join o in _dbCon.Style on c.ID equals o.CollectionID
                            where o.Status == 5 && o.CreationDate >= OrderDateLimit
                            group b by new { b.ID, b.Description } into bo
                            select new SelectListItem()
                            {
                                Text = bo.Key.Description.Trim(),
                                Value = bo.Key.ID.ToString()
                            };
            return await dataQuery.ToListAsync(cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLBuyerOfPlannedOrders(CancellationToken cancellationToken)
        {
            var data = await (from b in _dbCon.Buyer_Setup
                              join c in _dbCon.Collection on b.ID equals c.BuyerID
                              join o in _dbCon.Style on c.ID equals o.CollectionID
                              join p in _dbCon.Plan_OrderMaster on o.ID equals p.OrderID
                              select new SelectListItem
                              {
                                  Text = b.Description.Trim(),
                                  Value = b.ID.ToString()
                              }).Distinct().ToListAsync(cancellationToken);
            return data;
        }
    }
}
