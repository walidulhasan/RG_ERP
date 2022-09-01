using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.Embro.Setups;
using RG.Application.ViewModel.Embro.Setup.COAGroupings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Setups.COAGroups.Commands.Create
{
    public class COAGroupingCreateCommand:IRequest<RResult>
    {
        public COAGroupingCreateVM COAGrouping { get; set; }
    }
    public class COAGroupingCreateCommandHandler : IRequestHandler<COAGroupingCreateCommand, RResult>
    {
        private readonly ICOAGroupService _cOAGroupingService;

        public COAGroupingCreateCommandHandler(ICOAGroupService cOAGroupingService)
        {
            _cOAGroupingService = cOAGroupingService;
        }
        public async Task<RResult> Handle(COAGroupingCreateCommand request, CancellationToken cancellationToken)
        {
            return await _cOAGroupingService.Create(request.COAGrouping, true);
        }
    }
}
