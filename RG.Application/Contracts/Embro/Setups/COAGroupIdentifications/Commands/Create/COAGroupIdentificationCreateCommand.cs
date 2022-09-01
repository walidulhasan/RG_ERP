using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.Embro.Setups;
using RG.DBEntities.Embro.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Setups.COAGroupIdentifications.Commands.Create
{
    public class COAGroupIdentificationCreateCommand:IRequest<RResult>
    {
        public List<COAGroupIdentification> GroupIdentification { get; set; }
    }
    public class COAGroupIdentificationCreateCommandHandler : IRequestHandler<COAGroupIdentificationCreateCommand, RResult>
    {
        private readonly ICOAGroupIdentificationService _cOAGroupIdentificationService;

        public COAGroupIdentificationCreateCommandHandler(ICOAGroupIdentificationService cOAGroupIdentificationService)
        {
            _cOAGroupIdentificationService = cOAGroupIdentificationService;
        }
        public async Task<RResult> Handle(COAGroupIdentificationCreateCommand request, CancellationToken cancellationToken)
        {
            return await _cOAGroupIdentificationService.Create(request.GroupIdentification, true);
        }
    }
}
