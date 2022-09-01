using Microsoft.AspNetCore.Http;
using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.TrainingDocumentsComment.Commands.DataTransferModel;
using RG.Application.Contracts.AlgoHR.Business.TrainingInfos.Commands.DataTransferModel;
using RG.Application.Contracts.AlgoHR.Business.TrainingInfos.Queries.RequestResponseModel;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AlgoHR.Business
{
    public interface ITrainingInfoService
    {
        Task<RResult> Create(TrainingInfoDTM trainingInfo, IFormFileCollection files, CancellationToken cancellationToken);
        Task<List<TrainingInfoRM>> GetAllTrainingInfo(int TrainingTypeID,CancellationToken cancellationToken);
        Task<List<TrainingDocumentsRM>> GetTrainingDocumentsByTraining(int trainingID, CancellationToken cancellationToken);
        Task<TrainingInfoRM> GetTrainingInfo(int trainingID, CancellationToken cancellationToken);
        Task<RResult> DeleteTraining(int iD);
        Task<RResult> TrainingDocumentsCommentCreate(TrainingDocumentsCommentDTM model, bool saveChange);
    }
}
