using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.ApplicationDocumentss.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.DBEntities.AlgoHR.Business;
using RG.Infrastructure.Persistence.AlgoHRDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Business
{
    public class ApplicationDocumentsRepository:GenericRepository<ApplicationDocuments>, IApplicationDocumentsRepository
    {
        private AlgoHRDBContext dbCon;
        public ApplicationDocumentsRepository(AlgoHRDBContext context)
            : base(context)
        {
            dbCon = context;

        }

        public async Task<List<ApplicationDocumentsRM>> GetDocumentsByApplicationID(int applicationID, CancellationToken cancellationToken = default)
        {
            var data = await (from ad in dbCon.ApplicationDocuments
                              join dt in dbCon.UploadedDocumentType on ad.DocumentTypeID equals dt.DocumentTypeID
                              where ad.ApplicationID == applicationID && ad.IsActive == true && ad.IsRemoved == false
                              select new ApplicationDocumentsRM
                              {
                                  DocumentID = ad.DocumentID,
                                  ApplicationID = ad.ApplicationID,
                                  DocumentTypeID = ad.DocumentTypeID,
                                  DocumentType = dt.DocumentType,
                                  DocumentPath = ad.DocumentPath
                              }).ToListAsync(cancellationToken);
            return data;
        }

        public async Task<RResult> SaveApplicationDocuments(List<ApplicationDocuments> docs, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            RResult rResult = new();
            foreach (var doc in docs)
            {
                await dbCon.ApplicationDocuments.AddAsync(doc);
            }
            await dbCon.SaveChangesAsync(cancellationToken);
            rResult.result = 1;
            rResult.message = ReturnMessage.InsertMessage;
            return rResult;
        }
    }
}
