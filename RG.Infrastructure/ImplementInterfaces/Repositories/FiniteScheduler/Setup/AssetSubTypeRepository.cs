
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetSubTypes.Query.RequestResponseModel;
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
    public class AssetSubTypeRepository : GenericRepository<AssetSubType>, IAssetSubTypeRepository
    {
        private FiniteSchedulerDBContext dbCon;
        public AssetSubTypeRepository(FiniteSchedulerDBContext context) : base(context)
        {
            dbCon = context;
        }

        public async Task<RResult> Create(AssetSubType entity, CancellationToken cancellationToken)
        {
            RResult rResult = new();
            try
            {
                entity.Code = entity.Code.ToUpper();
                var typeWiseSubTypes = await dbCon.AssetSubType.Where(x => x.AssetTypeID == entity.AssetTypeID).ToListAsync(cancellationToken);
                var checkDuplicateData = (typeWiseSubTypes.Where(x => x.IsActive == true && x.IsRemoved == false
                                                              && (x.SubTypeName == entity.SubTypeName || x.Code == entity.Code)).ToList()).Count;
                if (checkDuplicateData == 0)
                {
                    entity.Serial = typeWiseSubTypes.Count + 1;
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

        public async Task<List<SelectListItem>> DDLAssetTypeWiseAssetSubType(int AssetTypeID, string predict, CancellationToken cancellationToken)
        {
            var query = dbCon.AssetSubType.Where(x => x.IsActive == true && x.IsRemoved == false && x.AssetTypeID == AssetTypeID)
                        .Select(x => new SelectListItem()
                        {
                            Text=x.SubTypeName.ToString(),
                            Value=x.AssetSubTypeID.ToString()
                        });
                        

            if (predict != null)
            {
                query = query.Where(x => x.Text.Contains(predict));
            }
            return await query.Distinct().ToListAsync(cancellationToken);
        }

        public IQueryable<AssetSubTypeRM> GetAllAssetSubType()
        {
            var query = (from ast in dbCon.AssetSubType
                        join at in dbCon.AssetType on ast.AssetTypeID equals at.AssetTypeID
                        where(ast.IsActive==true && ast.IsRemoved==false)
                        select new AssetSubTypeRM
                        {
                            AssetSubTypeID=ast.AssetSubTypeID,
                            AssetType=at.TypeName,
                            AssetTypeID=at.AssetTypeID,
                            Code=ast.Code,
                            Description=ast.Description,
                            Serial=ast.Serial,
                            SubTypeName=ast.SubTypeName
                        }).Distinct();
            return query;
        }
    }
}
