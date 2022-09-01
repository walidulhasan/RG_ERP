
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetSubTypes.Query.RequestResponseModel;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetTypes.Query.RequestResponseModel;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Setup;
using RG.DBEntities.FiniteScheduler.Setup;
using RG.Infrastructure.Persistence.FiniteSchedulerDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.FiniteScheduler.Setup
{
    public class AssetTypeRepository : GenericRepository<AssetType>, IAssetTypeRepository
    {
        private FiniteSchedulerDBContext dbCon;
        public AssetTypeRepository(FiniteSchedulerDBContext context)
            : base(context)
        {
            dbCon = context;
        }

        public async Task<RResult> Create(AssetType entity, CancellationToken cancellationToken)
        {
            RResult rResult = new();
            try
            {
                entity.Code = entity.Code.ToUpper();
                var assets = await dbCon.AssetType.ToListAsync(cancellationToken);
                var checkDuplicate = (assets.Where(x => x.IsActive == true && x.IsRemoved == false
                                                   && (x.TypeName == entity.TypeName || x.Code == entity.Code)).ToList()).Count;
                if (checkDuplicate == 0)
                {
                   
                    entity.Serial = assets.Count + 1;
                    await InsertAsync(entity, true);
                    rResult.result = 1;
                    rResult.message = ReturnMessage.InsertMessage;
                }
                else
                {
                    rResult.result = 0;
                    rResult.message = ReturnMessage.DuplicateMessage;

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return rResult;
        }

        public async Task<List<SelectListItem>> DDLAssetTypeName(CancellationToken cancellationToken)
        {
            var query = dbCon.AssetType.Where(x => x.IsActive == true && x.IsRemoved == false)
                                      .Select(x => new SelectListItem()
                                      {
                                          Text=x.TypeName.ToString(),
                                          Value=x.AssetTypeID.ToString()
                                      });
            return await query.ToListAsync(cancellationToken);
        }

        public IQueryable<AssetTypeRM> GetAllAssetType()
        {
            var query = dbCon.AssetType.Where(x => x.IsActive == true && x.IsRemoved == false)
                                     .Select(x => new AssetTypeRM()
                                     {
                                         AssetTypeID=x.AssetTypeID,
                                         Code=x.Code,
                                         Description=x.Description,
                                         Serial=x.Serial,
                                         TypeName=x.TypeName

                                     });
            return query;
        }
    }
}
