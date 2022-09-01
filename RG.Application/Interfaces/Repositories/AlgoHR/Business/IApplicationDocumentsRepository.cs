using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.ApplicationDocumentss.Queries.RequestResponseModel;
using RG.DBEntities.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.AlgoHR.Business
{
    public interface IApplicationDocumentsRepository:IGenericRepository<ApplicationDocuments>
    {
        Task<RResult> SaveApplicationDocuments(List<ApplicationDocuments> docs, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task<List<ApplicationDocumentsRM>> GetDocumentsByApplicationID(int applicationID, CancellationToken cancellationToken = default);
    }
}
