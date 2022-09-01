using RG.Application.Common.Models;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Setup
{
    public class TrainingDocumentsService : ITrainingDocumentsService
    {
        private readonly ITrainingDocumentsRepository _trainingDocumentsRepository;

        public TrainingDocumentsService(ITrainingDocumentsRepository trainingDocumentsRepository)
        {
            _trainingDocumentsRepository = trainingDocumentsRepository;
        }
        public async Task<RResult> DeleteDocument(int id)
        {
            RResult rResult = new();
            try
            {
                var entity = await _trainingDocumentsRepository.GetByIdAsync(id);
                entity.IsRemoved = true;
                await _trainingDocumentsRepository.UpdateAsync(entity, true);
                rResult.result = 1;
                rResult.data = ReturnMessage.DeleteMessage;
            }
            catch (Exception e)
            {
                rResult.result = 0;
                rResult.data = ReturnMessage.ErrorMessage;
            }

            return rResult;
        }
    }
}
