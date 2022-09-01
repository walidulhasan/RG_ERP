using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.KPIParticularValuess.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.KPIParticularValuess.Commands.Create
{
    public class KPIParticularValuesCreateCommand:IRequest<RResult>
    {
        public List<CompanyKPICreateDTM> KPIData { get; set; }
    }
    public class KPIParticularValuesCreateCommandHandler : IRequestHandler<KPIParticularValuesCreateCommand, RResult>
    {
        private readonly IKPIParticularValuesService _kpiParticularValuesService;

        public KPIParticularValuesCreateCommandHandler(IKPIParticularValuesService kpiParticularValuesService)
        {
            _kpiParticularValuesService = kpiParticularValuesService;
        }
        public async Task<RResult> Handle(KPIParticularValuesCreateCommand request, CancellationToken cancellationToken)
        {
            return await _kpiParticularValuesService.KPIParticularValuesCreate(request.KPIData, cancellationToken);
        }
    }
}
