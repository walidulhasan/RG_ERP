using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using RG.Application.Common.DevExtremeModelBinds;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using RG.Application.ViewModel.FiniteScheduler.Setup.MTMachineSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.MT_Machine_Setups.Queries
{
    public class GetListOfMachineQuery : IRequest<LoadResult>
    {
        public int CompanyID { get; set; }
        public int LocationID { get; set; }
        public int MachineGroupID { get; set; }
        public DataSourceLoadOptions LoadOptions { get; set; }
    }
    public class GetListOfMachineQueryHandler : IRequestHandler<GetListOfMachineQuery, LoadResult>
    {
        private readonly IMT_Machine_SetupService mT_Machine_SetupService;

        public GetListOfMachineQueryHandler(IMT_Machine_SetupService _mT_Machine_SetupService)
        {
            mT_Machine_SetupService = _mT_Machine_SetupService;
        }
        public async Task<LoadResult> Handle(GetListOfMachineQuery request, CancellationToken cancellationToken)
        {
           var dataQuery= mT_Machine_SetupService.GetListOfMachine(request.CompanyID, request.LocationID, request.MachineGroupID);
            return await DataSourceLoader.LoadAsync(dataQuery, request.LoadOptions, cancellationToken);            
        }
    }
    
}
