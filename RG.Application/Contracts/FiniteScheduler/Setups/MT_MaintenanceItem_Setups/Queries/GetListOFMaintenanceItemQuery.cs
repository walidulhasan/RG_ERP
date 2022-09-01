using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using RG.Application.Common.DevExtremeModelBinds;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.MT_MaintenanceItem_Setups.Queries
{
    public class GetListOFMaintenanceItemQuery : IRequest<LoadResult>
    {
        public int ItemCategoryID { get; set; }
        public DataSourceLoadOptions LoadOptions { get; set; }
    }
    public class GetListOFMaintenanceItemQueryHandler : IRequestHandler<GetListOFMaintenanceItemQuery, LoadResult>
    {
        private readonly IMT_MaintenanceItem_SetupService mT_MaintenanceItem_SetupService;

        public GetListOFMaintenanceItemQueryHandler(IMT_MaintenanceItem_SetupService _mT_MaintenanceItem_SetupService)
        {
            mT_MaintenanceItem_SetupService = _mT_MaintenanceItem_SetupService;
        }
        public async Task<LoadResult> Handle(GetListOFMaintenanceItemQuery request, CancellationToken cancellationToken)
        {
            var dataQuery = mT_MaintenanceItem_SetupService.GetListOFMaintenanceItem(request.ItemCategoryID);
            return await DataSourceLoader.LoadAsync(dataQuery, request.LoadOptions, cancellationToken);
        }
    }
}
