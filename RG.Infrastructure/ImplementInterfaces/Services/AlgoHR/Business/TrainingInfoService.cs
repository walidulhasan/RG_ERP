using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using RG.Application.Common.Models;
using RG.Application.Common.Utilities;
using RG.Application.Contracts.AlgoHR.Business.TrainingDocumentsComment.Commands.DataTransferModel;
using RG.Application.Contracts.AlgoHR.Business.TrainingInfos.Commands.DataTransferModel;
using RG.Application.Contracts.AlgoHR.Business.TrainingInfos.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using RG.DBEntities.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace RG.Infrastructure.ImplementInterfaces.Services.AlgoHR.Business
{
    public class TrainingInfoService : ITrainingInfoService
    {
        private readonly ITrainingInfoRepository _trainingInfoRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ITrainingDocumentsRepository _trainingDocumentsRepository;
        private readonly ITrainingDocumentsCommentsRepository _trainingDocumentsCommentsRepository;

        public TrainingInfoService(ITrainingInfoRepository trainingInfoRepository
            , IMapper mapper
            , IWebHostEnvironment hostingEnvironment
            , ITrainingDocumentsRepository trainingDocumentsRepository
            , ITrainingDocumentsCommentsRepository trainingDocumentsCommentsRepository
            )
        {
            _trainingInfoRepository = trainingInfoRepository;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
            _trainingDocumentsRepository = trainingDocumentsRepository;
            _trainingDocumentsCommentsRepository = trainingDocumentsCommentsRepository;
        }
        public async Task<RResult> Create(TrainingInfoDTM trainingInfo, IFormFileCollection files, CancellationToken cancellationToken)
        {
            RResult rResult = new();
            Random rnd = new();
            try
            {
                var entity = _mapper.Map<TrainingInfoDTM, TrainingInfo>(trainingInfo);
                foreach (var item in entity.TrainingDocuments)
                {
                    var file = files.Where(x => x.FileName == item.FileUrl).FirstOrDefault();
                    if (file != null)
                    {
                        string fName;
                        string currentMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month);
                        var extension = Path.GetExtension(file.FileName);
                        var targetFolder = Path.Combine(FileUploadLocation.TrainingDocuments, DateTime.Now.Year.ToString(), currentMonth);
                        string mainPath = Path.Combine(_hostingEnvironment.WebRootPath, targetFolder);

                        // Crate Directory
                        if (!Directory.Exists(mainPath))
                        {
                            Directory.CreateDirectory(mainPath);
                        }

                        var fileName = file.FileName.Replace(" ","").Replace(extension,"") + "_" + rnd.Next(100, 999);
                        fName = HttpUtility.UrlEncode(fileName + extension);
                        var filePath = Path.Combine(mainPath, fName);
                        file.CopyTo(new FileStream(filePath, FileMode.Create));
                        item.FileUrl = Path.Combine(targetFolder, fName);
                    }
                }
                if (entity.ID>0)
                {
                    var dbEntity = await _trainingInfoRepository.GetByIdAsync(entity.ID, cancellationToken);
                    dbEntity.TrainingTypeID = entity.TrainingTypeID;
                    dbEntity.TrainingName = entity.TrainingName;
                    dbEntity.TrainingDescription = entity.TrainingDescription;
                    entity.TrainingDocuments.ForEach(x => { x.TriningID = entity.ID; });

                    await _trainingDocumentsRepository.InsertAsync(entity.TrainingDocuments, true);
                    await _trainingInfoRepository.UpdateAsync(dbEntity, true);
                }
                else
                {
                await _trainingInfoRepository.InsertAsync(entity, true);
                }

                rResult.result = 1;
                rResult.message = ReturnMessage.InsertMessage;
            }
            catch (Exception e)
            {
                rResult.result = 0;
                rResult.message = e.Message;

            }
            return rResult;
        }

        public async Task<List<TrainingInfoRM>> GetAllTrainingInfo(int TrainingTypeID,CancellationToken cancellationToken)
        {
            return await _trainingInfoRepository.GetAllTrainingInfo(TrainingTypeID,cancellationToken);
        }
        public async Task<TrainingInfoRM> GetTrainingInfo(int id,CancellationToken cancellationToken)
        {
            var data = _mapper.Map<TrainingInfo, TrainingInfoRM>(await _trainingInfoRepository.GetByIdAsync(id));
            data.TrainingDocuments = await GetTrainingDocumentsByTraining(id, cancellationToken);
            return data;
        }

        public async Task<List<TrainingDocumentsRM>> GetTrainingDocumentsByTraining(int trainingID, CancellationToken cancellationToken)
        {
            return await _trainingInfoRepository.GetTrainingDocumentsByTraining(trainingID, cancellationToken);
        }

        public async Task<RResult> DeleteTraining(int iD)
        {
            return await _trainingInfoRepository.DeleteTraining(iD);
        }

        public async Task<RResult> TrainingDocumentsCommentCreate(TrainingDocumentsCommentDTM model, bool saveChange)
        {
            try
            {


                RResult result = new();
                var entity = _mapper.Map<TrainingDocumentsCommentDTM, TrainingDocumentsComments>(model);
                var obj = await _trainingDocumentsCommentsRepository.InsertAsync(entity, saveChange);
                if (obj != null)
                {
                    result.result = 1;
                    result.message = "Thanks For Feedback";
                }
                else
                {
                    result.result = 0;
                    result.message = ReturnMessage.ErrorMessage;
                }
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
