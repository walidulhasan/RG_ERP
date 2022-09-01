using MediatR;
using RG.Application.Interfaces.Services.Embro.Setups;
using RG.DBEntities.Embro.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Setups.Tbl_Currency_Details.Querirs
{
    public class GetCurrencyRateQuery:IRequest<tbl_Currency_Detail>
    {
        public long CurrencyId { get; set; }
    }
    public class GetCurrencyRateQueryHandler : IRequestHandler<GetCurrencyRateQuery, tbl_Currency_Detail>
    {
        private readonly Itbl_Currency_DetailService _itbl_Currency_DetailService;

        public GetCurrencyRateQueryHandler(Itbl_Currency_DetailService itbl_Currency_DetailService)
        {
            _itbl_Currency_DetailService = itbl_Currency_DetailService;
        }
        public async Task<tbl_Currency_Detail> Handle(GetCurrencyRateQuery request, CancellationToken cancellationToken)
        {
            return await _itbl_Currency_DetailService.GetCurrencyRate(request.CurrencyId, cancellationToken);
        }
    }
}
