using RG.Application.Contracts.AlgoHR.Business.TrainingDocumentsComment.Commands.DataTransferModel;
using RG.DBEntities.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.AlgoHR.Business
{
    public  interface ITrainingDocumentsCommentsRepository : IGenericRepository<TrainingDocumentsComments>
    {
        Task<List<TrainingDocumentsCommentDTM>> GetListTrainingDocumentsCommentsList(int ID, CancellationToken cancellationToken);
    }
}
