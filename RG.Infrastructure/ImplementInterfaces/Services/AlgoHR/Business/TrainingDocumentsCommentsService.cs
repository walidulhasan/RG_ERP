using RG.Application.Contracts.AlgoHR.Business.TrainingDocumentsComment.Commands.DataTransferModel;
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
    public class TrainingDocumentsCommentsService : ITrainingDocumentsCommentsService
    {
        private readonly ITrainingDocumentsCommentsRepository _trainingDocumentsCommentsRepository;

        public TrainingDocumentsCommentsService(ITrainingDocumentsCommentsRepository trainingDocumentsCommentsRepository)
        {
            _trainingDocumentsCommentsRepository = trainingDocumentsCommentsRepository;
        }
        public async Task<List<TrainingDocumentsCommentDTM>> GetListTrainingDocumentsCommentsList(int ID, CancellationToken cancellationToken)
        {
            return await _trainingDocumentsCommentsRepository.GetListTrainingDocumentsCommentsList(ID,cancellationToken);
        }
    }
}
