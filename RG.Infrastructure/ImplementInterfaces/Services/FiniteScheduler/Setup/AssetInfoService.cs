using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetIndexs.Queries.RequestResponseModel;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetInfos.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetInfos.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.Embro.Setups;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Business;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Setup;
using RG.Application.Interfaces.Services.FiniteScheduler.Business;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using RG.Application.ViewModel.FiniteScheduler.Setup.AssetInfo;
using RG.DBEntities.FiniteScheduler.Business;
using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace RG.Infrastructure.ImplementInterfaces.Services.FiniteScheduler.Setup
{
    public class AssetInfoService : IAssetInfoService
    {
        private readonly IAssetInfoRepository _assetInfoRepository;

        private readonly IMapper _mapper;
        private readonly IAssetDepriciationHistoryRepository _assetDepriciationHistoryRepository;
        private readonly IAssetAttributeAssociationValueRepository _assetAttributeAssociationValueRepository;
        private readonly ICompanyInfoRepository _companyInfoRepository;
        private readonly IAssetSubTypeRepository _assetSubTypeRepository;
        private readonly IAssetLocationRepository _assetLocationRepository;
        private readonly ITempAssetRepository _tempAssetRepository;

        public AssetInfoService(IAssetInfoRepository assetInfoRepository, IMapper mapper,
            IAssetDepriciationHistoryRepository assetDepriciationHistoryRepository
            , IAssetAttributeAssociationValueRepository assetAttributeAssociationValueRepository
            , ICompanyInfoRepository companyInfoRepository
            , IAssetSubTypeRepository assetSubTypeRepository
            , IAssetLocationRepository assetLocationRepository
            , ITempAssetRepository tempAssetRepository)
        {
            _assetInfoRepository = assetInfoRepository;
            _mapper = mapper;
            _assetDepriciationHistoryRepository = assetDepriciationHistoryRepository;
            _assetAttributeAssociationValueRepository = assetAttributeAssociationValueRepository;
            _companyInfoRepository = companyInfoRepository;
            _assetSubTypeRepository = assetSubTypeRepository;
            _assetLocationRepository = assetLocationRepository;
            _tempAssetRepository = tempAssetRepository;
        }

        //public async Task<RResult> AssetInfoRemove(int id, bool saveChange)
        //{
        //    RResult result = new();
        //    if (id > 0)
        //    {
        //        var entity = await _assetInfoRepository.GetByIdAsync(id);
        //        entity.IsRemoved = true;
        //        await _assetInfoRepository.UpdateAsync(entity, entity.AssetID, saveChange);
        //        result.result = 1;
        //        result.message = "Asset Info  Successfully Remove.";
        //    }
        //    else
        //    {
        //        result.result = 0;
        //        result.message = "Remove failed";
        //    }
        //    return result;
        //}

        public async Task<RResult> AssetinfoUpdate(AssetInfoDTM model, bool saveChange)
        {
            RResult result = new();
            var dbModel = await _assetInfoRepository.GetByIdAsync(model.AssetID);
            dbModel.AssetAssignedType = model.AssetAssignedType;
            dbModel.AssetSubTypeID = model.AssetSubTypeID;
            dbModel.AssetName = model.AssetName;
            dbModel.PurchaseDate = model.PurchaseDate;
            dbModel.PurchaseValue = model.PurchaseValue;
            dbModel.CompanyID = model.CompanyID;
            dbModel.Description = model.Description;
            dbModel.BrandName = model.BrandName;
            dbModel.Remarks = model.Remarks;
            dbModel.IsReturnable = model.IsReturnable;

            dbModel.Description = model.Description;
            dbModel.Capacity = model.Capacity;
            dbModel.CapacityUnitID = model.CapacityUnitID;
            dbModel.FunctionalStatusID = model.FunctionalStatusID;
            dbModel.ModelNo = model.ModelNo;
            dbModel.LCNo = model.LCNo;

            if (model.AssetID > 0)
            {
                await _assetInfoRepository.UpdateAsync(dbModel, saveChange);

                foreach (var item in model.AssetAttributeAssociationValue)
                {
                    var data = await _assetAttributeAssociationValueRepository.GetByIdAsync(item.AssociationValueID);
                    data.ValueDescription = item.ValueDescription;
                    data.ValueID = item.ValueID;
                    await _assetAttributeAssociationValueRepository.UpdateAsync(data);
                }
                result.result = 1;
                result.message = ReturnMessage.UpdateMessage;
            }
            else
            {
                result.result = 0;
                result.message = ReturnMessage.ErrorMessage;
            }

            return result;


        }





        //public async Task<RResult> Create(AssetInfoDTM model, CancellationToken cancellationToken)
        //{
        //    var entity = _mapper.Map<AssetInfoDTM, AssetInfo>(model);

        //    return await _assetInfoRepository.Create(entity, cancellationToken);
        //}

        public async Task<RResult> Create(AssetInfoDTM model, bool saveChange = true)
        {
            try
            {
                RResult result = new();
                model.ValueAfterDeprication = model.PurchaseValue;
                var entity = _mapper.Map<AssetInfoDTM, AssetInfo>(model);
                entity.Code = await GenerateAutoAssetCode(entity.CompanyID, entity.AssetSubTypeID);
                var obj = await _assetInfoRepository.InsertAsync(entity, saveChange);
                if (obj != null)
                {
                    if (model.AssetAttributeAssociationValue!=null && model.AssetAttributeAssociationValue.Count>0)
                    {

                    var associationValue = _mapper.Map<List<AssetAttributeAssociationValueDTM>, List<AssetAttributeAssociationValue>>(model.AssetAttributeAssociationValue);
                    associationValue.ForEach(x => x.AssetID = entity.AssetID);
                    await _assetAttributeAssociationValueRepository.InsertAsync(associationValue, true);
                    }
                    result.result = 1;
                    result.message = "Data Insert Successfulluy";
                }
                else
                {
                    result.result = 0;
                    result.message = ReturnMessage.ErrorMessage;
                }

                return result;
            }
            catch (Exception e)
            {
                throw;
            }

        }
        public async Task<RResult> TempAssetCreate()
        {
            RResult result = new();
            var dataList = await _tempAssetRepository.FindAllAsync(x=>x.IsUploaded==false);
            foreach (var item in dataList)
            {
                List<AssetLocationDTM> location = new List<AssetLocationDTM> {
                new AssetLocationDTM{BuildingID=item.BuildingID,FloorID=item.FloorID,DepartmentID=item.DepartmentID, DateFrom=DateTime.Now,IsReturned=false}
                };
                AssetInfoDTM model = new()
                {
                    AssetName = item.AssetName,
                    AssetSubTypeID = item.SubTypeID,
                    AssetAssignedType = 2,
                    BrandName = "N/A",
                    PurchaseDate = DateTime.Now,
                    PurchaseValue = 100,
                    ValueAfterDeprication = 100,
                    CompanyID = item.CompanyID,
                    IsReturnable = false,
                    Description = item.Description??"N",
                    AssetLocation=location
                };
                result = await Create(model, true);
                if (result.result==1)
                {
                    item.IsUploaded = true;
                    await _tempAssetRepository.UpdateAsync(item);
                }
            }
            return result;
        }


        private async Task<string> GenerateAutoAssetCode(decimal companyID, int assetSubTypeID)
        {
            var companyCode = (await _companyInfoRepository.GetByIdAsync(companyID)).Code;
            var assetSubTypeCode = (await _assetSubTypeRepository.GetByIdAsync(assetSubTypeID)).Code;
            var year = DateTime.Now.Year.ToString().Substring(2, 2);
            var prefix = $"{companyCode}/{assetSubTypeCode}/{year}";
            return await _assetInfoRepository.GenerateAutoAssetCode(prefix, (int)companyID, assetSubTypeID);

        }

        public async Task<List<SelectListItem>> DDLAssetNameViaAssetSubType(int AssetSubTypeID, CancellationToken cancellationToken = default)
        {
            return await _assetInfoRepository.DDLAssetNameViaAssetSubType(AssetSubTypeID, cancellationToken);
        }

        public async Task<RResult> DeleteAssetWithChild(int iD)
        {
            return await _assetInfoRepository.DeleteAssetWithChild(iD);
        }


        //public IQueryable<AssetInfoRM> GetAllAssetInfo()
        //{
        //    return _assetInfoRepository.GetAllAssetInfo();
        //}

        public async Task<List<AssetInfoRM>> GetAllAssetWithSearchTypeAndSubType(int AssetTypeID, int AssetSubTypeID, CancellationToken cancellationToken)
        {
            return await _assetInfoRepository.GetAllAssetWithSearchTypeAndSubType(AssetTypeID, AssetSubTypeID, cancellationToken);
        }


        public async Task<AssetInfoVM> GetDataToUpdateAsset(int id, CancellationToken cancellationToken)
        {
            var data = await _assetInfoRepository.GetDataToUpdateAsset(id, cancellationToken);
            data.AssetWiseAttributeValues = await _assetAttributeAssociationValueRepository.GetAssetWiseAttributeValues(id, cancellationToken);
            return data;
        }

        //Akbar
        public async Task<RResult> GenerateAssetDepreciation(DateTime? GenerateDate = null, CancellationToken cancellationToken = default)
        {

            RResult result = new RResult();
            result.result = 0;
            DateTime dateFrom;
            DateTime dateTo;

            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
                Timeout = TransactionManager.DefaultTimeout
            };

            using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, options, TransactionScopeAsyncFlowOption.Enabled))
            {

                if (GenerateDate.HasValue == false && GenerateDate.Value == null)
                {
                    dateFrom = new DateTime(DateTime.Now.Year - 1, 7, 1);
                    dateTo = new DateTime(DateTime.Now.Year, 6, 30);
                }
                else
                {
                    var generateYear = GenerateDate.Value.Month > 7 ? GenerateDate.Value.Year : GenerateDate.Value.Year - 1;
                    dateFrom = new DateTime(generateYear, 7, 1);
                    dateTo = new DateTime(generateYear + 1, 6, 30);
                }

                int fiscalYear = dateTo.Month > 7 ? dateTo.Year : dateTo.Year - 1;

                var hasExistingDepriciationList = await _assetDepriciationHistoryRepository
                                            .FindAllAsync(b => b.FiscalYear == fiscalYear && b.IsActive == true && b.IsRemoved == false);
                foreach (var depAss in hasExistingDepriciationList)
                {
                    var hisAss = await _assetDepriciationHistoryRepository.GetByIdAsync(depAss.ID, cancellationToken);
                    hisAss.IsRemoved = true;
                    hisAss.IsActive = false;
                    await _assetDepriciationHistoryRepository.UpdateAsync(hisAss);

                    var assetInUp = await _assetInfoRepository.GetByIdAsync(hisAss.AssetID, cancellationToken);
                    assetInUp.ValueAfterDeprication += hisAss.DepricationValue;
                    await _assetInfoRepository.UpdateAsync(assetInUp);

                }

                var assetInfo = await _assetInfoRepository
                    .FindAllAsync(b => b.IsRemoved == false && b.IsActive == true
                                  && b.ValueAfterDeprication > 1 && b.DepriciationPercent > 0
                                 //&& b.DapricationDateFrom<= dateFrom
                                 );
                foreach (var ast in assetInfo)
                {
                    var assetDepricationHistory = new AssetDepriciationHistory();

                    var totalDepricationValue = (ast.ValueAfterDeprication * ast.DepriciationPercent) / 100;


                    var _depDateFrom = ast.DapricationDateFrom > dateFrom ? ast.DapricationDateFrom : dateFrom;
                    var _depDateTo = ast.DapricationDateTo > dateTo ? dateTo : ast.DapricationDateTo;
                    var totalDayes = _depDateTo - _depDateFrom;
                    double depdayes = totalDayes.Value.TotalDays;
                    depdayes = depdayes > -1 ? depdayes + 1 : -1;

                    if (depdayes > 0)
                    {
                        var calculatedepricationValue = depdayes > 364 ? totalDepricationValue : ((totalDepricationValue / 365) * (decimal)depdayes);

                        var assetDepricationValue = ast.ValueAfterDeprication > 0 ? ast.ValueAfterDeprication - calculatedepricationValue : 1;

                        assetDepricationHistory.AssetID = ast.AssetID;
                        assetDepricationHistory.DateFrom = _depDateFrom.Value;
                        assetDepricationHistory.DateTo = _depDateTo.Value;
                        assetDepricationHistory.DepricationType = "-1";
                        assetDepricationHistory.FiscalYear = fiscalYear;
                        assetDepricationHistory.Rate = assetDepricationValue.Value == 1 ? 0 : ast.DepriciationPercent ?? 0;

                        ast.ValueAfterDeprication = assetDepricationValue > 1 ? assetDepricationValue.Value : 1;

                        //Set Default Value 1
                        assetDepricationHistory.DepricationValue = ast.ValueAfterDeprication == 1 ? 1 : calculatedepricationValue ?? 0;

                        await _assetDepriciationHistoryRepository.InsertAsync(assetDepricationHistory);
                        await _assetInfoRepository.UpdateAsync(ast, ast.AssetID);
                    }
                }
                transactionScope.Complete();
                result.result = 1;
            }

            return result;



        }

        public async Task<List<GetAllAssetAndRelationalInfoRM>> GetAllAssetAndRelationalInfo(GetAllAssetAndRelationalInfoQM queryModel, CancellationToken cancellationToken)
        {
            return await _assetInfoRepository.GetAllAssetAndRelationalInfo(queryModel, cancellationToken);
        }

        public async Task<List<GetAllAssetAndRelationalInfoRM>> GetAllAssetAndDepricationInfo(int CompanyID, int FiscalYear, CancellationToken cancellationToken)
        {
            return await _assetInfoRepository.GetAllAssetAndDepricationInfo(CompanyID, FiscalYear, cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLAssetNameWiseAssetCode(string assetName, CancellationToken cancellationToken)
        {
            return await _assetInfoRepository.DDLAssetNameWiseAssetCode(assetName, cancellationToken);
        }

        public async Task<List<ReportDataVM>> GetAssetReportData(int assetTypeName, int assetSubTypeID, int assetAssignedType, string assetName, DateTime? dateFrom, DateTime? dateTo
            , string code, int companyID, int divisionID, int departmentID, int buildingID, int floorID, string dynamicFilters, bool extendedFeature = false, CancellationToken cancellationToken = default)
        {
            var data = await _assetInfoRepository.GetAssetReportData(assetTypeName, assetSubTypeID, assetAssignedType, assetName, dateFrom, dateTo
                , code, companyID, divisionID, departmentID, buildingID, floorID, dynamicFilters, extendedFeature, cancellationToken);

            return data;
        }

        public async Task<List<string>> AssetNameAutocomplete(int assetSubTypeID, string predict, CancellationToken cancellationToken)
        {
            return await _assetInfoRepository.AssetNameAutocomplete(assetSubTypeID, predict, cancellationToken);
        }


    }
}
