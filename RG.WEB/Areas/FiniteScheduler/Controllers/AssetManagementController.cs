using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.DevExtremeModelBinds;
using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Setups.Tbl_Depts.Query;
using RG.Application.Contracts.Embro.CompanyInfos.Queries;
using RG.Application.Contracts.FiniteScheduler.Business.AssetAttributeAssociation.Queries;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetAssignedTypes.Queries;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetCapacityUnit.Queries;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetAttributeAssociations.Commands.Create;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetAttributeAssociations.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetAttributeAssociations.Commands.Update;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetDepriciationHistories.Commands.Create;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetDepriciationHistories.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetDepriciationHistories.Commands.Update;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetDepriciationHistories.Queries;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetFunctionalStatuss.Queries;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetIndexs.Queries;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetIndexs.Queries.RequestResponseModel;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetInfos.Commands.Create;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetInfos.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetInfos.Commands.Update;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetInfos.Queries;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetLocations.Commands.Create;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetLocations.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetLocations.Commands.Update;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetLocations.Queries;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetSubTypes.Commands.Create;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetSubTypes.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetSubTypes.Commands.Update;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetSubTypes.Query;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetTypes.Commands.Create;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetTypes.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetTypes.Commands.Update;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetTypes.Query;
using RG.Application.Contracts.FiniteScheduler.Setups.SubTypeAttributeAssociations.Queries;
using RG.Application.Contracts.MaterialsManagement.Setups.BuildingInfos.Queries;
using RG.Application.Enums;
using RG.Application.ViewModel.FiniteScheduler.Setup.AssetIndexs;
using RG.Application.ViewModel.FiniteScheduler.Setup.AssetInfo;
using RG.Application.ViewModel.FiniteScheduler.Setup.AssetInfoIndexs;
using RG.Application.ViewModel.FiniteScheduler.Setup.AssetSubType;
using RG.Application.ViewModel.FiniteScheduler.Setup.SubTypeAttributeAssociation;
using RG.DBEntities.FiniteScheduler.Setup;
using RG.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetAttributeAssociations.Queries;
using RG.Application.Contracts.FiniteScheduler.Business.AssetAttributeAssociationValue.Queries;
using RG.Application.Contracts.FiniteScheduler.Business.AssetDivisions.Queries;
using RG.Application.Contracts.FiniteScheduler.Business.AssetDepartments.Queries;
using RG.Application.Contracts.MaterialsManagement.Setups.BuildingFloorInfos.Queries;

namespace RG.WEB.Areas.FiniteScheduler.Controllers
{
    [Area("FiniteScheduler")]
    [Route("FiniteScheduler/[controller]/[action]")]
    public class AssetManagementController : BaseController
    {
        private readonly IDropdownService _dropdownService;

        public AssetManagementController(IDropdownService dropdownService)
        {
            _dropdownService = dropdownService;
        }
        public IActionResult AssetType()
        {
            return View();
        }
        public async Task<IActionResult> AssetIndex()
        {
            List<SelectListItem> SearchingType = new List<SelectListItem>() {
                 new SelectListItem{ Value="1",Text="Asset"},
                 new SelectListItem{ Value="2",Text="Depreciation"}
            };
            AssetIndexVM model = new()
            {
                DDLBuilding = _dropdownService.RenderDDL(await Mediator.Send(new DDLFloorTypeWiseBuildingQuery { FloorType = (int)enum_FloorType.Asset }), true),
                DDLLBuildingFloor = _dropdownService.DefaultDDL(),
                DDLDevision = _dropdownService.DefaultDDL(),
                DDLAssetSubTypeName = _dropdownService.DefaultDDL(),
                DDLDepartment = _dropdownService.DefaultDDL(),
                DDLAssetName = _dropdownService.DefaultDDL(),
                DDLAssetTypeName = _dropdownService.RenderDDL(await Mediator.Send(new GetAssetTypeNameQuery()), true),
                DDLCompany = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLCompanyInfoQuery()), true),
                DDLAssetAssignedType = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLAssetAssignedTypeQuery()), true),
                DDLSearchingType = SearchingType,
                DDLYear = _dropdownService.NumberDDL(DateTime.Now.AddYears(-1).Year, DateTime.Now.Year, true),
            };
            return View(model);
        }
        [HttpPost]
        public async Task<JsonResult> AssetType(AssetTypeDTM assetType)
        {
            var result = await Mediator.Send(new AssetTypeCreateCommand { AssetType = assetType });
            return Json(result);
        }
        public async Task<IActionResult> AssetSubType()
        {
            AssetSubTypeVM model = new()
            {
                DDLBuilding = _dropdownService.RenderDDL(await Mediator.Send(new DDLFloorTypeWiseBuildingQuery { FloorType = (int)enum_FloorType.YarnStore }), true),
                DDLAssetTypeName = _dropdownService.RenderDDL(await Mediator.Send(new GetAssetTypeNameQuery()), true),
            };
            return View(model);
        }
        [HttpPost]
        public async Task<JsonResult> AssetSubType(AssetSubTypeDTM assetSubType)
        {
            var result = await Mediator.Send(new AssetSubTypeCreateCommand { AssetSubType = assetSubType });
            return Json(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAssetSubType(DataSourceLoadOptions loadOptions)
        {
            loadOptions.PrimaryKey = new[] { "AssetSubTypeID" };
            loadOptions.PaginateViaPrimaryKey = true;
            var data = await Mediator.Send(new GetAllAssetSubTypeQuery { LoadOptions = loadOptions });
            return Json(data);

        }
        [HttpGet]
        public async Task<JsonResult> GetAllAssetAndRelationalInfo(DataSourceLoadOptions loadOptions, int AssetAssignedType, int AssetTypeName, int AssetSubTypeID, int AssetID, DateTime? DateFrom, DateTime? DateTo, string Code, int CompanyID, int DepartmentID, int BuildingID, int FloorID)
        {
            GetAllAssetAndRelationalInfoQM queryModel = new GetAllAssetAndRelationalInfoQM
            {
                AssetAssignedType = AssetAssignedType,
                AssetTypeName = AssetTypeName,
                AssetSubTypeID = AssetSubTypeID,
                AssetID = AssetID,
                DateFrom = DateFrom,
                DateTo = DateTo,
                Code = Code,
                CompanyID = CompanyID,
                DepartmentID = DepartmentID,
                BuildingID = BuildingID,
                FloorID = FloorID,
            };
            var _data = await Mediator.Send(new GetAllAssetAndRelationalInfoQuery { queryModel = queryModel });
            loadOptions.PrimaryKey = new[] { "AssetID" };
            loadOptions.PaginateViaPrimaryKey = true;
            var data = DataSourceLoader.Load(_data, loadOptions);
            return Json(data);
        }
        [HttpGet]
        public async Task<JsonResult> GetAllAssetAndDepricationInfo(DataSourceLoadOptions loadOptions, int CompanyID, int FiscalYear)
        {
            var _data = await Mediator.Send(new GetAllAssetAndDepricationInfoQuery { CompanyID = CompanyID, FiscalYear = FiscalYear });
            loadOptions.PrimaryKey = new[] { "AssetID" };
            loadOptions.PaginateViaPrimaryKey = true;
            var data = DataSourceLoader.Load(_data, loadOptions);
            return Json(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAssetType(DataSourceLoadOptions loadOptions)
        {
            loadOptions.PrimaryKey = new[] { "AssetTypeID" };
            loadOptions.PaginateViaPrimaryKey = true;
            var data = await Mediator.Send(new GetAllAssetTypeQuery { LoadOptions = loadOptions });
            return Json(data);

        }
        public async Task<IActionResult> AssetInfoIndex()
        {
            //Add Company, Division new Dropdown.
            AssetInfoIndexVM model = new()
            {
                DDLAssetTypeName = _dropdownService.RenderDDL(await Mediator.Send(new GetAssetTypeNameQuery()), true),
                DDLAssetSubType = _dropdownService.DefaultDDL(),
                DDLEmployee = _dropdownService.DefaultDDL(),
                DDLCompany = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLCompanyInfoQuery()), true),
                DDLBuilding = _dropdownService.RenderDDL(await Mediator.Send(new DDLFloorTypeWiseBuildingQuery { FloorType = (int)enum_FloorType.Asset }), true),
                DDLEmployeeType = _dropdownService.DefaultDDL(),
                DDLDepartment = _dropdownService.RenderDDL(await Mediator.Send(new DDLDeptListOnlyQuery()), true),
                DDLLBuildingFloor = _dropdownService.DefaultDDL(),
                DateFrom = DateTime.Now.ToString("dd-MMM-yyyy"),
                DDLDevision = _dropdownService.DefaultDDL(),
            };
            return View(model);
        }
        public async Task<IActionResult> AssetInfo()
        {
            AssetInfoVM model = new()
            {
                DateFrom = DateTime.Now.ToString("dd-MMM-yyyy"),
                DapricationDateFrom = DateTime.Now.ToString("dd-MMM-yyyy"),
                DDLBuilding = _dropdownService.RenderDDL(await Mediator.Send(new DDLFloorTypeWiseBuildingQuery { FloorType = (int)enum_FloorType.Asset }), true),
                DDLEmployeeType = _dropdownService.DefaultDDL(),
                DDLDepartment = _dropdownService.DefaultDDL(),
                DDLAssetSubTypeID = _dropdownService.DefaultDDL(),
                DDLLBuildingFloor = _dropdownService.DefaultDDL(),
                DDLDevision = _dropdownService.DefaultDDL(),
                DDLAssetTypeName = _dropdownService.RenderDDL(await Mediator.Send(new GetAssetTypeNameQuery()), true),
                DDLCompany = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLCompanyInfoQuery()), true),
                DDLLocationCompany= _dropdownService.RenderDDL(await Mediator.Send(new GetDDLCompanyInfoQuery()), true),
                DDLAssetAssignedType = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLAssetAssignedTypeQuery()), true),
                DDLCapacityUnit = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLAssetCapacityUnitQuery()), true),
                DDLFunctionalStatus = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLAssetFunctionalStatusQuery()), false),
                Code = "Comp/SubType/AutoCode"
            };

            return View(model);
        }
        [HttpPost]
        public async Task<JsonResult> AssetinfoCreate(AssetInfoDTM AssetCreate)
        {
            RResult rResult = new();
            rResult = await Mediator.Send(new AssetInfoCreateCommand { AssetInfoPC = AssetCreate });
            return Json(rResult);
        }

        public async Task<JsonResult> TempAssetinfoCreate()
        {
            RResult rResult = new();
            rResult = await Mediator.Send(new TempAssetInfoCreateCommand { });
            return Json(rResult);
        }

        [HttpGet]
        public async Task<IActionResult> AssetInfoEdit(int assetID)
        {
            AssetInfoVM model = new();
            if (assetID > 0)
            {
                model.DDLCompany = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLCompanyInfoQuery()), true);
            }
            return View("AssetInfo", model);
        }
        public async Task<IActionResult> Remove(int ID)
        {
            var rResult = new RResult();
            rResult = await Mediator.Send(new DeleteAssetWithChildCommand { AssetID = ID });
            return Json(rResult);
        }
        public async Task<IActionResult> AssetDepriciationHistoryRemove(int id)
        {
            var rResult = new RResult();
            rResult = await Mediator.Send(new AssetDepriciationHistoryRemoveCommand { ID = id });
            return Json(rResult);
        }
        public async Task<JsonResult> GetDDLAssetSubType(int AssetTypeID, string Predict = null)
        {
            var data = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLAssetTypeWiseAssetSubTypeQuery { AssetTypeID = AssetTypeID, Predict = Predict }), true);
            return Json(data);
        }
        public async Task<JsonResult> GetAllAssetInfo(DataSourceLoadOptions loadOptions, int assetTypeID, int assetSubTypeID)
        {
            var _data = await Mediator.Send(new GetAllAssetWithSearchTypeAndSubTypeQuery { AssetTypeID = assetTypeID, AssetTypeSubID = assetSubTypeID });
            loadOptions.PrimaryKey = new[] { "AssetID" };
            loadOptions.PaginateViaPrimaryKey = true;
            var data = DataSourceLoader.Load(_data, loadOptions);
            return Json(data);
        }
        [HttpPost]
        public async Task<IActionResult> AssetTypeUpdate(AssetTypeDTM assetTypeDTM)
        {
            var rResult = new RResult();
            rResult = await Mediator.Send(new AssetTypesUpdateCommand { assetTypeDTM = assetTypeDTM });
            return Json(rResult);
        }
        [HttpPost]
        public async Task<IActionResult> AssetinfoUpdate(AssetInfoDTM assetInfoDTmodel)
        {
            var rResult = new RResult();
            rResult = await Mediator.Send(new AssetinfoUpdateCommand { assetInfoDTM = assetInfoDTmodel });
            return Json(rResult);
        }
        [HttpPost]
        public async Task<IActionResult> AssetDepriciationHistoryUpdate(AssetDepriciationHistoryDTmodel model)
        {
            var rResult = new RResult();
            rResult = await Mediator.Send(new AssetDepriciationHistoryUpdateCommand { DTmodel = model });
            return Json(rResult);
        }
        [HttpPost]
        public async Task<IActionResult> AssetLocationAssign(AssetLocation DbModel)
        {
            var rResult = new RResult();
            rResult = await Mediator.Send(new AssetLocationCreateCommand { dbmodel = DbModel });
            return Json(rResult);
        }
        [HttpPost]
        public async Task<IActionResult> AssetTypeRemove(int assetTypeID)
        {
            var rResult = new RResult();
            rResult = await Mediator.Send(new AssetTypesRemoveCommand { AssetTypeID = assetTypeID });
            return Json(rResult);
        }
        [HttpPost]
        public async Task<IActionResult> AssetSubTypeUpdate(AssetSubTypeDTM assetSubTypeDTM)
        {
            var rResult = new RResult();
            rResult = await Mediator.Send(new AssetSubTypeUpdateCommand { assetSubTypeDTM = assetSubTypeDTM });
            return Json(rResult);
        }
        [HttpPost]
        public async Task<IActionResult> AssetCollectLoaction(AssetLocationDTModel assetLocationDTModel)
        {
            var rResult = new RResult();
            rResult = await Mediator.Send(new AssetCollectLoactionUpdateCommand { DTModel = assetLocationDTModel });
            return Json(rResult);
        }
        [HttpPost]
        public async Task<IActionResult> AssetDepriciationHistorieCreate(AssetDepriciationHistory depriciationHistory)
        {
            var rResult = new RResult();
            rResult = await Mediator.Send(new AssetDepriciationHistorieCreateCommand { assetDepriciationHistory = depriciationHistory });
            return Json(rResult);
        }
        public async Task<IActionResult> AssetSubTypeRemove(int assetSubTypeID)
        {
            var rResult = new RResult();
            rResult = await Mediator.Send(new AssetSubTypeRemoveCommand { AssetSubTypeID = assetSubTypeID });
            return Json(rResult);
        }
        public async Task<IActionResult> GetAssetLoactionById(int id)
        {
            var data = await Mediator.Send(new GetAssetLoactionByIDQuery { id = id });
            return Json(data);


        }
        [HttpPost]
        public async Task<IActionResult> GetListAssetDepriciationHistory(int id)
        {
            var data = await Mediator.Send(new GetListAssetDepriciationHistoryQuery { assetID = id });
            return Json(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetDataToUpdateAssetEdit(int id)
        {

            AssetInfoVM model = new();

            if (id > 0)
            {
                model = await Mediator.Send(new GetDataToUpdateAssetQuery { Id = id });
                model.DDLAssetAssignedType = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLAssetAssignedTypeQuery()), true);
                model.DDLCompany = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLCompanyInfoQuery()), true);
                if (model.AssetAssignedType == 2)
                {
                    model.DDLLocationCompany = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLCompanyInfoQuery()), true);
                    model.DDLDevision = _dropdownService.RenderDDL(await Mediator.Send(new EmbroCompanyWiseDDLDivisionQuery() { EmbroCompanyID = model.LoaCompanyID??0, Predict = "" }), true);
                    model.DDLDepartment = _dropdownService.RenderDDL(await Mediator.Send(new GetDivisionWiseDDLDepartmentQuery() { DivisionId = model.OfficeDivisionID??0, Predict = "" }), true);
                    model.DDLBuilding = _dropdownService.RenderDDL(await Mediator.Send(new DDLFloorTypeWiseBuildingQuery { FloorType = (int)enum_FloorType.Asset }), true);
                    model.DDLLBuildingFloor = _dropdownService.RenderDDL(await Mediator.Send(new DDLBuildingWiseBuildingFloorQuery { Building = model.BuildingID??0, Floor = (int)enum_FloorType.Asset, Predict = "" }), true);
                }
                else
                {
                    model.DDLLocationCompany = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLCompanyInfoQuery()), true);
                    model.DDLDevision = _dropdownService.DefaultDDL();
                    model.DDLDepartment = _dropdownService.DefaultDDL();
                    model.DDLBuilding = _dropdownService.RenderDDL(await Mediator.Send(new DDLFloorTypeWiseBuildingQuery { FloorType = (int)enum_FloorType.Asset }), true);
                    model.DDLLBuildingFloor = _dropdownService.DefaultDDL();
                } 
                model.DDLEmployeeType = _dropdownService.DefaultDDL();
                model.DDLAssetTypeName = _dropdownService.RenderDDL(await Mediator.Send(new GetAssetTypeNameQuery()), true);
                model.DDLCapacityUnit = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLAssetCapacityUnitQuery()), true);
                model.DDLFunctionalStatus = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLAssetFunctionalStatusQuery()), false);


            }
            return View("AssetInfo", model);
        }
        public async Task<JsonResult> GetDDLAssetNameViaAssetSubType( int assetSubTypeID)
        {
            var data = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLAssetNameViaAssetSubTypeQuery { AssetSubTypeID = assetSubTypeID }), true);
            return Json(data);
        }
        public async Task<JsonResult> GetDDLAssetNameWiseAssetCode(string AssetName)
        {
            var data = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLAssetNameWiseAssetCodeQuery { AssetName = AssetName }), true);
            return Json(data);
        }
        public async Task<JsonResult> GetAssetSubTypeWiseAttributes(int assetSubTypeID)
        {
            var data = await Mediator.Send(new AssetSubTypeWiseAttributesQuery { AssetSubTypeID = assetSubTypeID });
            return Json(data);
        }


        public async Task<IActionResult> SubTypeAttributeAssociation()
        {
            SubTypeAttributeAssociationVM model = new ()
            {
                DDLAssetType= _dropdownService.RenderDDL(await Mediator.Send(new GetAssetTypeNameQuery()), true),
                DDLAssetSubType=_dropdownService.DefaultDDL()
            };
            return View(model);
        }

        public async Task<JsonResult> GetAssetSubTypeWiseAttribute(int ID)
        {
            var data = await Mediator.Send(new GetAssetSubTypeWiseAttributeQuery { id = ID });
            return Json(data);
        }


        [HttpPost]
        public async Task<JsonResult> AssetAttributeAssociationCheckListSave(List<AssetAttributeAssociationDTM> model)
        {
            var data = await Mediator.Send(new AssetAttributeAssociationCheckListSaveCommand { assetAttributeAssociationDTM = model });
            return Json(data);
        }

        [HttpPost]
        public async Task<JsonResult> AssetAttributeAssociationCheckListRemove(List<AssetAttributeAssociationDTM> removeList)
        {
            var dataResult = await Mediator.Send(new AssetAttributeAssociationCheckListRemoveCommand{ modelList = removeList });
            return Json(dataResult);
        }

        [HttpPost]
        public async Task<JsonResult> AssetAttributeAssociationUpdate(AssetAttributeAssociationDTM UpdateModel)
        {
            var data = await Mediator.Send(new AssetAttributeAssociationUpdateCommand { model = UpdateModel });
            return Json(data);
        }

        public async Task<IActionResult> AssetReports()
        {
            List<SelectListItem> SearchingType = new() {
                 new SelectListItem{ Value="1",Text="Asset"},
                 new SelectListItem{ Value="2",Text="Depreciation"}
            };
            AssetReportsVM model = new()
            {
                DDLBuilding = _dropdownService.RenderDDL(await Mediator.Send(new DDLFloorTypeWiseBuildingQuery { FloorType = (int)enum_FloorType.Asset }), true),
                DDLLBuildingFloor = _dropdownService.DefaultDDL(),
                DDLDevision = _dropdownService.DefaultDDL(),
                DDLAssetSubTypeName = _dropdownService.DefaultDDL(),
                DDLDepartment = _dropdownService.DefaultDDL(),
                DDLAssetName = _dropdownService.DefaultDDL(),
                DDLAssetTypeName = _dropdownService.RenderDDL(await Mediator.Send(new GetAssetTypeNameQuery()), true),
                DDLCompany = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLCompanyInfoQuery()), true),
                DDLAssetAssignedType = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLAssetAssignedTypeQuery()), true),
                DDLSearchingType = SearchingType,
                DDLYear = _dropdownService.NumberDDL(DateTime.Now.AddYears(-1).Year, DateTime.Now.Year, true),
            };
            return View(model);
        }
        public async Task<JsonResult> AssetSubTypeWiseFilterableAttributes(int assetSubTypeID)
        {
            var data = await Mediator.Send(new AssetSubTypeWiseFilterableAttributesQuery { AssetSubTypeID = assetSubTypeID });
            return Json(data);
        }
        public async Task<JsonResult> AttributeValueAutoComplete(int assetSubTypeID,int attributeID,string predict)
        {
            var data = await Mediator.Send(new AttributeValueAutoCompleteQuery { AssetSubTypeID = assetSubTypeID , AttributeID =attributeID,Predict=predict});
            return Json(data);
        }
        public async Task<JsonResult> AssetNameAutocomplete(int assetSubTypeID,string predict)
        {
            var data = await Mediator.Send(new AssetNameAutocompleteQuery { AssetSubTypeID = assetSubTypeID , Predict=predict});
            return Json(data);
        }
        
        public async Task<IActionResult> Report(int AssetTypeName,int AssetSubTypeID ,
            int AssetAssignedType, string AssetName, DateTime? DateFrom, DateTime? DateTo, string Code, int CompanyID,
            int DivisionID, int DepartmentID, int BuildingID, int FloorID, string DynamicFilter,bool ExtendedFeature=false)
        {
            var data = await Mediator.Send(new GetAssetReportDataQuery {AssetTypeName=AssetTypeName,AssetSubTypeID=AssetSubTypeID
                ,AssetAssignedType=AssetAssignedType,AssetName=AssetName,DateFrom=DateFrom,DateTo=DateTo,Code=Code,CompanyID=CompanyID,DivisionID=DivisionID,DepartmentID=DepartmentID
                ,BuildingID=BuildingID,FloorID=FloorID,DynamicFilters=DynamicFilter,ExtendedFeature=ExtendedFeature });
            return View(data);
        }
        public async Task<IActionResult> AssetStickerReport(int AssetTypeName, int AssetSubTypeID,
           int AssetAssignedType, string AssetName, DateTime? DateFrom, DateTime? DateTo, string Code, int CompanyID,
           int DivisionID, int DepartmentID, int BuildingID, int FloorID, string DynamicFilter, bool ExtendedFeature = false)
        {
            var data = await Mediator.Send(new GetAssetReportDataQuery
            {
                AssetTypeName = AssetTypeName,
                AssetSubTypeID = AssetSubTypeID
                ,
                AssetAssignedType = AssetAssignedType,
                AssetName = AssetName,
                DateFrom = DateFrom,
                DateTo = DateTo,
                Code = Code,
                CompanyID = CompanyID,
                DivisionID = DivisionID,
                DepartmentID = DepartmentID
                ,
                BuildingID = BuildingID,
                FloorID = FloorID,
                DynamicFilters = DynamicFilter,
                ExtendedFeature = ExtendedFeature
            });
            return View(data);
        }

        
        public async Task<JsonResult> EmbroCompanyWiseDDLDivision(int embroCompanyID, string Predict = null)
        {
            try
            {
                var divisionList = _dropdownService.RenderDDL( await Mediator.Send(new EmbroCompanyWiseDDLDivisionQuery() { EmbroCompanyID= embroCompanyID, Predict = Predict }),true);
                return Json(divisionList);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        
        public async Task<JsonResult> GetDivisionWiseDDLDepartment(int DivisionId, string Predict = null)
        {
            try
            {
                var divisionList =_dropdownService.RenderDDL( await Mediator.Send(new GetDivisionWiseDDLDepartmentQuery() { DivisionId= DivisionId, Predict = Predict }),true);
                return Json(divisionList);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        

    }
}
