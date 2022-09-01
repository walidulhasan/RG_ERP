using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Contracts.Maxco.Buisness.Style.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.Maxco.Business;
using RG.Application.Interfaces.Services.Maxco.Business;
using RG.DBEntities.Maxco.Business;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.Maxco.Business
{
    public class StyleService : IStyleService
    {
        private readonly IStyleRepository styleRepository;
        private readonly IMapper mapper;

        public StyleService(IStyleRepository _styleRepository, IMapper _mapper)
        {
            styleRepository = _styleRepository;
            mapper = _mapper;
        }
        public async Task<List<SelectListItem>> DDLOrders(DateTime? FromDate, int BuyerID = 0, string Predict = null, CancellationToken cancellationToken = default)
        {
            return await styleRepository.DDLOrders(FromDate, BuyerID, Predict, cancellationToken);
        }
        public async Task<StyleRM> GetStyleByID(long id, CancellationToken cancellationToken = default)
        {
            try
            {
                var entity = await styleRepository.GetByIdAsync(id);

                var model = mapper.Map<Style, StyleRM>(entity);
                model.OrderNo = model.OrderNo.Trim();
                return model;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        public async Task<List<SelectListItem>> DDLGetOrderNo(int buyerID, DateTime OrderConditionDate, string Predict = null, CancellationToken cancellationToken = default)
        {
            return await styleRepository.DDLGetOrderNo(buyerID, OrderConditionDate, Predict, cancellationToken);
        }

        public  async Task<List<SelectListItem>> DDLOrdersWithOutSample(DateTime? FromDate, int BuyerID = 0, string Predict = null, CancellationToken cancellationToken = default)
        {
            return await styleRepository.DDLOrdersWithOutSample(FromDate, BuyerID,Predict,cancellationToken);
        }
    }
}
