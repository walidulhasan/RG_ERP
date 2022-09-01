using Microsoft.EntityFrameworkCore;
using RG.DBEntities.MaterialsManagement;
using RG.DBEntities.MaterialsManagement.Business;
using RG.DBEntities.MaterialsManagement.DBViews;
using RG.DBEntities.MaterialsManagement.GateReceiving;
using RG.DBEntities.MaterialsManagement.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.MaterialsManagement
{
    public  interface IMaterialsManagementDBContext
    {
        #region Setup
        public  DbSet<Yarn_RateSetup> Yarn_RateSetup { get; set; }
        public  DbSet<YArn_UnitSetup> YArn_UnitSetup { get; set; }
        public  DbSet<Yarn_ProcurementPurpose> Yarn_ProcurementPurpose { get; set; }
        public  DbSet<Yarn_ProcurementType> Yarn_ProcurementType { get; set; }
        public  DbSet<MM_Reason_Setup> MM_Reason_Setup { get; set; }
        public  DbSet<MM_StoreCategoryRelation> MM_StoreCategoryRelation { get; set; }
        public  DbSet<DDReasons_Setup> DDReasons_Setup { get; set; }
        public  DbSet<Module_Setup> Module_Setup { get; set; }
        public  DbSet<SubModule_Setup> SubModule_Setup { get; set; }
        public  DbSet<MM_DocumentType_Setup> MM_DocumentType_Setup { get; set; }
        public  DbSet<DD_POStatus_Setup> DD_POStatus_Setup { get; set; }
        public  DbSet<DDDeliveryPoint_Setup> DDDeliveryPoint_Setup { get; set; }
        public  DbSet<mm_PaymentMode> mm_PaymentMode { get; set; }
        public  DbSet<mm_PaymentTerm> mm_PaymentTerm { get; set; }
        public  DbSet<DDSigningAuthority_Setup> DDSigningAuthority_Setup { get; set; }
        public  DbSet<MM_MRPGrossUnit> MM_MRPGrossUnit { get; set; }
        public  DbSet<MM_MRPItem> MM_MRPItem { get; set; }
        public  DbSet<MM_MRPItemAttributeInstance> MM_MRPItemAttributeInstance { get; set; }
        public  DbSet<MM_MRPItemAttributeSet> MM_MRPItemAttributeSet { get; set; }
        public  DbSet<MM_MRPItemAttributeSetValues> MM_MRPItemAttributeSetValues { get; set; }
        public  DbSet<MM_MRPItemMasterAttribute> MM_MRPItemMasterAttribute { get; set; }
        public  DbSet<MM_MRPUnits> MM_MRPUnits { get; set; }
        public  DbSet<MM_MRPItemUnits> MM_MRPItemUnits { get; set; }
        public  DbSet<MM_UnitConversion_Setup> MM_UnitConversion_Setup { get; set; }
        public  DbSet<Yarn_DaysOfPayment_Setup> Yarn_DaysOfPayment_Setup { get; set; }
        public  DbSet<Yarn_TermsOfPayment_Setup> Yarn_TermsOfPayment_Setup { get; set; }
        public  DbSet<QRM_MM_UnitMapping> QRM_MM_UnitMapping { get; set; }

        public  DbSet<MM_Store_Setup> MM_Store_Setup { get; set; }
        public  DbSet<MM_StoreLocations_Setup> MM_StoreLocations_Setup { get; set; }
        public  DbSet<Yarn_ProgramType_Setup> Yarn_ProgramType_Setup { get; set; }
        public  DbSet<CMBL_SubProgramMaster> CMBL_SubProgramMaster { get; set; }
        public  DbSet<CMBL_SubProgramDetail> CMBL_SubProgramDetail { get; set; }
        public  DbSet<CMBL_SubProgramProcess> CMBL_SubProgramProcess { get; set; }
        public  DbSet<CMBL_UserDepartment> CMBL_UserDepartment { get; set; }
        public  DbSet<CMBL_Unit> CMBL_Unit { get; set; }
        public  DbSet<CMBL_UserStore> CMBL_UserStore { get; set; }
        public  DbSet<CMBL_Item> CMBL_Item { get; set; }
        public  DbSet<CMBL_ItemAttribute> CMBL_ItemAttribute { get; set; }
        public  DbSet<CMBL_ItemAttributeSet> CMBL_ItemAttributeSet { get; set; }
        public  DbSet<CMBL_ItemUnit> CMBL_ItemUnit { get; set; }
        public  DbSet<CMBL_StoreBroadGroup> CMBL_StoreBroadGroup { get; set; }
        public  DbSet<CMBL_RequisitionStatus> CMBL_RequisitionStatus { get; set; }
        public  DbSet<MM_StoreLocationTypes_Setup> MM_StoreLocationTypes_Setup { get; set; }
        public  DbSet<Yarn_KnittingWastage_Setup> Yarn_KnittingWastage_Setup { get; set; }
        public  DbSet<IC_Department> IC_Department { get; set; }
        public  DbSet<IC_SampleCustomerType> IC_SampleCustomerType { get; set; }
        public  DbSet<IC_SampleType_Setup> IC_SampleType_Setup { get; set; }
        public  DbSet<IC_SampleTypeProcess_Setup> IC_SampleTypeProcess_Setup { get; set; }
        public  DbSet<IC_UserDepartmentSetup> IC_UserDepartmentSetup { get; set; }
        public  DbSet<IC_UnitSetup> IC_UnitSetup { get; set; }
        public  DbSet<IC_ReturnableItemCategory> IC_ReturnableItemCategory { get; set; }
        public  DbSet<IC_ProcessSetup> IC_ProcessSetup { get; set; }
        public  DbSet<IC_GatePassAccountReview> IC_GatePassAccountReview { get; set; }
        public  DbSet<DailyProductionHour> DailyProductionHours { get; set; }
        public  DbSet<YarnRackSetup> YarnRackSetup { get; set; }
        public  DbSet<YarnSubRackSetup> YarnSubRackSetup { get; set; }
        public  DbSet<BuildingFloorInfo> BuildingFloorInfo { get; set; }
        public  DbSet<BuildingInfo> BuildingInfo { get; set; }

        //
        #endregion

        #region Business
        //
        public  DbSet<Yarn_PODeliverySchedule> Yarn_PODeliverySchedule { get; set; }
        public  DbSet<Yarn_PODetailRequisition> Yarn_PODetailRequisition { get; set; }
        public  DbSet<Yarn_GRNGRVAssociation> Yarn_GRNGRVAssociation { get; set; }
        public  DbSet<MM_CostCenterAssciationStyleWise> MM_CostCenterAssciationStyleWise { get; set; }
        public  DbSet<ValuationClass> ValuationClass { get; set; }
        public  DbSet<MM_FIIntregration> MM_FIIntregration { get; set; }
        public  DbSet<MM_PermanentReceivingMaster> MM_PermanentReceivingMaster { get; set; }
        public  DbSet<MM_ListAttributeInstanceID> MM_ListAttributeInstanceID { get; set; }
        public  DbSet<MM_ModelRequisitionRequirement> MM_ModelRequisitionRequirement { get; set; }
        public  DbSet<MM_ModelGrossRequirement> MM_ModelGrossRequirement { get; set; }
        public  DbSet<MM_ModelRequisitionMaster> MM_ModelRequisitionMaster { get; set; }
        public  DbSet<Yarn_IssuanceToKnitterMaster> Yarn_IssuanceToKnitterMaster { get; set; }
        public  DbSet<Yarn_AllocationToKnitter> Yarn_AllocationToKnitter { get; set; }
        public  DbSet<TEMP_Yarn_Issue> TEMP_Yarn_Issue { get; set; }
        public  DbSet<Yarn_KnitterStockTransactions> Yarn_KnitterStockTransactions { get; set; }
        public  DbSet<Yarn_StockTransactions> Yarn_StockTransactions { get; set; }
        public  DbSet<Yarn_PermanentReceivingMaster> Yarn_PermanentReceivingMaster { get; set; }
        public  DbSet<Greige_StockTransactions> Greige_StockTransactions { get; set; }
        public  DbSet<Greige_PermanentReceivingMaster> Greige_PermanentReceivingMaster { get; set; }
        public  DbSet<Yarn_KnittingContractFlatBed> Yarn_KnittingContractFlatBed { get; set; }
        public  DbSet<Yarn_KnittingContractMaster> Yarn_KnittingContractMaster { get; set; }
        public  DbSet<Yarn_KnittingContractTippingSpecification> Yarn_KnittingContractTippingSpecification { get; set; }
        public  DbSet<DD_POInstructions> DD_POInstructions { get; set; }
        public  DbSet<DD_POItemDetails> DD_POItemDetails { get; set; }
        public  DbSet<DD_POItemMaster> DD_POItemMaster { get; set; }
        public  DbSet<DD_POStatusChangeHistory> DD_POStatusChangeHistory { get; set; }
        public  DbSet<DD_PurchaseOrder> DD_PurchaseOrder { get; set; }
        public  DbSet<Yarn_KnittingContractColor> Yarn_KnittingContractColor { get; set; }
        public  DbSet<Yarn_KnittingContractDeliverySchedule> Yarn_KnittingContractDeliverySchedule { get; set; }
        public  DbSet<Yarn_KnittingContractDetail> Yarn_KnittingContractDetail { get; set; }
        public  DbSet<Dyed_TemporaryReceivingMaster> Dyed_TemporaryReceivingMaster { get; set; }
        public  DbSet<Dyed_StockTransactions> Dyed_StockTransactions { get; set; }
        public  DbSet<Greige_DyeingContractMaster> Greige_DyeingContractMaster { get; set; }
        public  DbSet<Greige_DyeingContractDetail> Greige_DyeingContractDetail { get; set; }
        public  DbSet<Greige_DyeingContractDeliverySchedule> Greige_DyeingContractDeliverySchedule { get; set; }
        public  DbSet<Greige_IssuanceMaster> Greige_IssuanceMaster { get; set; }
        public  DbSet<Greige_IssuanceAgainstDyeingContract_Detail> Greige_IssuanceAgainstDyeingContract_Detail { get; set; }
        public  DbSet<CMBL_ItemRequisitionMaster> CMBL_ItemRequisitionMaster { get; set; }
        public  DbSet<CMBL_ItemRequisitionRequirement> CMBL_ItemRequisitionRequirement { get; set; }
        public  DbSet<Yarn_RequisitionMaster> Yarn_RequisitionMaster { get; set; }
        public  DbSet<Yarn_RequisitionDetail> Yarn_RequisitionDetail { get; set; }
        public  DbSet<CMBL_InterStoreTransfer_Master> CMBL_InterStoreTransfer_Master { get; set; }
        public  DbSet<CMBL_StockTransaction> CMBL_StockTransaction { get; set; }
        public  DbSet<CMBL_IssuanceWithRequisition> CMBL_IssuanceWithRequisition { get; set; }
        public  DbSet<CMBL_COAAssociationType> CMBL_COAAssociationType { get; set; }
        public  DbSet<CMBL_AssetToCostCenterAssociation> CMBL_AssetToCostCenterAssociation { get; set; }
        public  DbSet<CMBL_FIIntegeration> CMBL_FIIntegeration { get; set; }
        public  DbSet<Dyed_InspectionMaster> Dyed_InspectionMaster { get; set; }
        public  DbSet<IC_DocumentCategories> IC_DocumentCategories { get; set; }
        public  DbSet<IC_GatepassMaster> IC_GatepassMaster { get; set; }
        public  DbSet<IC_LocalSalesGatePassMaster> IC_LocalSalesGatePassMaster { get; set; }
        public  DbSet<IC_ExportSalesGatePassMaster> IC_ExportSalesGatePassMaster { get; set; }
        public  DbSet<IC_ScrapSalesGatePassMaster> IC_ScrapSalesGatePassMaster { get; set; }
        public  DbSet<IC_NonReturnableGatePassMaster> IC_NonReturnableGatePassMaster { get; set; }
        public  DbSet<IC_ReturnableGatePassMaster> IC_ReturnableGatePassMaster { get; set; }
        public  DbSet<IC_SampleGatePassMaster> IC_SampleGatePassMaster { get; set; }
        public  DbSet<IC_LocalSalesGatePassDetail> IC_LocalSalesGatePassDetail { get; set; }
        public  DbSet<IC_ExportSalesGatePassDetail> IC_ExportSalesGatePassDetail { get; set; }
        public  DbSet<IC_ScrapSalesGatePassDetail> IC_ScrapSalesGatePassDetail { get; set; }
        public  DbSet<IC_NonReturnableGatePassDetail> IC_NonReturnableGatePassDetail { get; set; }
        public  DbSet<IC_ReturnableGatePassDetail> IC_ReturnableGatePassDetail { get; set; }
        public  DbSet<IC_SampleGatePassDetail> IC_SampleGatePassDetail { get; set; }
        public  DbSet<IC_ReturnableRecieveGatePassDetail> IC_ReturnableRecieveGatePassDetail { get; set; }
        public  DbSet<YarnRackAllocation> YarnRackAllocation { get; set; }
        public DbSet<CMBL_PurchaseOrder> CMBL_PurchaseOrder { get; set; }
        //
        #endregion Business

        #region GateReceving
        public DbSet<MM_GateReceiving> MM_GateReceiving { get; set; }
        public  DbSet<MM_GateReceivingDetail> MM_GateReceivingDetail { get; set; }
        public  DbSet<MM_TempReceivingMaster> MM_TempReceivingMaster { get; set; }
        public  DbSet<MM_StockTransactions> MM_StockTransactions { get; set; }
        public  DbSet<MM_MaterialInspection_Master> MM_MaterialInspection_Master { get; set; }
        public  DbSet<Yarn_GateReceivingMaster> Yarn_GateReceivingMaster { get; set; }
        public  DbSet<Yarn_GateReceivingDetail> Yarn_GateReceivingDetail { get; set; }
        public  DbSet<Yarn_POMaster> Yarn_POMaster { get; set; }
        public  DbSet<Yarn_WOMaster> Yarn_WOMaster { get; set; }
        public  DbSet<Yarn_TemporaryReceivingMaster> Yarn_TemporaryReceivingMaster { get; set; }
        public  DbSet<Yarn_SupplierInitial> Yarn_SupplierInitial { get; set; }
        public  DbSet<yarn_PODetail> yarn_PODetail { get; set; }
        public  DbSet<Yarn_InspectionMaster> Yarn_InspectionMaster { get; set; }
        public  DbSet<Yarn_WeighingInspectionMaster> Yarn_WeighingInspectionMaster { get; set; }
        //
        #endregion
        #region Purchase Requisition
        public DbSet<vw_RequisitionToPurchaseOrderCreate> vw_RequisitionToPurchaseOrderCreate { get; set; }
        public DbSet<viw_CurrentMovingAverageForAttributeInstance> viw_CurrentMovingAverageForAttributeInstance { get; set; }

        #endregion

        #region Partial Requisition Issue
        public  DbSet<MM_PartialRequisition_Master> MM_PartialRequisition_Master { get; set; }
        public  DbSet<MM_PartialRequisition_Detail> MM_PartialRequisition_Detail { get; set; }
        public  DbSet<MM_MaterialIssuanceMaster> MM_MaterialIssuanceMaster { get; set; }
        #endregion Partial Requisition Issue

        #region Inter Order Transfer IOT
        public  DbSet<CMBL_InterOrderTransfer> CMBL_InterOrderTransfer { get; set; }
        public  DbSet<MM_InterOrderTransferMaster> MM_InterOrderTransferMaster { get; set; }
        #endregion
        #region DB Views
        public DbSet<vw_GetAllGatePass> vw_GetAllGatePass { get; set; }
        public DbSet<Viw_Supplier> Viw_Supplier { get; set; }
        public DbSet<View_AttributeInstanceYarnInfo> View_AttributeInstanceYarnInfo { get; set; }

        #endregion DB Views
    }
}
