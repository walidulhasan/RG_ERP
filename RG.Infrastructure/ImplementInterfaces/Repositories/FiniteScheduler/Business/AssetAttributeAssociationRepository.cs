using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Business.AssetAttributeAssociation.Queries.RequestResponseModel;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetAttributeAssociations.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetAttributeAssociations.Queries.RequestResponseModel;
using RG.Application.Contracts.FiniteScheduler.Setups.SubTypeAttributeAssociations.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Business;
using RG.DBEntities.FiniteScheduler.Business;
using RG.Infrastructure.Persistence.FiniteSchedulerDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.FiniteScheduler.Business
{
    public class AssetAttributeAssociationRepository : GenericRepository<AssetAttributeAssociation>, IAssetAttributeAssociationRepository
    {
        private readonly FiniteSchedulerDBContext _dbCon;
        public AssetAttributeAssociationRepository(FiniteSchedulerDBContext context)
        : base(context)
        {
            _dbCon = context;
        }

        public async Task<RResult> AssetAttributeAssociationCheckListRemove(List<AssetAttributeAssociationDTM> ListModel, CancellationToken cancellationToken)
        {
            var rResult = new RResult();
            var associationID = ListModel.First().AssociationID;
            var chkAssociationId = await _dbCon.AssetAttributeAssociationValue
                .Where(b => b.AssociationID == associationID && b.IsRemoved == false && b.IsActive == true).ToListAsync();

            if (chkAssociationId.Count > 0)
            {
                rResult.result = 0;
                rResult.message = "Can't Delete!At First Data delete into Asset Attribute Association Value Table";
            }
            else
            {
                var dbData = await _dbCon.AssetAttributeAssociation
                .Where(b => b.AssociationID == associationID && b.IsRemoved == false && b.IsActive == true).ToListAsync();
                dbData.ForEach(b => b.IsRemoved = true);
                await _dbCon.SaveChangesAsync(cancellationToken);
                rResult.result = 1;
                rResult.message = ReturnMessage.DeleteMessage;
            }


            return rResult;
        }

        public async Task<RResult> AssetAttributeAssociationCheckListSave(List<AssetAttributeAssociation> entity, bool saveChanges)
        {
            try
            {
                var rResult = new RResult();


                await InsertAsync(entity, saveChanges);
                rResult.result = 1;
                rResult.message = ReturnMessage.InsertMessage;

                return rResult;
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task<List<FilterableAttributesRM>> AssetSubTypeWiseFilterableAttributes(int assetSubTypeID, CancellationToken cancellationToken)
        {
            var data = await (from aaa in _dbCon.AssetAttributeAssociation
                              join aa in _dbCon.AssetAttribute on new { aaa.AttributeID, aaa.IsActive, aaa.IsRemoved } equals new { aa.AttributeID, aa.IsActive, aa.IsRemoved }
                              where aaa.AssetSubTypeID == assetSubTypeID && aaa.IsFilterable == true && aaa.IsActive == true && aaa.IsRemoved == false
                              select new FilterableAttributesRM
                              {
                                  AttributeID = aa.AttributeID,
                                  AttributeName = aa.AttributeName,
                                  PrioritySerial = aaa.PrioritySerial
                              }).OrderBy(x=>x.PrioritySerial).ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<SubTypeAttributeAssociationRM>> GetAssetSubTypeWiseAttribute(int ID, CancellationToken cancellationToken)
        {
            try
            {
                var data = from aa in _dbCon.AssetAttribute
                           join aaa in _dbCon.AssetAttributeAssociation
                           on new { AssetSubTypeID = ID, AttributeID = aa.AttributeID, IsRemoved = false, IsActive = true }
                           equals new { AssetSubTypeID = aaa.AssetSubTypeID, AttributeID = aaa.AttributeID, IsRemoved = aaa.IsRemoved, IsActive = aaa.IsActive }
                           into AssetAttribute
                           from AssetAttributeData in AssetAttribute.DefaultIfEmpty()
                           select new SubTypeAttributeAssociationRM
                           {
                               AttributeID = aa.AttributeID,
                               AttributeName = aa.AttributeName,
                               AssociationID = AssetAttributeData == null ? 0 : AssetAttributeData.AssociationID,
                               PrioritySerial = AssetAttributeData == null ? 0 : AssetAttributeData.PrioritySerial,
                               IsVisible = AssetAttributeData == null ? false : AssetAttributeData.IsVisible == false ? false : true,
                               IsFilterable = AssetAttributeData == null ? false : AssetAttributeData.IsFilterable == false ? false : true,

                           };
                var que = data.ToQueryString();
                return await data.ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task<List<AssetSubTypeWiseAttributesRM>> GetAssetSubTypeWiseAttributes(int assetSubTypeID, CancellationToken cancellationToken)
        {
            var dataQuery = from ast in _dbCon.AssetSubType
                            join aaa in _dbCon.AssetAttributeAssociation on new { ast.AssetSubTypeID, IsActive=true, IsRemoved=false } equals new { aaa.AssetSubTypeID, aaa.IsActive, aaa.IsRemoved }
                            join aa in _dbCon.AssetAttribute on new { aaa.AttributeID, IsActive=true, IsRemoved=false } equals new { aa.AttributeID, aa.IsActive, aa.IsRemoved }
                            where ast.IsActive == true && ast.IsRemoved == false && ast.AssetSubTypeID == assetSubTypeID
                            select (new AssetSubTypeWiseAttributesRM
                            {
                                AssetSubTypeID = ast.AssetSubTypeID,
                                AssetSubTypeName = ast.SubTypeName,
                                AssociationID = aaa.AssociationID,
                                AttributeID = aaa.AttributeID,
                                AttributeName = aa.AttributeName,
                                IsFilterable = aaa.IsFilterable,
                                IsVisible = aaa.IsVisible,
                                PrioritySerial = aaa.PrioritySerial
                            });
            var data = await dataQuery.OrderBy(x=>x.PrioritySerial).ToListAsync(cancellationToken);
            return data;
        }
    }
}
