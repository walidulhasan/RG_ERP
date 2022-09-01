using Microsoft.EntityFrameworkCore;
using RG.Application.Contracts.AlgoHR.Business.TrainingDocumentsComment.Commands.DataTransferModel;
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
    public class TrainingDocumentsCommentsRepository : GenericRepository<TrainingDocumentsComments>, ITrainingDocumentsCommentsRepository
    {
        private readonly AlgoHRDBContext _dbcon;

        public TrainingDocumentsCommentsRepository(AlgoHRDBContext con) :base(con)
        {
            _dbcon = con;
        }

        public async Task<List<TrainingDocumentsCommentDTM>> GetListTrainingDocumentsCommentsList(int ID, CancellationToken cancellationToken)
        {
            try
            {
                var data = _dbcon.TrainingDocumentsComments.Where(x => x.DocumentsID == ID && x.IsActive == true && x.IsRemoved == false)
                            .Select(x => new TrainingDocumentsCommentDTM()
                            {
                                Comments = x.Comments,
                                DocumentsID = x.DocumentsID
                            });
                return await data.ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
