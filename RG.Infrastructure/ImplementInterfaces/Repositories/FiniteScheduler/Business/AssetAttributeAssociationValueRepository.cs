using RG.Application.Interfaces.Repositories.FiniteScheduler.Business;
using RG.Application.ViewModel.FiniteScheduler.Setup.AssetInfo;
using RG.DBEntities.FiniteScheduler.Business;
using RG.Infrastructure.Persistence.FiniteSchedulerDB;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.FiniteScheduler.Business
{
    public class AssetAttributeAssociationValueRepository : GenericRepository<AssetAttributeAssociationValue>, IAssetAttributeAssociationValueRepository
    {
        private readonly FiniteSchedulerDBContext _dbCon;
        public AssetAttributeAssociationValueRepository(FiniteSchedulerDBContext context)
        : base(context)
        {
            _dbCon = context;
        }

        public async Task<List<string>> AttributeValueAutoComplete(int assetSubTypeID, int attributeID, string predict, CancellationToken cancellationToken)
        {
            var data = await (from aaa in _dbCon.AssetAttributeAssociation
                              join aaav in _dbCon.AssetAttributeAssociationValue on new { aaa.IsActive, aaa.IsRemoved, aaa.AssociationID } equals new { aaav.IsActive, aaav.IsRemoved, aaav.AssociationID }
                              where aaa.AssetSubTypeID == assetSubTypeID && aaa.AttributeID == attributeID && aaav.ValueDescription.Contains(predict)
                              select aaav.ValueDescription.Trim()).Distinct().ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<AssetWiseAttributeValuesVM>> GetAssetWiseAttributeValues(int id, CancellationToken cancellationToken)
        {
            var dataQuery = from a in _dbCon.AssetInfo
                            join aaav in _dbCon.AssetAttributeAssociationValue on new { a.AssetID, a.IsActive, a.IsRemoved } equals new { aaav.AssetID, aaav.IsActive, aaav.IsRemoved }
                            join aaa in _dbCon.AssetAttributeAssociation on new { aaav.AssociationID, aaav.IsActive, aaav.IsRemoved } equals new { aaa.AssociationID, aaa.IsActive, aaa.IsRemoved }
                            join ast in _dbCon.AssetSubType on aaa.AssetSubTypeID equals ast.AssetSubTypeID
                            join aa in _dbCon.AssetAttribute on new { aaa.AttributeID, aaa.IsActive, aaa.IsRemoved } equals new { aa.AttributeID, aa.IsActive, aa.IsRemoved }
                            where a.IsActive == true && a.IsRemoved == false && a.AssetID == id
                            select (new AssetWiseAttributeValuesVM
                            {
                                AssociationValueID = aaav.AssociationValueID,
                                AssetID = aaav.AssetID,
                                AssetSubTypeID = ast.AssetSubTypeID,
                                AssetSubTypeName = ast.SubTypeName,
                                AssociationID = aaa.AssociationID,
                                AttributeID = aaa.AttributeID,
                                AttributeName = aa.AttributeName,
                                IsFilterable = aaa.IsFilterable,
                                IsVisible = aaa.IsVisible,
                                PrioritySerial = aaa.PrioritySerial,
                                ValueDescription = aaav.ValueDescription,
                                ValueID = aaav.ValueID
                            });
            var data = await dataQuery.ToListAsync(cancellationToken);
            return data;
        }
    }
}
