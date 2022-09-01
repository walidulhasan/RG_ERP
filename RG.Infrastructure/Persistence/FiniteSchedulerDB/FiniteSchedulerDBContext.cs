using Microsoft.EntityFrameworkCore;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Interfaces.Repositories.FiniteScheduler;
using RG.DBEntities;
using RG.DBEntities.FiniteScheduler.Business;
using RG.DBEntities.FiniteScheduler.DBViews;
using RG.DBEntities.FiniteScheduler.Setup;
using RG.DBEntities.MaterialsManagement.Setup;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.Persistence.FiniteSchedulerDB
{
    public partial class FiniteSchedulerDBContext : DbContext, IFiniteSchedulerDBContext
    {
        private readonly ICurrentUserService _currentUserService;
        public FiniteSchedulerDBContext(DbContextOptions<FiniteSchedulerDBContext> options, ICurrentUserService currentUserService)
           : base(options)
        {
            _currentUserService = currentUserService;
        }

        #region Setup
        public virtual DbSet<tbl_KnittingJobStatus> tbl_KnittingJobStatus { get; set; }
        public virtual DbSet<tbl_KnittingRollsQuality_Setup> tbl_KnittingRollsQuality_Setup { get; set; }
        public virtual DbSet<MT_Location_Setup> MT_Location_Setup { get; set; }
        public virtual DbSet<MT_Machine_Setup> MT_Machine_Setup { get; set; }
        public virtual DbSet<MT_MachineMaintenanceCategory_Setup> MT_MachineMaintenanceCategory_Setup { get; set; }
        public virtual DbSet<MT_MaintenanceItem_Setup> MT_MaintenanceItem_Setup { get; set; }
        public virtual DbSet<MT_MachineAndMaintenanceItemAssociation> MT_MachineAndMaintenanceItemAssociation { get; set; }
        public virtual DbSet<MT_MachineMaintenanceStatus> MT_MachineMaintenanceStatus { get; set; }
        
        public virtual DbSet<MT_MaintenanceSchedule_Setup> MT_MaintenanceSchedule_Setup { get; set; }
        public virtual DbSet<MT_MachineGroup> MT_MachineGroup { get; set; }
        public virtual DbSet<AssetLocation> AssetLocation { get; set; }
        public virtual DbSet<AssetDepriciationHistory> AssetDepriciationHistory { get; set; }
        public virtual DbSet<AssetType> AssetType { get; set; }
        public virtual DbSet<AssetSubType> AssetSubType { get; set; }
        public virtual DbSet<AssetInfo> AssetInfo { get; set; }
        public virtual DbSet<AssetAssignedType> AssetAssignedType { get; set; }
        public virtual DbSet<AssetFunctionalStatus> AssetFunctionalStatus { get; set; }
        public virtual DbSet<AssetCapacityUnit> AssetCapacityUnit { get; set; }

        

        //
        #endregion


        #region Business
        public virtual DbSet<DFS_DCAssociationforLot> DFS_DCAssociationforLot { get; set; }
        public virtual DbSet<tbl_KnittingPickListMaster> tbl_KnittingPickListMaster { get; set; }
        public virtual DbSet<DFS_LotMakingMaster> DFS_LotMakingMaster { get; set; }
        public virtual DbSet<tbl_KnittingPickListDetail> tbl_KnittingPickListDetail { get; set; }
        public virtual DbSet<DFS_ReceivingMaster> DFS_ReceivingMaster { get; set; }
        public virtual DbSet<tbl_KnittingRolls> tbl_KnittingRolls { get; set; }
        public virtual DbSet<DFS_Return_Rolls> DFS_Return_Rolls { get; set; }
        public virtual DbSet<tbl_KnittingRolls_Roll_Attributes> tbl_KnittingRolls_Roll_Attributes { get; set; }
        public virtual DbSet<DFS_StockTransaction> DFS_StockTransaction { get; set; }
        public virtual DbSet<tbl_KnittingStockTransaction> tbl_KnittingStockTransaction { get; set; }
        public virtual DbSet<tbl_KnittingSubPickListMaster> tbl_KnittingSubPickListMaster { get; set; }
        public virtual DbSet<tbl_GateKnittingRolls> tbl_GateKnittingRolls { get; set; }
        public virtual DbSet<tbl_knittingGate> tbl_knittingGate { get; set; }
        public virtual DbSet<tbl_KnittingSubPickListDetail> tbl_KnittingSubPickListDetail { get; set; }
        public virtual DbSet<tbl_KnittingInspectionMaster> tbl_KnittingInspectionMaster { get; set; }
        public virtual DbSet<tbl_KnittingIssuanceMaster> tbl_KnittingIssuanceMaster { get; set; }
        public virtual DbSet<tbl_KnittingLaboratoryInspection> tbl_KnittingLaboratoryInspection { get; set; }
        public virtual DbSet<tbl_KnittingJobConfirmation> tbl_KnittingJobConfirmation { get; set; }
        public virtual DbSet<tbl_KnittingJobs> tbl_KnittingJobs { get; set; }
        public virtual DbSet<DFS_IssuanceMaster> DFS_IssuanceMaster { get; set; }
        public virtual DbSet<DFS_ConfirmationMaster> DFS_ConfirmationMaster { get; set; }
        public virtual DbSet<DFS_InspectionMaster> DFS_InspectionMaster { get; set; }
        public virtual DbSet<DFS_InspectionNewAttribute_Setup> DFS_InspectionNewAttribute_Setup { get; set; }
      

        public virtual DbSet<MT_MachineAndMaintenanceCheckListMaster> MT_MachineAndMaintenanceCheckListMaster { get; set; }
        public virtual DbSet<MT_MachineAndMaintenanceCheckListDetails> MT_MachineAndMaintenanceCheckListDetails { get; set; }
        public virtual DbSet<AssetAttribute> AssetAttribute { get; set; }
        public virtual DbSet<AssetAttributeAssociation> AssetAttributeAssociation { get; set; }
        public virtual DbSet<AssetAttributeAssociationValue> AssetAttributeAssociationValue { get; set; }
        public virtual DbSet<TempAsset> TempAsset { get; set; }
        public virtual DbSet<AssetDivision> AssetDivision { get; set; }
        public virtual DbSet<AssetDepartment> AssetDepartment { get; set; }
        

        #endregion Business

        #region DB Views
        public virtual DbSet<VW_BuildingInfo> VW_BuildingInfo { get; set; }
        public virtual DbSet<Vw_HR_CompanyDepartment> Vw_HR_CompanyDepartment { get; set; }
        public virtual DbSet<Vw_EmbroCompanyInfo> Vw_EmbroCompanyInfo { get; set; }
        

        #endregion

        #region Tables


        //public virtual DbSet<AcBalanceFabricStock> AcBalanceFabricStock { get; set; }
        //public virtual DbSet<AcBalanceFabricStockBk> AcBalanceFabricStockBk { get; set; }
        //public virtual DbSet<AgencyAgencyIssuanceMaster> AgencyAgencyIssuanceMaster { get; set; }
        //public virtual DbSet<AgencyConfirmationMaster> AgencyConfirmationMaster { get; set; }
        //public virtual DbSet<AgencyConfirmationView> AgencyConfirmationView { get; set; }
        //public virtual DbSet<AgencyDateWiseReport> AgencyDateWiseReport { get; set; }
        //public virtual DbSet<AgencyDestinationSetup> AgencyDestinationSetup { get; set; }
        //public virtual DbSet<AgencyInspectionMaster> AgencyInspectionMaster { get; set; }
        //public virtual DbSet<AgencyInspectionView> AgencyInspectionView { get; set; }
        //public virtual DbSet<AgencyIssuanceView> AgencyIssuanceView { get; set; }
        //public virtual DbSet<AgencyLinkage> AgencyLinkage { get; set; }
        //public virtual DbSet<AgencyOrderWiseReport> AgencyOrderWiseReport { get; set; }
        //public virtual DbSet<AgencyReceivingMaster> AgencyReceivingMaster { get; set; }
        //public virtual DbSet<AgencyReceivingView> AgencyReceivingView { get; set; }
        //public virtual DbSet<AgencyRejectingMaster> AgencyRejectingMaster { get; set; }
        //public virtual DbSet<AgencyStockTransactionDocumentType> AgencyStockTransactionDocumentType { get; set; }
        //public virtual DbSet<AgencyStockTransactions> AgencyStockTransactions { get; set; }
        //public virtual DbSet<AgencyStyleChallanStatus> AgencyStyleChallanStatus { get; set; }
        //public virtual DbSet<AgencyView> AgencyView { get; set; }
        //public virtual DbSet<BarCodeDetail> BarCodeDetail { get; set; }
        //public virtual DbSet<BarCodeDocumentType> BarCodeDocumentType { get; set; }
        //public virtual DbSet<BarcodedetailNotToBeDelted> BarcodedetailNotToBeDelted { get; set; }
        //public virtual DbSet<BcdbackUp> BcdbackUp { get; set; }
        //public virtual DbSet<Bctable> Bctable { get; set; }
        //public virtual DbSet<Bctable1> Bctable1 { get; set; }
        //public virtual DbSet<BundleDetail> BundleDetail { get; set; }
        //public virtual DbSet<BundleDetailFazal> BundleDetailFazal { get; set; }
        //public virtual DbSet<BundleMaster> BundleMaster { get; set; }
        //public virtual DbSet<BundleStatusSetup> BundleStatusSetup { get; set; }
        //public virtual DbSet<BundleTransaction> BundleTransaction { get; set; }
        //public virtual DbSet<CadcambodyPart> CadcambodyPart { get; set; }
        //public virtual DbSet<Cadcamjob> Cadcamjob { get; set; }
        //public virtual DbSet<CadcampatternPiece> CadcampatternPiece { get; set; }
        //public virtual DbSet<CheckDoubleBarcode> CheckDoubleBarcode { get; set; }
        //public virtual DbSet<CmtChallanReceicveMaster> CmtChallanReceicveMaster { get; set; }
        //public virtual DbSet<CmtCompanySetup> CmtCompanySetup { get; set; }
        //public virtual DbSet<CmtCurrencySetup> CmtCurrencySetup { get; set; }
        //public virtual DbSet<CmtFinanceMapping> CmtFinanceMapping { get; set; }
        //public virtual DbSet<CmtModeOfPaymentSetup> CmtModeOfPaymentSetup { get; set; }
        //public virtual DbSet<CmtStockTransaction> CmtStockTransaction { get; set; }
        //public virtual DbSet<CmtStoresSetup> CmtStoresSetup { get; set; }
        //public virtual DbSet<CmtTermsOfPaymentSetup> CmtTermsOfPaymentSetup { get; set; }
        //public virtual DbSet<CmtWoDocumentType> CmtWoDocumentType { get; set; }
        //public virtual DbSet<CmtWochallanMaster> CmtWochallanMaster { get; set; }
        //public virtual DbSet<CmtWorkOrderMaster> CmtWorkOrderMaster { get; set; }
        //public virtual DbSet<ColorName> ColorName { get; set; }
        //public virtual DbSet<CuttingConfirmationDetail> CuttingConfirmationDetail { get; set; }
        //public virtual DbSet<CuttingConfirmationMaster> CuttingConfirmationMaster { get; set; }
        //public virtual DbSet<CuttingImplementation> CuttingImplementation { get; set; }
        //public virtual DbSet<CuttingInspection> CuttingInspection { get; set; }
        //public virtual DbSet<CuttingInspectionDetail> CuttingInspectionDetail { get; set; }
        //public virtual DbSet<CuttingInspectionMaster> CuttingInspectionMaster { get; set; }
        //public virtual DbSet<CuttingLeftOverMaster> CuttingLeftOverMaster { get; set; }
        //public virtual DbSet<CuttingMachineInstance> CuttingMachineInstance { get; set; }
        //public virtual DbSet<CuttingMachineLoad> CuttingMachineLoad { get; set; }
        //public virtual DbSet<CuttingMachineType> CuttingMachineType { get; set; }
        //public virtual DbSet<CuttingOperation> CuttingOperation { get; set; }
        //public virtual DbSet<DailyCuttingReportComments> DailyCuttingReportComments { get; set; }
        //public virtual DbSet<DefectCategory> DefectCategory { get; set; }
        //public virtual DbSet<DefectLevel1> DefectLevel1 { get; set; }
        //public virtual DbSet<DefectLevel2> DefectLevel2 { get; set; }
        //public virtual DbSet<DefectLevel3> DefectLevel3 { get; set; }
        //public virtual DbSet<DefectLevel4> DefectLevel4 { get; set; }
        //public virtual DbSet<DefectLevel5> DefectLevel5 { get; set; }
        //public virtual DbSet<DefectSetup> DefectSetup { get; set; }
        //public virtual DbSet<DfsConfirmationMaster> DfsConfirmationMaster { get; set; }
        //public virtual DbSet<DfsDcassociationforLot> DfsDcassociationforLot { get; set; }
        //public virtual DbSet<DfsDocumentTypeSetup> DfsDocumentTypeSetup { get; set; }
        //public virtual DbSet<DfsInspectionApproval> DfsInspectionApproval { get; set; }
        //public virtual DbSet<DfsInspectionApprovalDetail> DfsInspectionApprovalDetail { get; set; }
        //public virtual DbSet<DfsInspectionMaster> DfsInspectionMaster { get; set; }
        //public virtual DbSet<DfsInspectionNewAttributeSetup> DfsInspectionNewAttributeSetup { get; set; }
        //public virtual DbSet<DfsIssuanceDetail> DfsIssuanceDetail { get; set; }

        //public virtual DbSet<DfsLotApproval> DfsLotApproval { get; set; }
        //public virtual DbSet<DfsLotHistoryDestinationDetail> DfsLotHistoryDestinationDetail { get; set; }
        //public virtual DbSet<DfsLotHistoryDestinationDetailBeforeChange> DfsLotHistoryDestinationDetailBeforeChange { get; set; }
        //public virtual DbSet<DfsLotHistoryDestinationMaster> DfsLotHistoryDestinationMaster { get; set; }
        //public virtual DbSet<DfsLotHistorySetup> DfsLotHistorySetup { get; set; }
        //public virtual DbSet<DfsLotHistorySourceDetail> DfsLotHistorySourceDetail { get; set; }
        //public virtual DbSet<DfsLotHistorySourceDetailBeforeChange> DfsLotHistorySourceDetailBeforeChange { get; set; }
        //public virtual DbSet<DfsLotHistorySourceMaster> DfsLotHistorySourceMaster { get; set; }
        //public virtual DbSet<DfsLotHistorySuperMaster> DfsLotHistorySuperMaster { get; set; }
        //public virtual DbSet<DfsLotMachineRouting> DfsLotMachineRouting { get; set; }
        //public virtual DbSet<DfsLotMakingMaster> DfsLotMakingMaster { get; set; }
        //public virtual DbSet<DfsLotMakingMasterRedyeing> DfsLotMakingMasterRedyeing { get; set; }
        //public virtual DbSet<DfsMachineSetup> DfsMachineSetup { get; set; }
        //public virtual DbSet<DfsReDyeingConfirmationMaster> DfsReDyeingConfirmationMaster { get; set; }
        //public virtual DbSet<DfsReceivingMaster> DfsReceivingMaster { get; set; }
        //public virtual DbSet<DfsReturnRolls> DfsReturnRolls { get; set; }
        //public virtual DbSet<DfsRollInspectionAttribute> DfsRollInspectionAttribute { get; set; }
        //public virtual DbSet<DfsStockTransaction> DfsStockTransaction { get; set; }
        //public virtual DbSet<DfsStockTransactionBk22may2016> DfsStockTransactionBk22may2016 { get; set; }
        //public virtual DbSet<DfsStockTransactionDeleteLog> DfsStockTransactionDeleteLog { get; set; }
        //public virtual DbSet<DfsWoIssuanceMaster> DfsWoIssuanceMaster { get; set; }
        //public virtual DbSet<DfsWoinspectionMaster> DfsWoinspectionMaster { get; set; }
        //public virtual DbSet<DfsWoinspectionNewAttributeSetup> DfsWoinspectionNewAttributeSetup { get; set; }
        //public virtual DbSet<DfsWorkOrderRecevingMaster> DfsWorkOrderRecevingMaster { get; set; }
        //public virtual DbSet<DivisionSetup> DivisionSetup { get; set; }
        //public virtual DbSet<DocumentType> DocumentType { get; set; }
        //public virtual DbSet<EmbroideryInspectionDetails> EmbroideryInspectionDetails { get; set; }
        //public virtual DbSet<EmbroideryInspectionMaster> EmbroideryInspectionMaster { get; set; }
        //public virtual DbSet<EmbroideryIssuanceDetail> EmbroideryIssuanceDetail { get; set; }
        //public virtual DbSet<EmbroideryIssuanceMaster> EmbroideryIssuanceMaster { get; set; }
        //public virtual DbSet<EmbroideryReceivingDetail> EmbroideryReceivingDetail { get; set; }
        //public virtual DbSet<EmbroideryReceivingMaster> EmbroideryReceivingMaster { get; set; }
        //public virtual DbSet<ErpCalendarDetail> ErpCalendarDetail { get; set; }
        //public virtual DbSet<FabricIrdetail> FabricIrdetail { get; set; }
        //public virtual DbSet<FabricIrmaster> FabricIrmaster { get; set; }
        //public virtual DbSet<FinishingConfirmation> FinishingConfirmation { get; set; }
        //public virtual DbSet<FlDocumentTypeSetup> FlDocumentTypeSetup { get; set; }
        //public virtual DbSet<FlStockTransaction> FlStockTransaction { get; set; }
        //public virtual DbSet<Flow2Jugar> Flow2Jugar { get; set; }
        //public virtual DbSet<FlowBundleDetail> FlowBundleDetail { get; set; }
        //public virtual DbSet<FlowBundleMaster> FlowBundleMaster { get; set; }
        //public virtual DbSet<FlowIssuanceView> FlowIssuanceView { get; set; }
        //public virtual DbSet<FlowReceivingView> FlowReceivingView { get; set; }
        //public virtual DbSet<FsBundleCartDetail> FsBundleCartDetail { get; set; }
        //public virtual DbSet<FsBundleCartMaster> FsBundleCartMaster { get; set; }
        //public virtual DbSet<FsChallanStatusSetup> FsChallanStatusSetup { get; set; }
        //public virtual DbSet<FsDocumentTypeSetup> FsDocumentTypeSetup { get; set; }
        //public virtual DbSet<FsFabricMrpitemCode> FsFabricMrpitemCode { get; set; }
        //public virtual DbSet<FsFabricShapedPieces> FsFabricShapedPieces { get; set; }
        //public virtual DbSet<FsHoldingDetail> FsHoldingDetail { get; set; }
        //public virtual DbSet<FsHoldingMaster> FsHoldingMaster { get; set; }
        //public virtual DbSet<FsIssuanceMaster> FsIssuanceMaster { get; set; }
        //public virtual DbSet<FsMiratHand> FsMiratHand { get; set; }
        //public virtual DbSet<FsReceivingMaster> FsReceivingMaster { get; set; }
        //public virtual DbSet<FsRejectionRepository> FsRejectionRepository { get; set; }
        //public virtual DbSet<FsRejectionRepositoryBalancingQty> FsRejectionRepositoryBalancingQty { get; set; }
        //public virtual DbSet<FsRejectionRepositoryDetail> FsRejectionRepositoryDetail { get; set; }
        //public virtual DbSet<FsRejectionRepositoryReqSheetQty> FsRejectionRepositoryReqSheetQty { get; set; }
        //public virtual DbSet<FsRejectionRepositoryStockLotQty> FsRejectionRepositoryStockLotQty { get; set; }
        //public virtual DbSet<FsRejectionReqSheetMaster> FsRejectionReqSheetMaster { get; set; }
        //public virtual DbSet<FsRejectionSerialDetails> FsRejectionSerialDetails { get; set; }
        //public virtual DbSet<FsRgdAssociatedQty> FsRgdAssociatedQty { get; set; }
        //public virtual DbSet<FsStitchingDetail> FsStitchingDetail { get; set; }
        //public virtual DbSet<FsStitchingMaster> FsStitchingMaster { get; set; }
        //public virtual DbSet<FsStockTransaction> FsStockTransaction { get; set; }
        //public virtual DbSet<FsTicketStatus> FsTicketStatus { get; set; }
        //public virtual DbSet<IdentificationSetup> IdentificationSetup { get; set; }
        //public virtual DbSet<InpectionDepartment> InpectionDepartment { get; set; }
        //public virtual DbSet<InpectionParameterDepartment> InpectionParameterDepartment { get; set; }
        //public virtual DbSet<InspectionParameter> InspectionParameter { get; set; }
        //public virtual DbSet<IssuanceDetail> IssuanceDetail { get; set; }
        //public virtual DbSet<IssuanceMaster> IssuanceMaster { get; set; }
        //public virtual DbSet<JobStatus> JobStatus { get; set; }
        //public virtual DbSet<JobTicket> JobTicket { get; set; }
        //public virtual DbSet<KnittingCreatedJobsDeleteLog> KnittingCreatedJobsDeleteLog { get; set; }
        //public virtual DbSet<KnittingIssuanceDeleteLog> KnittingIssuanceDeleteLog { get; set; }
        //public virtual DbSet<KnittingMachineJobsDeleteLog> KnittingMachineJobsDeleteLog { get; set; }
        //public virtual DbSet<KnittingNeedleBreakage> KnittingNeedleBreakage { get; set; }
        //public virtual DbSet<KnittingNeedleBreakage1> KnittingNeedleBreakage1 { get; set; }
        //public virtual DbSet<KnittingPickListDeleteLog> KnittingPickListDeleteLog { get; set; }
        //public virtual DbSet<KnittingRollAttributesDeleteLog> KnittingRollAttributesDeleteLog { get; set; }
        //public virtual DbSet<KnittingRollsInspectionDeleteLog> KnittingRollsInspectionDeleteLog { get; set; }
        //public virtual DbSet<KnittingStockTransactionDeleteLog> KnittingStockTransactionDeleteLog { get; set; }
        //public virtual DbSet<KnittingSubPickListDeleteLog> KnittingSubPickListDeleteLog { get; set; }
        //public virtual DbSet<KnittingYarnAssignmentDeleteLog> KnittingYarnAssignmentDeleteLog { get; set; }
        //public virtual DbSet<MachineOperation> MachineOperation { get; set; }
        //public virtual DbSet<Mar2016BlockList> Mar2016BlockList { get; set; }
        //public virtual DbSet<Matched> Matched { get; set; }
        //public virtual DbSet<MinuteTime> MinuteTime { get; set; }
        //public virtual DbSet<MinuteType> MinuteType { get; set; }
        //public virtual DbSet<MyTable> MyTable { get; set; }
        //public virtual DbSet<PpSpare> PpSpare { get; set; }
        //public virtual DbSet<PrintingInspectionDetails> PrintingInspectionDetails { get; set; }
        //public virtual DbSet<PrintingInspectionMaster> PrintingInspectionMaster { get; set; }
        //public virtual DbSet<PrintingIssuanceDetail> PrintingIssuanceDetail { get; set; }
        //public virtual DbSet<PrintingIssuanceMaster> PrintingIssuanceMaster { get; set; }
        //public virtual DbSet<PrintingReceivingDetail> PrintingReceivingDetail { get; set; }
        //public virtual DbSet<PrintingReceivingMaster> PrintingReceivingMaster { get; set; }
        //public virtual DbSet<RangeCalculation> RangeCalculation { get; set; }
        //public virtual DbSet<ReceivingDetail> ReceivingDetail { get; set; }
        //public virtual DbSet<ReceivingMaster> ReceivingMaster { get; set; }
        //public virtual DbSet<ResourceGroup> ResourceGroup { get; set; }
        //public virtual DbSet<ResourceState> ResourceState { get; set; }
        //public virtual DbSet<Rework> Rework { get; set; }
        //public virtual DbSet<RollDefectDetail> RollDefectDetail { get; set; }
        //public virtual DbSet<RollTrack> RollTrack { get; set; }
        //public virtual DbSet<SfsAuditDetail> SfsAuditDetail { get; set; }
        //public virtual DbSet<SfsAuditGarmentStatusSetup> SfsAuditGarmentStatusSetup { get; set; }
        //public virtual DbSet<SfsAuditMaster> SfsAuditMaster { get; set; }
        //public virtual DbSet<SfsBayHeadSetup> SfsBayHeadSetup { get; set; }
        //public virtual DbSet<SfsConfirmationNauditAssociation> SfsConfirmationNauditAssociation { get; set; }
        //public virtual DbSet<SfsCpsLoad> SfsCpsLoad { get; set; }
        //public virtual DbSet<SfsCpsLoadHistory> SfsCpsLoadHistory { get; set; }
        //public virtual DbSet<SfsDocumentType> SfsDocumentType { get; set; }
        //public virtual DbSet<SfsEmpOfflineAllocationMaster> SfsEmpOfflineAllocationMaster { get; set; }
        //public virtual DbSet<SfsEmpOfflineDetail> SfsEmpOfflineDetail { get; set; }
        //public virtual DbSet<SfsEmployeeLineAllocation> SfsEmployeeLineAllocation { get; set; }
        //public virtual DbSet<SfsEmployeeLineAllocationDetail> SfsEmployeeLineAllocationDetail { get; set; }
        //public virtual DbSet<SfsInspection> SfsInspection { get; set; }
        //public virtual DbSet<SfsInspectionDefect> SfsInspectionDefect { get; set; }
        //public virtual DbSet<SfsInspectionDefectDetail> SfsInspectionDefectDetail { get; set; }
        //public virtual DbSet<SfsInspectionMaster> SfsInspectionMaster { get; set; }
        //public virtual DbSet<SfsIssuanceMaster> SfsIssuanceMaster { get; set; }
        //public virtual DbSet<SfsIssuanceView> SfsIssuanceView { get; set; }
        //public virtual DbSet<SfsJob> SfsJob { get; set; }
        //public virtual DbSet<SfsJobBackupTable> SfsJobBackupTable { get; set; }
        //public virtual DbSet<SfsJobConfirmation> SfsJobConfirmation { get; set; }
        //public virtual DbSet<SfsJobDetail> SfsJobDetail { get; set; }
        //public virtual DbSet<SfsJobHistory> SfsJobHistory { get; set; }
        //public virtual DbSet<SfsJobResource> SfsJobResource { get; set; }
        //public virtual DbSet<SfsJobStatus> SfsJobStatus { get; set; }
        //public virtual DbSet<SfsLayoutRequisition> SfsLayoutRequisition { get; set; }
        //public virtual DbSet<SfsLoads> SfsLoads { get; set; }
        //public virtual DbSet<SfsLoadsBackup> SfsLoadsBackup { get; set; }
        //public virtual DbSet<SfsMachineResourceStatus> SfsMachineResourceStatus { get; set; }
        //public virtual DbSet<SfsMachineResources> SfsMachineResources { get; set; }
        //public virtual DbSet<SfsPickListDetail> SfsPickListDetail { get; set; }
        //public virtual DbSet<SfsPickListMaster> SfsPickListMaster { get; set; }
        //public virtual DbSet<SfsPickListStatus> SfsPickListStatus { get; set; }
        //public virtual DbSet<SfsProductionResourceRelations> SfsProductionResourceRelations { get; set; }
        //public virtual DbSet<SfsProductionResourceSpecification> SfsProductionResourceSpecification { get; set; }
        //public virtual DbSet<SfsProductionResourceType> SfsProductionResourceType { get; set; }
        //public virtual DbSet<SfsPrselectedBuyers> SfsPrselectedBuyers { get; set; }
        //public virtual DbSet<SfsPrselectedFabricType> SfsPrselectedFabricType { get; set; }
        //public virtual DbSet<SfsPrselectedGarmentCategory> SfsPrselectedGarmentCategory { get; set; }
        //public virtual DbSet<SfsPrselectedGarmentType> SfsPrselectedGarmentType { get; set; }
        //public virtual DbSet<SfsPslog> SfsPslog { get; set; }
        //public virtual DbSet<SfsReplannedJobDetail> SfsReplannedJobDetail { get; set; }
        //public virtual DbSet<SfsReworkBacodes> SfsReworkBacodes { get; set; }
        //public virtual DbSet<SfsReworkConfirmation> SfsReworkConfirmation { get; set; }
        //public virtual DbSet<SfsReworkConfirmationDetail> SfsReworkConfirmationDetail { get; set; }
        //public virtual DbSet<SfsStockTransaction> SfsStockTransaction { get; set; }
        //public virtual DbSet<SfsStockTransactionBackupNotTobeDeleted> SfsStockTransactionBackupNotTobeDeleted { get; set; }
        //public virtual DbSet<ShipmentLock> ShipmentLock { get; set; }
        ////public virtual DbSet<Single> Single { get; set; }
        //public virtual DbSet<SizeRange> SizeRange { get; set; }
        //public virtual DbSet<SpreaderInstance> SpreaderInstance { get; set; }
        //public virtual DbSet<SpreaderLoad> SpreaderLoad { get; set; }
        //public virtual DbSet<SpreaderMachineType> SpreaderMachineType { get; set; }
        //public virtual DbSet<SpreadingLeadTime> SpreadingLeadTime { get; set; }
        //public virtual DbSet<StitchingRec> StitchingRec { get; set; }
        //public virtual DbSet<StitchingRecView> StitchingRecView { get; set; }
        //public virtual DbSet<StyleInfo> StyleInfo { get; set; }
        //public virtual DbSet<StylePatternPiece> StylePatternPiece { get; set; }
        //public virtual DbSet<TableLoad> TableLoad { get; set; }
        //public virtual DbSet<Tables> Tables { get; set; }
        //public virtual DbSet<TblAgency> TblAgency { get; set; }
        //public virtual DbSet<TblAgencyTransComments> TblAgencyTransComments { get; set; }
        //public virtual DbSet<TblAgencyTransDetail> TblAgencyTransDetail { get; set; }
        //public virtual DbSet<TblAgencyTransMaster> TblAgencyTransMaster { get; set; }
        //public virtual DbSet<TblAgencyTransactions> TblAgencyTransactions { get; set; }
        //public virtual DbSet<TblBonus> TblBonus { get; set; }
        //public virtual DbSet<TblBundleBarcodeTrack> TblBundleBarcodeTrack { get; set; }
        //public virtual DbSet<TblCutoffDetails> TblCutoffDetails { get; set; }
        //public virtual DbSet<TblCutoffentryMaster> TblCutoffentryMaster { get; set; }
        //public virtual DbSet<TblCutting60> TblCutting60 { get; set; }
        //public virtual DbSet<TblCuttingDefects> TblCuttingDefects { get; set; }
        //public virtual DbSet<TblCuttingInputTransfer> TblCuttingInputTransfer { get; set; }
        //public virtual DbSet<TblCuttingPartDefects> TblCuttingPartDefects { get; set; }
        //public virtual DbSet<TblCuttingPartOk> TblCuttingPartOk { get; set; }
        //public virtual DbSet<TblCuttingSticker> TblCuttingSticker { get; set; }
        //public virtual DbSet<TblCuttingStickerBundle> TblCuttingStickerBundle { get; set; }
        //public virtual DbSet<TblCuttingStickerBundleMaster> TblCuttingStickerBundleMaster { get; set; }
        //public virtual DbSet<TblCuttingStickerMaster> TblCuttingStickerMaster { get; set; }
        //public virtual DbSet<TblCuttingWeight> TblCuttingWeight { get; set; }
        //public virtual DbSet<TblDailyCuttingReportTable> TblDailyCuttingReportTable { get; set; }
        //public virtual DbSet<TblDefects> TblDefects { get; set; }
        //public virtual DbSet<TblDyeing60> TblDyeing60 { get; set; }
        //public virtual DbSet<TblDyeing602> TblDyeing602 { get; set; }
        //public virtual DbSet<TblDyeingCategory> TblDyeingCategory { get; set; }
        //public virtual DbSet<TblDyeingDefects> TblDyeingDefects { get; set; }
        //public virtual DbSet<TblDyeingDefectsCatagory> TblDyeingDefectsCatagory { get; set; }
        //public virtual DbSet<TblDyeingLosttime> TblDyeingLosttime { get; set; }
        //public virtual DbSet<TblDyeingLosttimeR> TblDyeingLosttimeR { get; set; }
        //public virtual DbSet<TblDyeingMachine> TblDyeingMachine { get; set; }
        //public virtual DbSet<TblDyeingRolldefects> TblDyeingRolldefects { get; set; }
        //public virtual DbSet<TblDyeingRollinspaction> TblDyeingRollinspaction { get; set; }
        //public virtual DbSet<TblDyeingTime> TblDyeingTime { get; set; }
        //public virtual DbSet<TblDyeingTimeSplit> TblDyeingTimeSplit { get; set; }
        //public virtual DbSet<TblDyeingType> TblDyeingType { get; set; }
        //public virtual DbSet<TblDyeingWG> TblDyeingWG { get; set; }
        //public virtual DbSet<TblDyeingWGStatus> TblDyeingWGStatus { get; set; }
        //public virtual DbSet<TblFam> TblFam { get; set; }
        //public virtual DbSet<TblFinishFabricLog> TblFinishFabricLog { get; set; }
        //public virtual DbSet<TblFloor> TblFloor { get; set; }
        //public virtual DbSet<TblGarmentsTypes> TblGarmentsTypes { get; set; }
        //public virtual DbSet<TblGateKnittingRolls> TblGateKnittingRolls { get; set; }
        //public virtual DbSet<TblKnittingAttributeSetup> TblKnittingAttributeSetup { get; set; }
        //public virtual DbSet<TblKnittingDayMinuteTime> TblKnittingDayMinuteTime { get; set; }
        //public virtual DbSet<TblKnittingDocumentTypeSetup> TblKnittingDocumentTypeSetup { get; set; }
        //public virtual DbSet<TblKnittingEfficiencyArchive> TblKnittingEfficiencyArchive { get; set; }
        //public virtual DbSet<TblKnittingFabricProcessAssociation> TblKnittingFabricProcessAssociation { get; set; }
        //public virtual DbSet<TblKnittingFabricSpecification> TblKnittingFabricSpecification { get; set; }
        //public virtual DbSet<TblKnittingGate> TblKnittingGate { get; set; }
        //public virtual DbSet<TblKnittingInspectionMaster> TblKnittingInspectionMaster { get; set; }
        //public virtual DbSet<TblKnittingInspectionRejection> TblKnittingInspectionRejection { get; set; }
        //public virtual DbSet<TblKnittingIssuanceMaster> TblKnittingIssuanceMaster { get; set; }
        //public virtual DbSet<TblKnittingJobConfirmation> TblKnittingJobConfirmation { get; set; }
        //public virtual DbSet<TblKnittingJobStatus> TblKnittingJobStatus { get; set; }
        //public virtual DbSet<TblKnittingJobs> TblKnittingJobs { get; set; }
        //public virtual DbSet<TblKnittingJobsOld> TblKnittingJobsOld { get; set; }
        //public virtual DbSet<TblKnittingLaboratoryInspection> TblKnittingLaboratoryInspection { get; set; }
        //public virtual DbSet<TblKnittingLoads> TblKnittingLoads { get; set; }
        //public virtual DbSet<TblKnittingMachineLeadTime> TblKnittingMachineLeadTime { get; set; }
        //public virtual DbSet<TblKnittingMachines> TblKnittingMachines { get; set; }
        //public virtual DbSet<TblKnittingMachinesLog> TblKnittingMachinesLog { get; set; }
        //public virtual DbSet<TblKnittingMinuteTime> TblKnittingMinuteTime { get; set; }
        //public virtual DbSet<TblKnittingPickListDetail> TblKnittingPickListDetail { get; set; }
        //public virtual DbSet<TblKnittingPickListMaster> TblKnittingPickListMaster { get; set; }
        //public virtual DbSet<TblKnittingPickListRejection> TblKnittingPickListRejection { get; set; }
        //public virtual DbSet<TblKnittingRolls> TblKnittingRolls { get; set; }
        //public virtual DbSet<TblKnittingRollsAttributeSetup> TblKnittingRollsAttributeSetup { get; set; }
        //public virtual DbSet<TblKnittingRollsQualitySetup> TblKnittingRollsQualitySetup { get; set; }
        //public virtual DbSet<TblKnittingRollsRollAttributes> TblKnittingRollsRollAttributes { get; set; }
        //public virtual DbSet<TblKnittingStockTransaction> TblKnittingStockTransaction { get; set; }
        //public virtual DbSet<TblKnittingStockTransaction27thMar2014> TblKnittingStockTransaction27thMar2014 { get; set; }
        //public virtual DbSet<TblKnittingSubPickListDetail> TblKnittingSubPickListDetail { get; set; }
        //public virtual DbSet<TblKnittingSubPickListMaster> TblKnittingSubPickListMaster { get; set; }
        //public virtual DbSet<TblKnittingSubPickListRejection> TblKnittingSubPickListRejection { get; set; }
        //public virtual DbSet<TblKnittingWorkOrderMaster> TblKnittingWorkOrderMaster { get; set; }
        //public virtual DbSet<TblKnittingYarnAssignment> TblKnittingYarnAssignment { get; set; }
        //public virtual DbSet<TblKnittingYarnReturnDetail> TblKnittingYarnReturnDetail { get; set; }
        //public virtual DbSet<TblKnittingYarnReturnMaster> TblKnittingYarnReturnMaster { get; set; }
        //public virtual DbSet<TblLayoutDetailes> TblLayoutDetailes { get; set; }
        //public virtual DbSet<TblLayoutEmpProductionEntry> TblLayoutEmpProductionEntry { get; set; }
        //public virtual DbSet<TblLayoutLine> TblLayoutLine { get; set; }
        //public virtual DbSet<TblLayoutMaster> TblLayoutMaster { get; set; }
        //public virtual DbSet<TblLayoutProcess> TblLayoutProcess { get; set; }
        //public virtual DbSet<TblLayoutRemarks> TblLayoutRemarks { get; set; }
        //public virtual DbSet<TblLocation> TblLocation { get; set; }
        //public virtual DbSet<TblLostTime> TblLostTime { get; set; }
        //public virtual DbSet<TblLosttype> TblLosttype { get; set; }
        //public virtual DbSet<TblLotStatus> TblLotStatus { get; set; }
        //public virtual DbSet<TblLotStatusWGBuyer> TblLotStatusWGBuyer { get; set; }
        //public virtual DbSet<TblMachineCategory> TblMachineCategory { get; set; }
        //public virtual DbSet<TblMachineRod> TblMachineRod { get; set; }
        //public virtual DbSet<TblMachineTypeSetup> TblMachineTypeSetup { get; set; }
        //public virtual DbSet<TblMachines> TblMachines { get; set; }
        //public virtual DbSet<TblMarkerConsInfo> TblMarkerConsInfo { get; set; }
        //public virtual DbSet<TblMarkerCreate> TblMarkerCreate { get; set; }
        //public virtual DbSet<TblMarkerFromPrint> TblMarkerFromPrint { get; set; }
        //public virtual DbSet<TblMarkerInfo> TblMarkerInfo { get; set; }
        //public virtual DbSet<TblMarkerInputAccessInfo> TblMarkerInputAccessInfo { get; set; }
        //public virtual DbSet<TblMarkerInputConfirm> TblMarkerInputConfirm { get; set; }
        //public virtual DbSet<TblMarkerInputDetails> TblMarkerInputDetails { get; set; }
        //public virtual DbSet<TblMarkerInputInfo> TblMarkerInputInfo { get; set; }
        //public virtual DbSet<TblMarkerPartDetails> TblMarkerPartDetails { get; set; }
        //public virtual DbSet<TblMarkerPartMaster> TblMarkerPartMaster { get; set; }
        //public virtual DbSet<TblMarkerRadioDetailes> TblMarkerRadioDetailes { get; set; }
        //public virtual DbSet<TblMarkerRadioMaster> TblMarkerRadioMaster { get; set; }
        //public virtual DbSet<TblMarkerRoll> TblMarkerRoll { get; set; }
        //public virtual DbSet<TblMarkerShortCutting> TblMarkerShortCutting { get; set; }
        //public virtual DbSet<TblMarkerSize> TblMarkerSize { get; set; }
        //public virtual DbSet<TblMonthDays> TblMonthDays { get; set; }
        //public virtual DbSet<TblOperations> TblOperations { get; set; }
        //public virtual DbSet<TblPendinglotNotificationComments> TblPendinglotNotificationComments { get; set; }
        //public virtual DbSet<TblProblem> TblProblem { get; set; }
        //public virtual DbSet<TblRollDefects> TblRollDefects { get; set; }
        //public virtual DbSet<TblRollDefectsLog> TblRollDefectsLog { get; set; }
        //public virtual DbSet<TblRollEditLog> TblRollEditLog { get; set; }
        //public virtual DbSet<TblShortSizeQty> TblShortSizeQty { get; set; }
        //public virtual DbSet<TblTempCutToPack> TblTempCutToPack { get; set; }
        //public virtual DbSet<TblTempCutToPackNew> TblTempCutToPackNew { get; set; }
        //public virtual DbSet<TblTempCutToPackStylewise> TblTempCutToPackStylewise { get; set; }
        //public virtual DbSet<TblTempFlow2Transaction> TblTempFlow2Transaction { get; set; }
        //public virtual DbSet<TblTempFlowReport> TblTempFlowReport { get; set; }
        //public virtual DbSet<TblTempFlowTransaction> TblTempFlowTransaction { get; set; }
        //public virtual DbSet<TblTempRoll> TblTempRoll { get; set; }
        //public virtual DbSet<TblYarnTypeDet> TblYarnTypeDet { get; set; }
        //public virtual DbSet<TblYarntype> TblYarntype { get; set; }
        //public virtual DbSet<TempWashingChemicals> TempWashingChemicals { get; set; }
        //public virtual DbSet<TempWashingDyes> TempWashingDyes { get; set; }
        //public virtual DbSet<TempWashingItemsList> TempWashingItemsList { get; set; }
        //public virtual DbSet<TempWashingOfficinaChemicals> TempWashingOfficinaChemicals { get; set; }
        //public virtual DbSet<TempWashingOfficinaDyes> TempWashingOfficinaDyes { get; set; }
        //public virtual DbSet<TemporaryBarCode> TemporaryBarCode { get; set; }
        //public virtual DbSet<Tkci> Tkci { get; set; }
        //public virtual DbSet<Trace> Trace { get; set; }
        //public virtual DbSet<Upomsewing> Upomsewing { get; set; }
        //public virtual DbSet<Upomsewing1> Upomsewing1 { get; set; }
        //public virtual DbSet<UpomsewingBk02Jan2016> UpomsewingBk02Jan2016 { get; set; }
        //public virtual DbSet<VAgencyColorwiseTrack> VAgencyColorwiseTrack { get; set; }
        //public virtual DbSet<VAgencyWorkCenterLink> VAgencyWorkCenterLink { get; set; }
        //public virtual DbSet<VBarcodeTest> VBarcodeTest { get; set; }
        //public virtual DbSet<VBarcodeTraceModelwise> VBarcodeTraceModelwise { get; set; }
        //public virtual DbSet<VBundleInfo> VBundleInfo { get; set; }
        //public virtual DbSet<VBundleMasterDetail> VBundleMasterDetail { get; set; }
        //public virtual DbSet<VChkQty> VChkQty { get; set; }
        //public virtual DbSet<VCmtFinder> VCmtFinder { get; set; }
        //public virtual DbSet<VColorSizeWiseAgency> VColorSizeWiseAgency { get; set; }
        //public virtual DbSet<VDetailAgency> VDetailAgency { get; set; }
        //public virtual DbSet<VErrorAgencyColor> VErrorAgencyColor { get; set; }
        //public virtual DbSet<VErrorAgencyPartialId> VErrorAgencyPartialId { get; set; }
        //public virtual DbSet<VStyleColorSize> VStyleColorSize { get; set; }
        //public virtual DbSet<VTest> VTest { get; set; }
        //public virtual DbSet<VacumTable> VacumTable { get; set; }
        //public virtual DbSet<View1> View1 { get; set; }
        //public virtual DbSet<VwMinMaxStitDate> VwMinMaxStitDate { get; set; }
        //public virtual DbSet<WashingActivity> WashingActivity { get; set; }
        //public virtual DbSet<WashingActivityProcess> WashingActivityProcess { get; set; }
        //public virtual DbSet<WashingCollectionRecipeSetupMaster> WashingCollectionRecipeSetupMaster { get; set; }
        //public virtual DbSet<WashingCollectionRecipeSetupMaterial> WashingCollectionRecipeSetupMaterial { get; set; }
        //public virtual DbSet<WashingCollectionRecipeSetupProcess> WashingCollectionRecipeSetupProcess { get; set; }
        //public virtual DbSet<WashingCollectionRecipeSetupRpmrange> WashingCollectionRecipeSetupRpmrange { get; set; }
        //public virtual DbSet<WashingCollectionRecipeSetupTemperatureRange> WashingCollectionRecipeSetupTemperatureRange { get; set; }
        //public virtual DbSet<WashingExecutionPlanMaster> WashingExecutionPlanMaster { get; set; }
        //public virtual DbSet<WashingExecutionPlanStage> WashingExecutionPlanStage { get; set; }
        //public virtual DbSet<WashingExecutionPlanStageLot> WashingExecutionPlanStageLot { get; set; }
        //public virtual DbSet<WashingExecutionPlanStageLotBom> WashingExecutionPlanStageLotBom { get; set; }
        //public virtual DbSet<WashingExecutionPlanStageProcess> WashingExecutionPlanStageProcess { get; set; }
        //public virtual DbSet<WashingItemDetail> WashingItemDetail { get; set; }
        //public virtual DbSet<WashingItemDetail1> WashingItemDetail1 { get; set; }
        //public virtual DbSet<WashingItemMaster> WashingItemMaster { get; set; }
        //public virtual DbSet<WashingItemUnits> WashingItemUnits { get; set; }
        //public virtual DbSet<WashingLotDetail> WashingLotDetail { get; set; }
        //public virtual DbSet<WashingLotExecution> WashingLotExecution { get; set; }
        //public virtual DbSet<WashingLotMaster> WashingLotMaster { get; set; }
        //public virtual DbSet<WashingLotStageDetail> WashingLotStageDetail { get; set; }
        //public virtual DbSet<WashingLotStageMaster> WashingLotStageMaster { get; set; }
        //public virtual DbSet<WashingLotToppingDetail> WashingLotToppingDetail { get; set; }
        //public virtual DbSet<WashingLotToppingMaster> WashingLotToppingMaster { get; set; }
        //public virtual DbSet<WashingMachineSetup> WashingMachineSetup { get; set; }
        //public virtual DbSet<WashingMachineStatusSetup> WashingMachineStatusSetup { get; set; }
        //public virtual DbSet<WashingMachineTypeAssociationProcessCode> WashingMachineTypeAssociationProcessCode { get; set; }
        //public virtual DbSet<WashingMachineTypeSetup> WashingMachineTypeSetup { get; set; }
        //public virtual DbSet<WashingMachineTypeToProcessAssociationDetail> WashingMachineTypeToProcessAssociationDetail { get; set; }
        //public virtual DbSet<WashingMachineTypeToProcessAssociationMaster> WashingMachineTypeToProcessAssociationMaster { get; set; }
        //public virtual DbSet<WashingMaterialSetup> WashingMaterialSetup { get; set; }
        //public virtual DbSet<WashingMaterialSetup1> WashingMaterialSetup1 { get; set; }
        //public virtual DbSet<WashingMaterialTypeSetup> WashingMaterialTypeSetup { get; set; }
        //public virtual DbSet<WashingMaterialTypeToItemAssociationDetail> WashingMaterialTypeToItemAssociationDetail { get; set; }
        //public virtual DbSet<WashingMaterialTypeToItemAssociationMaster> WashingMaterialTypeToItemAssociationMaster { get; set; }
        //public virtual DbSet<WashingMaterialTypeToProcessAssociationDetail> WashingMaterialTypeToProcessAssociationDetail { get; set; }
        //public virtual DbSet<WashingMaterialTypeToProcessAssociationDetail1> WashingMaterialTypeToProcessAssociationDetail1 { get; set; }
        //public virtual DbSet<WashingMaterialTypeToProcessAssociationMaster> WashingMaterialTypeToProcessAssociationMaster { get; set; }
        //public virtual DbSet<WashingProcessCodeSetup> WashingProcessCodeSetup { get; set; }
        //public virtual DbSet<WashingProcessCodeSetupBk> WashingProcessCodeSetupBk { get; set; }
        //public virtual DbSet<WashingProcessSequence> WashingProcessSequence { get; set; }
        //public virtual DbSet<WashingRecipeOptionsToProcessAssociationDetail> WashingRecipeOptionsToProcessAssociationDetail { get; set; }
        //public virtual DbSet<WashingRecipeOptionsToProcessAssociationMaster> WashingRecipeOptionsToProcessAssociationMaster { get; set; }
        //public virtual DbSet<WashingRecipeSetupMaster> WashingRecipeSetupMaster { get; set; }
        //public virtual DbSet<WashingRecipeSetupMaterial> WashingRecipeSetupMaterial { get; set; }
        //public virtual DbSet<WashingRecipeSetupMaterialSubstitution> WashingRecipeSetupMaterialSubstitution { get; set; }
        //public virtual DbSet<WashingRecipeSetupProcess> WashingRecipeSetupProcess { get; set; }
        //public virtual DbSet<WashingRecipeSetupRpmrange> WashingRecipeSetupRpmrange { get; set; }
        //public virtual DbSet<WashingRecipeSetupTemperatureRange> WashingRecipeSetupTemperatureRange { get; set; }
        //public virtual DbSet<WashingRecipeStage> WashingRecipeStage { get; set; }
        //public virtual DbSet<WashingRecipeStageProcessAssociation> WashingRecipeStageProcessAssociation { get; set; }
        //public virtual DbSet<WashingRecipeToStyleAssociation> WashingRecipeToStyleAssociation { get; set; }
        //public virtual DbSet<WashingRecipeTypeToProcessAssociationDetail> WashingRecipeTypeToProcessAssociationDetail { get; set; }
        //public virtual DbSet<WashingRecipeTypeToProcessAssociationMaster> WashingRecipeTypeToProcessAssociationMaster { get; set; }
        //public virtual DbSet<WashingSampleRecipeSetupDetail> WashingSampleRecipeSetupDetail { get; set; }
        //public virtual DbSet<WashingSampleRecipeSetupMaster> WashingSampleRecipeSetupMaster { get; set; }
        //public virtual DbSet<WashingSampleRecipeSetupRpmrange> WashingSampleRecipeSetupRpmrange { get; set; }
        //public virtual DbSet<WashingSampleRecipeSetupTemperatureRange> WashingSampleRecipeSetupTemperatureRange { get; set; }
        //public virtual DbSet<WashingTemp123> WashingTemp123 { get; set; }
        //public virtual DbSet<WashingTemp123Temp> WashingTemp123Temp { get; set; }
        //public virtual DbSet<WashingTimeAndTempUnit> WashingTimeAndTempUnit { get; set; }
        //public virtual DbSet<WashingUnitGroupDetail> WashingUnitGroupDetail { get; set; }
        //public virtual DbSet<WashingUnitGroupMaster> WashingUnitGroupMaster { get; set; }
        //public virtual DbSet<Wcimplementation> Wcimplementation { get; set; }
        //public virtual DbSet<WfsChallanIssuance> WfsChallanIssuance { get; set; }
        //public virtual DbSet<WfsChallanIssuanceDetail> WfsChallanIssuanceDetail { get; set; }
        //public virtual DbSet<WfsConfirmationMaster> WfsConfirmationMaster { get; set; }
        //public virtual DbSet<WfsDocumentTypeSetup> WfsDocumentTypeSetup { get; set; }
        //public virtual DbSet<WfsInspectionMaster> WfsInspectionMaster { get; set; }
        //public virtual DbSet<WfsIssuanceMaster> WfsIssuanceMaster { get; set; }
        //public virtual DbSet<WfsJobChallan> WfsJobChallan { get; set; }
        //public virtual DbSet<WfsJobDetail> WfsJobDetail { get; set; }
        //public virtual DbSet<WfsJobMaster> WfsJobMaster { get; set; }
        //public virtual DbSet<WfsJobStatus> WfsJobStatus { get; set; }
        //public virtual DbSet<WfsLoad> WfsLoad { get; set; }
        //public virtual DbSet<WfsLotConfirmationAssociation> WfsLotConfirmationAssociation { get; set; }
        //public virtual DbSet<WfsLotConfirmationMaster> WfsLotConfirmationMaster { get; set; }
        //public virtual DbSet<WfsLotMakingMaster> WfsLotMakingMaster { get; set; }
        //public virtual DbSet<WfsMachinesSetup> WfsMachinesSetup { get; set; }
        //public virtual DbSet<WfsManualOperations> WfsManualOperations { get; set; }
        //public virtual DbSet<WfsMinuteTime> WfsMinuteTime { get; set; }
        //public virtual DbSet<WfsProcessDetail> WfsProcessDetail { get; set; }
        //public virtual DbSet<WfsProcessMaster> WfsProcessMaster { get; set; }
        //public virtual DbSet<WfsReceivingChallanDetail> WfsReceivingChallanDetail { get; set; }
        //public virtual DbSet<WfsReceivingChallanMaster> WfsReceivingChallanMaster { get; set; }
        //public virtual DbSet<WfsRejectionMaster> WfsRejectionMaster { get; set; }
        //public virtual DbSet<WfsStockTransaction> WfsStockTransaction { get; set; }
        //public virtual DbSet<WoDfsRollInspectionAttribute> WoDfsRollInspectionAttribute { get; set; }
        //public virtual DbSet<WoRollDefectDetail> WoRollDefectDetail { get; set; }
        //public virtual DbSet<WorkCenterMrpitemCode> WorkCenterMrpitemCode { get; set; }
        //public virtual DbSet<WorkCenterSetup> WorkCenterSetup { get; set; }
        #endregion


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<DefaultTableProperties>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.IsActive = true;
                        entry.Entity.IsRemoved = false;
                        entry.Entity.CreatedBy = _currentUserService.UserID;
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserID;
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
            #region Setups



            //
            #endregion Setups
           
            

            
            

            //modelBuilder.Entity<AcBalanceFabricStock>(entity =>
            //{
            //    entity.HasKey(e => e.Id)
            //        .HasName("PK_AC_BalanceFabricStock_1")
            //        .IsClustered(false);

            //    entity.ToTable("AC_BalanceFabricStock");

            //    entity.HasIndex(e => e.TransDate);

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ActualGsm).HasColumnName("ActualGSM");

            //    entity.Property(e => e.AttributeinstanceId).HasColumnName("AttributeinstanceID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.StdGsm).HasColumnName("StdGSM");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.TransDate)
            //        .HasColumnName("Trans_Date")
            //        .HasColumnType("datetime");
            //});

            //modelBuilder.Entity<AcBalanceFabricStockBk>(entity =>
            //{
            //    entity.ToTable("AC_BalanceFabricStock_Bk");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ActualGsm).HasColumnName("ActualGSM");

            //    entity.Property(e => e.AttributeinstanceId).HasColumnName("AttributeinstanceID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.StdGsm).HasColumnName("StdGSM");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.TransDate)
            //        .HasColumnName("Trans_Date")
            //        .HasColumnType("datetime");
            //});

            //modelBuilder.Entity<AgencyAgencyIssuanceMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Agency_AgencyIssuanceMaster");

            //    entity.Property(e => e.AgencyId).HasColumnName("AgencyID");

            //    entity.Property(e => e.AgencyIssuanceId)
            //        .HasColumnName("AgencyIssuanceID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Comments).HasMaxLength(255);

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<AgencyConfirmationMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Agency_ConfirmationMaster");

            //    entity.Property(e => e.AgencyConfirmationId)
            //        .HasColumnName("AgencyConfirmationID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.AgencyId).HasColumnName("AgencyID");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<AgencyConfirmationView>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("AgencyConfirmation_View");

            //    entity.Property(e => e.AgencyConfirmationId).HasColumnName("AgencyConfirmationID");

            //    entity.Property(e => e.AgencyId).HasColumnName("AgencyID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<AgencyDateWiseReport>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.Property(e => e.BundleId).HasColumnName("BundleID");

            //    entity.Property(e => e.ChallanNo).HasColumnName("challanNO");

            //    entity.Property(e => e.Color)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.IssuanceAgencyId).HasColumnName("IssuanceAgencyID");

            //    entity.Property(e => e.OrderNo)
            //        .HasColumnName("OrderNO")
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.PatternPiece)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PatternPieceId).HasColumnName("PatternPieceID");

            //    entity.Property(e => e.ReceiveAgencyId).HasColumnName("ReceiveAgencyID");

            //    entity.Property(e => e.Size)
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.Style)
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<AgencyDestinationSetup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("AgencyDestination_Setup");

            //    entity.Property(e => e.FromMrpitemCode).HasColumnName("FromMRPItemCode");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ToMrpitemCode).HasColumnName("ToMRPItemCode");
            //});

            //modelBuilder.Entity<AgencyInspectionMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Agency_InspectionMaster");

            //    entity.Property(e => e.AgencyId).HasColumnName("AgencyID");

            //    entity.Property(e => e.AgencyInspectionId)
            //        .HasColumnName("AgencyInspectionID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<AgencyInspectionView>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("AgencyInspection_View");

            //    entity.Property(e => e.AgencyId).HasColumnName("AgencyID");

            //    entity.Property(e => e.AgencyInspectionId).HasColumnName("AgencyInspectionID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<AgencyIssuanceView>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("AgencyIssuance_View");

            //    entity.Property(e => e.AgencyId).HasColumnName("AgencyID");

            //    entity.Property(e => e.AgencyIssuanceId).HasColumnName("AgencyIssuanceID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<AgencyLinkage>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("AgencyLinkage");

            //    entity.Property(e => e.AgencyDesc)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.AgencyId).HasColumnName("AgencyID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.CadcamjobId).HasColumnName("CADCAMJobID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.Comments)
            //        .IsRequired()
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.IssuanceMasterId).HasColumnName("IssuanceMasterID");

            //    entity.Property(e => e.JobTicketId).HasColumnName("JobTicketID");

            //    entity.Property(e => e.MrpitemCode)
            //        .HasColumnName("MRPItemCode")
            //        .HasColumnType("numeric(18, 0)");

            //    entity.Property(e => e.PieceId).HasColumnName("PieceID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.TransDate).HasColumnType("datetime");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<AgencyOrderWiseReport>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.Property(e => e.BundleId).HasColumnName("BundleID");

            //    entity.Property(e => e.ChallanNo).HasColumnName("challanNO");

            //    entity.Property(e => e.Color)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.IssuanceAgencyId).HasColumnName("IssuanceAgencyID");

            //    entity.Property(e => e.OrderNo)
            //        .HasColumnName("OrderNO")
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.PatternPiece)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PatternPieceId).HasColumnName("PatternPieceID");

            //    entity.Property(e => e.ReceiveAgencyId).HasColumnName("ReceiveAgencyID");

            //    entity.Property(e => e.Size)
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.Style)
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<AgencyReceivingMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Agency_ReceivingMaster");

            //    entity.Property(e => e.AgencyId).HasColumnName("AgencyID");

            //    entity.Property(e => e.AgencyReceivingId)
            //        .HasColumnName("AgencyReceivingID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<AgencyReceivingView>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("AgencyReceiving_View");

            //    entity.Property(e => e.AgencyId).HasColumnName("AgencyID");

            //    entity.Property(e => e.AgencyReceivingId).HasColumnName("AgencyReceivingID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<AgencyRejectingMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Agency_RejectingMaster");

            //    entity.Property(e => e.AgencyId).HasColumnName("AgencyID");

            //    entity.Property(e => e.AgencyRejectingId)
            //        .HasColumnName("AgencyRejectingID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<AgencyStockTransactionDocumentType>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Agency_StockTransaction_DocumentType");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");
            //});

            //modelBuilder.Entity<AgencyStockTransactions>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Agency_StockTransactions");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.BundleId).HasColumnName("BundleID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.PatternPieceId).HasColumnName("PatternPieceID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.StockTransactionId)
            //        .HasColumnName("StockTransactionID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.TransactionDate).HasColumnType("datetime");
            //});

            //modelBuilder.Entity<AgencyStyleChallanStatus>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Agency_StyleChallan_Status");

            //    entity.Property(e => e.AgencyId).HasColumnName("AgencyID");

            //    entity.Property(e => e.FlowChallanRecStatus)
            //        .IsRequired()
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<AgencyView>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("AgencyView");

            //    entity.Property(e => e.AgencyDesc)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.AgencyId).HasColumnName("AgencyID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.Comments)
            //        .IsRequired()
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.MrpitemCode)
            //        .HasColumnName("MRPItemCode")
            //        .HasColumnType("numeric(18, 0)");

            //    entity.Property(e => e.PieceId).HasColumnName("PieceID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.TransDate).HasColumnType("datetime");
            //});

            //modelBuilder.Entity<BarCodeDetail>(entity =>
            //{
            //    entity.HasKey(e => new { e.BarCodeNo, e.MrpitemCode, e.DocumentTypeId })
            //        .HasName("PK_BarCodeDetail_1");

            //    entity.Property(e => e.BarCodeNo)
            //        .HasColumnName("BarCodeNO")
            //        .HasMaxLength(23)
            //        .IsUnicode(false);

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.ChallanId).HasColumnName("ChallanID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.Dated).HasColumnType("datetime");

            //    entity.Property(e => e.QualityId).HasColumnName("QualityID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.Sno)
            //        .HasColumnName("SNO")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.StockTransactionId).HasColumnName("StockTransactionID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<BarCodeDocumentType>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("BarCode_DocumentType");

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Id).HasColumnName("ID");
            //});

            //modelBuilder.Entity<BarcodedetailNotToBeDelted>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("barcodedetail_NotToBeDelted");

            //    entity.Property(e => e.BarCodeNo)
            //        .IsRequired()
            //        .HasColumnName("BarCodeNO")
            //        .HasMaxLength(23)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ChallanId).HasColumnName("ChallanID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.Dated).HasColumnType("datetime");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.QualityId).HasColumnName("QualityID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.Sno)
            //        .HasColumnName("SNO")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.StockTransactionId).HasColumnName("StockTransactionID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<BcdbackUp>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("BCDBackUp");

            //    entity.Property(e => e.BarCodeNo)
            //        .HasColumnName("BarCodeNO")
            //        .HasMaxLength(23)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ChallanId).HasColumnName("ChallanID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.Dated).HasColumnType("datetime");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.QualityId).HasColumnName("QualityID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.Sno)
            //        .HasColumnName("SNO")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.StockTransactionId).HasColumnName("StockTransactionID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<Bctable>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("BCTable");

            //    entity.Property(e => e.Barcodeno)
            //        .HasColumnName("barcodeno")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.Mrpitemcode).HasColumnName("mrpitemcode");

            //    entity.Property(e => e.Serialno).HasColumnName("serialno");
            //});

            //modelBuilder.Entity<Bctable1>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("BCTable1");

            //    entity.Property(e => e.Barcodeno)
            //        .HasColumnName("barcodeno")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Countter).HasColumnName("countter");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.Mrpitemcode).HasColumnName("mrpitemcode");

            //    entity.Property(e => e.Serialno).HasColumnName("serialno");
            //});

            //modelBuilder.Entity<BundleDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Bundle_Detail");

            //    entity.HasIndex(e => new { e.BundleId, e.SizeId, e.ColorId })
            //        .HasName("Ind_Bundle_Detail_1");

            //    entity.HasIndex(e => new { e.BundleId, e.ColorId, e.SizeId, e.PatternPieceId })
            //        .HasName("Bundle_1");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.BundleId).HasColumnName("BundleID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.PatternPieceId).HasColumnName("PatternPieceID");

            //    entity.Property(e => e.Shade)
            //        .HasColumnName("SHADE")
            //        .HasMaxLength(1)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");
            //});

            //modelBuilder.Entity<BundleDetailFazal>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("bundle_detail_fazal");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.BundleId).HasColumnName("BundleID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.PatternPieceId).HasColumnName("PatternPieceID");

            //    entity.Property(e => e.Shade)
            //        .HasColumnName("shade")
            //        .HasMaxLength(2)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");
            //});

            //modelBuilder.Entity<BundleMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Bundle_Master");

            //    entity.HasIndex(e => e.BundleId)
            //        .HasName("Ind_Bundle_Master_1")
            //        .IsClustered();

            //    entity.HasIndex(e => new { e.StyleId, e.BundleId, e.JobTicketId })
            //        .HasName("Ind_Bundle_Master_2");

            //    entity.Property(e => e.BundleId)
            //        .HasColumnName("BundleID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.BundleStatusId).HasColumnName("BundleStatusID");

            //    entity.Property(e => e.JobTicketId).HasColumnName("JobTicketID");

            //    entity.Property(e => e.Rdate)
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.WorkCenterId).HasColumnName("WorkCenterID");
            //});

            //modelBuilder.Entity<BundleStatusSetup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("BundleStatus_Setup");

            //    entity.Property(e => e.BundleStatus)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.BundleStatusId).HasColumnName("BundleStatusID");
            //});

            //modelBuilder.Entity<BundleTransaction>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Bundle_Transaction");

            //    entity.Property(e => e.Bdate)
            //        .HasColumnName("BDate")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.BundleId).HasColumnName("BundleID");

            //    entity.Property(e => e.BundleStatusId).HasColumnName("BundleStatusID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<CadcambodyPart>(entity =>
            //{
            //    entity.HasKey(e => e.BodyPartId);

            //    entity.ToTable("CADCAMBodyPart");

            //    entity.Property(e => e.BodyPartId)
            //        .HasColumnName("BodyPartID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.CadcamjobId).HasColumnName("CADCAMJobID");

            //    entity.Property(e => e.QrmfabricTrimId).HasColumnName("QRMFabricTrimID");

            //    entity.HasOne(d => d.Cadcamjob)
            //        .WithMany(p => p.CadcambodyPart)
            //        .HasForeignKey(d => d.CadcamjobId)
            //        .HasConstraintName("FK_CADCAMBodyPart_CADCAMJob");
            //});

            //modelBuilder.Entity<Cadcamjob>(entity =>
            //{
            //    entity.ToTable("CADCAMJob");

            //    entity.Property(e => e.CadcamjobId)
            //        .HasColumnName("CADCAMJobID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.AssignedStyleId).HasColumnName("AssignedStyleID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.CadcamjobNo)
            //        .IsRequired()
            //        .HasColumnName("CADCAMJobNo")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.MarkerReceivedStatus).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<CadcampatternPiece>(entity =>
            //{
            //    entity.ToTable("CADCAMPatternPiece");

            //    entity.Property(e => e.CadcampatternPieceId)
            //        .HasColumnName("CADCAMPatternPieceID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.CadcambodyPartId).HasColumnName("CADCAMBodyPartID");

            //    entity.Property(e => e.QrmpatternPieceId).HasColumnName("QRMPatternPieceID");

            //    entity.HasOne(d => d.CadcambodyPart)
            //        .WithMany(p => p.CadcampatternPiece)
            //        .HasForeignKey(d => d.CadcambodyPartId)
            //        .HasConstraintName("FK_CADCAMPatternPiece_CADCAMBodyPart");
            //});

            //modelBuilder.Entity<CheckDoubleBarcode>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("CheckDoubleBarcode");
            //});

            //modelBuilder.Entity<CmtChallanReceicveMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMT_ChallanReceicveMaster");

            //    entity.Property(e => e.ChallanId).HasColumnName("ChallanID");

            //    entity.Property(e => e.Comments)
            //        .HasColumnName("comments")
            //        .HasMaxLength(500)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ReceiveDate).HasColumnType("datetime");

            //    entity.Property(e => e.ReceiveId)
            //        .HasColumnName("ReceiveID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.WomasterId).HasColumnName("WOMasterID");
            //});

            //modelBuilder.Entity<CmtCompanySetup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMT_Company_Setup");

            //    entity.Property(e => e.CreditorAccId).HasColumnName("Creditor_AccID");

            //    entity.Property(e => e.DebitorAccId).HasColumnName("Debitor_AccID");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<CmtCurrencySetup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMT_Currency_Setup");

            //    entity.Property(e => e.CmtCurrencyId)
            //        .HasColumnName("CMT_CurrencyID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<CmtFinanceMapping>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMT_FinanceMapping");

            //    entity.Property(e => e.AccId).HasColumnName("AccID");

            //    entity.Property(e => e.ActivityId).HasColumnName("Activity_ID");

            //    entity.Property(e => e.AgencyId).HasColumnName("AgencyID");

            //    entity.Property(e => e.CostCenterId).HasColumnName("CostCenterID");

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.LocationId).HasColumnName("Location_ID");

            //    entity.Property(e => e.Mrpitem).HasColumnName("MRPItem");

            //    entity.Property(e => e.ParentId).HasColumnName("ParentID");

            //    entity.Property(e => e.Sno).ValueGeneratedOnAdd();

            //    entity.Property(e => e.WcId).HasColumnName("WC_ID");
            //});

            //modelBuilder.Entity<CmtModeOfPaymentSetup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMT_ModeOfPayment_Setup");

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ModeOfPaymentId)
            //        .HasColumnName("ModeOfPaymentID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<CmtStockTransaction>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMT_StockTransaction");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.CmtBundleId).HasColumnName("CMT_BundleID");

            //    entity.Property(e => e.CmtColorId).HasColumnName("CMT_ColorID");

            //    entity.Property(e => e.CmtDocumentNo).HasColumnName("CMT_DocumentNo");

            //    entity.Property(e => e.CmtDocumentTypeId).HasColumnName("CMT_DocumentTypeID");

            //    entity.Property(e => e.CmtMrpitemCode).HasColumnName("CMT_MRPItemCode");

            //    entity.Property(e => e.CmtPatternPieceId).HasColumnName("CMT_PatternPieceID");

            //    entity.Property(e => e.CmtPerPieceRate).HasColumnName("CMT_PerPieceRate");

            //    entity.Property(e => e.CmtQuantity).HasColumnName("CMT_Quantity");

            //    entity.Property(e => e.CmtSizeId).HasColumnName("CMT_SizeID");

            //    entity.Property(e => e.CmtStockTransactionId)
            //        .HasColumnName("CMT_StockTransactionID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.CmtTransactionDate)
            //        .HasColumnName("CMT_TransactionDate")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.StartDate).HasColumnType("datetime");
            //});

            //modelBuilder.Entity<CmtStoresSetup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMT_Stores_Setup");

            //    entity.Property(e => e.CmtStoreId)
            //        .HasColumnName("CMT_StoreID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<CmtTermsOfPaymentSetup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMT_TermsOfPayment_Setup");

            //    entity.Property(e => e.CmtTermsOfPaymentId)
            //        .HasColumnName("CMT_TermsOfPaymentID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<CmtWoDocumentType>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMT_WO_DocumentType");

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.WoDocumentTypeId)
            //        .HasColumnName("WO_DocumentTypeID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<CmtWochallanMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMT_WOChallanMaster");

            //    entity.Property(e => e.ChallanDate).HasColumnType("datetime");

            //    entity.Property(e => e.ChallanId)
            //        .HasColumnName("ChallanID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Comments)
            //        .HasColumnName("comments")
            //        .HasMaxLength(500)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Status).HasColumnName("status");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.WomasterId).HasColumnName("WOMasterID");
            //});

            //modelBuilder.Entity<CmtWorkOrderMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMT_WorkOrderMaster");

            //    entity.Property(e => e.CmtAgencyId).HasColumnName("CMT_AgencyID");

            //    entity.Property(e => e.CmtBcocode).HasColumnName("CMT_BCOCode");

            //    entity.Property(e => e.CmtCodeId).HasColumnName("CMT_CodeID");

            //    entity.Property(e => e.CmtCurrencyId).HasColumnName("CMT_CurrencyID");

            //    entity.Property(e => e.CmtDeliveryDate)
            //        .HasColumnName("CMT_DeliveryDate")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.CmtDeliveryDestinationId).HasColumnName("CMT_DeliveryDestinationID");

            //    entity.Property(e => e.CmtModeOfPaymentId).HasColumnName("CMT_ModeOfPaymentID");

            //    entity.Property(e => e.CmtNoOfDelivery).HasColumnName("CMT_NoOfDelivery");

            //    entity.Property(e => e.CmtPaymentDays).HasColumnName("CMT_PaymentDays");

            //    entity.Property(e => e.CmtPerPieceRate).HasColumnName("CMT_PerPieceRate");

            //    entity.Property(e => e.CmtStyleId).HasColumnName("CMT_StyleID");

            //    entity.Property(e => e.CmtTermsOfPaymentId).HasColumnName("CMT_TermsOfPaymentID");

            //    entity.Property(e => e.CmtWorkOrderMasterId)
            //        .HasColumnName("CMT_WorkOrderMasterID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<ColorName>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("ColorName");

            //    entity.Property(e => e.ColorName1)
            //        .HasColumnName("ColorName")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.PantoneNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .IsFixedLength();
            //});

            //modelBuilder.Entity<CuttingConfirmationDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.CuttingConfirmationDetailId)
            //        .HasColumnName("CuttingConfirmationDetailID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.CuttingConfirmationMasterId).HasColumnName("CuttingConfirmationMasterID");

            //    entity.Property(e => e.RangeId).HasColumnName("RangeID");

            //    entity.Property(e => e.ShellColorId).HasColumnName("ShellColorID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.TrimId).HasColumnName("TrimID");

            //    entity.HasOne(d => d.CuttingConfirmationMaster)
            //        .WithMany(p => p.CuttingConfirmationDetail)
            //        .HasForeignKey(d => d.CuttingConfirmationMasterId)
            //        .HasConstraintName("FK_CuttingConfirmationDetail_CuttingConfirmationMaster");
            //});

            //modelBuilder.Entity<CuttingConfirmationMaster>(entity =>
            //{
            //    entity.Property(e => e.CuttingConfirmationMasterId).HasColumnName("CuttingConfirmationMasterID");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ConfirmationDate)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.DocumentType).HasDefaultValueSql("(1)");

            //    entity.Property(e => e.FabricDetailId).HasColumnName("FabricDetailID");

            //    entity.Property(e => e.JobTicketId).HasColumnName("JobTicketID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<CuttingImplementation>(entity =>
            //{
            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.ImplementationId).HasColumnName("ImplementationID");

            //    entity.Property(e => e.TableId).HasColumnName("TableID");
            //});

            //modelBuilder.Entity<CuttingInspection>(entity =>
            //{
            //    entity.HasKey(e => e.CuttingInspectionMasterId);

            //    entity.Property(e => e.CuttingInspectionMasterId).HasColumnName("CuttingInspectionMasterID");

            //    entity.Property(e => e.CuttingInspectionDate).HasColumnType("datetime");

            //    entity.Property(e => e.InspectionXml)
            //        .HasColumnName("InspectionXML")
            //        .HasMaxLength(8000)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ReceivedFabricDetailId).HasColumnName("ReceivedFabricDetailID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<CuttingInspectionDetail>(entity =>
            //{
            //    entity.Property(e => e.CuttingInspectionDetailId).HasColumnName("CuttingInspectionDetailID");

            //    entity.Property(e => e.CuttingInpectionParameterId).HasColumnName("CuttingInpectionParameterID");

            //    entity.Property(e => e.CuttingInspectionMasterId).HasColumnName("CuttingInspectionMasterID");

            //    entity.HasOne(d => d.CuttingInpectionParameter)
            //        .WithMany(p => p.CuttingInspectionDetail)
            //        .HasForeignKey(d => d.CuttingInpectionParameterId)
            //        .HasConstraintName("FK_CuttingInspectionDetail_InspectionParameter");

            //    entity.HasOne(d => d.CuttingInspectionMaster)
            //        .WithMany(p => p.CuttingInspectionDetail)
            //        .HasForeignKey(d => d.CuttingInspectionMasterId)
            //        .HasConstraintName("FK_CuttingInspectionDetail_CuttingInspectionMaster");
            //});

            //modelBuilder.Entity<CuttingInspectionMaster>(entity =>
            //{
            //    entity.Property(e => e.CuttingInspectionMasterId).HasColumnName("CuttingInspectionMasterID");

            //    entity.Property(e => e.CuttingInspectionDate).HasColumnType("datetime");

            //    entity.Property(e => e.ReceivedFabricDetailId).HasColumnName("ReceivedFabricDetailID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<CuttingLeftOverMaster>(entity =>
            //{
            //    entity.HasKey(e => e.CuttingLeftOverId);

            //    entity.ToTable("Cutting_LeftOver_Master");

            //    entity.Property(e => e.CuttingLeftOverId).HasColumnName("Cutting_LeftOver_ID");

            //    entity.Property(e => e.ModelId).HasColumnName("ModelID");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.TransDate)
            //        .HasColumnName("Trans_Date")
            //        .HasColumnType("datetime");
            //});

            //modelBuilder.Entity<CuttingMachineInstance>(entity =>
            //{
            //    entity.HasKey(e => e.FamId);

            //    entity.Property(e => e.FamId)
            //        .HasColumnName("FAM_ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.CuttingMachineInstanceName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CuttingMachineTypeId).HasColumnName("CuttingMachineTypeID");

            //    entity.Property(e => e.FamparentId).HasColumnName("FAMParent_ID");

            //    entity.Property(e => e.StateId)
            //        .HasColumnName("StateID")
            //        .HasDefaultValueSql("(1)");

            //    entity.HasOne(d => d.Famparent)
            //        .WithMany(p => p.CuttingMachineInstance)
            //        .HasForeignKey(d => d.FamparentId)
            //        .HasConstraintName("FK_CuttingMachineInstance_CuttingMachineType");
            //});

            //modelBuilder.Entity<CuttingMachineLoad>(entity =>
            //{
            //    entity.Property(e => e.CuttingMachineLoadId).HasColumnName("CuttingMachineLoadID");

            //    entity.Property(e => e.Deleted).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.FamId).HasColumnName("FAM_ID");

            //    entity.Property(e => e.JobTicketId).HasColumnName("JobTicketID");

            //    entity.Property(e => e.MinuteId).HasColumnName("MinuteID");

            //    entity.Property(e => e.WcdayId).HasColumnName("WCDayID");

            //    entity.HasOne(d => d.Fam)
            //        .WithMany(p => p.CuttingMachineLoad)
            //        .HasForeignKey(d => d.FamId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_CuttingMachineLoad_CuttingMachineInstance");

            //    entity.HasOne(d => d.Minute)
            //        .WithMany(p => p.CuttingMachineLoad)
            //        .HasForeignKey(d => d.MinuteId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_CuttingMachineLoad_MinuteTime");
            //});

            //modelBuilder.Entity<CuttingMachineType>(entity =>
            //{
            //    entity.HasKey(e => e.FamId);

            //    entity.Property(e => e.FamId)
            //        .HasColumnName("FAM_ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.CuttingMachineTypeName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.FamparentId).HasColumnName("FAMParent_ID");
            //});

            //modelBuilder.Entity<CuttingOperation>(entity =>
            //{
            //    entity.Property(e => e.CuttingOperationId)
            //        .HasColumnName("CuttingOperationID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.CuttingOperationName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<DailyCuttingReportComments>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.ReportDate)
            //        .HasMaxLength(12)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<DefectCategory>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Defect_Category");

            //    entity.Property(e => e.DefectCategoryId)
            //        .HasColumnName("DefectCategoryID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.DefectDescription)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.WorkCentreId).HasColumnName("WorkCentreID");
            //});

            //modelBuilder.Entity<DefectLevel1>(entity =>
            //{
            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.LevelNo).HasDefaultValueSql("(1)");
            //});

            //modelBuilder.Entity<DefectLevel2>(entity =>
            //{
            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ConCatId)
            //        .HasColumnName("ConCatID")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.LevelNo).HasDefaultValueSql("(2)");

            //    entity.Property(e => e.ParentId).HasColumnName("ParentID");

            //    entity.HasOne(d => d.Parent)
            //        .WithMany(p => p.DefectLevel2)
            //        .HasForeignKey(d => d.ParentId)
            //        .HasConstraintName("FK_DefectLevel2_DefectLevel1");
            //});

            //modelBuilder.Entity<DefectLevel3>(entity =>
            //{
            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ConCatId)
            //        .HasColumnName("ConCatID")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.LevelNo).HasDefaultValueSql("(3)");

            //    entity.Property(e => e.ParentId).HasColumnName("ParentID");

            //    entity.HasOne(d => d.Parent)
            //        .WithMany(p => p.DefectLevel3)
            //        .HasForeignKey(d => d.ParentId)
            //        .HasConstraintName("FK_DefectLevel3_DefectLevel2");
            //});

            //modelBuilder.Entity<DefectLevel4>(entity =>
            //{
            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ConCatId)
            //        .HasColumnName("ConCatID")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.LevelNo).HasDefaultValueSql("(4)");

            //    entity.Property(e => e.ParentId).HasColumnName("ParentID");

            //    entity.HasOne(d => d.Parent)
            //        .WithMany(p => p.DefectLevel4)
            //        .HasForeignKey(d => d.ParentId)
            //        .HasConstraintName("FK_DefectLevel4_DefectLevel3");
            //});

            //modelBuilder.Entity<DefectLevel5>(entity =>
            //{
            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ConCatId)
            //        .HasColumnName("ConCatID")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.LevelNo).HasDefaultValueSql("(5)");

            //    entity.Property(e => e.ParentId).HasColumnName("ParentID");

            //    entity.HasOne(d => d.Parent)
            //        .WithMany(p => p.DefectLevel5)
            //        .HasForeignKey(d => d.ParentId)
            //        .HasConstraintName("FK_DefectLevel5_DefectLevel4");
            //});

            //modelBuilder.Entity<DefectSetup>(entity =>
            //{
            //    entity.HasKey(e => e.DefectId);

            //    entity.ToTable("Defect_Setup");

            //    entity.Property(e => e.DefectId).HasColumnName("DefectID");

            //    entity.Property(e => e.Defect)
            //        .IsRequired()
            //        .HasMaxLength(250)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DefectCategoryId).HasColumnName("DefectCategoryID");

            //    entity.Property(e => e.WorkCenterId).HasColumnName("WorkCenterID");
            //});

            //modelBuilder.Entity<DfsConfirmationMaster>(entity =>
            //{
            //    entity.ToTable("DFS_ConfirmationMaster");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ConfirmationDate).HasColumnType("datetime");

            //    entity.Property(e => e.LotId).HasColumnName("LotID");

            //    entity.Property(e => e.Status)
            //        .HasColumnName("STATUS")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<DfsDcassociationforLot>(entity =>
            //{
            //    entity.ToTable("DFS_DCAssociationforLot");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Dcid).HasColumnName("DCID");

            //    entity.Property(e => e.LotId).HasColumnName("LotID");
            //});

            //modelBuilder.Entity<DfsDocumentTypeSetup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("DFS_DocumentType_Setup");

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<DfsInspectionApproval>(entity =>
            //{
            //    entity.HasKey(e => e.InspectionApprovalId);

            //    entity.ToTable("DFS_Inspection_Approval");

            //    entity.Property(e => e.InspectionApprovalId).HasColumnName("Inspection_Approval_ID");

            //    entity.Property(e => e.AgencyId).HasColumnName("AgencyID");

            //    entity.Property(e => e.ConformationId).HasColumnName("ConformationID");

            //    entity.Property(e => e.InspectionApprovalDate)
            //        .HasColumnName("Inspection_Approval_Date")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.InspectionApprovalNo)
            //        .IsRequired()
            //        .HasColumnName("Inspection_Approval_No")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.LotId).HasColumnName("LotID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<DfsInspectionApprovalDetail>(entity =>
            //{
            //    entity.HasKey(e => e.InspectionApprovalDetailId);

            //    entity.ToTable("DFS_Inspection_Approval_Detail");

            //    entity.Property(e => e.InspectionApprovalDetailId).HasColumnName("Inspection_Approval_DetailID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(500)
            //        .IsUnicode(false);

            //    entity.Property(e => e.FabricRubbings)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.FabricSkewing)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.FabricWashing)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Gsm).HasColumnName("GSM");

            //    entity.Property(e => e.InspectionApprovalId).HasColumnName("Inspection_Approval_ID");

            //    entity.Property(e => e.RecordDate).HasColumnType("datetime");

            //    entity.Property(e => e.RollNo)
            //        .IsRequired()
            //        .HasMaxLength(25)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ShrinkageLen)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ShrinkageWidth)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<DfsInspectionMaster>(entity =>
            //{
            //    entity.ToTable("DFS_InspectionMaster");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(1000)
            //        .IsUnicode(false);

            //    entity.Property(e => e.InspectionDate).HasColumnType("datetime");

            //    entity.Property(e => e.LotId).HasColumnName("LotID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<DfsInspectionNewAttributeSetup>(entity =>
            //{
            //    entity.ToTable("DFS_InspectionNewAttribute_Setup");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.FinishedGsm)
            //        .HasColumnName("FinishedGSM")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.FinishedWeight).HasDefaultValueSql("((0))");

            //    entity.Property(e => e.FinishedWidth).HasDefaultValueSql("((0))");

            //    entity.Property(e => e.MachineId).HasColumnName("MachineID");

            //    entity.Property(e => e.NewDcgattributeInstanceId).HasColumnName("NewDCGAttributeInstanceID");

            //    entity.Property(e => e.OldDcgattributeInstanceId).HasColumnName("OldDCGAttributeInstanceID");

            //    entity.Property(e => e.RollId).HasColumnName("RollID");

            //    entity.Property(e => e.RollNo)
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Ykncid).HasColumnName("YKNCID");
            //});

            //modelBuilder.Entity<DfsIssuanceDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("DFS_IssuanceDetail");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.IssuanceId).HasColumnName("IssuanceID");

            //    entity.Property(e => e.ReceivingId).HasColumnName("ReceivingID");
            //});

            //modelBuilder.Entity<DfsIssuanceMaster>(entity =>
            //{
            //    entity.ToTable("DFS_IssuanceMaster");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Dcid).HasColumnName("DCID");

            //    entity.Property(e => e.IsReceived)
            //        .HasColumnName("isReceived")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.IssuanceDate).HasColumnType("datetime");

            //    entity.Property(e => e.LotId).HasColumnName("LotID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<DfsLotApproval>(entity =>
            //{
            //    entity.HasKey(e => e.ApprovalId);

            //    entity.ToTable("DFS_LotApproval");

            //    entity.Property(e => e.ApprovalId).HasColumnName("ApprovalID");

            //    entity.Property(e => e.ApprovalDate).HasColumnType("datetime");

            //    entity.Property(e => e.Comments).IsUnicode(false);

            //    entity.Property(e => e.LotId).HasColumnName("LotID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<DfsLotHistoryDestinationDetail>(entity =>
            //{
            //    entity.ToTable("DFS_LotHistoryDestinationDetail");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.Ldid).HasColumnName("LDID");

            //    entity.Property(e => e.RollNumber)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<DfsLotHistoryDestinationDetailBeforeChange>(entity =>
            //{
            //    entity.ToTable("DFS_LotHistoryDestinationDetail_BeforeChange");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.Ldid).HasColumnName("LDID");

            //    entity.Property(e => e.RollNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<DfsLotHistoryDestinationMaster>(entity =>
            //{
            //    entity.HasKey(e => e.Ldid);

            //    entity.ToTable("DFS_LotHistoryDestinationMaster");

            //    entity.Property(e => e.Ldid).HasColumnName("LDID");

            //    entity.Property(e => e.Date)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.DestinationLotId).HasColumnName("DestinationLotID");

            //    entity.Property(e => e.DestinationLotNumber)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.Hid).HasColumnName("HID");

            //    entity.Property(e => e.PantoneId).HasColumnName("PantoneID");
            //});

            //modelBuilder.Entity<DfsLotHistorySetup>(entity =>
            //{
            //    entity.ToTable("DFS_LotHistory_Setup");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(20)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<DfsLotHistorySourceDetail>(entity =>
            //{
            //    entity.ToTable("DFS_LotHistorySourceDetail");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.Lsid).HasColumnName("LSID");

            //    entity.Property(e => e.RollNumber)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<DfsLotHistorySourceDetailBeforeChange>(entity =>
            //{
            //    entity.ToTable("DFS_LotHistorySourceDetail_BeforeChange");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.Lsid).HasColumnName("LSID");

            //    entity.Property(e => e.RollNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<DfsLotHistorySourceMaster>(entity =>
            //{
            //    entity.HasKey(e => e.Lsid);

            //    entity.ToTable("DFS_LotHistorySourceMaster");

            //    entity.Property(e => e.Lsid).HasColumnName("LSID");

            //    entity.Property(e => e.Date)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.Hid).HasColumnName("HID");

            //    entity.Property(e => e.PantoneId).HasColumnName("PantoneID");

            //    entity.Property(e => e.SourceLotId).HasColumnName("SourceLotID");

            //    entity.Property(e => e.SourceLotNumber)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<DfsLotHistorySuperMaster>(entity =>
            //{
            //    entity.HasKey(e => e.Hid);

            //    entity.ToTable("DFS_LotHistorySuperMaster");

            //    entity.Property(e => e.Hid).HasColumnName("HID");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(60)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Dated)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.PreviousLotId).HasColumnName("PreviousLotID");

            //    entity.Property(e => e.PreviousLotNumber)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UpdateLotId).HasColumnName("UpdateLotID");

            //    entity.Property(e => e.UpdateLotNumber)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<DfsLotMachineRouting>(entity =>
            //{
            //    entity.ToTable("DFS_LotMachine_Routing");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.LotId).HasColumnName("LotID");

            //    entity.Property(e => e.MachineId).HasColumnName("MachineID");
            //});

            //modelBuilder.Entity<DfsLotMakingMaster>(entity =>
            //{
            //    entity.ToTable("DFS_LotMakingMaster");

            //    entity.HasIndex(e => e.Id)
            //        .HasName("IX_DFS_LotMakingMaster");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(1000)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.LotNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<DfsLotMakingMasterRedyeing>(entity =>
            //{
            //    entity.HasKey(e => e.LotId);

            //    entity.ToTable("DFS_LotMakingMaster_Redyeing");

            //    entity.Property(e => e.LotId).HasColumnName("LotID");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(250)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.LotNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<DfsMachineSetup>(entity =>
            //{
            //    entity.ToTable("DFS_Machine_Setup");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.MachineName)
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Smv).HasColumnName("SMV");
            //});

            //modelBuilder.Entity<DfsReDyeingConfirmationMaster>(entity =>
            //{
            //    entity.HasKey(e => e.ConformationId);

            //    entity.ToTable("DFS_Re_Dyeing_ConfirmationMaster");

            //    entity.Property(e => e.ConformationId).HasColumnName("ConformationID");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(250)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ConfirmationDate).HasColumnType("datetime");

            //    entity.Property(e => e.LotId).HasColumnName("LotID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<DfsReceivingMaster>(entity =>
            //{
            //    entity.ToTable("DFS_ReceivingMaster");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Dcid).HasColumnName("DCID");

            //    entity.Property(e => e.IssuanceId).HasColumnName("IssuanceID");

            //    entity.Property(e => e.ReceivingDate).HasColumnType("datetime");

            //    entity.Property(e => e.UserId)
            //        .HasColumnName("UserID")
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .IsFixedLength();
            //});

            //modelBuilder.Entity<DfsReturnRolls>(entity =>
            //{
            //    entity.HasKey(e => e.ReturnId);

            //    entity.ToTable("DFS_Return_Rolls");

            //    entity.Property(e => e.ReturnId).HasColumnName("ReturnID");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.IssuanceId).HasColumnName("IssuanceID");

            //    entity.Property(e => e.RecevieDate)
            //        .HasColumnName("Recevie_Date")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.RecevingId).HasColumnName("RecevingID");

            //    entity.Property(e => e.ReturnDate)
            //        .HasColumnName("Return_Date")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.RollId).HasColumnName("RollID");

            //    entity.Property(e => e.RollNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<DfsRollInspectionAttribute>(entity =>
            //{
            //    entity.ToTable("DFS_Roll_InspectionAttribute");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.DcgattributeInstanceId).HasColumnName("DCGAttributeInstanceID");

            //    entity.Property(e => e.DcrollAttributeId).HasColumnName("DCRollAttributeID");

            //    entity.Property(e => e.InspectionId).HasColumnName("InspectionID");

            //    entity.Property(e => e.MachineId).HasColumnName("MachineID");

            //    entity.Property(e => e.Quantity)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.RollId).HasColumnName("RollID");

            //    entity.Property(e => e.RollNo)
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Ykncid).HasColumnName("YKNCID");
            //});

            //modelBuilder.Entity<DfsStockTransaction>(entity =>
            //{
            //    entity.ToTable("DFS_StockTransaction");

            //    entity.HasIndex(e => new { e.RollId, e.RollNo })
            //        .HasName("Ind_DFS_StockTransaction_Waqar11");

            //    entity.HasIndex(e => new { e.DocumentTypeId, e.RollNo, e.Quantity })
            //        .HasName("Ind_DFS_Stocktransaction_waqar")
            //        .IsUnique();

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(250)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DcgattributeInstanceId).HasColumnName("DCGAttributeInstanceID");

            //    entity.Property(e => e.Dcid).HasColumnName("DCID");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.FinishingCode)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.MachineId).HasColumnName("MachineID");

            //    entity.Property(e => e.MatchingSourceId).HasColumnName("MatchingSourceID");

            //    entity.Property(e => e.PantoneId).HasColumnName("PantoneID");

            //    entity.Property(e => e.PantoneNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.RollId).HasColumnName("RollID");

            //    entity.Property(e => e.RollNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Rollnonew)
            //        .HasColumnName("rollnonew")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Rollnop)
            //        .HasColumnName("rollnop")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StoreLocationId).HasColumnName("StoreLocationID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.Ykncid).HasColumnName("YKNCID");
            //});

            //modelBuilder.Entity<DfsStockTransactionBk22may2016>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("DFS_StockTransaction_BK_22May2016");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(250)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DcgattributeInstanceId).HasColumnName("DCGAttributeInstanceID");

            //    entity.Property(e => e.Dcid).HasColumnName("DCID");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.FinishingCode)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.MachineId).HasColumnName("MachineID");

            //    entity.Property(e => e.MatchingSourceId).HasColumnName("MatchingSourceID");

            //    entity.Property(e => e.PantoneId).HasColumnName("PantoneID");

            //    entity.Property(e => e.PantoneNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.RollId).HasColumnName("RollID");

            //    entity.Property(e => e.RollNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Rollnonew)
            //        .HasColumnName("rollnonew")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Rollnop)
            //        .HasColumnName("rollnop")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StoreLocationId).HasColumnName("StoreLocationID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.Ykncid).HasColumnName("YKNCID");
            //});

            //modelBuilder.Entity<DfsStockTransactionDeleteLog>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("DFS_StockTransaction_DeleteLog");

            //    entity.Property(e => e.Comments)
            //        .HasColumnName("comments")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DcattributeInstanceId).HasColumnName("DCAttributeInstanceID");

            //    entity.Property(e => e.Dcid).HasColumnName("DCID");

            //    entity.Property(e => e.DeletionDate).HasColumnType("datetime");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.FinishingCode)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.LotNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.MachineId).HasColumnName("MachineID");

            //    entity.Property(e => e.MatchingSourceId).HasColumnName("MatchingSourceID");

            //    entity.Property(e => e.PantoneId).HasColumnName("PantoneID");

            //    entity.Property(e => e.PantoneNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.RollId).HasColumnName("RollID");

            //    entity.Property(e => e.RollNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StoreLocationId).HasColumnName("StoreLocationID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.Property(e => e.Ykncid).HasColumnName("YKNCID");
            //});

            //modelBuilder.Entity<DfsWoIssuanceMaster>(entity =>
            //{
            //    entity.ToTable("DFS_WO_IssuanceMaster");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Dcid).HasColumnName("DCID");

            //    entity.Property(e => e.IsReceived).HasColumnName("isReceived");

            //    entity.Property(e => e.IssuanceDate)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.LotId).HasColumnName("LotID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<DfsWoinspectionMaster>(entity =>
            //{
            //    entity.ToTable("DFS_WOInspectionMaster");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(1000)
            //        .IsUnicode(false);

            //    entity.Property(e => e.InspectionDate).HasColumnType("datetime");

            //    entity.Property(e => e.LotId).HasColumnName("LotID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<DfsWoinspectionNewAttributeSetup>(entity =>
            //{
            //    entity.ToTable("DFS_WOInspectionNewAttribute_Setup");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.MachineId).HasColumnName("MachineID");

            //    entity.Property(e => e.NewDcgattributeInstanceId).HasColumnName("NewDCGAttributeInstanceID");

            //    entity.Property(e => e.OldDcgattributeInstanceId).HasColumnName("OldDCGAttributeInstanceID");

            //    entity.Property(e => e.RollId).HasColumnName("RollID");

            //    entity.Property(e => e.RollNo)
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Ykncid).HasColumnName("YKNCID");
            //});

            //modelBuilder.Entity<DfsWorkOrderRecevingMaster>(entity =>
            //{
            //    entity.HasKey(e => e.WorkOrderRecevId);

            //    entity.ToTable("DFS_WorkOrder_Receving_Master");

            //    entity.Property(e => e.WorkOrderRecevId).HasColumnName("WorkOrder_Recev_ID");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(250)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.Property(e => e.WoRecevingDate)
            //        .HasColumnName("WO_Receving_Date")
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.WoRecevingNo)
            //        .IsRequired()
            //        .HasColumnName("WO_Receving_No")
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.WorkOrderId).HasColumnName("WorkOrderID");
            //});

            //modelBuilder.Entity<DivisionSetup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Division_Setup");

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Id)
            //        .IsRequired()
            //        .HasColumnName("ID")
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .IsFixedLength();
            //});

            //modelBuilder.Entity<DocumentType>(entity =>
            //{
            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.DocumentTypeName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<EmbroideryInspectionDetails>(entity =>
            //{
            //    entity.HasKey(e => e.EmbroideryInspectionDetailId);

            //    entity.Property(e => e.EmbroideryInspectionDetailId).HasColumnName("EmbroideryInspectionDetailID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.EmrbroideryInspectionMasterId).HasColumnName("EmrbroideryInspectionMasterID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.HasOne(d => d.EmrbroideryInspectionMaster)
            //        .WithMany(p => p.EmbroideryInspectionDetails)
            //        .HasForeignKey(d => d.EmrbroideryInspectionMasterId)
            //        .HasConstraintName("FK_EmbroideryInspectionDetails_EmbroideryInspectionMaster");
            //});

            //modelBuilder.Entity<EmbroideryInspectionMaster>(entity =>
            //{
            //    entity.Property(e => e.EmbroideryInspectionMasterId).HasColumnName("EmbroideryInspectionMasterID");

            //    entity.Property(e => e.Dated).HasColumnType("datetime");

            //    entity.Property(e => e.EmbroiderySpecificationId).HasColumnName("EmbroiderySpecificationID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<EmbroideryIssuanceDetail>(entity =>
            //{
            //    entity.Property(e => e.EmbroideryIssuanceDetailId)
            //        .HasColumnName("EmbroideryIssuanceDetailID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.EmbroideryJobId).HasColumnName("EmbroideryJobID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.HasOne(d => d.EmbroideryJob)
            //        .WithMany(p => p.EmbroideryIssuanceDetail)
            //        .HasForeignKey(d => d.EmbroideryJobId)
            //        .HasConstraintName("FK_EmbroideryIssuanceDetail_EmbroideryIssuanceMaster");
            //});

            //modelBuilder.Entity<EmbroideryIssuanceMaster>(entity =>
            //{
            //    entity.HasKey(e => e.EmbroideryJobId);

            //    entity.Property(e => e.EmbroideryJobId)
            //        .HasColumnName("EmbroideryJobID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.Dated).HasColumnType("datetime");

            //    entity.Property(e => e.EmbroiderySpecificationId).HasColumnName("EmbroiderySpecificationID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<EmbroideryReceivingDetail>(entity =>
            //{
            //    entity.HasKey(e => e.EmrbroideryReceivingDetailId);

            //    entity.Property(e => e.EmrbroideryReceivingDetailId).HasColumnName("EmrbroideryReceivingDetailID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.EmbroideryMasterId).HasColumnName("EmbroideryMasterID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.HasOne(d => d.EmbroideryMaster)
            //        .WithMany(p => p.EmbroideryReceivingDetail)
            //        .HasForeignKey(d => d.EmbroideryMasterId)
            //        .HasConstraintName("FK_EmbroideryReceivingDetail_EmbroideryReceivingMaster");
            //});

            //modelBuilder.Entity<EmbroideryReceivingMaster>(entity =>
            //{
            //    entity.Property(e => e.EmbroideryReceivingMasterId).HasColumnName("EmbroideryReceivingMasterID");

            //    entity.Property(e => e.Dated).HasColumnType("datetime");

            //    entity.Property(e => e.EmbroiderySpecificationId).HasColumnName("EmbroiderySpecificationID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<ErpCalendarDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("ERP_CalendarDetail");

            //    entity.Property(e => e.CalendarDate).HasColumnType("datetime");

            //    entity.Property(e => e.CalendarDayTypeId).HasColumnName("CalendarDayTypeID");

            //    entity.Property(e => e.CalendarId).HasColumnName("CalendarID");

            //    entity.Property(e => e.Id).HasColumnName("ID");
            //});

            //modelBuilder.Entity<FabricIrdetail>(entity =>
            //{
            //    entity.ToTable("FabricIRDetail");

            //    entity.Property(e => e.FabricIrdetailId).HasColumnName("FabricIRDetailID");

            //    entity.Property(e => e.AllocatedQty).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.AttributeInstanceId)
            //        .HasColumnName("AttributeInstanceID")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.Color)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Description).HasColumnType("ntext");

            //    entity.Property(e => e.FabricIrmasterId).HasColumnName("FabricIRMasterID");

            //    entity.Property(e => e.Gsm)
            //        .HasColumnName("GSM")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.QtyKg)
            //        .HasColumnName("QtyKG")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.QtyM).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.VariationId).HasColumnName("VariationID");

            //    entity.Property(e => e.Width).HasDefaultValueSql("(0)");

            //    entity.HasOne(d => d.FabricIrmaster)
            //        .WithMany(p => p.FabricIrdetail)
            //        .HasForeignKey(d => d.FabricIrmasterId)
            //        .HasConstraintName("FK_FabricIRDetail_FabricIRMaster");
            //});

            //modelBuilder.Entity<FabricIrmaster>(entity =>
            //{
            //    entity.ToTable("FabricIRMaster");

            //    entity.Property(e => e.FabricIrmasterId).HasColumnName("FabricIRMasterID");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Dated).HasColumnType("datetime");

            //    entity.Property(e => e.DocumentTypeId)
            //        .HasColumnName("DocumentTypeID")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.PickListParent).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.StockId).HasColumnName("StockID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<FinishingConfirmation>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("Finishing Confirmation");

            //    entity.Property(e => e.AssOrdId).HasColumnName("AssOrdID");

            //    entity.Property(e => e.AssignedOrderId).HasColumnName("AssignedOrderID");

            //    entity.Property(e => e.AssignedOrderNo)
            //        .IsRequired()
            //        .HasMaxLength(60)
            //        .IsUnicode(false);

            //    entity.Property(e => e.AssignedStyleId).HasColumnName("AssignedStyleID");

            //    entity.Property(e => e.AssignedStyleNo)
            //        .HasMaxLength(60)
            //        .IsUnicode(false);

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.ChallanNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.ConId).HasColumnName("ConID");

            //    entity.Property(e => e.ConfirmationId).HasColumnName("ConfirmationID");

            //    entity.Property(e => e.IssuanceMasterId).HasColumnName("IssuanceMasterID");

            //    entity.Property(e => e.PantoneNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<FlDocumentTypeSetup>(entity =>
            //{
            //    entity.HasKey(e => e.DocumentTypeId);

            //    entity.ToTable("FL_DocumentType_Setup");

            //    entity.Property(e => e.DocumentTypeId)
            //        .HasColumnName("DocumentTypeID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.DocumentName)
            //        .IsRequired()
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Initials)
            //        .HasMaxLength(10)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<FlStockTransaction>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("FL_StockTransaction");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.FabricColorId).HasColumnName("FabricColorID");

            //    entity.Property(e => e.JobTicketId)
            //        .HasColumnName("JobTicketID")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.PartialId)
            //        .HasColumnName("Partial_ID")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.PatternPieceId).HasColumnName("PatternPieceID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.StockTransactionId)
            //        .HasColumnName("StockTransactionID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<Flow2Jugar>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("Flow2_Jugar");

            //    entity.Property(e => e.ColorId)
            //        .HasColumnName("ColorID")
            //        .HasColumnType("numeric(9, 0)");

            //    entity.Property(e => e.ColorName)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.FlowRec).HasColumnType("numeric(38, 0)");

            //    entity.Property(e => e.OrderId)
            //        .HasColumnName("OrderID")
            //        .HasColumnType("numeric(18, 0)");

            //    entity.Property(e => e.OrderName)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SizeId)
            //        .HasColumnName("SizeID")
            //        .HasColumnType("numeric(9, 0)");

            //    entity.Property(e => e.StyleId)
            //        .HasColumnName("StyleID")
            //        .HasColumnType("numeric(18, 0)");

            //    entity.Property(e => e.StyleName)
            //        .HasMaxLength(301)
            //        .IsUnicode(false);

            //    entity.Property(e => e.TransType).HasColumnType("numeric(18, 0)");

            //    entity.Property(e => e.WorkCenterId)
            //        .HasColumnName("WorkCenterID")
            //        .HasColumnType("numeric(18, 0)");
            //});

            //modelBuilder.Entity<FlowBundleDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("FlowBundle_Detail");

            //    entity.HasIndex(e => new { e.MasterId, e.ColorId, e.SizeId, e.PatternPieceId })
            //        .HasName("FlowBundle_Detail_Index");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.DetailId)
            //        .HasColumnName("DetailID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.MasterId).HasColumnName("MasterID");

            //    entity.Property(e => e.PatternPieceId).HasColumnName("PatternPieceID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");
            //});

            //modelBuilder.Entity<FlowBundleMaster>(entity =>
            //{
            //    entity.ToTable("FlowBundle_Master");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.BundleId).HasColumnName("BundleID");

            //    entity.Property(e => e.BundleStatusId).HasColumnName("BundleStatusID");

            //    entity.Property(e => e.ReceivingMasterId).HasColumnName("ReceivingMasterID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<FlowIssuanceView>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("FlowIssuance_View");

            //    entity.Property(e => e.ChallanStatusId).HasColumnName("ChallanStatusID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.ColorName)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Dated).HasColumnType("datetime");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.IssuanceMasterId).HasColumnName("IssuanceMasterID");

            //    entity.Property(e => e.PatternPieceId).HasColumnName("PatternPieceID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.StockTransactionId).HasColumnName("StockTransactionID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<FlowReceivingView>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("FlowReceiving_View");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.Dated).HasColumnType("datetime");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.IssuanceMasterId).HasColumnName("IssuanceMasterID");

            //    entity.Property(e => e.PatternPieceId).HasColumnName("PatternPieceID");

            //    entity.Property(e => e.ReceivingChallanNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ReceivingMasterId).HasColumnName("ReceivingMasterID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<FsBundleCartDetail>(entity =>
            //{
            //    entity.ToTable("FS_BundleCart_Detail");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.BundleId).HasColumnName("BundleID");

            //    entity.Property(e => e.CartMasterId).HasColumnName("CartMasterID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.PatternPieceId).HasColumnName("PatternPieceID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.Status).HasDefaultValueSql("(0)");

            //    entity.HasOne(d => d.CartMaster)
            //        .WithMany(p => p.FsBundleCartDetail)
            //        .HasForeignKey(d => d.CartMasterId)
            //        .HasConstraintName("FK_FS_BundleCart_Detail_FS_BundleCart_Master");
            //});

            //modelBuilder.Entity<FsBundleCartMaster>(entity =>
            //{
            //    entity.HasKey(e => e.CartMasterId)
            //        .HasName("PK_FS_BundleCart");

            //    entity.ToTable("FS_BundleCart_Master");

            //    entity.Property(e => e.CartMasterId).HasColumnName("CartMasterID");

            //    entity.Property(e => e.Date).HasColumnType("datetime");

            //    entity.Property(e => e.Status).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<FsChallanStatusSetup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("FS_ChallanStatus_Setup");

            //    entity.Property(e => e.ChallanStatus)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ChallanStatusId).HasColumnName("ChallanStatusID");
            //});

            //modelBuilder.Entity<FsDocumentTypeSetup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("FS_DocumentType_Setup");

            //    entity.Property(e => e.DocumentName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");
            //});

            //modelBuilder.Entity<FsFabricMrpitemCode>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("FS_Fabric_MRPItemCode");

            //    entity.Property(e => e.FabricTypeId).HasColumnName("FabricTypeID");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");
            //});

            //modelBuilder.Entity<FsFabricShapedPieces>(entity =>
            //{
            //    entity.ToTable("FS_Fabric_ShapedPieces");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.FabricCategoryId).HasColumnName("FabricCategoryID");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");
            //});

            //modelBuilder.Entity<FsHoldingDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("FS_HoldingDetail");

            //    entity.Property(e => e.MasterId).HasColumnName("MasterID");
            //});

            //modelBuilder.Entity<FsHoldingMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("FS_HoldingMaster");

            //    entity.Property(e => e.BundleId).HasColumnName("BundleID");

            //    entity.Property(e => e.BundleNo).HasColumnName("BundleNO");

            //    entity.Property(e => e.ChallanId).HasColumnName("ChallanID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<FsIssuanceMaster>(entity =>
            //{
            //    entity.HasKey(e => e.IssuanceMasterId);

            //    entity.ToTable("FS_IssuanceMaster");

            //    entity.Property(e => e.IssuanceMasterId).HasColumnName("IssuanceMasterID");

            //    entity.Property(e => e.ChallanStatusId)
            //        .HasColumnName("ChallanStatusID")
            //        .HasDefaultValueSql("((1))");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(8000)
            //        .IsUnicode(false)
            //        .HasDefaultValueSql("('NO COMMENTS')");

            //    entity.Property(e => e.Dated).HasColumnType("datetime");

            //    entity.Property(e => e.IsReceived)
            //        .HasColumnName("isReceived")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.IssuanceChallanNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StitchingJobId).HasColumnName("StitchingJobID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<FsMiratHand>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("FS_MIRAtHand");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.Date).HasColumnType("datetime");

            //    entity.Property(e => e.FabricColorId).HasColumnName("FabricColorID");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.JobTicketId).HasColumnName("JobTicketID");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.PatternPieceId).HasColumnName("PatternPieceID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");
            //});

            //modelBuilder.Entity<FsReceivingMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("FS_ReceivingMaster");

            //    entity.Property(e => e.Comments).HasColumnType("ntext");

            //    entity.Property(e => e.Dated).HasColumnType("datetime");

            //    entity.Property(e => e.IssuanceMasterId).HasColumnName("IssuanceMasterID");

            //    entity.Property(e => e.ReceivingChallanNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ReceivingMasterId).HasColumnName("ReceivingMasterID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<FsRejectionRepository>(entity =>
            //{
            //    entity.HasKey(e => e.RejectionRepositoryId);

            //    entity.ToTable("FS_RejectionRepository");

            //    entity.Property(e => e.RejectionRepositoryId)
            //        .HasColumnName("RejectionRepositoryID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.ChallanId).HasColumnName("ChallanID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<FsRejectionRepositoryBalancingQty>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("FS_RejectionRepositoryBalancingQty");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.Int)
            //        .HasColumnName("int")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.RejectionRepositoryId).HasColumnName("RejectionRepositoryID");

            //    entity.Property(e => e.ReqSheetMasterId).HasColumnName("ReqSheetMasterID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<FsRejectionRepositoryDetail>(entity =>
            //{
            //    entity.HasKey(e => e.RejectionRepositoryDetailId);

            //    entity.ToTable("FS_RejectionRepositoryDetail");

            //    entity.Property(e => e.RejectionRepositoryDetailId).HasColumnName("RejectionRepositoryDetailID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.BundleId).HasColumnName("BundleID");

            //    entity.Property(e => e.Date).HasColumnType("datetime");

            //    entity.Property(e => e.PatternPieceId).HasColumnName("PatternPieceID");

            //    entity.Property(e => e.RejectionRepositoryId).HasColumnName("RejectionRepositoryID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.Property(e => e.WorkCenterId).HasColumnName("WorkCenterID");

            //    entity.HasOne(d => d.RejectionRepository)
            //        .WithMany(p => p.FsRejectionRepositoryDetail)
            //        .HasForeignKey(d => d.RejectionRepositoryId)
            //        .HasConstraintName("FK_FS_RejectionRepositoryDetail_FS_RejectionRepository");
            //});

            //modelBuilder.Entity<FsRejectionRepositoryReqSheetQty>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("FS_RejectionRepositoryReqSheetQty");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.RejectionRepositoryId).HasColumnName("RejectionRepositoryID");

            //    entity.Property(e => e.ReqSheetMasterId).HasColumnName("ReqSheetMasterID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<FsRejectionRepositoryStockLotQty>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("FS_RejectionRepositoryStockLotQty");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.RejectionRepositoryId).HasColumnName("RejectionRepositoryID");

            //    entity.Property(e => e.ReqSheetMasterId).HasColumnName("ReqSheetMasterID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<FsRejectionReqSheetMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("FS_RejectionReqSheetMaster");

            //    entity.Property(e => e.RejectionSfsmasterId)
            //        .HasColumnName("RejectionSFSMasterID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.RejectionSfsno)
            //        .IsRequired()
            //        .HasColumnName("RejectionSFSNo")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<FsRejectionSerialDetails>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("FS_RejectionSerialDetails");

            //    entity.Property(e => e.BundleId).HasColumnName("BundleID");

            //    entity.Property(e => e.PatternPieceId).HasColumnName("PatternPieceID");
            //});

            //modelBuilder.Entity<FsRgdAssociatedQty>(entity =>
            //{
            //    entity.ToTable("FS_RGD_AssociatedQty");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<FsStitchingDetail>(entity =>
            //{
            //    entity.HasKey(e => e.Id)
            //        .IsClustered(false);

            //    entity.ToTable("FS_Stitching_Detail");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.IsBarCode).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.MasterId).HasColumnName("MasterID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.HasOne(d => d.Master)
            //        .WithMany(p => p.FsStitchingDetail)
            //        .HasForeignKey(d => d.MasterId)
            //        .OnDelete(DeleteBehavior.Cascade)
            //        .HasConstraintName("FK_FS_Stitching_Detail_FS_Stitching_Master");
            //});

            //modelBuilder.Entity<FsStitchingMaster>(entity =>
            //{
            //    entity.HasKey(e => e.Id)
            //        .IsClustered(false);

            //    entity.ToTable("FS_Stitching_Master");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.BundleId).HasColumnName("BundleID");

            //    entity.Property(e => e.Rdate)
            //        .HasColumnName("RDate")
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.ReceivingMasterId).HasColumnName("ReceivingMasterID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<FsStockTransaction>(entity =>
            //{
            //    entity.HasKey(e => e.StockTransactionId)
            //        .HasName("PK_FS_StockTransaction1")
            //        .IsClustered(false);

            //    entity.ToTable("FS_StockTransaction");

            //    entity.HasIndex(e => e.StockTransactionId);

            //    entity.HasIndex(e => new { e.DocumentTypeId, e.DocumentNo, e.AttributeInstanceId, e.ColorId, e.SizeId, e.PatternPieceId, e.FabricColorId, e.BundleId })
            //        .HasName("IND_FS_StockTransaction");

            //    entity.Property(e => e.StockTransactionId).HasColumnName("StockTransactionID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.BundleId).HasColumnName("BundleID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.FabricColorId).HasColumnName("FabricColorID");

            //    entity.Property(e => e.PatternPieceId).HasColumnName("PatternPieceID");

            //    entity.Property(e => e.QualityId)
            //        .HasColumnName("QualityID")
            //        .HasDefaultValueSql("((1))");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");
            //});

            //modelBuilder.Entity<FsTicketStatus>(entity =>
            //{
            //    entity.ToTable("FS_TicketStatus");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<IdentificationSetup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Identification_Setup");

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.IdentificationId).HasColumnName("IdentificationID");
            //});

            //modelBuilder.Entity<InpectionDepartment>(entity =>
            //{
            //    entity.HasKey(e => e.InspectionDepartmentId);

            //    entity.Property(e => e.InspectionDepartmentId).HasColumnName("InspectionDepartmentID");

            //    entity.Property(e => e.InspectionDepartmentName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<InpectionParameterDepartment>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.Property(e => e.InspectionDepartmentId).HasColumnName("InspectionDepartmentID");

            //    entity.Property(e => e.InspectionParameterId).HasColumnName("InspectionParameterID");

            //    entity.HasOne(d => d.InspectionDepartment)
            //        .WithMany(p => p.InpectionParameterDepartment)
            //        .HasForeignKey(d => d.InspectionDepartmentId)
            //        .HasConstraintName("FK_InpectionParameterDepartment_InpectionDepartment");

            //    entity.HasOne(d => d.InspectionParameter)
            //        .WithMany(p => p.InpectionParameterDepartment)
            //        .HasForeignKey(d => d.InspectionParameterId)
            //        .HasConstraintName("FK_InpectionParameterDepartment_InspectionParameter");
            //});

            //modelBuilder.Entity<InspectionParameter>(entity =>
            //{
            //    entity.Property(e => e.InspectionParameterId).HasColumnName("InspectionParameterID");

            //    entity.Property(e => e.InspectionParameterName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<IssuanceDetail>(entity =>
            //{
            //    entity.Property(e => e.IssuanceDetailId).HasColumnName("IssuanceDetailID");

            //    entity.Property(e => e.AttributeInstanceId)
            //        .HasColumnName("AttributeInstanceID")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.IssuanceMasterId).HasColumnName("IssuanceMasterID");

            //    entity.Property(e => e.ShellColorId)
            //        .HasColumnName("ShellColorID")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");
            //});

            //modelBuilder.Entity<IssuanceMaster>(entity =>
            //{
            //    entity.Property(e => e.IssuanceMasterId).HasColumnName("IssuanceMasterID");

            //    entity.Property(e => e.Comments)
            //        .IsRequired()
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Dated).HasColumnType("datetime");

            //    entity.Property(e => e.IssuanceChallanNo)
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.IssuanceFrom).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.JobTicketId).HasColumnName("JobTicketID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<JobStatus>(entity =>
            //{
            //    entity.HasKey(e => e.StatusId);

            //    entity.Property(e => e.StatusId)
            //        .HasColumnName("StatusID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<JobTicket>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.Property(e => e.CadcamjobId).HasColumnName("CADCAMJobID");

            //    entity.Property(e => e.CuttingMachineId).HasColumnName("CuttingMachineID");

            //    entity.Property(e => e.EndMinuteId).HasColumnName("EndMinuteID");

            //    entity.Property(e => e.FabricDetailId).HasColumnName("FabricDetailID");

            //    entity.Property(e => e.JobTicketId)
            //        .HasColumnName("JobTicketID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.RangeId).HasColumnName("RangeID");

            //    entity.Property(e => e.SpreadingMachineId).HasColumnName("SpreadingMachineID");

            //    entity.Property(e => e.StartMinuteId).HasColumnName("StartMinuteID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.TableId).HasColumnName("TableID");

            //    entity.Property(e => e.WcdayId).HasColumnName("WCDayID");
            //});

            //modelBuilder.Entity<KnittingCreatedJobsDeleteLog>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("KnittingCreatedJobs_Delete_Log");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.DeletionDate).HasColumnType("datetime");

            //    entity.Property(e => e.EndingDayMinuteId).HasColumnName("EndingDayMinuteID");

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.JobName)
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.JobStatusId).HasColumnName("JobStatusID");

            //    entity.Property(e => e.MachineId).HasColumnName("MachineID");

            //    entity.Property(e => e.StartingDayMinuteId).HasColumnName("StartingDayMinuteID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.Property(e => e.YarnKnittingContractId).HasColumnName("YarnKnittingContractID");
            //});

            //modelBuilder.Entity<KnittingIssuanceDeleteLog>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("KnittingIssuance_Delete_Log");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DeletionDate).HasColumnType("datetime");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.Gsm).HasColumnName("GSM");

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.RollId).HasColumnName("RollID");

            //    entity.Property(e => e.StockTransactionId).HasColumnName("StockTransactionID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<KnittingMachineJobsDeleteLog>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("KnittingMachineJobs_Delete_Log");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DayMinuteId).HasColumnName("DayMinuteID");

            //    entity.Property(e => e.DeletionDate).HasColumnType("datetime");

            //    entity.Property(e => e.KnittingJobId).HasColumnName("KnittingJobID");

            //    entity.Property(e => e.LoadId).HasColumnName("LoadID");

            //    entity.Property(e => e.MachineId).HasColumnName("MachineID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<KnittingNeedleBreakage>(entity =>
            //{
            //    entity.HasKey(e => e.BreakageId);

            //    entity.ToTable("Knitting_NeedleBreakage");

            //    entity.Property(e => e.BreakageId).HasColumnName("Breakage_ID");

            //    entity.Property(e => e.BreakageCompanyId).HasColumnName("Breakage_CompanyID");

            //    entity.Property(e => e.BreakageDate)
            //        .HasColumnName("Breakage_Date")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.BreakageItemId).HasColumnName("Breakage_ItemID");

            //    entity.Property(e => e.BreakageQty).HasColumnName("Breakage_Qty");

            //    entity.Property(e => e.BreakageShift)
            //        .HasColumnName("Breakage_Shift")
            //        .HasMaxLength(1)
            //        .IsUnicode(false);

            //    entity.Property(e => e.BreakageUser).HasColumnName("Breakage_User");

            //    entity.Property(e => e.Machineno).HasColumnName("MACHINENO");
            //});

            //modelBuilder.Entity<KnittingNeedleBreakage1>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Knitting_NeedleBreakage_1");

            //    entity.Property(e => e.BreakageCompanyId).HasColumnName("Breakage_CompanyID");

            //    entity.Property(e => e.BreakageDate)
            //        .HasColumnName("Breakage_Date")
            //        .HasColumnType("smalldatetime");

            //    entity.Property(e => e.BreakageId)
            //        .HasColumnName("Breakage_ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.BreakageItemId).HasColumnName("Breakage_ItemID");

            //    entity.Property(e => e.BreakageQty).HasColumnName("Breakage_Qty");

            //    entity.Property(e => e.BreakageShift)
            //        .HasColumnName("Breakage_Shift")
            //        .HasMaxLength(1)
            //        .IsUnicode(false);

            //    entity.Property(e => e.BreakageUser).HasColumnName("Breakage_User");

            //    entity.Property(e => e.Machineno).HasColumnName("MACHINENO");
            //});

            //modelBuilder.Entity<KnittingPickListDeleteLog>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("KnittingPickList_Delete_Log");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.BatchDescription)
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.DeletionDate).HasColumnType("datetime");

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.PickListDetailId).HasColumnName("PickListDetailID");

            //    entity.Property(e => e.PickListId).HasColumnName("PickListID");

            //    entity.Property(e => e.PickListNo)
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ReceivingPersonName)
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.Property(e => e.YarnKnittingContractId).HasColumnName("YarnKnittingContractID");

            //    entity.Property(e => e.YarnReceivingDate).HasColumnType("datetime");
            //});

            //modelBuilder.Entity<KnittingRollAttributesDeleteLog>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("KnittingRollAttributes_Delete_Log");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DeletionDate).HasColumnType("datetime");

            //    entity.Property(e => e.RollAttrDesc)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.RollAttrId).HasColumnName("RollAttrID");

            //    entity.Property(e => e.RollAttrSetupId).HasColumnName("RollAttrSetupID");

            //    entity.Property(e => e.RollId).HasColumnName("RollID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<KnittingRollsInspectionDeleteLog>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("KnittingRollsInspection_Delete_Log");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DeletionDate).HasColumnType("datetime");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.Gsm).HasColumnName("GSM");

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.RollId).HasColumnName("RollID");

            //    entity.Property(e => e.StockTransactionId).HasColumnName("StockTransactionID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<KnittingStockTransactionDeleteLog>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("KnittingStockTransaction_Delete_Log");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DeletionDate).HasColumnType("datetime");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.Gsm).HasColumnName("GSM");

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.RollId).HasColumnName("RollID");

            //    entity.Property(e => e.StockTransactionId).HasColumnName("StockTransactionID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<KnittingSubPickListDeleteLog>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("KnittingSubPickList_Delete_Log");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.BatchDescription)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.DeletionDate).HasColumnType("datetime");

            //    entity.Property(e => e.MasterPickListId).HasColumnName("MasterPickListID");

            //    entity.Property(e => e.ReceivingPersonName)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SubPickListDetailId).HasColumnName("SubPickListDetailID");

            //    entity.Property(e => e.SubPickListId).HasColumnName("SubPickListID");

            //    entity.Property(e => e.SubPickListNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.Property(e => e.YarnReceivingDate).HasColumnType("datetime");
            //});

            //modelBuilder.Entity<KnittingYarnAssignmentDeleteLog>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("KnittingYarnAssignment_Delete_Log");

            //    entity.Property(e => e.AssignmentDate).HasColumnType("datetime");

            //    entity.Property(e => e.AssignmentId).HasColumnName("AssignmentID");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DeletionDate).HasColumnType("datetime");

            //    entity.Property(e => e.SubPickListId).HasColumnName("SubPickListID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.Property(e => e.YarnKncontractId).HasColumnName("YarnKNContractID");
            //});

            //modelBuilder.Entity<MachineOperation>(entity =>
            //{
            //    entity.Property(e => e.MachineOperationId).HasColumnName("MachineOperationID");

            //    entity.Property(e => e.FabricTypeId).HasColumnName("FabricTypeID");

            //    entity.Property(e => e.MachineTypeId).HasColumnName("MachineTypeID");

            //    entity.Property(e => e.OperationId).HasColumnName("OperationID");

            //    entity.HasOne(d => d.MachineType)
            //        .WithMany(p => p.MachineOperation)
            //        .HasForeignKey(d => d.MachineTypeId)
            //        .HasConstraintName("FK_MachineOperation_CuttingMachineType");

            //    entity.HasOne(d => d.Operation)
            //        .WithMany(p => p.MachineOperation)
            //        .HasForeignKey(d => d.OperationId)
            //        .HasConstraintName("FK_MachineOperation_CuttingOperation");
            //});

            //modelBuilder.Entity<Mar2016BlockList>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.Property(e => e.DeptCd)
            //        .HasColumnName("Dept_Cd")
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.EmpAccount)
            //        .HasColumnName("Emp_Account")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EmpAcode1)
            //        .HasColumnName("Emp_Acode1")
            //        .HasMaxLength(3)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.EmpAcode2)
            //        .HasColumnName("Emp_Acode2")
            //        .HasMaxLength(3)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.EmpAcode3)
            //        .HasColumnName("Emp_Acode3")
            //        .HasMaxLength(3)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.EmpActive).HasColumnName("Emp_Active");

            //    entity.Property(e => e.EmpAddress1)
            //        .HasColumnName("Emp_Address1")
            //        .HasMaxLength(700)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EmpAddress2)
            //        .HasColumnName("Emp_Address2")
            //        .HasMaxLength(700)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EmpAppointment)
            //        .HasColumnName("Emp_Appointment")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.EmpApproved)
            //        .HasColumnName("Emp_Approved")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EmpAttAllow).HasColumnName("Emp_AttAllow");

            //    entity.Property(e => e.EmpAttType)
            //        .HasColumnName("Emp_AttType")
            //        .HasMaxLength(10)
            //        .IsFixedLength();

            //    entity.Property(e => e.EmpBank).HasColumnName("Emp_Bank");

            //    entity.Property(e => e.EmpBankId).HasColumnName("Emp_BankID");

            //    entity.Property(e => e.EmpBlockDate)
            //        .HasColumnName("Emp_BlockDate")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.EmpBlockReason)
            //        .HasColumnName("Emp_BlockReason")
            //        .IsUnicode(false);

            //    entity.Property(e => e.EmpBlocked).HasColumnName("Emp_Blocked");

            //    entity.Property(e => e.EmpBname)
            //        .HasColumnName("Emp_Bname")
            //        .HasMaxLength(4000);

            //    entity.Property(e => e.EmpCashPayroll).HasColumnName("Emp_CashPayroll");

            //    entity.Property(e => e.EmpCd)
            //        .IsRequired()
            //        .HasColumnName("Emp_Cd")
            //        .HasMaxLength(6)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.EmpCitizen)
            //        .HasColumnName("Emp_Citizen")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EmpCity1)
            //        .HasColumnName("Emp_City1")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EmpCity2)
            //        .HasColumnName("Emp_City2")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EmpCmail)
            //        .HasColumnName("Emp_CMail")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EmpCompany).HasColumnName("Emp_Company");

            //    entity.Property(e => e.EmpConfirmation)
            //        .HasColumnName("Emp_Confirmation")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.EmpCountry1).HasColumnName("Emp_Country1");

            //    entity.Property(e => e.EmpCountry2).HasColumnName("Emp_Country2");

            //    entity.Property(e => e.EmpCreated)
            //        .HasColumnName("Emp_Created")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.EmpDeleted).HasColumnName("Emp_Deleted");

            //    entity.Property(e => e.EmpDept).HasColumnName("Emp_Dept");

            //    entity.Property(e => e.EmpDesignation).HasColumnName("Emp_Designation");

            //    entity.Property(e => e.EmpDob)
            //        .HasColumnName("Emp_DOB")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.EmpDocType)
            //        .HasColumnName("emp_docType")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EmpEmail)
            //        .HasColumnName("Emp_Email")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EmpEobiDeduction)
            //        .HasColumnName("Emp_EOBI_Deduction")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EmpExt)
            //        .HasColumnName("Emp_Ext")
            //        .HasMaxLength(5)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EmpFather)
            //        .HasColumnName("Emp_Father")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EmpFingerPrintCd).HasColumnName("Emp_FingerPrintCD");

            //    entity.Property(e => e.EmpFname)
            //        .HasColumnName("Emp_Fname")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EmpGender)
            //        .HasColumnName("Emp_Gender")
            //        .HasMaxLength(100)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.EmpGross).HasColumnName("Emp_Gross");

            //    entity.Property(e => e.EmpHalfdayallowed).HasColumnName("Emp_halfdayallowed");

            //    entity.Property(e => e.EmpId).HasColumnName("Emp_ID");

            //    entity.Property(e => e.EmpIncOt).HasColumnName("Emp_IncOT");

            //    entity.Property(e => e.EmpIncentives).HasColumnName("Emp_Incentives");

            //    entity.Property(e => e.EmpInterviewNo)
            //        .HasColumnName("Emp_InterviewNo")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EmpInterviewed)
            //        .HasColumnName("Emp_Interviewed")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EmpLcountry).HasColumnName("Emp_LCountry");

            //    entity.Property(e => e.EmpLegacyCategory)
            //        .HasColumnName("Emp_LegacyCategory")
            //        .HasMaxLength(10)
            //        .IsFixedLength();

            //    entity.Property(e => e.EmpLegacyType).HasColumnName("Emp_LegacyType");

            //    entity.Property(e => e.EmpLexpiry)
            //        .HasColumnName("Emp_LExpiry")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.EmpLicense)
            //        .HasColumnName("Emp_License")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EmpLissue)
            //        .HasColumnName("Emp_LIssue")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.EmpLname)
            //        .HasColumnName("Emp_Lname")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EmpMarital).HasColumnName("Emp_Marital");

            //    entity.Property(e => e.EmpMname)
            //        .HasColumnName("Emp_Mname")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EmpMobile)
            //        .HasColumnName("Emp_Mobile")
            //        .HasMaxLength(100)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.EmpMotherName)
            //        .HasColumnName("Emp_MotherName")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EmpName)
            //        .HasColumnName("Emp_Name")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EmpNicexp)
            //        .HasColumnName("Emp_NICExp")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.EmpOldNo)
            //        .HasColumnName("Emp_oldNo")
            //        .HasMaxLength(25)
            //        .IsFixedLength();

            //    entity.Property(e => e.EmpOldnoNumeric).HasColumnName("Emp_OldnoNumeric");

            //    entity.Property(e => e.EmpOt).HasColumnName("Emp_OT");

            //    entity.Property(e => e.EmpPayroll).HasColumnName("Emp_Payroll");

            //    entity.Property(e => e.EmpPermanentlyBlocked).HasColumnName("Emp_PermanentlyBlocked");

            //    entity.Property(e => e.EmpPf).HasColumnName("Emp_PF");

            //    entity.Property(e => e.EmpPlaceofBirth)
            //        .HasColumnName("Emp_PlaceofBirth")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EmpProximity)
            //        .HasColumnName("Emp_Proximity")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EmpRace)
            //        .HasColumnName("Emp_Race")
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.EmpReligion).HasColumnName("Emp_Religion");

            //    entity.Property(e => e.EmpRestDay)
            //        .HasColumnName("Emp_RestDay")
            //        .HasMaxLength(10)
            //        .IsFixedLength();

            //    entity.Property(e => e.EmpRoute).HasColumnName("Emp_Route");

            //    entity.Property(e => e.EmpSalary).HasColumnName("Emp_Salary");

            //    entity.Property(e => e.EmpSalaryStructure).HasColumnName("Emp_SalaryStructure");

            //    entity.Property(e => e.EmpSalutation)
            //        .HasColumnName("Emp_Salutation")
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EmpSect)
            //        .HasColumnName("Emp_Sect")
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.EmpSection).HasColumnName("Emp_Section");

            //    entity.Property(e => e.EmpShift).HasColumnName("Emp_Shift");

            //    entity.Property(e => e.EmpSsn)
            //        .HasColumnName("Emp_SSN")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EmpSsn2)
            //        .HasColumnName("Emp_SSN2")
            //        .HasMaxLength(50);

            //    entity.Property(e => e.EmpSsnDeduction)
            //        .HasColumnName("Emp_SSN_Deduction")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EmpState1)
            //        .HasColumnName("Emp_State1")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EmpState2)
            //        .HasColumnName("Emp_State2")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EmpTaxDed).HasColumnName("Emp_TaxDed");

            //    entity.Property(e => e.EmpTel1)
            //        .HasColumnName("Emp_Tel1")
            //        .HasMaxLength(100)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.EmpTel2)
            //        .HasColumnName("Emp_Tel2")
            //        .HasMaxLength(20)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.EmpTel3)
            //        .HasColumnName("Emp_Tel3")
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.EmpType).HasColumnName("emp_type");

            //    entity.Property(e => e.EmpUser)
            //        .HasColumnName("Emp_User")
            //        .HasMaxLength(10)
            //        .IsFixedLength();

            //    entity.Property(e => e.EmpZip1)
            //        .HasColumnName("Emp_Zip1")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EmpZip2)
            //        .HasColumnName("Emp_Zip2")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.NighAllowance).HasColumnName("nighAllowance");

            //    entity.Property(e => e.SecCd)
            //        .HasColumnName("Sec_CD")
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .IsFixedLength();
            //});

            //modelBuilder.Entity<Matched>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.Comments).HasMaxLength(255);

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.Length).HasMaxLength(255);

            //    entity.Property(e => e.MachineId).HasColumnName("MachineID");

            //    entity.Property(e => e.NoOfPieces).HasMaxLength(255);

            //    entity.Property(e => e.OrderId)
            //        .HasColumnName("OrderID")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.ProgramTypeId).HasColumnName("ProgramTypeID");

            //    entity.Property(e => e.QualityId).HasColumnName("QualityID");

            //    entity.Property(e => e.RateWrtbaseUnit).HasColumnName("Rate_WRTBaseUnit");

            //    entity.Property(e => e.RollId).HasColumnName("RollID");

            //    entity.Property(e => e.RollNo).HasMaxLength(255);

            //    entity.Property(e => e.Rollnonew).HasColumnName("rollnonew");

            //    entity.Property(e => e.Rollnop)
            //        .HasColumnName("rollnop")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.SNo).HasColumnName("S#no");

            //    entity.Property(e => e.Skuunit).HasColumnName("SKUUnit");

            //    entity.Property(e => e.StockTransactionId).HasColumnName("StockTransactionID");

            //    entity.Property(e => e.StoreLocationId).HasColumnName("StoreLocationID");

            //    entity.Property(e => e.StyleId)
            //        .HasColumnName("StyleID")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.TrDate)
            //        .HasColumnName("tr_date")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.TransactionDate).HasColumnType("datetime");

            //    entity.Property(e => e.Width).HasMaxLength(255);

            //    entity.Property(e => e.Ykncid).HasColumnName("YKNCID");
            //});

            //modelBuilder.Entity<MinuteTime>(entity =>
            //{
            //    entity.HasKey(e => e.MinuteId);

            //    entity.Property(e => e.MinuteId)
            //        .HasColumnName("MinuteID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.DayMinute).HasColumnType("datetime");

            //    entity.Property(e => e.MinuteTypeId).HasColumnName("MinuteTypeID");

            //    entity.HasOne(d => d.MinuteType)
            //        .WithMany(p => p.MinuteTime)
            //        .HasForeignKey(d => d.MinuteTypeId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_MinuteTime_MinuteType");
            //});

            //modelBuilder.Entity<MinuteType>(entity =>
            //{
            //    entity.Property(e => e.MinuteTypeId)
            //        .HasColumnName("MinuteTypeID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.MinuteTypeDescription)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.MinuteTypeName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<MyTable>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.Property(e => e.DayMinute).HasColumnType("datetime");

            //    entity.Property(e => e.MinuteId).HasColumnName("MinuteID");

            //    entity.Property(e => e.MinuteTypeId).HasColumnName("MinuteTypeID");
            //});

            //modelBuilder.Entity<PpSpare>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("PP_Spare");

            //    entity.Property(e => e.FabricType)
            //        .IsRequired()
            //        .HasMaxLength(30)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.FabricTypeId).HasColumnName("FabricTypeID");

            //    entity.Property(e => e.PatternPiece)
            //        .IsRequired()
            //        .HasMaxLength(30)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.PatternPieceId).HasColumnName("PatternPieceID");
            //});

            //modelBuilder.Entity<PrintingInspectionDetails>(entity =>
            //{
            //    entity.HasKey(e => e.PrintingInspectionDetailId);

            //    entity.Property(e => e.PrintingInspectionDetailId).HasColumnName("PrintingInspectionDetailID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.PrintingInspectionMasterId).HasColumnName("PrintingInspectionMasterID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.HasOne(d => d.PrintingInspectionMaster)
            //        .WithMany(p => p.PrintingInspectionDetails)
            //        .HasForeignKey(d => d.PrintingInspectionMasterId)
            //        .HasConstraintName("FK_PrintingInspectionDetails_PrintingInspectionMaster");
            //});

            //modelBuilder.Entity<PrintingInspectionMaster>(entity =>
            //{
            //    entity.Property(e => e.PrintingInspectionMasterId).HasColumnName("PrintingInspectionMasterID");

            //    entity.Property(e => e.Dated).HasColumnType("datetime");

            //    entity.Property(e => e.PrintingSpecificationId).HasColumnName("PrintingSpecificationID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<PrintingIssuanceDetail>(entity =>
            //{
            //    entity.Property(e => e.PrintingIssuanceDetailId)
            //        .HasColumnName("PrintingIssuanceDetailID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.PrintingJobId).HasColumnName("PrintingJobID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.HasOne(d => d.PrintingJob)
            //        .WithMany(p => p.PrintingIssuanceDetail)
            //        .HasForeignKey(d => d.PrintingJobId)
            //        .HasConstraintName("FK_PrintingIssuanceDetail_PrintingIssuanceMaster");
            //});

            //modelBuilder.Entity<PrintingIssuanceMaster>(entity =>
            //{
            //    entity.HasKey(e => e.PrintingJobId);

            //    entity.Property(e => e.PrintingJobId)
            //        .HasColumnName("PrintingJobID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.Dated).HasColumnType("datetime");

            //    entity.Property(e => e.PrintingSpecificationId).HasColumnName("PrintingSpecificationID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<PrintingReceivingDetail>(entity =>
            //{
            //    entity.HasKey(e => e.EmrbroideryReceivingDetailId);

            //    entity.Property(e => e.EmrbroideryReceivingDetailId).HasColumnName("EmrbroideryReceivingDetailID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.PrintingMasterId).HasColumnName("PrintingMasterID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.HasOne(d => d.PrintingMaster)
            //        .WithMany(p => p.PrintingReceivingDetail)
            //        .HasForeignKey(d => d.PrintingMasterId)
            //        .HasConstraintName("FK_PrintingReceivingDetail_PrintingReceivingMaster");
            //});

            //modelBuilder.Entity<PrintingReceivingMaster>(entity =>
            //{
            //    entity.Property(e => e.PrintingReceivingMasterId).HasColumnName("PrintingReceivingMasterID");

            //    entity.Property(e => e.Dated).HasColumnType("datetime");

            //    entity.Property(e => e.PrintingSpecificationId).HasColumnName("PrintingSpecificationID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<RangeCalculation>(entity =>
            //{
            //    entity.HasKey(e => e.RangeSetupId);

            //    entity.Property(e => e.RangeSetupId).HasColumnName("RangeSetupID");

            //    entity.Property(e => e.CuttingMachineFamId).HasColumnName("CuttingMachine_FAM_ID");

            //    entity.Property(e => e.FabricTypeId).HasColumnName("FabricTypeID");

            //    entity.Property(e => e.Gsm).HasColumnName("GSM");

            //    entity.HasOne(d => d.CuttingMachineFam)
            //        .WithMany(p => p.RangeCalculation)
            //        .HasForeignKey(d => d.CuttingMachineFamId)
            //        .HasConstraintName("FK_RangeCalculation_CuttingMachineType");
            //});

            //modelBuilder.Entity<ReceivingDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.Property(e => e.AttributeInstanceId)
            //        .HasColumnName("AttributeInstanceID")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.ReceivingDetailId)
            //        .HasColumnName("ReceivingDetailID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.ReceivingMasterId).HasColumnName("ReceivingMasterID");

            //    entity.Property(e => e.ShellColorId)
            //        .HasColumnName("ShellColorID")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");
            //});

            //modelBuilder.Entity<ReceivingMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Dated).HasColumnType("datetime");

            //    entity.Property(e => e.IssuanceMasterId)
            //        .HasColumnName("IssuanceMasterID")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.JobTicketId).HasColumnName("JobTicketID");

            //    entity.Property(e => e.ReceivedBy).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.ReceivingChallanNo)
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.ReceivingMasterId).HasColumnName("ReceivingMasterID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<ResourceGroup>(entity =>
            //{
            //    entity.Property(e => e.ResourceGroupId).HasColumnName("ResourceGroupID");

            //    entity.Property(e => e.CuttingMachineInstanceId).HasColumnName("CuttingMachineInstanceID");

            //    entity.Property(e => e.SpreadingMachineInstanceId).HasColumnName("SpreadingMachineInstanceID");

            //    entity.Property(e => e.TableId).HasColumnName("TableID");

            //    entity.HasOne(d => d.CuttingMachineInstance)
            //        .WithMany(p => p.ResourceGroup)
            //        .HasForeignKey(d => d.CuttingMachineInstanceId)
            //        .HasConstraintName("FK_ResouceGroup_CuttingMachineInstance");

            //    entity.HasOne(d => d.SpreadingMachineInstance)
            //        .WithMany(p => p.ResourceGroup)
            //        .HasForeignKey(d => d.SpreadingMachineInstanceId)
            //        .HasConstraintName("FK_ResouceGroup_SpreaderInstance");
            //});

            //modelBuilder.Entity<ResourceState>(entity =>
            //{
            //    entity.HasKey(e => e.StateId);

            //    entity.Property(e => e.StateId)
            //        .HasColumnName("StateID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.StateDescription)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StateName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<Rework>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("Rework");

            //    entity.Property(e => e.BarcodeNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ConfirmationId).HasColumnName("ConfirmationID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<RollDefectDetail>(entity =>
            //{
            //    entity.ToTable("Roll_Defect_Detail");

            //    entity.Property(e => e.RollDefectDetailId).HasColumnName("Roll_Defect_Detail_ID");

            //    entity.Property(e => e.DefectDirection)
            //        .HasColumnName("Defect_Direction")
            //        .HasMaxLength(30)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DefectStartFrom).HasColumnName("Defect_Start_from");

            //    entity.Property(e => e.DfsRollInspectionAttributeId).HasColumnName("DFS_Roll_InspectionAttribute_ID");

            //    entity.Property(e => e.ProcessId).HasColumnName("Process_ID");
            //});

            //modelBuilder.Entity<RollTrack>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("Roll_Track");

            //    entity.Property(e => e.RollCode)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.RollId).HasColumnName("RollID");

            //    entity.Property(e => e.YarnKnittingContractId).HasColumnName("YarnKnittingContractID");
            //});

            //modelBuilder.Entity<SfsAuditDetail>(entity =>
            //{
            //    entity.ToTable("SFS_Audit_Detail");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.AuditMasterId).HasColumnName("AuditMasterID");

            //    entity.Property(e => e.DefGarBackImg)
            //        .HasColumnName("Def_Gar_BackImg")
            //        .HasColumnType("image");

            //    entity.Property(e => e.DefGarFrontImg)
            //        .IsRequired()
            //        .HasColumnName("Def_Gar_FrontImg")
            //        .HasColumnType("image");

            //    entity.HasOne(d => d.AuditMaster)
            //        .WithMany(p => p.SfsAuditDetail)
            //        .HasForeignKey(d => d.AuditMasterId)
            //        .HasConstraintName("FK_SFS_Audit_Detail_SFS_Audit_Master");
            //});

            //modelBuilder.Entity<SfsAuditGarmentStatusSetup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("SFS_Audit_GarmentStatus_Setup");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Id).HasColumnName("ID");
            //});

            //modelBuilder.Entity<SfsAuditMaster>(entity =>
            //{
            //    entity.ToTable("SFS_Audit_Master");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.AuditId).HasColumnName("AuditID");

            //    entity.Property(e => e.Barcode)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Color)
            //        .IsRequired()
            //        .HasMaxLength(3)
            //        .IsUnicode(false);

            //    entity.Property(e => e.GarmentStatusId).HasColumnName("GarmentStatusID");

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.Order)
            //        .IsRequired()
            //        .HasMaxLength(25)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Size)
            //        .IsRequired()
            //        .HasMaxLength(3)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Style)
            //        .IsRequired()
            //        .HasMaxLength(25)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.TransactionDate)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.HasOne(d => d.Audit)
            //        .WithMany(p => p.SfsAuditMaster)
            //        .HasForeignKey(d => d.AuditId)
            //        .OnDelete(DeleteBehavior.Cascade)
            //        .HasConstraintName("FK_SFS_Audit_Master_SFS_ConfirmationNAudit_Association");
            //});

            //modelBuilder.Entity<SfsBayHeadSetup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("SFS_BayHead_Setup");

            //    entity.Property(e => e.FabricCategoryId).HasColumnName("FabricCategoryID");

            //    entity.Property(e => e.HeadUserId).HasColumnName("HeadUserID");
            //});

            //modelBuilder.Entity<SfsConfirmationNauditAssociation>(entity =>
            //{
            //    entity.HasKey(e => e.AuditId);

            //    entity.ToTable("SFS_ConfirmationNAudit_Association");

            //    entity.Property(e => e.AuditId).HasColumnName("AuditID");

            //    entity.Property(e => e.AuditApprovalDate).HasColumnType("datetime");

            //    entity.Property(e => e.AuditComments).HasColumnType("ntext");

            //    entity.Property(e => e.AuditDate).HasColumnType("datetime");

            //    entity.Property(e => e.ConfirmationId).HasColumnName("ConfirmationID");

            //    entity.Property(e => e.UserId)
            //        .HasColumnName("UserID")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.HasOne(d => d.Confirmation)
            //        .WithMany(p => p.SfsConfirmationNauditAssociation)
            //        .HasForeignKey(d => d.ConfirmationId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_SFS_ConfirmationNAudit_Association_SFS_JobConfirmation");
            //});

            //modelBuilder.Entity<SfsCpsLoad>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("sfs_CpsLoad");

            //    entity.Property(e => e.Colorid).HasColumnName("colorid");

            //    entity.Property(e => e.Cpsid).HasColumnName("CPSID");

            //    entity.Property(e => e.Creationdate)
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Endtime)
            //        .HasColumnName("endtime")
            //        .HasColumnType("smalldatetime");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Lineid).HasColumnName("lineid");

            //    entity.Property(e => e.Orderid).HasColumnName("orderid");

            //    entity.Property(e => e.Starttime)
            //        .HasColumnName("starttime")
            //        .HasColumnType("smalldatetime");

            //    entity.Property(e => e.Status).HasColumnName("STATUS");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.Target).HasColumnName("TARGET");

            //    entity.Property(e => e.Userid).HasColumnName("userid");
            //});

            //modelBuilder.Entity<SfsCpsLoadHistory>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("SFS_CpsLoadHistory");

            //    entity.Property(e => e.ChainProcessSetupId).HasColumnName("ChainProcessSetupID");

            //    entity.Property(e => e.ClhId)
            //        .HasColumnName("clh_id")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Creationdate)
            //        .HasColumnName("creationdate")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Emloyeeid).HasColumnName("emloyeeid");

            //    entity.Property(e => e.Machineid).HasColumnName("machineid");

            //    entity.Property(e => e.Sequence).HasColumnName("sequence");

            //    entity.Property(e => e.Varsionno).HasColumnName("varsionno");

            //    entity.Property(e => e.Workid).HasColumnName("workid");
            //});

            //modelBuilder.Entity<SfsDocumentType>(entity =>
            //{
            //    entity.HasKey(e => e.DocumentTypeId);

            //    entity.ToTable("SFS_DocumentType");

            //    entity.Property(e => e.DocumentTypeId)
            //        .HasColumnName("DocumentTypeID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.DocumentDescription)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DocumentName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Initials)
            //        .IsRequired()
            //        .HasMaxLength(5)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<SfsEmpOfflineAllocationMaster>(entity =>
            //{
            //    entity.ToTable("SFS_EMP_Offline_Allocation_Master");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ChainOperationSetupId).HasColumnName("ChainOperationSetupID");

            //    entity.Property(e => e.CreateDate)
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.GeversionNo).HasColumnName("GEVersionNo");

            //    entity.Property(e => e.Prsid).HasColumnName("PRSID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<SfsEmpOfflineDetail>(entity =>
            //{
            //    entity.ToTable("SFS_EMP_Offline_Detail");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.AllocationId).HasColumnName("AllocationID");

            //    entity.Property(e => e.DesignationId).HasColumnName("DesignationID");

            //    entity.Property(e => e.OperatorId).HasColumnName("OperatorID");

            //    entity.Property(e => e.PunchTime).HasColumnType("datetime");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");

            //    entity.HasOne(d => d.Allocation)
            //        .WithMany(p => p.SfsEmpOfflineDetail)
            //        .HasForeignKey(d => d.AllocationId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_SFS_EMP_Offline_Detail_SFS_EMP_Offline_Allocation_Master");
            //});

            //modelBuilder.Entity<SfsEmployeeLineAllocation>(entity =>
            //{
            //    entity.ToTable("SFS_EmployeeLineAllocation");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.AllocationDate).HasColumnType("datetime");

            //    entity.Property(e => e.ChainOperationSetupId).HasColumnName("ChainOperationSetupID");

            //    entity.Property(e => e.Ge2).HasColumnName("GE2");

            //    entity.Property(e => e.GeversionNo).HasColumnName("GEVersionNo");

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.Prsid).HasColumnName("PRSID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<SfsEmployeeLineAllocationDetail>(entity =>
            //{
            //    entity.ToTable("SFS_EmployeeLineAllocation_Detail");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.AllocationId).HasColumnName("AllocationID");

            //    entity.Property(e => e.EmployeeCode)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.MachineBarcode)
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.MachineId).HasColumnName("MachineID");

            //    entity.Property(e => e.OperationId).HasColumnName("OperationID");

            //    entity.Property(e => e.OperatorId).HasColumnName("OperatorID");

            //    entity.Property(e => e.PunchTime)
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.HasOne(d => d.Allocation)
            //        .WithMany(p => p.SfsEmployeeLineAllocationDetail)
            //        .HasForeignKey(d => d.AllocationId)
            //        .HasConstraintName("FK_SFS_EmployeeLineAllocation_Detail_SFS_EmployeeLineAllocation");
            //});

            //modelBuilder.Entity<SfsInspection>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("SFS_Inspection");

            //    entity.Property(e => e.InspectionDate).HasColumnType("datetime");

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<SfsInspectionDefect>(entity =>
            //{
            //    entity.ToTable("SFS_Inspection_Defect");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.DefectId).HasColumnName("DefectID");

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.SfsinspectionId).HasColumnName("SFSInspectionID");
            //});

            //modelBuilder.Entity<SfsInspectionDefectDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("SFS_Inspection_DefectDetail");

            //    entity.Property(e => e.AuditId).HasColumnName("AuditID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.DefectedGarmentImg).HasColumnType("image");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.MasterId).HasColumnName("MasterID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<SfsInspectionMaster>(entity =>
            //{
            //    entity.HasKey(e => e.InspectionId);

            //    entity.ToTable("SFS_InspectionMaster");

            //    entity.Property(e => e.InspectionId).HasColumnName("InspectionID");

            //    entity.Property(e => e.Deleted).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.InspectionDate).HasColumnType("datetime");

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<SfsIssuanceMaster>(entity =>
            //{
            //    entity.HasKey(e => e.IssuanceId)
            //        .HasName("PK_SFS_Issuance");

            //    entity.ToTable("SFS_IssuanceMaster");

            //    entity.Property(e => e.IssuanceId).HasColumnName("IssuanceID");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(8000)
            //        .IsUnicode(false)
            //        .HasDefaultValueSql("('NONE')");

            //    entity.Property(e => e.Deleted).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.IssuanceDate).HasColumnType("datetime");

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<SfsIssuanceView>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("SFS_Issuance_View");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.IssuanceId).HasColumnName("IssuanceID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<SfsJob>(entity =>
            //{
            //    entity.HasKey(e => e.JobId);

            //    entity.ToTable("SFS_Job");

            //    entity.HasIndex(e => e.StyleId)
            //        .HasName("IDX_StyleID");

            //    entity.HasIndex(e => new { e.JobId, e.StyleId })
            //        .HasName("Ind_SFS_Job_1");

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.EndMinuteId).HasColumnName("EndMinuteID");

            //    entity.Property(e => e.EndWcdayId).HasColumnName("EndWCDayID");

            //    entity.Property(e => e.SfsPrsid)
            //        .HasColumnName("SFS_PRSID")
            //        .HasDefaultValueSql("((-1))");

            //    entity.Property(e => e.StartMinuteId).HasColumnName("StartMinuteID");

            //    entity.Property(e => e.StartWcdayId).HasColumnName("StartWCDayID");

            //    entity.Property(e => e.Status).HasDefaultValueSql("(2)");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.HasOne(d => d.StatusNavigation)
            //        .WithMany(p => p.SfsJob)
            //        .HasForeignKey(d => d.Status)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_SFS_Job_SFS_JobStatus");
            //});

            //modelBuilder.Entity<SfsJobBackupTable>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("SFS_JobBackupTable");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.EndMinuteId).HasColumnName("EndMinuteID");

            //    entity.Property(e => e.EndWcdayId).HasColumnName("EndWCDayID");

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.SfsPrsid).HasColumnName("SFS_PRSID");

            //    entity.Property(e => e.StartMinuteId).HasColumnName("StartMinuteID");

            //    entity.Property(e => e.StartWcdayId).HasColumnName("StartWCDayID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<SfsJobConfirmation>(entity =>
            //{
            //    entity.HasKey(e => e.ConfirmationId);

            //    entity.ToTable("SFS_JobConfirmation");

            //    entity.Property(e => e.ConfirmationId).HasColumnName("ConfirmationID");

            //    entity.Property(e => e.ConfirmationDate).HasColumnType("datetime");

            //    entity.Property(e => e.Deleted).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.IsBarCode)
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.IssuanceStatus).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.Remarks)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SendToRework).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.HasOne(d => d.Job)
            //        .WithMany(p => p.SfsJobConfirmation)
            //        .HasForeignKey(d => d.JobId)
            //        .HasConstraintName("FK_SFS_JobConfirmation_SFS_Job");
            //});

            //modelBuilder.Entity<SfsJobDetail>(entity =>
            //{
            //    entity.HasKey(e => e.JobDetailId);

            //    entity.ToTable("SFS_JobDetail");

            //    entity.HasIndex(e => new { e.JobId, e.ColorId, e.SizeId })
            //        .HasName("Ind_Ind_Sfs_JobDetail_1_2");

            //    entity.HasIndex(e => new { e.JobId, e.SizeId, e.ColorId })
            //        .HasName("Ind_Sfs_JobDetail_1");

            //    entity.Property(e => e.JobDetailId).HasColumnName("JobDetailID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.HasOne(d => d.Job)
            //        .WithMany(p => p.SfsJobDetail)
            //        .HasForeignKey(d => d.JobId)
            //        .HasConstraintName("FK_SFS_JobDetail_SFS_Job");
            //});

            //modelBuilder.Entity<SfsJobHistory>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("SFS_JobHistory");

            //    entity.Property(e => e.EndMinuteId).HasColumnName("EndMinuteID");

            //    entity.Property(e => e.EndWcdayId).HasColumnName("EndWCDayID");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.SfsPrsid).HasColumnName("SFS_PRSID");

            //    entity.Property(e => e.StartMinuteId).HasColumnName("StartMinuteID");

            //    entity.Property(e => e.StartWcdayId).HasColumnName("StartWCDayID");
            //});

            //modelBuilder.Entity<SfsJobResource>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("SFS_JobResource");

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.ResourceId).HasColumnName("ResourceID");

            //    entity.HasOne(d => d.Job)
            //        .WithMany(p => p.SfsJobResource)
            //        .HasForeignKey(d => d.JobId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_SFS_JobResource_SFS_Job");
            //});

            //modelBuilder.Entity<SfsJobStatus>(entity =>
            //{
            //    entity.HasKey(e => e.StatusId);

            //    entity.ToTable("SFS_JobStatus");

            //    entity.Property(e => e.StatusId)
            //        .HasColumnName("StatusID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.ColorCode)
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<SfsLayoutRequisition>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("sfs_layout_requisition");

            //    entity.Property(e => e.Colorid).HasColumnName("colorid");

            //    entity.Property(e => e.Colorname)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Creationdate)
            //        .HasColumnName("creationdate")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.DeliveryDate)
            //        .HasColumnName("delivery_date")
            //        .HasColumnType("smalldatetime");

            //    entity.Property(e => e.LineNo)
            //        .HasColumnName("line_no")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Lineid).HasColumnName("lineid");

            //    entity.Property(e => e.Orderid).HasColumnName("orderid");

            //    entity.Property(e => e.Orderno)
            //        .HasColumnName("orderno")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ReqId)
            //        .HasColumnName("req_id")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Styleid).HasColumnName("styleid");

            //    entity.Property(e => e.Styleno)
            //        .HasColumnName("styleno")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Userid).HasColumnName("userid");
            //});

            //modelBuilder.Entity<SfsLoads>(entity =>
            //{
            //    entity.ToTable("SFS_Loads");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Deleted).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.FixedAssetId).HasColumnName("FixedAssetID");

            //    entity.Property(e => e.MinuteId).HasColumnName("MinuteID");

            //    entity.Property(e => e.SfsJobTicketId).HasColumnName("SFS_JobTicketID");

            //    entity.Property(e => e.WcdayId).HasColumnName("WCDayID");

            //    entity.HasOne(d => d.Minute)
            //        .WithMany(p => p.SfsLoads)
            //        .HasForeignKey(d => d.MinuteId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_SFS_Loads_MinuteTime");
            //});

            //modelBuilder.Entity<SfsLoadsBackup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("SFS_Loads_Backup");

            //    entity.Property(e => e.FixedAssetId).HasColumnName("FixedAssetID");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.MinuteId).HasColumnName("MinuteID");

            //    entity.Property(e => e.SfsJobTicketId).HasColumnName("SFS_JobTicketID");

            //    entity.Property(e => e.WcdayId).HasColumnName("WCDayID");
            //});

            //modelBuilder.Entity<SfsMachineResourceStatus>(entity =>
            //{
            //    entity.HasKey(e => e.Status);

            //    entity.ToTable("SFS_MachineResourceStatus");

            //    entity.Property(e => e.Status).ValueGeneratedNever();

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .IsFixedLength();
            //});

            //modelBuilder.Entity<SfsMachineResources>(entity =>
            //{
            //    entity.HasKey(e => e.FixedAssetId);

            //    entity.ToTable("SFS_MachineResources");

            //    entity.Property(e => e.FixedAssetId)
            //        .HasColumnName("FixedAssetID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.Brand)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Code)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.FammachineTypeId).HasColumnName("FAMMachineTypeID");

            //    entity.Property(e => e.Model)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Name)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SfsPrsid).HasColumnName("SFS_PRSID");

            //    entity.Property(e => e.Type)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<SfsPickListDetail>(entity =>
            //{
            //    entity.HasKey(e => e.PickListDetailId);

            //    entity.ToTable("SFS_PickListDetail");

            //    entity.Property(e => e.PickListDetailId).HasColumnName("PickListDetailID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.PickListId).HasColumnName("PickListID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.HasOne(d => d.PickList)
            //        .WithMany(p => p.SfsPickListDetail)
            //        .HasForeignKey(d => d.PickListId)
            //        .HasConstraintName("FK_SFS_PickListDetail_SFS_PickListMaster");
            //});

            //modelBuilder.Entity<SfsPickListMaster>(entity =>
            //{
            //    entity.HasKey(e => e.PicklistId);

            //    entity.ToTable("SFS_PickListMaster");

            //    entity.Property(e => e.PicklistId).HasColumnName("PicklistID");

            //    entity.Property(e => e.AckDate).HasColumnType("datetime");

            //    entity.Property(e => e.IssuanceDate).HasColumnType("datetime");

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.StatusId).HasColumnName("StatusID");

            //    entity.HasOne(d => d.Job)
            //        .WithMany(p => p.SfsPickListMaster)
            //        .HasForeignKey(d => d.JobId)
            //        .HasConstraintName("FK_SFS_PickListMaster_SFS_Job");

            //    entity.HasOne(d => d.Status)
            //        .WithMany(p => p.SfsPickListMaster)
            //        .HasForeignKey(d => d.StatusId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_SFS_PickListMaster_SFS_PickListStatus");
            //});

            //modelBuilder.Entity<SfsPickListStatus>(entity =>
            //{
            //    entity.HasKey(e => e.StatusId);

            //    entity.ToTable("SFS_PickListStatus");

            //    entity.Property(e => e.StatusId)
            //        .HasColumnName("StatusID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<SfsProductionResourceRelations>(entity =>
            //{
            //    entity.ToTable("SFS_ProductionResourceRelations");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ChildSfsPrsid).HasColumnName("ChildSFS_PRSID");

            //    entity.Property(e => e.ParentSfsPrsid).HasColumnName("ParentSFS_PRSID");
            //});

            //modelBuilder.Entity<SfsProductionResourceSpecification>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("SFS_ProductionResourceSpecification");

            //    entity.Property(e => e.FabricCategoryId).HasColumnName("FabricCategoryID");

            //    entity.Property(e => e.HeadUserId).HasColumnName("HeadUserID");

            //    entity.Property(e => e.Name)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SfsPrsid)
            //        .HasColumnName("SFS_PRSID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.SfsPrtypeId).HasColumnName("SFS_PRTypeID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.HasOne(d => d.SfsPrtype)
            //        .WithMany(p => p.SfsProductionResourceSpecification)
            //        .HasForeignKey(d => d.SfsPrtypeId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_SFS_ProductionResourceSpecification_SFS_ProductionResourceType");
            //});

            //modelBuilder.Entity<SfsProductionResourceType>(entity =>
            //{
            //    entity.HasKey(e => e.SfsPrtypeId);

            //    entity.ToTable("SFS_ProductionResourceType");

            //    entity.Property(e => e.SfsPrtypeId).HasColumnName("SFS_PRTypeID");

            //    entity.Property(e => e.Prdesc)
            //        .IsRequired()
            //        .HasColumnName("PRDesc")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<SfsPrselectedBuyers>(entity =>
            //{
            //    entity.ToTable("SFS_PRSelectedBuyers");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Buyer)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.BuyerId).HasColumnName("BuyerID");

            //    entity.Property(e => e.SfsPrsid).HasColumnName("SFS_PRSID");
            //});

            //modelBuilder.Entity<SfsPrselectedFabricType>(entity =>
            //{
            //    entity.ToTable("SFS_PRSelectedFabricType");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.FabricType)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.FabricTypeId).HasColumnName("FabricTypeID");

            //    entity.Property(e => e.SfsPrsid).HasColumnName("SFS_PRSID");
            //});

            //modelBuilder.Entity<SfsPrselectedGarmentCategory>(entity =>
            //{
            //    entity.ToTable("SFS_PRSelectedGarmentCategory");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.GarmentCategory)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.GarmentCategoryId).HasColumnName("GarmentCategoryID");

            //    entity.Property(e => e.SfsPrsid).HasColumnName("SFS_PRSID");
            //});

            //modelBuilder.Entity<SfsPrselectedGarmentType>(entity =>
            //{
            //    entity.ToTable("SFS_PRSelectedGarmentType");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.GarmentType)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.GarmentTypeId).HasColumnName("GarmentTypeID");

            //    entity.Property(e => e.SfsPrsid).HasColumnName("SFS_PRSID");
            //});

            //modelBuilder.Entity<SfsPslog>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("SFS_PSLog");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.LineId).HasColumnName("LineID");

            //    entity.Property(e => e.TransactionDate).HasColumnType("datetime");

            //    entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<SfsReplannedJobDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("SFS_ReplannedJobDetail");

            //    entity.Property(e => e.Balance).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.ReplannedJobDetailId)
            //        .HasColumnName("Replanned_JobDetailID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");
            //});

            //modelBuilder.Entity<SfsReworkBacodes>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("SFS_Rework_Bacodes");

            //    entity.Property(e => e.BarcodeNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ChallanId).HasColumnName("ChallanID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.Dated).HasColumnType("datetime");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.QualityId).HasColumnName("QualityID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<SfsReworkConfirmation>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("SFS_ReworkConfirmation");

            //    entity.Property(e => e.ConfirmationId).HasColumnName("ConfirmationID");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<SfsReworkConfirmationDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("SFS_ReworkConfirmation_Detail");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.ConfirmationId).HasColumnName("ConfirmationID");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.QualityId).HasColumnName("QualityID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");
            //});

            //modelBuilder.Entity<SfsStockTransaction>(entity =>
            //{
            //    entity.HasKey(e => e.StockTransactionId);

            //    entity.ToTable("SFS_StockTransaction");

            //    entity.HasIndex(e => new { e.DocumentTypeId, e.DocumentNo, e.JobId, e.SizeId, e.ColorId, e.Quantity })
            //        .HasName("Ind_SfsStockTransaction");

            //    entity.Property(e => e.StockTransactionId).HasColumnName("StockTransactionID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.Deleted).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.QualityId).HasColumnName("QualityID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.TransactionDate).HasColumnType("datetime");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.HasOne(d => d.DocumentType)
            //        .WithMany(p => p.SfsStockTransaction)
            //        .HasForeignKey(d => d.DocumentTypeId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_SFS_StockTransaction_SFS_DocumentType");
            //});

            //modelBuilder.Entity<SfsStockTransactionBackupNotTobeDeleted>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("SFS_StockTransaction_Backup_NotTobeDeleted");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.QualityId).HasColumnName("QualityID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.StockTransactionId)
            //        .HasColumnName("StockTransactionID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.TransactionDate).HasColumnType("datetime");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<ShipmentLock>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.Property(e => e.Status).HasColumnName("status");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<Single>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.Comments).HasMaxLength(255);

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.Length).HasMaxLength(255);

            //    entity.Property(e => e.MachineId).HasColumnName("MachineID");

            //    entity.Property(e => e.NoOfPieces).HasMaxLength(255);

            //    entity.Property(e => e.OrderId)
            //        .HasColumnName("OrderID")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.ProgramTypeId).HasColumnName("ProgramTypeID");

            //    entity.Property(e => e.QualityId).HasColumnName("QualityID");

            //    entity.Property(e => e.RateWrtbaseUnit).HasColumnName("Rate_WRTBaseUnit");

            //    entity.Property(e => e.RollId).HasColumnName("RollID");

            //    entity.Property(e => e.RollNo).HasMaxLength(255);

            //    entity.Property(e => e.Rollnonew).HasColumnName("rollnonew");

            //    entity.Property(e => e.Rollnop)
            //        .HasColumnName("rollnop")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.SNo).HasColumnName("S#no");

            //    entity.Property(e => e.Skuunit).HasColumnName("SKUUnit");

            //    entity.Property(e => e.StockTransactionId).HasColumnName("StockTransactionID");

            //    entity.Property(e => e.StoreLocationId).HasColumnName("StoreLocationID");

            //    entity.Property(e => e.StyleId)
            //        .HasColumnName("StyleID")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.TrDate)
            //        .HasColumnName("tr_date")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.TransactionDate).HasColumnType("datetime");

            //    entity.Property(e => e.Width).HasMaxLength(255);

            //    entity.Property(e => e.Ykncid).HasColumnName("YKNCID");
            //});

            //modelBuilder.Entity<SizeRange>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("SizeRange");

            //    entity.Property(e => e.SelectedElementId).HasColumnName("SelectedElementID");

            //    entity.Property(e => e.Size)
            //        .IsRequired()
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");
            //});

            //modelBuilder.Entity<SpreaderInstance>(entity =>
            //{
            //    entity.HasKey(e => e.FamId);

            //    entity.Property(e => e.FamId)
            //        .HasColumnName("FAM_ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.FamparentId).HasColumnName("FAMParent_ID");

            //    entity.Property(e => e.SpreaderInstanceName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SpreaderMachineTypeId).HasColumnName("SpreaderMachineTypeID");

            //    entity.Property(e => e.StateId)
            //        .HasColumnName("StateID")
            //        .HasDefaultValueSql("(1)");

            //    entity.HasOne(d => d.Famparent)
            //        .WithMany(p => p.SpreaderInstance)
            //        .HasForeignKey(d => d.FamparentId)
            //        .HasConstraintName("FK_SpreaderInstance_SpreaderMachineType");
            //});

            //modelBuilder.Entity<SpreaderLoad>(entity =>
            //{
            //    entity.Property(e => e.SpreaderLoadId).HasColumnName("SpreaderLoadID");

            //    entity.Property(e => e.Deleted).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.FamId).HasColumnName("FAM_ID");

            //    entity.Property(e => e.JobTicketId).HasColumnName("JobTicketID");

            //    entity.Property(e => e.MinuteId).HasColumnName("MinuteID");

            //    entity.Property(e => e.WcdayId).HasColumnName("WCDayID");

            //    entity.HasOne(d => d.Fam)
            //        .WithMany(p => p.SpreaderLoad)
            //        .HasForeignKey(d => d.FamId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_SpreaderLoad_SpreaderInstance");

            //    entity.HasOne(d => d.Minute)
            //        .WithMany(p => p.SpreaderLoad)
            //        .HasForeignKey(d => d.MinuteId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_SpreaderLoad_MinuteTime");
            //});

            //modelBuilder.Entity<SpreaderMachineType>(entity =>
            //{
            //    entity.HasKey(e => e.FamId)
            //        .HasName("PK_SpreaderType");

            //    entity.Property(e => e.FamId)
            //        .HasColumnName("FAM_ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.FamparentId).HasColumnName("FAMParent_ID");

            //    entity.Property(e => e.SpreaderTypeName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<SpreadingLeadTime>(entity =>
            //{
            //    entity.HasKey(e => e.SpreadingTimeId);

            //    entity.Property(e => e.SpreadingTimeId).HasColumnName("SpreadingTimeID");

            //    entity.Property(e => e.FabricTypeId).HasColumnName("FabricTypeID");

            //    entity.Property(e => e.SpreadingMachineTypeId).HasColumnName("SpreadingMachineTypeID");

            //    entity.HasOne(d => d.SpreadingMachineType)
            //        .WithMany(p => p.SpreadingLeadTime)
            //        .HasForeignKey(d => d.SpreadingMachineTypeId)
            //        .OnDelete(DeleteBehavior.Cascade)
            //        .HasConstraintName("FK_SpreadingLeadTime_SpreaderMachineType");
            //});

            //modelBuilder.Entity<StitchingRec>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("Stitching_Rec");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.ReceivingMasterId).HasColumnName("ReceivingMasterID");
            //});

            //modelBuilder.Entity<StitchingRecView>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("Stitching_Rec_View");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.Date).HasColumnType("datetime");

            //    entity.Property(e => e.ReceivingMasterId).HasColumnName("ReceivingMasterID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<StyleInfo>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("StyleInfo");

            //    entity.Property(e => e.AssignedStyleNo)
            //        .HasMaxLength(60)
            //        .IsUnicode(false);

            //    entity.Property(e => e.FabricSpecificationId).HasColumnName("FabricSpecificationID");

            //    entity.Property(e => e.FabricTrim)
            //        .HasMaxLength(25)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.FabricTrimId).HasColumnName("FabricTrimID");

            //    entity.Property(e => e.FabricTrimSelectedId).HasColumnName("FabricTrimSelectedID");

            //    entity.Property(e => e.FscolorId).HasColumnName("FSColorID");

            //    entity.Property(e => e.PantonNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Ppsid).HasColumnName("PPSID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<StylePatternPiece>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("Style_PatternPiece");

            //    entity.Property(e => e.BodyPart)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.FabricSpecificationId).HasColumnName("FabricSpecificationID");

            //    entity.Property(e => e.FabricTrimId).HasColumnName("FabricTrimID");

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.PatternPiece)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<TableLoad>(entity =>
            //{
            //    entity.Property(e => e.TableLoadId).HasColumnName("TableLoadID");

            //    entity.Property(e => e.Deleted).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.FamId).HasColumnName("FAM_ID");

            //    entity.Property(e => e.JobTicketId).HasColumnName("JobTicketID");

            //    entity.Property(e => e.MinuteId).HasColumnName("MinuteID");

            //    entity.Property(e => e.WcdayId).HasColumnName("WCDayID");

            //    entity.HasOne(d => d.Fam)
            //        .WithMany(p => p.TableLoad)
            //        .HasForeignKey(d => d.FamId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_TableLoad_Tables");

            //    entity.HasOne(d => d.Minute)
            //        .WithMany(p => p.TableLoad)
            //        .HasForeignKey(d => d.MinuteId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_TableLoad_MinuteTime");
            //});

            //modelBuilder.Entity<Tables>(entity =>
            //{
            //    entity.HasKey(e => e.FamId);

            //    entity.Property(e => e.FamId)
            //        .HasColumnName("FAM_ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.FamparentId).HasColumnName("FAMParent_ID");

            //    entity.Property(e => e.TableNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<TblAgency>(entity =>
            //{
            //    entity.HasKey(e => e.AgencyId);

            //    entity.ToTable("tbl_Agency");

            //    entity.Property(e => e.AgencyId).HasColumnName("AgencyID");

            //    entity.Property(e => e.AgencyDesc)
            //        .IsRequired()
            //        .HasMaxLength(50);
            //});

            //modelBuilder.Entity<TblAgencyTransComments>(entity =>
            //{
            //    entity.HasKey(e => e.DocId);

            //    entity.ToTable("tbl_AgencyTrans_Comments");

            //    entity.Property(e => e.DocId)
            //        .HasColumnName("Doc_ID")
            //        .HasColumnType("numeric(18, 0)")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Comments)
            //        .IsRequired()
            //        .HasMaxLength(255)
            //        .IsUnicode(false)
            //        .HasDefaultValueSql("('None')");

            //    entity.Property(e => e.CommentsId)
            //        .HasColumnName("Comments_ID")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.DocumentTypeId)
            //        .HasColumnName("DocumentTypeID")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.UserId)
            //        .HasColumnName("UserID")
            //        .HasDefaultValueSql("(0)");
            //});

            //modelBuilder.Entity<TblAgencyTransDetail>(entity =>
            //{
            //    entity.HasKey(e => e.TransId);

            //    entity.ToTable("tbl_AgencyTransDetail");

            //    entity.Property(e => e.TransId).HasColumnName("Trans_ID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.PieceId).HasColumnName("PieceID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");
            //});

            //modelBuilder.Entity<TblAgencyTransMaster>(entity =>
            //{
            //    entity.HasKey(e => e.RefNo);

            //    entity.ToTable("tbl_AgencyTransMaster");

            //    entity.Property(e => e.AgencyId).HasColumnName("AgencyID");

            //    entity.Property(e => e.IsGarment)
            //        .IsRequired()
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.MrpitemCode)
            //        .HasColumnName("MRPItemCode")
            //        .HasColumnType("numeric(18, 0)");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<TblAgencyTransactions>(entity =>
            //{
            //    entity.HasKey(e => e.TransCode);

            //    entity.ToTable("tbl_AgencyTransactions");

            //    entity.Property(e => e.TransCode).HasColumnName("Trans_Code");

            //    entity.Property(e => e.CommentsId).HasColumnName("Comments_ID");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.Quantity).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.TransDate).HasColumnType("datetime");

            //    entity.Property(e => e.TransId).HasColumnName("Trans_ID");
            //});

            //modelBuilder.Entity<TblBonus>(entity =>
            //{
            //    entity.ToTable("Tbl_bonus");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.BonusType).HasColumnName("Bonus_type");

            //    entity.Property(e => e.BonusYear).HasColumnName("Bonus_year");

            //    entity.Property(e => e.EmpAppointment)
            //        .HasColumnName("Emp_appointment")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.EmpBonus).HasColumnName("Emp_bonus");

            //    entity.Property(e => e.EmpCd)
            //        .IsRequired()
            //        .HasColumnName("Emp_cd")
            //        .HasMaxLength(6)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.EmpComp)
            //        .IsRequired()
            //        .HasColumnName("Emp_Comp")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EmpCompid).HasColumnName("Emp_Compid");

            //    entity.Property(e => e.EmpDept)
            //        .IsRequired()
            //        .HasColumnName("Emp_dept")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EmpDeptid).HasColumnName("Emp_deptid");

            //    entity.Property(e => e.EmpDesignation)
            //        .IsRequired()
            //        .HasColumnName("Emp_designation")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EmpDesignationid).HasColumnName("Emp_designationid");

            //    entity.Property(e => e.EmpDivision)
            //        .IsRequired()
            //        .HasColumnName("Emp_division")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EmpDivisionid).HasColumnName("Emp_divisionid");

            //    entity.Property(e => e.EmpId).HasColumnName("Emp_ID");

            //    entity.Property(e => e.EmpLocation)
            //        .IsRequired()
            //        .HasColumnName("Emp_location")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EmpLocationId).HasColumnName("Emp_LocationID");

            //    entity.Property(e => e.EmpName)
            //        .IsRequired()
            //        .HasColumnName("Emp_Name")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EmpOldNo)
            //        .HasColumnName("Emp_OldNo")
            //        .HasMaxLength(25)
            //        .IsFixedLength();

            //    entity.Property(e => e.EmpSalary).HasColumnName("Emp_Salary");

            //    entity.Property(e => e.EmpSection)
            //        .IsRequired()
            //        .HasColumnName("Emp_section")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EmpSectionid).HasColumnName("Emp_sectionid");

            //    entity.Property(e => e.EmpType)
            //        .HasColumnName("Emp_type")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EmpTypeid).HasColumnName("Emp_typeid");
            //});

            //modelBuilder.Entity<TblBundleBarcodeTrack>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tblBundleBarcode_Track");

            //    entity.Property(e => e.ColorId)
            //        .HasColumnName("ColorID")
            //        .HasColumnType("numeric(18, 0)");

            //    entity.Property(e => e.ColorName).HasMaxLength(50);

            //    entity.Property(e => e.LoginTime).HasColumnType("datetime");

            //    entity.Property(e => e.OrderId)
            //        .HasColumnName("OrderID")
            //        .HasColumnType("numeric(18, 0)");

            //    entity.Property(e => e.OrderName).HasMaxLength(50);

            //    entity.Property(e => e.SizeId)
            //        .HasColumnName("SizeID")
            //        .HasColumnType("numeric(18, 0)");

            //    entity.Property(e => e.SizeName).HasMaxLength(50);

            //    entity.Property(e => e.Sno)
            //        .HasColumnType("numeric(18, 0)")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.StyleId)
            //        .HasColumnName("StyleID")
            //        .HasColumnType("numeric(18, 0)");

            //    entity.Property(e => e.StyleName).HasMaxLength(50);

            //    entity.Property(e => e.TransName).HasMaxLength(250);

            //    entity.Property(e => e.TransTime).HasColumnType("datetime");

            //    entity.Property(e => e.TransType).HasMaxLength(250);

            //    entity.Property(e => e.UserId)
            //        .HasColumnName("UserID")
            //        .HasColumnType("numeric(18, 0)");
            //});

            //modelBuilder.Entity<TblCutoffDetails>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_cutoff_details");

            //    entity.Property(e => e.Cutoffid).HasColumnName("cutoffid");

            //    entity.Property(e => e.Sieid).HasColumnName("sieid");

            //    entity.Property(e => e.Sizename)
            //        .HasColumnName("sizename")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Sizeqty).HasColumnName("sizeqty");
            //});

            //modelBuilder.Entity<TblCutoffentryMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_cutoffentry_master");

            //    entity.Property(e => e.Colorid).HasColumnName("colorid");

            //    entity.Property(e => e.Countryid).HasColumnName("countryid");

            //    entity.Property(e => e.Creationdate)
            //        .HasColumnName("creationdate")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Cufoffno).HasColumnName("cufoffno");

            //    entity.Property(e => e.Cutofffid)
            //        .HasColumnName("cutofffid")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Cuttingno).HasColumnName("cuttingno");

            //    entity.Property(e => e.DeliveryDate).HasColumnType("smalldatetime");

            //    entity.Property(e => e.Orderid).HasColumnName("orderid");

            //    entity.Property(e => e.Pantonno)
            //        .HasColumnName("pantonno")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Sn).HasColumnName("sn");

            //    entity.Property(e => e.Styleid).HasColumnName("styleid");

            //    entity.Property(e => e.Weekno).HasColumnName("weekno");
            //});

            //modelBuilder.Entity<TblCutting60>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_cutting_60");

            //    entity.Property(e => e.BookQty)
            //        .HasColumnName("book_qty")
            //        .HasColumnType("decimal(18, 3)");

            //    entity.Property(e => e.BuyerId).HasColumnName("BuyerID");

            //    entity.Property(e => e.Buyername)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Color)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.Companyname)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Creationdate)
            //        .HasColumnName("creationdate")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.CuttingDeliveredSewingKg)
            //        .HasColumnName("cutting_delivered_sewing_kg")
            //        .HasColumnType("decimal(18, 4)");

            //    entity.Property(e => e.CuttingKg)
            //        .HasColumnName("cutting_kg")
            //        .HasColumnType("decimal(18, 4)");

            //    entity.Property(e => e.CuttingPc).HasColumnName("cutting_pc");

            //    entity.Property(e => e.CuttingPercent)
            //        .HasColumnName("cutting_percent")
            //        .HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.FinishedQty)
            //        .HasColumnName("Finished_qty")
            //        .HasColumnType("decimal(18, 4)");

            //    entity.Property(e => e.GrayQty)
            //        .HasColumnName("gray_qty")
            //        .HasColumnType("decimal(18, 3)");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.OrderId).HasColumnName("Order_ID");

            //    entity.Property(e => e.OrderNo)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OrderQty).HasColumnName("Order_qty");

            //    entity.Property(e => e.PantonId).HasColumnName("panton_id");

            //    entity.Property(e => e.Pantonno)
            //        .HasColumnName("pantonno")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PerPcWeight)
            //        .HasColumnName("per_pc_weight")
            //        .HasColumnType("decimal(18, 3)");

            //    entity.Property(e => e.RequiredFebricKg)
            //        .HasColumnName("REQUIRED_febric_kg")
            //        .HasColumnType("decimal(18, 4)");

            //    entity.Property(e => e.Styleid).HasColumnName("styleid");

            //    entity.Property(e => e.TtlCuttingWeight)
            //        .HasColumnName("ttl_cutting_weight")
            //        .HasColumnType("decimal(18, 3)");

            //    entity.Property(e => e.TtlRejectPc)
            //        .HasColumnName("ttl_reject_pc")
            //        .HasColumnType("decimal(18, 3)");
            //});

            //modelBuilder.Entity<TblCuttingDefects>(entity =>
            //{
            //    entity.ToTable("tbl_cutting_defects");

            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.DefectName)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<TblCuttingInputTransfer>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Tbl_Cutting_Input_Transfer");

            //    entity.Property(e => e.CInputId).HasColumnName("c_input_id");

            //    entity.Property(e => e.Creatondate)
            //        .HasColumnName("creatondate")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.CutInputTId)
            //        .HasColumnName("cut_input_t_id")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.MarkerId).HasColumnName("marker_id");

            //    entity.Property(e => e.MarkerShortId).HasColumnName("marker_short_id");

            //    entity.Property(e => e.OldOrderid).HasColumnName("old_orderid");

            //    entity.Property(e => e.OldOrderno)
            //        .HasColumnName("old_orderno")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Orderid).HasColumnName("orderid");

            //    entity.Property(e => e.Orderno)
            //        .HasColumnName("orderno")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<TblCuttingPartDefects>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Tbl_cutting_part_Defects");

            //    entity.Property(e => e.Bundleno).HasColumnName("bundleno");

            //    entity.Property(e => e.Bundleqty).HasColumnName("bundleqty");

            //    entity.Property(e => e.DefectId).HasColumnName("DefectID");

            //    entity.Property(e => e.DefectValue).HasColumnType("decimal(5, 2)");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.LotId).HasColumnName("LotID");

            //    entity.Property(e => e.Score).HasColumnType("decimal(3, 2)");

            //    entity.Property(e => e.Sizeid).HasColumnName("sizeid");

            //    entity.Property(e => e.TransationId).HasColumnName("Transation_ID");
            //});

            //modelBuilder.Entity<TblCuttingPartOk>(entity =>
            //{
            //    entity.ToTable("Tbl_cutting_part_ok");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ChallanId).HasColumnName("challan_id");

            //    entity.Property(e => e.Comment)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CuttingNo).HasColumnName("Cutting_no");

            //    entity.Property(e => e.InspectionDate)
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Inspectorname)
            //        .HasColumnName("inspectorname")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.LotId).HasColumnName("LotID");

            //    entity.Property(e => e.TtlCutPc).HasColumnName("ttl_cut_pc");

            //    entity.Property(e => e.TtlOkCutPc).HasColumnName("ttl_ok_cut_pc");

            //    entity.Property(e => e.UserId).HasColumnName("user_id");
            //});

            //modelBuilder.Entity<TblCuttingSticker>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_cutting_sticker");

            //    entity.Property(e => e.Bundleid).HasColumnName("bundleid");

            //    entity.Property(e => e.BundleidM).HasColumnName("bundleidM");

            //    entity.Property(e => e.Challanid).HasColumnName("challanid");

            //    entity.Property(e => e.Countryid).HasColumnName("countryid");

            //    entity.Property(e => e.Creationdate)
            //        .HasColumnName("creationdate")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Cuttingno).HasColumnName("cuttingno");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Rfidno).HasColumnName("rfidno");

            //    entity.Property(e => e.Rollid).HasColumnName("rollid");

            //    entity.Property(e => e.Rollno)
            //        .HasColumnName("rollno")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Sizeid).HasColumnName("sizeid");

            //    entity.Property(e => e.Sizename)
            //        .HasColumnName("sizename")
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Srno).HasColumnName("srno");

            //    entity.Property(e => e.Stickerno).HasColumnName("stickerno");
            //});

            //modelBuilder.Entity<TblCuttingStickerBundle>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_cutting_sticker_bundle");

            //    entity.Property(e => e.BundleStatus)
            //        .HasColumnName("bundle_status")
            //        .HasDefaultValueSql("((1))");

            //    entity.Property(e => e.Bundleid)
            //        .HasColumnName("bundleid")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Bundlesrno).HasColumnName("bundlesrno");

            //    entity.Property(e => e.Challanid).HasColumnName("challanid");

            //    entity.Property(e => e.Countryid).HasColumnName("countryid");

            //    entity.Property(e => e.Creationdate)
            //        .HasColumnName("creationdate")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Cutidno).HasColumnName("cutidno");

            //    entity.Property(e => e.Maxstickerno).HasColumnName("maxstickerno");

            //    entity.Property(e => e.Minstickerno).HasColumnName("minstickerno");

            //    entity.Property(e => e.Rfidno)
            //        .HasColumnName("rfidno")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Sizeid).HasColumnName("sizeid");

            //    entity.Property(e => e.Sizename)
            //        .HasColumnName("sizename")
            //        .HasMaxLength(15)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UpdateDate)
            //        .HasColumnName("update_date")
            //        .HasColumnType("smalldatetime");
            //});

            //modelBuilder.Entity<TblCuttingStickerBundleMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_cutting_sticker_bundle_master");

            //    entity.Property(e => e.Bundlemid)
            //        .HasColumnName("bundlemid")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Bundlesrno).HasColumnName("bundlesrno");

            //    entity.Property(e => e.Challanid).HasColumnName("challanid");

            //    entity.Property(e => e.Creationdate)
            //        .HasColumnName("creationdate")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Cuttingno).HasColumnName("cuttingno");

            //    entity.Property(e => e.Endno).HasColumnName("endno");

            //    entity.Property(e => e.MainBundleid).HasColumnName("main_bundleid");

            //    entity.Property(e => e.Rollcode)
            //        .HasColumnName("rollcode")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Rollid).HasColumnName("rollid");

            //    entity.Property(e => e.SizeRatio).HasColumnName("size_ratio");

            //    entity.Property(e => e.Sizeid).HasColumnName("sizeid");

            //    entity.Property(e => e.Sizename)
            //        .HasColumnName("sizename")
            //        .HasMaxLength(15)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Startno).HasColumnName("startno");
            //});

            //modelBuilder.Entity<TblCuttingStickerMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_cutting_sticker_master");

            //    entity.Property(e => e.Challanid).HasColumnName("challanid");

            //    entity.Property(e => e.Countryid).HasColumnName("countryid");

            //    entity.Property(e => e.Creationdate)
            //        .HasColumnName("creationdate")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Cutidno)
            //        .HasColumnName("cutidno")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.OrderCutno).HasColumnName("order_cutno");

            //    entity.Property(e => e.Orderid).HasColumnName("orderid");
            //});

            //modelBuilder.Entity<TblCuttingWeight>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_cutting_weight");

            //    entity.Property(e => e.Comment)
            //        .HasColumnName("comment")
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Creationdate)
            //        .HasColumnName("creationdate")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.CuttingWeight)
            //        .HasColumnName("cutting_weight")
            //        .HasColumnType("decimal(18, 4)");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.MarkerId).HasColumnName("marker_id");

            //    entity.Property(e => e.Userid).HasColumnName("userid");
            //});

            //modelBuilder.Entity<TblDailyCuttingReportTable>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_DailyCuttingReportTable");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.ColorName)
            //        .HasMaxLength(75)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OrderNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PatternPieceId).HasColumnName("PatternPieceID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.SizeName)
            //        .HasMaxLength(25)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.StyleName)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<TblDefects>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Tbl_Defects");

            //    entity.Property(e => e.DefectName)
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<TblDyeing60>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_dyeing_60");

            //    entity.Property(e => e.BuyerId).HasColumnName("BuyerID");

            //    entity.Property(e => e.Buyername)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Color)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.Companyname)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Composition)
            //        .HasColumnName("composition")
            //        .IsUnicode(false);

            //    entity.Property(e => e.Creationdate)
            //        .HasColumnName("creationdate")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.FinishPercent)
            //        .HasColumnName("Finish_percent")
            //        .HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.FinishRollQty).HasColumnName("finish_roll_qty");

            //    entity.Property(e => e.FinishedQty)
            //        .HasColumnName("Finished_qty")
            //        .HasColumnType("decimal(18, 4)");

            //    entity.Property(e => e.GreigeFabricQty)
            //        .HasColumnName("Greige_fabric_qty")
            //        .HasColumnType("decimal(18, 4)");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.OrderId).HasColumnName("Order_ID");

            //    entity.Property(e => e.OrderNo)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OrderQty).HasColumnName("Order_qty");

            //    entity.Property(e => e.PantonId).HasColumnName("panton_id");

            //    entity.Property(e => e.Pantonno)
            //        .HasColumnName("pantonno")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ReqFabric)
            //        .HasColumnName("req_fabric")
            //        .HasColumnType("decimal(18, 4)");

            //    entity.Property(e => e.Styleid).HasColumnName("styleid");

            //    entity.Property(e => e.TtlGreigeAgainstFinishedFabric)
            //        .HasColumnName("ttl_Greige_Against_Finished_Fabric")
            //        .HasColumnType("decimal(18, 4)");
            //});

            //modelBuilder.Entity<TblDyeing602>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_dyeing_60_2");

            //    entity.Property(e => e.ApprovePercentage)
            //        .HasColumnName("approve_Percentage")
            //        .HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.Buyerid).HasColumnName("BUYERID");

            //    entity.Property(e => e.Buyername)
            //        .HasColumnName("BUYERNAME")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.Companyname)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Creatiodate)
            //        .HasColumnName("creatiodate")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.DyeingQty)
            //        .HasColumnName("dyeing_qty")
            //        .HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.FabricComposition).IsUnicode(false);

            //    entity.Property(e => e.FinishQty)
            //        .HasColumnName("finish_qty")
            //        .HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.LossFabric)
            //        .HasColumnName("loss_fabric")
            //        .HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.OrderNo)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OrderQty).HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.PantoneNo)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ProducePercent)
            //        .HasColumnName("produce_percent")
            //        .HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.ReqGrayQty)
            //        .HasColumnName("req_gray_qty")
            //        .HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.RequiredFebricKg)
            //        .HasColumnName("REQUIRED_febric_kg")
            //        .HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.SaveFabric)
            //        .HasColumnName("save_fabric")
            //        .HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.StyleDescription)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Styleid).HasColumnName("styleid");

            //    entity.Property(e => e.WestagePercent)
            //        .HasColumnName("westage_percent")
            //        .HasColumnType("decimal(18, 2)");
            //});

            //modelBuilder.Entity<TblDyeingCategory>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Tbl_dyeing_Category");

            //    entity.Property(e => e.Catagory)
            //        .HasColumnName("catagory")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Id).HasColumnName("ID");
            //});

            //modelBuilder.Entity<TblDyeingDefects>(entity =>
            //{
            //    entity.ToTable("tbl_dyeing_defects");

            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.DefectName)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<TblDyeingDefectsCatagory>(entity =>
            //{
            //    entity.ToTable("tbl_dyeing_defects_catagory");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Catagory)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<TblDyeingLosttime>(entity =>
            //{
            //    entity.ToTable("Tbl_Dyeing_Losttime");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Catagory).HasColumnName("catagory");

            //    entity.Property(e => e.Comment)
            //        .HasColumnName("comment")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Date)
            //        .HasColumnName("date")
            //        .HasColumnType("smalldatetime");

            //    entity.Property(e => e.InputDate)
            //        .HasColumnName("input_date")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.LostTime).HasColumnName("lost_time");

            //    entity.Property(e => e.LostTypeId).HasColumnName("lost_type_id");

            //    entity.Property(e => e.McNo).HasColumnName("mc_no");

            //    entity.Property(e => e.Remarks)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Shift)
            //        .HasColumnName("shift")
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ShiftTime).HasColumnName("shift_time");

            //    entity.Property(e => e.UserId).HasColumnName("userID");
            //});

            //modelBuilder.Entity<TblDyeingLosttimeR>(entity =>
            //{
            //    entity.ToTable("Tbl_Dyeing_Losttime_R");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Comment)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CreationDate)
            //        .HasColumnName("creation_date")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.EndDate)
            //        .HasColumnName("end_date")
            //        .HasColumnType("smalldatetime");

            //    entity.Property(e => e.EndTimeD)
            //        .HasColumnName("end_time_d")
            //        .HasColumnType("smalldatetime");

            //    entity.Property(e => e.LostTypeId).HasColumnName("lost_type_ID");

            //    entity.Property(e => e.McNo).HasColumnName("mc_no");

            //    entity.Property(e => e.Remarks)
            //        .HasColumnName("remarks")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StartDate)
            //        .HasColumnName("start_date")
            //        .HasColumnType("smalldatetime");

            //    entity.Property(e => e.UserId).HasColumnName("userID");
            //});

            //modelBuilder.Entity<TblDyeingMachine>(entity =>
            //{
            //    entity.ToTable("Tbl_Dyeing_Machine");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.MachineId)
            //        .HasColumnName("Machine_ID")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.MachineName)
            //        .HasColumnName("Machine_name")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<TblDyeingRolldefects>(entity =>
            //{
            //    entity.ToTable("tbl_dyeing_rolldefects");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Comment).HasMaxLength(50);

            //    entity.Property(e => e.DefectId).HasColumnName("DefectID");

            //    entity.Property(e => e.DefectValue).HasColumnType("decimal(5, 2)");

            //    entity.Property(e => e.DefectValueie).HasColumnType("decimal(5, 2)");

            //    entity.Property(e => e.Gsm).HasColumnName("gsm");

            //    entity.Property(e => e.InspectionDate)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Remarks)
            //        .HasColumnName("remarks")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.RollId).HasColumnName("RollID");

            //    entity.Property(e => e.Userid).HasColumnName("userid");

            //    entity.Property(e => e.Weight)
            //        .HasColumnName("weight")
            //        .HasColumnType("decimal(5, 2)");

            //    entity.Property(e => e.Width)
            //        .HasColumnName("width")
            //        .HasColumnType("decimal(5, 2)");

            //    entity.Property(e => e.Width2)
            //        .HasColumnName("width2")
            //        .HasColumnType("decimal(5, 2)");

            //    entity.Property(e => e.Width3)
            //        .HasColumnName("width3")
            //        .HasColumnType("decimal(5, 2)");
            //});

            //modelBuilder.Entity<TblDyeingRollinspaction>(entity =>
            //{
            //    entity.ToTable("tbl_dyeing_rollinspaction");

            //    entity.HasIndex(e => new { e.RollId, e.Lotid })
            //        .HasName("IND_tbl_dyeing_rollinspaction_1");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Comment)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DefectId).HasColumnName("DefectID");

            //    entity.Property(e => e.DefectValue).HasColumnType("decimal(5, 2)");

            //    entity.Property(e => e.Gsm).HasColumnName("gsm");

            //    entity.Property(e => e.Horizontal).HasColumnType("decimal(5, 2)");

            //    entity.Property(e => e.InspectionDate)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Orderid).HasColumnName("orderid");

            //    entity.Property(e => e.Remarks)
            //        .HasColumnName("remarks")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.RollId).HasColumnName("RollID");

            //    entity.Property(e => e.Userid).HasColumnName("userid");

            //    entity.Property(e => e.Vertical)
            //        .HasColumnName("vertical")
            //        .HasColumnType("decimal(5, 2)");

            //    entity.Property(e => e.Weight)
            //        .HasColumnName("weight")
            //        .HasColumnType("decimal(5, 2)");

            //    entity.Property(e => e.Width)
            //        .HasColumnName("width")
            //        .HasColumnType("decimal(5, 2)");
            //});

            //modelBuilder.Entity<TblDyeingTime>(entity =>
            //{
            //    entity.ToTable("Tbl_Dyeing_Time");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Category).HasColumnName("category");

            //    entity.Property(e => e.Comment)
            //        .HasColumnName("comment")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Creationdate)
            //        .HasColumnName("creationdate")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.EndTime)
            //        .HasColumnName("end_time")
            //        .HasColumnType("smalldatetime");

            //    entity.Property(e => e.EndTimeEntry)
            //        .HasColumnName("end_time_entry")
            //        .HasColumnType("smalldatetime");

            //    entity.Property(e => e.LoadStatus)
            //        .HasColumnName("load_status")
            //        .HasDefaultValueSql("((1))");

            //    entity.Property(e => e.LotId).HasColumnName("lotID");

            //    entity.Property(e => e.McNo).HasColumnName("mc_no");

            //    entity.Property(e => e.StartTime)
            //        .HasColumnName("start_time")
            //        .HasColumnType("smalldatetime");

            //    entity.Property(e => e.Type)
            //        .HasColumnName("type")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.UserId).HasColumnName("user_ID");
            //});

            //modelBuilder.Entity<TblDyeingTimeSplit>(entity =>
            //{
            //    entity.ToTable("Tbl_Dyeing_Time_Split");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Comment)
            //        .HasColumnName("comment")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Noofpcs)
            //        .HasColumnName("noofpcs")
            //        .HasDefaultValueSql("((1))");

            //    entity.Property(e => e.Rollid).HasColumnName("rollid");

            //    entity.Property(e => e.Rollweight).HasColumnName("rollweight");

            //    entity.Property(e => e.StocktransationId).HasColumnName("stocktransationID");
            //});

            //modelBuilder.Entity<TblDyeingType>(entity =>
            //{
            //    entity.ToTable("Tbl_Dyeing_Type");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Catagory).HasColumnName("catagory");

            //    entity.Property(e => e.DyeingDype)
            //        .HasColumnName("dyeing_dype")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Serial).HasColumnName("serial");
            //});

            //modelBuilder.Entity<TblDyeingWG>(entity =>
            //{
            //    entity.HasKey(e => e.DyeingWgId);

            //    entity.ToTable("tbl_dyeing_W_G");

            //    entity.Property(e => e.DyeingWgId).HasColumnName("dyeing_wg_ID");

            //    entity.Property(e => e.Comment)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Creationdate)
            //        .HasColumnName("creationdate")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Entrytime).HasColumnName("entrytime");

            //    entity.Property(e => e.Gsm)
            //        .HasColumnName("GSM")
            //        .HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.Lotid).HasColumnName("lotid");

            //    entity.Property(e => e.Rollid).HasColumnName("rollid");

            //    entity.Property(e => e.UserId).HasColumnName("user_id");

            //    entity.Property(e => e.Width)
            //        .HasColumnName("width")
            //        .HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.Width1)
            //        .HasColumnName("width1")
            //        .HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.Width2)
            //        .HasColumnName("width2")
            //        .HasColumnType("decimal(18, 2)");
            //});

            //modelBuilder.Entity<TblDyeingWGStatus>(entity =>
            //{
            //    entity.HasKey(e => e.LotStatusId);

            //    entity.ToTable("tbl_dyeing_w_g_status");

            //    entity.Property(e => e.LotStatusId).HasColumnName("lot_status_id");

            //    entity.Property(e => e.LotComment)
            //        .HasColumnName("lot_comment")
            //        .IsUnicode(false);

            //    entity.Property(e => e.LotEntryDate)
            //        .HasColumnName("lot_entry_date")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Lotid).HasColumnName("lotid");

            //    entity.Property(e => e.UserId).HasColumnName("user_id");
            //});

            //modelBuilder.Entity<TblFam>(entity =>
            //{
            //    entity.ToTable("tbl_fam");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Fam)
            //        .HasColumnName("FAM")
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.Property(e => e.MachineTypeId).HasColumnName("Machine_type_id");
            //});

            //modelBuilder.Entity<TblFinishFabricLog>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Tbl_FinishFabric_Log");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CommentsDate)
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.CreationDate)
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.OrderNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Pantone)
            //        .HasMaxLength(100)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<TblFloor>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_floor");

            //    entity.Property(e => e.Active).HasDefaultValueSql("((1))");

            //    entity.Property(e => e.FloorId)
            //        .HasColumnName("FloorID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.FloorName)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.LocationId).HasColumnName("LocationID");
            //});

            //modelBuilder.Entity<TblGarmentsTypes>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Tbl_Garments_Types");

            //    entity.Property(e => e.Gtid)
            //        .HasColumnName("GTID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.TblGarmentsTypes1)
            //        .HasColumnName("Tbl_Garments_Types")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<TblGateKnittingRolls>(entity =>
            //{
            //    entity.HasKey(e => e.RollId);

            //    entity.ToTable("tbl_GateKnittingRolls");

            //    entity.Property(e => e.RollId)
            //        .HasColumnName("RollID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.ParentId).HasColumnName("ParentID");

            //    entity.Property(e => e.QualityId)
            //        .HasColumnName("QualityID")
            //        .HasDefaultValueSql("((1))");

            //    entity.Property(e => e.RollCode)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<TblKnittingAttributeSetup>(entity =>
            //{
            //    entity.ToTable("tbl_KnittingAttribute_Setup");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ProcessName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<TblKnittingDayMinuteTime>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_KnittingDayMinuteTime");

            //    entity.Property(e => e.DayId).HasColumnName("DayID");

            //    entity.Property(e => e.DayMinuteId)
            //        .HasColumnName("DayMinuteID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.MinuteId).HasColumnName("MinuteID");

            //    entity.Property(e => e.StatusId).HasColumnName("StatusID");
            //});

            //modelBuilder.Entity<TblKnittingDocumentTypeSetup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_KnittingDocumentType_Setup");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.DocumentTypeName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<TblKnittingEfficiencyArchive>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Tbl_Knitting_Efficiency_Archive");

            //    entity.Property(e => e.Brand)
            //        .HasColumnName("BRAND")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.Companyname)
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EffeciencyDate).HasColumnType("smalldatetime");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.MachineNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Rpm).HasColumnName("RPM");

            //    entity.Property(e => e.Shift)
            //        .HasMaxLength(1)
            //        .IsUnicode(false)
            //        .IsFixedLength();
            //});

            //modelBuilder.Entity<TblKnittingFabricProcessAssociation>(entity =>
            //{
            //    entity.HasKey(e => e.AssociationId);

            //    entity.ToTable("tbl_KnittingFabricProcessAssociation");

            //    entity.Property(e => e.AssociationId).HasColumnName("AssociationID");

            //    entity.Property(e => e.KnittingFabricId).HasColumnName("KnittingFabricID");

            //    entity.Property(e => e.ProcessId).HasColumnName("ProcessID");

            //    entity.HasOne(d => d.Process)
            //        .WithMany(p => p.TblKnittingFabricProcessAssociation)
            //        .HasForeignKey(d => d.ProcessId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_tbl_KnittingFabricProcessAssociation_tbl_KnittingAttribute_Setup");
            //});

            //modelBuilder.Entity<TblKnittingFabricSpecification>(entity =>
            //{
            //    entity.HasKey(e => e.FabricSpecificationId);

            //    entity.ToTable("tbl_KnittingFabricSpecification");

            //    entity.Property(e => e.FabricSpecificationId).HasColumnName("FabricSpecificationID");

            //    entity.Property(e => e.DesignId).HasColumnName("DesignID");

            //    entity.Property(e => e.GaugeId).HasColumnName("GaugeID");

            //    entity.Property(e => e.Gsm).HasColumnName("GSM");

            //    entity.Property(e => e.MachineTypeId).HasColumnName("MachineTypeID");

            //    entity.Property(e => e.QualityId).HasColumnName("QualityID");

            //    entity.Property(e => e.TypeId).HasColumnName("TypeID");
            //});

            //modelBuilder.Entity<TblKnittingGate>(entity =>
            //{
            //    entity.ToTable("tbl_knittingGate");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Date).HasColumnType("datetime");

            //    entity.Property(e => e.DeliveryChallan)
            //        .HasMaxLength(800)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

            //    entity.Property(e => e.DeliveryPerson)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.VehicleNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Yknc).HasColumnName("YKNC");
            //});

            //modelBuilder.Entity<TblKnittingInspectionMaster>(entity =>
            //{
            //    entity.HasKey(e => e.InspectionId);

            //    entity.ToTable("tbl_KnittingInspectionMaster");

            //    entity.Property(e => e.InspectionId).HasColumnName("InspectionID");

            //    entity.Property(e => e.InspectionDate).HasColumnType("datetime");

            //    entity.Property(e => e.IsLabTest).HasDefaultValueSql("(1)");

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.KnittingFabricSpecificationId).HasColumnName("KnittingFabricSpecificationID");
            //});

            //modelBuilder.Entity<TblKnittingInspectionRejection>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_KnittingInspectionRejection");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.RollCode)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.RollId).HasColumnName("RollID");

            //    entity.Property(e => e.Ykncid).HasColumnName("YKNCID");
            //});

            //modelBuilder.Entity<TblKnittingIssuanceMaster>(entity =>
            //{
            //    entity.HasKey(e => e.IssuanceId);

            //    entity.ToTable("tbl_KnittingIssuanceMaster");

            //    entity.Property(e => e.IssuanceId).HasColumnName("IssuanceID");

            //    entity.Property(e => e.IssuanceDate).HasColumnType("datetime");

            //    entity.Property(e => e.IssuanceNo)
            //        .IsRequired()
            //        .HasMaxLength(10)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<TblKnittingJobConfirmation>(entity =>
            //{
            //    entity.HasKey(e => e.ConfirmationId);

            //    entity.ToTable("tbl_KnittingJobConfirmation");

            //    entity.Property(e => e.ConfirmationId).HasColumnName("ConfirmationID");

            //    entity.Property(e => e.ConfirmationDate).HasColumnType("datetime");

            //    entity.Property(e => e.JobId).HasColumnName("JobID");
            //});

            //modelBuilder.Entity<TblKnittingJobStatus>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_KnittingJobStatus");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Status)
            //        .IsRequired()
            //        .HasMaxLength(20)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<TblKnittingJobs>(entity =>
            //{
            //    entity.HasKey(e => e.JobId);

            //    entity.ToTable("tbl_KnittingJobs");

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.EndingDayMinuteId).HasColumnName("EndingDayMinuteID");

            //    entity.Property(e => e.JobName)
            //        .IsRequired()
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.JobStatusId).HasColumnName("JobStatusID");

            //    entity.Property(e => e.MachineId).HasColumnName("MachineID");

            //    entity.Property(e => e.StartingDayMinuteId).HasColumnName("StartingDayMinuteID");

            //    entity.Property(e => e.YarnKnittingContractId).HasColumnName("YarnKnittingContractID");
            //});

            //modelBuilder.Entity<TblKnittingJobsOld>(entity =>
            //{
            //    entity.HasKey(e => e.JobId);

            //    entity.ToTable("tbl_KnittingJobs_Old");

            //    entity.Property(e => e.JobId)
            //        .HasColumnName("JobID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.EndMinuteId).HasColumnName("EndMinuteID");

            //    entity.Property(e => e.EndTime)
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EndWcdayId).HasColumnName("EndWCDayID");

            //    entity.Property(e => e.JobName)
            //        .IsRequired()
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.JobStatusId).HasColumnName("JobStatusID");

            //    entity.Property(e => e.MachineId).HasColumnName("MachineID");

            //    entity.Property(e => e.StartDate)
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StartMinuteId).HasColumnName("StartMinuteID");

            //    entity.Property(e => e.StartTime)
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StartWcdayId).HasColumnName("StartWCDayID");

            //    entity.Property(e => e.YarnKnittingContractId).HasColumnName("YarnKnittingContractID");
            //});

            //modelBuilder.Entity<tbl_KnittingLaboratoryInspection>(entity =>
            //{
            //    entity.ToTable("tbl_KnittingLaboratoryInspection");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ProcessId).HasColumnName("ProcessID");

            //    entity.Property(e => e.RollId).HasColumnName("RollID");

            //entity.HasOne(d => d.ProcessID)
            //    .WithMany(p => p.TblKnittingLaboratoryInspection)
            //    .HasForeignKey(d => d.ProcessId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_tbl_KnittingLaboratoryInspection_tbl_KnittingAttribute_Setup");

            //entity.HasOne(d => d.RollID)
            //    .WithMany(p => p.TblKnittingLaboratoryInspection)
            //    .HasForeignKey(d => d.RollId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_tbl_KnittingLaboratoryInspection_tbl_KnittingRolls");
            //});

            //modelBuilder.Entity<TblKnittingLoads>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_KnittingLoads");

            //    entity.Property(e => e.DayMinuteId).HasColumnName("DayMinuteID");

            //    entity.Property(e => e.KnittingJobId).HasColumnName("KnittingJobID");

            //    entity.Property(e => e.LoadId)
            //        .HasColumnName("LoadID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.MachineId).HasColumnName("MachineID");
            //});

            //modelBuilder.Entity<TblKnittingMachineLeadTime>(entity =>
            //{
            //    entity.ToTable("tbl_KnittingMachineLeadTime");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.FabricQualityId).HasColumnName("FabricQualityID");

            //    entity.Property(e => e.FabricTypeId).HasColumnName("FabricTypeID");

            //    entity.Property(e => e.MachineId).HasColumnName("MachineID");
            //});

            //modelBuilder.Entity<TblKnittingMachines>(entity =>
            //{
            //    entity.HasKey(e => e.MachineNo);

            //    entity.ToTable("Tbl_KnittingMachines");

            //    entity.Property(e => e.MachineNo).ValueGeneratedNever();

            //    entity.Property(e => e.Brand)
            //        .HasColumnName("BRAND")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.Dia).HasColumnName("DIA");

            //    entity.Property(e => e.Model)
            //        .HasColumnName("model")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Rod1Weight)
            //        .HasColumnName("ROD1_Weight")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.Rod2Weight)
            //        .HasColumnName("ROD2_Weight")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.Rod3Weight)
            //        .HasColumnName("ROD3_Weight")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.Rod4Weight)
            //        .HasColumnName("ROD4_Weight")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.Rod5Weight)
            //        .HasColumnName("ROD5_Weight")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.Rpm).HasColumnName("rpm");

            //    entity.Property(e => e.Slength)
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.Property(e => e.YType).HasColumnName("y_type");

            //    entity.Property(e => e.Ycount).HasColumnName("ycount");

            //    entity.Property(e => e.Year)
            //        .HasColumnName("year")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<TblKnittingMachinesLog>(entity =>
            //{
            //    entity.ToTable("Tbl_KnittingMachines_log");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Brand)
            //        .HasColumnName("BRAND")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.Date)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Dia).HasColumnName("DIA");

            //    entity.Property(e => e.Rpm).HasColumnName("RPM");

            //    entity.Property(e => e.Slength)
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Userid).HasColumnName("userid");

            //    entity.Property(e => e.YType).HasColumnName("y_type");

            //    entity.Property(e => e.Ycount).HasColumnName("YCount");
            //});

            //modelBuilder.Entity<TblKnittingMinuteTime>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_KnittingMinuteTime");

            //    entity.Property(e => e.DayMinute).HasColumnType("datetime");

            //    entity.Property(e => e.MinuteId).HasColumnName("MinuteID");

            //    entity.Property(e => e.MinuteTypeId).HasColumnName("MinuteTypeID");
            //});

            //modelBuilder.Entity<TblKnittingPickListDetail>(entity =>
            //{
            //    entity.HasKey(e => e.PickListDetailId);

            //    entity.ToTable("tbl_KnittingPickListDetail");

            //    entity.HasIndex(e => new { e.PickListId, e.AttributeInstanceId })
            //        .HasName("Ind_tbl_KnittingPickListDetail_1");

            //    entity.Property(e => e.PickListDetailId).HasColumnName("PickListDetailID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.BatchDescription)
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PickListId).HasColumnName("PickListID");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");

            //    entity.HasOne(d => d.PickList)
            //        .WithMany(p => p.TblKnittingPickListDetail)
            //        .HasForeignKey(d => d.PickListId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_tbl_KnittingPickListDetail_tbl_KnittingPickListMaster");
            //});

            //modelBuilder.Entity<TblKnittingPickListMaster>(entity =>
            //{
            //    entity.HasKey(e => e.PickListId);

            //    entity.ToTable("tbl_KnittingPickListMaster");

            //    entity.Property(e => e.PickListId).HasColumnName("PickListID");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.PickListNo)
            //        .IsRequired()
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ReceivingPersonName)
            //        .IsRequired()
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.YarnKnittingContractId).HasColumnName("YarnKnittingContractID");

            //    entity.Property(e => e.YarnReceivingDate).HasColumnType("datetime");
            //});

            //modelBuilder.Entity<TblKnittingPickListRejection>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_KnittingPickListRejection");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.PickListId).HasColumnName("PickListID");

            //    entity.Property(e => e.RejectionId)
            //        .HasColumnName("RejectionID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.RejectionNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Status).HasDefaultValueSql("(0)");
            //});

            //modelBuilder.Entity<TblKnittingRolls>(entity =>
            //{
            //    entity.HasKey(e => e.RollId);

            //    entity.ToTable("tbl_KnittingRolls");

            //    entity.Property(e => e.RollId)
            //        .HasColumnName("RollID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.GateReceivingId).HasColumnName("GateReceivingID");

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.Machine).HasColumnName("MACHINE");

            //    entity.Property(e => e.ParentId).HasColumnName("ParentID");

            //    entity.Property(e => e.QualityId)
            //        .HasColumnName("QualityID")
            //        .HasDefaultValueSql("((1))");

            //    entity.Property(e => e.RollCode)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.RollCreationDate)
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.ShiftCode)
            //        .HasMaxLength(1)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Yarnlot)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<TblKnittingRollsAttributeSetup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_KnittingRolls_Attribute_Setup");

            //    entity.Property(e => e.RollAttrSetupDescription)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.RollAttrSetupId)
            //        .HasColumnName("RollAttrSetupID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<TblKnittingRollsQualitySetup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_KnittingRollsQuality_Setup");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.QualityId).HasColumnName("QualityID");
            //});

            //modelBuilder.Entity<TblKnittingRollsRollAttributes>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_KnittingRolls_Roll_Attributes");

            //    entity.Property(e => e.RollAttrDesc)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.RollAttrId)
            //        .HasColumnName("RollAttrID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.RollAttrSetupId).HasColumnName("RollAttrSetupID");

            //    entity.Property(e => e.RollId).HasColumnName("RollID");
            //});

            modelBuilder.Entity<tbl_KnittingStockTransaction>(entity =>
            {
                entity.HasKey(e => new { e.DocumentTypeID, e.RollID })
                    .HasName("PK_tbl_KnittingStockTransaction_1");

                //entity.ToTable("tbl_KnittingStockTransaction");

                entity.HasIndex(e => new { e.DocumentTypeID, e.RollID })
                    .HasName("IND_tbl_KnittingStockTransaction_1");

                //entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

                //entity.Property(e => e.RollId).HasColumnName("RollID");

                //entity.Property(e => e.Gsm).HasColumnName("GSM");

                //entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.StockTransactionID)
                    .HasColumnName("StockTransactionID")
                    .ValueGeneratedOnAdd();
            });

            //modelBuilder.Entity<TblKnittingStockTransaction27thMar2014>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_KnittingStockTransaction_27thMar2014");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.Gsm).HasColumnName("GSM");

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.RollId).HasColumnName("RollID");

            //    entity.Property(e => e.StockTransactionId).HasColumnName("StockTransactionID");
            //});

            //modelBuilder.Entity<TblKnittingSubPickListDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_KnittingSubPickListDetail");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.BatchDescription)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SubPickListDetailId)
            //        .HasColumnName("SubPickListDetailID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.SubPickListId).HasColumnName("SubPickListID");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");
            //});

            //modelBuilder.Entity<TblKnittingSubPickListMaster>(entity =>
            //{
            //    entity.HasKey(e => e.SubPickListId);

            //    entity.ToTable("tbl_KnittingSubPickListMaster");

            //    entity.HasIndex(e => e.MasterPickListId)
            //        .HasName("Ind_tbl_KnittingSubPickListMaster_1");

            //    entity.Property(e => e.SubPickListId).HasColumnName("SubPickListID");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.MasterPickListId).HasColumnName("MasterPickListID");

            //    entity.Property(e => e.ReceivingPersonName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SubPickListNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.YarnReceivingDate).HasColumnType("datetime");
            //});

            //modelBuilder.Entity<TblKnittingSubPickListRejection>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_KnittingSubPickListRejection");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.RejectionId)
            //        .HasColumnName("RejectionID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.RejectionNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SubPickListId).HasColumnName("SubPickListID");
            //});

            //modelBuilder.Entity<TblKnittingWorkOrderMaster>(entity =>
            //{
            //    entity.HasKey(e => e.WorkOrerId);

            //    entity.ToTable("tbl_KnittingWorkOrderMaster");

            //    entity.Property(e => e.WorkOrerId).HasColumnName("WorkOrerID");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.PickListId).HasColumnName("PickListID");

            //    entity.Property(e => e.SubPickListId).HasColumnName("SubPickListID");

            //    entity.Property(e => e.WorkOrderNo)
            //        .IsRequired()
            //        .HasMaxLength(10)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<TblKnittingYarnAssignment>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_KnittingYarnAssignment");

            //    entity.Property(e => e.AssignmentDate).HasColumnType("datetime");

            //    entity.Property(e => e.AssignmentId)
            //        .HasColumnName("AssignmentID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.SubPickListId).HasColumnName("SubPickListID");

            //    entity.Property(e => e.YarnKncontractId).HasColumnName("YarnKNContractID");
            //});

            //modelBuilder.Entity<TblKnittingYarnReturnDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_KnittingYarnReturnDetail");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.ReturnDetailId)
            //        .HasColumnName("ReturnDetailID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.ReturnId).HasColumnName("ReturnID");
            //});

            //modelBuilder.Entity<TblKnittingYarnReturnMaster>(entity =>
            //{
            //    entity.HasKey(e => e.ReturnId);

            //    entity.ToTable("tbl_KnittingYarnReturnMaster");

            //    entity.Property(e => e.ReturnId).HasColumnName("ReturnID");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.Status).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.YarnKnittingContractId).HasColumnName("YarnKnittingContractID");
            //});

            //modelBuilder.Entity<TblLayoutDetailes>(entity =>
            //{
            //    entity.ToTable("tbl_layout_detailes");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Creationdate)
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.EmpId).HasColumnName("empID");

            //    entity.Property(e => e.LineSlNo)
            //        .HasColumnName("line_sl_no")
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.Property(e => e.MachineId).HasColumnName("Machine_id");

            //    entity.Property(e => e.Processid).HasColumnName("processid");

            //    entity.Property(e => e.Smv)
            //        .HasColumnName("smv")
            //        .HasColumnType("decimal(5, 2)");

            //    entity.Property(e => e.Stocktransationid).HasColumnName("stocktransationid");

            //    entity.Property(e => e.TargetQty).HasColumnName("target_qty");
            //});

            //modelBuilder.Entity<TblLayoutEmpProductionEntry>(entity =>
            //{
            //    entity.ToTable("tbl_layout_emp_production_entry");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Alterqty).HasColumnName("alterqty");

            //    entity.Property(e => e.ClhId).HasColumnName("clh_id");

            //    entity.Property(e => e.Creationdate)
            //        .HasColumnName("creationdate")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.DefectQty).HasColumnName("defect_qty");

            //    entity.Property(e => e.Defectid).HasColumnName("defectid");

            //    entity.Property(e => e.Losttime).HasColumnName("losttime");

            //    entity.Property(e => e.ProductionQty).HasColumnName("production_qty");

            //    entity.Property(e => e.Remarks)
            //        .HasColumnName("remarks")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Userid).HasColumnName("userid");

            //    entity.Property(e => e.Workid).HasColumnName("workid");
            //});

            //modelBuilder.Entity<TblLayoutLine>(entity =>
            //{
            //    entity.ToTable("tbl_layout_Line");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.LineNo)
            //        .HasColumnName("line_no")
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.Property(e => e.LocationName)
            //        .HasColumnName("Location_Name")
            //        .HasMaxLength(120)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Userid).HasColumnName("userid");
            //});

            //modelBuilder.Entity<TblLayoutMaster>(entity =>
            //{
            //    entity.ToTable("tbl_layout_master");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Creationdate)
            //        .HasColumnName("creationdate")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.LineNo)
            //        .HasColumnName("line_no")
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Orderid).HasColumnName("orderid");

            //    entity.Property(e => e.Pantonno)
            //        .HasColumnName("pantonno")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Styleid).HasColumnName("styleid");

            //    entity.Property(e => e.Userid).HasColumnName("userid");
            //});

            //modelBuilder.Entity<TblLayoutProcess>(entity =>
            //{
            //    entity.ToTable("tbl_layout_Process");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ProcessName)
            //        .HasColumnName("Process_name")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<TblLayoutRemarks>(entity =>
            //{
            //    entity.ToTable("tbl_layout_remarks");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Remarks)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<TblLocation>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Tbl_Location");

            //    entity.Property(e => e.LocationId)
            //        .HasColumnName("Location_Id")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.LocationName)
            //        .HasColumnName("Location_Name")
            //        .HasMaxLength(255)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<TblLostTime>(entity =>
            //{
            //    entity.ToTable("Tbl_LostTime");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Comment)
            //        .HasColumnName("comment")
            //        .HasMaxLength(50);

            //    entity.Property(e => e.Date)
            //        .HasColumnName("date")
            //        .HasColumnType("smalldatetime");

            //    entity.Property(e => e.InputDate)
            //        .HasColumnName("input_date")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.LostTime).HasColumnName("lost_time");

            //    entity.Property(e => e.LostTypeId).HasColumnName("lost_type_id");

            //    entity.Property(e => e.McNo).HasColumnName("mc_no");

            //    entity.Property(e => e.Remarks)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Shift)
            //        .HasColumnName("shift")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ShiftTime).HasColumnName("shift_time");

            //    entity.Property(e => e.UserId).HasColumnName("userID");
            //});

            //modelBuilder.Entity<TblLosttype>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_losttype");

            //    entity.Property(e => e.Catagory)
            //        .HasColumnName("catagory")
            //        .HasDefaultValueSql("((1))");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.LostType)
            //        .HasColumnName("lost_type")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Serial)
            //        .HasColumnName("serial")
            //        .HasDefaultValueSql("((1))");
            //});

            //modelBuilder.Entity<TblLotStatus>(entity =>
            //{
            //    entity.HasKey(e => e.LotStatusId);

            //    entity.ToTable("tbl_lot_status");

            //    entity.Property(e => e.LotStatusId).HasColumnName("lot_status_id");

            //    entity.Property(e => e.LotComment)
            //        .HasColumnName("lot_comment")
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.LotEntryDate)
            //        .HasColumnName("lot_entry_date")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Lotid).HasColumnName("lotid");

            //    entity.Property(e => e.UserId).HasColumnName("user_id");
            //});

            //modelBuilder.Entity<TblLotStatusWGBuyer>(entity =>
            //{
            //    entity.HasKey(e => e.LotStatusId);

            //    entity.ToTable("tbl_lot_status_w_G_buyer");

            //    entity.Property(e => e.LotStatusId).HasColumnName("lot_status_id");

            //    entity.Property(e => e.LotComment)
            //        .HasColumnName("lot_comment")
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.LotEntryDate)
            //        .HasColumnName("lot_entry_date")
            //        .HasColumnType("smalldatetime");

            //    entity.Property(e => e.Lotid).HasColumnName("lotid");

            //    entity.Property(e => e.UserId).HasColumnName("user_id");
            //});

            //modelBuilder.Entity<TblMachineCategory>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Tbl_Machine_Category");

            //    entity.Property(e => e.CategoryId)
            //        .HasColumnName("CategoryID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.MachineCategoryName)
            //        .HasColumnName("Machine_CategoryName")
            //        .HasMaxLength(255)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<TblMachineRod>(entity =>
            //{
            //    entity.HasKey(e => e.MachineRodId);

            //    entity.ToTable("Tbl_MachineRod");

            //    entity.Property(e => e.MachineRodId)
            //        .HasColumnName("MachineRod_ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.MachineRodMachine).HasColumnName("MachineRod_Machine");

            //    entity.Property(e => e.MachineRodWeight).HasColumnName("MachineRod_Weight");
            //});

            //modelBuilder.Entity<TblMachineTypeSetup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_MachineType_Setup");

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(1000)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<TblMachines>(entity =>
            //{
            //    entity.HasKey(e => e.MachineId);

            //    entity.ToTable("tbl_Machines");

            //    entity.Property(e => e.MachineId).HasColumnName("MachineID");

            //    entity.Property(e => e.Brand)
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.FammachineId).HasColumnName("FAMMachineID");

            //    entity.Property(e => e.KnitterId).HasColumnName("KnitterID");

            //    entity.Property(e => e.MachineName)
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.MachineTypeId).HasColumnName("MachineTypeID");

            //    entity.Property(e => e.Model)
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Rpm).HasColumnName("RPM");

            //    entity.Property(e => e.Smv).HasColumnName("SMV");
            //});

            //modelBuilder.Entity<TblMarkerConsInfo>(entity =>
            //{
            //    entity.HasKey(e => e.MarkerConsId)
            //        .HasName("PK_tbl_marker_con_info");

            //    entity.ToTable("tbl_marker_cons_info");

            //    entity.Property(e => e.MarkerConsId).HasColumnName("marker_cons_ID");

            //    entity.Property(e => e.Buyerid).HasColumnName("buyerid");

            //    entity.Property(e => e.CadConsDz)
            //        .HasColumnName("cad_cons_dz")
            //        .HasColumnType("decimal(18, 3)");

            //    entity.Property(e => e.Companyid).HasColumnName("companyid");

            //    entity.Property(e => e.CosConsDz)
            //        .HasColumnName("cos_cons_dz")
            //        .HasColumnType("decimal(18, 3)");

            //    entity.Property(e => e.FabCostYrd)
            //        .HasColumnName("fab_cost_yrd")
            //        .HasColumnType("decimal(18, 3)");

            //    entity.Property(e => e.HDate)
            //        .HasColumnName("h_date")
            //        .HasColumnType("smalldatetime");

            //    entity.Property(e => e.OrderId).HasColumnName("order_id");

            //    entity.Property(e => e.StyleId).HasColumnName("style_id");

            //    entity.Property(e => e.UserId).HasColumnName("user_id");
            //});

            //modelBuilder.Entity<TblMarkerCreate>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_marker_create");

            //    entity.Property(e => e.Buyerid).HasColumnName("buyerid");

            //    entity.Property(e => e.Buyername)
            //        .HasColumnName("buyername")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Color)
            //        .HasColumnName("color")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Creationdate)
            //        .HasColumnName("creationdate")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Date)
            //        .HasColumnName("date")
            //        .HasColumnType("smalldatetime");

            //    entity.Property(e => e.FabricWidthFinish)
            //        .HasColumnName("fabric_width_finish")
            //        .HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.FabricWithOutside)
            //        .HasColumnName("fabric_with_outside")
            //        .HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.Fcomposition)
            //        .HasColumnName("fcomposition")
            //        .IsUnicode(false);

            //    entity.Property(e => e.Fquality)
            //        .HasColumnName("fquality")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Ftype)
            //        .HasColumnName("ftype")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Gsm)
            //        .HasColumnName("gsm")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Id)
            //        .HasColumnName("id")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Lotid).HasColumnName("lotid");

            //    entity.Property(e => e.Lotno)
            //        .HasColumnName("lotno")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.MLength)
            //        .HasColumnName("m_length")
            //        .HasColumnType("decimal(18, 4)");

            //    entity.Property(e => e.Orderid).HasColumnName("orderid");

            //    entity.Property(e => e.Orderno)
            //        .HasColumnName("orderno")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SizeRadio)
            //        .HasColumnName("size_radio")
            //        .IsUnicode(false);

            //    entity.Property(e => e.SizeRadioId).HasColumnName("size_radio_id");

            //    entity.Property(e => e.Styleid).HasColumnName("styleid");

            //    entity.Property(e => e.Userid).HasColumnName("userid");

            //    entity.Property(e => e.Username)
            //        .HasColumnName("username")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<TblMarkerFromPrint>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_marker_from_print");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("id")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.InputId).HasColumnName("input_id");

            //    entity.Property(e => e.Sizeid).HasColumnName("sizeid");

            //    entity.Property(e => e.Sizename)
            //        .HasColumnName("sizename")
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Sizeqty)
            //        .HasColumnName("sizeqty")
            //        .HasColumnType("decimal(18, 0)");
            //});

            //modelBuilder.Entity<TblMarkerInfo>(entity =>
            //{
            //    entity.HasKey(e => e.MarkerId);

            //    entity.ToTable("tbl_marker_info");

            //    entity.Property(e => e.MarkerId).HasColumnName("marker_ID");

            //    entity.Property(e => e.Buyerid).HasColumnName("buyerid");

            //    entity.Property(e => e.Companyid).HasColumnName("companyid");

            //    entity.Property(e => e.CreationDate)
            //        .HasColumnName("creation_date")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.CutMLength)
            //        .HasColumnName("cut_m_length")
            //        .HasColumnType("decimal(18, 2)")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.DeltaHor)
            //        .HasColumnName("delta_hor")
            //        .HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.DeltaVer)
            //        .HasColumnName("delta_ver")
            //        .HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.Efficiency).HasColumnType("decimal(18, 3)");

            //    entity.Property(e => e.HDate)
            //        .HasColumnName("h_date")
            //        .HasColumnType("smalldatetime");

            //    entity.Property(e => e.MGsm)
            //        .HasColumnName("m_gsm")
            //        .HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.MLayerWeight)
            //        .HasColumnName("m_layer_weight")
            //        .HasColumnType("decimal(18, 3)");

            //    entity.Property(e => e.MLength)
            //        .HasColumnName("m_length")
            //        .HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.MLengthType)
            //        .HasColumnName("m_length_type")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.MSizeRatio)
            //        .HasColumnName("m_size_ratio")
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.MWidth)
            //        .HasColumnName("m_width")
            //        .HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.MWidthType)
            //        .HasColumnName("m_width_type")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.MarkerConsumption)
            //        .HasColumnName("Marker_Consumption")
            //        .HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.MarkerName)
            //        .HasColumnName("marker_name")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PatternPiece).HasColumnName("Pattern_Piece");

            //    entity.Property(e => e.PlanDate)
            //        .HasColumnName("plan_date")
            //        .HasColumnType("smalldatetime");

            //    entity.Property(e => e.RequisitionId).HasColumnName("requisition_id");

            //    entity.Property(e => e.SpEndDateTime)
            //        .HasColumnName("sp_end_date_time")
            //        .HasColumnType("smalldatetime");

            //    entity.Property(e => e.SpreadingDate)
            //        .HasColumnName("Spreading_date")
            //        .HasColumnType("smalldatetime");

            //    entity.Property(e => e.SpreadingTable)
            //        .HasColumnName("Spreading_table")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId).HasColumnName("user_id");
            //});

            //modelBuilder.Entity<TblMarkerInputAccessInfo>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_marker_input_access_info");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Lavelid).HasColumnName("lavelid");

            //    entity.Property(e => e.ModifyData).HasColumnName("modify_data");

            //    entity.Property(e => e.Userid).HasColumnName("userid");
            //});

            //modelBuilder.Entity<TblMarkerInputConfirm>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_marker_input_confirm");

            //    entity.Property(e => e.CInputId).HasColumnName("c_input_id");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Location).HasColumnName("location");

            //    entity.Property(e => e.RcvDate)
            //        .HasColumnName("rcv_date")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Userid).HasColumnName("userid");
            //});

            //modelBuilder.Entity<TblMarkerInputDetails>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_marker_input_details");

            //    entity.Property(e => e.Bundleid).HasColumnName("bundleid");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("id")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.InputId).HasColumnName("input_id");

            //    entity.Property(e => e.Sizeid).HasColumnName("sizeid");

            //    entity.Property(e => e.Sizename)
            //        .HasColumnName("sizename")
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Sizeqty)
            //        .HasColumnName("sizeqty")
            //        .HasColumnType("decimal(18, 0)");
            //});

            //modelBuilder.Entity<TblMarkerInputInfo>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_marker_input_info");

            //    entity.Property(e => e.Bundleid).HasColumnName("bundleid");

            //    entity.Property(e => e.Buyername)
            //        .HasColumnName("buyername")
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CInputId)
            //        .HasColumnName("c_input_id")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Colorname)
            //        .HasColumnName("colorname")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Composition)
            //        .HasColumnName("composition")
            //        .IsUnicode(false);

            //    entity.Property(e => e.Creationdate)
            //        .HasColumnName("creationdate")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Cutoffid).HasColumnName("cutoffid");

            //    entity.Property(e => e.Ftype)
            //        .HasColumnName("ftype")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Linename)
            //        .HasColumnName("linename")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Location).HasColumnName("location");

            //    entity.Property(e => e.MarkerId).HasColumnName("marker_id");

            //    entity.Property(e => e.MarkerShortId).HasColumnName("marker_short_id");

            //    entity.Property(e => e.OldOrderid).HasColumnName("old_orderid");

            //    entity.Property(e => e.OldOrderno)
            //        .HasColumnName("old_orderno")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Orderid).HasColumnName("orderid");

            //    entity.Property(e => e.Orderno)
            //        .HasColumnName("orderno")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Styleid).HasColumnName("styleid");

            //    entity.Property(e => e.Stylename)
            //        .HasColumnName("stylename")
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Userid).HasColumnName("userid");
            //});

            //modelBuilder.Entity<TblMarkerPartDetails>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Tbl_marker_part_details");

            //    entity.Property(e => e.Active)
            //        .HasColumnName("active")
            //        .HasDefaultValueSql("((1))");

            //    entity.Property(e => e.Cmpdid)
            //        .HasColumnName("CMPDID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Cmpid).HasColumnName("CMPID");

            //    entity.Property(e => e.Creationdate)
            //        .HasColumnName("creationdate")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.PartName)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Sr).HasColumnName("sr");
            //});

            //modelBuilder.Entity<TblMarkerPartMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Tbl_marker_part_Master");

            //    entity.Property(e => e.Cmpid)
            //        .HasColumnName("CMPID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Cretiondate)
            //        .HasColumnName("cretiondate")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Panton)
            //        .HasColumnName("panton")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Styleid).HasColumnName("styleid");

            //    entity.Property(e => e.Userid).HasColumnName("userid");
            //});

            //modelBuilder.Entity<TblMarkerRadioDetailes>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_marker_radio_detailes");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Sizename)
            //        .HasColumnName("sizename")
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Sizeqty).HasColumnName("sizeqty");

            //    entity.Property(e => e.Sn).HasColumnName("SN");

            //    entity.Property(e => e.Stocktransationid).HasColumnName("stocktransationid");
            //});

            //modelBuilder.Entity<TblMarkerRadioMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_marker_Radio_master");

            //    entity.Property(e => e.Color)
            //        .HasColumnName("color")
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Creationdate)
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Fcomposition)
            //        .HasColumnName("fcomposition")
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Fquality)
            //        .HasColumnName("fquality")
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Ftype)
            //        .HasColumnName("ftype")
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.MarkerLength)
            //        .HasColumnName("marker_length")
            //        .HasColumnType("decimal(18, 4)");

            //    entity.Property(e => e.RadioName)
            //        .HasColumnName("radio_name")
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Userid).HasColumnName("userid");
            //});

            //modelBuilder.Entity<TblMarkerRoll>(entity =>
            //{
            //    entity.ToTable("tbl_marker_roll");

            //    entity.HasIndex(e => new { e.Orderid, e.PantonId, e.Rollid, e.Lotid })
            //        .HasName("NonClusteredIndex-20180104-160944");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.DLayer).HasColumnName("d_layer");

            //    entity.Property(e => e.Fstatus)
            //        .HasColumnName("fstatus")
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Leftover).HasColumnType("decimal(18, 3)");

            //    entity.Property(e => e.Lotid).HasColumnName("lotid");

            //    entity.Property(e => e.MLayer).HasColumnName("m_layer");

            //    entity.Property(e => e.Orderid).HasColumnName("orderid");

            //    entity.Property(e => e.PantonId).HasColumnName("panton_id");

            //    entity.Property(e => e.Rgsm).HasColumnName("rgsm");

            //    entity.Property(e => e.Rlength)
            //        .HasColumnName("rlength")
            //        .HasColumnType("decimal(18, 3)");

            //    entity.Property(e => e.Rweight)
            //        .HasColumnName("rweight")
            //        .HasColumnType("decimal(18, 3)");

            //    entity.Property(e => e.SpreadingDate)
            //        .HasColumnName("Spreading_date")
            //        .HasColumnType("smalldatetime");

            //    entity.Property(e => e.SpreadingTable)
            //        .HasColumnName("Spreading_table")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SpreadingWastage)
            //        .HasColumnName("Spreading_Wastage")
            //        .HasColumnType("decimal(18, 3)");

            //    entity.Property(e => e.StocktransationId).HasColumnName("stocktransationID");

            //    entity.Property(e => e.Width).HasColumnName("width");
            //});

            //modelBuilder.Entity<TblMarkerShortCutting>(entity =>
            //{
            //    entity.HasKey(e => e.MarkerShortId);

            //    entity.ToTable("tbl_marker_short_cutting");

            //    entity.Property(e => e.MarkerShortId).HasColumnName("marker_short_ID");

            //    entity.Property(e => e.Buyerid).HasColumnName("buyerid");

            //    entity.Property(e => e.Companyid).HasColumnName("companyid");

            //    entity.Property(e => e.Creationdate)
            //        .HasColumnName("creationdate")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.HDate)
            //        .HasColumnName("h_date")
            //        .HasColumnType("smalldatetime");

            //    entity.Property(e => e.Layer).HasColumnName("layer");

            //    entity.Property(e => e.OrderId).HasColumnName("order_id");

            //    entity.Property(e => e.Pantonno)
            //        .HasColumnName("pantonno")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Rollno)
            //        .HasColumnName("rollno")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StyleId).HasColumnName("style_id");

            //    entity.Property(e => e.UserId).HasColumnName("user_id");
            //});

            //modelBuilder.Entity<TblMarkerSize>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_marker_size");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.SizeName)
            //        .HasColumnName("size_name")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SizeQty).HasColumnName("Size_qty");

            //    entity.Property(e => e.StocktransationId).HasColumnName("stocktransationID");
            //});

            //modelBuilder.Entity<TblMonthDays>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Tbl_MonthDays");
            //});

            //modelBuilder.Entity<TblOperations>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Tbl_Operations");

            //    entity.Property(e => e.Gtid).HasColumnName("GTID");

            //    entity.Property(e => e.Operationid).ValueGeneratedOnAdd();

            //    entity.Property(e => e.Operationname)
            //        .HasColumnName("operationname")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<TblPendinglotNotificationComments>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Tbl_Pendinglot_Notification_comments");

            //    entity.Property(e => e.CommentDate)
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Lotno)
            //        .HasColumnName("LOTNO")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<TblProblem>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Tbl_Problem");

            //    entity.Property(e => e.Gtid).HasColumnName("GTID");

            //    entity.Property(e => e.Problemid).ValueGeneratedOnAdd();

            //    entity.Property(e => e.Problemname)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<TblRollDefects>(entity =>
            //{
            //    entity.ToTable("Tbl_RollDefects");

            //    entity.HasIndex(e => new { e.RollId, e.DefectId })
            //        .HasName("ID_Tbl_RollDefects_1");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Comment)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DefectId).HasColumnName("DefectID");

            //    entity.Property(e => e.DefectValue).HasColumnType("decimal(5, 2)");

            //    entity.Property(e => e.Feeder).HasColumnName("FEEDER");

            //    entity.Property(e => e.InspectionDate)
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.MacNo).HasColumnName("MacNO");

            //    entity.Property(e => e.Mdia).HasColumnName("MDIA");

            //    entity.Property(e => e.RollId).HasColumnName("RollID");

            //    entity.Property(e => e.Rpm).HasColumnName("RPM");

            //    entity.Property(e => e.Score).HasColumnType("decimal(3, 2)");

            //    entity.Property(e => e.Sl)
            //        .HasColumnName("SL")
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId).HasColumnName("user_id");

            //    entity.Property(e => e.YColor).HasColumnName("y_color");

            //    entity.Property(e => e.YType).HasColumnName("y_type");

            //    entity.Property(e => e.Ycount).HasColumnName("ycount");
            //});

            //modelBuilder.Entity<TblRollDefectsLog>(entity =>
            //{
            //    entity.ToTable("Tbl_RollDefects_log");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.Brand)
            //        .HasColumnName("BRAND")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.Date)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Dia).HasColumnName("DIA");

            //    entity.Property(e => e.RollId).HasColumnName("RollID");

            //    entity.Property(e => e.Rpm).HasColumnName("RPM");

            //    entity.Property(e => e.Slength)
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Userid).HasColumnName("userid");

            //    entity.Property(e => e.YType).HasColumnName("y_type");

            //    entity.Property(e => e.Ycount).HasColumnName("YCount");
            //});

            //modelBuilder.Entity<TblRollEditLog>(entity =>
            //{
            //    entity.HasKey(e => e.RollEditId)
            //        .HasName("PK_tbl_eoll_edit_log");

            //    entity.ToTable("tbl_roll_edit_log");

            //    entity.Property(e => e.RollEditId).HasColumnName("roll_edit_id");

            //    entity.Property(e => e.Creationdate)
            //        .HasColumnName("creationdate")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Dgsm)
            //        .HasColumnName("dgsm")
            //        .HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.Dweight)
            //        .HasColumnName("dweight")
            //        .HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.Dwidth)
            //        .HasColumnName("dwidth")
            //        .HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.Gsm)
            //        .HasColumnName("gsm")
            //        .HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.Lotid).HasColumnName("lotid");

            //    entity.Property(e => e.Rollid).HasColumnName("rollid");

            //    entity.Property(e => e.Rollweight)
            //        .HasColumnName("rollweight")
            //        .HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.Rollwidth)
            //        .HasColumnName("rollwidth")
            //        .HasColumnType("decimal(18, 2)");
            //});

            //modelBuilder.Entity<TblShortSizeQty>(entity =>
            //{
            //    entity.ToTable("tbl_short_size_qty");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.OrderId).HasColumnName("order_id");

            //    entity.Property(e => e.SizeQty).HasColumnName("size_qty");

            //    entity.Property(e => e.Sizename)
            //        .HasColumnName("sizename")
            //        .HasMaxLength(15)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StocktransationId).HasColumnName("stocktransationID");
            //});

            //modelBuilder.Entity<TblTempCutToPack>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_tempCutToPack");

            //    entity.Property(e => e.ColorId)
            //        .HasColumnName("ColorID")
            //        .HasColumnType("decimal(9, 0)");

            //    entity.Property(e => e.ColorName)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CutD)
            //        .HasColumnName("Cut_D")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.CutI)
            //        .HasColumnName("Cut_I")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.CutRj)
            //        .HasColumnName("Cut_Rj")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.EmbD)
            //        .HasColumnName("Emb_D")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.EmbI)
            //        .HasColumnName("Emb_I")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.EmbR)
            //        .HasColumnName("Emb_R")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.EmbRj)
            //        .HasColumnName("Emb_Rj")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.FinishC)
            //        .HasColumnName("Finish_C")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.FinishIss)
            //        .HasColumnName("Finish_Iss")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.FinishR)
            //        .HasColumnName("Finish_R")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.FinishRr)
            //        .HasColumnName("Finish_RR")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.OrderId)
            //        .HasColumnName("OrderID")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.OrderName)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OrderQty).HasColumnType("decimal(9, 0)");

            //    entity.Property(e => e.PatternPiece)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PatternPieceId)
            //        .HasColumnName("patternPieceID")
            //        .HasColumnType("decimal(9, 0)");

            //    entity.Property(e => e.PrintD)
            //        .HasColumnName("Print_D")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.PrintI)
            //        .HasColumnName("Print_I")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.PrintR)
            //        .HasColumnName("Print_R")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.PrintRj)
            //        .HasColumnName("Print_Rj")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.SizeId)
            //        .HasColumnName("SizeID")
            //        .HasColumnType("decimal(9, 0)");

            //    entity.Property(e => e.SizeName)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StitD)
            //        .HasColumnName("Stit_D")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.StitI)
            //        .HasColumnName("Stit_I")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.StitR)
            //        .HasColumnName("Stit_R")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.StitRj)
            //        .HasColumnName("Stit_Rj")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.StyleId)
            //        .HasColumnName("StyleID")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.StyleName)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.WashC)
            //        .HasColumnName("Wash_C")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.WashIss)
            //        .HasColumnName("Wash_Iss")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.WashR)
            //        .HasColumnName("Wash_R")
            //        .HasColumnType("decimal(18, 0)");
            //});

            //modelBuilder.Entity<TblTempCutToPackNew>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_tempCutToPack_New");

            //    entity.Property(e => e.ColorId)
            //        .HasColumnName("ColorID")
            //        .HasColumnType("decimal(9, 0)");

            //    entity.Property(e => e.ColorName)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CutD)
            //        .HasColumnName("Cut_D")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.CutI)
            //        .HasColumnName("Cut_I")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.CutRj)
            //        .HasColumnName("Cut_Rj")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.EmbD)
            //        .HasColumnName("Emb_D")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.EmbI)
            //        .HasColumnName("Emb_I")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.EmbR)
            //        .HasColumnName("Emb_R")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.EmbRj)
            //        .HasColumnName("Emb_Rj")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.FinishC)
            //        .HasColumnName("Finish_C")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.FinishIss)
            //        .HasColumnName("Finish_Iss")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.FinishR)
            //        .HasColumnName("Finish_R")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.FinishRr)
            //        .HasColumnName("Finish_RR")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.OrderId)
            //        .HasColumnName("OrderID")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.OrderName)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OrderQty).HasColumnType("decimal(9, 0)");

            //    entity.Property(e => e.PatternPiece)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PatternPieceId)
            //        .HasColumnName("patternPieceID")
            //        .HasColumnType("decimal(9, 0)");

            //    entity.Property(e => e.PrintD)
            //        .HasColumnName("Print_D")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.PrintI)
            //        .HasColumnName("Print_I")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.PrintR)
            //        .HasColumnName("Print_R")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.PrintRj)
            //        .HasColumnName("Print_Rj")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.SizeId)
            //        .HasColumnName("SizeID")
            //        .HasColumnType("decimal(9, 0)");

            //    entity.Property(e => e.SizeName)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StitD)
            //        .HasColumnName("Stit_D")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.StitI)
            //        .HasColumnName("Stit_I")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.StitR)
            //        .HasColumnName("Stit_R")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.StitRj)
            //        .HasColumnName("Stit_Rj")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.StyleId)
            //        .HasColumnName("StyleID")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.StyleName)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.WashC)
            //        .HasColumnName("Wash_C")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.WashIss)
            //        .HasColumnName("Wash_Iss")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.WashR)
            //        .HasColumnName("Wash_R")
            //        .HasColumnType("decimal(18, 0)");
            //});

            //modelBuilder.Entity<TblTempCutToPackStylewise>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_tempCutToPack_Stylewise");

            //    entity.Property(e => e.ColorId)
            //        .HasColumnName("ColorID")
            //        .HasColumnType("decimal(9, 0)");

            //    entity.Property(e => e.ColorName)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CutD)
            //        .HasColumnName("Cut_D")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.CutI)
            //        .HasColumnName("Cut_I")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.CutRj)
            //        .HasColumnName("Cut_Rj")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.EmbD)
            //        .HasColumnName("Emb_D")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.EmbI)
            //        .HasColumnName("Emb_I")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.EmbR)
            //        .HasColumnName("Emb_R")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.EmbRj)
            //        .HasColumnName("Emb_Rj")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.FinishC)
            //        .HasColumnName("Finish_C")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.FinishIss)
            //        .HasColumnName("Finish_Iss")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.FinishR)
            //        .HasColumnName("Finish_R")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.OrderId)
            //        .HasColumnName("OrderID")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.OrderName)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OrderQty).HasColumnType("decimal(9, 0)");

            //    entity.Property(e => e.PatternPiece)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PatternPieceId)
            //        .HasColumnName("patternPieceID")
            //        .HasColumnType("decimal(9, 0)");

            //    entity.Property(e => e.PrintD)
            //        .HasColumnName("Print_D")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.PrintI)
            //        .HasColumnName("Print_I")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.PrintR)
            //        .HasColumnName("Print_R")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.PrintRj)
            //        .HasColumnName("Print_Rj")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.SizeId)
            //        .HasColumnName("SizeID")
            //        .HasColumnType("decimal(9, 0)");

            //    entity.Property(e => e.SizeName)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StitD)
            //        .HasColumnName("Stit_D")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.StitI)
            //        .HasColumnName("Stit_I")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.StitR)
            //        .HasColumnName("Stit_R")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.StitRj)
            //        .HasColumnName("Stit_Rj")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.StyleId)
            //        .HasColumnName("StyleID")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.StyleName)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.WashC)
            //        .HasColumnName("Wash_C")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.WashIss)
            //        .HasColumnName("Wash_Iss")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.WashR)
            //        .HasColumnName("Wash_R")
            //        .HasColumnType("decimal(18, 0)");
            //});

            //modelBuilder.Entity<TblTempFlow2Transaction>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_tempFlow2Transaction");

            //    entity.Property(e => e.ColorId)
            //        .HasColumnName("ColorID")
            //        .HasColumnType("numeric(9, 0)");

            //    entity.Property(e => e.ColorName)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OrderId)
            //        .HasColumnName("OrderID")
            //        .HasColumnType("numeric(18, 0)");

            //    entity.Property(e => e.OrderName)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PatternPiece)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PatternPieceId)
            //        .HasColumnName("patternPieceID")
            //        .HasColumnType("numeric(9, 0)");

            //    entity.Property(e => e.Qty).HasColumnType("numeric(9, 0)");

            //    entity.Property(e => e.SizeId)
            //        .HasColumnName("SizeID")
            //        .HasColumnType("numeric(9, 0)");

            //    entity.Property(e => e.StyleId)
            //        .HasColumnName("StyleID")
            //        .HasColumnType("numeric(18, 0)");

            //    entity.Property(e => e.StyleName)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.TransType).HasColumnType("numeric(18, 0)");

            //    entity.Property(e => e.WorkCenterId)
            //        .HasColumnName("WorkCenterID")
            //        .HasColumnType("numeric(18, 0)");
            //});

            //modelBuilder.Entity<TblTempFlowReport>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_tempFlowReport");

            //    entity.Property(e => e.ColorId)
            //        .HasColumnName("ColorID")
            //        .HasColumnType("numeric(9, 0)");

            //    entity.Property(e => e.ColorName)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Dated)
            //        .HasMaxLength(25)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Mname)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OperationName)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OrderName)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PatternPiece)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PatternPieceId)
            //        .HasColumnName("patternPieceID")
            //        .HasColumnType("numeric(9, 0)");

            //    entity.Property(e => e.Qty).HasColumnType("numeric(9, 0)");

            //    entity.Property(e => e.SizeId)
            //        .HasColumnName("SizeID")
            //        .HasColumnType("numeric(9, 0)");

            //    entity.Property(e => e.StyleName)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<TblTempFlowTransaction>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_tempFlowTransaction");

            //    entity.Property(e => e.ColorId)
            //        .HasColumnName("ColorID")
            //        .HasColumnType("numeric(9, 0)");

            //    entity.Property(e => e.ColorName)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OrderId)
            //        .HasColumnName("OrderID")
            //        .HasColumnType("numeric(18, 0)");

            //    entity.Property(e => e.OrderName)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PatternPiece)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PatternPieceId)
            //        .HasColumnName("patternPieceID")
            //        .HasColumnType("numeric(9, 0)");

            //    entity.Property(e => e.Qty)
            //        .HasColumnType("numeric(9, 0)")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.SizeId)
            //        .HasColumnName("SizeID")
            //        .HasColumnType("numeric(9, 0)");

            //    entity.Property(e => e.StyleId)
            //        .HasColumnName("StyleID")
            //        .HasColumnType("numeric(18, 0)");

            //    entity.Property(e => e.StyleName)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.TransType)
            //        .HasColumnType("numeric(18, 0)")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.WorkCenterId)
            //        .HasColumnName("WorkCenterID")
            //        .HasColumnType("numeric(18, 0)");
            //});

            //modelBuilder.Entity<TblTempRoll>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_TempRoll");
            //});

            //modelBuilder.Entity<TblYarnTypeDet>(entity =>
            //{
            //    entity.HasKey(e => e.YtId);

            //    entity.ToTable("tbl_yarn_type_det");

            //    entity.Property(e => e.YtId)
            //        .HasColumnName("YT_ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.YarnDes)
            //        .IsRequired()
            //        .HasColumnName("yarn_des")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.YarnTypeCode)
            //        .IsRequired()
            //        .HasColumnName("yarn_type_code")
            //        .HasMaxLength(50);
            //});

            //modelBuilder.Entity<TblYarntype>(entity =>
            //{
            //    entity.HasKey(e => e.YtId)
            //        .HasName("PK__tbl_yarntype__4F371391");

            //    entity.ToTable("tbl_yarntype");

            //    entity.Property(e => e.YtId).HasColumnName("yt_id");

            //    entity.Property(e => e.YarnCode)
            //        .IsRequired()
            //        .HasColumnName("yarn_code")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.YarnCreated)
            //        .HasColumnName("Yarn_created")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.YarnCreatedBy).HasColumnName("Yarn_CreatedBy");

            //    entity.Property(e => e.YarnDesc)
            //        .IsRequired()
            //        .HasColumnName("yarn_desc")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<TempWashingChemicals>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("temp_Washing_Chemicals");

            //    entity.Property(e => e.Description).HasMaxLength(255);

            //    entity.Property(e => e.Purpose).HasMaxLength(255);

            //    entity.Property(e => e.SNo).HasColumnName("S#no");

            //    entity.Property(e => e.Supplier).HasMaxLength(255);

            //    entity.Property(e => e.Usage).HasMaxLength(255);
            //});

            //modelBuilder.Entity<TempWashingDyes>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("temp_Washing_Dyes");

            //    entity.Property(e => e.Description).HasMaxLength(255);

            //    entity.Property(e => e.Purpose).HasMaxLength(255);

            //    entity.Property(e => e.SNo).HasColumnName("S#no");

            //    entity.Property(e => e.Supplier).HasMaxLength(255);

            //    entity.Property(e => e.Usage).HasMaxLength(255);
            //});

            //modelBuilder.Entity<TempWashingItemsList>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Temp_WashingItemsList");

            //    entity.Property(e => e.Category).HasMaxLength(255);

            //    entity.Property(e => e.ItemId).HasColumnName("ItemID");

            //    entity.Property(e => e.ItemName).HasMaxLength(255);

            //    entity.Property(e => e.MatCatId).HasColumnName("MatCatID");

            //    entity.Property(e => e.Type).HasMaxLength(255);
            //});

            //modelBuilder.Entity<TempWashingOfficinaChemicals>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("temp_Washing_OfficinaChemicals");

            //    entity.Property(e => e.Description).HasMaxLength(255);

            //    entity.Property(e => e.Purpose).HasMaxLength(255);

            //    entity.Property(e => e.SNo).HasColumnName("S#no");

            //    entity.Property(e => e.Supplier).HasMaxLength(255);

            //    entity.Property(e => e.Usage).HasMaxLength(255);
            //});

            //modelBuilder.Entity<TempWashingOfficinaDyes>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("temp_Washing_OfficinaDyes");

            //    entity.Property(e => e.Description).HasMaxLength(255);

            //    entity.Property(e => e.Purpose).HasMaxLength(255);

            //    entity.Property(e => e.SNo).HasColumnName("S#no");

            //    entity.Property(e => e.Supplier).HasMaxLength(255);

            //    entity.Property(e => e.Usage).HasMaxLength(255);
            //});

            //modelBuilder.Entity<TemporaryBarCode>(entity =>
            //{
            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.BarCodeNo)
            //        .HasMaxLength(23)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ColorCode)
            //        .HasMaxLength(15)
            //        .IsUnicode(false);

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<Tkci>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("TKCI");

            //    entity.Property(e => e.Ajid).HasColumnName("AJID");

            //    entity.Property(e => e.Akcid).HasColumnName("AKCID");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.EndingDayMinuteId).HasColumnName("EndingDayMinuteID");

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.JobName)
            //        .IsRequired()
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.JobStatusId).HasColumnName("JobStatusID");

            //    entity.Property(e => e.MachineId).HasColumnName("MachineID");

            //    entity.Property(e => e.Pjid).HasColumnName("PJID");

            //    entity.Property(e => e.StartingDayMinuteId).HasColumnName("StartingDayMinuteID");

            //    entity.Property(e => e.YarnKnittingContractId).HasColumnName("YarnKnittingContractID");
            //});

            //modelBuilder.Entity<Trace>(entity =>
            //{
            //    entity.HasKey(e => e.RowNumber)
            //        .HasName("PK__trace__73347CE5");

            //    entity.ToTable("trace");

            //    entity.Property(e => e.ApplicationName).HasMaxLength(128);

            //    entity.Property(e => e.ClientProcessId).HasColumnName("ClientProcessID");

            //    entity.Property(e => e.Cpu).HasColumnName("CPU");

            //    entity.Property(e => e.LoginName).HasMaxLength(128);

            //    entity.Property(e => e.NtuserName)
            //        .HasColumnName("NTUserName")
            //        .HasMaxLength(128);

            //    entity.Property(e => e.Spid).HasColumnName("SPID");

            //    entity.Property(e => e.StartTime).HasColumnType("datetime");

            //    entity.Property(e => e.TextData).HasColumnType("ntext");
            //});

            //modelBuilder.Entity<Upomsewing>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("UPOMSewing");

            //    entity.Property(e => e.Brand).HasMaxLength(255);

            //    entity.Property(e => e.Category).HasMaxLength(255);

            //    entity.Property(e => e.Fam)
            //        .HasColumnName("FAM")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Floor).HasMaxLength(255);

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.LocationId).HasColumnName("LocationID");

            //    entity.Property(e => e.MachineNo).HasMaxLength(255);

            //    entity.Property(e => e.MotorTye).HasMaxLength(255);

            //    entity.Property(e => e.Origin)
            //        .HasColumnName("ORIGIN")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.Serial).HasMaxLength(255);

            //    entity.Property(e => e.SpecialFeature).HasMaxLength(255);

            //    entity.Property(e => e.Specification).HasMaxLength(255);

            //    entity.Property(e => e.Status).HasMaxLength(255);

            //    entity.Property(e => e.Type).HasMaxLength(255);
            //});

            //modelBuilder.Entity<Upomsewing1>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("UPOMSewing1");

            //    entity.Property(e => e.Brand).HasMaxLength(255);

            //    entity.Property(e => e.Category).HasMaxLength(255);

            //    entity.Property(e => e.Fam)
            //        .HasColumnName("FAM")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Floor).HasMaxLength(255);

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.MachineNo).HasMaxLength(255);

            //    entity.Property(e => e.MotorTye).HasMaxLength(255);

            //    entity.Property(e => e.Origin)
            //        .HasColumnName("ORIGIN")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.Serial).HasMaxLength(255);

            //    entity.Property(e => e.SpecialFeature).HasMaxLength(255);

            //    entity.Property(e => e.Specification).HasMaxLength(255);

            //    entity.Property(e => e.Status).HasMaxLength(255);

            //    entity.Property(e => e.Type).HasMaxLength(255);
            //});

            //modelBuilder.Entity<UpomsewingBk02Jan2016>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("upomsewing_Bk02Jan2016");

            //    entity.Property(e => e.Brand).HasMaxLength(255);

            //    entity.Property(e => e.Category).HasMaxLength(255);

            //    entity.Property(e => e.Fam)
            //        .HasColumnName("FAM")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Floor).HasMaxLength(255);

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.MachineNo).HasMaxLength(255);

            //    entity.Property(e => e.MotorTye).HasMaxLength(255);

            //    entity.Property(e => e.Origin)
            //        .HasColumnName("ORIGIN")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.Serial).HasMaxLength(255);

            //    entity.Property(e => e.SpecialFeature).HasMaxLength(255);

            //    entity.Property(e => e.Specification).HasMaxLength(255);

            //    entity.Property(e => e.Status).HasMaxLength(255);

            //    entity.Property(e => e.Type).HasMaxLength(255);
            //});

            //modelBuilder.Entity<VAgencyColorwiseTrack>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("v_AgencyColorwiseTrack");

            //    entity.Property(e => e.AgencyName)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.ChallanFlowIssueDate).HasColumnType("datetime");

            //    entity.Property(e => e.Collection)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ColorName)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Comments)
            //        .IsRequired()
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CommentsId).HasColumnName("Comments_ID");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.DocumentName)
            //        .IsRequired()
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.Htmlcode)
            //        .HasColumnName("HTMLCode")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.JobTicketId).HasColumnName("JobTicketID");

            //    entity.Property(e => e.OrderNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.PantoneNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PatternPiece)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StyleName)
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.TransDate).HasColumnType("datetime");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<VAgencyWorkCenterLink>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("v_Agency_WorkCenterLink");

            //    entity.Property(e => e.Mname)
            //        .IsRequired()
            //        .HasColumnName("MName")
            //        .HasMaxLength(200)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.WorkCenter)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.WorkCenterId).HasColumnName("WorkCenterID");
            //});

            //modelBuilder.Entity<VBarcodeTest>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("v_Barcode_test");

            //    entity.Property(e => e.BarCodeNo)
            //        .HasColumnName("BarCodeNO")
            //        .HasMaxLength(23)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ChallanId).HasColumnName("ChallanID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.Expr1).HasColumnType("datetime");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.QualityId).HasColumnName("QualityID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<VBarcodeTraceModelwise>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("v_Barcode_Trace_Modelwise");

            //    entity.Property(e => e.BarCodeNo)
            //        .HasColumnName("BarCodeNO")
            //        .HasMaxLength(23)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Dated).HasColumnType("datetime");

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Mname)
            //        .IsRequired()
            //        .HasColumnName("MName")
            //        .HasMaxLength(200)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.QualityId).HasColumnName("QualityID");
            //});

            //modelBuilder.Entity<VBundleInfo>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("v_BundleInfo");

            //    entity.Property(e => e.BodyPart)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.BundleId).HasColumnName("BundleID");

            //    entity.Property(e => e.BundleStatusId).HasColumnName("BundleStatusID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.PatternPiece)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.TrimId).HasColumnName("TrimID");
            //});

            //modelBuilder.Entity<VBundleMasterDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("v_BundleMaster_Detail");

            //    entity.Property(e => e.BundleStatusId).HasColumnName("BundleStatusID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.PatternPieceId).HasColumnName("PatternPieceID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<VChkQty>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("v_ChkQty");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");
            //});

            //modelBuilder.Entity<VCmtFinder>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("v_CMT_Finder");

            //    entity.Property(e => e.AssignedOrderNo)
            //        .IsRequired()
            //        .HasMaxLength(60)
            //        .IsUnicode(false);

            //    entity.Property(e => e.AssignedStyleNo)
            //        .HasMaxLength(60)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Mname)
            //        .IsRequired()
            //        .HasColumnName("MName")
            //        .HasMaxLength(200)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.WorkCenter)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.WorkCenterId).HasColumnName("WorkCenterID");
            //});

            //modelBuilder.Entity<VColorSizeWiseAgency>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("v_ColorSizeWiseAgency");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.PatternPieceId).HasColumnName("PatternPieceID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.TransCode).HasColumnName("Trans_Code");
            //});

            //modelBuilder.Entity<VDetailAgency>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("v_DetailAgency");

            //    entity.Property(e => e.AgencyName)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.ChallanFlowIssueDate).HasColumnType("datetime");

            //    entity.Property(e => e.Collection)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ColorName)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Comments)
            //        .IsRequired()
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CommentsId).HasColumnName("Comments_ID");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.Htmlcode)
            //        .HasColumnName("HTMLCode")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OrderNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.PantoneNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PatternPiece)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StyleName)
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.TransDate).HasColumnType("datetime");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<VErrorAgencyColor>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("v_Error_AgencyColor");

            //    entity.Property(e => e.AgencyAtt).HasColumnName("Agency Att");

            //    entity.Property(e => e.AgencyColor).HasColumnName("Agency Color");

            //    entity.Property(e => e.AgencyId).HasColumnName("AgencyID");

            //    entity.Property(e => e.AgencyPiece).HasColumnName("Agency Piece");

            //    entity.Property(e => e.AgencySize).HasColumnName("Agency Size");

            //    entity.Property(e => e.FlowAtt).HasColumnName("Flow Att");

            //    entity.Property(e => e.FlowColor).HasColumnName("Flow Color");

            //    entity.Property(e => e.FlowFabricColor).HasColumnName("Flow Fabric Color");

            //    entity.Property(e => e.FlowPiece).HasColumnName("Flow Piece");

            //    entity.Property(e => e.FlowSize).HasColumnName("Flow Size");

            //    entity.Property(e => e.TransDate).HasColumnType("datetime");
            //});

            //modelBuilder.Entity<VErrorAgencyPartialId>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("v_Error_Agency_PartialID");

            //    entity.Property(e => e.AgencyAtt).HasColumnName("Agency Att");

            //    entity.Property(e => e.AgencyColor).HasColumnName("Agency Color");

            //    entity.Property(e => e.AgencyId).HasColumnName("AgencyID");

            //    entity.Property(e => e.AgencyPiece).HasColumnName("Agency Piece");

            //    entity.Property(e => e.AgencySize).HasColumnName("Agency Size");

            //    entity.Property(e => e.CommentsId).HasColumnName("Comments_ID");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.FlowAtt).HasColumnName("Flow Att");

            //    entity.Property(e => e.FlowColor).HasColumnName("Flow Color");

            //    entity.Property(e => e.FlowPiece).HasColumnName("Flow Piece");

            //    entity.Property(e => e.FlowSize).HasColumnName("Flow Size");

            //    entity.Property(e => e.PartialId).HasColumnName("Partial_ID");

            //    entity.Property(e => e.TransDate).HasColumnType("datetime");
            //});

            //modelBuilder.Entity<VStyleColorSize>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("v_Style_Color_Size");

            //    entity.Property(e => e.ColorName)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ColorSetId).HasColumnName("ColorSetID");

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.PantoneNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.SizeName)
            //        .IsRequired()
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.SizeSetId).HasColumnName("SizeSetID");
            //});

            //modelBuilder.Entity<VTest>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("v_Test");

            //    entity.Property(e => e.AssignedStyleId)
            //        .HasColumnName("AssignedStyleID")
            //        .HasColumnType("numeric(18, 0)");

            //    entity.Property(e => e.ColorId)
            //        .HasColumnName("ColorID")
            //        .HasColumnType("decimal(9, 0)");

            //    entity.Property(e => e.ColorName)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OrderId)
            //        .HasColumnName("OrderID")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.OrderName)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OrderQty).HasColumnType("decimal(9, 0)");

            //    entity.Property(e => e.PatternPiece)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PatternPieceId)
            //        .HasColumnName("PatternPieceID")
            //        .HasColumnType("decimal(9, 0)");

            //    entity.Property(e => e.SizeId)
            //        .HasColumnName("SizeID")
            //        .HasColumnType("decimal(9, 0)");

            //    entity.Property(e => e.SizeName)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StyleId)
            //        .HasColumnName("StyleID")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.StyleName)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<VacumTable>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Vacum_Table");

            //    entity.Property(e => e.Brand).HasMaxLength(250);

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Location).HasMaxLength(250);

            //    entity.Property(e => e.Origin).HasMaxLength(250);

            //    entity.Property(e => e.PurchaseYear).HasMaxLength(250);

            //    entity.Property(e => e.Serial).HasMaxLength(250);

            //    entity.Property(e => e.Specification).HasMaxLength(250);

            //    entity.Property(e => e.Status).HasMaxLength(250);

            //    entity.Property(e => e.Type).HasMaxLength(250);
            //});

            //modelBuilder.Entity<View1>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("VIEW1");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");
            //});

            //modelBuilder.Entity<VwMinMaxStitDate>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("vw_MinMaxStitDate");

            //    entity.Property(e => e.EdDateVal).HasColumnName("edDateVal");

            //    entity.Property(e => e.StDateVal).HasColumnName("stDateVal");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<WashingActivity>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Washing_Activity");

            //    entity.Property(e => e.WashingActivityDate)
            //        .HasColumnName("Washing_ActivityDate")
            //        .HasColumnType("smalldatetime");

            //    entity.Property(e => e.WashingActivityId)
            //        .HasColumnName("Washing_ActivityID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.WashingActivityName)
            //        .IsRequired()
            //        .HasColumnName("Washing_ActivityName")
            //        .HasMaxLength(255)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<WashingActivityProcess>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Washing_Activity_Process");

            //    entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

            //    entity.Property(e => e.FabricCategoryId).HasColumnName("FabricCategoryID");

            //    entity.Property(e => e.ProcessId).HasColumnName("ProcessID");

            //    entity.Property(e => e.SetupCodeId).HasColumnName("SetupCodeID");
            //});

            //modelBuilder.Entity<WashingCollectionRecipeSetupMaster>(entity =>
            //{
            //    entity.HasKey(e => e.RecipeMasterId);

            //    entity.ToTable("Washing_Collection_RecipeSetup_Master");

            //    entity.Property(e => e.RecipeMasterId).HasColumnName("RecipeMasterID");

            //    entity.Property(e => e.Approved).HasDefaultValueSql("((0))");

            //    entity.Property(e => e.ApprovedOn).HasColumnType("datetime");

            //    entity.Property(e => e.CollectionId).HasColumnName("CollectionID");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.FabricCategoryId).HasColumnName("FabricCategoryID");

            //    entity.Property(e => e.FabricSpecificationColorId).HasColumnName("FabricSpecificationColorID");

            //    entity.Property(e => e.ModelId).HasColumnName("ModelID");

            //    entity.Property(e => e.PantoneNo).IsUnicode(false);

            //    entity.Property(e => e.ParentRecipeId).HasColumnName("ParentRecipeID");

            //    entity.Property(e => e.RecipeName).IsRequired();

            //    entity.Property(e => e.RecipeStageId).HasColumnName("RecipeStageID");

            //    entity.Property(e => e.RecipeSubTypeId).HasColumnName("RecipeSubTypeID");

            //    entity.Property(e => e.RecipeTypeId).HasColumnName("RecipeTypeID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<WashingCollectionRecipeSetupMaterial>(entity =>
            //{
            //    entity.ToTable("Washing_Collection_RecipeSetup_Material");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ItemId).HasColumnName("ItemID");

            //    entity.Property(e => e.ItemPerUnitId).HasColumnName("ItemPerUnitID");

            //    entity.Property(e => e.ItemUnitId).HasColumnName("ItemUnitID");

            //    entity.Property(e => e.MaterialCategoryId).HasColumnName("MaterialCategoryID");

            //    entity.Property(e => e.MaterialTypeId).HasColumnName("MaterialTypeID");

            //    entity.Property(e => e.RecipeProcessId).HasColumnName("RecipeProcessID");

            //    entity.Property(e => e.Rpm).HasColumnName("RPM");
            //});

            //modelBuilder.Entity<WashingCollectionRecipeSetupProcess>(entity =>
            //{
            //    entity.ToTable("Washing_Collection_RecipeSetup_Process");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.HasMachineRpm).HasColumnName("HasMachineRPM");

            //    entity.Property(e => e.HasPh).HasColumnName("HasPH");

            //    entity.Property(e => e.MachineRpm).HasColumnName("MachineRPM");

            //    entity.Property(e => e.MachineType).IsUnicode(false);

            //    entity.Property(e => e.ParentProcessId).HasColumnName("ParentProcessID");

            //    entity.Property(e => e.Ph).HasColumnName("PH");

            //    entity.Property(e => e.ProcessId).HasColumnName("ProcessID");

            //    entity.Property(e => e.ProcessName).IsUnicode(false);

            //    entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

            //    entity.Property(e => e.TemperatureUnit).IsUnicode(false);

            //    entity.Property(e => e.TemperatureUnitId).HasColumnName("TemperatureUnitID");

            //    entity.Property(e => e.TimeUnit).IsUnicode(false);

            //    entity.Property(e => e.TimeUnitId).HasColumnName("TimeUnitID");
            //});

            //modelBuilder.Entity<WashingCollectionRecipeSetupRpmrange>(entity =>
            //{
            //    entity.ToTable("Washing_Collection_RecipeSetup_RPMRange");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.RecipeProcessId).HasColumnName("RecipeProcessID");

            //    entity.Property(e => e.Rpm).HasColumnName("RPM");

            //    entity.Property(e => e.Sno).HasColumnName("SNo");
            //});

            //modelBuilder.Entity<WashingCollectionRecipeSetupTemperatureRange>(entity =>
            //{
            //    entity.ToTable("Washing_Collection_RecipeSetup_TemperatureRange");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.RecipeProcessId).HasColumnName("RecipeProcessID");

            //    entity.Property(e => e.Sno).HasColumnName("SNo");
            //});

            //modelBuilder.Entity<WashingExecutionPlanMaster>(entity =>
            //{
            //    entity.ToTable("Washing_ExecutionPlan_Master");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ColorSetId).HasColumnName("ColorSetID");

            //    entity.Property(e => e.Firmed).HasDefaultValueSql("((0))");

            //    entity.Property(e => e.FirmedOn).HasColumnType("smalldatetime");

            //    entity.Property(e => e.Rdate)
            //        .HasColumnName("RDate")
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.Property(e => e.VariationNo).IsUnicode(false);
            //});

            //modelBuilder.Entity<WashingExecutionPlanStage>(entity =>
            //{
            //    entity.ToTable("Washing_ExecutionPlan_Stage");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.PlanId).HasColumnName("PlanID");

            //    entity.Property(e => e.RequisitionId).HasColumnName("RequisitionID");

            //    entity.Property(e => e.StageNo).IsUnicode(false);
            //});

            //modelBuilder.Entity<WashingExecutionPlanStageLot>(entity =>
            //{
            //    entity.ToTable("Washing_ExecutionPlan_StageLot");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.CapacityUnitId).HasColumnName("CapacityUnitID");

            //    entity.Property(e => e.ExecutionTime).HasColumnType("datetime");

            //    entity.Property(e => e.FinalizedOn).HasColumnType("datetime");

            //    entity.Property(e => e.FirmedOn).HasColumnType("datetime");

            //    entity.Property(e => e.IsFinalized)
            //        .HasColumnName("isFinalized")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.LotNo).IsUnicode(false);

            //    entity.Property(e => e.MachineId).HasColumnName("MachineID");

            //    entity.Property(e => e.ParentLotId).HasColumnName("ParentLotID");

            //    entity.Property(e => e.Rdate)
            //        .HasColumnName("RDate")
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

            //    entity.Property(e => e.StageId).HasColumnName("StageID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<WashingExecutionPlanStageLotBom>(entity =>
            //{
            //    entity.ToTable("Washing_ExecutionPlan_StageLotBOM");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.IsSubstitute)
            //        .HasColumnName("isSubstitute")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.ItemId).HasColumnName("ItemID");

            //    entity.Property(e => e.LotId).HasColumnName("LotID");

            //    entity.Property(e => e.RecipeMaterialId).HasColumnName("RecipeMaterialID");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");
            //});

            //modelBuilder.Entity<WashingExecutionPlanStageProcess>(entity =>
            //{
            //    entity.ToTable("Washing_ExecutionPlan_StageProcess");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.RecipeProcessId).HasColumnName("RecipeProcessID");

            //    entity.Property(e => e.StageId).HasColumnName("StageID");
            //});

            //modelBuilder.Entity<WashingItemDetail>(entity =>
            //{
            //    entity.ToTable("Washing_Item_Detail");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ItemId).HasColumnName("ItemID");

            //    entity.Property(e => e.MasterId).HasColumnName("MasterID");

            //    entity.Property(e => e.UnitId)
            //        .HasColumnName("UnitID")
            //        .HasDefaultValueSql("((18))");
            //});

            //modelBuilder.Entity<WashingItemDetail1>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Washing_Item_Detail1");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.ItemId).HasColumnName("ItemID");

            //    entity.Property(e => e.MasterId).HasColumnName("MasterID");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");
            //});

            //modelBuilder.Entity<WashingItemMaster>(entity =>
            //{
            //    entity.ToTable("Washing_Item_Master");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Date)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<WashingItemUnits>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Washing_ItemUnits");

            //    entity.Property(e => e.BaseUnitId).HasColumnName("BaseUnitID");

            //    entity.Property(e => e.CmblunitId).HasColumnName("CMBLUnitID");

            //    entity.Property(e => e.UnitId)
            //        .HasColumnName("UnitID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<WashingLotDetail>(entity =>
            //{
            //    entity.ToTable("Washing_Lot_Detail");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.LotMasterId).HasColumnName("LotMasterID");

            //    entity.Property(e => e.ModelId).HasColumnName("ModelID");
            //});

            //modelBuilder.Entity<WashingLotExecution>(entity =>
            //{
            //    entity.ToTable("Washing_Lot_Execution");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.LotId).HasColumnName("LotID");

            //    entity.Property(e => e.Rdate)
            //        .HasColumnName("RDate")
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<WashingLotMaster>(entity =>
            //{
            //    entity.HasKey(e => e.LotMasterId);

            //    entity.ToTable("Washing_Lot_Master");

            //    entity.Property(e => e.LotMasterId).HasColumnName("LotMasterID");

            //    entity.Property(e => e.Comments).IsUnicode(false);

            //    entity.Property(e => e.Date)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.IsFinalized)
            //        .HasColumnName("isFinalized")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.LotNo).IsUnicode(false);

            //    entity.Property(e => e.ParentRecipeId).HasColumnName("ParentRecipeID");

            //    entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

            //    entity.Property(e => e.RequisitionId).HasColumnName("RequisitionID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<WashingLotStageDetail>(entity =>
            //{
            //    entity.ToTable("Washing_LotStage_Detail");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.RecipeProcessId).HasColumnName("RecipeProcessID");

            //    entity.Property(e => e.StageId).HasColumnName("StageID");
            //});

            //modelBuilder.Entity<WashingLotStageMaster>(entity =>
            //{
            //    entity.ToTable("Washing_LotStage_Master");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.CapacityUnitId).HasColumnName("CapacityUnitID");

            //    entity.Property(e => e.IsFinalized)
            //        .HasColumnName("isFinalized")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.LotMasterId).HasColumnName("LotMasterID");

            //    entity.Property(e => e.MachineId).HasColumnName("MachineID");

            //    entity.Property(e => e.Rdate)
            //        .HasColumnName("RDate")
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.StageNo).IsUnicode(false);
            //});

            //modelBuilder.Entity<WashingLotToppingDetail>(entity =>
            //{
            //    entity.ToTable("Washing_LotTopping_Detail");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.RecipeMaterialId).HasColumnName("RecipeMaterialID");

            //    entity.Property(e => e.ToppingMasterId).HasColumnName("ToppingMasterID");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");
            //});

            //modelBuilder.Entity<WashingLotToppingMaster>(entity =>
            //{
            //    entity.ToTable("Washing_LotTopping_Master");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Comments).IsUnicode(false);

            //    entity.Property(e => e.CreationDate)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.LotId).HasColumnName("LotID");

            //    entity.Property(e => e.RequisitionId).HasColumnName("RequisitionID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<WashingMachineSetup>(entity =>
            //{
            //    entity.HasKey(e => e.MachineId);

            //    entity.ToTable("Washing_Machine_Setup");

            //    entity.Property(e => e.MachineId).HasColumnName("MachineID");

            //    entity.Property(e => e.CapacityUnitId).HasColumnName("CapacityUnitID");

            //    entity.Property(e => e.Date)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.DepartmentNo).HasMaxLength(50);

            //    entity.Property(e => e.FamassetId).HasColumnName("FAMAssetID");

            //    entity.Property(e => e.IsProduction).HasColumnName("isProduction");

            //    entity.Property(e => e.MachineCapacity).HasColumnType("money");

            //    entity.Property(e => e.MachineName)
            //        .IsRequired()
            //        .HasMaxLength(250);

            //    entity.Property(e => e.MachineTypeId).HasColumnName("MachineTypeID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<WashingMachineStatusSetup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Washing_MachineStatus_Setup");

            //    entity.Property(e => e.StatusId)
            //        .HasColumnName("StatusID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<WashingMachineTypeAssociationProcessCode>(entity =>
            //{
            //    entity.ToTable("Washing_MachineTypeAssociationProcessCode");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.MachineTypeId).HasColumnName("MachineTypeID");

            //    entity.Property(e => e.ProcessCodeId).HasColumnName("ProcessCodeID");
            //});

            //modelBuilder.Entity<WashingMachineTypeSetup>(entity =>
            //{
            //    entity.HasKey(e => e.MachineTypeId);

            //    entity.ToTable("Washing_MachineTypeSetup");

            //    entity.Property(e => e.MachineTypeId).HasColumnName("MachineTypeID");

            //    entity.Property(e => e.Date)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.MachineTypeName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<WashingMachineTypeToProcessAssociationDetail>(entity =>
            //{
            //    entity.ToTable("Washing_MachineTypeToProcessAssociation_Detail");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.FabricCategoryId).HasColumnName("FabricCategoryID");

            //    entity.Property(e => e.IsWetProcess)
            //        .IsRequired()
            //        .HasDefaultValueSql("((1))");

            //    entity.Property(e => e.MachineTypeId).HasColumnName("MachineTypeID");

            //    entity.Property(e => e.MasterId).HasColumnName("MasterID");

            //    entity.Property(e => e.ProcessCodeId).HasColumnName("ProcessCodeID");
            //});

            //modelBuilder.Entity<WashingMachineTypeToProcessAssociationMaster>(entity =>
            //{
            //    entity.ToTable("Washing_MachineTypeToProcessAssociation_Master");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Date)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<WashingMaterialSetup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Washing_MaterialSetup");

            //    entity.Property(e => e.Date)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.MaterialTypeId).HasColumnName("MaterialTypeID");

            //    entity.Property(e => e.Name)
            //        .HasColumnName("NAME")
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId)
            //        .HasColumnName("UserID")
            //        .HasDefaultValueSql("((420))");
            //});

            //modelBuilder.Entity<WashingMaterialSetup1>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Washing_MaterialSetup1");

            //    entity.Property(e => e.Date).HasColumnType("datetime");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.MaterialTypeId).HasColumnName("MaterialTypeID");

            //    entity.Property(e => e.Name)
            //        .HasColumnName("NAME")
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<WashingMaterialTypeSetup>(entity =>
            //{
            //    entity.HasKey(e => e.MaterialTypeId);

            //    entity.ToTable("Washing_MaterialTypeSetup");

            //    entity.Property(e => e.MaterialTypeId).HasColumnName("MaterialTypeID");

            //    entity.Property(e => e.Date)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.MaterialTypeName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId)
            //        .HasColumnName("UserID")
            //        .HasDefaultValueSql("((420))");
            //});

            //modelBuilder.Entity<WashingMaterialTypeToItemAssociationDetail>(entity =>
            //{
            //    entity.ToTable("Washing_MaterialTypeToItemAssociation_Detail");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ItemId).HasColumnName("ItemID");

            //    entity.Property(e => e.MasterId).HasColumnName("MasterID");

            //    entity.Property(e => e.MaterialTypeId).HasColumnName("MaterialTypeID");

            //    entity.Property(e => e.Rdate)
            //        .HasColumnName("RDate")
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<WashingMaterialTypeToItemAssociationMaster>(entity =>
            //{
            //    entity.ToTable("Washing_MaterialTypeToItemAssociation_Master");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Date)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<WashingMaterialTypeToProcessAssociationDetail>(entity =>
            //{
            //    entity.ToTable("Washing_MaterialTypeToProcessAssociation_Detail");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.MasterId).HasColumnName("MasterID");

            //    entity.Property(e => e.MaterialTypeId).HasColumnName("MaterialTypeID");

            //    entity.Property(e => e.ProcessCodeId).HasColumnName("ProcessCodeID");
            //});

            //modelBuilder.Entity<WashingMaterialTypeToProcessAssociationDetail1>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Washing_MaterialTypeToProcessAssociation_Detail_1");

            //    entity.Property(e => e.Materialtypeid).HasColumnName("materialtypeid");

            //    entity.Property(e => e.Processcodeid).HasColumnName("processcodeid");
            //});

            //modelBuilder.Entity<WashingMaterialTypeToProcessAssociationMaster>(entity =>
            //{
            //    entity.ToTable("Washing_MaterialTypeToProcessAssociation_Master");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Date)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.FabricCategoryId).HasColumnName("FabricCategoryID");

            //    entity.Property(e => e.IsWetProcess)
            //        .IsRequired()
            //        .HasDefaultValueSql("((1))");

            //    entity.Property(e => e.ProcessCodeId).HasColumnName("ProcessCodeID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<WashingProcessCodeSetup>(entity =>
            //{
            //    entity.HasKey(e => e.ProcessId);

            //    entity.ToTable("Washing_ProcessCode_Setup");

            //    entity.Property(e => e.ProcessId).HasColumnName("ProcessID");

            //    entity.Property(e => e.Date).HasColumnType("datetime");

            //    entity.Property(e => e.FabricCategoryId)
            //        .HasColumnName("FabricCategoryID")
            //        .HasDefaultValueSql("((1))");

            //    entity.Property(e => e.ParentId).HasColumnName("ParentID");

            //    entity.Property(e => e.ProcessName)
            //        .IsRequired()
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<WashingProcessCodeSetupBk>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Washing_ProcessCode_Setup_BK");

            //    entity.Property(e => e.Date).HasColumnType("datetime");

            //    entity.Property(e => e.FabricCategoryId).HasColumnName("FabricCategoryID");

            //    entity.Property(e => e.ParentId).HasColumnName("ParentID");

            //    entity.Property(e => e.ProcessId)
            //        .HasColumnName("ProcessID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.ProcessName)
            //        .IsRequired()
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<WashingProcessSequence>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Washing_ProcessSequence");

            //    entity.Property(e => e.ChildProcessId).HasColumnName("ChildProcessID");

            //    entity.Property(e => e.ParentProcessId).HasColumnName("ParentProcessID");

            //    entity.Property(e => e.SequenceId)
            //        .HasColumnName("SequenceID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<WashingRecipeOptionsToProcessAssociationDetail>(entity =>
            //{
            //    entity.ToTable("Washing_RecipeOptionsToProcessAssociation_Detail");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ExecutionUnitId).HasColumnName("ExecutionUnitID");

            //    entity.Property(e => e.FabricCategoryId).HasColumnName("FabricCategoryID");

            //    entity.Property(e => e.IsLiquorRatioExceptional)
            //        .HasColumnName("isLiquorRatioExceptional")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.Lr).HasColumnName("LR");

            //    entity.Property(e => e.MachineRpm).HasColumnName("MachineRPM");

            //    entity.Property(e => e.MasterId).HasColumnName("MasterID");

            //    entity.Property(e => e.Ph).HasColumnName("PH");

            //    entity.Property(e => e.Phvalue).HasColumnName("PHValue");

            //    entity.Property(e => e.ProcessCodeId).HasColumnName("ProcessCodeID");

            //    entity.Property(e => e.Rpm).HasColumnName("RPM");
            //});

            //modelBuilder.Entity<WashingRecipeOptionsToProcessAssociationMaster>(entity =>
            //{
            //    entity.ToTable("Washing_RecipeOptionsToProcessAssociation_Master");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Date)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<WashingRecipeSetupMaster>(entity =>
            //{
            //    entity.HasKey(e => e.RecipeMasterId);

            //    entity.ToTable("Washing_RecipeSetup_Master");

            //    entity.Property(e => e.RecipeMasterId).HasColumnName("RecipeMasterID");

            //    entity.Property(e => e.Approved).HasDefaultValueSql("((0))");

            //    entity.Property(e => e.ApprovedOn).HasColumnType("datetime");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.FabricCategoryId).HasColumnName("FabricCategoryID");

            //    entity.Property(e => e.FabricSpecificationColorId).HasColumnName("FabricSpecificationColorID");

            //    entity.Property(e => e.ModelId).HasColumnName("ModelID");

            //    entity.Property(e => e.PantoneNo).IsUnicode(false);

            //    entity.Property(e => e.ParentRecipeId).HasColumnName("ParentRecipeID");

            //    entity.Property(e => e.RecipeName).IsRequired();

            //    entity.Property(e => e.RecipeStageId).HasColumnName("RecipeStageID");

            //    entity.Property(e => e.RecipeSubTypeId).HasColumnName("RecipeSubTypeID");

            //    entity.Property(e => e.RecipeTypeId).HasColumnName("RecipeTypeID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<WashingRecipeSetupMaterial>(entity =>
            //{
            //    entity.ToTable("Washing_RecipeSetup_Material");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ItemId).HasColumnName("ItemID");

            //    entity.Property(e => e.ItemPerUnitId).HasColumnName("ItemPerUnitID");

            //    entity.Property(e => e.ItemUnitId).HasColumnName("ItemUnitID");

            //    entity.Property(e => e.MaterialCategoryId).HasColumnName("MaterialCategoryID");

            //    entity.Property(e => e.MaterialTypeId).HasColumnName("MaterialTypeID");

            //    entity.Property(e => e.RecipeProcessId).HasColumnName("RecipeProcessID");

            //    entity.Property(e => e.Rpm).HasColumnName("RPM");
            //});

            //modelBuilder.Entity<WashingRecipeSetupMaterialSubstitution>(entity =>
            //{
            //    entity.ToTable("Washing_RecipeSetup_MaterialSubstitution");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ItemId).HasColumnName("ItemID");

            //    entity.Property(e => e.ItemPerUnitId).HasColumnName("ItemPerUnitID");

            //    entity.Property(e => e.ItemUnitId).HasColumnName("ItemUnitID");

            //    entity.Property(e => e.MaterialCategoryId).HasColumnName("MaterialCategoryID");

            //    entity.Property(e => e.MaterialTypeId).HasColumnName("MaterialTypeID");

            //    entity.Property(e => e.Rdate)
            //        .HasColumnName("RDate")
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.RecipeMaterialId).HasColumnName("RecipeMaterialID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<WashingRecipeSetupProcess>(entity =>
            //{
            //    entity.ToTable("Washing_RecipeSetup_Process");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.HasMachineRpm).HasColumnName("HasMachineRPM");

            //    entity.Property(e => e.HasPh).HasColumnName("HasPH");

            //    entity.Property(e => e.MachineRpm).HasColumnName("MachineRPM");

            //    entity.Property(e => e.MachineType).IsUnicode(false);

            //    entity.Property(e => e.ParentProcessId).HasColumnName("ParentProcessID");

            //    entity.Property(e => e.Ph).HasColumnName("PH");

            //    entity.Property(e => e.ProcessId).HasColumnName("ProcessID");

            //    entity.Property(e => e.ProcessName).IsUnicode(false);

            //    entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

            //    entity.Property(e => e.TemperatureUnit).IsUnicode(false);

            //    entity.Property(e => e.TemperatureUnitId).HasColumnName("TemperatureUnitID");

            //    entity.Property(e => e.TimeUnit).IsUnicode(false);

            //    entity.Property(e => e.TimeUnitId).HasColumnName("TimeUnitID");
            //});

            //modelBuilder.Entity<WashingRecipeSetupRpmrange>(entity =>
            //{
            //    entity.ToTable("Washing_RecipeSetup_RPMRange");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.RecipeProcessId).HasColumnName("RecipeProcessID");

            //    entity.Property(e => e.Rpm).HasColumnName("RPM");

            //    entity.Property(e => e.Sno).HasColumnName("SNo");
            //});

            //modelBuilder.Entity<WashingRecipeSetupTemperatureRange>(entity =>
            //{
            //    entity.ToTable("Washing_RecipeSetup_TemperatureRange");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.RecipeProcessId).HasColumnName("RecipeProcessID");

            //    entity.Property(e => e.Sno).HasColumnName("SNo");
            //});

            //modelBuilder.Entity<WashingRecipeStage>(entity =>
            //{
            //    entity.ToTable("Washing_RecipeStage");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Name).IsUnicode(false);
            //});

            //modelBuilder.Entity<WashingRecipeStageProcessAssociation>(entity =>
            //{
            //    entity.ToTable("Washing_RecipeStageProcess_Association");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ChildProcessId).HasColumnName("ChildProcessID");

            //    entity.Property(e => e.ParentProcessId).HasColumnName("ParentProcessID");

            //    entity.Property(e => e.Rdate)
            //        .HasColumnName("RDate")
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.RecipeStageId).HasColumnName("RecipeStageID");
            //});

            //modelBuilder.Entity<WashingRecipeToStyleAssociation>(entity =>
            //{
            //    entity.ToTable("Washing_RecipeToStyleAssociation");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Date)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.RecipeMasterId).HasColumnName("RecipeMasterID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<WashingRecipeTypeToProcessAssociationDetail>(entity =>
            //{
            //    entity.ToTable("Washing_RecipeTypeToProcessAssociation_Detail");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.IsWetProcess).HasDefaultValueSql("((1))");

            //    entity.Property(e => e.MasterId).HasColumnName("MasterID");

            //    entity.Property(e => e.ProcessCodeId).HasColumnName("ProcessCodeID");

            //    entity.Property(e => e.RecipeSubTypeId).HasColumnName("RecipeSubTypeID");

            //    entity.Property(e => e.RecipeTypeId).HasColumnName("RecipeTypeID");
            //});

            //modelBuilder.Entity<WashingRecipeTypeToProcessAssociationMaster>(entity =>
            //{
            //    entity.ToTable("Washing_RecipeTypeToProcessAssociation_Master");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Date)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.UserId)
            //        .HasColumnName("UserID")
            //        .HasDefaultValueSql("((420))");
            //});

            //modelBuilder.Entity<WashingSampleRecipeSetupDetail>(entity =>
            //{
            //    entity.HasKey(e => e.RecipeProcessId)
            //        .HasName("PK_Washing_SampleRecipeSetup_Process");

            //    entity.ToTable("Washing_SampleRecipeSetup_Detail");

            //    entity.Property(e => e.RecipeProcessId).HasColumnName("RecipeProcessID");

            //    entity.Property(e => e.ChildProcessId).HasColumnName("ChildProcessID");

            //    entity.Property(e => e.IsWetProcess)
            //        .IsRequired()
            //        .HasDefaultValueSql("((1))");

            //    entity.Property(e => e.ItemId).HasColumnName("ItemID");

            //    entity.Property(e => e.MachineRpm).HasColumnName("MachineRPM");

            //    entity.Property(e => e.MaterialCategoryId).HasColumnName("MaterialCategoryID");

            //    entity.Property(e => e.MaterialTypeId).HasColumnName("MaterialTypeID");

            //    entity.Property(e => e.ParentProcessId).HasColumnName("ParentProcessID");

            //    entity.Property(e => e.PerUnitId).HasColumnName("PerUnitID");

            //    entity.Property(e => e.Ph).HasColumnName("PH");

            //    entity.Property(e => e.ProcessTempUnitId).HasColumnName("ProcessTempUnitID");

            //    entity.Property(e => e.ProcessTemperatureFrom).HasColumnType("numeric(6, 2)");

            //    entity.Property(e => e.ProcessTemperatureTo).HasColumnType("numeric(6, 2)");

            //    entity.Property(e => e.ProcessTimeUnitId).HasColumnName("ProcessTimeUnitID");

            //    entity.Property(e => e.RecipeMasterId).HasColumnName("RecipeMasterID");

            //    entity.Property(e => e.Temperature).HasColumnType("numeric(6, 2)");

            //    entity.Property(e => e.Time).HasColumnType("numeric(6, 2)");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");
            //});

            //modelBuilder.Entity<WashingSampleRecipeSetupMaster>(entity =>
            //{
            //    entity.HasKey(e => e.RecipeMasterId);

            //    entity.ToTable("Washing_SampleRecipeSetup_Master");

            //    entity.Property(e => e.RecipeMasterId).HasColumnName("RecipeMasterID");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.FabricCategoryId).HasColumnName("FabricCategoryID");

            //    entity.Property(e => e.ModelId).HasColumnName("ModelID");

            //    entity.Property(e => e.RecipeName).IsRequired();

            //    entity.Property(e => e.RecipeSubTypeId).HasColumnName("RecipeSubTypeID");

            //    entity.Property(e => e.RecipeTypeId).HasColumnName("RecipeTypeID");
            //});

            //modelBuilder.Entity<WashingSampleRecipeSetupRpmrange>(entity =>
            //{
            //    entity.ToTable("Washing_SampleRecipeSetup_RPMRange");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ProcessId).HasColumnName("ProcessID");

            //    entity.Property(e => e.RecipeMasterId).HasColumnName("RecipeMasterID");

            //    entity.Property(e => e.Rpm).HasColumnName("RPM");

            //    entity.Property(e => e.Sno).HasColumnName("SNo");

            //    entity.Property(e => e.TimeFrom).HasColumnType("numeric(6, 2)");

            //    entity.Property(e => e.TimeTo).HasColumnType("numeric(6, 2)");
            //});

            //modelBuilder.Entity<WashingSampleRecipeSetupTemperatureRange>(entity =>
            //{
            //    entity.ToTable("Washing_SampleRecipeSetup_TemperatureRange");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ProcessId).HasColumnName("ProcessID");

            //    entity.Property(e => e.RecipeMasterId).HasColumnName("RecipeMasterID");

            //    entity.Property(e => e.Sno).HasColumnName("SNo");

            //    entity.Property(e => e.Temperature).HasColumnType("numeric(6, 2)");

            //    entity.Property(e => e.TimeFrom).HasColumnType("numeric(6, 2)");

            //    entity.Property(e => e.TimeTo).HasColumnType("numeric(6, 2)");
            //});

            //modelBuilder.Entity<WashingTemp123>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("washing_temp123");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.FabricCategoryId).HasColumnName("FabricCategoryID");

            //    entity.Property(e => e.FabricSpecificationColorId).HasColumnName("FabricSpecificationColorID");

            //    entity.Property(e => e.ModelId).HasColumnName("ModelID");

            //    entity.Property(e => e.PantoneNo).IsUnicode(false);

            //    entity.Property(e => e.ParentRecipeId).HasColumnName("ParentRecipeID");

            //    entity.Property(e => e.RecipeMasterId)
            //        .HasColumnName("RecipeMasterID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.RecipeName).IsRequired();

            //    entity.Property(e => e.RecipeStageId).HasColumnName("RecipeStageID");

            //    entity.Property(e => e.RecipeSubTypeId).HasColumnName("RecipeSubTypeID");

            //    entity.Property(e => e.RecipeTypeId).HasColumnName("RecipeTypeID");
            //});

            //modelBuilder.Entity<WashingTemp123Temp>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("washing_temp123_temp");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.FabricCategoryId).HasColumnName("FabricCategoryID");

            //    entity.Property(e => e.FabricSpecificationColorId).HasColumnName("FabricSpecificationColorID");

            //    entity.Property(e => e.ModelId).HasColumnName("ModelID");

            //    entity.Property(e => e.PantoneNo).IsUnicode(false);

            //    entity.Property(e => e.ParentRecipeId).HasColumnName("ParentRecipeID");

            //    entity.Property(e => e.RecipeMasterId)
            //        .HasColumnName("RecipeMasterID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.RecipeName).IsRequired();

            //    entity.Property(e => e.RecipeStageId).HasColumnName("RecipeStageID");

            //    entity.Property(e => e.RecipeSubTypeId).HasColumnName("RecipeSubTypeID");

            //    entity.Property(e => e.RecipeTypeId).HasColumnName("RecipeTypeID");
            //});

            //modelBuilder.Entity<WashingTimeAndTempUnit>(entity =>
            //{
            //    entity.ToTable("Washing_TimeAndTempUnit");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.UnitName)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.UnitShortName).HasMaxLength(50);
            //});

            //modelBuilder.Entity<WashingUnitGroupDetail>(entity =>
            //{
            //    entity.ToTable("Washing_UnitGroup_Detail");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.UnitGroupMasterId).HasColumnName("UnitGroupMasterID");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");
            //});

            //modelBuilder.Entity<WashingUnitGroupMaster>(entity =>
            //{
            //    entity.ToTable("Washing_UnitGroup_Master");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.UnitTypeDescription)
            //        .IsRequired()
            //        .HasMaxLength(50);
            //});

            //modelBuilder.Entity<Wcimplementation>(entity =>
            //{
            //    entity.ToTable("WCImplementation");

            //    entity.Property(e => e.WcimplementationId).HasColumnName("WCImplementationID");
            //});

            //modelBuilder.Entity<WfsChallanIssuance>(entity =>
            //{
            //    entity.HasKey(e => e.IssuanceChallanId);

            //    entity.ToTable("WFS_ChallanIssuance");

            //    entity.Property(e => e.IssuanceChallanId).HasColumnName("IssuanceChallanID");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.IssuanceChallanDate).HasColumnType("datetime");

            //    entity.Property(e => e.ReceivingChallanId).HasColumnName("ReceivingChallanID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<WfsChallanIssuanceDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("WFS_ChallanIssuanceDetail");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.IssuanceChallanId).HasColumnName("IssuanceChallanID");

            //    entity.Property(e => e.IssuanceDetailId)
            //        .HasColumnName("IssuanceDetailID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.HasOne(d => d.IssuanceChallan)
            //        .WithMany(p => p.WfsChallanIssuanceDetail)
            //        .HasForeignKey(d => d.IssuanceChallanId)
            //        .HasConstraintName("FK_WFS_ChallanIssuanceDetail_WFS_ChallanIssuance");
            //});

            //modelBuilder.Entity<WfsConfirmationMaster>(entity =>
            //{
            //    entity.HasKey(e => e.ConfirmationId);

            //    entity.ToTable("WFS_ConfirmationMaster");

            //    entity.Property(e => e.ConfirmationId).HasColumnName("ConfirmationID");

            //    entity.Property(e => e.Comments)
            //        .IsRequired()
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ConfirmationDate).HasColumnType("datetime");

            //    entity.Property(e => e.JobId).HasColumnName("JobID");
            //});

            //modelBuilder.Entity<WfsDocumentTypeSetup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("WFS_DocumentType_Setup");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");
            //});

            //modelBuilder.Entity<WfsInspectionMaster>(entity =>
            //{
            //    entity.HasKey(e => e.InspectionId);

            //    entity.ToTable("WFS_InspectionMaster");

            //    entity.Property(e => e.InspectionId).HasColumnName("InspectionID");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.InspectionDate).HasColumnType("datetime");

            //    entity.Property(e => e.JobId).HasColumnName("JobID");
            //});

            //modelBuilder.Entity<WfsIssuanceMaster>(entity =>
            //{
            //    entity.HasKey(e => e.IssuanceId);

            //    entity.ToTable("WFS_IssuanceMaster");

            //    entity.Property(e => e.IssuanceId).HasColumnName("IssuanceID");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.IssuanceDate).HasColumnType("datetime");

            //    entity.Property(e => e.JobId).HasColumnName("JobID");
            //});

            //modelBuilder.Entity<WfsJobChallan>(entity =>
            //{
            //    entity.HasKey(e => e.JobChallanId);

            //    entity.ToTable("WFS_JobChallan");

            //    entity.Property(e => e.JobChallanId).HasColumnName("JobChallanID");

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.ReceivingMasterId).HasColumnName("ReceivingMasterID");

            //    entity.HasOne(d => d.Job)
            //        .WithMany(p => p.WfsJobChallan)
            //        .HasForeignKey(d => d.JobId)
            //        .HasConstraintName("FK_WFS_JobChallan_WFS_JobMaster");
            //});

            //modelBuilder.Entity<WfsJobDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("WFS_JobDetail");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.JobChallanId).HasColumnName("JobChallanID");

            //    entity.Property(e => e.JobDetailId)
            //        .HasColumnName("JobDetailID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.HasOne(d => d.JobChallan)
            //        .WithMany(p => p.WfsJobDetail)
            //        .HasForeignKey(d => d.JobChallanId)
            //        .HasConstraintName("FK_WFS_JobDetail_WFS_JobChallan");
            //});

            //modelBuilder.Entity<WfsJobMaster>(entity =>
            //{
            //    entity.HasKey(e => e.JobId);

            //    entity.ToTable("WFS_JobMaster");

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.ColorCode)
            //        .IsRequired()
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.EndDayId).HasColumnName("EndDayID");

            //    entity.Property(e => e.EndTimeId).HasColumnName("EndTimeID");

            //    entity.Property(e => e.JobStatusId).HasColumnName("JobStatusID");

            //    entity.Property(e => e.ProcessMasterId).HasColumnName("ProcessMasterID");

            //    entity.Property(e => e.StartDayId).HasColumnName("StartDayID");

            //    entity.Property(e => e.StartTimeId).HasColumnName("StartTimeID");

            //    entity.HasOne(d => d.ProcessMaster)
            //        .WithMany(p => p.WfsJobMaster)
            //        .HasForeignKey(d => d.ProcessMasterId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_WFS_JobMaster_WFS_ProcessMaster");
            //});

            //modelBuilder.Entity<WfsJobStatus>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("WFS_JobStatus");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.StatusName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<WfsLoad>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("WFS_Load");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.MachineId).HasColumnName("MachineID");

            //    entity.Property(e => e.ManualOperationId).HasColumnName("ManualOperationID");

            //    entity.Property(e => e.MinuteId).HasColumnName("MinuteID");

            //    entity.Property(e => e.Status).HasDefaultValueSql("(3)");

            //    entity.Property(e => e.WcdayId).HasColumnName("WCDayID");
            //});

            //modelBuilder.Entity<WfsLotConfirmationAssociation>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("WFS_LotConfirmationAssociation");

            //    entity.Property(e => e.ConformationId).HasColumnName("ConformationID");

            //    entity.Property(e => e.LotId).HasColumnName("LotID");
            //});

            //modelBuilder.Entity<WfsLotConfirmationMaster>(entity =>
            //{
            //    entity.ToTable("WFS_LotConfirmationMaster");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Comments).HasMaxLength(50);

            //    entity.Property(e => e.ConfirmationNo).HasMaxLength(50);

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.ProcessId).HasColumnName("ProcessID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<WfsLotMakingMaster>(entity =>
            //{
            //    entity.ToTable("WFS_LotMakingMaster");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Comments).HasMaxLength(50);

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.LotNo).HasMaxLength(50);

            //    entity.Property(e => e.ProcessId).HasColumnName("ProcessID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<WfsMachinesSetup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("WFS_MachinesSetup");

            //    entity.Property(e => e.FamMachineTypeId).HasColumnName("FAM_MachineTypeID");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.MachineId).HasColumnName("MachineID");

            //    entity.Property(e => e.Name)
            //        .HasMaxLength(25)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<WfsManualOperations>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("WFS_ManualOperations");

            //    entity.Property(e => e.GeManualOperationId).HasColumnName("GE_ManualOperationID");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.OperationName)
            //        .IsRequired()
            //        .HasMaxLength(25)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<WfsMinuteTime>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("WFS_MinuteTime");

            //    entity.Property(e => e.DayMinute).HasColumnType("datetime");

            //    entity.Property(e => e.MinuteId).HasColumnName("MinuteID");

            //    entity.Property(e => e.MinuteTypeId).HasColumnName("MinuteTypeID");
            //});

            //modelBuilder.Entity<WfsProcessDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("WFS_ProcessDetail");

            //    entity.Property(e => e.ProcessDetailId)
            //        .HasColumnName("ProcessDetailID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.ProcessMasterId).HasColumnName("ProcessMasterID");

            //    entity.HasOne(d => d.ProcessMaster)
            //        .WithMany(p => p.WfsProcessDetail)
            //        .HasForeignKey(d => d.ProcessMasterId)
            //        .HasConstraintName("FK_WFS_ProcessDetail_WFS_ProcessMaster");
            //});

            //modelBuilder.Entity<WfsProcessMaster>(entity =>
            //{
            //    entity.HasKey(e => e.ProcessMasterId);

            //    entity.ToTable("WFS_ProcessMaster");

            //    entity.Property(e => e.ProcessMasterId).HasColumnName("ProcessMasterID");

            //    entity.Property(e => e.MachineTypeId).HasColumnName("MachineTypeID");

            //    entity.Property(e => e.ProcessId).HasColumnName("ProcessID");

            //    entity.Property(e => e.ProcessName)
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ReceivingMasterId).HasColumnName("ReceivingMasterID");
            //});

            //modelBuilder.Entity<WfsReceivingChallanDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("WFS_ReceivingChallanDetail");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.ReceivingDetailId)
            //        .HasColumnName("ReceivingDetailID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.ReceivingMasterId).HasColumnName("ReceivingMasterID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.HasOne(d => d.ReceivingMaster)
            //        .WithMany(p => p.WfsReceivingChallanDetail)
            //        .HasForeignKey(d => d.ReceivingMasterId)
            //        .HasConstraintName("FK_WFS_ReceivingChallanDetail_WFS_ReceivingChallanMaster");
            //});

            //modelBuilder.Entity<WfsReceivingChallanMaster>(entity =>
            //{
            //    entity.HasKey(e => e.ReceivingMasterId);

            //    entity.ToTable("WFS_ReceivingChallanMaster");

            //    entity.Property(e => e.ReceivingMasterId).HasColumnName("ReceivingMasterID");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.IssuanceMasterId).HasColumnName("IssuanceMasterID");

            //    entity.Property(e => e.ReceivingDate).HasColumnType("datetime");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<WfsRejectionMaster>(entity =>
            //{
            //    entity.HasKey(e => e.RejectionId);

            //    entity.ToTable("WFS_RejectionMaster");

            //    entity.Property(e => e.RejectionId).HasColumnName("RejectionID");

            //    entity.Property(e => e.JobId).HasColumnName("JobID");

            //    entity.Property(e => e.RejectionDate).HasColumnType("datetime");
            //});

            //modelBuilder.Entity<WfsStockTransaction>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("WFS_StockTransaction");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.GarmentWeightPw).HasColumnName("GarmentWeightPW");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.ProcessId).HasColumnName("ProcessID");

            //    entity.Property(e => e.ReceivingChallanId).HasColumnName("ReceivingChallanID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.StockId)
            //        .HasColumnName("StockID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<WoDfsRollInspectionAttribute>(entity =>
            //{
            //    entity.ToTable("WO_DFS_Roll_InspectionAttribute");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.DcgattributeInstanceId).HasColumnName("DCGAttributeInstanceID");

            //    entity.Property(e => e.DcrollAttributeId).HasColumnName("DCRollAttributeID");

            //    entity.Property(e => e.InspectionId).HasColumnName("InspectionID");

            //    entity.Property(e => e.MachineId).HasColumnName("MachineID");

            //    entity.Property(e => e.Quantity)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.RollId).HasColumnName("RollID");

            //    entity.Property(e => e.RollNo)
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Ykncid).HasColumnName("YKNCID");
            //});

            //modelBuilder.Entity<WoRollDefectDetail>(entity =>
            //{
            //    entity.HasKey(e => e.RollDefectDetailId);

            //    entity.ToTable("WO_Roll_Defect_Detail");

            //    entity.Property(e => e.RollDefectDetailId).HasColumnName("Roll_Defect_Detail_ID");

            //    entity.Property(e => e.DefectDirection)
            //        .HasColumnName("Defect_Direction")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DefectStartFrom).HasColumnName("Defect_Start_from");

            //    entity.Property(e => e.DfsRollInspectionAttributeId).HasColumnName("DFS_Roll_InspectionAttribute_ID");

            //    entity.Property(e => e.ProcessId).HasColumnName("Process_ID");
            //});

            //modelBuilder.Entity<WorkCenterMrpitemCode>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("WorkCenter_MRPItemCode");

            //    entity.HasIndex(e => new { e.WorkCenterId, e.MrpitemCode })
            //        .HasName("IX_WorkCenter_MRPItemCode_C");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.WorkCenterId).HasColumnName("WorkCenterID");
            //});

            //modelBuilder.Entity<WorkCenterSetup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("WorkCenter_Setup");

            //    entity.Property(e => e.CostCenterId).HasColumnName("CostCenterID");

            //    entity.Property(e => e.WorkCenter)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.WorkCenterId).HasColumnName("WorkCenterID");
            //});

            OnModelCreatingPartial(modelBuilder);
        }
       
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
