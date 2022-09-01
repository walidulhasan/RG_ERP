using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class StyleRepository : GenericRepository<Style>, IStyleRepository
    {
        private readonly MaxcoDBContext dbCon;

        public StyleRepository(MaxcoDBContext _dbCon) : base(_dbCon)
        {
            dbCon = _dbCon;
        }
        public async Task<List<SelectListItem>> DDLOrders(DateTime? FromDate, int BuyerID = 0, string Predict = null, CancellationToken cancellationToken = default)
        {
            if (FromDate is null)
                FromDate = DateTime.Now.AddYears(-2).Date;

            var dataQuery = from b in dbCon.Buyer_Setup
                            join c in dbCon.Collection on b.ID equals c.BuyerID
                            join o in dbCon.Style on c.ID equals o.CollectionID
                            where o.Status == 5 && o.CreationDate >= FromDate
                             && (BuyerID == 0 || b.ID == BuyerID)
                             && (Predict == null || o.OrderNo.Contains(Predict))
                            select new
                            {
                                Buyer = b.Description.Trim(),
                                OrderID = o.ID,
                                OrderNo = o.OrderNo.Trim()
                            };
            var qq = dataQuery.ToQueryString();
            var parentGropu = await dataQuery.Select(b => $"{b.Buyer}")
                        .Distinct()
                        .Select(groupName => new SelectListGroup { Name = groupName })
                        .ToDictionaryAsync(group => group.Name, StringComparer.Ordinal, cancellationToken);

            var data = await dataQuery.Select(s => new SelectListItem
            {
                Text = s.OrderNo,
                Value = s.OrderID.ToString(),
                Group = parentGropu[s.Buyer]
            }).ToListAsync(cancellationToken);
            return data;

        }
        public async Task<List<SelectListItem>> DDLOrdersWithOutSample(DateTime? FromDate, int BuyerID = 0, string Predict = null, CancellationToken cancellationToken = default)
        {
            try
            {
                if (FromDate is null)
                    FromDate = DateTime.Now.AddYears(-2).Date;

            var excludeOrder = new List<string>()
            {
                "sa-","carton","Advance","ref"
            };

                var dataQuery = from b in dbCon.Buyer_Setup
                                join c in dbCon.Collection on b.ID equals c.BuyerID
                                join o in dbCon.Style on c.ID equals o.CollectionID
                                where o.Status == 5 && o.CreationDate >= FromDate
                                 && (BuyerID == 0 || b.ID == BuyerID)
                                 && !(o.OrderNo.Contains("sa-") || o.OrderNo.Contains("carton") || o.OrderNo.Contains("Advance") || o.OrderNo.Contains("ref"))
                                 //&& !excludeOrder.Any(x => o.OrderNo.Contains(x))
                                 //&& !excludeOrder.Any(x=>x==o.OrderNo)
                                 && (Predict == null || o.OrderNo.Contains(Predict))
                                select new
                                {
                                    Buyer = b.Description.Trim(),
                                    OrderID = o.ID,
                                    OrderNo = o.OrderNo.Trim()
                                };
                var qq = dataQuery.ToQueryString();
                var parentGropu = await dataQuery.Select(b => $"{b.Buyer}")
                            .Distinct()
                            .Select(groupName => new SelectListGroup { Name = groupName })
                            .ToDictionaryAsync(group => group.Name, StringComparer.Ordinal, cancellationToken);

                var data = await dataQuery.Select(s => new SelectListItem
                {
                    Text = s.OrderNo,
                    Value = s.OrderID.ToString(),
                    Group = parentGropu[s.Buyer]
                }).ToListAsync(cancellationToken);
                return data;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        public async Task<List<SelectListItem>> DDLGetOrderNo(int buyerID, DateTime OrderConditionDate, string Predict = null, CancellationToken cancellationToken = default)
        {

            var rtnList = from o in dbCon.Style
                          join c in dbCon.Collection on o.CollectionID equals c.ID
                          where o.Status == 5 && o.CreationDate >= OrderConditionDate
                          select new
                          {
                              BuyerID = c.BuyerID,
                              Text = o.OrderNo.Trim(),
                              Value = o.ID.ToString()
                          };
            if (buyerID > 0)
            {
                rtnList = rtnList.Where(b => b.BuyerID == buyerID);
            }
            if (Predict != null)
            {
                rtnList = rtnList.Where(b => b.Text.Contains(Predict));
            }
            var dataList = await rtnList.Select(x => new SelectListItem
            {
                Text = x.Text,
                Value = x.Value
            }).ToListAsync(cancellationToken);
            return dataList;

        }
    }
}
