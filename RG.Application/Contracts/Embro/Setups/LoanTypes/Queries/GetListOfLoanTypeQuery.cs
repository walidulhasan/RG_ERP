using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using RG.Application.Common.DevExtremeModelBinds;
using RG.Application.Interfaces.Services.Embro.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Setups.LoanTypes.Queries
{
    public class GetListOfLoanTypeQuery:IRequest<LoadResult>
    {
        public DataSourceLoadOptions LoadOptions { get; set; }
    }
    public class GetListOFLoanTypeQuery : IRequestHandler<GetListOfLoanTypeQuery, LoadResult>
    {
        private readonly ILoanTypeService _loanTypeService;

        public GetListOFLoanTypeQuery(ILoanTypeService loanTypeService)
        {
            _loanTypeService = loanTypeService;
        }
        public async Task<LoadResult> Handle(GetListOfLoanTypeQuery request, CancellationToken cancellationToken)
        {
            var dataQuery = _loanTypeService.GetAllGridData();
            return await DataSourceLoader.LoadAsync(dataQuery, request.LoadOptions, cancellationToken);
        }
    }
}
