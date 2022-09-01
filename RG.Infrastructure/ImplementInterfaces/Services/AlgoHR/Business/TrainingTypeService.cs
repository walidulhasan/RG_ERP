using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AlgoHR.Business
{
    public class TrainingTypeService : ITrainingTypeService
    {
        private readonly ITrainingTypeRepository _trainingTypeRepository;

        public TrainingTypeService(ITrainingTypeRepository trainingTypeRepository)
        {
            _trainingTypeRepository = trainingTypeRepository;
        }
        public async Task<List<SelectListItem>> DDLTrainingType(CancellationToken cancellationToken)
        {
            var data = (await _trainingTypeRepository.FindAllAsync(x => x.IsActive == true && x.IsRemoved == false))
                .Select(x => new SelectListItem
                {
                    Text=x.TrainingTypeName,
                    Value=x.ID.ToString()
                }).ToList();
            return data;
        }
    }
}
