using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Contracts.Maxco.Buisness.Style.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.Maxco.Business
{
    public interface IStyleService
    {
        Task<List<SelectListItem>> DDLOrders(DateTime? FromDate,int BuyerID=0, string Predict=null, CancellationToken cancellationToken=default);
        Task<List<SelectListItem>> DDLGetOrderNo(int buyerID, DateTime OrderConditionDate, string Predict = null, CancellationToken cancellationToken = default);
        Task<StyleRM> GetStyleByID(long id, CancellationToken cancellationToken = default);
        Task<List<SelectListItem>> DDLOrdersWithOutSample(DateTime? FromDate, int BuyerID = 0, string Predict = null, CancellationToken cancellationToken = default);
    }
}
