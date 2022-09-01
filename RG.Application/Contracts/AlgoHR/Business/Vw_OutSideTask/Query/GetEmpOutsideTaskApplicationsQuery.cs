using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using RG.Application.Common.DevExtremeModelBinds;
using RG.Application.Contracts.AlgoHR.Business.Vw_OutSideTask.Query.RequestResponseModel;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Vw_OutSideTask.Query
{
   public class GetEmpOutsideTaskApplicationsQuery:IRequest<LoadResult>
    {
        public OutSideTaskSearchQM SearchModel { get; set; }
        public DataSourceLoadOptions loadOptions { get; set; }
    }
    public class GetEmpOutsideTaskApplicationsQueryHandler : IRequestHandler<GetEmpOutsideTaskApplicationsQuery, LoadResult>
    {
        private readonly IVw_OutSideTaskService vw_OutSideTaskService;

        public GetEmpOutsideTaskApplicationsQueryHandler(IVw_OutSideTaskService _vw_OutSideTaskService)
        {
            vw_OutSideTaskService = _vw_OutSideTaskService;
        }
        public async Task<LoadResult> Handle(GetEmpOutsideTaskApplicationsQuery request, CancellationToken cancellationToken)
        {
            var query = vw_OutSideTaskService.GetEmpOutsideTaskApplications(request.SearchModel, cancellationToken);
            
            request.loadOptions.PrimaryKey = new[] { "OutSideTaskID" };

            request.loadOptions.PaginateViaPrimaryKey = true;
            var returnData = await DataSourceLoader.LoadAsync(query, request.loadOptions, cancellationToken);
            return returnData;
        }
    }
}
