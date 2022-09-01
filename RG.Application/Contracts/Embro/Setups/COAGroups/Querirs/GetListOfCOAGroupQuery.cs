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

namespace RG.Application.Contracts.Embro.Setups.COAGroups.Querirs
{
    public class GetListOfCOAGroupQuery : IRequest<LoadResult>
    {
        public DataSourceLoadOptions LoadOptions { get; set; }
    }
    public class GetListOfCOAGroupQueryHandler : IRequestHandler<GetListOfCOAGroupQuery, LoadResult>
    {
        private readonly ICOAGroupService _cOAGroupService;

        public GetListOfCOAGroupQueryHandler(ICOAGroupService cOAGroupService)
        {
            _cOAGroupService = cOAGroupService;
        }
        public async Task<LoadResult> Handle(GetListOfCOAGroupQuery request, CancellationToken cancellationToken)
        {
            var dataQuery = _cOAGroupService.GetListOfCOAGroup();
            return await DataSourceLoader.LoadAsync(dataQuery, request.LoadOptions, cancellationToken);
        }
    }
}
