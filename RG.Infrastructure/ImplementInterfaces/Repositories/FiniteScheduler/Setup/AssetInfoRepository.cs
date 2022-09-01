
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetIndexs.Queries.RequestResponseModel;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetInfos.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Setup;
using RG.Application.ViewModel.FiniteScheduler.Setup.AssetInfo;
using RG.DBEntities.FiniteScheduler.Setup;
using RG.Infrastructure.Persistence.FiniteSchedulerDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.FiniteScheduler.Business
{
    public class AssetInfoRepository : GenericRepository<AssetInfo>, IAssetInfoRepository
    {
        private FiniteSchedulerDBContext dbCon;
        private readonly IMapper _mapper;

        public AssetInfoRepository(FiniteSchedulerDBContext context, IMapper mapper) : base(context)
        {
            dbCon = context;
            _mapper = mapper;
        }

        public async Task<RResult> Create(AssetInfo entity, CancellationToken cancellationToken)
        {

            RResult rResult = new();
            try
            {
                entity.Code = entity.Code.ToUpper();
                var subTypeWiseAsset = await dbCon.AssetInfo.Where(x => x.AssetSubTypeID == entity.AssetSubTypeID).ToListAsync(cancellationToken);



                await InsertAsync(entity, true);
                rResult.result = 1;
                rResult.message = ReturnMessage.InsertMessage;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return rResult;
        }

        public async Task<List<AssetInfoRM>> GetAllAssetWithSearchTypeAndSubType(int AssetTypeID, int AssetSubTypeID, CancellationToken cancellationToken)
        {
            try
            {
                var data = (from ai in dbCon.AssetInfo

                            join ast in dbCon.AssetSubType on ai.AssetSubTypeID equals ast.AssetSubTypeID
                            join at in dbCon.AssetType on ast.AssetTypeID equals at.AssetTypeID
                            join al in dbCon.AssetLocation on new { ai.AssetID, IsReturned = false, IsActive = true, IsRemoved = false } equals new { al.AssetID, al.IsReturned, al.IsActive, al.IsRemoved } into ali
                            from alia in ali.DefaultIfEmpty()
                            where (ai.IsActive == true && ai.IsRemoved == false)
                            select new AssetInfoRM
                            {
                                AssetID = ai.AssetID,
                                AssetName = ai.AssetName,
                                Code = ai.Code,
                                AssetTypeID = at.AssetTypeID,
                                TypeName = at.TypeName,
                                AssetSubTypeID = ast.AssetSubTypeID,
                                SubTypeName = ast.SubTypeName,

                                BrandName = ai.BrandName,
                                PurchaseDate = ai.PurchaseDate,
                                PurchaseValue = ai.PurchaseValue,
                                AssetAssignedType = ai.AssetAssignedType,
                                IsFreeAsset = alia == null,
                                AssetLoactionID = alia.ID
                            });
                return await data.ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public async Task<AssetInfoVM> GetDataToUpdateAsset(int id, CancellationToken cancellationToken)
        {
            var data = from ai in dbCon.AssetInfo
                       join ast in dbCon.AssetSubType on ai.AssetSubTypeID equals ast.AssetSubTypeID
                       join at in dbCon.AssetType on ast.AssetTypeID equals at.AssetTypeID
                       join _loc in dbCon.AssetLocation on new { asset = ai.AssetID, act = true } equals new { asset = _loc.AssetID, act = _loc.IsActive } into _locJ
                       from loc in _locJ.DefaultIfEmpty()
                       join _dep in dbCon.AssetDepartment on loc.DepartmentID equals _dep.DepartmentID into _depJ
                       from dep in _depJ.DefaultIfEmpty()
                       join _div in dbCon.AssetDivision on dep.DivisionID equals _div.DivisionID into _divj
                       from  div in _divj.DefaultIfEmpty()
                       where ai.IsActive == true && ai.IsRemoved == false && ai.AssetID == id
                       select new AssetInfoVM
                       {
                           AssetID = ai.AssetID,
                           AssetName = ai.AssetName,
                           AssetAssignedType = ai.AssetAssignedType,
                           AssetSubTypeID = ai.AssetSubTypeID,
                           AssetTypeName = at.AssetTypeID,
                           Code = ai.Code,
                           BrandName = ai.BrandName,
                           PurchaseDate = ai.PurchaseDate,
                           PurchaseValue = ai.PurchaseValue,
                           CompanyID = ai.CompanyID,
                           IsReturnable = ai.IsReturnable,
                           Description = ai.Description,
                           Remarks = ai.Remarks,
                           Capacity = ai.Capacity,
                           CapacityUnitID = ai.CapacityUnitID,
                           FunctionalStatusID = ai.FunctionalStatusID,
                           ModelNo = ai.ModelNo,
                           DepartmentID= loc != null?loc.DepartmentID:0,
                           OfficeDivisionID= dep!=null?dep.DivisionID:0,
                           LoaCompanyID= div!=null ? div.EmbroCompanyID:0,
                           BuildingID = loc != null ? loc.BuildingID : 0,
                           FloorID = loc != null ? loc.FloorID : 0,
                           DateFrom= loc != null? loc.DateFrom.ToString("dd-MMM-yyyy"):""
                       };
            var query = data.ToQueryString();
            return await data.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<RResult> DeleteAssetWithChild(int iD)
        {
            RResult rResult = new();
            try
            {
                var entity = await dbCon.AssetInfo
                .Include(x => x.AssetLocation.Where(y => y.IsActive == true && y.IsRemoved == false))
                //.Include(x => x.AssetDepriciationHistory.Where(y => y.IsActive == true && y.IsRemoved == false))
                .Where(x => x.AssetID == iD && x.IsActive == true && x.IsRemoved == false).FirstAsync();
                entity.IsRemoved = true;
                entity.AssetLocation.ForEach(x => { x.IsRemoved = true; });
                //entity.AssetDepriciationHistory.ForEach(x => { x.IsRemoved = true; });
                await dbCon.SaveChangesAsync();
                rResult.result = 1;
                rResult.message = ReturnMessage.DeleteMessage;
            }
            catch (Exception e)
            {
                rResult.result = 0;
                rResult.message = e.Message;
            }
            return rResult;
        }

        public async Task<List<SelectListItem>> DDLAssetNameViaAssetSubType(int AssetSubTypeID, CancellationToken cancellationToken = default)
        {
            var data = dbCon.AssetInfo.Where(x => x.IsActive == true && x.IsRemoved == false & x.AssetSubTypeID == AssetSubTypeID)
                                    .Select(x => new SelectListItem()
                                    {
                                        Text = x.AssetName,
                                        Value = x.AssetName
                                    }).Distinct();

            return await data.ToListAsync(cancellationToken);
        }

        public async Task<List<GetAllAssetAndRelationalInfoRM>> GetAllAssetAndRelationalInfo(GetAllAssetAndRelationalInfoQM qm, CancellationToken cancellationToken)
        {
            var data = from ai in dbCon.AssetInfo
                       join aat in dbCon.AssetAssignedType on ai.AssetAssignedType equals aat.AssignedTypeNameID
                       join ast in dbCon.AssetSubType on ai.AssetSubTypeID equals ast.AssetSubTypeID
                       join at in dbCon.AssetType on ast.AssetTypeID equals at.AssetTypeID
                       join al in dbCon.AssetLocation on new { ai.AssetID, IsReturned = false, IsActive = true, IsRemoved = false } equals new { al.AssetID, al.IsReturned, al.IsActive, al.IsRemoved } into ail
                       from ailt in ail.DefaultIfEmpty()
                       where ai.IsActive == true && ai.IsRemoved == false
                       && (qm.AssetAssignedType == 0 || qm.AssetAssignedType == ai.AssetAssignedType)
                       && (qm.AssetTypeName == 0 || qm.AssetTypeName == at.AssetTypeID)
                       && (qm.AssetSubTypeID == 0 || qm.AssetSubTypeID == ai.AssetSubTypeID)
                       && (qm.AssetID == 0 || qm.AssetID == ai.AssetID)
                       && (qm.DateFrom == null || ai.PurchaseDate >= qm.DateFrom)
                       && (qm.DateTo == null || ai.PurchaseDate <= qm.DateTo)
                       && (qm.Code == "" || qm.Code == null || qm.Code == ai.Code)
                       && (qm.CompanyID == 0 || qm.CompanyID == ai.CompanyID)
                       && (qm.DepartmentID == 0 || qm.DepartmentID == ailt.DepartmentID)
                       && (qm.BuildingID == 0 || qm.BuildingID == ailt.BuildingID)
                       && (qm.FloorID == 0 || qm.FloorID == ailt.FloorID)
                       select new GetAllAssetAndRelationalInfoRM
                       {
                           AssetID = ai.AssetID,
                           AssetName = ai.AssetName,
                           AssetTypeName = at.TypeName,
                           AssetSubTypeName = ast.SubTypeName,
                           AssetAssignedType = aat.AssignedTypeName,
                           Code = ai.Code,
                           PurchaseDate = ai.PurchaseDate,
                           PurchaseValue = ai.PurchaseValue,
                           ValueAfterDeprication = ai.ValueAfterDeprication,
                           DepriciationPercent = ai.DepriciationPercent,
                           DapricationDateFrom = ai.DapricationDateFrom.Value.ToString("dd-MMM-yyyy"),
                           DapricationDateTo = ai.DapricationDateTo.Value.ToString("dd-MMM-yyyy")
                       };
            return await data.ToListAsync(cancellationToken);

        }

        public async Task<List<GetAllAssetAndRelationalInfoRM>> GetAllAssetAndDepricationInfo(int CompanyID, int FiscalYear, CancellationToken cancellationToken)
        {
            var data = from ai in dbCon.AssetInfo
                       join adh in dbCon.AssetDepriciationHistory on ai.AssetID equals adh.AssetID
                       where ai.IsActive == true
                       && ai.IsRemoved == false
                       && (CompanyID == 0 || ai.CompanyID == CompanyID)
                       && (FiscalYear == 0 || adh.FiscalYear == FiscalYear)
                       select new GetAllAssetAndRelationalInfoRM
                       {
                           AssetID = ai.AssetID,
                           AssetName = ai.AssetName,
                           Code = ai.Code,
                           PurchaseDate = ai.PurchaseDate,
                           PurchaseValue = ai.PurchaseValue,
                           ValueAfterDeprication = ai.ValueAfterDeprication,
                           DepriciationPercent = ai.DepriciationPercent,
                           DapricationDateFrom = ai.DapricationDateFrom.Value.ToString("dd-MMM-yyyy"),
                           DapricationDateTo = ai.DapricationDateTo.Value.ToString("dd-MMM-yyyy"),
                           Rate = adh.Rate,
                           DepricationValue = adh.DepricationValue,
                           FiscalYear = adh.FiscalYear
                       };
            var dddd = data.ToQueryString();
            return await data.ToListAsync(cancellationToken);
        }

        public async Task<string> GenerateAutoAssetCode(string prefix, int companyID, int assetSubTypeID)
        {
            var assetCount = await dbCon.AssetInfo.Where(x => x.CompanyID == companyID && x.AssetSubTypeID == assetSubTypeID && x.Code.StartsWith(prefix)).CountAsync();
            var newAssetSl = (assetCount + 1).ToString().PadLeft(4, '0');
            return $"{prefix}{newAssetSl}";
        }

        public async Task<List<SelectListItem>> DDLAssetNameWiseAssetCode(string assetName, CancellationToken cancellationToken)
        {
            var data = dbCon.AssetInfo.Where(x => x.IsActive == true && x.IsRemoved == false & x.AssetName == assetName)
                                    .Select(x => new SelectListItem()
                                    {
                                        Text = x.Code,
                                        Value = x.AssetID.ToString()
                                    });

            return await data.ToListAsync(cancellationToken);
        }

        public async Task<List<ReportDataVM>> GetAssetReportData(int assetTypeName, int assetSubTypeID, int assetAssignedType, string assetName, DateTime? dateFrom, DateTime? dateTo
            , string code, int companyID, int divisionID, int departmentID, int buildingID, int floorID, string dynamicFilters, bool extendedFeature = false, CancellationToken cancellationToken = default)
        {
            List<ReportDataVM> data = new();

            var dataQuery = from ai in dbCon.AssetInfo
                            join ast in dbCon.AssetSubType on ai.AssetSubTypeID equals ast.AssetSubTypeID
                            join at in dbCon.AssetType on ast.AssetTypeID equals at.AssetTypeID
                            join fs in dbCon.AssetFunctionalStatus on ai.FunctionalStatusID equals fs.StatusID
                            join c in dbCon.Vw_EmbroCompanyInfo on ai.CompanyID equals c.CompanyID  
                            join acu in dbCon.AssetCapacityUnit on ai.CapacityUnitID equals acu.CapacityUnitID into acuj
                            from aculj in acuj.DefaultIfEmpty()
                            join al in dbCon.AssetLocation on new { ai.AssetID, IsActive=true, IsRemoved=false,IsReturned=false } equals new { al.AssetID, al.IsActive, al.IsRemoved,al.IsReturned } into alj
                            from allj in alj.DefaultIfEmpty()
                            join bi in dbCon.VW_BuildingInfo on new { allj.BuildingID, allj.FloorID } equals new { bi.BuildingID, FloorID = bi.BuildingFloorID } into bij
                            from bilj in bij.DefaultIfEmpty()
                            join cd in dbCon.AssetDepartment on new { allj.DepartmentID } equals new { DepartmentID=cd.DepartmentID} into cdj
                            from cdlj in cdj.DefaultIfEmpty()
                            join _div in dbCon.AssetDivision on new { cdlj.DivisionID } equals new { _div.DivisionID } into __divJ
                            from div in __divJ.DefaultIfEmpty()
                            where ai.IsActive==true && ai.IsRemoved==false
                            select new ReportDataVM
                            {
                                AssetID = ai.AssetID,
                                AssetName = ai.AssetName,
                                AssetSubTypeID = ai.AssetSubTypeID,
                                AssetSubTypeName = ast.SubTypeName,
                                AssetTypeID = ast.AssetTypeID,
                                AssetTypeName = at.TypeName,
                                AssetAssignedType = ai.AssetAssignedType,
                                Code = ai.Code,
                                BrandName = ai.BrandName,
                                PurchaseDate = ai.PurchaseDate,
                                PurchaseDateMsg = ai.PurchaseDate.ToString("dd-MMM-yyyy"),
                                PurchaseValue = ai.PurchaseValue,
                                DepriciationPercent = ai.DepriciationPercent,
                                ValueAfterDeprication = ai.ValueAfterDeprication,
                                CompanyID = ai.CompanyID,
                                CompanyName=c.Companyname,
                                Remarks=ai.Remarks,
                                Description = ai.Description,
                                FunctionalStatusID = ai.FunctionalStatusID,
                                FunctionalStatus = fs.StatusName,
                                Capacity = ai.Capacity,
                                CapacityUnitID = ai.CapacityUnitID,
                                CapacityUnit = aculj != null ? aculj.CapacityUnitName : null,
                                ModelNo = ai.ModelNo,
                                LCNo = ai.LCNo,
                                BuildingID= bilj!=null? bilj.BuildingID:0,
                                FloorID= bilj != null ? bilj.BuildingFloorID : 0,
                                Location = allj != null ? allj.EmployeeCode!=null? allj.EmployeeCode :$"{bilj.BuildingName}, {bilj.FloorName}": "",
                                DivisionID= div != null ? div.DivisionID : 0,
                                Division = div != null? div.DivisionName:"",
                                DepartmentID = cdlj != null ? cdlj.DepartmentID : 0,
                                Department = cdlj != null ? cdlj.DepartmentName:""
                            };

            if (assetTypeName>0)
            {
                dataQuery = dataQuery.Where(x => x.AssetTypeID == assetTypeName);
            }
            if (assetSubTypeID > 0)
            {
                dataQuery = dataQuery.Where(x => x.AssetSubTypeID == assetSubTypeID);
            }
            if (assetAssignedType > 0)
            {
                dataQuery = dataQuery.Where(x => x.AssetAssignedType == assetAssignedType);
            }
            if (assetName!=null && assetName!="")
            {
                dataQuery = dataQuery.Where(x => x.AssetName == assetName);
            }
            if (dateFrom !=null)
            {
                dataQuery = dataQuery.Where(x => x.PurchaseDate>= dateFrom);
            }
            if (dateTo !=null)
            {
                dataQuery = dataQuery.Where(x => x.PurchaseDate <=dateTo);
            }
            if (code!=null && code != "")
            {
                dataQuery = dataQuery.Where(x => x.Code == code);
            }
            if (companyID > 0)
            {
                dataQuery = dataQuery.Where(x => x.CompanyID == companyID);
            }
            if (divisionID > 0)
            {
                dataQuery = dataQuery.Where(x => x.DivisionID == divisionID);
            }
            if (departmentID > 0)
            {
                dataQuery = dataQuery.Where(x => x.DepartmentID == departmentID);
            }
            if (buildingID > 0)
            {
                dataQuery = dataQuery.Where(x => x.BuildingID == buildingID);
            }
            if (floorID > 0)
            {
                dataQuery = dataQuery.Where(x => x.FloorID == floorID);
            }

            var query = dataQuery.ToQueryString();
            data = await dataQuery.ToListAsync(cancellationToken);

            

            if (extendedFeature)
            {
                data = await GetReportDataWithAttributes(dynamicFilters, data, cancellationToken);
            }
            return data;
        }

        

        private async Task<List<ReportDataVM>> GetReportDataWithAttributes(string dynamicFilters, List<ReportDataVM> data, CancellationToken cancellationToken)
        {
            var splittedFilter = dynamicFilters.Split("%");
            List<SelectListItem> dynamicFilter = new();
            foreach (var item in splittedFilter)
            {
                if (item != "")
                {
                    var attID_Value = item.Split("-");
                    var attId = attID_Value[0].ToString();
                    var attValue = attID_Value[1].ToString().Trim();

                    dynamicFilter.Add(new SelectListItem { Value = attId, Text = attValue });
                }
            }
            foreach (var item in data)
            {
                item.DataAttribute = await GetAssetAttributes(item.AssetID, dynamicFilter, cancellationToken);
            }
            return data;
        }

        private async Task<List<DataAttributeVM>> GetAssetAttributes(int assetID, List<SelectListItem> dynamicFilter, CancellationToken cancellationToken)
        {
            var attributeQuery = from aaav in dbCon.AssetAttributeAssociationValue
                                 join aaa in dbCon.AssetAttributeAssociation on new { aaav.AssociationID, aaav.IsActive, aaav.IsRemoved } equals new { aaa.AssociationID, aaa.IsActive, aaa.IsRemoved }
                                 join aa in dbCon.AssetAttribute on new { aaa.AttributeID, aaa.IsActive, aaa.IsRemoved } equals new { aa.AttributeID, aa.IsActive, aa.IsRemoved }
                                 where aaav.AssetID == assetID && aaav.IsActive == true && aaav.IsRemoved == false
                                 select new DataAttributeVM
                                 {
                                     AttributeID = aa.AttributeID,
                                     AttributeName = aa.AttributeName,
                                     AttributeShortName = aa.AttributeShortName,
                                     PrioritySerial = aaa.PrioritySerial,
                                     IsVisible = aaa.IsVisible,
                                     AttributeValue = aaav.ValueDescription
                                 };
            if (dynamicFilter != null)
            {
                foreach (var filter in dynamicFilter)
                {
                    attributeQuery = attributeQuery.Where(x => x.AttributeID == Convert.ToInt32(filter.Value) && x.AttributeValue == filter.Text);
                }
            }

            var attributes = await attributeQuery.ToListAsync(cancellationToken);
            return attributes;
        }

        public async Task<List<string>> AssetNameAutocomplete(int assetSubTypeID, string predict, CancellationToken cancellationToken)
        {
            var data = await dbCon.AssetInfo.Where(x => x.IsActive == true && x.IsRemoved == false 
                                                && x.AssetSubTypeID == assetSubTypeID && x.AssetName.Contains(predict))
                            .Select(x => x.AssetName).Distinct().ToListAsync(cancellationToken);
            return data;
        }
    }
}
