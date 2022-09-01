using RG.Application.Contracts.AlgoHR.Business.TrainingDocumentsComment.Commands.DataTransferModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AlgoHR.Business
{
    public  interface ITrainingDocumentsCommentsService
    {
        Task<List<TrainingDocumentsCommentDTM>> GetListTrainingDocumentsCommentsList(int ID, CancellationToken cancellationToken);
    }
}
