using Microsoft.AspNetCore.Mvc.Rendering;
using RG.DBEntities.Maxco.Business;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.Maxco.Business
{
    public interface IStyleRepository : IGenericRepository<Style>
    {
        Task<List<SelectListItem>> DDLGetOrderNo(int buyerID, DateTime OrderConditionDate, string Predict = null, CancellationToken cancellationToken = default);
        Task<List<SelectListItem>> DDLOrders(DateTime? FromDate, int BuyerID = 0, string Predict = null, CancellationToken cancellationToken = default);
        Task<List<SelectListItem>> DDLOrdersWithOutSample(DateTime? FromDate, int BuyerID = 0, string Predict = null, CancellationToken cancellationToken = default);

    }
}
