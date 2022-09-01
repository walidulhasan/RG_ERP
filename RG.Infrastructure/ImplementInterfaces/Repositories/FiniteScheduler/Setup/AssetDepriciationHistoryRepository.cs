using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetDepriciationHistories.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetDepriciationHistories.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Setup;
using RG.DBEntities.FiniteScheduler.Setup;
using RG.Infrastructure.Persistence.FiniteSchedulerDB;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.FiniteScheduler.Setup
{
    public class AssetDepriciationHistoryRepository : GenericRepository<AssetDepriciationHistory>, IAssetDepriciationHistoryRepository
    {
        private FiniteSchedulerDBContext dbCon;
        public AssetDepriciationHistoryRepository(FiniteSchedulerDBContext context)
            : base(context)
        {
            dbCon = context;
        }

        public async Task<RResult> AssetDepriciationHistoryCreate(AssetDepriciationHistory model, bool saveChange)
        {
           
            try
            {
                RResult rResult = new();
                var query =await dbCon.AssetDepriciationHistory.Where(x => x.DateFrom == model.DateFrom).CountAsync();
                if (query == 0)
                {
                    if (model != null)
                    {
                        model.DepricationType = "-1";
                        await InsertAsync(model, saveChange);
                        rResult.result = 1;
                        rResult.message = ReturnMessage.InsertMessage;
                    }
                    else
                    {
                        rResult.result = 0;
                        rResult.message = ReturnMessage.ErrorMessage;
                    }
                    
                }
                else
                {
                    rResult.result = 0;
                    rResult.message = "Date From Can't be Duplicated";
                }
                return rResult;
            }
            catch (Exception e)
            {

                throw;
            }
            
        }

        public async Task<List<AssetDepriciationHistoryRM>> GetListAssetDepriciationHistory(int AssetID, CancellationToken cancellationToken)
        {
            try
            {
                var data = (from ai in dbCon.AssetInfo
                            join adh in dbCon.AssetDepriciationHistory on ai.AssetID equals adh.AssetID
                            where (adh.AssetID == AssetID && adh.IsActive == true && adh.IsRemoved == false)
                            select new AssetDepriciationHistoryRM
                            {
                                ID=adh.ID,
                                AssetName = ai.AssetName,
                                DateFrom = adh.DateFrom,
                                DateTo = adh.DateTo.Value.ToString("dd-MMM-yyyy"),
                                Rate = adh.Rate,
                                ValueAfterDeprication = ai.ValueAfterDeprication,
                                DepricationValue=adh.DepricationValue
                            }).OrderBy(x => x.DateFrom);

                var query = data.ToQueryString();
                return await data.ToListAsync(cancellationToken);
            }
            catch (System.Exception e)
            {

                throw;
            }

           

        }
    }
}
