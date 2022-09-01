using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.TrainingCalendars.Queries.RequestResponseModel;
using RG.Application.Contracts.AlgoHR.Business.TrainingInfos.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.DBEntities.AlgoHR.Business;
using RG.Infrastructure.Persistence.AlgoHRDB;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Business
{
    public class TrainingInfoRepository : GenericRepository<TrainingInfo>, ITrainingInfoRepository
    {
        private readonly AlgoHRDBContext _dbCon;

        public TrainingInfoRepository(AlgoHRDBContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }

        public async Task<RResult> DeleteTraining(int iD)
        {
            RResult rResult = new();
            try
            {
                var entity = await _dbCon.TrainingInfo
                .Include(x => x.TrainingDocuments.Where(y => y.IsActive == true && y.IsRemoved == false))
                .Where(x => x.ID == iD && x.IsActive == true && x.IsRemoved == false).FirstAsync();
                entity.IsRemoved = true;
                entity.TrainingDocuments.ForEach(x => { x.IsRemoved = true; });
                await _dbCon.SaveChangesAsync();
                rResult.result = 1;
                rResult.message = ReturnMessage.DeleteMessage;
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
            //var data = await _dbCon.TrainingInfo
            //    .Include(x => x.TrainingDocuments.Where(y => y.IsActive == true && y.IsRemoved == false))
            //    .Where(x => x.IsActive == true && x.IsRemoved == false).ToListAsync(cancellationToken);

            //var returnData = data.Select(x => new TrainingInfoRM
            //{
            //    ID = x.ID,
            //    TrainingName = x.TrainingName,
            //    TrainingDescription = x.TrainingDescription,
            //    NoOfDocuments = x.TrainingDocuments.Count
            //}).ToList();
            //var query=
            var dataQuery = (from ti in _dbCon.TrainingInfo
                             join tt in _dbCon.TrainingType on ti.TrainingTypeID equals tt.ID
                             join td in _dbCon.TrainingDocuments on ti.ID equals td.TriningID
                             where ((TrainingTypeID == 0 || ti.TrainingTypeID == TrainingTypeID) && td.IsActive==true && td.IsRemoved==false && ti.IsRemoved==false && ti.IsActive==true)
                             group new { ti, tt, td } by new { ti.ID, ti.TrainingTypeID, ti.TrainingName, ti.TrainingDescription, tt.TrainingTypeName } into grp

                             select new TrainingInfoRM
                             {
                                 ID = grp.Key.ID,
                                 TrainingTypeID = grp.Key.TrainingTypeID,
                                 TrainingTypeName = grp.Key.TrainingTypeName,
                                 TrainingName = grp.Key.TrainingName,
                                 TrainingDescription = grp.Key.TrainingDescription,
                                 NoOfDocuments = grp.Count(x => x.td.ID > 0)
                             });

            //var str = dataQuery.ToQueryString();
            var data= await dataQuery.ToListAsync(cancellationToken);

            return data;
        }

      

        public async Task<List<TrainingDocumentsRM>> GetTrainingDocumentsByTraining(int trainingID, CancellationToken cancellationToken)
        {
            var data = await (from td in _dbCon.TrainingDocuments
                              join dt in _dbCon.UploadedDocumentType on td.DocumentTypeID equals dt.DocumentTypeID
                              where td.TriningID==trainingID && td.IsActive == true && td.IsRemoved == false
                              select new TrainingDocumentsRM
                              {
                                  ID = td.ID,
                                  TriningID = td.TriningID,
                                  DocumentTypeID = td.DocumentTypeID,
                                  DocumentType = dt.DocumentType,
                                  FileSerial = td.FileSerial,
                                  FileTitle = td.FileTitle,
                                  FileExtension = td.FileExtension,
                                  FileUrl = td.FileUrl,
                                  IsExternalFile = td.IsExternalFile
                              }).ToListAsync(cancellationToken);
            return data;

        }
    }
}
