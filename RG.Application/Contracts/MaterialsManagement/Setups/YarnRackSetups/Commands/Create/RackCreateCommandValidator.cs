using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace RG.Application.Contracts.MaterialsManagement.Setups.YarnRackSetups.Commands.Create
{
    public class RackCreateCommandValidator: AbstractValidator<YarnRackCreateCommand>
    {
        private readonly IMaterialsManagementDBContext _dbCon;

        public RackCreateCommandValidator(IMaterialsManagementDBContext dbCon)
        {
            _dbCon = dbCon;
            RuleFor(b => b.yarnRackCreateVM.RackName).NotEmpty().WithMessage("Loan Type Name Can't be Null")
             .MustAsync(BeUniqueRack).WithMessage("Rack must be unique.");
        }
        public async Task<bool> BeUniqueRack(YarnRackCreateCommand model, string rackName, CancellationToken cancellationToken)
        {
            if (model.yarnRackCreateVM.RackID > 0)
            {
                return await _dbCon.YarnRackSetup
                .Where(l => l.IsRemoved == false && l.IsActive == true && (model.yarnRackCreateVM.RackID > 0 && l.RackID != model.yarnRackCreateVM.RackID))
                .AllAsync(l => l.RackName == rackName, cancellationToken);
            }

            var result = !await _dbCon.YarnRackSetup
                .Where(b => b.IsRemoved == false && b.IsActive == true)
                .AnyAsync(l => l.RackName == rackName && l.BuildingFloorID==model.yarnRackCreateVM.BuildingFloorID, cancellationToken);
            return result;
        }
    }
}
