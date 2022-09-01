using RG.Application.Common.Models;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Business;
using RG.DBEntities.MaterialsManagement.Business;
using RG.Infrastructure.Persistence.MaterialsManagementDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.MaterialsManagement.Business
{
    public class IC_GatePassAccountReviewRepository : GenericRepository<IC_GatePassAccountReview>, IIC_GatePassAccountReviewRepository
    {
            private readonly MaterialsManagementDBContext dbCon;

            public IC_GatePassAccountReviewRepository(MaterialsManagementDBContext _dbCon) : base(_dbCon)
            {
                dbCon = _dbCon;
            }
        public async Task<RResult> GatePassAccountReviewSave(IC_GatePassAccountReview entity, CancellationToken cancellationToken)
        {
            RResult rResult = new RResult();
            await dbCon.IC_GatePassAccountReview.AddAsync(entity);
            await dbCon.SaveChangesAsync(cancellationToken);
            rResult.result = 1;
            rResult.message = ReturnMessage.InsertMessage;
            return rResult;

        }
    }
}

