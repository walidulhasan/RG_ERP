using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.TrainingCalendars.Queries.RequestResponseModel;
using RG.Application.Contracts.AlgoHR.Business.TrainingInfos.Queries.RequestResponseModel;
using RG.DBEntities.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.AlgoHR.Business
{
    public interface ITrainingInfoRepository : IGenericRepository<TrainingInfo>
    {
        Task<List<TrainingInfoRM>> GetAllTrainingInfo(int TrainingTypeID,CancellationToken cancellationToken);
        Task<List<TrainingDocumentsRM>> GetTrainingDocumentsByTraining(int trainingID, CancellationToken cancellationToken);
        Task<RResult> DeleteTraining(int iD);
        
    }
}
