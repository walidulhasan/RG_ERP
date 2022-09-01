using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.Embro.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Setups.COAGroups.Commands.Update
{
    public class COAGroupingRemoveCommand:IRequest<RResult>
    {
        public int Id { get; set; }
    }
    public class COAGroupingRemoveCommandHandler : IRequestHandler<COAGroupingRemoveCommand, RResult>
    {
        private readonly ICOAGroupService _cOAGroupService;

        public COAGroupingRemoveCommandHandler(ICOAGroupService cOAGroupService)
        {
            _cOAGroupService = cOAGroupService;
        }
        public async Task<RResult> Handle(COAGroupingRemoveCommand request, CancellationToken cancellationToken)
        {
            return await _cOAGroupService.Remove(request.Id, true);
        }
    }
}
