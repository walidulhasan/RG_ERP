using Microsoft.EntityFrameworkCore;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Interfaces.Repositories.MaterialsManagement;
using RG.DBEntities;
using RG.DBEntities.MaterialsManagement;
using RG.DBEntities.MaterialsManagement.Business;
using RG.DBEntities.MaterialsManagement.DBViews;
using RG.DBEntities.MaterialsManagement.GateReceiving;
using RG.DBEntities.MaterialsManagement.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.Persistence.MaterialsManagementDB
{
    public partial class MaterialsManagementDBContext : DbContext,IMaterialsManagementDBContext
    {
        private readonly ICurrentUserService _currentUserService;

        public MaterialsManagementDBContext(DbContextOptions<MaterialsManagementDBContext> options, ICurrentUserService currentUserService)
            : base(options)
        {
            _currentUserService = currentUserService;
        }

        #region Setup
        //
        public virtual DbSet<Yarn_RateSetup> Yarn_RateSetup { get; set; }
        public virtual DbSet<YArn_UnitSetup> YArn_UnitSetup { get; set; }
        public virtual DbSet<Yarn_ProcurementPurpose> Yarn_ProcurementPurpose { get; set; }
        public virtual DbSet<Yarn_ProcurementType> Yarn_ProcurementType { get; set; }
        public virtual DbSet<MM_Reason_Setup> MM_Reason_Setup { get; set; }
        public virtual DbSet<MM_StoreCategoryRelation> MM_StoreCategoryRelation { get; set; }
        public virtual DbSet<DDReasons_Setup> DDReasons_Setup { get; set; }
        public virtual DbSet<Module_Setup> Module_Setup { get; set; }
        public virtual DbSet<SubModule_Setup> SubModule_Setup { get; set; }
        public virtual DbSet<MM_DocumentType_Setup> MM_DocumentType_Setup { get; set; }
        public virtual DbSet<DD_POStatus_Setup> DD_POStatus_Setup { get; set; }
        public virtual DbSet<DDDeliveryPoint_Setup> DDDeliveryPoint_Setup { get; set; }
        public virtual DbSet<mm_PaymentMode> mm_PaymentMode { get; set; }
        public virtual DbSet<mm_PaymentTerm> mm_PaymentTerm { get; set; }
        public virtual DbSet<DDSigningAuthority_Setup> DDSigningAuthority_Setup { get; set; }
        public virtual DbSet<MM_MRPGrossUnit> MM_MRPGrossUnit { get; set; }
        public virtual DbSet<MM_MRPItem> MM_MRPItem { get; set; }
        public virtual DbSet<MM_MRPItemAttributeInstance> MM_MRPItemAttributeInstance { get; set; }
        public virtual DbSet<MM_MRPItemAttributeSet> MM_MRPItemAttributeSet { get; set; }
        public virtual DbSet<MM_MRPItemAttributeSetValues> MM_MRPItemAttributeSetValues { get; set; }
        public virtual DbSet<MM_MRPItemMasterAttribute> MM_MRPItemMasterAttribute { get; set; }
        public virtual DbSet<MM_MRPUnits> MM_MRPUnits { get; set; }
        public virtual DbSet<MM_MRPItemUnits> MM_MRPItemUnits { get; set; }
        public virtual DbSet<MM_UnitConversion_Setup> MM_UnitConversion_Setup { get; set; }
        public virtual DbSet<Yarn_DaysOfPayment_Setup> Yarn_DaysOfPayment_Setup { get; set; }
        public virtual DbSet<Yarn_TermsOfPayment_Setup> Yarn_TermsOfPayment_Setup { get; set; }
        public virtual DbSet<QRM_MM_UnitMapping> QRM_MM_UnitMapping { get; set; }

        public virtual DbSet<MM_Store_Setup> MM_Store_Setup { get; set; }
        public virtual DbSet<MM_StoreLocations_Setup> MM_StoreLocations_Setup { get; set; }
        public virtual DbSet<Yarn_ProgramType_Setup> Yarn_ProgramType_Setup { get; set; }
        public virtual DbSet<CMBL_SubProgramMaster> CMBL_SubProgramMaster { get; set; }
        public virtual DbSet<CMBL_SubProgramDetail> CMBL_SubProgramDetail { get; set; }
        public virtual DbSet<CMBL_SubProgramProcess> CMBL_SubProgramProcess { get; set; }
        public virtual DbSet<CMBL_UserDepartment> CMBL_UserDepartment { get; set; }
        public virtual DbSet<CMBL_Unit> CMBL_Unit { get; set; }
        public virtual DbSet<CMBL_UserStore> CMBL_UserStore { get; set; }
        public virtual DbSet<CMBL_Item> CMBL_Item { get; set; }
        public virtual DbSet<CMBL_ItemAttribute> CMBL_ItemAttribute { get; set; }
        public virtual DbSet<CMBL_ItemAttributeSet> CMBL_ItemAttributeSet { get; set; }
        public virtual DbSet<CMBL_ItemUnit> CMBL_ItemUnit { get; set; }
        public virtual DbSet<CMBL_StoreBroadGroup> CMBL_StoreBroadGroup { get; set; }
        public virtual DbSet<CMBL_RequisitionStatus> CMBL_RequisitionStatus { get; set; }
        public virtual DbSet<MM_StoreLocationTypes_Setup> MM_StoreLocationTypes_Setup { get; set; }
        public virtual DbSet<Yarn_KnittingWastage_Setup> Yarn_KnittingWastage_Setup { get; set; }
        public virtual DbSet<IC_Department> IC_Department { get; set; }
        public virtual DbSet<IC_SampleCustomerType> IC_SampleCustomerType { get; set; }
        public virtual DbSet<IC_SampleType_Setup> IC_SampleType_Setup { get; set; }
        public virtual DbSet<IC_SampleTypeProcess_Setup> IC_SampleTypeProcess_Setup { get; set; }
        public virtual DbSet<IC_UserDepartmentSetup> IC_UserDepartmentSetup { get; set; }
        public virtual DbSet<IC_UnitSetup> IC_UnitSetup { get; set; }
        public virtual DbSet<IC_ReturnableItemCategory> IC_ReturnableItemCategory { get; set; }
        public virtual DbSet<IC_ProcessSetup> IC_ProcessSetup { get; set; }
        public virtual DbSet<IC_GatePassAccountReview> IC_GatePassAccountReview { get; set; }
        public virtual DbSet<DailyProductionHour> DailyProductionHours { get; set; }
        public virtual DbSet<YarnRackSetup> YarnRackSetup { get; set; }
        public virtual DbSet<YarnSubRackSetup> YarnSubRackSetup { get; set; }
        public virtual DbSet<BuildingFloorInfo> BuildingFloorInfo { get; set; }
        public virtual DbSet<BuildingInfo> BuildingInfo { get; set; }
        public virtual DbSet<BuildingType> BuildingType { get; set; }
        public virtual DbSet<FloorType> FloorType { get; set; }
        public virtual DbSet<CMBL_POQuotationFileUpload> CMBL_POQuotationFileUpload { get; set; }

        //
        #endregion

        #region Business
        //
        public virtual DbSet<Yarn_PODeliverySchedule> Yarn_PODeliverySchedule { get; set; }
        public virtual DbSet<Yarn_PODetailRequisition> Yarn_PODetailRequisition { get; set; }
        public virtual DbSet<Yarn_GRNGRVAssociation> Yarn_GRNGRVAssociation { get; set; }
        public virtual DbSet<MM_CostCenterAssciationStyleWise> MM_CostCenterAssciationStyleWise { get; set; }
        public virtual DbSet<ValuationClass> ValuationClass { get; set; }
        public virtual DbSet<MM_FIIntregration> MM_FIIntregration { get; set; }
        public virtual DbSet<MM_PermanentReceivingMaster> MM_PermanentReceivingMaster { get; set; }
        public virtual DbSet<MM_ListAttributeInstanceID> MM_ListAttributeInstanceID { get; set; }
        public virtual DbSet<MM_ModelRequisitionRequirement> MM_ModelRequisitionRequirement { get; set; }
        public virtual DbSet<MM_ModelGrossRequirement> MM_ModelGrossRequirement { get; set; }
        public virtual DbSet<MM_ModelRequisitionMaster> MM_ModelRequisitionMaster { get; set; }
        public virtual DbSet<Yarn_IssuanceToKnitterMaster> Yarn_IssuanceToKnitterMaster { get; set; }
        public virtual DbSet<Yarn_AllocationToKnitter> Yarn_AllocationToKnitter { get; set; }
        public virtual DbSet<TEMP_Yarn_Issue> TEMP_Yarn_Issue { get; set; }
        public virtual DbSet<Yarn_KnitterStockTransactions> Yarn_KnitterStockTransactions { get; set; }
        public virtual DbSet<Yarn_StockTransactions> Yarn_StockTransactions { get; set; }
        public virtual DbSet<Yarn_PermanentReceivingMaster> Yarn_PermanentReceivingMaster { get; set; }
        public virtual DbSet<Greige_StockTransactions> Greige_StockTransactions { get; set; }
        public virtual DbSet<Greige_PermanentReceivingMaster> Greige_PermanentReceivingMaster { get; set; }
        public virtual DbSet<Yarn_KnittingContractFlatBed> Yarn_KnittingContractFlatBed { get; set; }
        public virtual DbSet<Yarn_KnittingContractMaster> Yarn_KnittingContractMaster { get; set; }
        public virtual DbSet<Yarn_KnittingContractTippingSpecification> Yarn_KnittingContractTippingSpecification { get; set; }
        public virtual DbSet<DD_POInstructions> DD_POInstructions { get; set; }
        public virtual DbSet<DD_POItemDetails> DD_POItemDetails { get; set; }
        public virtual DbSet<DD_POItemMaster> DD_POItemMaster { get; set; }
        public virtual DbSet<DD_POStatusChangeHistory> DD_POStatusChangeHistory { get; set; }
        public virtual DbSet<DD_PurchaseOrder> DD_PurchaseOrder { get; set; }
        public virtual DbSet<Yarn_KnittingContractColor> Yarn_KnittingContractColor { get; set; }
        public virtual DbSet<Yarn_KnittingContractDeliverySchedule> Yarn_KnittingContractDeliverySchedule { get; set; }
        public virtual DbSet<Yarn_KnittingContractDetail> Yarn_KnittingContractDetail { get; set; }
        public virtual DbSet<Dyed_TemporaryReceivingMaster> Dyed_TemporaryReceivingMaster { get; set; }
        public virtual DbSet<Dyed_StockTransactions> Dyed_StockTransactions { get; set; }
        public virtual DbSet<Greige_DyeingContractMaster> Greige_DyeingContractMaster { get; set; }
        public virtual DbSet<Greige_DyeingContractDetail> Greige_DyeingContractDetail { get; set; }
        public virtual DbSet<Greige_DyeingContractDeliverySchedule> Greige_DyeingContractDeliverySchedule { get; set; }
        public virtual DbSet<Greige_IssuanceMaster> Greige_IssuanceMaster { get; set; }
        public virtual DbSet<Greige_IssuanceAgainstDyeingContract_Detail> Greige_IssuanceAgainstDyeingContract_Detail { get; set; }
        public virtual DbSet<CMBL_ItemRequisitionMaster> CMBL_ItemRequisitionMaster { get; set; }
        public virtual DbSet<CMBL_ItemRequisitionRequirement> CMBL_ItemRequisitionRequirement { get; set; }
        public virtual DbSet<Yarn_RequisitionMaster> Yarn_RequisitionMaster { get; set; }
        public virtual DbSet<Yarn_RequisitionDetail> Yarn_RequisitionDetail { get; set; }
        public virtual DbSet<CMBL_InterStoreTransfer_Master> CMBL_InterStoreTransfer_Master { get; set; }
        public virtual DbSet<CMBL_StockTransaction> CMBL_StockTransaction { get; set; }
        public virtual DbSet<CMBL_IssuanceWithRequisition> CMBL_IssuanceWithRequisition { get; set; }
        public virtual DbSet<CMBL_COAAssociationType> CMBL_COAAssociationType { get; set; }
        public virtual DbSet<CMBL_AssetToCostCenterAssociation> CMBL_AssetToCostCenterAssociation { get; set; }
        public virtual DbSet<CMBL_FIIntegeration> CMBL_FIIntegeration { get; set; }
        public virtual DbSet<Dyed_InspectionMaster> Dyed_InspectionMaster { get; set; }
        public virtual DbSet<IC_DocumentCategories> IC_DocumentCategories { get; set; }
        public virtual DbSet<IC_GatepassMaster> IC_GatepassMaster { get; set; }
        public virtual DbSet<IC_LocalSalesGatePassMaster> IC_LocalSalesGatePassMaster { get; set; }
        public virtual DbSet<IC_ExportSalesGatePassMaster> IC_ExportSalesGatePassMaster { get; set; }
        public virtual DbSet<IC_ScrapSalesGatePassMaster> IC_ScrapSalesGatePassMaster { get; set; }
        public virtual DbSet<IC_NonReturnableGatePassMaster> IC_NonReturnableGatePassMaster { get; set; }
        public virtual DbSet<IC_ReturnableGatePassMaster> IC_ReturnableGatePassMaster { get; set; }
        public virtual DbSet<IC_SampleGatePassMaster> IC_SampleGatePassMaster { get; set; }
        public virtual DbSet<IC_LocalSalesGatePassDetail> IC_LocalSalesGatePassDetail { get; set; }
        public virtual DbSet<IC_ExportSalesGatePassDetail> IC_ExportSalesGatePassDetail { get; set; }
        public virtual DbSet<IC_ScrapSalesGatePassDetail> IC_ScrapSalesGatePassDetail { get; set; }
        public virtual DbSet<IC_NonReturnableGatePassDetail> IC_NonReturnableGatePassDetail { get; set; }
        public virtual DbSet<IC_ReturnableGatePassDetail> IC_ReturnableGatePassDetail { get; set; }
        public virtual DbSet<IC_SampleGatePassDetail> IC_SampleGatePassDetail { get; set; }
        public virtual DbSet<IC_ReturnableRecieveGatePassDetail> IC_ReturnableRecieveGatePassDetail { get; set; }
        public virtual DbSet<YarnRackAllocation> YarnRackAllocation { get; set; }
        public virtual DbSet<AllocatedYarnIssueFromRack> AllocatedYarnIssueFromRack { get; set; }
        public virtual DbSet<YarnRackIssue> YarnRackIssue { get; set; }
        public virtual DbSet<CMBL_PurchaseOrder> CMBL_PurchaseOrder { get; set; }
        public virtual DbSet<CMBL_PurchaseOrderItem> CMBL_PurchaseOrderItem { get; set; }
        public virtual DbSet<CMBL_StatusPO> CMBL_StatusPO { get; set; }

        //
        #endregion Business

        #region GateReceving
        public virtual DbSet<MM_GateReceiving> MM_GateReceiving { get; set; }
        public virtual DbSet<MM_GateReceivingDetail> MM_GateReceivingDetail { get; set; }
        public virtual DbSet<MM_TempReceivingMaster> MM_TempReceivingMaster { get; set; }
        public virtual DbSet<MM_StockTransactions> MM_StockTransactions { get; set; }
        public virtual DbSet<MM_MaterialInspection_Master> MM_MaterialInspection_Master { get; set; }
        public virtual DbSet<Yarn_GateReceivingMaster> Yarn_GateReceivingMaster { get; set; }
        public virtual DbSet<Yarn_GateReceivingDetail> Yarn_GateReceivingDetail { get; set; }
        public virtual DbSet<Yarn_POMaster> Yarn_POMaster { get; set; }
        public virtual DbSet<Yarn_WOMaster> Yarn_WOMaster { get; set; }
        public virtual DbSet<Yarn_TemporaryReceivingMaster> Yarn_TemporaryReceivingMaster { get; set; }
        public virtual DbSet<Yarn_SupplierInitial> Yarn_SupplierInitial { get; set; }
        public virtual DbSet<yarn_PODetail> yarn_PODetail { get; set; }
        public virtual DbSet<Yarn_InspectionMaster> Yarn_InspectionMaster { get; set; }
        public virtual DbSet<Yarn_WeighingInspectionMaster> Yarn_WeighingInspectionMaster { get; set; }
        //
        #endregion
        #region Purchase Requisition
        public DbSet<vw_RequisitionToPurchaseOrderCreate> vw_RequisitionToPurchaseOrderCreate { get; set; }
        public DbSet<viw_CurrentMovingAverageForAttributeInstance> viw_CurrentMovingAverageForAttributeInstance { get; set; }

        #endregion

        #region Partial Requisition Issue
        public virtual DbSet<MM_PartialRequisition_Master> MM_PartialRequisition_Master { get; set; }
        public virtual DbSet<MM_PartialRequisition_Detail> MM_PartialRequisition_Detail { get; set; }
        public virtual DbSet<MM_MaterialIssuanceMaster> MM_MaterialIssuanceMaster { get; set; }
        #endregion Partial Requisition Issue

        #region Inter Order Transfer IOT
        public virtual DbSet<CMBL_InterOrderTransfer> CMBL_InterOrderTransfer { get; set; }
        public virtual DbSet<MM_InterOrderTransferMaster> MM_InterOrderTransferMaster { get; set; }
        #endregion
        #region DB Views
        public DbSet<vw_GetAllGatePass> vw_GetAllGatePass { get; set; }
        public DbSet<Viw_Supplier> Viw_Supplier { get; set; }
        public DbSet<View_AttributeInstanceYarnInfo> View_AttributeInstanceYarnInfo { get; set; }
        public DbSet<vw_KRSOrder> vw_KRSOrder { get; set; }
        public DbSet<Vw_User_Setup> Vw_User_Setup { get; set; }
        public DbSet<Vw_SupplierSetup> Vw_SupplierSetup { get; set; }
        public DbSet<vw_CMBL_ItemALLAttribute> vw_CMBL_ItemALLAttribute { get; set; }
        public DbSet<Vw_Currency> Vw_Currency { get; set; }
        public DbSet<Vw_CompanyInfo> Vw_CompanyInfo { get; set; }
        public DbSet<Vw_BuyerOrder> Vw_BuyerOrder { get; set; }

        #endregion DB Views

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //            if (!optionsBuilder.IsConfigured)
            //            {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //                optionsBuilder.UseSqlServer("Server=192.173.163.190;Database=Dev_MaterialsManagement;Trusted_Connection=false;user id=sa;password=ERP@2019");
            //            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);



            #region Table IC_Local Sales Gate Pass Master

            modelBuilder.Entity<IC_LocalSalesGatePassMaster>()
                .HasKey(b => b.GatePassID);


            modelBuilder.Entity<IC_GatepassMaster>()
              .HasOne(a => a.IC_LocalSalesGatePassMaster)
              .WithOne(b => b.IC_GatepassMaster)
              .HasForeignKey<IC_LocalSalesGatePassMaster>(e => e.GatePassID);

            #endregion IC_LocalSalesGatePassMaster

            #region Export Sales
            modelBuilder.Entity<IC_ExportSalesGatePassMaster>()
                .HasKey(b => b.GatePassId);

            modelBuilder.Entity<IC_GatepassMaster>()
                   .HasOne(a => a.IC_ExportSalesGatePassMaster)
                   .WithOne(b => b.IC_GatepassMaster)
                   .HasForeignKey<IC_ExportSalesGatePassMaster>(e => e.GatePassId);

            #endregion

            #region Table Scrap Sales GatePassMaster

            modelBuilder.Entity<IC_ScrapSalesGatePassMaster>()
                .HasKey(b => b.GatePassID);


            modelBuilder.Entity<IC_GatepassMaster>()
              .HasOne(a => a.IC_ScrapSalesGatePassMaster)
              .WithOne(b => b.IC_GatepassMaster)
              .HasForeignKey<IC_ScrapSalesGatePassMaster>(e => e.GatePassID);

            #endregion Table Scrap Sales GatePassMaster

            #region Table NonReturnable GatePassMaster
            modelBuilder.Entity<IC_NonReturnableGatePassMaster>()
                .HasKey(b => b.GatePassID);

            modelBuilder.Entity<IC_GatepassMaster>()
                .HasOne(a => a.IC_NonReturnableGatePassMaster)
                .WithOne(b => b.IC_GatepassMaster)
                .HasForeignKey<IC_NonReturnableGatePassMaster>(e => e.GatePassID);
            #endregion Table NonReturnable GatePassMaster

            #region Table Returnable GatePassMaster
            modelBuilder.Entity<IC_ReturnableGatePassMaster>()
                .HasKey(b => b.GatePassID);

            modelBuilder.Entity<IC_GatepassMaster>()
                .HasOne(a => a.IC_ReturnableGatePassMaster)
                .WithOne(b => b.IC_GatepassMaster)
                .HasForeignKey<IC_ReturnableGatePassMaster>(e => e.GatePassID);
            #endregion Table Returnable GatePassMaster

            #region Table  Sample Gate PassMaster
            modelBuilder.Entity<IC_SampleGatePassMaster>()
                .HasKey(b => b.GatePassID);

            modelBuilder.Entity<IC_GatepassMaster>()
                .HasOne(a => a.IC_SampleGatePassMaster)
                .WithOne(b => b.IC_GatepassMaster)
                .HasForeignKey<IC_SampleGatePassMaster>(e => e.GatePassID);
            #endregion Table Sample Gate PassMaster




            #region Business
            modelBuilder.Entity<DD_POInstructions>(entity =>
            {
                entity.ToTable("DD_POInstructions", "dbo");
            });
            modelBuilder.Entity<DD_POItemDetails>(entity =>
            {
                entity.ToTable("DD_POItemDetails", "dbo");
            });
            modelBuilder.Entity<DD_POItemMaster>(entity =>
            {
                entity.ToTable("DD_POItemMaster", "dbo");
            });
            modelBuilder.Entity<DD_POStatusChangeHistory>(entity =>
            {
                entity.ToTable("DD_POStatusChangeHistory", "dbo");
            });
            modelBuilder.Entity<DD_PurchaseOrder>(entity =>
            {
                entity.ToTable("DD_PurchaseOrder", "dbo");
            });
            #endregion Business
            #region Setup
            modelBuilder.Entity<DD_POStatus_Setup>(entity =>
            {
                entity.ToTable("DD_POStatus_Setup", "dbo");
            });
            #endregion Setup

            #region VIew
            modelBuilder.Entity<vw_GetAllGatePass>()
            .ToTable("vw_GetAllGatePass", "ajt");

            #endregion

            //modelBuilder.Entity<AcGarmentSelectionCriteria>(entity =>
            //{
            //    entity.ToTable("AC_GarmentSelectionCriteria");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Date).HasColumnType("datetime");

            //    entity.Property(e => e.GarmentCriteriaId).HasColumnName("GarmentCriteriaID");

            //    entity.Property(e => e.TrimId)
            //        .HasColumnName("TrimID")
            //        .HasComment("TrimID represents BodyPart");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.Property(e => e.WorkCenterId).HasColumnName("WorkCenterID");

            //    entity.HasOne(d => d.GarmentCriteria)
            //        .WithMany(p => p.AcGarmentSelectionCriteria)
            //        .HasForeignKey(d => d.GarmentCriteriaId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_AC_GarmentSelectionCriteria_AC_GarmentSelectionCriteria_Setup");
            //});

            //modelBuilder.Entity<AcGarmentSelectionCriteriaSetup>(entity =>
            //{
            //    entity.ToTable("AC_GarmentSelectionCriteria_Setup");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<AcWcwiseSumView>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("AC_WCWiseSum_View");

            //    entity.Property(e => e.ConfirmedQty).HasColumnName("Confirmed_Qty");

            //    entity.Property(e => e.DelQty).HasColumnName("Del_Qty");

            //    entity.Property(e => e.InsQty).HasColumnName("Ins_Qty");

            //    entity.Property(e => e.RecQty).HasColumnName("Rec_Qty");

            //    entity.Property(e => e.RejQty).HasColumnName("Rej_Qty");

            //    entity.Property(e => e.WcDescrip)
            //        .HasColumnName("WC_Descrip")
            //        .HasMaxLength(50);

            //    entity.Property(e => e.WcId).HasColumnName("WC_ID");
            //});

            //modelBuilder.Entity<AttributeInstanceId>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("AttributeInstanceID");

            //    entity.Property(e => e.Id).HasColumnName("ID");
            //});

            //modelBuilder.Entity<AttributeInstanceUpdator>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<Bardata>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("bardata");

            //    entity.Property(e => e.Brand)
            //        .HasColumnName("brand")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.Colour).HasMaxLength(255);

            //    entity.Property(e => e.CustomerCode)
            //        .HasColumnName("Customer code")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

            //    entity.Property(e => e.DestinationCode)
            //        .HasColumnName("destination code")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.DestinationId).HasColumnName("DestinationID");

            //    entity.Property(e => e.F13).HasMaxLength(255);

            //    entity.Property(e => e.F14).HasMaxLength(255);

            //    entity.Property(e => e.OrderDate)
            //        .HasColumnName("order date")
            //        .HasColumnType("smalldatetime");

            //    entity.Property(e => e.OrderQuantity).HasColumnName("Order quantity");

            //    entity.Property(e => e.Season).HasMaxLength(255);

            //    entity.Property(e => e.Size).HasMaxLength(255);

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.Status).HasMaxLength(255);

            //    entity.Property(e => e.StyleCode)
            //        .HasColumnName("Style code")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.StyleDescription)
            //        .HasColumnName("Style description")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.StyleId1).HasColumnName("StyleID1");

            //    entity.Property(e => e.Theme)
            //        .HasColumnName("theme")
            //        .HasMaxLength(255);
            //});

            //modelBuilder.Entity<BciAllSizesSetup>(entity =>
            //{
            //    entity.ToTable("BCI_AllSizesSetup");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.FgtypeId).HasColumnName("FGTypeID");

            //    entity.Property(e => e.Size)
            //        .IsRequired()
            //        .HasMaxLength(5)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Sno).HasColumnName("SNo");
            //});

            //modelBuilder.Entity<BciAssortmentCodeSetupDetail>(entity =>
            //{
            //    entity.ToTable("BCI_AssortmentCodeSetup_Detail");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.AssortmentCodeSetupMasterId).HasColumnName("AssortmentCodeSetup_MasterID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.HasOne(d => d.AssortmentCodeSetupMaster)
            //        .WithMany(p => p.BciAssortmentCodeSetupDetail)
            //        .HasForeignKey(d => d.AssortmentCodeSetupMasterId)
            //        .HasConstraintName("FK_BCI_AssortmentCodeSetup_Detail_BCI_AssortmentCodeSetup_Master");
            //});

            //modelBuilder.Entity<BciAssortmentCodeSetupMaster>(entity =>
            //{
            //    entity.ToTable("BCI_AssortmentCodeSetup_Master");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.AssortmentCode)
            //        .IsRequired()
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.FinishedGoodTypeId).HasColumnName("FinishedGoodTypeID");

            //    entity.Property(e => e.TypeId)
            //        .HasColumnName("TypeID")
            //        .HasDefaultValueSql("(1)");

            //    entity.HasOne(d => d.Type)
            //        .WithMany(p => p.BciAssortmentCodeSetupMaster)
            //        .HasForeignKey(d => d.TypeId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_BCI_AssortmentCodeSetup_Master_BCI_AssortmentCodeType");
            //});

            //modelBuilder.Entity<BciAssortmentCodeType>(entity =>
            //{
            //    entity.HasKey(e => e.TypeId);

            //    entity.ToTable("BCI_AssortmentCodeType");

            //    entity.Property(e => e.TypeId).HasColumnName("TypeID");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<BciBarCodeDetail>(entity =>
            //{
            //    entity.ToTable("BCI_BarCodeDetail");

            //    entity.HasIndex(e => e.BciCartonSetupDetailId)
            //        .HasName("IX_BCI_BarCodeDetail_NC");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.BciCartonSetupDetailId).HasColumnName("BCI_CartonSetupDetailID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.Size)
            //        .IsRequired()
            //        .HasMaxLength(5)
            //        .IsUnicode(false);

            //    entity.HasOne(d => d.BciCartonSetupDetail)
            //        .WithMany(p => p.BciBarCodeDetail)
            //        .HasForeignKey(d => d.BciCartonSetupDetailId)
            //        .HasConstraintName("FK_BCI_BarCodeDetail_BCI_CartonSetupDetail");
            //});

            //modelBuilder.Entity<BciCartonInContainer>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("BCI_CartonInContainer");
            //});

            //modelBuilder.Entity<BciCartonReceivingDetail>(entity =>
            //{
            //    entity.ToTable("BCI_CartonReceivingDetail");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.BciCartonReceivingMasterId).HasColumnName("BCI_CartonReceivingMasterID");

            //    entity.Property(e => e.BciCartonSetupMasterId).HasColumnName("BCI_CartonSetupMasterID");

            //    entity.HasOne(d => d.BciCartonReceivingMaster)
            //        .WithMany(p => p.BciCartonReceivingDetail)
            //        .HasForeignKey(d => d.BciCartonReceivingMasterId)
            //        .HasConstraintName("FK_BCI_CartonReceivingDetail_BCI_CartonReceivingMaster");
            //});

            //modelBuilder.Entity<BciCartonReceivingMaster>(entity =>
            //{
            //    entity.ToTable("BCI_CartonReceivingMaster");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Date).HasColumnType("datetime");

            //    entity.Property(e => e.ReceivingNumber)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<BciCartonSetupDetail>(entity =>
            //{
            //    entity.ToTable("BCI_CartonSetupDetail");

            //    entity.HasIndex(e => e.BciCartonSetupMasterId)
            //        .HasName("IX_BCI_CartonSetupDetail_NC");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.BarCode)
            //        .IsRequired()
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.BciCartonSetupMasterId).HasColumnName("BCI_CartonSetupMasterID");

            //    entity.Property(e => e.Bcoccurence).HasColumnName("BCOccurence");

            //    entity.Property(e => e.Color)
            //        .IsRequired()
            //        .HasMaxLength(5)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Model)
            //        .IsRequired()
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.HasOne(d => d.BciCartonSetupMaster)
            //        .WithMany(p => p.BciCartonSetupDetail)
            //        .HasForeignKey(d => d.BciCartonSetupMasterId)
            //        .HasConstraintName("FK_BCI_CartonSetupDetail_BCI_CartonSetupMaster");
            //});

            //modelBuilder.Entity<BciCartonSetupMaster>(entity =>
            //{
            //    entity.ToTable("BCI_CartonSetupMaster");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.BciCartonStatusId)
            //        .HasColumnName("BCI_CartonStatusID")
            //        .HasDefaultValueSql("(1)");

            //    entity.Property(e => e.BciCartonTypeSetupId).HasColumnName("BCI_CartonTypeSetupID");

            //    entity.Property(e => e.BciFgqid).HasColumnName("BCI_FGQID");

            //    entity.Property(e => e.CartonNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ContainerId).HasColumnName("ContainerID");

            //    entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

            //    entity.Property(e => e.Date).HasColumnType("datetime");

            //    entity.Property(e => e.DestinationId).HasColumnName("DestinationID");

            //    entity.Property(e => e.Order)
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OrderDeliveryId).HasColumnName("OrderDeliveryID");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.PickListId).HasColumnName("PickListID");

            //    entity.Property(e => e.SystemBarCode)
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.HasOne(d => d.BciCartonStatus)
            //        .WithMany(p => p.BciCartonSetupMaster)
            //        .HasForeignKey(d => d.BciCartonStatusId)
            //        .HasConstraintName("FK_BCI_CartonSetupMaster_BCI_CartonStatus");

            //    entity.HasOne(d => d.Customer)
            //        .WithMany(p => p.BciCartonSetupMaster)
            //        .HasForeignKey(d => d.CustomerId)
            //        .HasConstraintName("FK_BCI_CartonSetupMaster_BCI_Customer");

            //    entity.HasOne(d => d.Destination)
            //        .WithMany(p => p.BciCartonSetupMaster)
            //        .HasForeignKey(d => d.DestinationId)
            //        .HasConstraintName("FK_BCI_CartonSetupMaster_BCI_Destination");
            //});

            //modelBuilder.Entity<BciCartonStatus>(entity =>
            //{
            //    entity.ToTable("BCI_CartonStatus");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<BciCartonTypeSetup>(entity =>
            //{
            //    entity.ToTable("BCI_CartonTypeSetup");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Height)
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Length).HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.PackagingTypeId).HasColumnName("PackagingTypeID");

            //    entity.Property(e => e.Type)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Weight).HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.Width).HasColumnType("decimal(18, 0)");
            //});

            //modelBuilder.Entity<BciCcorder>(entity =>
            //{
            //    entity.HasKey(e => e.CcorderId);

            //    entity.ToTable("BCI_CCOrder");

            //    entity.Property(e => e.CcorderId).HasColumnName("CCOrderID");

            //    entity.Property(e => e.CorderDate)
            //        .HasColumnName("COrderDate")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

            //    entity.Property(e => e.DestinationId).HasColumnName("DestinationID");

            //    entity.Property(e => e.OrderDeliveryId).HasColumnName("OrderDeliveryID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<BciCcorderDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("BCI_CCOrderDetail");

            //    entity.HasIndex(e => new { e.CcorderId, e.Deleted })
            //        .HasName("IX_CCOrderDetail")
            //        .IsClustered();

            //    entity.HasIndex(e => new { e.StyleId, e.ColorId, e.SizeId })
            //        .HasName("IX_BCI_CCOrderDetail_NC");

            //    entity.Property(e => e.CcorderId).HasColumnName("CCOrderID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.ComboDetailId).HasColumnName("ComboDetailID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.Uid)
            //        .HasColumnName("UID")
            //        .HasColumnType("numeric(18, 0)")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<BciCombo>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("BCI_Combo");

            //    entity.Property(e => e.ComboId).HasColumnName("ComboID");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");
            //});

            //modelBuilder.Entity<BciComboDetails>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("BCI_ComboDetails");

            //    entity.Property(e => e.Color)
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ComboColor)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ComboDetailId).HasColumnName("ComboDetailID");

            //    entity.Property(e => e.ComboId).HasColumnName("ComboID");

            //    entity.Property(e => e.ComboSize)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ComboStyleNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Size)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Style)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<BciCombosCarton>(entity =>
            //{
            //    entity.ToTable("BCI_CombosCarton");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .HasColumnType("numeric(18, 0)")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.CartonId)
            //        .HasColumnName("CartonID")
            //        .HasColumnType("numeric(18, 0)");

            //    entity.Property(e => e.ComboId)
            //        .HasColumnName("ComboID")
            //        .HasColumnType("numeric(18, 0)");
            //});

            //modelBuilder.Entity<BciConsigneeSetup>(entity =>
            //{
            //    entity.ToTable("BCI_ConsigneeSetup");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Address)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Faxnumber)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PartyName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.TelePhoneNumber)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<BciContainerSetup>(entity =>
            //{
            //    entity.HasKey(e => e.ContainerId);

            //    entity.ToTable("BCI_ContainerSetup");

            //    entity.Property(e => e.ContainerId).HasColumnName("ContainerID");

            //    entity.Property(e => e.ContainerNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<BciCustomer>(entity =>
            //{
            //    entity.HasKey(e => e.CustomerId);

            //    entity.ToTable("BCI_Customer");

            //    entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

            //    entity.Property(e => e.CustomerCode)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Deleted).HasDefaultValueSql("(0)");
            //});

            //modelBuilder.Entity<BciCustomerDestination>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("BCI_CustomerDestination");

            //    entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

            //    entity.Property(e => e.Deleted).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.DestinationId).HasColumnName("DestinationID");
            //});

            //modelBuilder.Entity<BciDeletedMasterBarCodes>(entity =>
            //{
            //    entity.HasKey(e => e.MasterId);

            //    entity.ToTable("BCI_DeletedMasterBarCodes");

            //    entity.Property(e => e.MasterId)
            //        .HasColumnName("MasterID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.DeletionDate).HasColumnType("datetime");

            //    entity.Property(e => e.MasterBarCode)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<BciDeletedSingleBarCodes>(entity =>
            //{
            //    entity.ToTable("BCI_DeletedSingleBarCodes");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.MasterId).HasColumnName("MasterID");

            //    entity.Property(e => e.SingleBarCode)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<BciDestination>(entity =>
            //{
            //    entity.HasKey(e => e.DestinationId);

            //    entity.ToTable("BCI_Destination");

            //    entity.Property(e => e.DestinationId).HasColumnName("DestinationID");

            //    entity.Property(e => e.Deleted).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.DestinationCode)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<BciDocumentTypeSetup>(entity =>
            //{
            //    entity.ToTable("BCI_DocumentTypeSetup");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<BciFgsize>(entity =>
            //{
            //    entity.HasKey(e => e.SizeId);

            //    entity.ToTable("BCI_FGSize");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.FgtypeId).HasColumnName("FGTypeID");

            //    entity.Property(e => e.SizeDesc)
            //        .IsRequired()
            //        .HasMaxLength(5)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<BciFgtype>(entity =>
            //{
            //    entity.HasKey(e => e.FgtypeId);

            //    entity.ToTable("BCI_FGType");

            //    entity.Property(e => e.FgtypeId).HasColumnName("FGTypeID");

            //    entity.Property(e => e.FgtypeDesc)
            //        .IsRequired()
            //        .HasColumnName("FGTypeDesc")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<BciFinishGoodQualitySetup>(entity =>
            //{
            //    entity.ToTable("BCI_FinishGoodQuality_Setup");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(5)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<BciItemDescriptionSetup>(entity =>
            //{
            //    entity.ToTable("BCI_ItemDescriptionSetup");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.BciItemSetupId).HasColumnName("BCI_ItemSetupID");

            //    entity.Property(e => e.ItemDescriptionName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.HasOne(d => d.BciItemSetup)
            //        .WithMany(p => p.BciItemDescriptionSetup)
            //        .HasForeignKey(d => d.BciItemSetupId)
            //        .HasConstraintName("FK_BCI_ItemDescriptionSetup_BCI_ItemSetup");
            //});

            //modelBuilder.Entity<BciItemSetup>(entity =>
            //{
            //    entity.ToTable("BCI_ItemSetup");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ItemName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<BciItemUnitSetup>(entity =>
            //{
            //    entity.ToTable("BCI_ItemUnitSetup");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.UnitName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<BciMainCombo>(entity =>
            //{
            //    entity.HasKey(e => e.ComboId);

            //    entity.ToTable("BCI_MainCombo");

            //    entity.Property(e => e.ComboId)
            //        .HasColumnName("ComboID")
            //        .HasColumnType("numeric(18, 0)")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.AssortmentCode)
            //        .IsRequired()
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ColorCode)
            //        .IsRequired()
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StyleCode)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<BciMainComboDetail>(entity =>
            //{
            //    entity.HasKey(e => e.ComboDetailId);

            //    entity.ToTable("BCI_MainComboDetail");

            //    entity.Property(e => e.ComboDetailId)
            //        .HasColumnName("ComboDetailID")
            //        .HasColumnType("numeric(18, 0)")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Color)
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ComboId)
            //        .HasColumnName("ComboID")
            //        .HasColumnType("numeric(18, 0)");

            //    entity.Property(e => e.Size)
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Style)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<BciMarksTypeSetup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("BCI_MarksType_Setup");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<BciMaxcoRubraOrderAssociation>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("BCI_MaxcoRubraOrderAssociation");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Maxco).HasMaxLength(255);

            //    entity.Property(e => e.Rubra).HasMaxLength(255);
            //});

            //modelBuilder.Entity<BciNotifyParty>(entity =>
            //{
            //    entity.ToTable("BCI_NotifyParty");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Address)
            //        .IsRequired()
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.FaxNumber)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PartyName)
            //        .IsRequired()
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.TelePhoneNumber)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<BciOrderDeliverySetup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("BCI_OrderDeliverySetup");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OrderDeliveryId)
            //        .HasColumnName("OrderDeliveryID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<BciPackagingTypeSetup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("BCI_PackagingTypeSetup");

            //    entity.Property(e => e.PackagingType)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PackagingTypeId)
            //        .HasColumnName("PackagingTypeID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<BciPalletteSetup>(entity =>
            //{
            //    entity.HasKey(e => e.PalletteId);

            //    entity.ToTable("BCI_PalletteSetup");

            //    entity.Property(e => e.PalletteId)
            //        .HasColumnName("PalletteID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.PalletteNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<BciPickListDetail>(entity =>
            //{
            //    entity.HasKey(e => e.DetailId);

            //    entity.ToTable("BCI_PickListDetail");

            //    entity.Property(e => e.DetailId).HasColumnName("DetailID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.PickListId).HasColumnName("PickListID");

            //    entity.Property(e => e.SharingDetailId).HasColumnName("SharingDetailID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.HasOne(d => d.PickList)
            //        .WithMany(p => p.BciPickListDetail)
            //        .HasForeignKey(d => d.PickListId)
            //        .HasConstraintName("FK_BCI_PickListDetail_BCI_PickListMain");
            //});

            //modelBuilder.Entity<BciPickListMain>(entity =>
            //{
            //    entity.HasKey(e => e.PickListId);

            //    entity.ToTable("BCI_PickListMain");

            //    entity.Property(e => e.PickListId).HasColumnName("PickListID");

            //    entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

            //    entity.Property(e => e.Deleted)
            //        .IsRequired()
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.DestinationId).HasColumnName("DestinationID");

            //    entity.Property(e => e.OrderDeliveryId).HasColumnName("OrderDeliveryID");

            //    entity.Property(e => e.PickListNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Status).HasDefaultValueSql("(1)");

            //    entity.Property(e => e.TransDate).HasColumnType("datetime");

            //    entity.Property(e => e.UserId)
            //        .HasColumnName("UserID")
            //        .HasDefaultValueSql("(0)");
            //});

            //modelBuilder.Entity<BciPickListStatus>(entity =>
            //{
            //    entity.ToTable("BCI_PickListStatus");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<BciPreShipmentInvoice>(entity =>
            //{
            //    entity.ToTable("BCI_PreShipmentInvoice");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.CreationDate)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.InvoiceNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<BciPreShipmentInvoiceDetail>(entity =>
            //{
            //    entity.ToTable("BCI_PreShipmentInvoiceDetail");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.BuyerId).HasColumnName("BuyerID");

            //    entity.Property(e => e.BuyerName)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.ColorName)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.MasterId).HasColumnName("MasterID");

            //    entity.Property(e => e.ModelId).HasColumnName("ModelID");

            //    entity.Property(e => e.ModelName)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.OrderNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.SizeName)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Status).HasDefaultValueSql("(1)");

            //    entity.HasOne(d => d.Master)
            //        .WithMany(p => p.BciPreShipmentInvoiceDetail)
            //        .HasForeignKey(d => d.MasterId)
            //        .HasConstraintName("FK_BCI_PreShipmentInvoiceDetail_BCI_PreShipmentInvoice");
            //});

            //modelBuilder.Entity<BciQrmEmsColorAssociation>(entity =>
            //{
            //    entity.HasKey(e => e.Emscolor);

            //    entity.ToTable("BCI_QRM_EMS_ColorAssociation");

            //    entity.Property(e => e.Emscolor)
            //        .HasColumnName("EMSColor")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Qrmcolor)
            //        .IsRequired()
            //        .HasColumnName("QRMColor")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<BciQrmEmsStyleAssociation>(entity =>
            //{
            //    entity.HasKey(e => e.Qrmstyle);

            //    entity.ToTable("BCI_QRM_EMS_StyleAssociation");

            //    entity.Property(e => e.Qrmstyle)
            //        .HasColumnName("QRMStyle")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Emsstyle)
            //        .IsRequired()
            //        .HasColumnName("EMSStyle")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<BciReceiving>(entity =>
            //{
            //    entity.HasKey(e => e.ReceivingId);

            //    entity.ToTable("BCI_Receiving");

            //    entity.Property(e => e.ReceivingId).HasColumnName("ReceivingID");

            //    entity.Property(e => e.Deleted).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.ReceivingDate).HasColumnType("datetime");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<BciReceivingDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("BCI_ReceivingDetail");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.Deleted).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.ReceivingId).HasColumnName("ReceivingID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.HasOne(d => d.Receiving)
            //        .WithMany(p => p.BciReceivingDetail)
            //        .HasForeignKey(d => d.ReceivingId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_BCI_ReceivingDetail_BCI_Receiving");
            //});

            //modelBuilder.Entity<BciSharingDetail>(entity =>
            //{
            //    entity.HasKey(e => e.DetailId);

            //    entity.ToTable("BCI_SharingDetail");

            //    entity.Property(e => e.DetailId).HasColumnName("DetailID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

            //    entity.Property(e => e.DestinationId).HasColumnName("DestinationID");

            //    entity.Property(e => e.OrderDeliveryId).HasColumnName("OrderDeliveryID");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.SharingId).HasColumnName("SharingID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.Status).HasDefaultValueSql("(1)");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.HasOne(d => d.Sharing)
            //        .WithMany(p => p.BciSharingDetail)
            //        .HasForeignKey(d => d.SharingId)
            //        .HasConstraintName("FK_BCI_SharingDetail_BCI_SharingMain");
            //});

            //modelBuilder.Entity<BciSharingMain>(entity =>
            //{
            //    entity.HasKey(e => e.SharingId);

            //    entity.ToTable("BCI_SharingMain");

            //    entity.Property(e => e.SharingId).HasColumnName("SharingID");

            //    entity.Property(e => e.Deleted)
            //        .IsRequired()
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.TransactionDate).HasColumnType("datetime");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<BciSharingStatus>(entity =>
            //{
            //    entity.ToTable("BCI_SharingStatus");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<BciShipmentDeclarationDetail>(entity =>
            //{
            //    entity.ToTable("BCI_ShipmentDeclarationDetail");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.BciItemDescriptionSetupId).HasColumnName("BCI_ItemDescriptionSetupID");

            //    entity.Property(e => e.BciItemUnitSetupId).HasColumnName("BCI_ItemUnitSetupID");

            //    entity.Property(e => e.BciShipmentDeclarationMasterId).HasColumnName("BCI_ShipmentDeclarationMasterID");

            //    entity.HasOne(d => d.BciShipmentDeclarationMaster)
            //        .WithMany(p => p.BciShipmentDeclarationDetail)
            //        .HasForeignKey(d => d.BciShipmentDeclarationMasterId)
            //        .HasConstraintName("FK_BCI_ShipmentDeclarationDetail_BCI_ShipmentDeclarationMaster");
            //});

            //modelBuilder.Entity<BciShipmentDeclarationMaster>(entity =>
            //{
            //    entity.ToTable("BCI_ShipmentDeclarationMaster");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.BciItemSetupId).HasColumnName("BCI_ItemSetupID");
            //});

            //modelBuilder.Entity<BciShipmentDeclarationModels>(entity =>
            //{
            //    entity.ToTable("BCI_ShipmentDeclarationModels");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Buyer)
            //        .IsRequired()
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.BuyerId).HasColumnName("BuyerID");

            //    entity.Property(e => e.ConsumedPpc).HasColumnName("ConsumedPPC");

            //    entity.Property(e => e.Model)
            //        .IsRequired()
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ModelId).HasColumnName("ModelID");

            //    entity.Property(e => e.Order)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");
            //});

            //modelBuilder.Entity<BciShipmentMaster>(entity =>
            //{
            //    entity.ToTable("BCI_ShipmentMaster");

            //    entity.HasIndex(e => e.InvoiceNo)
            //        .HasName("IX_BCI_ShipmentMaster")
            //        .IsUnique();

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.AwlBlno)
            //        .HasColumnName("AWL/BLNo")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.BankId).HasColumnName("BankID");

            //    entity.Property(e => e.Buyer)
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.BuyerId).HasColumnName("BuyerID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.ConsigneeId).HasColumnName("ConsigneeID");

            //    entity.Property(e => e.Date).HasColumnType("datetime");

            //    entity.Property(e => e.Destination)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.FormEdate)
            //        .HasColumnName("FormEDate")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.FormEno)
            //        .HasColumnName("FormENo")
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.GrossWeight).HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.InvoiceNo)
            //        .IsRequired()
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.MarksId).HasColumnName("MarksID");

            //    entity.Property(e => e.ModeOfPaymentId).HasColumnName("ModeOfPaymentID");

            //    entity.Property(e => e.NetWeight).HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.NotifyPartyId).HasColumnName("NotifyPartyID");

            //    entity.Property(e => e.Rdate)
            //        .HasColumnName("RDate")
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.ShipmentDate).HasColumnType("datetime");

            //    entity.Property(e => e.ShipmentModeDetailId).HasColumnName("ShipmentModeDetailID");

            //    entity.Property(e => e.ShipmentModeId).HasColumnName("ShipmentModeID");

            //    entity.Property(e => e.ShipmentNo)
            //        .IsRequired()
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ShipperId).HasColumnName("ShipperID");

            //    entity.Property(e => e.SoldToId).HasColumnName("SoldToID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.Property(e => e.VesselVoyageNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<BciShipmentMode>(entity =>
            //{
            //    entity.ToTable("BCI_ShipmentMode");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<BciShipmentModeDetail>(entity =>
            //{
            //    entity.ToTable("BCI_ShipmentModeDetail");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ShipmentModeId).HasColumnName("ShipmentModeID");

            //    entity.HasOne(d => d.ShipmentMode)
            //        .WithMany(p => p.BciShipmentModeDetail)
            //        .HasForeignKey(d => d.ShipmentModeId)
            //        .HasConstraintName("FK_BCI_ShipmentModeDetail_BCI_ShipmentMode");
            //});

            //modelBuilder.Entity<BciShippersSetup>(entity =>
            //{
            //    entity.ToTable("BCI_ShippersSetup");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Address)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Name)
            //        .IsRequired()
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PhoneNo)
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SalesTaxNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<BciShortShipmentMaster>(entity =>
            //{
            //    entity.ToTable("BCI_ShortShipmentMaster");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.BciShipmentMasterId).HasColumnName("BCI_ShipmentMasterID");
            //});

            //modelBuilder.Entity<BciSingleBarCodes>(entity =>
            //{
            //    entity.HasKey(e => e.SingleBarCode);

            //    entity.ToTable("BCI_SingleBarCodes");

            //    entity.HasIndex(e => e.Status)
            //        .HasName("IX_BCI_SingleBarCodes_NC");

            //    entity.Property(e => e.SingleBarCode)
            //        .HasMaxLength(25)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<BciSoldTo>(entity =>
            //{
            //    entity.ToTable("BCI_SoldTO");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Address)
            //        .IsRequired()
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.FaxNumber)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PartyName)
            //        .IsRequired()
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.TelephoneNumber)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<BciStockStatusLog>(entity =>
            //{
            //    entity.HasKey(e => e.RunId);

            //    entity.ToTable("BCI_StockStatusLog");

            //    entity.Property(e => e.RunId).HasColumnName("RunID");

            //    entity.Property(e => e.Deleted).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.RunDate).HasColumnType("datetime");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<BciStockStatusLogDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("BCI_StockStatusLogDetail");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.Deleted).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.RunId).HasColumnName("RunID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.HasOne(d => d.Run)
            //        .WithMany(p => p.BciStockStatusLogDetail)
            //        .HasForeignKey(d => d.RunId)
            //        .HasConstraintName("FK_BCI_StockStatusLogDetail_BCI_StockStatusLog");
            //});

            //modelBuilder.Entity<BciStockTransaction>(entity =>
            //{
            //    entity.HasKey(e => e.StockTransactionId);

            //    entity.ToTable("BCI_StockTransaction");

            //    entity.HasIndex(e => new { e.BciCartonSetupMasterId, e.DocumentTypeId, e.DocumentNo, e.OrderId, e.Model })
            //        .HasName("BCI_StockTransaction3");

            //    entity.Property(e => e.StockTransactionId).HasColumnName("StockTransactionID");

            //    entity.Property(e => e.BciCartonSetupMasterId).HasColumnName("BCI_CartonSetupMasterID");

            //    entity.Property(e => e.BuyerId).HasColumnName("BuyerID");

            //    entity.Property(e => e.Color)
            //        .IsRequired()
            //        .HasMaxLength(5)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DocumentDate).HasColumnType("datetime");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.Model)
            //        .IsRequired()
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ModelId).HasColumnName("ModelID");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.Size)
            //        .IsRequired()
            //        .HasMaxLength(5)
            //        .IsUnicode(false);

            //    entity.Property(e => e.TransactionDate).HasColumnType("datetime");
            //});

            //modelBuilder.Entity<BciStyleColorCode>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("BCI_StyleColorCode");

            //    entity.Property(e => e.ColorCode)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.Deleted).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.TransactionDate).HasColumnType("datetime");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<BciStyleDescription>(entity =>
            //{
            //    entity.ToTable("BCI_StyleDescription");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Deleted).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<BciUniqueAssortementDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("BCI_UniqueAssortementDetail");

            //    entity.HasIndex(e => e.MasterId)
            //        .HasName("IX_BCI_UniqueAssortementDetail_NC");

            //    entity.HasIndex(e => e.SingleBarCode)
            //        .HasName("IX_BCI_UniqueAssortementDetail")
            //        .IsUnique()
            //        .IsClustered();

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.MasterId).HasColumnName("MasterID");

            //    entity.Property(e => e.SingleBarCode)
            //        .IsRequired()
            //        .HasMaxLength(25)
            //        .IsUnicode(false);

            //    entity.HasOne(d => d.Master)
            //        .WithMany(p => p.BciUniqueAssortementDetail)
            //        .HasForeignKey(d => d.MasterId)
            //        .HasConstraintName("FK_BCI_UniqueAssortementDetail_BCI_UniqueAssortementMaster");
            //});

            //modelBuilder.Entity<BciUniqueAssortementMaster>(entity =>
            //{
            //    entity.HasKey(e => e.MasterId)
            //        .IsClustered(false);

            //    entity.ToTable("BCI_UniqueAssortementMaster");

            //    entity.HasIndex(e => e.MasterBarCode)
            //        .HasName("IX_BCI_UniqueAssortementMaster")
            //        .IsClustered();

            //    entity.Property(e => e.MasterId).HasColumnName("MasterID");

            //    entity.Property(e => e.AssortementCode)
            //        .IsRequired()
            //        .HasMaxLength(5)
            //        .IsUnicode(false);

            //    entity.Property(e => e.AssortementCodeSetupMasterId).HasColumnName("AssortementCodeSetup_MasterID");

            //    entity.Property(e => e.ColorCode)
            //        .IsRequired()
            //        .HasMaxLength(5)
            //        .IsUnicode(false);

            //    entity.Property(e => e.MasterBarCode)
            //        .IsRequired()
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OrderNo)
            //        .IsRequired()
            //        .HasMaxLength(5)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StyleCode)
            //        .IsRequired()
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<BciUniqueBarCodeDetail>(entity =>
            //{
            //    entity.ToTable("BCI_UniqueBarCodeDetail");

            //    entity.HasIndex(e => new { e.CartonSetupDetailId, e.CartonSetupMasterId, e.UniqueBarCode })
            //        .HasName("IX_BCI_UniqueBarCodeDetail_NC");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.CartonSetupDetailId).HasColumnName("CartonSetupDetailID");

            //    entity.Property(e => e.CartonSetupMasterId).HasColumnName("CartonSetupMasterID");

            //    entity.Property(e => e.Date).HasColumnType("datetime");

            //    entity.Property(e => e.UniqueBarCode)
            //        .HasMaxLength(21)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<CartonWisePackingView>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("CartonWisePacking_View");

            //    entity.Property(e => e.Color)
            //        .IsRequired()
            //        .HasMaxLength(5)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CustomerCode)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Delivery)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DestinationCode)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Model)
            //        .IsRequired()
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Size)
            //        .IsRequired()
            //        .HasMaxLength(5)
            //        .IsUnicode(false);

            //    entity.Property(e => e.TransactionDate).HasColumnType("datetime");
            //});

            //modelBuilder.Entity<CcpackingStatusView>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("CCPackingStatus_View");

            //    entity.Property(e => e.Color)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CustomerCode)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Delivery)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DestinationCode)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Model)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Size)
            //        .IsRequired()
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .IsFixedLength();
            //});

            //modelBuilder.Entity<CcshipmentStatusView>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("CCShipmentStatus_View");

            //    entity.Property(e => e.Color)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CustomerCode)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

            //    entity.Property(e => e.Delivery)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DestinationCode)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DestinationId).HasColumnName("DestinationID");

            //    entity.Property(e => e.Model)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OrderDeliveryId).HasColumnName("OrderDeliveryID");

            //    entity.Property(e => e.Size)
            //        .IsRequired()
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .IsFixedLength();
            //});

            //modelBuilder.Entity<CmblAssetToCostCenterAssociation>(entity =>
            //{
            //    entity.ToTable("CMBL_AssetToCostCenterAssociation");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

            //    entity.Property(e => e.Coaid).HasColumnName("COAID");

            //    entity.Property(e => e.CostCenterId).HasColumnName("CostCenterID");

            //    entity.Property(e => e.DomainId).HasColumnName("DomainID");

            //    entity.Property(e => e.LocationId).HasColumnName("LocationID");
            //});

            //modelBuilder.Entity<CmblCategory>(entity =>
            //{
            //    entity.HasKey(e => e.CategoryId);

            //    entity.ToTable("CMBL_Category");

            //    entity.Property(e => e.CategoryId)
            //        .HasColumnName("CategoryID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.CategoryName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<CmblCoaassociationType>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMBL_COAAssociationType");

            //    entity.Property(e => e.Bg1id).HasColumnName("BG1ID");

            //    entity.Property(e => e.Coaid).HasColumnName("COAID");

            //    entity.Property(e => e.DomainId).HasColumnName("DomainID");

            //    entity.Property(e => e.RelationId).HasColumnName("RelationID");
            //});

            //modelBuilder.Entity<CmblCoaassociationTypeBkup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMBL_COAAssociationType_BKUP");

            //    entity.Property(e => e.Bg1id).HasColumnName("BG1ID");

            //    entity.Property(e => e.Coaid).HasColumnName("COAID");

            //    entity.Property(e => e.RelationId).HasColumnName("RelationID");
            //});

            //modelBuilder.Entity<CmblCoaassociationTypeSetup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMBL_COAAssociationType_Setup");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.RelationId).HasColumnName("RelationID");
            //});

            //modelBuilder.Entity<CmblConsolidatedFabricIssQuantitytemp>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMBL_ConsolidatedFabricIssQuantitytemp");

            //    entity.Property(e => e.ConsolidatedFabricXml)
            //        .HasColumnName("ConsolidatedFabricXML")
            //        .HasColumnType("ntext");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");
            //});

            //modelBuilder.Entity<CmblDocumentTypeSetup>(entity =>
            //{
            //    entity.HasKey(e => e.DocumentTypeId);

            //    entity.ToTable("CMBL_DocumentType_Setup");

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
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .IsFixedLength();
            //});

            //modelBuilder.Entity<CmblFiintegeration>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMBL_FIIntegeration");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.VoucherId).HasColumnName("VoucherID");

            //    entity.Property(e => e.VoucherNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<CmblFiintegerationOld>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMBL_FIIntegerationOld");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.VoucherId).HasColumnName("VoucherID");

            //    entity.Property(e => e.VoucherNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<CmblGateReceiving>(entity =>
            //{
            //    entity.HasKey(e => e.Grid);

            //    entity.ToTable("CMBL_GateReceiving");

            //    entity.Property(e => e.Grid).HasColumnName("GRID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.Deleted).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.DeliveryChallanNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

            //    entity.Property(e => e.DeliveryPerson)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Grno).HasColumnName("GRNo");

            //    entity.Property(e => e.Poid).HasColumnName("POID");

            //    entity.Property(e => e.TempStatus).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.Property(e => e.VehicleNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<CmblGateReceivingDetail>(entity =>
            //{
            //    entity.HasKey(e => e.Grdid);

            //    entity.ToTable("CMBL_GateReceivingDetail");

            //    entity.Property(e => e.Grdid).HasColumnName("GRDID");

            //    entity.Property(e => e.Grid).HasColumnName("GRID");

            //    entity.Property(e => e.ItemId).HasColumnName("ItemID");

            //    entity.HasOne(d => d.Gr)
            //        .WithMany(p => p.CmblGateReceivingDetail)
            //        .HasForeignKey(d => d.Grid)
            //        .HasConstraintName("FK_CMBL_GateReceivingDetail_CMBL_GateReceiving");
            //});

            //modelBuilder.Entity<CmblInspectionDetail>(entity =>
            //{
            //    entity.HasKey(e => e.Mindid);

            //    entity.ToTable("CMBL_InspectionDetail");

            //    entity.Property(e => e.Mindid).HasColumnName("MINDID");

            //    entity.Property(e => e.MinacceptedQty).HasColumnName("MINAcceptedQty");

            //    entity.Property(e => e.Mincomments)
            //        .HasColumnName("MINComments")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Minid).HasColumnName("MINID");

            //    entity.Property(e => e.MinrejectedQty).HasColumnName("MINRejectedQty");

            //    entity.Property(e => e.PoitemId).HasColumnName("POItemID");

            //    entity.HasOne(d => d.Min)
            //        .WithMany(p => p.CmblInspectionDetail)
            //        .HasForeignKey(d => d.Minid)
            //        .OnDelete(DeleteBehavior.Cascade)
            //        .HasConstraintName("FK_CMBL_InspectionDetail_CMBL_InspectionMain");

            //    entity.HasOne(d => d.Poitem)
            //        .WithMany(p => p.CmblInspectionDetail)
            //        .HasForeignKey(d => d.PoitemId)
            //        .HasConstraintName("FK_CMBL_InspectionDetail_CMBL_PurchaseOrderItem");
            //});

            //modelBuilder.Entity<CmblInspectionMain>(entity =>
            //{
            //    entity.HasKey(e => e.Minid);

            //    entity.ToTable("CMBL_InspectionMain");

            //    entity.Property(e => e.Minid).HasColumnName("MINID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.Deleted).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.Docid).HasColumnName("DOCID");

            //    entity.Property(e => e.DoctypeId).HasColumnName("DOCTypeID");

            //    entity.Property(e => e.Mindate)
            //        .HasColumnName("MINDate")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.Minno)
            //        .HasColumnName("MINNO")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Ogpstatus)
            //        .HasColumnName("OGPStatus")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.Poid).HasColumnName("POID");

            //    entity.Property(e => e.PrecStatus)
            //        .HasColumnName("PRecStatus")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.Trid).HasColumnName("TRID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<CmblInterBroadGroupTransfer>(entity =>
            //{
            //    entity.HasKey(e => e.Ibgid);

            //    entity.ToTable("CMBL_InterBroadGroupTransfer");

            //    entity.Property(e => e.Ibgid).HasColumnName("IBGID");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.Deleted).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.Ibgdate)
            //        .HasColumnName("IBGDate")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.Ibgno).HasColumnName("IBGNO");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<CmblInterOrderTransfer>(entity =>
            //{
            //    entity.HasKey(e => e.Iotid);

            //    entity.ToTable("CMBL_InterOrderTransfer");

            //    entity.Property(e => e.Iotid).HasColumnName("IOTID");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.Deleted).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.Iotdate)
            //        .HasColumnName("IOTDate")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.Iotno).HasColumnName("IOTNO");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<CmblInterStoreTransferMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMBL_InterStoreTransfer_Master");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.Deleted).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.Istdate)
            //        .HasColumnName("ISTDate")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.Istid)
            //        .HasColumnName("ISTID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Istno)
            //        .IsRequired()
            //        .HasColumnName("ISTNO")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<CmblIssuanceWithOutRequisition>(entity =>
            //{
            //    entity.HasKey(e => e.IssuanceId);

            //    entity.ToTable("CMBL_IssuanceWithOutRequisition");

            //    entity.Property(e => e.IssuanceId).HasColumnName("IssuanceID");

            //    entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.Deleted).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.IssuanceDate).HasColumnType("datetime");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.ReceivingPerson)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Remarks)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.RequisitionNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.Property(e => e.YarnKncontractId).HasColumnName("YarnKNContractID");
            //});

            //modelBuilder.Entity<CmblIssuanceWithRequisition>(entity =>
            //{
            //    entity.HasKey(e => e.IssuanceId)
            //        .HasName("PK_IssuanceWithRequisition");

            //    entity.ToTable("CMBL_IssuanceWithRequisition");

            //    entity.Property(e => e.IssuanceId).HasColumnName("IssuanceID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.Deleted).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.IssuanceDate).HasColumnType("datetime");

            //    entity.Property(e => e.RecPerson)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<CmblItem>(entity =>
            //{
            //    entity.HasKey(e => e.ItemId);

            //    entity.ToTable("CMBL_Item");

            //    entity.HasIndex(e => new { e.LowestAttributeId, e.ItemId, e.Sku })
            //        .HasName("IX_CMBL_Item");

            //    entity.Property(e => e.ItemId).HasColumnName("ItemID");

            //    entity.Property(e => e.BlockStatus)
            //        .HasColumnName("Block_Status")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.CompanyId)
            //        .HasColumnName("CompanyID")
            //        .HasDefaultValueSql("(183)");

            //    entity.Property(e => e.ItemCode)
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.ItemMasterId).HasColumnName("ItemMasterID");

            //    entity.Property(e => e.ItemName)
            //        .IsRequired()
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ItemType).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.LowestAttributeId).HasColumnName("LowestAttributeID");

            //    entity.Property(e => e.SafetyStock).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.Sku).HasColumnName("SKU");
            //});

            //modelBuilder.Entity<CmblItemAttribute>(entity =>
            //{
            //    entity.HasKey(e => e.AttributeId);

            //    entity.ToTable("CMBL_ItemAttribute");

            //    entity.HasIndex(e => new { e.CompanyId, e.AttributeId, e.AttributeLevel })
            //        .HasName("Ind_CMBL_ItemAttribute_1");

            //    entity.Property(e => e.AttributeId).HasColumnName("AttributeID");

            //    entity.Property(e => e.AttributeCode)
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.AttributeName)
            //        .IsRequired()
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CompanyId)
            //        .HasColumnName("CompanyID")
            //        .HasDefaultValueSql("(183)");

            //    entity.Property(e => e.ParentAttributeId).HasColumnName("ParentAttributeID");
            //});

            //modelBuilder.Entity<CmblItemAttributeSet>(entity =>
            //{
            //    entity.HasKey(e => e.ItemAttributeId);

            //    entity.ToTable("CMBL_ItemAttributeSet");

            //    entity.HasIndex(e => new { e.ItemId, e.AttributeId })
            //        .HasName("Ind_CMBL_ItemAttributeSet_1");

            //    entity.Property(e => e.ItemAttributeId).HasColumnName("ItemAttributeID");

            //    entity.Property(e => e.AttributeId).HasColumnName("AttributeID");

            //    entity.Property(e => e.ItemId).HasColumnName("ItemID");

            //    entity.HasOne(d => d.Attribute)
            //        .WithMany(p => p.CmblItemAttributeSet)
            //        .HasForeignKey(d => d.AttributeId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_CMBL_ItemAttributeSet_CMBL_ItemAttribute");

            //    entity.HasOne(d => d.Item)
            //        .WithMany(p => p.CmblItemAttributeSet)
            //        .HasForeignKey(d => d.ItemId)
            //        .HasConstraintName("FK_CMBL_ItemAttributeSet_CMBL_Item");
            //});

            //modelBuilder.Entity<CmblItemImportDuty>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMBL_ItemImportDuty");

            //    entity.Property(e => e.CmblAit)
            //        .HasColumnName("CMBL_AIT")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.CmblAtv)
            //        .HasColumnName("CMBL_ATV")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.CmblCustomDuty).HasColumnName("CMBL_CustomDuty");

            //    entity.Property(e => e.CmblFiscal).HasColumnName("CMBL_Fiscal");

            //    entity.Property(e => e.CmblHscode)
            //        .HasColumnName("CMBL_HSCODE")
            //        .HasMaxLength(15)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CmblId)
            //        .HasColumnName("CMBL_ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.CmblItemId).HasColumnName("CMBL_ItemID");

            //    entity.Property(e => e.CmblOther)
            //        .HasColumnName("CMBL_OTHER")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.CmblRd)
            //        .HasColumnName("CMBL_RD")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.CmblSupplementaryDuty)
            //        .HasColumnName("CMBL_SupplementaryDuty")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.CmblTtl)
            //        .HasColumnName("CMBL_TTL")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.CmblVat)
            //        .HasColumnName("CMBL_VAT")
            //        .HasDefaultValueSql("((0))");
            //});

            //modelBuilder.Entity<CmblItemImportDutyLog>(entity =>
            //{
            //    entity.HasKey(e => e.CmblLogId);

            //    entity.ToTable("CMBL_ItemImportDuty_log");

            //    entity.Property(e => e.CmblLogId).HasColumnName("CMBL_log_ID");

            //    entity.Property(e => e.CmblAit)
            //        .HasColumnName("CMBL_AIT")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.CmblAtv)
            //        .HasColumnName("CMBL_ATV")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.CmblCustomDuty).HasColumnName("CMBL_CustomDuty");

            //    entity.Property(e => e.CmblFiscal).HasColumnName("CMBL_Fiscal");

            //    entity.Property(e => e.CmblHscode)
            //        .HasColumnName("CMBL_HSCODE")
            //        .HasMaxLength(15)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CmblId).HasColumnName("CMBL_ID");

            //    entity.Property(e => e.CmblItemId).HasColumnName("CMBL_ItemID");

            //    entity.Property(e => e.CmblOther)
            //        .HasColumnName("CMBL_OTHER")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.CmblRd)
            //        .HasColumnName("CMBL_RD")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.CmblSupplementaryDuty)
            //        .HasColumnName("CMBL_SupplementaryDuty")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.CmblTtl)
            //        .HasColumnName("CMBL_TTL")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.CmblVat)
            //        .HasColumnName("CMBL_VAT")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.CreatDate)
            //        .HasColumnName("creat_date")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.ModifyUser).HasColumnName("modify_user");
            //});

            //modelBuilder.Entity<CmblItemMaster>(entity =>
            //{
            //    entity.HasKey(e => e.ItemMasterId);

            //    entity.ToTable("CMBL_ItemMaster");

            //    entity.Property(e => e.ItemMasterId).HasColumnName("ItemMasterID");

            //    entity.Property(e => e.ItemName)
            //        .HasMaxLength(400)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");
            //});

            //modelBuilder.Entity<CmblItemRequisitionMaster>(entity =>
            //{
            //    entity.HasKey(e => e.Irid);

            //    entity.ToTable("CMBL_ItemRequisitionMaster");

            //    entity.HasIndex(e => new { e.Ircode, e.Irid, e.BuyerId })
            //        .HasName("_dta_index_CMBL_ItemRequisitionMaster_9_1921546029__K1_K13_K2");

            //    entity.HasIndex(e => new { e.Irid, e.CompanyId, e.ReqTypeId, e.StoreId, e.BuyerId })
            //        .HasName("Ind_CMBL_ItemRequisitionMaster");

            //    entity.Property(e => e.Irid).HasColumnName("IRID");

            //    entity.Property(e => e.BuyerId).HasColumnName("BuyerID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.CreatorComments)
            //        .HasMaxLength(8000)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

            //    entity.Property(e => e.Ircode).HasColumnName("IRCode");

            //    entity.Property(e => e.LoanCompanyId).HasColumnName("LoanCompanyID");

            //    entity.Property(e => e.LoanStoreId).HasColumnName("LoanStoreID");

            //    entity.Property(e => e.LocationId).HasColumnName("LocationID");

            //    entity.Property(e => e.Pocomments)
            //        .HasColumnName("POComments")
            //        .HasMaxLength(8000)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Postatus).HasColumnName("POStatus");

            //    entity.Property(e => e.ReqTypeId).HasColumnName("ReqTypeID");

            //    entity.Property(e => e.ReqTypes).HasDefaultValueSql("((1))");

            //    entity.Property(e => e.StoreComments)
            //        .HasMaxLength(8000)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StoreId).HasColumnName("StoreID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.Property(e => e.WashingStageId).HasColumnName("WashingStageID");
            //});

            modelBuilder.Entity<CMBL_ItemRequisitionRequirement>(entity =>
            {
                entity.HasKey(e => e.IRRID);

                //entity.HasIndex(e => new { e.Irrid, e.ReqDate, e.Irid, e.OrderId })
                //    .HasName("_dta_index_CMBL_ItemRequisitionRequirement_9_1113875135__K1_K2_K15");

                //entity.HasIndex(e => new { e.Irid, e.OrderId, e.LotId, e.ItemId, e.ReqDate })
                //    .HasName("Ind_CMBL_ItemRequisitionRequirement");

                //entity.Property(e => e.Irrid).HasColumnName("IRRID");

                entity.Property(e => e.ByGramPerLitre).HasDefaultValueSql("((0))");

                entity.Property(e => e.ByWeight).HasDefaultValueSql("((0))");

                entity.Property(e => e.Color)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InPOQuantity)
                    //.HasColumnName("InPOQuantity")
                    .HasDefaultValueSql("((0))");

                //entity.Property(e => e.Irid).HasColumnName("IRID");

                entity.Property(e => e.IsLoan).HasDefaultValueSql("((-1))");

                //entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.LiquorRatio).HasDefaultValueSql("((0))");

                //entity.Property(e => e.LotId).HasColumnName("Lot_Id");

                entity.Property(e => e.Lot_No)
                    //.HasColumnName("Lot_No")
                    .HasMaxLength(50);

                //entity.Property(e => e.OrderId).HasColumnName("OrderID");

                //entity.Property(e => e.Postatus).HasColumnName("POStatus");

                //entity.Property(e => e.PrePoquantity).HasColumnName("PrePOQuantity");

                //entity.Property(e => e.ProcessId).HasColumnName("ProcessID");

                entity.Property(e => e.ReducedQuantity).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReducedReason)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReqDate).HasColumnType("datetime");

                entity.Property(e => e.ReqMachineName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReqMachineNo).HasMaxLength(50);

                entity.Property(e => e.ReservedQuantity).HasDefaultValueSql("((0))");

                // entity.Property(e => e.UserSelectedUnitId).HasColumnName("UserSelectedUnitID");
            });

            //modelBuilder.Entity<CmblItemRequisitionRequirementEdit>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMBL_ItemRequisitionRequirement_Edit");

            //    entity.Property(e => e.Creationdate)
            //        .HasColumnName("creationdate")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Depid).HasColumnName("depid");

            //    entity.Property(e => e.DocumnetType).HasDefaultValueSql("((1))");

            //    entity.Property(e => e.Irrid).HasColumnName("IRRID");

            //    entity.Property(e => e.StCsId)
            //        .HasColumnName("St_CS_ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Userid).HasColumnName("userid");
            //});

            //modelBuilder.Entity<CmblItemUnit>(entity =>
            //{
            //    entity.HasKey(e => new { e.ItemId, e.UnitId });

            //    entity.ToTable("CMBL_ItemUnit");

            //    entity.Property(e => e.ItemId).HasColumnName("ItemID");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");

            //    entity.Property(e => e.Skuconversion).HasColumnName("SKUConversion");

            //    entity.HasOne(d => d.Item)
            //        .WithMany(p => p.CmblItemUnit)
            //        .HasForeignKey(d => d.ItemId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_CMBL_ItemUnit_CMBL_Item");

            //    entity.HasOne(d => d.Unit)
            //        .WithMany(p => p.CmblItemUnit)
            //        .HasForeignKey(d => d.UnitId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_CMBL_ItemUnit_CMBL_Unit");
            //});

            //modelBuilder.Entity<CmblIwadjustmentMaster>(entity =>
            //{
            //    entity.HasKey(e => e.IwadjustmentId);

            //    entity.ToTable("CMBL_IWAdjustmentMaster");

            //    entity.Property(e => e.IwadjustmentId).HasColumnName("IWAdjustmentID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.Deleted).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.IwadjComments)
            //        .HasColumnName("IWAdjComments")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.IwadjustmentDate)
            //        .HasColumnName("IWAdjustmentDate")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.IwadjustmentNo).HasColumnName("IWAdjustmentNo");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<CmblLoan>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMBL_Loan");

            //    entity.Property(e => e.ApprovalDate).HasColumnType("datetime");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.LoanComments)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.LoanId)
            //        .HasColumnName("LoanID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.LoanStatus).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.MainComments)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<CmblLoanItem>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMBL_LoanItem");

            //    entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");

            //    entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

            //    entity.Property(e => e.ItemId).HasColumnName("ItemID");

            //    entity.Property(e => e.LoanId).HasColumnName("LoanID");

            //    entity.Property(e => e.LoanItemId)
            //        .HasColumnName("LoanItemID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Remarks)
            //        .HasMaxLength(250)
            //        .IsUnicode(false);

            //    entity.Property(e => e.RequisitionDetailId).HasColumnName("RequisitionDetailID");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");
            //});

            //modelBuilder.Entity<CmblLoanReceiving>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMBL_LoanReceiving");

            //    entity.Property(e => e.ChallanDate)
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Challano)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.Deleted)
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.DocumentDate).HasColumnType("datetime");

            //    entity.Property(e => e.LoanId).HasColumnName("LoanID");

            //    entity.Property(e => e.LoanRecId)
            //        .HasColumnName("LoanRecID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<CmblLoanToSupplierDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMBL_LoanToSupplierDetail");

            //    entity.Property(e => e.ItemId).HasColumnName("ItemID");

            //    entity.Property(e => e.LoanDetailId)
            //        .HasColumnName("LoanDetailID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.LoanId).HasColumnName("LoanID");

            //    entity.Property(e => e.StoreLocationId).HasColumnName("StoreLocationID");

            //    entity.Property(e => e.StoreLocationName)
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserSelectedUnitId).HasColumnName("UserSelectedUnitID");
            //});

            //modelBuilder.Entity<CmblLoanToSupplierMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMBL_LoanToSupplierMaster");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.CreatorComments)
            //        .HasMaxLength(8000)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

            //    entity.Property(e => e.GatePassDate).HasColumnType("datetime");

            //    entity.Property(e => e.GatePassNo)
            //        .IsRequired()
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .HasDefaultValueSql("((-1))");

            //    entity.Property(e => e.GatePassUserId).HasColumnName("GatePassUserID");

            //    entity.Property(e => e.LoanId)
            //        .HasColumnName("LoanID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<CmblLog>(entity =>
            //{
            //    entity.HasKey(e => e.LogId);

            //    entity.ToTable("CMBL_Log");

            //    entity.Property(e => e.LogId).HasColumnName("LogID");

            //    entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.LogDate).HasColumnType("datetime");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.HasOne(d => d.Category)
            //        .WithMany(p => p.CmblLog)
            //        .HasForeignKey(d => d.CategoryId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_CMBL_Log_CMBL_Category");

            //    entity.HasOne(d => d.DocumentType)
            //        .WithMany(p => p.CmblLog)
            //        .HasForeignKey(d => d.DocumentTypeId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_CMBL_Log_CMBL_DocumentType_Setup");
            //});

            //modelBuilder.Entity<CmblLotdelweight>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMBL_LOTDELWEIGHT");

            //    entity.HasIndex(e => e.Irmlotdelreqid)
            //        .HasName("IND_CMBL_LOTDELWEIGHT")
            //        .IsClustered();

            //    entity.Property(e => e.Irmlotdelreqid).HasColumnName("IRMLOTDELREQID");

            //    entity.Property(e => e.Irmlotdelwt).HasColumnName("IRMLOTDELWT");

            //    entity.Property(e => e.Irmlotdelwtdate)
            //        .HasColumnName("IRMLOTDELWTDATE")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Irmlotdelwtid)
            //        .HasColumnName("IRMLOTDELWTID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<CmblLotweight>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMBL_LOTWEIGHT");

            //    entity.HasIndex(e => e.Irmlotreqid)
            //        .HasName("CMBL_LOTWEIGHT")
            //        .IsClustered();

            //    entity.Property(e => e.Irmlotdeliveredwt)
            //        .HasColumnName("IRMLOTDELIVEREDWT")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.Irmlotfinalwt).HasColumnName("IRMLOTFINALWT");

            //    entity.Property(e => e.Irmlotreason)
            //        .HasColumnName("IRMLOTREASON")
            //        .HasMaxLength(255)
            //        .IsUnicode(false)
            //        .HasDefaultValueSql("('NO COMMENTS')");

            //    entity.Property(e => e.Irmlotreqid).HasColumnName("IRMLOTREQID");

            //    entity.Property(e => e.IrmlotwtDate)
            //        .HasColumnName("IRMLOTWtDate")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Irmlotwtid)
            //        .HasColumnName("IRMLOTWTID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<CmblOpeningBalance>(entity =>
            //{
            //    entity.HasKey(e => e.Obid);

            //    entity.ToTable("CMBL_OpeningBalance");

            //    entity.Property(e => e.Obid).HasColumnName("OBID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.Deleted).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.Obdate)
            //        .HasColumnName("OBDate")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.Obno).HasColumnName("OBNo");

            //    entity.Property(e => e.UserId)
            //        .IsRequired()
            //        .HasColumnName("UserID")
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .IsFixedLength();
            //});

            //modelBuilder.Entity<CmblOutGatePass>(entity =>
            //{
            //    entity.HasKey(e => e.Ogpid);

            //    entity.ToTable("CMBL_OutGatePass");

            //    entity.Property(e => e.Ogpid).HasColumnName("OGPID");

            //    entity.Property(e => e.CompId).HasColumnName("CompID");

            //    entity.Property(e => e.Minid).HasColumnName("MINID");

            //    entity.Property(e => e.Ogpdate)
            //        .HasColumnName("OGPDate")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.Ogpno)
            //        .HasColumnName("OGPNo")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Poid).HasColumnName("POID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.HasOne(d => d.Min)
            //        .WithMany(p => p.CmblOutGatePass)
            //        .HasForeignKey(d => d.Minid)
            //        .OnDelete(DeleteBehavior.Cascade)
            //        .HasConstraintName("FK_CMBL_OutGatePass_CMBL_InspectionMain");
            //});

            //modelBuilder.Entity<CmblPaymentMode>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMBL_PaymentMode");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.Pmdescription)
            //        .IsRequired()
            //        .HasColumnName("PMDescription")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Pmid)
            //        .HasColumnName("PMID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<CmblPaymentTerm>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMBL_PaymentTerm");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.IsDisplay).HasDefaultValueSql("(1)");

            //    entity.Property(e => e.Ptdescription)
            //        .IsRequired()
            //        .HasColumnName("PTDescription")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Ptid)
            //        .HasColumnName("PTID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<CmblPotype>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMBL_POType");

            //    entity.Property(e => e.PotypeDescription)
            //        .IsRequired()
            //        .HasColumnName("POTypeDescription")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PotypeId).HasColumnName("POTypeID");
            //});

            //modelBuilder.Entity<CmblPurchaseOrder>(entity =>
            //{
            //    entity.HasKey(e => e.Poid);

            //    entity.ToTable("CMBL_PurchaseOrder");

            //    entity.Property(e => e.Poid).HasColumnName("POID");

            //    entity.Property(e => e.AdvancePercentage).HasColumnName("advance_percentage");

            //    entity.Property(e => e.ApprovalDate).HasColumnType("datetime");

            //    entity.Property(e => e.ApprvAuthorityId).HasColumnName("ApprvAuthorityID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.Lcnumber)
            //        .HasColumnName("LCNumber")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.MainComments)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PaymentMode)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PaymentTerm)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Pocomments)
            //        .HasColumnName("POComments")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Pono).HasColumnName("PONo");

            //    entity.Property(e => e.PonoNew).HasColumnName("PONO_New");

            //    entity.Property(e => e.Postatus)
            //        .HasColumnName("POStatus")
            //        .HasDefaultValueSql("(5)");

            //    entity.Property(e => e.PotypeId)
            //        .HasColumnName("POTypeID")
            //        .HasDefaultValueSql("(1)");

            //    entity.Property(e => e.Ptid).HasColumnName("PTID");

            //    entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<CmblPurchaseOrderItem>(entity =>
            //{
            //    entity.HasKey(e => e.PoitemId);

            //    entity.ToTable("CMBL_PurchaseOrderItem");

            //    entity.HasIndex(e => new { e.Poid, e.RequisitionDetailId })
            //        .HasName("_dta_index_CMBL_PurchaseOrderItem_9_1751781398__K3_K5");

            //    entity.Property(e => e.PoitemId).HasColumnName("POItemID");

            //    entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

            //    entity.Property(e => e.Fcid).HasColumnName("FCID");

            //    entity.Property(e => e.Fcrate).HasColumnName("FCRate");

            //    entity.Property(e => e.ItemId).HasColumnName("ItemID");

            //    entity.Property(e => e.Poid).HasColumnName("POID");

            //    entity.Property(e => e.Remarks)
            //        .IsRequired()
            //        .HasMaxLength(250)
            //        .IsUnicode(false);

            //    entity.Property(e => e.RequisitionDetailId).HasColumnName("RequisitionDetailID");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");

            //    entity.HasOne(d => d.Po)
            //        .WithMany(p => p.CmblPurchaseOrderItem)
            //        .HasForeignKey(d => d.Poid)
            //        .HasConstraintName("FK_CMBL_PurchaseOrderItem_CMBL_PurchaseOrder");

            //    entity.HasOne(d => d.Unit)
            //        .WithMany(p => p.CmblPurchaseOrderItem)
            //        .HasForeignKey(d => d.UnitId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_CMBL_PurchaseOrderItem_CMBL_Unit");
            //});

            //modelBuilder.Entity<CmblReceivingWithOutPo>(entity =>
            //{
            //    entity.HasKey(e => e.RecWithOutPoid);

            //    entity.ToTable("CMBL_ReceivingWithOutPO");

            //    entity.Property(e => e.RecWithOutPoid).HasColumnName("RecWithOutPOID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.ContactPerson)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Deleted)
            //        .IsRequired()
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .IsFixedLength()
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.DeliveryChallanDate).HasColumnType("datetime");

            //    entity.Property(e => e.DeliveryChallanNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DocumentDate).HasColumnType("datetime");

            //    entity.Property(e => e.InvoiceNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Podate)
            //        .HasColumnName("PODate")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.Pono)
            //        .IsRequired()
            //        .HasColumnName("PONo")
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.RecWithOutPono).HasColumnName("RecWithOutPONo");

            //    entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.Property(e => e.VehicleNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.YarnKncontractId).HasColumnName("YarnKNContractID");
            //});

            //modelBuilder.Entity<CmblRecievingwithPo>(entity =>
            //{
            //    entity.HasKey(e => e.Prid);

            //    entity.ToTable("CMBL_RecievingwithPO");

            //    entity.Property(e => e.Prid).HasColumnName("PRID");

            //    entity.Property(e => e.CompId).HasColumnName("CompID");

            //    entity.Property(e => e.Minid).HasColumnName("MINID");

            //    entity.Property(e => e.Poid).HasColumnName("POID");

            //    entity.Property(e => e.Prdate)
            //        .HasColumnName("PRDate")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.Prno)
            //        .HasColumnName("PRNO")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.HasOne(d => d.Min)
            //        .WithMany(p => p.CmblRecievingwithPo)
            //        .HasForeignKey(d => d.Minid)
            //        .HasConstraintName("FK_CMBL_RecievingwithPO_CMBL_InspectionMain");

            //    entity.HasOne(d => d.Po)
            //        .WithMany(p => p.CmblRecievingwithPo)
            //        .HasForeignKey(d => d.Poid)
            //        .HasConstraintName("FK_CMBL_RecievingwithPO_CMBL_PurchaseOrder");
            //});

            //modelBuilder.Entity<CmblRequisitionStatus>(entity =>
            //{
            //    entity.HasKey(e => e.StatusId)
            //        .HasName("PK_CMBL_Status");

            //    entity.ToTable("CMBL_RequisitionStatus");

            //    entity.Property(e => e.StatusId)
            //        .HasColumnName("StatusID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.StatusDescription)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<CmblRequisitionTypeSetup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMBL_RequisitionType_Setup");

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ReqTypeId).HasColumnName("ReqTypeID");
            //});

            //modelBuilder.Entity<CmblReturnFromDepartment>(entity =>
            //{
            //    entity.HasKey(e => e.Rfdid);

            //    entity.ToTable("CMBL_ReturnFromDepartment");

            //    entity.Property(e => e.Rfdid).HasColumnName("RFDID");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.Deleted).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.Rfddate)
            //        .HasColumnName("RFDDate")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.Rfdno).HasColumnName("RFDNO");

            //    entity.Property(e => e.Rpname)
            //        .HasColumnName("RPName")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<CmblReturnToSupplier>(entity =>
            //{
            //    entity.HasKey(e => e.Rtsid);

            //    entity.ToTable("CMBL_ReturnToSupplier");

            //    entity.Property(e => e.Rtsid).HasColumnName("RTSID");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.Rpname)
            //        .HasColumnName("RPName")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Rtsdate)
            //        .HasColumnName("RTSDate")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.Rtsno).HasColumnName("RTSNo");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<CmblSample>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMBL_Sample");

            //    entity.Property(e => e.ApproxDeliveryDate).HasColumnType("datetime");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.MainComments)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SampleComments)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SampleId)
            //        .HasColumnName("SampleID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

            //    entity.Property(e => e.TotalValue).HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<CmblSampleGateReceiving>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMBL_SampleGateReceiving");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.Deleted)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DeliveryChallanDate).HasColumnType("datetime");

            //    entity.Property(e => e.DeliveryChallano)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DeliveryPerson)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DocumentDate).HasColumnType("datetime");

            //    entity.Property(e => e.SampleId).HasColumnName("SampleID");

            //    entity.Property(e => e.SampleRecId)
            //        .HasColumnName("SampleRecID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.Property(e => e.VehicleNumber)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<CmblSampleIssue>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMBL_SampleIssue");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.Deleted)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DeliveryChallanDate).HasColumnType("datetime");

            //    entity.Property(e => e.DeliveryChallano)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DeliveryPerson)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DocumentDate).HasColumnType("datetime");

            //    entity.Property(e => e.SampleId).HasColumnName("SampleID");

            //    entity.Property(e => e.SampleIssueId)
            //        .HasColumnName("SampleIssueID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.Property(e => e.VehicleNumber)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<CmblSampleItem>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMBL_SampleItem");

            //    entity.Property(e => e.Balance).HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.ConversionRate).HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");

            //    entity.Property(e => e.ItemId).HasColumnName("ItemID");

            //    entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.Rate).HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.Remarks)
            //        .HasMaxLength(250)
            //        .IsUnicode(false);

            //    entity.Property(e => e.RequisitionDetailId).HasColumnName("RequisitionDetailID");

            //    entity.Property(e => e.SampleId).HasColumnName("SampleID");

            //    entity.Property(e => e.SampleItemId)
            //        .HasColumnName("SampleItemID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");
            //});

            //modelBuilder.Entity<CmblSampleItemGateReceiving>(entity =>
            //{
            //    entity.HasKey(e => e.SampleItemRecId)
            //        .HasName("PK_SapmleItemGateReceiveing");

            //    entity.ToTable("CMBL_SampleItemGateReceiving");

            //    entity.Property(e => e.SampleItemRecId).HasColumnName("SampleItemRecID");

            //    entity.Property(e => e.ReceivedQuantity).HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.SampleItemId).HasColumnName("SampleItemID");

            //    entity.Property(e => e.SampleRecId).HasColumnName("SampleRecID");
            //});

            //modelBuilder.Entity<CmblSampleItemIssue>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMBL_SampleItemIssue");

            //    entity.Property(e => e.IssuedQuantity).HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.SampleIssueId).HasColumnName("SampleIssueID");

            //    entity.Property(e => e.SampleItemId).HasColumnName("SampleItemID");

            //    entity.Property(e => e.SampleItemIssueId)
            //        .HasColumnName("SampleItemIssueID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<CmblStatusPo>(entity =>
            //{
            //    entity.HasKey(e => e.StatusId);

            //    entity.ToTable("CMBL_StatusPO");

            //    entity.Property(e => e.StatusId)
            //        .HasColumnName("StatusID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<CmblStockAdjustment>(entity =>
            //{
            //    entity.HasKey(e => e.AdjustmentId);

            //    entity.ToTable("CMBL_StockAdjustment");

            //    entity.Property(e => e.AdjustmentId).HasColumnName("AdjustmentID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.Deleted).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            modelBuilder.Entity<CMBL_StockTransaction>(entity =>
            {
                //    entity.HasKey(e => e.StockTransactionId);

                //    entity.ToTable("CMBL_StockTransaction");

                //    entity.HasIndex(e => new { e.Irrid, e.DocumentTypeId })
                //        .HasName("Ind_TEst");

                //    entity.HasIndex(e => new { e.DocumentTypeId, e.CompanyId, e.Irrid, e.OrderId, e.ItemId })
                //        .HasName("Ind_CMBL_StockTransaction");

                //    entity.Property(e => e.StockTransactionId).HasColumnName("StockTransactionID");

                //    entity.Property(e => e.AopReqDid).HasColumnName("aop_ReqDID");

                //    entity.Property(e => e.Comments)
                //        .HasMaxLength(200)
                //        .IsUnicode(false);

                //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                //    entity.Property(e => e.Deleted).HasDefaultValueSql("(0)");

                //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

                //    entity.Property(e => e.Irrid).HasColumnName("IRRID");

                //    entity.Property(e => e.ItemId).HasColumnName("ItemID");

                //    entity.Property(e => e.ModelId).HasColumnName("ModelID");

                //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

                //    entity.Property(e => e.RateWrtbaseUnit).HasColumnName("Rate_WRTbaseUnit");

                //    entity.Property(e => e.StoreLocationId).HasColumnName("StoreLocationID");

                //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

                //    entity.Property(e => e.TransactionDate).HasColumnType("datetime");

                //    entity.Property(e => e.YarnKncontractId).HasColumnName("YarnKNContractID");

                entity.HasOne(d => d.CMBL_Item)
                    .WithMany(p => p.CMBL_StockTransaction)
                    .HasForeignKey(d => d.ItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CMBL_StockTransaction_CMBL_Item");
            });

            //modelBuilder.Entity<CmblStoreBroadGroup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMBL_StoreBroadGroup");

            //    entity.Property(e => e.AttributeId).HasColumnName("AttributeID");

            //    entity.Property(e => e.StoreId).HasColumnName("StoreID");
            //});


            modelBuilder.Entity<CMBL_SubProgramDetail>(entity =>
            {
                //entity.HasKey(e => e.SbdId);

                //entity.ToTable("CMBL_SubProgramDetail");

                //entity.Property(e => e.SbdId).HasColumnName("SBD_ID");

                //entity.Property(e => e.SbId).HasColumnName("SB_ID");

                //entity.Property(e => e.SbdItemByGram).HasColumnName("SBD_ITemByGram");

                entity.Property(e => e.SBD_ItemByLiquorRatio)
                    .HasColumnName("SBD_ItemByLiquorRatio")
                    .HasComputedColumnSql("(([SBD_ITemByGram]*[SBD_ITemByLitre])/(1000))");

                //entity.Property(e => e.SbdItemByLitre).HasColumnName("SBD_ITemByLitre");

                //entity.Property(e => e.SbdItemByWeight)
                //    .HasColumnName("SBD_ITemByWeight")
                //    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SBD_ITemByWeightPercentage)
                    .HasColumnName("SBD_ITemByWeightPercentage")
                    .HasComputedColumnSql("([SBD_ItemByWeight]/(100))");

                //entity.Property(e => e.SbdItemId).HasColumnName("SBD_ItemID");

                //entity.Property(e => e.SbdItemUnit).HasColumnName("SBD_ITemUnit");

                //entity.Property(e => e.SbdItemWiseComment)
                //    .HasColumnName("SBD_ItemWiseComment")
                //    .HasMaxLength(350)
                //    .IsUnicode(false);

                //entity.Property(e => e.SbdProcessSequence).HasColumnName("SBD_ProcessSequence");

                entity.HasOne(d => d.CMBL_SubProgramMaster)
                    .WithMany(p => p.CMBL_SubProgramDetail)
                    .HasForeignKey(d => d.SB_ID)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CMBL_SubProgramDetail_CMBL_SubProgramMaster1");
            });

            modelBuilder.Entity<CMBL_UserStore>(entity =>
            {
                entity.HasNoKey();

                // entity.ToTable("CMBL_UserStore");

                //entity.property(e => e.StoreID).hascolumnname("StoreID");

                //entity.property(e => e.UserID).hascolumnname("UserID");
            });

            //modelBuilder.Entity<CmblSubProgramMaster>(entity =>
            //{
            //    entity.HasKey(e => e.SbId);

            //    entity.ToTable("CMBL_SubProgramMaster");

            //    entity.Property(e => e.SbId).HasColumnName("SB_ID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.SbCode)
            //        .HasColumnName("SB_Code")
            //        .HasMaxLength(6)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SbCreationDate)
            //        .HasColumnName("SB_CreationDate")
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.SbName)
            //        .HasColumnName("SB_Name")
            //        .HasMaxLength(150)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<CmblSubProgramProcess>(entity =>
            //{
            //    entity.HasKey(e => e.SubProgramProcessId);

            //    entity.ToTable("CMBL_SubProgramProcess");

            //    entity.Property(e => e.SubProgramProcessId).HasColumnName("SubProgram_ProcessID");

            //    entity.Property(e => e.SubProgramProcessName)
            //        .HasColumnName("SubProgram_ProcessName")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<CmblSupplierToCostCenterAssociation>(entity =>
            //{
            //    entity.ToTable("CMBL_SupplierToCostCenterAssociation");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

            //    entity.Property(e => e.Coaid).HasColumnName("COAID");

            //    entity.Property(e => e.CostCenterId).HasColumnName("CostCenterID");

            //    entity.Property(e => e.DomainId).HasColumnName("DomainID");

            //    entity.Property(e => e.LocationId).HasColumnName("LocationID");
            //});

            //modelBuilder.Entity<CmblTemporaryReceiving>(entity =>
            //{
            //    entity.HasKey(e => e.Trid);

            //    entity.ToTable("CMBL_TemporaryReceiving");

            //    entity.Property(e => e.Trid).HasColumnName("TRID");

            //    entity.Property(e => e.CompanyId)
            //        .HasColumnName("CompanyID")
            //        .HasDefaultValueSql("(183)");

            //    entity.Property(e => e.Deleted).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.Grid).HasColumnName("GRID");

            //    entity.Property(e => e.InspectionStatus).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.Poid).HasColumnName("POID");

            //    entity.Property(e => e.TempRecDate).HasColumnType("datetime");

            //    entity.Property(e => e.Trno).HasColumnName("TRNo");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.HasOne(d => d.Gr)
            //        .WithMany(p => p.CmblTemporaryReceiving)
            //        .HasForeignKey(d => d.Grid)
            //        .HasConstraintName("FK_CMBL_TemporaryReceiving_CMBL_GateReceiving");
            //});

            //modelBuilder.Entity<CmblTemporaryReceivingDetail>(entity =>
            //{
            //    entity.HasKey(e => e.Trdid)
            //        .HasName("PK_CMBL_TemporaryRecevingDetail");

            //    entity.ToTable("CMBL_TemporaryReceivingDetail");

            //    entity.Property(e => e.Trdid).HasColumnName("TRDID");

            //    entity.Property(e => e.ItemId).HasColumnName("ItemID");

            //    entity.Property(e => e.LocationId).HasColumnName("LocationID");

            //    entity.Property(e => e.Pobalance).HasColumnName("POBalance");

            //    entity.Property(e => e.PoitemId).HasColumnName("POItemID");

            //    entity.Property(e => e.StoreId).HasColumnName("StoreID");

            //    entity.Property(e => e.Trid).HasColumnName("TRID");

            //    entity.HasOne(d => d.Tr)
            //        .WithMany(p => p.CmblTemporaryReceivingDetail)
            //        .HasForeignKey(d => d.Trid)
            //        .HasConstraintName("FK_CMBL_TemporaryRecevingDetail_CMBL_TemporaryReceiving");
            //});

            //modelBuilder.Entity<CmblTemporaryTable>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMBL_TemporaryTable");

            //    entity.Property(e => e.F8).HasMaxLength(255);

            //    entity.Property(e => e.ItemDescription).HasMaxLength(255);

            //    entity.Property(e => e.ItemName).HasMaxLength(255);

            //    entity.Property(e => e.OBOf3May).HasColumnName("O#B of 3-May ");

            //    entity.Property(e => e.OBQuantity).HasColumnName("O-B Quantity");

            //    entity.Property(e => e.Unit).HasMaxLength(255);

            //    entity.Property(e => e.Unit1).HasMaxLength(255);
            //});

            //modelBuilder.Entity<CmblTemporaryTable1>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMBL_TemporaryTable1");

            //    entity.Property(e => e.ItemId).HasColumnName("ItemID");

            //    entity.Property(e => e.ItemTypeId).HasColumnName("ItemTypeID");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");
            //});

            //modelBuilder.Entity<CmblUnit>(entity =>
            //{
            //    entity.HasKey(e => e.UnitId);

            //    entity.ToTable("CMBL_Unit");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");

            //    entity.Property(e => e.CompanyId)
            //        .HasColumnName("CompanyID")
            //        .HasDefaultValueSql("(183)");

            //    entity.Property(e => e.UnitAbbreviation)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UnitDescription)
            //        .IsRequired()
            //        .HasMaxLength(100)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<CmblUserDepartment>(entity =>
            //{
            //    entity.HasKey(e => e.UserId);

            //    entity.ToTable("CMBL_UserDepartment");

            //    entity.Property(e => e.UserId)
            //        .HasColumnName("UserID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.CostCenterId).HasColumnName("CostCenterID");

            //    entity.Property(e => e.StoreId).HasColumnName("StoreID");

            //    entity.Property(e => e.UserName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<CmblUserLog>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("CMBL_UserLog");

            //    entity.Property(e => e.ActionDateTime).HasColumnType("datetime");

            //    entity.Property(e => e.DocId).HasColumnName("DocID");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.UserAction)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});


            //modelBuilder.Entity<ComboCombo>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Combo_Combo");

            //    entity.Property(e => e.ComboCode)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ComboId).HasColumnName("ComboID");
            //});

            //modelBuilder.Entity<ComboComboDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Combo_ComboDetail");

            //    entity.Property(e => e.ComboDetailCode)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ComboDetailId).HasColumnName("ComboDetailID");

            //    entity.Property(e => e.ComboId).HasColumnName("ComboID");
            //});

            //modelBuilder.Entity<ComboComboStyle>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Combo_ComboStyle");

            //    entity.Property(e => e.ComboDetailId).HasColumnName("ComboDetailID");

            //    entity.Property(e => e.ComboStyleCode)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<ComboCustomer>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Combo_Customer");

            //    entity.Property(e => e.CustomerCode)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            //});

            //modelBuilder.Entity<ComboResult>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Combo_Result");

            //    entity.Property(e => e.CartonId).HasColumnName("CartonID");

            //    entity.Property(e => e.ComboCode)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ComboDetailCode)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ComboDetailId).HasColumnName("ComboDetailID");

            //    entity.Property(e => e.ComboId).HasColumnName("ComboID");

            //    entity.Property(e => e.CustomerCode)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            //});

            //modelBuilder.Entity<CottonAttributesSetup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Cotton_Attributes_Setup");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.MrpattributeId).HasColumnName("MRPAttributeID");
            //});

            //modelBuilder.Entity<CottonBroadGroupAssociation>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Cotton_BroadGroupAssociation");

            //    entity.Property(e => e.BroadGroupId).HasColumnName("BroadGroupID");

            //    entity.Property(e => e.Date).HasColumnType("datetime");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<CottonContractItem>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Cotton_ContractItem");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.ContractId).HasColumnName("ContractID");

            //    entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Remarks)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.RequisitionDetailId).HasColumnName("RequisitionDetailID");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");
            //});

            //modelBuilder.Entity<CottonContractMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Cotton_ContractMaster");

            //    entity.Property(e => e.ApprovalDate).HasColumnType("datetime");

            //    entity.Property(e => e.ApprvAuthorityId).HasColumnName("ApprvAuthorityID");

            //    entity.Property(e => e.ContractId)
            //        .HasColumnName("ContractID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.ContractNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.MainComments)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PaymentMode)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PaymentTerm)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<CottonContractStatus>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Cotton_ContractStatus");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Status)
            //        .IsRequired()
            //        .HasMaxLength(20)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<CottonDocumentTypeSetup>(entity =>
            //{
            //    entity.ToTable("Cotton_DocumentTypeSetup");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.DocumentDescription)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DocumentName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<CottonGateReceiving>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Cotton_GateReceiving");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.ContractId).HasColumnName("ContractID");

            //    entity.Property(e => e.DeliveryChallanNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

            //    entity.Property(e => e.DeliveryPerson)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Grid)
            //        .HasColumnName("GRID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Grno)
            //        .IsRequired()
            //        .HasColumnName("GRNo")
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.Property(e => e.VehicleNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<CottonGateReceivingDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Cotton_GateReceivingDetail");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.Grdid)
            //        .HasColumnName("GRDID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Grid).HasColumnName("GRID");
            //});

            //modelBuilder.Entity<CottonGateReceivingSubDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Cotton_GateReceiving_SubDetail");

            //    entity.Property(e => e.Grdid).HasColumnName("GRDID");

            //    entity.Property(e => e.Grsdid)
            //        .HasColumnName("GRSDID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.LotNo)
            //        .IsRequired()
            //        .HasMaxLength(20)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<CottonInspectionQualityMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Cotton_InspectionQuality_Master");

            //    entity.Property(e => e.ContractId).HasColumnName("ContractID");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.InspectionQualityId)
            //        .HasColumnName("InspectionQualityID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.InspectionQualityNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.InspectionQuantityId).HasColumnName("InspectionQuantityID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<CottonInspectionQuantityMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Cotton_InspectionQuantity_Master");

            //    entity.Property(e => e.ContractId).HasColumnName("ContractID");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.InspectionQuantityId)
            //        .HasColumnName("InspectionQuantityID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.InspectionQuantityNo)
            //        .IsRequired()
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Trid).HasColumnName("TRID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<CottonIssuanceDetail>(entity =>
            //{
            //    entity.ToTable("Cotton_IssuanceDetail");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.CoaitemId).HasColumnName("COAItemID");

            //    entity.Property(e => e.IssuanceId).HasColumnName("IssuanceID");

            //    entity.Property(e => e.OperationId).HasColumnName("OperationID");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.HasOne(d => d.Issuance)
            //        .WithMany(p => p.CottonIssuanceDetail)
            //        .HasForeignKey(d => d.IssuanceId)
            //        .HasConstraintName("FK_Cotton_IssuanceDetail_Cotton_IssuanceMaster");
            //});

            //modelBuilder.Entity<CottonIssuanceMaster>(entity =>
            //{
            //    entity.ToTable("Cotton_IssuanceMaster");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.CreationDate)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.IssuanceDate).HasColumnType("datetime");

            //    entity.Property(e => e.IssuanceNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ReceivingPerson)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.RequisitionId).HasColumnName("RequisitionID");
            //});

            //modelBuilder.Entity<CottonIssuanceRequisitionApprovalStatusSetup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Cotton_IssuanceRequisitionApprovalStatus_Setup");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Id).HasColumnName("ID");
            //});

            //modelBuilder.Entity<CottonIssuanceRequisitionDetail>(entity =>
            //{
            //    entity.ToTable("Cotton_IssuanceRequisitionDetail");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.Irid).HasColumnName("IRID");

            //    entity.Property(e => e.Sfi).HasColumnName("SFI");

            //    entity.Property(e => e.Sl).HasColumnName("SL");

            //    entity.Property(e => e.Str).HasColumnName("STR");

            //    entity.Property(e => e.Ur).HasColumnName("UR");

            //    entity.HasOne(d => d.Ir)
            //        .WithMany(p => p.CottonIssuanceRequisitionDetail)
            //        .HasForeignKey(d => d.Irid)
            //        .HasConstraintName("FK_Cotton_IssuanceRequisitionDetail_Cotton_IssuanceRequisitionMaster");
            //});

            //modelBuilder.Entity<CottonIssuanceRequisitionMaster>(entity =>
            //{
            //    entity.ToTable("Cotton_IssuanceRequisitionMaster");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.CreationDate)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.IssReqNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ReqDate)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Status).HasDefaultValueSql("(1)");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<CottonItemProperties>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Cotton_ItemProperties");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.ItemName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Sku).HasColumnName("SKU");
            //});

            //modelBuilder.Entity<CottonItemRequisitionMaster>(entity =>
            //{
            //    entity.HasKey(e => e.Irid)
            //        .HasName("PK_Cotton_ItemRequisitionMaster");

            //    entity.ToTable("Cotton_ItemRequisition_Master");

            //    entity.Property(e => e.Irid).HasColumnName("IRID");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.CreatorComments)
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Ircode)
            //        .HasColumnName("IRCode")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Status)
            //        .IsRequired()
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.UserId)
            //        .HasColumnName("UserID")
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .IsFixedLength();
            //});

            //modelBuilder.Entity<CottonItemRequisitionRequirement>(entity =>
            //{
            //    entity.HasKey(e => e.Irrid);

            //    entity.ToTable("Cotton_ItemRequisition_Requirement");

            //    entity.Property(e => e.Irrid).HasColumnName("IRRID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.Irid).HasColumnName("IRID");

            //    entity.Property(e => e.ReqDate).HasColumnType("datetime");

            //    entity.Property(e => e.UserSelectedUnitId).HasColumnName("UserSelectedUnitID");
            //});

            //modelBuilder.Entity<CottonOpeningBalanceMaster>(entity =>
            //{
            //    entity.HasKey(e => e.Obid);

            //    entity.ToTable("Cotton_OpeningBalance_Master");

            //    entity.Property(e => e.Obid).HasColumnName("OBID");

            //    entity.Property(e => e.Obdate)
            //        .HasColumnName("OBDate")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.Obno)
            //        .HasColumnName("OBNo")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PocontractNo)
            //        .HasColumnName("POContractNo")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<CottonPermanentReceivingMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Cotton_PermanentReceiving_Master");

            //    entity.Property(e => e.ContractId).HasColumnName("ContractID");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.InspectionQualityId).HasColumnName("InspectionQualityID");

            //    entity.Property(e => e.PermRecId)
            //        .HasColumnName("PermRecID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<CottonStockTransactions>(entity =>
            //{
            //    entity.HasKey(e => e.StockTransactionId);

            //    entity.ToTable("Cotton_StockTransactions");

            //    entity.Property(e => e.StockTransactionId).HasColumnName("StockTransactionID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.BaleNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.LotNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.RateWrtbaseUnit).HasColumnName("Rate_WRTBaseUnit");

            //    entity.Property(e => e.Sfi).HasColumnName("SFI");

            //    entity.Property(e => e.Skuunit).HasColumnName("SKUUnit");

            //    entity.Property(e => e.Sl).HasColumnName("SL");

            //    entity.Property(e => e.StoreLocationId).HasColumnName("StoreLocationID");

            //    entity.Property(e => e.Str).HasColumnName("STR");

            //    entity.Property(e => e.TransactionDate).HasColumnType("datetime");

            //    entity.Property(e => e.Ur).HasColumnName("UR");
            //});

            //modelBuilder.Entity<CottonSubDomain>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Cotton_SubDomain");

            //    entity.Property(e => e.DomainId).HasColumnName("DomainID");

            //    entity.Property(e => e.SubDomainDescription)
            //        .IsRequired()
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SubDomainId).HasColumnName("SubDomainID");
            //});

            //modelBuilder.Entity<CottonSubDomainLinks>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Cotton_SubDomain_Links");

            //    entity.Property(e => e.LinkDescription)
            //        .IsRequired()
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SubDomainId).HasColumnName("SubDomainID");

            //    entity.Property(e => e.Url)
            //        .IsRequired()
            //        .HasColumnName("URL")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<CottonSupplierAssociation>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Cotton_SupplierAssociation");

            //    entity.Property(e => e.AssociationDate).HasColumnType("datetime");

            //    entity.Property(e => e.IdentificationId).HasColumnName("IdentificationID");

            //    entity.Property(e => e.SupplierAssociationId)
            //        .HasColumnName("SupplierAssociationID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<CottonTemporaryReceiving>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Cotton_TemporaryReceiving");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.ContractId).HasColumnName("ContractID");

            //    entity.Property(e => e.Grid).HasColumnName("GRID");

            //    entity.Property(e => e.TempRecDate).HasColumnType("datetime");

            //    entity.Property(e => e.Trid)
            //        .HasColumnName("TRID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Trno)
            //        .IsRequired()
            //        .HasColumnName("TRNo")
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<CottonTemporaryReceivingDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Cotton_TemporaryReceivingDetail");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.ContractDetId).HasColumnName("ContractDetID");

            //    entity.Property(e => e.LocationId).HasColumnName("LocationID");

            //    entity.Property(e => e.StoreId).HasColumnName("StoreID");

            //    entity.Property(e => e.Trdid)
            //        .HasColumnName("TRDID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Trid).HasColumnName("TRID");
            //});

            //modelBuilder.Entity<DailyTimeBuckets>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.Property(e => e.DayDate).HasColumnType("datetime");

            //    entity.Property(e => e.DayId).HasColumnName("DayID");

            //    entity.Property(e => e.WeekId).HasColumnName("WeekID");
            //});

            //modelBuilder.Entity<DdLotSizeInventory>(entity =>
            //{
            //    entity.ToTable("DD_LotSize_Inventory");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.LsmasterId).HasColumnName("LSMasterID");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");

            //    entity.HasOne(d => d.Lsmaster)
            //        .WithMany(p => p.DdLotSizeInventory)
            //        .HasForeignKey(d => d.LsmasterId)
            //        .HasConstraintName("FK_DD_LotSize_Inventory_DD_LotSize_Master");
            //});

            //modelBuilder.Entity<DdLotSizeIssuance>(entity =>
            //{
            //    entity.ToTable("DD_LotSize_Issuance");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.LsmasterId).HasColumnName("LSMasterID");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");

            //    entity.HasOne(d => d.Lsmaster)
            //        .WithMany(p => p.DdLotSizeIssuance)
            //        .HasForeignKey(d => d.LsmasterId)
            //        .HasConstraintName("FK_DD_LotSize_Issuance_DD_LotSize_Master1");
            //});

            //modelBuilder.Entity<DdLotSizeMaster>(entity =>
            //{
            //    entity.ToTable("DD_LotSize_Master");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");
            //});

            //modelBuilder.Entity<DdLotSizePurchase>(entity =>
            //{
            //    entity.ToTable("DD_LotSize_Purchase");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.LsmasterId).HasColumnName("LSMasterID");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");

            //    entity.HasOne(d => d.Lsmaster)
            //        .WithMany(p => p.DdLotSizePurchase)
            //        .HasForeignKey(d => d.LsmasterId)
            //        .HasConstraintName("FK_DD_LotSize_Purchase_DD_LotSize_Master");
            //});

            //modelBuilder.Entity<DdLotSizeSales>(entity =>
            //{
            //    entity.ToTable("DD_LotSize_Sales");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.LsmasterId).HasColumnName("LSMasterID");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");

            //    entity.HasOne(d => d.Lsmaster)
            //        .WithMany(p => p.DdLotSizeSales)
            //        .HasForeignKey(d => d.LsmasterId)
            //        .HasConstraintName("FK_DD_LotSize_Sales_DD_LotSize_Master");
            //});

            //modelBuilder.Entity<DdPoLog>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("DD_PO_Log");

            //    entity.Property(e => e.CommentDate)
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CreationDate)
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.Poid).HasColumnName("POID");

            //    entity.Property(e => e.Pono)
            //        .HasColumnName("PONO")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<DdPoinstructions>(entity =>
            //{
            //    entity.ToTable("DD_POInstructions");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Instruction)
            //        .IsRequired()
            //        .HasMaxLength(200);

            //    entity.Property(e => e.PurchaseOrderId).HasColumnName("PurchaseOrderID");

            //    entity.HasOne(d => d.PurchaseOrder)
            //        .WithMany(p => p.DdPoinstructions)
            //        .HasForeignKey(d => d.PurchaseOrderId)
            //        .HasConstraintName("FK_DD_POInstructions_DD_PurchaseOrder");
            //});

            //modelBuilder.Entity<DdPoitemDetails>(entity =>
            //{
            //    entity.ToTable("DD_POItemDetails");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");

            //    entity.Property(e => e.DeliveryDate)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.DeliveryPointId).HasColumnName("DeliveryPointID");

            //    entity.Property(e => e.PoitemMasterId).HasColumnName("POItemMasterID");

            //    entity.Property(e => e.Remarks).HasMaxLength(50);

            //    entity.HasOne(d => d.PoitemMaster)
            //        .WithMany(p => p.DdPoitemDetails)
            //        .HasForeignKey(d => d.PoitemMasterId)
            //        .HasConstraintName("FK_DD_POItemDetails_DD_POItemMaster");
            //});

            //modelBuilder.Entity<DdPoitemMaster>(entity =>
            //{
            //    entity.ToTable("DD_POItemMaster");

            //    entity.HasIndex(e => new { e.OrderId, e.ModelId })
            //        .HasName("IndexOrderId");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.IsMrpbased).HasColumnName("IsMRPBased");

            //    entity.Property(e => e.ModelId).HasColumnName("ModelID");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.ObjectId).HasColumnName("ObjectID");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.PurchaseOrderId).HasColumnName("PurchaseOrderID");

            //    entity.Property(e => e.RequisitionId).HasColumnName("RequisitionID");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");

            //    entity.HasOne(d => d.PurchaseOrder)
            //        .WithMany(p => p.DdPoitemMaster)
            //        .HasForeignKey(d => d.PurchaseOrderId)
            //        .HasConstraintName("FK_DD_POItemDetails_DD_PurchaseOrder");
            //});

            //modelBuilder.Entity<DdPostatusChangeHistory>(entity =>
            //{
            //    entity.ToTable("DD_POStatusChangeHistory");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Comments).HasMaxLength(50);

            //    entity.Property(e => e.Date).HasColumnType("datetime");

            //    entity.Property(e => e.DispatchDate).HasColumnType("datetime");

            //    entity.Property(e => e.DispatchTo).HasMaxLength(50);

            //    entity.Property(e => e.DispatchTypeId).HasColumnName("DispatchTypeID");

            //    entity.Property(e => e.PurchaseOrderId).HasColumnName("PurchaseOrderID");

            //    entity.Property(e => e.ReasonId).HasColumnName("ReasonID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.HasOne(d => d.PurchaseOrder)
            //        .WithMany(p => p.DdPostatusChangeHistory)
            //        .HasForeignKey(d => d.PurchaseOrderId)
            //        .HasConstraintName("FK_DD_POStatusChangeHistory_DD_PurchaseOrder");
            //});

            //modelBuilder.Entity<DdPostatusSetup>(entity =>
            //{
            //    entity.ToTable("DD_POStatus_Setup");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.UsedFor).HasMaxLength(100);
            //});

            //modelBuilder.Entity<DdProfilesSetup>(entity =>
            //{
            //    entity.ToTable("DD_Profiles_Setup");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(20);
            //});

            //modelBuilder.Entity<DdPurchaseOrder>(entity =>
            //{
            //    entity.ToTable("DD_PurchaseOrder");

            //    entity.HasIndex(e => new { e.PurchaseOrderNo, e.Id })
            //        .HasName("_dta_index_DD_PurchaseOrder_9_1409544205__K1_2");

            //    entity.HasIndex(e => new { e.LcmId, e.Id, e.SupplierId })
            //        .HasName("Ind_dd_PurchaseOrder");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.AdvancePercentage).HasColumnName("advance_percentage");

            //    entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.ContactPersonId).HasColumnName("ContactPersonID");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.IsIndReq).HasDefaultValueSql("((0))");

            //    entity.Property(e => e.LcmId).HasColumnName("LCM_ID");

            //    entity.Property(e => e.OriginalPoid).HasColumnName("OriginalPOID");

            //    entity.Property(e => e.ParentPoid).HasColumnName("ParentPOID");

            //    entity.Property(e => e.PaymentMode)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PaymentSubTerm)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PaymentTerm)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PurchaseOrderNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.RevisionReasonId).HasColumnName("RevisionReasonID");

            //    entity.Property(e => e.SigningAuthorityId).HasColumnName("SigningAuthorityID");

            //    entity.Property(e => e.SpecialComments)
            //        .HasMaxLength(1000)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.HasOne(d => d.StatusNavigation)
            //        .WithMany(p => p.DdPurchaseOrder)
            //        .HasForeignKey(d => d.Status)
            //        .OnDelete(DeleteBehavior.Cascade)
            //        .HasConstraintName("FK_DD_PurchaseOrder_DD_POStatus_Setup");
            //});

            //modelBuilder.Entity<DdblockedSupplier>(entity =>
            //{
            //    entity.ToTable("DDBlockedSupplier");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.BlockDate).HasColumnType("datetime");

            //    entity.Property(e => e.BlockReasonId).HasColumnName("BlockReasonID");

            //    entity.Property(e => e.Remarks).HasMaxLength(200);

            //    entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

            //    entity.Property(e => e.UnblockReasonId).HasColumnName("UnblockReasonID");

            //    entity.HasOne(d => d.BlockReason)
            //        .WithMany(p => p.DdblockedSupplier)
            //        .HasForeignKey(d => d.BlockReasonId)
            //        .HasConstraintName("FK_DDBlockedSupplier_DDReasons_Setup");

            //    entity.HasOne(d => d.Supplier)
            //        .WithMany(p => p.DdblockedSupplier)
            //        .HasForeignKey(d => d.SupplierId)
            //        .HasConstraintName("FK_DDBlockedSupplier_DDSupplier");
            //});

            //modelBuilder.Entity<DddeliveryPointSetup>(entity =>
            //{
            //    entity.ToTable("DDDeliveryPoint_Setup");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DomainId).HasColumnName("DomainID");
            //});

            //modelBuilder.Entity<DddispatchTypeSetup>(entity =>
            //{
            //    entity.ToTable("DDDispatchType_Setup");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<DditemCatagorySetup>(entity =>
            //{
            //    entity.ToTable("DDItemCatagory_Setup");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(100)
            //        .IsFixedLength();

            //    entity.Property(e => e.IsMrp).HasColumnName("IsMRP");
            //});

            //modelBuilder.Entity<DdmrpitemSetup>(entity =>
            //{
            //    entity.ToTable("DDMRPItem_Setup");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.ItemCatagoryId).HasColumnName("ItemCatagoryID");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");
            //});

            //modelBuilder.Entity<DdnonmrpitemSetup>(entity =>
            //{
            //    entity.ToTable("DDNONMRPItem_Setup");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.MrpitemTypeId).HasColumnName("MRPItemTypeID");

            //    entity.HasOne(d => d.MrpitemType)
            //        .WithMany(p => p.DdnonmrpitemSetup)
            //        .HasForeignKey(d => d.MrpitemTypeId)
            //        .HasConstraintName("FK_DDNONMRPItem_Setup_DDNONMRPItemType");
            //});

            //modelBuilder.Entity<DdnonmrpitemTypeSetup>(entity =>
            //{
            //    entity.ToTable("DDNONMRPItemType_Setup");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ItemCatagoryId).HasColumnName("ItemCatagoryID");
            //});

            //modelBuilder.Entity<DdreasonTypeSetup>(entity =>
            //{
            //    entity.ToTable("DDReasonType_Setup");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50);
            //});



            //modelBuilder.Entity<DdreasonsSetup>(entity =>
            //{
            //    entity.ToTable("DDReasons_Setup");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Reason)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.ReasonTypeId).HasColumnName("ReasonTypeID");

            //    entity.HasOne(d => d.ReasonType)
            //        .WithMany(p => p.DdreasonsSetup)
            //        .HasForeignKey(d => d.ReasonTypeId)
            //        .HasConstraintName("FK_DDBlockReasons_Setup_DDBlockingType_Setup");
            //});

            //modelBuilder.Entity<DdsigningAuthoritySetup>(entity =>
            //{
            //    entity.ToTable("DDSigningAuthority_Setup");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.Designation)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.IsDefault)
            //        .IsRequired()
            //        .HasDefaultValueSql("(0)");
            //});

            //modelBuilder.Entity<Ddsupplier>(entity =>
            //{
            //    entity.ToTable("DDSupplier");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Address)
            //        .IsRequired()
            //        .HasMaxLength(200);

            //    entity.Property(e => e.ContactEmail1).HasMaxLength(30);

            //    entity.Property(e => e.ContactEmail2).HasMaxLength(30);

            //    entity.Property(e => e.ContactMobile1)
            //        .IsRequired()
            //        .HasMaxLength(12)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.ContactMobile2)
            //        .HasMaxLength(12)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.ContactName1)
            //        .IsRequired()
            //        .HasMaxLength(20)
            //        .IsFixedLength();

            //    entity.Property(e => e.ContactName2)
            //        .HasMaxLength(20)
            //        .IsFixedLength();

            //    entity.Property(e => e.ContactPhone1)
            //        .HasMaxLength(11)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.ContactPhone2)
            //        .HasMaxLength(11)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.ContactRemarks1).HasMaxLength(200);

            //    entity.Property(e => e.ContactRemarks2).HasMaxLength(200);

            //    entity.Property(e => e.Designation1)
            //        .IsRequired()
            //        .HasMaxLength(20);

            //    entity.Property(e => e.Designation2).HasMaxLength(20);

            //    entity.Property(e => e.Email).HasMaxLength(30);

            //    entity.Property(e => e.Fax)
            //        .HasMaxLength(11)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Ntn)
            //        .IsRequired()
            //        .HasColumnName("NTN")
            //        .HasMaxLength(10);

            //    entity.Property(e => e.Phone1)
            //        .IsRequired()
            //        .HasMaxLength(11)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Phone2)
            //        .HasMaxLength(11)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Remarks).HasMaxLength(200);

            //    entity.Property(e => e.SupplierName)
            //        .IsRequired()
            //        .HasMaxLength(50);
            //});

            //modelBuilder.Entity<DdsupplierDomain>(entity =>
            //{
            //    entity.ToTable("DDSupplierDomain");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ItemCatagoryId).HasColumnName("ItemCatagoryID");

            //    entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

            //    entity.HasOne(d => d.ItemCatagory)
            //        .WithMany(p => p.DdsupplierDomain)
            //        .HasForeignKey(d => d.ItemCatagoryId)
            //        .HasConstraintName("FK_DDSupplierDomain_DDItemCatagory_Setup");

            //    entity.HasOne(d => d.Supplier)
            //        .WithMany(p => p.DdsupplierDomain)
            //        .HasForeignKey(d => d.SupplierId)
            //        .HasConstraintName("FK_DDSupplierDomain_DDSupplier");
            //});

            //modelBuilder.Entity<DdsupplierItem>(entity =>
            //{
            //    entity.ToTable("DDSupplierItem");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.IsMrp)
            //        .HasColumnName("IsMRP")
            //        .HasComment("1 for yes 0 for No");

            //    entity.Property(e => e.ItemId).HasColumnName("ItemID");

            //    entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");

            //    entity.HasOne(d => d.Supplier)
            //        .WithMany(p => p.DdsupplierItem)
            //        .HasForeignKey(d => d.SupplierId)
            //        .HasConstraintName("FK_DDSupplierItem_DDSupplier");

            //    entity.HasOne(d => d.Unit)
            //        .WithMany(p => p.DdsupplierItem)
            //        .HasForeignKey(d => d.UnitId)
            //        .OnDelete(DeleteBehavior.Cascade)
            //        .HasConstraintName("FK_DDSupplierItem_DDUnit_Setup");
            //});

            //modelBuilder.Entity<DdunitSetup>(entity =>
            //{
            //    entity.ToTable("DDUnit_Setup");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50);
            //});

            //modelBuilder.Entity<DduserProfiles>(entity =>
            //{
            //    entity.ToTable("DDUserProfiles");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ProfileId).HasColumnName("ProfileID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<Debug>(entity =>
            //{
            //    entity.HasKey(e => e.Did);

            //    entity.ToTable("debug");

            //    entity.Property(e => e.Did).HasColumnName("DID");

            //    entity.Property(e => e.Date)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Sp)
            //        .HasColumnName("SP")
            //        .HasMaxLength(500)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Xml)
            //        .HasColumnName("XML")
            //        .HasColumnType("xml");
            //});

            //modelBuilder.Entity<Dummy>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.Property(e => e.Pono)
            //        .HasColumnName("PONo")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<Dummytable>(entity =>
            //{
            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Date)
            //        .HasColumnName("date")
            //        .HasColumnType("datetime");
            //});

            //modelBuilder.Entity<DyedCuttingInspectionDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Dyed_CuttingInspectionDetail");

            //    entity.Property(e => e.Ciid).HasColumnName("CIID");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.QualityAttributeId).HasColumnName("QualityAttributeID");

            //    entity.Property(e => e.QualityAttributeValue)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.RollNo)
            //        .HasMaxLength(30)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<DyedCuttingInspectionMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Dyed_CuttingInspectionMaster");

            //    entity.Property(e => e.Ciid)
            //        .HasColumnName("CIID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Cinsno)
            //        .IsRequired()
            //        .HasColumnName("CINSNO")
            //        .HasMaxLength(30)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Crnstatus).HasColumnName("CRNStatus");

            //    entity.Property(e => e.CuttingId).HasColumnName("CuttingID");

            //    entity.Property(e => e.InspectionDate).HasColumnType("datetime");
            //});

            //modelBuilder.Entity<DyedCuttingIssuanceMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Dyed_CuttingIssuanceMaster");

            //    entity.Property(e => e.IssuanceDate).HasColumnType("datetime");

            //    entity.Property(e => e.IssuanceId)
            //        .HasColumnName("IssuanceID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.IssuanceNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<DyedCuttingPermanentReceivingDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Dyed_CuttingPermanentReceivingDetail");

            //    entity.Property(e => e.DetailId)
            //        .HasColumnName("DetailID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Fid).HasColumnName("FID");

            //    entity.Property(e => e.PermRecId).HasColumnName("PermRecID");
            //});

            //modelBuilder.Entity<DyedCuttingPermanentReceivingMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Dyed_CuttingPermanentReceivingMaster");

            //    entity.Property(e => e.Ciid).HasColumnName("CIID");

            //    entity.Property(e => e.PermRecDate).HasColumnType("datetime");

            //    entity.Property(e => e.PermRecId)
            //        .HasColumnName("PermRecID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.PermRecNo)
            //        .IsRequired()
            //        .HasMaxLength(30)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<DyedCuttingPermanentReceivingSubDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Dyed_CuttingPermanentReceivingSubDetail");

            //    entity.Property(e => e.DetailId).HasColumnName("DetailID");

            //    entity.Property(e => e.RollId).HasColumnName("RollID");

            //    entity.Property(e => e.RollNo)
            //        .IsRequired()
            //        .HasMaxLength(30)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SubDetailId)
            //        .HasColumnName("SubDetailID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<DyedCuttingReceivingMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Dyed_CuttingReceivingMaster");

            //    entity.Property(e => e.CuttingId)
            //        .HasColumnName("CuttingID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.CuttingNo)
            //        .IsRequired()
            //        .HasMaxLength(30)
            //        .IsUnicode(false);

            //    entity.Property(e => e.IssuanceId).HasColumnName("IssuanceID");

            //    entity.Property(e => e.RecDate).HasColumnType("datetime");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<DyedCuttingRff>(entity =>
            //{
            //    entity.ToTable("Dyed_CuttingRFF");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.DocumentDate).HasColumnType("datetime");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<DyedDocumentTypeSetup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Dyed_DocumentType_Setup");

            //    entity.Property(e => e.DocumentDescription)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DocumentName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.StoreId).HasColumnName("StoreID");
            //});

            //modelBuilder.Entity<DyedFabricStockMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Dyed_FabricStockMaster");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.StockId)
            //        .HasColumnName("StockID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<DyedFrsagainstDyedAttributeInstanceId>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Dyed_FRSAgainstDyedAttributeInstanceID");

            //    entity.Property(e => e.DyedAttributeInstanceId).HasColumnName("DyedAttributeInstanceID");

            //    entity.Property(e => e.FrsattributeInstanceId).HasColumnName("FRSAttributeInstanceID");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<DyedFrsagainstRollAssignmentTransactions>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Dyed_FRSAgainstRollAssignmentTransactions");

            //    entity.Property(e => e.DyedStockId).HasColumnName("DyedStockID");

            //    entity.Property(e => e.Fid).HasColumnName("FID");

            //    entity.Property(e => e.TransactionDate).HasColumnType("datetime");

            //    entity.Property(e => e.TransactionId)
            //        .HasColumnName("TransactionID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<DyedGateReceivingDetail>(entity =>
            //{
            //    entity.ToTable("Dyed_GateReceivingDetail");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.Grid).HasColumnName("GRID");

            //    entity.Property(e => e.LotNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.HasOne(d => d.Gr)
            //        .WithMany(p => p.DyedGateReceivingDetail)
            //        .HasForeignKey(d => d.Grid)
            //        .HasConstraintName("FK_Dyed_GateReceivingDetail_Dyed_GateReceivingMaster");
            //});

            //modelBuilder.Entity<DyedGateReceivingMaster>(entity =>
            //{
            //    entity.HasKey(e => e.Grid);

            //    entity.ToTable("Dyed_GateReceivingMaster");

            //    entity.Property(e => e.Grid).HasColumnName("GRID");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.DeliveryChallan)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

            //    entity.Property(e => e.DeliveryPerson)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Grno)
            //        .IsRequired()
            //        .HasColumnName("GRNo")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Poid).HasColumnName("POID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.Property(e => e.VehicleNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<DyedInspectionDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Dyed_InspectionDetail");

            //    entity.Property(e => e.Diid).HasColumnName("DIID");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.QualityAttributeId).HasColumnName("QualityAttributeID");

            //    entity.Property(e => e.QualityAttributeValue)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.RollNo)
            //        .HasMaxLength(20)
            //        .IsUnicode(false);
            //});

            modelBuilder.Entity<Dyed_InspectionMaster>(entity =>
            {
                entity.Property(e => e.Comments)
                    .HasColumnName("comments")
                    .HasMaxLength(500)
                    .IsUnicode(false);


                entity.Property(e => e.UserID)
                      .HasColumnName("userID");
            });

            //modelBuilder.Entity<DyedInterOrderTransferMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Dyed_InterOrderTransferMaster");

            //    entity.Property(e => e.Iotdate)
            //        .HasColumnName("IOTDate")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.Iotid)
            //        .HasColumnName("IOTID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Iotno)
            //        .IsRequired()
            //        .HasColumnName("IOTNo")
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<DyedIssuanceDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Dyed_IssuanceDetail");

            //    entity.HasIndex(e => e.RollId)
            //        .HasName("NonClusteredIndex-20180104-191407");

            //    entity.Property(e => e.AssignmentId).HasColumnName("AssignmentID");

            //    entity.Property(e => e.DyedAttributeInstanceId).HasColumnName("DyedAttributeInstanceID");

            //    entity.Property(e => e.Fid).HasColumnName("FID");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.IssuanceId).HasColumnName("IssuanceID");

            //    entity.Property(e => e.RollId).HasColumnName("RollID");

            //    entity.Property(e => e.RollNo)
            //        .IsRequired()
            //        .HasMaxLength(30)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<DyedIssuanceMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Dyed_IssuanceMaster");

            //    entity.Property(e => e.IssuanceDate).HasColumnType("datetime");

            //    entity.Property(e => e.IssuanceId)
            //        .HasColumnName("IssuanceID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.IssuanceNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.IssuancePerson)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<DyedPermanentReceivingMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Dyed_PermanentReceivingMaster");

            //    entity.Property(e => e.Dcid).HasColumnName("DCID");

            //    entity.Property(e => e.Diid).HasColumnName("DIID");

            //    entity.Property(e => e.PermRecDate).HasColumnType("datetime");

            //    entity.Property(e => e.PermRecId)
            //        .HasColumnName("PermRecID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.PermRecNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<DyedPostatusSetup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Dyed_POStatus_Setup");

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Id).HasColumnName("ID");
            //});

            //modelBuilder.Entity<DyedPurchaseOrderDeliverySchedule>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Dyed_PurchaseOrderDeliverySchedule");

            //    entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

            //    entity.Property(e => e.DeliveryLocationId).HasColumnName("DeliveryLocationID");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Poid).HasColumnName("POID");
            //});

            //modelBuilder.Entity<DyedPurchaseOrderDetail>(entity =>
            //{
            //    entity.ToTable("Dyed_PurchaseOrderDetail");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.DeliveryDate).HasMaxLength(50);

            //    entity.Property(e => e.DeliveryPointId).HasColumnName("DeliveryPointID");

            //    entity.Property(e => e.FinishingCodeId).HasColumnName("FinishingCodeID");

            //    entity.Property(e => e.MatchingSourceId).HasColumnName("MatchingSourceID");

            //    entity.Property(e => e.ModelId).HasColumnName("ModelID");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.PantoneNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Poid).HasColumnName("POID");

            //    entity.Property(e => e.Remarks).HasMaxLength(50);

            //    entity.Property(e => e.ReqSheetId).HasColumnName("ReqSheetID");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");

            //    entity.HasOne(d => d.Po)
            //        .WithMany(p => p.DyedPurchaseOrderDetail)
            //        .HasForeignKey(d => d.Poid)
            //        .HasConstraintName("FK_Dyed_PurchaseOrderDetail_Dyed_PurchaseOrderMaster");
            //});

            //modelBuilder.Entity<DyedPurchaseOrderFabrics>(entity =>
            //{
            //    entity.ToTable("Dyed_PurchaseOrderFabrics");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.FinishingCodeId).HasColumnName("FinishingCodeID");

            //    entity.Property(e => e.MatchingSourceId).HasColumnName("MatchingSourceID");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.PantoneNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Poid).HasColumnName("POID");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");

            //    entity.HasOne(d => d.Po)
            //        .WithMany(p => p.DyedPurchaseOrderFabrics)
            //        .HasForeignKey(d => d.Poid)
            //        .HasConstraintName("FK_Dyed_PurchaseOrderFabrics_Dyed_PurchaseOrderMaster");
            //});

            //modelBuilder.Entity<DyedPurchaseOrderMaster>(entity =>
            //{
            //    entity.ToTable("Dyed_PurchaseOrderMaster");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.PaymentMode)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PaymentSubTerm)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PaymentTerm)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Pono)
            //        .HasColumnName("PONo")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SigningAuthorityId).HasColumnName("SigningAuthorityID");

            //    entity.Property(e => e.SpecialComments)
            //        .HasMaxLength(1000)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<DyedRecievingTypeInput>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Dyed_RecievingType_Input");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.TypeId).HasColumnName("TypeID");
            //});

            //modelBuilder.Entity<DyedRejectionSetup>(entity =>
            //{
            //    entity.ToTable("Dyed_Rejection_Setup");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<DyedRollAssignmentMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Dyed_RollAssignmentMaster");

            //    entity.Property(e => e.AssignmentDate).HasColumnType("datetime");

            //    entity.Property(e => e.AssignmentId)
            //        .HasColumnName("AssignmentID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.AssignmentNo)
            //        .IsRequired()
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(800)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<DyedStockAdjustmentMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Dyed_StockAdjustmentMaster");

            //    entity.Property(e => e.Sadate)
            //        .HasColumnName("SADate")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.Said)
            //        .HasColumnName("SAID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Sano)
            //        .IsRequired()
            //        .HasColumnName("SANo")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<DyedStockRolls>(entity =>
            //{
            //    entity.ToTable("Dyed_StockRolls");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.RollNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<DyedStockTransactions>(entity =>
            //{
            //    entity.HasKey(e => e.StockTransactionId);

            //    entity.ToTable("Dyed_StockTransactions");

            //    entity.HasIndex(e => new { e.DocumentTypeId, e.DyeingContractId, e.DyeingLotId })
            //        .HasName("IND_Dyed_Stocktransaction_1");

            //    entity.Property(e => e.StockTransactionId).HasColumnName("StockTransactionID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CuttingDetailId).HasColumnName("CuttingDetailID");

            //    entity.Property(e => e.DocumentDate).HasColumnType("datetime");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.DyedRollNo)
            //        .IsRequired()
            //        .HasMaxLength(30)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DyeingContractId).HasColumnName("DyeingContractID");

            //    entity.Property(e => e.DyeingLotId).HasColumnName("DyeingLotID");

            //    entity.Property(e => e.DyeingLotNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Fid).HasColumnName("fid");

            //    entity.Property(e => e.GreigeRollId).HasColumnName("GreigeRollID");

            //    entity.Property(e => e.IsShortFall).HasDefaultValueSql("((0))");

            //    entity.Property(e => e.ModelId).HasColumnName("ModelID");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.ProgramTypeId).HasColumnName("ProgramTypeID");

            //    entity.Property(e => e.Quantity).HasColumnType("decimal(20, 4)");

            //    entity.Property(e => e.ReceivedGsm).HasColumnName("ReceivedGSM");

            //    entity.Property(e => e.Rollnonew)
            //        .HasColumnName("rollnonew")
            //        .HasMaxLength(30)
            //        .IsUnicode(false);

            //    entity.Property(e => e.RotaryCode)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Skurate).HasColumnName("SKURate");

            //    entity.Property(e => e.Skuunit).HasColumnName("SKUUnit");

            //    entity.Property(e => e.Status).HasDefaultValueSql("((1))");

            //    entity.Property(e => e.StoreLocationId).HasColumnName("StoreLocationID");
            //});

            //modelBuilder.Entity<DyedTemporaryReceivingMaster>(entity =>
            //{
            //    entity.HasKey(e => e.Dtrid);

            //    entity.ToTable("Dyed_TemporaryReceivingMaster");

            //    entity.Property(e => e.Dtrid).HasColumnName("DTRID");

            //    entity.Property(e => e.Dcid).HasColumnName("DCID");

            //    entity.Property(e => e.Grid).HasColumnName("GRID");

            //    entity.Property(e => e.IsDependent).HasColumnName("isDependent");

            //    entity.Property(e => e.IsPo).HasColumnName("IsPO");

            //    entity.Property(e => e.PantoneNo)
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.TempRecDate).HasColumnType("datetime");

            //    entity.Property(e => e.Tgrno)
            //        .HasColumnName("TGRNo")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<ExpPackingList>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Exp_PackingList");

            //    entity.Property(e => e.Color)
            //        .IsRequired()
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ContainerNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CustomerCode)
            //        .IsRequired()
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DestinationCode)
            //        .IsRequired()
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.InvoiceNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OrderDelivery)
            //        .IsRequired()
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OrderNo)
            //        .IsRequired()
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Size)
            //        .IsRequired()
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Style)
            //        .IsRequired()
            //        .HasMaxLength(20)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<FabricColor>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Ykncid).HasColumnName("YKNCID");
            //});

            //modelBuilder.Entity<Fimmassociation>(entity =>
            //{
            //    entity.ToTable("FIMMAssociation");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.ValuationClassId).HasColumnName("ValuationClassID");
            //});

            //modelBuilder.Entity<GreigeDocumentTypeSetup>(entity =>
            //{
            //    entity.ToTable("Greige_DocumentTypeSetup");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.DocumentDescription)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DocumentName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.IsSearchCriteria).HasDefaultValueSql("(0)");
            //});

            //modelBuilder.Entity<GreigeDyeingContractDeliverySchedule>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Greige_DyeingContractDeliverySchedule");

            //    entity.Property(e => e.Dcid).HasColumnName("DCID");

            //    entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

            //    entity.Property(e => e.DeliveryLocationId).HasColumnName("DeliveryLocationID");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<GreigeDyeingContractDeliveryScheduleDel>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Greige_DyeingContractDeliverySchedule_Del");

            //    entity.Property(e => e.Dcid).HasColumnName("DCID");

            //    entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

            //    entity.Property(e => e.DeliveryLocationId).HasColumnName("DeliveryLocationID");

            //    entity.Property(e => e.Id).HasColumnName("ID");
            //});

            //modelBuilder.Entity<GreigeDyeingContractDetail>(entity =>
            //{
            //    entity.ToTable("Greige_DyeingContractDetail");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.ContractId).HasColumnName("ContractID");

            //    entity.Property(e => e.DeliveryDate).HasMaxLength(50);

            //    entity.Property(e => e.DeliveryPointId).HasColumnName("DeliveryPointID");

            //    entity.Property(e => e.FinishingCodeId).HasColumnName("FinishingCodeID");

            //    entity.Property(e => e.GreigeAttributeInstanceId).HasColumnName("GreigeAttributeInstanceID");

            //    entity.Property(e => e.MatchingSourceId).HasColumnName("MatchingSourceID");

            //    entity.Property(e => e.ModelId).HasColumnName("ModelID");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.PantoneId).HasColumnName("PantoneID");

            //    entity.Property(e => e.PantoneNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ProgramTypeId).HasColumnName("ProgramTypeID");

            //    entity.Property(e => e.Remarks).HasMaxLength(50);

            //    entity.Property(e => e.ReqSheetId).HasColumnName("ReqSheetID");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");

            //    entity.Property(e => e.Week).HasColumnName("week");

            //    entity.Property(e => e.Year).HasColumnName("year");

            //    entity.HasOne(d => d.Contract)
            //        .WithMany(p => p.GreigeDyeingContractDetail)
            //        .HasForeignKey(d => d.ContractId)
            //        .HasConstraintName("FK_Greige_DyeingContractDetail_Greige_DyeingContractMaster");
            //});

            //modelBuilder.Entity<GreigeDyeingContractDetailDel>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Greige_DyeingContractDetail_Del");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.ContractId).HasColumnName("ContractID");

            //    entity.Property(e => e.DeliveryDate).HasMaxLength(50);

            //    entity.Property(e => e.DeliveryPointId).HasColumnName("DeliveryPointID");

            //    entity.Property(e => e.FinishingCodeId).HasColumnName("FinishingCodeID");

            //    entity.Property(e => e.GreigeAttributeInstanceId).HasColumnName("GreigeAttributeInstanceID");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.MatchingSourceId).HasColumnName("MatchingSourceID");

            //    entity.Property(e => e.ModelId).HasColumnName("ModelID");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.PantoneId).HasColumnName("PantoneID");

            //    entity.Property(e => e.PantoneNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ProgramTypeId).HasColumnName("ProgramTypeID");

            //    entity.Property(e => e.Remarks).HasMaxLength(50);

            //    entity.Property(e => e.ReqSheetId).HasColumnName("ReqSheetID");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");
            //});

            //modelBuilder.Entity<GreigeDyeingContractMaster>(entity =>
            //{
            //    entity.ToTable("Greige_DyeingContractMaster");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.DyeingContractNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DyeingSourceId).HasColumnName("DyeingSourceID");

            //    entity.Property(e => e.DyerId).HasColumnName("DyerID");

            //    entity.Property(e => e.PaymentMode)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PaymentSubTerm)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PaymentTerm)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SigningAuthorityId).HasColumnName("SigningAuthorityID");

            //    entity.Property(e => e.SpecialComments)
            //        .HasMaxLength(1000)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<GreigeDyeingContractMasterDel>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Greige_DyeingContractMaster_Del");

            //    entity.Property(e => e.ActionDate).HasColumnType("datetime");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.DyeingContractNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DyeingSourceId).HasColumnName("DyeingSourceID");

            //    entity.Property(e => e.DyerId).HasColumnName("DyerID");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.PaymentMode)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PaymentSubTerm)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PaymentTerm)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SigningAuthorityId).HasColumnName("SigningAuthorityID");

            //    entity.Property(e => e.SpecialComments)
            //        .HasMaxLength(1000)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<GreigeDyeingContractStatusChangeHistory>(entity =>
            //{
            //    entity.ToTable("Greige_DyeingContractStatusChangeHistory");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Comments).HasMaxLength(50);

            //    entity.Property(e => e.Date).HasColumnType("datetime");

            //    entity.Property(e => e.Dcid).HasColumnName("DCID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<GreigeDyeingContractStatusSetup>(entity =>
            //{
            //    entity.ToTable("Greige_DyeingContractStatus_Setup");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<GreigeDyeingSourceSetup>(entity =>
            //{
            //    entity.ToTable("Greige_DyeingSource_Setup");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<GreigeGateReceivingMaster>(entity =>
            //{
            //    entity.HasKey(e => e.Grid);

            //    entity.ToTable("Greige_GateReceivingMaster");

            //    entity.Property(e => e.Grid).HasColumnName("GRID");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.DeliveryChallan)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

            //    entity.Property(e => e.DeliveryPerson)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Grno)
            //        .IsRequired()
            //        .HasColumnName("GRNo")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.QuantityInKg).HasColumnName("QuantityInKG");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.Property(e => e.VehicleNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Ykncid).HasColumnName("YKNCID");
            //});

            //modelBuilder.Entity<GreigeInspectionDetail>(entity =>
            //{
            //    entity.ToTable("Greige_InspectionDetail");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Gimid).HasColumnName("GIMID");

            //    entity.Property(e => e.QualityAttributeId).HasColumnName("QualityAttributeID");

            //    entity.Property(e => e.QualityAttributeValue)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Status)
            //        .IsRequired()
            //        .HasDefaultValueSql("(1)");

            //    entity.HasOne(d => d.Gim)
            //        .WithMany(p => p.GreigeInspectionDetail)
            //        .HasForeignKey(d => d.Gimid)
            //        .HasConstraintName("FK_Greige_InspectionDetail_Greige_InspectionMaster");
            //});

            //modelBuilder.Entity<GreigeInspectionDetailFlatBed>(entity =>
            //{
            //    entity.ToTable("Greige_InspectionDetail_FlatBed");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Gimid).HasColumnName("GIMID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.HasOne(d => d.Gim)
            //        .WithMany(p => p.GreigeInspectionDetailFlatBed)
            //        .HasForeignKey(d => d.Gimid)
            //        .HasConstraintName("FK_Greige_InspectionDetail_FlatBed_Greige_InspectionMaster");
            //});

            //modelBuilder.Entity<GreigeInspectionMaster>(entity =>
            //{
            //    entity.HasKey(e => e.Gimid);

            //    entity.ToTable("Greige_InspectionMaster");

            //    entity.Property(e => e.Gimid).HasColumnName("GIMID");

            //    entity.Property(e => e.Ginsno)
            //        .IsRequired()
            //        .HasColumnName("GINSNO")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Grnstatus).HasColumnName("GRNStatus");

            //    entity.Property(e => e.Gtrmid).HasColumnName("GTRMID");

            //    entity.Property(e => e.InspectionDate).HasColumnType("datetime");

            //    entity.Property(e => e.Ykncid).HasColumnName("YKNCID");
            //});

            //modelBuilder.Entity<GreigeInterOrderTransferMaster>(entity =>
            //{
            //    entity.HasKey(e => e.Iotid);

            //    entity.ToTable("Greige_InterOrderTransferMaster");

            //    entity.Property(e => e.Iotid).HasColumnName("IOTID");

            //    entity.Property(e => e.Iotdate)
            //        .HasColumnName("IOTDate")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.Iotno)
            //        .HasColumnName("IOTNo")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<GreigeIssuanceAgainstDyeingContractDetail>(entity =>
            //{
            //    entity.ToTable("Greige_IssuanceAgainstDyeingContract_Detail");

            //    entity.HasIndex(e => new { e.RollId, e.Dcid })
            //        .HasName("Ind_Greige_IssuanceAgainstDyeingContract_Detail_1");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.DcgattributeInstanceId).HasColumnName("DCGAttributeInstanceID");

            //    entity.Property(e => e.Dcid).HasColumnName("DCID");

            //    entity.Property(e => e.IssuanceId).HasColumnName("IssuanceID");

            //    entity.Property(e => e.PantoneNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.RollId).HasColumnName("RollID");

            //    entity.Property(e => e.RollNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StockGattributeInstanceId).HasColumnName("StockGAttributeInstanceID");

            //    entity.Property(e => e.TransactionDate).HasColumnType("datetime");

            //    entity.HasOne(d => d.Dc)
            //        .WithMany(p => p.GreigeIssuanceAgainstDyeingContractDetail)
            //        .HasForeignKey(d => d.Dcid)
            //        .HasConstraintName("FK_Greige_IssuanceAgainstDyeingContract_Detail_Greige_DyeingContractMaster");
            //});

            //modelBuilder.Entity<GreigeIssuanceMaster>(entity =>
            //{
            //    entity.HasKey(e => e.Giid);

            //    entity.ToTable("Greige_IssuanceMaster");

            //    entity.Property(e => e.Giid).HasColumnName("GIID");

            //    entity.Property(e => e.IssuanceDate).HasColumnType("datetime");

            //    entity.Property(e => e.IssuanceNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.IssuancePerson)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Ykncid).HasColumnName("YKNCID");
            //});

            //modelBuilder.Entity<GreigeMovingAverage>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Greige_MovingAverage");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");
            //});

            //modelBuilder.Entity<GreigeOpeningBalanceFlatbedDetail>(entity =>
            //{
            //    entity.ToTable("Greige_OpeningBalance_FlatbedDetail");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.QuantityInKgs).HasColumnName("QuantityInKGs");
            //});

            //modelBuilder.Entity<GreigeOpeningBalanceMaster>(entity =>
            //{
            //    entity.HasKey(e => e.Obid);

            //    entity.ToTable("Greige_OpeningBalance_Master");

            //    entity.Property(e => e.Obid).HasColumnName("OBID");

            //    entity.Property(e => e.Obdate)
            //        .HasColumnName("OBDate")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.Obno)
            //        .HasColumnName("OBNo")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<GreigePermanentReceivingMaster>(entity =>
            //{
            //    entity.HasKey(e => e.PermRecMid);

            //    entity.ToTable("Greige_PermanentReceivingMaster");

            //    entity.Property(e => e.PermRecMid).HasColumnName("PermRecMID");

            //    entity.Property(e => e.Gimid).HasColumnName("GIMID");

            //    entity.Property(e => e.PermRecDate).HasColumnType("datetime");

            //    entity.Property(e => e.PermRecNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Status).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.Ykncid).HasColumnName("YKNCID");
            //});

            //modelBuilder.Entity<GreigeQualityAttributes>(entity =>
            //{
            //    entity.ToTable("Greige_QualityAttributes");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.IsOptional)
            //        .IsRequired()
            //        .HasDefaultValueSql("(0)");
            //});

            //modelBuilder.Entity<GreigeStockAdjustmentMaster>(entity =>
            //{
            //    entity.HasKey(e => e.Said);

            //    entity.ToTable("Greige_StockAdjustmentMaster");

            //    entity.Property(e => e.Said).HasColumnName("SAID");

            //    entity.Property(e => e.Sadate)
            //        .HasColumnName("SADate")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.Sano)
            //        .HasColumnName("SANo")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<GreigeStockTransactions>(entity =>
            //{
            //    entity.HasKey(e => e.StockTransactionId);

            //    entity.ToTable("Greige_StockTransactions");

            //    entity.HasIndex(e => new { e.RollId, e.DocumentTypeId })
            //        .HasName("Ind_Greige_Stocktransactions_1");

            //    entity.Property(e => e.StockTransactionId).HasColumnName("StockTransactionID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.MachineId).HasColumnName("MachineID");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.ProgramTypeId).HasColumnName("ProgramTypeID");

            //    entity.Property(e => e.QualityId).HasColumnName("QualityID");

            //    entity.Property(e => e.RateWrtbaseUnit).HasColumnName("Rate_WRTBaseUnit");

            //    entity.Property(e => e.RollId).HasColumnName("RollID");

            //    entity.Property(e => e.RollNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Rollnonew).HasColumnName("rollnonew");

            //    entity.Property(e => e.Rollnop)
            //        .HasColumnName("rollnop")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Skuunit).HasColumnName("SKUUnit");

            //    entity.Property(e => e.Status).HasDefaultValueSql("((1))");

            //    entity.Property(e => e.StoreLocationId).HasColumnName("StoreLocationID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.TransactionDate).HasColumnType("datetime");

            //    entity.Property(e => e.Ykncid).HasColumnName("YKNCID");
            //});

            //modelBuilder.Entity<GreigeStocktransactionsBk09Apr2017>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("greige_Stocktransactions_bk09Apr2017");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.MachineId).HasColumnName("MachineID");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.ProgramTypeId).HasColumnName("ProgramTypeID");

            //    entity.Property(e => e.QualityId).HasColumnName("QualityID");

            //    entity.Property(e => e.RateWrtbaseUnit).HasColumnName("Rate_WRTBaseUnit");

            //    entity.Property(e => e.RollId).HasColumnName("RollID");

            //    entity.Property(e => e.RollNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Rollnonew).HasColumnName("rollnonew");

            //    entity.Property(e => e.Rollnop)
            //        .HasColumnName("rollnop")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Skuunit).HasColumnName("SKUUnit");

            //    entity.Property(e => e.StockTransactionId)
            //        .HasColumnName("StockTransactionID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.StoreLocationId).HasColumnName("StoreLocationID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.TransactionDate).HasColumnType("datetime");

            //    entity.Property(e => e.Ykncid).HasColumnName("YKNCID");
            //});

            //modelBuilder.Entity<GreigeTemporaryReceivingDetail>(entity =>
            //{
            //    entity.ToTable("Greige_TemporaryReceivingDetail");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Gtrmid).HasColumnName("GTRMID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.HasOne(d => d.Gtrm)
            //        .WithMany(p => p.GreigeTemporaryReceivingDetail)
            //        .HasForeignKey(d => d.Gtrmid)
            //        .HasConstraintName("FK_Greige_TemporaryReceivingDetail_Greige_TemporaryReceivingMaster");
            //});

            //modelBuilder.Entity<GreigeTemporaryReceivingMaster>(entity =>
            //{
            //    entity.HasKey(e => e.Gtrmid);

            //    entity.ToTable("Greige_TemporaryReceivingMaster");

            //    entity.Property(e => e.Gtrmid).HasColumnName("GTRMID");

            //    entity.Property(e => e.Grid).HasColumnName("GRID");

            //    entity.Property(e => e.TempRecDate).HasColumnType("datetime");

            //    entity.Property(e => e.Tgrno)
            //        .IsRequired()
            //        .HasColumnName("TGRNo")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Ykncid).HasColumnName("YKNCID");
            //});

            //modelBuilder.Entity<GreighFrsgreighAssociationAttInsId>(entity =>
            //{
            //    entity.ToTable("Greigh_FRSGreighAssociationAttInsID");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Daid).HasColumnName("DAID");

            //    entity.Property(e => e.Frsaid).HasColumnName("FRSAID");

            //    entity.Property(e => e.Frsid).HasColumnName("FRSID");

            //    entity.Property(e => e.Gaid).HasColumnName("GAID");

            //    entity.Property(e => e.Gsm).HasColumnName("GSM");
            //});

            //modelBuilder.Entity<IcAuthorityLevels>(entity =>
            //{
            //    entity.ToTable("IC_AuthorityLevels");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Description).IsUnicode(false);

            //    entity.Property(e => e.Name).IsUnicode(false);
            //});

            //modelBuilder.Entity<IcDepartment>(entity =>
            //{
            //    entity.ToTable("IC_Department");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.AddedOn)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Name)
            //        .IsRequired()
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<IcDepartmentUnitSetup>(entity =>
            //{
            //    entity.ToTable("IC_DepartmentUnitSetup");

            //    entity.Property(e => e.CreateDate).HasColumnType("datetime");

            //    entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            //});

            //modelBuilder.Entity<IcDocumentCategories>(entity =>
            //{
            //    entity.ToTable("IC_DocumentCategories");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

            //    entity.Property(e => e.Name)
            //        .IsRequired()
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<IcDocumentSetup>(entity =>
            //{
            //    entity.ToTable("IC_DocumentSetup");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Description).IsUnicode(false);

            //    entity.Property(e => e.Name)
            //        .IsRequired()
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<IcExportSalesGatePassDetail>(entity =>
            //{
            //    entity.ToTable("IC_ExportSalesGatePassDetail");

            //    entity.Property(e => e.BuyerName)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ClearingAgent)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ContainerNo)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ContainerSize)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ExportSalesGatePassId).HasColumnName("ExportSalesGatePassID");

            //    entity.Property(e => e.FormEno)
            //        .HasColumnName("FormENo")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.InvoiceNumber)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ItemName)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.Remarks)
            //        .HasMaxLength(500)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SealNo)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ShippingLine).IsUnicode(false);

            //    entity.Property(e => e.Sno)
            //        .HasColumnName("SNO")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<IcExportSalesGatePassDetailBk29Jan2018>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("IC_ExportSalesGatePassDetail_Bk29Jan2018");

            //    entity.Property(e => e.BuyerName)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ClearingAgent)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ContainerNo)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ContainerSize)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ExportSalesGatePassId).HasColumnName("ExportSalesGatePassID");

            //    entity.Property(e => e.FormEno)
            //        .HasColumnName("FormENo")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Gid).HasColumnName("GID");

            //    entity.Property(e => e.Id).ValueGeneratedOnAdd();

            //    entity.Property(e => e.InvoiceNumber)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ItemName)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.Remarks)
            //        .HasMaxLength(500)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SealNo)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ShippingLine).IsUnicode(false);

            //    entity.Property(e => e.Sno)
            //        .HasColumnName("SNO")
            //        .HasMaxLength(100)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<IcExportSalesGatePassMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("IC_ExportSalesGatePassMaster");

            //    entity.Property(e => e.CustomerId)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Purpose)
            //        .HasMaxLength(500)
            //        .IsUnicode(false);

            //    entity.Property(e => e.VehicleRef)
            //        .HasMaxLength(100)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<IcExportSalesGatePassMasterBk29Jan2018>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("IC_ExportSalesGatePassMaster_Bk29Jan2018");

            //    entity.Property(e => e.CustomerId)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Gid).HasColumnName("GID");

            //    entity.Property(e => e.Purpose)
            //        .HasMaxLength(500)
            //        .IsUnicode(false);

            //    entity.Property(e => e.VehicleRef)
            //        .HasMaxLength(100)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<IcGatepassLog>(entity =>
            //{
            //    entity.ToTable("IC_Gatepass_Log");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CommentsDate)
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.CreationDate)
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.GatepassId).HasColumnName("GatepassID");

            //    entity.Property(e => e.GatepassNo)
            //        .HasColumnName("GatepassNO")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<IcGatepassLogBk29Jan2018>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("IC_Gatepass_Log_Bk29Jan2018");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CommentsDate).HasColumnType("smalldatetime");

            //    entity.Property(e => e.CreationDate).HasColumnType("smalldatetime");

            //    entity.Property(e => e.GatepassId).HasColumnName("GatepassID");

            //    entity.Property(e => e.GatepassNo)
            //        .HasColumnName("GatepassNO")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<IcGatepassMaster>(entity =>
            //{
            //    entity.ToTable("IC_GatepassMaster");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ApprovedOn).HasColumnType("datetime");

            //    entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.DateTimeStamp)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.DeletedOn).HasColumnType("datetime");

            //    entity.Property(e => e.Gid).HasColumnName("GID");

            //    entity.Property(e => e.IsApproved)
            //        .HasColumnName("isApproved")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.IsDeleted)
            //        .HasColumnName("isDeleted")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.IsMarkedOut)
            //        .HasColumnName("isMarkedOut")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.MarkedOutOn).HasColumnType("datetime");

            //    entity.Property(e => e.Seq).HasColumnName("SEQ");

            //    entity.Property(e => e.Serial)
            //        .IsRequired()
            //        .IsUnicode(false);

            //    entity.Property(e => e.VehicleNo).IsUnicode(false);
            //});

            //modelBuilder.Entity<IcGatepassMasterBk29Jan2018>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("IC_GatepassMaster_Bk29Jan2018");

            //    entity.Property(e => e.ApprovedOn).HasColumnType("datetime");

            //    entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.DateTimeStamp).HasColumnType("datetime");

            //    entity.Property(e => e.DeletedOn).HasColumnType("datetime");

            //    entity.Property(e => e.Gid).HasColumnName("GID");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.IsApproved).HasColumnName("isApproved");

            //    entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

            //    entity.Property(e => e.IsMarkedOut).HasColumnName("isMarkedOut");

            //    entity.Property(e => e.MarkedOutOn).HasColumnType("datetime");

            //    entity.Property(e => e.Seq).HasColumnName("SEQ");

            //    entity.Property(e => e.Serial)
            //        .IsRequired()
            //        .IsUnicode(false);

            //    entity.Property(e => e.VehicleNo).IsUnicode(false);
            //});

            //modelBuilder.Entity<IcLocalSalesGatePassDetail>(entity =>
            //{
            //    entity.ToTable("IC_LocalSalesGatePassDetail");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ColorFinishCode).IsUnicode(false);

            //    entity.Property(e => e.ItemType)
            //        .HasMaxLength(500)
            //        .IsUnicode(false);

            //    entity.Property(e => e.LocalSalesGatePassId).HasColumnName("LocalSalesGatePassID");

            //    entity.Property(e => e.OrderNo).IsUnicode(false);

            //    entity.Property(e => e.ProcessCodeId)
            //        .HasColumnName("ProcessCodeID")
            //        .HasMaxLength(500)
            //        .IsUnicode(false);

            //    entity.Property(e => e.RefNo).IsUnicode(false);

            //    entity.Property(e => e.Remarks).IsUnicode(false);

            //    entity.Property(e => e.Roll)
            //        .HasMaxLength(500)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SalesTaxInvoiceNo).IsUnicode(false);

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");
            //});

            //modelBuilder.Entity<IcLocalSalesGatePassMaster>(entity =>
            //{
            //    entity.HasKey(e => e.GatePassId);

            //    entity.ToTable("IC_LocalSalesGatePassMaster");

            //    entity.Property(e => e.GatePassId)
            //        .HasColumnName("GatePassID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

            //    entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

            //    entity.Property(e => e.IsSelfVehicle)
            //        .HasColumnName("isSelfVehicle")
            //        .HasDefaultValueSql("((1))");
            //});

            //modelBuilder.Entity<IcLocalSalesItem>(entity =>
            //{
            //    entity.ToTable("IC_LocalSalesItem");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.AddedOn)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

            //    entity.Property(e => e.Name)
            //        .IsRequired()
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<IcLocalSalesItemProcessCode>(entity =>
            //{
            //    entity.ToTable("IC_LocalSalesItemProcessCode");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.AddedOn)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Code)
            //        .IsRequired()
            //        .IsUnicode(false);

            //    entity.Property(e => e.LocalSalesItemId).HasColumnName("LocalSalesItemID");
            //});

            //modelBuilder.Entity<IcMenuItem>(entity =>
            //{
            //    entity.ToTable("IC_MenuItem");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

            //    entity.Property(e => e.Name)
            //        .IsRequired()
            //        .IsUnicode(false);

            //    entity.Property(e => e.NavigateUrl).IsUnicode(false);

            //    entity.Property(e => e.ParentItemId).HasColumnName("ParentItemID");
            //});

            //modelBuilder.Entity<IcNonReturnableGatePassDetail>(entity =>
            //{
            //    entity.ToTable("IC_NonReturnableGatePassDetail");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ItemName)
            //        .IsRequired()
            //        .IsUnicode(false);

            //    entity.Property(e => e.NonReturnableGatePassId).HasColumnName("NonReturnableGatePassID");

            //    entity.Property(e => e.Remarks).IsUnicode(false);

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");
            //});

            //modelBuilder.Entity<IcNonReturnableGatePassDetailBk29Jan2018>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("IC_NonReturnableGatePassDetail_Bk29Jan2018");

            //    entity.Property(e => e.Gid).HasColumnName("GID");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.ItemName)
            //        .IsRequired()
            //        .IsUnicode(false);

            //    entity.Property(e => e.NonReturnableGatePassId).HasColumnName("NonReturnableGatePassID");

            //    entity.Property(e => e.Remarks).IsUnicode(false);

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");
            //});

            //modelBuilder.Entity<IcNonReturnableGatePassMaster>(entity =>
            //{
            //    entity.HasKey(e => e.GatePassId);

            //    entity.ToTable("IC_NonReturnableGatePassMaster");

            //    entity.Property(e => e.GatePassId)
            //        .HasColumnName("GatePassID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

            //    entity.Property(e => e.IssuedToId)
            //        .HasColumnName("IssuedToID")
            //        .HasMaxLength(500)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Purpose).IsUnicode(false);
            //});

            //modelBuilder.Entity<IcNonReturnableGatePassMasterBk29Jan2018>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("IC_NonReturnableGatePassMaster_Bk29Jan2018");

            //    entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

            //    entity.Property(e => e.GatePassId).HasColumnName("GatePassID");

            //    entity.Property(e => e.Gid).HasColumnName("GID");

            //    entity.Property(e => e.IssuedToId)
            //        .HasColumnName("IssuedToID")
            //        .HasMaxLength(500)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Purpose).IsUnicode(false);
            //});

            //modelBuilder.Entity<IcReturnableGatePassDetail>(entity =>
            //{
            //    entity.ToTable("IC_ReturnableGatePassDetail");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ExpectedReturnDate).HasColumnType("datetime");

            //    entity.Property(e => e.ItemName)
            //        .IsRequired()
            //        .IsUnicode(false);

            //    entity.Property(e => e.RecieveQuantity).HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.Remarks).IsUnicode(false);

            //    entity.Property(e => e.ReturnableGatePassId).HasColumnName("ReturnableGatePassID");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");
            //});

            //modelBuilder.Entity<IcReturnableGatePassDetailBk29Jan2018>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("IC_ReturnableGatePassDetail_Bk29Jan2018");

            //    entity.Property(e => e.ExpectedReturnDate).HasColumnType("datetime");

            //    entity.Property(e => e.Gid).HasColumnName("GID");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.ItemName)
            //        .IsRequired()
            //        .IsUnicode(false);

            //    entity.Property(e => e.RecieveQuantity).HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.Remarks).IsUnicode(false);

            //    entity.Property(e => e.ReturnableGatePassId).HasColumnName("ReturnableGatePassID");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");
            //});

            //modelBuilder.Entity<IcReturnableGatePassMaster>(entity =>
            //{
            //    entity.HasKey(e => e.GatePassId);

            //    entity.ToTable("IC_ReturnableGatePassMaster");

            //    entity.Property(e => e.GatePassId)
            //        .HasColumnName("GatePassID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.Hrmsid)
            //        .HasColumnName("HRMSID")
            //        .IsUnicode(false);

            //    entity.Property(e => e.IsSelfVehicle)
            //        .HasColumnName("isSelfVehicle")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.IssuedTo)
            //        .HasMaxLength(500)
            //        .IsUnicode(false);

            //    entity.Property(e => e.JobDesc).IsUnicode(false);

            //    entity.Property(e => e.Representative)
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.RepresentativeContact).IsUnicode(false);

            //    entity.Property(e => e.VendorId).HasColumnName("VendorID");
            //});

            //modelBuilder.Entity<IcReturnableGatePassMasterBk29Jan2018>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("IC_ReturnableGatePassMaster_Bk29Jan2018");

            //    entity.Property(e => e.GatePassId).HasColumnName("GatePassID");

            //    entity.Property(e => e.Gid).HasColumnName("GID");

            //    entity.Property(e => e.Hrmsid)
            //        .HasColumnName("HRMSID")
            //        .IsUnicode(false);

            //    entity.Property(e => e.IsSelfVehicle).HasColumnName("isSelfVehicle");

            //    entity.Property(e => e.IssuedTo)
            //        .HasMaxLength(500)
            //        .IsUnicode(false);

            //    entity.Property(e => e.JobDesc).IsUnicode(false);

            //    entity.Property(e => e.Representative)
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.RepresentativeContact).IsUnicode(false);

            //    entity.Property(e => e.VendorId).HasColumnName("VendorID");
            //});

            //modelBuilder.Entity<IcReturnableRecieveGatePassDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("IC_ReturnableRecieveGatePassDetail");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.RecieveDate).HasColumnType("datetime");

            //    entity.Property(e => e.RecieveQuantity).HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.ReturnableGatePassItemId).HasColumnName("ReturnableGatePassItemID");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");
            //});

            //modelBuilder.Entity<IcReturnableRecieveGatePassDetailBk29Jan2018>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("IC_ReturnableRecieveGatePassDetail_Bk29Jan2018");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.RecieveDate).HasColumnType("datetime");

            //    entity.Property(e => e.RecieveQuantity).HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.ReturnableGatePassItemId).HasColumnName("ReturnableGatePassItemID");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");
            //});

            //modelBuilder.Entity<IcRoleSetup>(entity =>
            //{
            //    entity.ToTable("IC_RoleSetup");

            //    entity.Property(e => e.RoleName)
            //        .HasMaxLength(500)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<IcScrapCustomer>(entity =>
            //{
            //    entity.ToTable("IC_ScrapCustomer");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.AddedOn)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Address).IsUnicode(false);

            //    entity.Property(e => e.CompanyName)
            //        .IsRequired()
            //        .IsUnicode(false);

            //    entity.Property(e => e.ContactPerson).IsUnicode(false);

            //    entity.Property(e => e.ContactPhone).IsUnicode(false);
            //});

            //modelBuilder.Entity<IcScrapSalesGatePassDetail>(entity =>
            //{
            //    entity.ToTable("IC_ScrapSalesGatePassDetail");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ItemName)
            //        .IsRequired()
            //        .IsUnicode(false);

            //    entity.Property(e => e.Remarks).IsUnicode(false);

            //    entity.Property(e => e.ScrapSalesGatePassId).HasColumnName("ScrapSalesGatePassID");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");
            //});

            //modelBuilder.Entity<IcScrapSalesGatePassMaster>(entity =>
            //{
            //    entity.HasKey(e => e.GatePassId);

            //    entity.ToTable("IC_ScrapSalesGatePassMaster");

            //    entity.Property(e => e.GatePassId)
            //        .HasColumnName("GatePassID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.ScrapCustomerId).HasColumnName("ScrapCustomerID");

            //    entity.Property(e => e.WeightSlipNo).IsUnicode(false);
            //});

            //modelBuilder.Entity<IcUnitSetup>(entity =>
            //{
            //    entity.ToTable("IC_UnitSetup");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Name)
            //        .IsRequired()
            //        .IsUnicode(false);

            //    entity.Property(e => e.ShortName)
            //        .IsRequired()
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<IcUserAuthorities>(entity =>
            //{
            //    entity.ToTable("IC_UserAuthorities");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.AuthorityLevelId).HasColumnName("AuthorityLevelID");

            //    entity.Property(e => e.AuthorizedOn)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<IcUserCategory>(entity =>
            //{
            //    entity.ToTable("Ic_UserCategory");

            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.Userid).HasColumnName("userid");
            //});

            //modelBuilder.Entity<IcUserCategoryDepartmentAuthority>(entity =>
            //{
            //    entity.ToTable("IC_UserCategoryDepartmentAuthority");

            //    entity.Property(e => e.CreateDate).HasColumnType("datetime");

            //    entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            //});

            //modelBuilder.Entity<IcUserDepartmentSetup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("IC_UserDepartmentSetup");

            //    entity.Property(e => e.CreateDate).HasColumnType("datetime");

            //    entity.Property(e => e.Id).ValueGeneratedOnAdd();

            //    entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            //});

            //modelBuilder.Entity<IcUserMenuItem>(entity =>
            //{
            //    entity.ToTable("IC_UserMenuItem");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.AssignedOn)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.MenuItemId).HasColumnName("MenuItemID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<IcUserRole>(entity =>
            //{
            //    entity.ToTable("IC_UserRole");
            //});

            //modelBuilder.Entity<IcUserSetup>(entity =>
            //{
            //    entity.HasKey(e => e.UserId);

            //    entity.ToTable("IC_UserSetup");

            //    entity.Property(e => e.UserId)
            //        .HasColumnName("UserID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.Active).HasDefaultValueSql("((1))");

            //    entity.Property(e => e.AddedOn)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.CanAddScrapCustomers).HasDefaultValueSql("((0))");

            //    entity.Property(e => e.CanAuthorizeUsers).HasDefaultValueSql("((0))");

            //    entity.Property(e => e.CanCreateUsers).HasDefaultValueSql("((0))");

            //    entity.Property(e => e.CanViewScrapCustomers).HasDefaultValueSql("((0))");
            //});

            //modelBuilder.Entity<IcVendorDetail>(entity =>
            //{
            //    entity.ToTable("IC_VendorDetail");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ContactNo)
            //        .IsRequired()
            //        .IsUnicode(false);

            //    entity.Property(e => e.Name)
            //        .IsRequired()
            //        .IsUnicode(false);

            //    entity.Property(e => e.VendorId).HasColumnName("VendorID");
            //});

            //modelBuilder.Entity<IcVendorMaster>(entity =>
            //{
            //    entity.ToTable("IC_VendorMaster");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.AddedOn)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Address).IsUnicode(false);

            //    entity.Property(e => e.ContactNo).IsUnicode(false);

            //    entity.Property(e => e.VendorName)
            //        .IsRequired()
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<IcvpopulateTableTemp>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("ICVPopulateTableTemp");

            //    entity.Property(e => e.FabricCategoryId).HasColumnName("FabricCategoryID");

            //    entity.Property(e => e.VoucherId).HasColumnName("VoucherID");
            //});

            //modelBuilder.Entity<ImportDoubleOrder>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Import_DoubleOrder");

            //    entity.Property(e => e.Cartonno).HasColumnName("CARTONNO");

            //    entity.Property(e => e.Correctorder)
            //        .HasColumnName("CORRECTORDER")
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Correctorderid).HasColumnName("CORRECTORDERID");

            //    entity.Property(e => e.Model)
            //        .HasColumnName("MODEL")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.Order)
            //        .HasColumnName("ORDER")
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Orderid).HasColumnName("ORDERID");
            //});

            //modelBuilder.Entity<ImportScs225order>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Import_SCS225Order");

            //    entity.Property(e => e.ColorIdnew).HasColumnName("ColorIDNew");

            //    entity.Property(e => e.ColorIdold).HasColumnName("ColorIDOld");

            //    entity.Property(e => e.SizeIdnew).HasColumnName("SizeIDNew");

            //    entity.Property(e => e.SizeIdold).HasColumnName("SizeIDOld");
            //});

            //modelBuilder.Entity<ImportUsdata>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Import_USData");

            //    entity.Property(e => e.Brand).HasMaxLength(255);

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.Colour).HasMaxLength(255);

            //    entity.Property(e => e.CustomerCode)
            //        .HasColumnName("Customer code")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.CustomerCode1)
            //        .HasColumnName("CustomerCode")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

            //    entity.Property(e => e.CustomerName)
            //        .HasColumnName("customer name")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.DeliveryTheme)
            //        .HasColumnName("Delivery /theme")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.DestinationCode)
            //        .HasColumnName("destination code")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.DestinationId).HasColumnName("DestinationID");

            //    entity.Property(e => e.IdNumer)
            //        .HasColumnName("Id numer")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.OrderDate)
            //        .HasColumnName("order date")
            //        .HasColumnType("smalldatetime");

            //    entity.Property(e => e.Season).HasMaxLength(255);

            //    entity.Property(e => e.Size).HasMaxLength(255);

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.SoldQnt).HasColumnName("Sold Qnt");

            //    entity.Property(e => e.StyleCode)
            //        .HasColumnName("Style code")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.StyleDescription)
            //        .HasColumnName("Style description")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.StyleId1).HasColumnName("StyleID1");
            //});

            //modelBuilder.Entity<LcFpManufacturefabricPi>(entity =>
            //{
            //    entity.HasKey(e => e.LfpId);

            //    entity.ToTable("LC_FP_MANUFACTUREFABRIC_PI");

            //    entity.Property(e => e.LfpId)
            //        .HasColumnName("LFP_ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.LfpOrdersheetfabricid).HasColumnName("LFP_ORDERSHEETFABRICID");

            //    entity.Property(e => e.LfpRequiredquantity)
            //        .HasColumnName("LFP_REQUIREDQUANTITY")
            //        .HasColumnType("numeric(18, 4)");

            //    entity.Property(e => e.LmpId).HasColumnName("LMP_ID");

            //    entity.HasOne(d => d.Lmp)
            //        .WithMany(p => p.LcFpManufacturefabricPi)
            //        .HasForeignKey(d => d.LmpId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_LC_FP_MANUFACTUREFABRIC_PI_LC_MP_MANUFACTUREITEM_PI");
            //});

            //modelBuilder.Entity<LcMpManufactureitemPi>(entity =>
            //{
            //    entity.HasKey(e => e.LmpId);

            //    entity.ToTable("LC_MP_MANUFACTUREITEM_PI");

            //    entity.Property(e => e.LmpId)
            //        .HasColumnName("LMP_ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.LmpCode)
            //        .IsRequired()
            //        .HasColumnName("LMP_CODE")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.LpoId).HasColumnName("LPO_ID");
            //});

            //modelBuilder.Entity<MasterBarCodeView>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("MasterBarCode_View");

            //    entity.Property(e => e.AssortementCode)
            //        .IsRequired()
            //        .HasMaxLength(5)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ColorCode)
            //        .IsRequired()
            //        .HasMaxLength(5)
            //        .IsUnicode(false);

            //    entity.Property(e => e.MasterBarCode)
            //        .IsRequired()
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OrderNo)
            //        .IsRequired()
            //        .HasMaxLength(5)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SingleBarCode)
            //        .IsRequired()
            //        .HasMaxLength(25)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SizeDesc)
            //        .IsRequired()
            //        .HasMaxLength(5)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StyleCode)
            //        .IsRequired()
            //        .HasMaxLength(10)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<MirgrossNet>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MIRGrossNet");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.ConsolidationAttributeId).HasColumnName("ConsolidationAttributeID");

            //    entity.Property(e => e.DayId).HasColumnName("DayID");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.ObjectId).HasColumnName("ObjectID");

            //    entity.Property(e => e.PodayId).HasColumnName("PODayID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");
            //});

            //modelBuilder.Entity<MirscheduleReceipt>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MIRScheduleReceipt");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.CollectionId).HasColumnName("CollectionID");

            //    entity.Property(e => e.DayId).HasColumnName("DayID");

            //    entity.Property(e => e.IsDeleted).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<MmAdjustmentMaster>(entity =>
            //{
            //    entity.HasKey(e => e.AdjustmentId);

            //    entity.ToTable("MM_AdjustmentMaster");

            //    entity.Property(e => e.AdjustmentId).HasColumnName("AdjustmentID");

            //    entity.Property(e => e.AdjustmentDate).HasColumnType("datetime");

            //    entity.Property(e => e.AdjustmentNoteNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<MmAttributeValue>(entity =>
            //{
            //    entity.HasKey(e => e.AttributeValueId);

            //    entity.ToTable("MM_AttributeValue");

            //    entity.Property(e => e.AttributeValueId).HasColumnName("AttributeValueID");

            //    entity.Property(e => e.AttributeId).HasColumnName("AttributeID");

            //    entity.Property(e => e.MavalueDescription)
            //        .IsRequired()
            //        .HasColumnName("MAValueDescription")
            //        .HasMaxLength(1000)
            //        .IsUnicode(false);

            //    entity.Property(e => e.MavalueId).HasColumnName("MAValueID");
            //});

            //modelBuilder.Entity<MmBuyerOrderModelAvailableQty>(entity =>
            //{
            //    entity.ToTable("MM_BuyerOrderModel_AvailableQty");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.BuyerId).HasColumnName("BuyerID");

            //    entity.Property(e => e.ModelId).HasColumnName("ModelID");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");
            //});

            //modelBuilder.Entity<MmClosingDates>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MM_ClosingDates");

            //    entity.Property(e => e.EndDate).HasColumnType("datetime");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.StartDate).HasColumnType("datetime");
            //});

            //modelBuilder.Entity<MmCostCenterAssciationStyleWise>(entity =>
            //{
            //    entity.ToTable("MM_CostCenterAssciationStyleWise");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

            //    entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

            //    entity.Property(e => e.Ccid).HasColumnName("CCID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.FabricCategoryId).HasColumnName("FabricCategoryID");

            //    entity.Property(e => e.LocationId).HasColumnName("LocationID");
            //});

            //modelBuilder.Entity<MmDebitNote>(entity =>
            //{
            //    entity.HasKey(e => e.Dnid);

            //    entity.ToTable("MM_DebitNote");

            //    entity.Property(e => e.Dnid).HasColumnName("DNID");

            //    entity.Property(e => e.Dnno)
            //        .IsRequired()
            //        .HasColumnName("DNNo")
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .IsFixedLength();
            //});

            //modelBuilder.Entity<MmDebitNoteDetail>(entity =>
            //{
            //    entity.HasKey(e => e.Dndid);

            //    entity.ToTable("MM_DebitNoteDetail");

            //    entity.Property(e => e.Dndid).HasColumnName("DNDID");

            //    entity.Property(e => e.Dnid).HasColumnName("DNID");

            //    entity.Property(e => e.Iid).HasColumnName("IID");

            //    entity.HasOne(d => d.Dn)
            //        .WithMany(p => p.MmDebitNoteDetail)
            //        .HasForeignKey(d => d.Dnid)
            //        .HasConstraintName("FK_MM_DebitNoteDetail_MM_DebitNote");
            //});

            //modelBuilder.Entity<MM_DocumentType_Setup>(entity =>
            //{
            //    entity.HasNoKey();

            //    //entity.ToTable("MM_DocumentType_Setup");

            //    //entity.Property(e => e.DocumentDescription)
            //    //    .IsRequired()
            //    //    .HasMaxLength(50)
            //    //    .IsUnicode(false);

            //    //entity.Property(e => e.DocumentName)
            //    //    .IsRequired()
            //    //    .HasMaxLength(50)
            //    //    .IsUnicode(false);

            //    //entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    //entity.Property(e => e.SubModuleId).HasColumnName("SubModuleID");

            //    entity.HasOne(d => d.SubModule_Setup)
            //        .WithMany(p => p.MM_DocumentType_Setup)
            //        .HasForeignKey(d => d.SubModuleID)
            //        .HasConstraintName("FK_DocumentType_Setup_SubModule_Setup");
            //});

            //modelBuilder.Entity<MmDomainCategory>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MM_DomainCategory");

            //    entity.Property(e => e.DomainId).HasColumnName("DomainID");

            //    entity.Property(e => e.StoreCategoryId).HasColumnName("StoreCategoryID");
            //});

            //modelBuilder.Entity<MmFiintregration>(entity =>
            //{
            //    entity.ToTable("MM_FIIntregration");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.Status)
            //        .HasColumnName("status")
            //        .HasDefaultValueSql("((1))");

            //    entity.Property(e => e.TransactionDate).HasColumnType("datetime");

            //    entity.Property(e => e.VouchareId).HasColumnName("VouchareID");

            //    entity.Property(e => e.VouchareNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<MmFiintregrationBkup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MM_FIIntregration_BKUP");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

            //    entity.Property(e => e.DocumentNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Status).HasColumnName("status");

            //    entity.Property(e => e.TransactionDate).HasColumnType("datetime");

            //    entity.Property(e => e.VouchareId).HasColumnName("VouchareID");

            //    entity.Property(e => e.VouchareNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<MM_GateReceiving>(entity =>
            //{
            //   // entity.HasNoKey();

            //    //entity.ToTable("MM_GateReceiving");

            //    //entity.Property(e => e.Grid).HasColumnName("GRID");

            //    //entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

            //    //entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    //entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    //entity.Property(e => e.DeliveryChallan)
            //    //    .HasMaxLength(100)
            //    //    .IsUnicode(false);

            //    //entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

            //    //entity.Property(e => e.DeliveryPerson)
            //    //    .HasMaxLength(50)
            //    //    .IsUnicode(false);

            //    //entity.Property(e => e.Flag)
            //    //    .HasColumnName("flag")
            //    //    .HasDefaultValueSql("((1))");

            //    //entity.Property(e => e.Grno)
            //    //    .IsRequired()
            //    //    .HasColumnName("GRNo")
            //    //    .HasMaxLength(50)
            //    //    .IsUnicode(false);

            //    //entity.Property(e => e.Poid).HasColumnName("POID");

            //    //entity.Property(e => e.Status).HasComment("0...Temporary Receiving NOT done.... 5 ....Temp Recv. Done");

            //    //entity.Property(e => e.UserId).HasColumnName("UserID");

            //    //entity.Property(e => e.VehicleNo)
            //    //    .HasMaxLength(50)
            //    //    .IsUnicode(false);
            //});

            //modelBuilder.Entity<MM_GateReceivingDetail>(entity =>
            //{
            //    entity.HasNoKey();
            //   // entity.HasKey(e => e.Grdid);

            //    //entity.ToTable("MM_GateReceivingDetail");

            //    //entity.Property(e => e.Grdid).HasColumnName("GRDID");

            //    //entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    //entity.Property(e => e.Grid)
            //    //    .HasColumnName("GRID")
            //    //    .HasComment("foreign key from MM_GateReceiving");

            //    //entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    //entity.Property(e => e.ObjectId).HasColumnName("ObjectID");

            //    //entity.Property(e => e.PodetailId).HasColumnName("PODetailID");

            //    //entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    //entity.HasOne(d => d.Gr)
            //    //    .WithMany(p => p.MmGateReceivingDetail)
            //    //    .HasForeignKey(d => d.Grid)
            //    //    .HasConstraintName("FK_MM_GateReceivingDetail_MM_GateReceiving");
            //});

            //modelBuilder.Entity<MmGeneralSetupDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MM_GeneralSetupDetail");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.InstanceId)
            //        .IsRequired()
            //        .HasColumnName("InstanceID")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.InstanceValue)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Rdate)
            //        .HasColumnName("RDate")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.SetupId)
            //        .IsRequired()
            //        .HasColumnName("SetupID")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<MmGeneralSetupMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MM_GeneralSetupMaster");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Rdate)
            //        .HasColumnName("RDate")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.SetupId)
            //        .IsRequired()
            //        .HasColumnName("SetupID")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<MmInterLocationTransferMaster>(entity =>
            //{
            //    entity.ToTable("MM_InterLocationTransferMaster");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

            //    entity.Property(e => e.BuyerId).HasColumnName("BuyerID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.Iltnumber)
            //        .HasColumnName("ILTNumber")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.InterLocationTransferDate).HasColumnType("datetime");

            //    entity.Property(e => e.ModelId).HasColumnName("ModelID");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");
            //});

            //modelBuilder.Entity<MmInterOrderTransferMaster>(entity =>
            //{
            //    entity.HasKey(e => e.Ioid);

            //    entity.ToTable("MM_InterOrderTransferMaster");

            //    entity.Property(e => e.Ioid).HasColumnName("IOID");

            //    entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

            //    entity.Property(e => e.BuyerId).HasColumnName("BuyerID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.InterOrderDate).HasColumnType("datetime");

            //    entity.Property(e => e.Iotnumber)
            //        .IsRequired()
            //        .HasColumnName("IOTNumber")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ModelId).HasColumnName("ModelID");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<MmInvoiceDetail>(entity =>
            //{
            //    entity.HasKey(e => e.Idid);

            //    entity.ToTable("MM_InvoiceDetail");

            //    entity.Property(e => e.Idid).HasColumnName("IDID");

            //    entity.Property(e => e.Gst).HasColumnName("GST");

            //    entity.Property(e => e.Iid).HasColumnName("IID");

            //    entity.Property(e => e.PermRecMid).HasColumnName("PermRecMID");

            //    entity.HasOne(d => d.I)
            //        .WithMany(p => p.MmInvoiceDetail)
            //        .HasForeignKey(d => d.Iid)
            //        .HasConstraintName("FK_MM_InvoiceDetail_MM_InvoiceMaster");
            //});

            //modelBuilder.Entity<MmInvoiceMaster>(entity =>
            //{
            //    entity.HasKey(e => e.Iid);

            //    entity.ToTable("MM_InvoiceMaster");

            //    entity.Property(e => e.Iid).HasColumnName("IID");

            //    entity.Property(e => e.CinvoiceDate)
            //        .HasColumnName("CInvoiceDate")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.CinvoiceNo)
            //        .IsRequired()
            //        .HasColumnName("CInvoiceNo")
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

            //    entity.Property(e => e.InvoiceNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            //});

            //modelBuilder.Entity<MmLcsDetailItems>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MM_LCS_Detail_Items");

            //    entity.Property(e => e.Lcsfcrate).HasColumnName("LCSFCRate");

            //    entity.Property(e => e.LcsitemId)
            //        .HasColumnName("LCSItemID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.LcsmasterId).HasColumnName("LCSMasterID");

            //    entity.Property(e => e.Lcsquantity).HasColumnName("LCSQuantity");

            //    entity.Property(e => e.LcsrevisedLcrate).HasColumnName("LCSRevisedLCRate");

            //    entity.Property(e => e.PoitemId).HasColumnName("POItemID");
            //});

            //modelBuilder.Entity<MmLcsMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MM_LCS_Master");

            //    entity.Property(e => e.CalculatedLcsrate).HasColumnName("CalculatedLCSRate");

            //    entity.Property(e => e.ClearingAgentBillNo)
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");

            //    entity.Property(e => e.GdmasterId).HasColumnName("GDMasterID");

            //    entity.Property(e => e.LcsmasterId)
            //        .HasColumnName("LCSMasterID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Lcsnumber)
            //        .HasColumnName("LCSNumber")
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Lcsversion).HasColumnName("LCSVersion");

            //    entity.Property(e => e.Mplnumber)
            //        .HasColumnName("MPLNumber")
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PackageDetail)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ProformaInvoiceNo)
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ReceivingDate).HasColumnType("datetime");

            //    entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            //});

            modelBuilder.Entity<MM_ListAttributeInstanceID>(entity =>
            {
                entity.HasKey(e => new { e.ListAttInstanceID, e.AttributeInstanceID });

                //entity.ToTable("MM_ListAttributeInstanceID");

                //entity.Property(e => e.ListAttInstanceId).HasColumnName("ListAttInstanceID");

                //entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");
            });

            //modelBuilder.Entity<MmMaterialInspectionMaster>(entity =>
            //{
            //    entity.HasKey(e => e.Mimid);

            //    entity.ToTable("MM_MaterialInspection_Master");

            //    entity.Property(e => e.Mimid).HasColumnName("MIMID");

            //    entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.Flag)
            //        .HasColumnName("flag")
            //        .HasDefaultValueSql("(1)");

            //    entity.Property(e => e.Grnstatus).HasColumnName("GRNStatus");

            //    entity.Property(e => e.InspectionDate).HasColumnType("datetime");

            //    entity.Property(e => e.Minsno)
            //        .IsRequired()
            //        .HasColumnName("MINSNO")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Mtrmid).HasColumnName("MTRMID");

            //    entity.Property(e => e.Poid).HasColumnName("POID");

            //    entity.HasOne(d => d.Mtrm)
            //        .WithMany(p => p.MmMaterialInspectionMaster)
            //        .HasForeignKey(d => d.Mtrmid)
            //        .HasConstraintName("FK_MM_MaterialInspection_Master_MM_TempReceivingMaster");
            //});

            //modelBuilder.Entity<MmMaterialIssuanceMaster>(entity =>
            //{
            //    entity.HasKey(e => e.Miid);

            //    entity.ToTable("MM_MaterialIssuanceMaster");

            //    entity.Property(e => e.Miid).HasColumnName("MIID");

            //    entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

            //    entity.Property(e => e.ChallanNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.CostCenterId).HasColumnName("CostCenterID");

            //    entity.Property(e => e.IssuanceDate).HasColumnType("datetime");

            //    entity.Property(e => e.IssuanceReceivingPerson)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.LocationId).HasColumnName("LocationID");

            //    entity.Property(e => e.ModelId).HasColumnName("ModelID");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.ReasonId).HasColumnName("ReasonID");
            //});

            //modelBuilder.Entity<MmMaterialReceivingWithOutPomaster>(entity =>
            //{
            //    entity.HasKey(e => e.RecWithOutPoid);

            //    entity.ToTable("MM_MaterialReceivingWithOutPOMaster");

            //    entity.Property(e => e.RecWithOutPoid).HasColumnName("RecWithOutPOID");

            //    entity.Property(e => e.PspoId).HasColumnName("PSPO_ID");

            //    entity.Property(e => e.RecWithOutPodate)
            //        .HasColumnName("RecWithOutPODate")
            //        .HasColumnType("datetime");

            //    entity.HasOne(d => d.Pspo)
            //        .WithMany(p => p.MmMaterialReceivingWithOutPomaster)
            //        .HasForeignKey(d => d.PspoId)
            //        .HasConstraintName("FK_MM_MaterialReceivingWithOutPOMaster_MM_PreSystemPOs");
            //});

            //modelBuilder.Entity<MmMaterialStockOpening>(entity =>
            //{
            //    entity.HasKey(e => e.Msoid);

            //    entity.ToTable("MM_MaterialStockOpening");

            //    entity.Property(e => e.Msoid).HasColumnName("MSOID");

            //    entity.Property(e => e.Obdate)
            //        .HasColumnName("OBDate")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.Status).HasDefaultValueSql("(0)");
            //});

            //modelBuilder.Entity<MmMirallocatedAtHand>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MM_MIRAllocatedAtHand");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.CollectionId).HasColumnName("CollectionID");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.DayId).HasColumnName("DayID");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.ObjectId).HasColumnName("ObjectID");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<MmMiratHand>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MM_MIRAtHand");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.CollectionId).HasColumnName("CollectionID");

            //    entity.Property(e => e.DayId).HasColumnName("DayID");

            //    entity.Property(e => e.IsDeleted).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<MmModelGrossRequirement>(entity =>
            //{
            //    entity.HasKey(e => e.Mgrid);

            //    entity.ToTable("MM_ModelGrossRequirement");

            //    entity.Property(e => e.Mgrid).HasColumnName("MGRID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.ColorSetId).HasColumnName("ColorSetID");

            //    entity.Property(e => e.GrossUnitId).HasColumnName("GrossUnitID");

            //    entity.Property(e => e.ModelId).HasColumnName("ModelID");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.ObjectId).HasColumnName("ObjectID");

            //    entity.Property(e => e.SizeSetId).HasColumnName("SizeSetID");
            //});

            //modelBuilder.Entity<MmModelGrossTransactionLog>(entity =>
            //{
            //    entity.ToTable("MM_ModelGrossTransactionLog");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Ipaddress)
            //        .IsRequired()
            //        .HasColumnName("IPAddress")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.TransactionDate).HasColumnType("datetime");

            //    entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

            //    entity.Property(e => e.UserId)
            //        .IsRequired()
            //        .HasColumnName("UserID")
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .IsFixedLength();
            //});

            //modelBuilder.Entity<MmModelRequisitionAtHandAdjustment>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MM_ModelRequisitionAtHandAdjustment");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.TransactionDate).HasColumnType("datetime");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<MmModelRequisitionAtHandAdjustmentDetail>(entity =>
            //{
            //    entity.ToTable("MM_ModelRequisitionAtHandAdjustment_Detail");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.MasterId).HasColumnName("MasterID");

            //    entity.Property(e => e.ModelId).HasColumnName("ModelID");

            //    entity.Property(e => e.ObjectId).HasColumnName("ObjectID");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");
            //});

            //modelBuilder.Entity<MmModelRequisitionAtHandAdjustmentDetailChild>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MM_ModelRequisitionAtHandAdjustment_DetailChild");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.DetailId).HasColumnName("DetailID");

            //    entity.Property(e => e.Ponumber)
            //        .IsRequired()
            //        .HasColumnName("PONumber")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.HasOne(d => d.Detail)
            //        .WithMany(p => p.MmModelRequisitionAtHandAdjustmentDetailChild)
            //        .HasForeignKey(d => d.DetailId)
            //        .HasConstraintName("FK_MM_ModelRequisitionAtHandAdjustment_DetailChild_MM_ModelRequisitionAtHandAdjustment_Detail");
            //});

            //modelBuilder.Entity<MmModelRequisitionMaster>(entity =>
            //{
            //    entity.HasKey(e => e.Mrmid);

            //    entity.ToTable("MM_ModelRequisitionMaster");

            //    entity.Property(e => e.Mrmid).HasColumnName("MRMID");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.Ipaddress)
            //        .HasColumnName("IPAddress")
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.IsPresumption).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.ModelId).HasColumnName("ModelID");

            //    entity.Property(e => e.Mrmno)
            //        .IsRequired()
            //        .HasColumnName("MRMNo")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Status).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<MmModelRequisitionRequirement>(entity =>
            //{
            //    entity.HasKey(e => e.Mrrid);

            //    entity.ToTable("MM_ModelRequisitionRequirement");

            //    entity.Property(e => e.Mrrid).HasColumnName("MRRID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.ColorSetId).HasColumnName("ColorSetID");

            //    entity.Property(e => e.Mgrid).HasColumnName("MGRID");

            //    entity.Property(e => e.ModelId).HasColumnName("ModelID");

            //    entity.Property(e => e.Mrmid).HasColumnName("MRMID");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.ObjectId).HasColumnName("ObjectID");

            //    entity.Property(e => e.SizeSetId).HasColumnName("SizeSetID");

            //    entity.Property(e => e.SpecialComments)
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Status).HasDefaultValueSql("(0)");

            //    entity.HasOne(d => d.Mrm)
            //        .WithMany(p => p.MmModelRequisitionRequirement)
            //        .HasForeignKey(d => d.Mrmid)
            //        .OnDelete(DeleteBehavior.Cascade)
            //        .HasConstraintName("FK_MM_ModelRequisitionRequirement_MM_ModelRequisitionMaster");
            //});

            //modelBuilder.Entity<MmModelRequistionRequirementTemp>(entity =>
            //{
            //    entity.HasKey(e => e.Mrrid);

            //    entity.ToTable("MM_ModelRequistionRequirementTEMP");

            //    entity.Property(e => e.Mrrid).HasColumnName("MRRID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.ColorSetId).HasColumnName("ColorSetID");

            //    entity.Property(e => e.ModelId).HasColumnName("ModelID");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.ObjectId).HasColumnName("ObjectID");

            //    entity.Property(e => e.SizeSetId).HasColumnName("SizeSetID");
            //});

            //modelBuilder.Entity<MmMrpgrossUnit>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MM_MRPGrossUnit");

            //    entity.Property(e => e.GrossUnitId).HasColumnName("GrossUnitID");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.HasOne(d => d.MrpitemCodeNavigation)
            //        .WithMany(p => p.MmMrpgrossUnit)
            //        .HasForeignKey(d => d.MrpitemCode)
            //        .HasConstraintName("FK_MM_MRPGrossUnit_MM_MRPItem");
            //});

            //modelBuilder.Entity<MmMrpitem>(entity =>
            //{
            //    entity.HasKey(e => e.MrpitemCode)
            //        .HasName("PK_Material");

            //    entity.ToTable("MM_MRPItem");

            //    entity.Property(e => e.MrpitemCode)
            //        .HasColumnName("MRPItemCode")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.AgencyId)
            //        .HasColumnName("AgencyID")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.IsCrp).HasColumnName("IsCRP");

            //    entity.Property(e => e.IsIop).HasColumnName("IsIOP");

            //    entity.Property(e => e.IssueUnit)
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.LeadTimeFormulaId).HasColumnName("LeadTimeFormulaID");

            //    entity.Property(e => e.LoadFormulaId).HasColumnName("LoadFormulaID");

            //    entity.Property(e => e.Mname)
            //        .IsRequired()
            //        .HasColumnName("MName")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OperationName)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PurchaseUnit)
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Sku).HasColumnName("SKU");

            //    entity.Property(e => e.WastageFormulaId).HasColumnName("WastageFormulaID");
            //});

            //modelBuilder.Entity<MmMrpitemAttributeInstance>(entity =>
            //{
            //    entity.HasKey(e => e.AttributeInstanceId)
            //        .HasName("PK_AttributeInstance");

            //    entity.ToTable("MM_MRPItemAttributeInstance");

            //    entity.Property(e => e.AttributeInstanceId)
            //        .HasColumnName("AttributeInstanceID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.Adesc)
            //        .HasColumnName("ADesc")
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.AttributesXml)
            //        .HasColumnName("AttributesXML")
            //        .HasMaxLength(8000)
            //        .IsUnicode(false);

            //    entity.Property(e => e.MovingAverage).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.ValueDescription)
            //        .HasMaxLength(8000)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<MmMrpitemAttributeSet>(entity =>
            //{
            //    entity.HasKey(e => e.MattributeId)
            //        .HasName("PK_MaterialAttribute");

            //    entity.ToTable("MM_MRPItemAttributeSet");

            //    entity.Property(e => e.MattributeId).HasColumnName("MAttributeID");

            //    entity.Property(e => e.AttributeId).HasColumnName("AttributeID");

            //    entity.Property(e => e.DefaultValue)
            //        .HasMaxLength(1000)
            //        .IsUnicode(false);

            //    entity.Property(e => e.IsHighLevel).HasComment("For display in all areas");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.HasOne(d => d.Attribute)
            //        .WithMany(p => p.MmMrpitemAttributeSet)
            //        .HasForeignKey(d => d.AttributeId)
            //        .HasConstraintName("FK_MaterialAttribute_Attribute");

            //    entity.HasOne(d => d.MrpitemCodeNavigation)
            //        .WithMany(p => p.MmMrpitemAttributeSet)
            //        .HasForeignKey(d => d.MrpitemCode)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_MM_MRPItemAttributeSet_MM_MRPItem");
            //});

            //modelBuilder.Entity<MmMrpitemAttributeSetValues>(entity =>
            //{
            //    entity.HasKey(e => e.Mavid)
            //        .HasName("PK_MaterialAttributeValues");

            //    entity.ToTable("MM_MRPItemAttributeSetValues");

            //    entity.HasIndex(e => e.AttributeInstanceId)
            //        .HasName("Ind_MM_MRPItemAttributeSetValues_!");

            //    entity.Property(e => e.Mavid).HasColumnName("MAVID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.MattributeId).HasColumnName("MAttributeID");

            //    entity.Property(e => e.MavalueDescription)
            //        .HasColumnName("MAValueDescription")
            //        .HasMaxLength(1000)
            //        .IsUnicode(false);

            //    entity.Property(e => e.MavalueId)
            //        .IsRequired()
            //        .HasColumnName("MAValueID")
            //        .HasMaxLength(1000)
            //        .IsUnicode(false);

            //    entity.HasOne(d => d.AttributeInstance)
            //        .WithMany(p => p.MmMrpitemAttributeSetValues)
            //        .HasForeignKey(d => d.AttributeInstanceId)
            //        .HasConstraintName("FK_MaterialAttributeValues_AttributeInstance");

            //    entity.HasOne(d => d.Mattribute)
            //        .WithMany(p => p.MmMrpitemAttributeSetValues)
            //        .HasForeignKey(d => d.MattributeId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_MM_MRPItemAttributeSetValues_MM_MRPItemAttributeSet");
            //});

            //modelBuilder.Entity<MmMrpitemCriteria>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MM_MRPItem_Criteria");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.MrpitemCriteriaId).HasColumnName("MRPItemCriteriaID");
            //});

            //modelBuilder.Entity<MmMrpitemCriteriaSetup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MM_MRPItem_Criteria_Setup");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.MrpitemCriteriaId)
            //        .HasColumnName("MRPItemCriteriaID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<MmMrpitemMasterAttribute>(entity =>
            //{
            //    entity.HasKey(e => e.AttributeId)
            //        .HasName("PK_Attribute");

            //    entity.ToTable("MM_MRPItemMasterAttribute");

            //    entity.Property(e => e.AttributeId).HasColumnName("AttributeID");

            //    entity.Property(e => e.Aname)
            //        .IsRequired()
            //        .HasColumnName("AName")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<MmMrpitemUnits>(entity =>
            //{
            //    entity.HasKey(e => e.MrpitemUnitId)
            //        .HasName("PK_MRPItemUnits");

            //    entity.ToTable("MM_MRPItemUnits");

            //    entity.Property(e => e.MrpitemUnitId).HasColumnName("MRPItemUnitID");

            //    entity.Property(e => e.ConversiontoSku).HasColumnName("ConversiontoSKU");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.MrpunitsId).HasColumnName("MRPUnitsID");

            //    entity.HasOne(d => d.Mrpunits)
            //        .WithMany(p => p.MmMrpitemUnits)
            //        .HasForeignKey(d => d.MrpunitsId)
            //        .HasConstraintName("FK_MRPItemUnits_MRPUnits");
            //});

            //modelBuilder.Entity<MmMrpunits>(entity =>
            //{
            //    entity.HasKey(e => e.MrpunitsId)
            //        .HasName("PK_Unit");

            //    entity.ToTable("MM_MRPUnits");

            //    entity.Property(e => e.MrpunitsId)
            //        .HasColumnName("MRPUnitsID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.UnitDatatype).HasComment("1. Integer, 2. Float");

            //    entity.Property(e => e.UnitDesc)
            //        .IsRequired()
            //        .HasMaxLength(100)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<MmOutGatePassDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MM_OutGatePassDetail");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.OutGatePassId).HasColumnName("OutGatePassID");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");
            //});

            //modelBuilder.Entity<MmOutGatePassMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MM_OutGatePassMaster");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.OutGatePassDate).HasColumnType("datetime");

            //    entity.Property(e => e.OutGatePassId)
            //        .HasColumnName("OutGatePassID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.PersonName)
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Poid).HasColumnName("POID");

            //    entity.Property(e => e.Rsmid).HasColumnName("RSMID");

            //    entity.Property(e => e.VehicleNo)
            //        .IsRequired()
            //        .HasMaxLength(20)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<MmPartialRequisitionDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MM_PartialRequisition_Detail");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.ModelId).HasColumnName("ModelID");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.MrpitemName)
            //        .HasColumnName("MRPItemName")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ReqDetailId)
            //        .HasColumnName("ReqDetailID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.ReqMasterId).HasColumnName("ReqMasterID");

            //    entity.Property(e => e.ReqQuantity).HasColumnType("decimal(18, 4)");

            //    entity.Property(e => e.SizeRearks)
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");
            //});

            //modelBuilder.Entity<MmPartialRequisitionMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MM_PartialRequisition_Master");

            //    entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.CostCentreId).HasColumnName("CostCentreID");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.LocationId).HasColumnName("LocationID");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.ReqDate).HasColumnType("smalldatetime");

            //    entity.Property(e => e.SubLocation)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<MmPaymentMode>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MM_PaymentMode");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.PaymentMode)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<MmPaymentTerm>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MM_PaymentTerm");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.PaymentModeId).HasColumnName("PaymentModeID");

            //    entity.Property(e => e.PaymentTerm)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<MmPermanentReceivingMaster>(entity =>
            //{
            //    entity.HasKey(e => e.PermRecMid);

            //    entity.ToTable("MM_PermanentReceivingMaster");

            //    entity.Property(e => e.PermRecMid).HasColumnName("PermRecMID");

            //    entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.Flag)
            //        .HasColumnName("flag")
            //        .HasDefaultValueSql("((1))");

            //    entity.Property(e => e.Mimid).HasColumnName("MIMID");

            //    entity.Property(e => e.PermRecDate).HasColumnType("datetime");

            //    entity.Property(e => e.PermRecNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Poid).HasColumnName("POID");

            //    entity.HasOne(d => d.Mim)
            //        .WithMany(p => p.MmPermanentReceivingMaster)
            //        .HasForeignKey(d => d.Mimid)
            //        .HasConstraintName("FK_MM_PermanentReceivingMaster_MM_MaterialInspection_Master");
            //});

            //modelBuilder.Entity<MmPreSystemPos>(entity =>
            //{
            //    entity.HasKey(e => e.PspoId);

            //    entity.ToTable("MM_PreSystemPOs");

            //    entity.Property(e => e.PspoId).HasColumnName("PSPO_ID");

            //    entity.Property(e => e.ContactPerson)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DeliveryChallanDate).HasColumnType("datetime");

            //    entity.Property(e => e.DeliveryChallanNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.InvoiceNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.Podate)
            //        .HasColumnName("PODate")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.Pono)
            //        .IsRequired()
            //        .HasColumnName("PONo")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

            //    entity.Property(e => e.VehicleNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<MmReasonSetup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MM_Reason_Setup");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<MmReportGateReceiving>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MM_Report_GateReceiving");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.DeliveryChallan)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

            //    entity.Property(e => e.DeliveryPerson)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Grdid).HasColumnName("GRDID");

            //    entity.Property(e => e.Grid).HasColumnName("GRID");

            //    entity.Property(e => e.Grno)
            //        .IsRequired()
            //        .HasColumnName("GRno")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ObjectId).HasColumnName("ObjectID");

            //    entity.Property(e => e.Poid).HasColumnName("POID");

            //    entity.Property(e => e.VehicleNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<MmReportMaterialsInspection>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MM_Report_materialsInspection");

            //    entity.Property(e => e.DeliveryChallan)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

            //    entity.Property(e => e.DeliveryPerson)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Grid).HasColumnName("GRID");

            //    entity.Property(e => e.Grno).HasColumnName("GRNO");

            //    entity.Property(e => e.InspectionDate).HasColumnType("datetime");

            //    entity.Property(e => e.Mimid).HasColumnName("MIMID");

            //    entity.Property(e => e.Minsno).HasColumnName("MINSNO");

            //    entity.Property(e => e.Mtrmid).HasColumnName("MTRMID");

            //    entity.Property(e => e.Poid).HasColumnName("POID");

            //    entity.Property(e => e.TempRecDate).HasColumnType("datetime");

            //    entity.Property(e => e.Tgrno).HasColumnName("TGRNo");

            //    entity.Property(e => e.VehicleNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<MmReportPermanentReceiving>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MM_Report_PermanentReceiving");

            //    entity.Property(e => e.DeliveryChallan)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

            //    entity.Property(e => e.DelvieryPerson)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Grid).HasColumnName("GRID");

            //    entity.Property(e => e.Grno).HasColumnName("GRno");

            //    entity.Property(e => e.InspectionDate).HasColumnType("datetime");

            //    entity.Property(e => e.Mimid).HasColumnName("MIMID");

            //    entity.Property(e => e.Minsno).HasColumnName("MINSNO");

            //    entity.Property(e => e.Mtrmid).HasColumnName("MTRMID");

            //    entity.Property(e => e.PermRecDate).HasColumnType("datetime");

            //    entity.Property(e => e.PermRecMid).HasColumnName("PermRecMID");

            //    entity.Property(e => e.Poid).HasColumnName("POID");

            //    entity.Property(e => e.TempRecDate).HasColumnType("datetime");

            //    entity.Property(e => e.Tgrno).HasColumnName("TGRNo");

            //    entity.Property(e => e.VehicleNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<MmReportRecWithOutPo>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MM_Report_RecWithOutPO");

            //    entity.Property(e => e.DeliveryChallanDate).HasColumnType("datetime");

            //    entity.Property(e => e.DeliveryChallanNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.InvoiceNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.Podate)
            //        .HasColumnName("PODate")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.Pono).HasColumnName("PONo");

            //    entity.Property(e => e.PspoId).HasColumnName("PSPO_ID");

            //    entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

            //    entity.Property(e => e.VehicleNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<MmReportStockTransactions>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MM_Report_StockTransactions");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.BuyerName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DocumentDate).HasColumnType("datetime");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.ModelNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Mrpname)
            //        .IsRequired()
            //        .HasColumnName("MRPName")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OrderNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.RateWrtbaseUnit).HasColumnName("Rate_WRTbaseUnit");

            //    entity.Property(e => e.StoreLocationName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StoreName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<MmReportTempReceiving>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MM_Report_TempReceiving");

            //    entity.Property(e => e.DeliveryChallan)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

            //    entity.Property(e => e.DeliveryPerson)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Grid).HasColumnName("GRID");

            //    entity.Property(e => e.Grno)
            //        .IsRequired()
            //        .HasColumnName("GRNo")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Mtrmid).HasColumnName("MTRMID");

            //    entity.Property(e => e.Poid).HasColumnName("POID");

            //    entity.Property(e => e.TempRecDate).HasColumnType("datetime");

            //    entity.Property(e => e.Tgrno)
            //        .IsRequired()
            //        .HasColumnName("TGRNo")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.VehicleNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<MmReturnFromFloorMaster>(entity =>
            //{
            //    entity.HasKey(e => e.Rffid);

            //    entity.ToTable("MM_ReturnFromFloorMaster");

            //    entity.Property(e => e.Rffid).HasColumnName("RFFID");

            //    entity.Property(e => e.Miid).HasColumnName("MIID");

            //    entity.Property(e => e.Remarks)
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.HasOne(d => d.Mi)
            //        .WithMany(p => p.MmReturnFromFloorMaster)
            //        .HasForeignKey(d => d.Miid)
            //        .OnDelete(DeleteBehavior.Cascade)
            //        .HasConstraintName("FK_MM_ReturnFromFloorMaster_MM_MaterialIssuanceMaster");
            //});

            //modelBuilder.Entity<MmReturnToSupplierMaster>(entity =>
            //{
            //    entity.HasKey(e => e.Rsmid);

            //    entity.ToTable("MM_ReturnToSupplier_Master");

            //    entity.Property(e => e.Rsmid).HasColumnName("RSMID");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.Rsmno)
            //        .IsRequired()
            //        .HasColumnName("RSMNO")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<MmReturnToSupplierMaster1>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MM_ReturnToSupplierMaster");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.Poid).HasColumnName("POID");

            //    entity.Property(e => e.Rsmid)
            //        .HasColumnName("RSMID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<MmStatusSetup>(entity =>
            //{
            //    entity.ToTable("MM_Status_Setup");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<MmStockTransactions>(entity =>
            //{
            //    entity.HasKey(e => e.StockTransactionId)
            //        .HasName("PK_StockTransactions");

            //    entity.ToTable("MM_StockTransactions");

            //    entity.Property(e => e.StockTransactionId).HasColumnName("StockTransactionID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

            //    entity.Property(e => e.BuyerId).HasColumnName("BuyerID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.DocumentDate).HasColumnType("datetime");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.ModelId).HasColumnName("ModelID");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.OldStoreLocationId).HasColumnName("OldStoreLocationID");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.RateWrtbaseUnit).HasColumnName("Rate_WRTbaseUnit");

            //    entity.Property(e => e.StoreLocationId).HasColumnName("StoreLocationID");

            //    entity.Property(e => e.TransactionDate).HasColumnType("datetime");
            //});

            //modelBuilder.Entity<MmStoreCategoryRelation>(entity =>
            //{
            //    entity.ToTable("MM_StoreCategoryRelation");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.StoreCategoryId).HasColumnName("StoreCategoryID");

            //    entity.Property(e => e.StoreId).HasColumnName("StoreID");

            //    entity.HasOne(d => d.StoreCategory)
            //        .WithMany(p => p.MmStoreCategoryRelation)
            //        .HasForeignKey(d => d.StoreCategoryId)
            //        .HasConstraintName("FK_MM_StoreCategoryRelation_StoreCategory_Setup");

            //    entity.HasOne(d => d.Store)
            //        .WithMany(p => p.MmStoreCategoryRelation)
            //        .HasForeignKey(d => d.StoreId)
            //        .HasConstraintName("FK_MM_StoreCategoryRelation_Store_Setup");
            //});

            //modelBuilder.Entity<MmStoreCategorySetup>(entity =>
            //{
            //    entity.HasKey(e => e.StoreCategoryId)
            //        .HasName("PK_StoreCategory_Setup");

            //    entity.ToTable("MM_StoreCategory_Setup");

            //    entity.Property(e => e.StoreCategoryId).HasColumnName("StoreCategoryID");

            //    entity.Property(e => e.Sccode)
            //        .IsRequired()
            //        .HasColumnName("SCCode")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Scdescription)
            //        .IsRequired()
            //        .HasColumnName("SCDescription")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Scname)
            //        .IsRequired()
            //        .HasColumnName("SCName")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<MmStoreLocationTransferMaster>(entity =>
            //{
            //    entity.HasKey(e => e.MtransferId);

            //    entity.ToTable("MM_StoreLocationTransferMaster");

            //    entity.Property(e => e.MtransferId).HasColumnName("MTransferID");

            //    entity.Property(e => e.MtransferDate)
            //        .HasColumnName("MTransferDate")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.MtransferNo)
            //        .HasColumnName("MTransferNo")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<MmStoreLocationTypesSetup>(entity =>
            //{
            //    entity.HasKey(e => e.LocTypeId);

            //    entity.ToTable("MM_StoreLocationTypes_Setup");

            //    entity.Property(e => e.LocTypeId).HasColumnName("LocTypeID");

            //    entity.Property(e => e.LocationTypeDesc)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.LocationtypeName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<MmStoreLocationsSetup>(entity =>
            //{
            //    entity.HasKey(e => e.StoreLocationId)
            //        .HasName("PK_StoreLocations_Setup");

            //    entity.ToTable("MM_StoreLocations_Setup");

            //    entity.Property(e => e.StoreLocationId).HasColumnName("StoreLocationID");

            //    entity.Property(e => e.Height)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Length)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.LocTypeId).HasColumnName("LocTypeID");

            //    entity.Property(e => e.Sldescription)
            //        .HasColumnName("SLDescription")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Slname)
            //        .IsRequired()
            //        .HasColumnName("SLName")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StoreId).HasColumnName("StoreID");

            //    entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

            //    entity.Property(e => e.UnitId)
            //        .HasColumnName("UnitID")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Width)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.HasOne(d => d.LocType)
            //        .WithMany(p => p.MmStoreLocationsSetup)
            //        .HasForeignKey(d => d.LocTypeId)
            //        .HasConstraintName("FK_MM_StoreLocations_Setup_MM_StoreLocationTypes_Setup");

            //    entity.HasOne(d => d.Store)
            //        .WithMany(p => p.MmStoreLocationsSetup)
            //        .HasForeignKey(d => d.StoreId)
            //        .HasConstraintName("FK_StoreLocations_Setup_Store_Setup");
            //});

            //modelBuilder.Entity<MmStoreSetup>(entity =>
            //{
            //    entity.HasKey(e => e.StoreId)
            //        .HasName("PK_Store_Setup");

            //    entity.ToTable("MM_Store_Setup");

            //    entity.Property(e => e.StoreId).HasColumnName("StoreID");

            //    entity.Property(e => e.Address)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ContactNo)
            //        .HasColumnName("ContactNO")
            //        .HasMaxLength(25)
            //        .IsUnicode(false);

            //    entity.Property(e => e.IsMainStore).HasDefaultValueSql("((1))");

            //    entity.Property(e => e.ParentStoreId).HasColumnName("ParentStoreID");

            //    entity.Property(e => e.Scode)
            //        .IsRequired()
            //        .HasColumnName("SCode")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StoreDescription)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StoreName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StoreShortName)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<MmTempReceivingMaster>(entity =>
            //{
            //    entity.HasKey(e => e.Mtrmid);

            //    entity.ToTable("MM_TempReceivingMaster");

            //    entity.Property(e => e.Mtrmid).HasColumnName("MTRMID");

            //    entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.Flag)
            //        .HasColumnName("flag")
            //        .HasDefaultValueSql("(1)");

            //    entity.Property(e => e.Grid).HasColumnName("GRID");

            //    entity.Property(e => e.Poid).HasColumnName("POID");

            //    entity.Property(e => e.TempRecDate).HasColumnType("datetime");

            //    entity.Property(e => e.Tgrno)
            //        .IsRequired()
            //        .HasColumnName("TGRNo")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.HasOne(d => d.Gr)
            //        .WithMany(p => p.MmTempReceivingMaster)
            //        .HasForeignKey(d => d.Grid)
            //        .HasConstraintName("FK_MM_TempReceivingMaster_MM_GateReceiving");
            //});

            //modelBuilder.Entity<MmTempTable>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MM_TempTable");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");
            //});

            //modelBuilder.Entity<MmTrimName>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MM_TrimName");

            //    entity.Property(e => e.Creationdate)
            //        .HasColumnName("creationdate")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Status)
            //        .HasColumnName("status")
            //        .HasDefaultValueSql("((1))");

            //    entity.Property(e => e.TrimId)
            //        .HasColumnName("TrimID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.TrimName)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<MmUnitConversionSetup>(entity =>
            //{
            //    entity.ToTable("MM_UnitConversion_Setup");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ConversionFormula).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.ConvertedUnitId).HasColumnName("ConvertedUnitID");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");
            //});

            //modelBuilder.Entity<MmUserBusinessAssociation>(entity =>
            //{
            //    entity.ToTable("MM_User_Business_Association");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<MmValuationClass>(entity =>
            //{
            //       entity.HasNoKey();

            //    entity.ToTable("MM_ValuationClass");

            //    entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

            //    entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

            //    entity.Property(e => e.ClassName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.CostCentreId).HasColumnName("CostCentreID");

            //    entity.Property(e => e.LocationId).HasColumnName("LocationID");

            //    entity.Property(e => e.ParentId).HasColumnName("ParentID");
            //  });

            //modelBuilder.Entity<MmreportsSetup>(entity =>
            //{
            //    entity.HasKey(e => e.MmreportId);

            //    entity.ToTable("MMReports_Setup");

            //    entity.Property(e => e.MmreportId)
            //        .HasColumnName("MMReportID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.MmreportName)
            //        .IsRequired()
            //        .HasColumnName("MMReportName")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<ModuleSetup>(entity =>
            //{
            //    entity.HasKey(e => e.ModuleId);

            //    entity.ToTable("Module_Setup");

            //    entity.Property(e => e.ModuleId).HasColumnName("ModuleID");

            //    entity.Property(e => e.ModuleDescription)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ModuleName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<MuMenu>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MU_Menu");

            //    entity.Property(e => e.MenuId).HasColumnName("MenuID");

            //    entity.Property(e => e.MenuName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<MuMenuItem>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MU_MenuItem");

            //    entity.Property(e => e.LevelId).HasColumnName("LevelID");

            //    entity.Property(e => e.MenuId).HasColumnName("MenuID");

            //    entity.Property(e => e.MenuItemId)
            //        .HasColumnName("MenuItemID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.MenuItemName)
            //        .IsRequired()
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.PageId).HasColumnName("PageID");

            //    entity.Property(e => e.ParentMenuItemId).HasColumnName("ParentMenuItemID");
            //});

            //modelBuilder.Entity<MuModule>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MU_Module");

            //    entity.Property(e => e.ModuleId)
            //        .HasColumnName("ModuleID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.ModuleLink)
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ModuleName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ParentId).HasColumnName("ParentID");
            //});

            //modelBuilder.Entity<MuPage>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MU_Page");

            //    entity.Property(e => e.ModuleId).HasColumnName("ModuleID");

            //    entity.Property(e => e.PageId)
            //        .HasColumnName("PageID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.PageLink)
            //        .IsRequired()
            //        .HasMaxLength(500)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PageName)
            //        .IsRequired()
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PageTypeId).HasColumnName("PageTypeID");
            //});

            //modelBuilder.Entity<MuPageType>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MU_PageType");

            //    entity.Property(e => e.PageTypeId).HasColumnName("PageTypeID");

            //    entity.Property(e => e.PageTypeName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<MuUser>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MU_User");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.LoginId)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PinCode)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserGroupId).HasColumnName("UserGroupID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.Property(e => e.UserName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<MuUserGroup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MU_UserGroup");

            //    entity.Property(e => e.UserGroupId).HasColumnName("UserGroupID");

            //    entity.Property(e => e.UserGroupName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<MuUserPages>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("MU_UserPages");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.MenuId).HasColumnName("MenuID");

            //    entity.Property(e => e.PageId).HasColumnName("PageID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<OpSubOps>(entity =>
            //{
            //    entity.ToTable("OP_SubOPs");

            //    entity.Property(e => e.OpSubOpsId).HasColumnName("OP_SubOPs_ID");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.PageLink)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SubOpid).HasColumnName("SubOPID");

            //    entity.HasOne(d => d.SubOp)
            //        .WithMany(p => p.OpSubOps)
            //        .HasForeignKey(d => d.SubOpid)
            //        .HasConstraintName("FK_OP_SubOPs_SubOperations_Setup");
            //});

            //modelBuilder.Entity<PackingListByContainerView>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("PackingListByContainer_View");

            //    entity.Property(e => e.Color)
            //        .IsRequired()
            //        .HasMaxLength(5)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ContainerNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CustomerCode)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Delivery)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DestinationCode)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.InvoiceNo)
            //        .IsRequired()
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Model)
            //        .IsRequired()
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OrderNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Size)
            //        .IsRequired()
            //        .HasMaxLength(5)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<PoCancelLog>(entity =>
            //{
            //    entity.ToTable("PO_CancelLog");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.CancellationDate)
            //        .HasColumnName("Cancellation Date")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.PoType).HasColumnName("PO Type");

            //    entity.Property(e => e.Poid).HasColumnName("POID");
            //});

            //modelBuilder.Entity<PrintWorkOrder>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Print Work Order");

            //    entity.Property(e => e.BuyerName)
            //        .HasColumnName("Buyer Name")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Color)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DeliveryDate)
            //        .HasColumnName("Delivery Date")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.FabricComposition)
            //        .HasColumnName("Fabric Composition")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.MeasurementUnit).HasColumnName("Measurement Unit");

            //    entity.Property(e => e.OrderNumber)
            //        .HasColumnName("Order Number")
            //        .HasMaxLength(2000)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PrintQty).HasColumnName("Print Qty");

            //    entity.Property(e => e.PrintRate)
            //        .HasColumnName("Print Rate")
            //        .HasColumnType("decimal(20, 3)");

            //    entity.Property(e => e.PrintType)
            //        .HasColumnName("Print Type")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SupplierName)
            //        .HasColumnName("Supplier Name")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<QrmMmUnitMapping>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("QRM_MM_UnitMapping");

            //    entity.Property(e => e.MeasurementScaleId).HasColumnName("MeasurementScaleID");

            //    entity.Property(e => e.MrpunitsId).HasColumnName("MRPUnitsID");
            //});

            //modelBuilder.Entity<Results>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.Property(e => e.ComboId).HasColumnName("ComboID");

            //    entity.Property(e => e.Size).HasMaxLength(255);

            //    entity.Property(e => e.Style).HasMaxLength(255);
            //});

            //modelBuilder.Entity<Sheet1>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Sheet1$");

            //    entity.Property(e => e.Ait).HasColumnName("AIT");

            //    entity.Property(e => e.Atv).HasColumnName("ATV");

            //    entity.Property(e => e.Cd).HasColumnName("CD");

            //    entity.Property(e => e.Classification).HasMaxLength(255);

            //    entity.Property(e => e.HscodeEffective)
            //        .HasColumnName("HSCODE (Effective)")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.ItemDescription)
            //        .HasColumnName("Item Description")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.ItemId).HasColumnName("ItemID");

            //    entity.Property(e => e.Rd).HasColumnName("RD");

            //    entity.Property(e => e.Sd).HasColumnName("SD");

            //    entity.Property(e => e.Ttl).HasColumnName("TTL");

            //    entity.Property(e => e.Type).HasMaxLength(255);

            //    entity.Property(e => e.Vat).HasColumnName("VAT");
            //});

            //modelBuilder.Entity<SubModule_Setup>(entity =>
            //{
            //    entity.HasNoKey();
            //    //entity.HasKey(e => e.SubModuleId);

            //    //entity.ToTable("SubModule_Setup");

            //    //entity.Property(e => e.SubModuleId).HasColumnName("SubModuleID");

            //    //entity.Property(e => e.ModuleId).HasColumnName("ModuleID");

            //    //entity.Property(e => e.SubModuleName)
            //    //    .IsRequired()
            //    //    .HasMaxLength(50)
            //    //    .IsUnicode(false);

            //    entity.HasOne(d => d.Module_Setup)
            //        .WithMany(p => p.SubModule_Setup)
            //        .HasForeignKey(d => d.ModuleID)
            //        .HasConstraintName("FK_SubModule_Setup_Module_Setup");
            //});

            //modelBuilder.Entity<SubOperationsSetup>(entity =>
            //{
            //    entity.HasKey(e => e.SubOpid);

            //    entity.ToTable("SubOperations_Setup");

            //    entity.Property(e => e.SubOpid)
            //        .HasColumnName("SubOPID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.SubOpName)
            //        .IsRequired()
            //        .HasColumnName("SubOP_name")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SubOpdescription)
            //        .IsRequired()
            //        .HasColumnName("SubOPDescription")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<Table1>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.Property(e => e.FatherSName)
            //        .HasColumnName("[father's name")
            //        .HasMaxLength(10)
            //        .IsFixedLength();

            //    entity.Property(e => e.MotherSName)
            //        .HasColumnName("mother's name")
            //        .HasMaxLength(10)
            //        .IsFixedLength();

            //    entity.Property(e => e.Name)
            //        .HasColumnName("name")
            //        .HasMaxLength(10)
            //        .IsFixedLength();

            //    entity.Property(e => e.Rool)
            //        .HasColumnName("rool")
            //        .HasMaxLength(10)
            //        .IsFixedLength();
            //});

            //modelBuilder.Entity<TblActualData>(entity =>
            //{
            //    entity.ToTable("tbl_ActualData");

            //    entity.HasIndex(e => new { e.WcId, e.Tmonth, e.Tyear, e.Deleted })
            //        .HasName("IX_tbl_ActualData");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Aclc)
            //        .HasColumnName("ACLC")
            //        .HasColumnType("numeric(18, 0)");

            //    entity.Property(e => e.Acoh)
            //        .HasColumnName("ACOH")
            //        .HasColumnType("numeric(18, 0)");

            //    entity.Property(e => e.Acrm)
            //        .HasColumnName("ACRM")
            //        .HasColumnType("numeric(18, 0)");

            //    entity.Property(e => e.Atlc)
            //        .HasColumnName("ATLC")
            //        .HasColumnType("numeric(18, 0)");

            //    entity.Property(e => e.Atoh)
            //        .HasColumnName("ATOH")
            //        .HasColumnType("numeric(18, 0)");

            //    entity.Property(e => e.Atrm)
            //        .HasColumnName("ATRM")
            //        .HasColumnType("numeric(18, 0)");

            //    entity.Property(e => e.Deleted)
            //        .IsRequired()
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.Tmonth).HasColumnName("TMonth");

            //    entity.Property(e => e.Tyear).HasColumnName("TYear");

            //    entity.Property(e => e.WcId).HasColumnName("WC_ID");

            //    entity.Property(e => e.Wuid)
            //        .HasColumnName("WUID")
            //        .HasDefaultValueSql("(1)");
            //});

            //modelBuilder.Entity<TblCostingLog>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_CostingLog");

            //    entity.Property(e => e.CostingData)
            //        .IsRequired()
            //        .HasColumnType("sql_variant");

            //    entity.Property(e => e.CostingDate).HasColumnType("datetime");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.VerNo).ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<TblFlowDailyTransactionLog>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_Flow_DailyTransaction_Log");

            //    entity.HasIndex(e => new { e.FlowId, e.WcId, e.StyleId })
            //        .HasName("IX_tbl_Flow_DailyTransaction_Log_NC")
            //        .IsClustered();

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.FabricCategoryId)
            //        .HasColumnName("FabricCategoryID")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.FlowId).HasColumnName("FlowID");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.QualityId)
            //        .HasColumnName("QualityID")
            //        .HasDefaultValueSql("(1)");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.TransDate).HasColumnType("datetime");

            //    entity.Property(e => e.TransId)
            //        .HasColumnName("TransID")
            //        .HasColumnType("numeric(18, 0)")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.WcId).HasColumnName("WC_ID");
            //});

            //modelBuilder.Entity<TblIndWorkorderApprove>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Tbl_Ind_workorder_approve");

            //    entity.Property(e => e.CreationDate)
            //        .HasColumnName("creation_date")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.UserId).HasColumnName("User_id");

            //    entity.Property(e => e.WorkorderNo).HasColumnName("Workorder_no");
            //});

            //modelBuilder.Entity<TblIndWorkorderDetails>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Tbl_Ind_Workorder_details");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Itemname).IsUnicode(false);

            //    entity.Property(e => e.Quantity)
            //        .HasColumnName("quantity")
            //        .HasColumnType("decimal(18, 4)");

            //    entity.Property(e => e.Sn).HasColumnName("SN");

            //    entity.Property(e => e.Status).HasDefaultValueSql("((1))");

            //    entity.Property(e => e.UnitPrice)
            //        .HasColumnName("unit_price")
            //        .HasColumnType("decimal(18, 4)");

            //    entity.Property(e => e.Unitid).HasColumnName("unitid");

            //    entity.Property(e => e.WorkorderId).HasColumnName("Workorder_ID");
            //});

            //modelBuilder.Entity<TblIndWorkorderMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Tbl_Ind_Workorder_Master");

            //    entity.Property(e => e.Ait)
            //        .HasColumnName("AIT")
            //        .HasColumnType("decimal(18, 4)");

            //    entity.Property(e => e.Body).IsUnicode(false);

            //    entity.Property(e => e.CompanyId).HasColumnName("company_id");

            //    entity.Property(e => e.ContuctPerson)
            //        .HasColumnName("contuctPerson")
            //        .IsUnicode(false);

            //    entity.Property(e => e.CreationDate)
            //        .HasColumnName("creation_date")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Discount)
            //        .HasColumnName("discount")
            //        .HasColumnType("decimal(18, 4)");

            //    entity.Property(e => e.ExRate)
            //        .HasColumnName("Ex_rate")
            //        .HasColumnType("decimal(18, 4)");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Information)
            //        .HasColumnName("information")
            //        .IsUnicode(false);

            //    entity.Property(e => e.Inword)
            //        .HasColumnName("inword")
            //        .IsUnicode(false);

            //    entity.Property(e => e.MobileNo).IsUnicode(false);

            //    entity.Property(e => e.Note).IsUnicode(false);

            //    entity.Property(e => e.PaymentMode).HasColumnName("Payment_mode");

            //    entity.Property(e => e.PaymentTerms).HasColumnName("Payment_Terms");

            //    entity.Property(e => e.Quotation)
            //        .HasMaxLength(250)
            //        .IsUnicode(false);

            //    entity.Property(e => e.QuotationDate)
            //        .HasColumnName("Quotation_date")
            //        .HasColumnType("smalldatetime");

            //    entity.Property(e => e.ServiceName)
            //        .HasColumnName("Service_name")
            //        .IsUnicode(false);

            //    entity.Property(e => e.Subject)
            //        .HasColumnName("subject")
            //        .IsUnicode(false);

            //    entity.Property(e => e.SupplierId).HasColumnName("Supplier_id");

            //    entity.Property(e => e.UserId).HasColumnName("user_id");

            //    entity.Property(e => e.Vat)
            //        .HasColumnName("VAT")
            //        .HasColumnType("decimal(18, 4)");

            //    entity.Property(e => e.WorkorderDate)
            //        .HasColumnName("workorder_date")
            //        .HasColumnType("smalldatetime");

            //    entity.Property(e => e.WorkorderEndDate)
            //        .HasColumnName("workorder_end_date")
            //        .HasColumnType("smalldatetime");
            //});

            //modelBuilder.Entity<TblIndWorkorderTerms>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Tbl_Ind_workorder_terms");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Sn).HasColumnName("SN");

            //    entity.Property(e => e.Terms)
            //        .HasColumnName("terms")
            //        .IsUnicode(false);

            //    entity.Property(e => e.WorkorderId).HasColumnName("workorder_ID");
            //});

            //modelBuilder.Entity<TblIndWorkorderTermsExtra>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Tbl_Ind_workorder_terms_extra");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Sn).HasColumnName("SN");

            //    entity.Property(e => e.TermsExtra)
            //        .HasColumnName("terms_extra")
            //        .IsUnicode(false);

            //    entity.Property(e => e.WorkorderId).HasColumnName("workorder_ID");
            //});

            //modelBuilder.Entity<TblItemAtt>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tblItemAtt");

            //    entity.Property(e => e.Comp183).HasMaxLength(50);

            //    entity.Property(e => e.Comp3684).HasMaxLength(50);
            //});

            //modelBuilder.Entity<TblLotno>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_lotno");

            //    entity.Property(e => e.LotNo)
            //        .HasColumnName("Lot_No")
            //        .HasMaxLength(50);
            //});

            //modelBuilder.Entity<TblMachineType>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Tbl_Machine_Type");

            //    entity.Property(e => e.MachineTypeName)
            //        .HasColumnName("Machine_TypeName")
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.MtypeId)
            //        .HasColumnName("MTypeID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<TblMmmm>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_mmmm");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Name)
            //        .IsRequired()
            //        .HasMaxLength(350)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<TblOrderColorCostingCache>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Tbl_OrderColorCostingCache");

            //    entity.Property(e => e.Color)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");
            //});

            //modelBuilder.Entity<TblPrinting>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_printing");

            //    entity.Property(e => e.ChemicalCost).HasColumnType("decimal(18, 4)");

            //    entity.Property(e => e.CreationDate).HasColumnType("smalldatetime");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.PrintId).HasColumnName("PrintID");

            //    entity.Property(e => e.Rate).HasColumnType("decimal(18, 4)");

            //    entity.Property(e => e.Smv)
            //        .HasColumnName("SMV")
            //        .HasColumnType("decimal(18, 4)");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<TblRollsDelivery>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Tbl_RollsDelivery");

            //    entity.Property(e => e.DcgattributeInstanceId).HasColumnName("DCGAttributeInstanceID");

            //    entity.Property(e => e.Dcid).HasColumnName("DCID");

            //    entity.Property(e => e.Fcompoistion)
            //        .HasColumnName("FCompoistion")
            //        .HasMaxLength(1000)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Fquality)
            //        .HasMaxLength(1000)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Ftype)
            //        .HasMaxLength(1000)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Gsm)
            //        .HasColumnName("GSM")
            //        .HasMaxLength(1000)
            //        .IsUnicode(false);

            //    entity.Property(e => e.IssuanceAgainstDyeingContractDetaiId).HasColumnName("IssuanceAgainstDyeingContractDetaiID");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.PantoneId).HasColumnName("PantoneID");

            //    entity.Property(e => e.PantoneNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Rollid).HasColumnName("rollid");

            //    entity.Property(e => e.Rollno)
            //        .HasColumnName("rollno")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Sno).HasColumnName("SNO");

            //    entity.Property(e => e.StockGattributeInstanceId).HasColumnName("StockGAttributeInstanceID");
            //});

            //modelBuilder.Entity<TblRollsDelivery1>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Tbl_RollsDelivery_1");

            //    entity.Property(e => e.DcgattributeInstanceId).HasColumnName("DCGAttributeInstanceID");

            //    entity.Property(e => e.Dcid).HasColumnName("DCID");

            //    entity.Property(e => e.Fcompoistion)
            //        .HasColumnName("FCompoistion")
            //        .HasMaxLength(1000)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Fquality)
            //        .HasMaxLength(1000)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Ftype)
            //        .HasMaxLength(1000)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Gsm)
            //        .HasColumnName("GSM")
            //        .HasMaxLength(1000)
            //        .IsUnicode(false);

            //    entity.Property(e => e.IssuanceAgainstDyeingContractDetaiId).HasColumnName("IssuanceAgainstDyeingContractDetaiID");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.PantoneId).HasColumnName("PantoneID");

            //    entity.Property(e => e.PantoneNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Rollid).HasColumnName("rollid");

            //    entity.Property(e => e.Rollno)
            //        .HasColumnName("rollno")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Sno).HasColumnName("SNO");

            //    entity.Property(e => e.StockGattributeInstanceId).HasColumnName("StockGAttributeInstanceID");
            //});

            //modelBuilder.Entity<TblStyleCost>(entity =>
            //{
            //    entity.HasKey(e => e.StyleCostId);

            //    entity.ToTable("tbl_StyleCost");

            //    entity.HasIndex(e => new { e.OrderId, e.StyleId })
            //        .HasName("IX_tbl_StyleCost");

            //    entity.Property(e => e.StyleCostId).HasColumnName("StyleCostID");

            //    entity.Property(e => e.IsDel)
            //        .IsRequired()
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.Rdate)
            //        .HasColumnName("RDate")
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.TotalActualCost).HasColumnType("decimal(24, 3)");

            //    entity.Property(e => e.TotalStdCost).HasColumnType("decimal(24, 3)");

            //    entity.Property(e => e.TotalVariance).HasColumnType("decimal(24, 3)");
            //});

            //modelBuilder.Entity<TblStyleCostDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_StyleCostDetail");

            //    entity.HasIndex(e => new { e.StyleCostId, e.WcId })
            //        .HasName("IX_tbl_StyleCostDetail")
            //        .IsClustered();

            //    entity.Property(e => e.PreDeptCost).HasColumnType("decimal(24, 3)");

            //    entity.Property(e => e.StyleCostId).HasColumnName("StyleCostID");

            //    entity.Property(e => e.Variance).HasColumnType("decimal(24, 3)");

            //    entity.Property(e => e.WcId).HasColumnName("WC_ID");

            //    entity.Property(e => e.Wccost)
            //        .HasColumnName("WCCost")
            //        .HasColumnType("decimal(24, 3)");

            //    entity.HasOne(d => d.StyleCost)
            //        .WithMany(p => p.TblStyleCostDetail)
            //        .HasForeignKey(d => d.StyleCostId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_tbl_StyleCostDetail_tbl_StyleCost");
            //});

            //modelBuilder.Entity<TblStyleFabricationValues>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_StyleFabricationValues");

            //    entity.HasIndex(e => e.StyleId)
            //        .HasName("IX_tbl_StyleFabricationValues")
            //        .IsClustered();

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.FabricId).HasColumnName("FabricID");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");
            //});

            //modelBuilder.Entity<TblTemp1>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_Temp1");

            //    entity.Property(e => e.Color)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DeliveryDate)
            //        .HasMaxLength(25)
            //        .IsUnicode(false);

            //    entity.Property(e => e.FabricComposition)
            //        .HasMaxLength(500)
            //        .IsUnicode(false);

            //    entity.Property(e => e.FabricSpecs)
            //        .HasMaxLength(190)
            //        .IsUnicode(false);

            //    entity.Property(e => e.FabricType)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.FinishDelivered).HasColumnName("Finish Delivered");

            //    entity.Property(e => e.FinishQty)
            //        .HasColumnName("Finish Qty")
            //        .HasColumnType("decimal(8, 2)");

            //    entity.Property(e => e.GreigeDelivered).HasColumnName("Greige Delivered");

            //    entity.Property(e => e.Gsm).HasColumnName("GSM");

            //    entity.Property(e => e.KnittingDate)
            //        .HasMaxLength(25)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Order)
            //        .HasColumnName("ORDER")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Quality)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ReceivedUpKd).HasColumnName("Received UP KD");

            //    entity.Property(e => e.SNo).HasColumnName("S No");
            //});

            //modelBuilder.Entity<TblTocheck>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_tocheck");

            //    entity.Property(e => e.Strxml)
            //        .HasColumnName("STRXml")
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<TblWcDailyTransactionLog>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_WC_DailyTransaction_Log");

            //    entity.HasIndex(e => e.TransDate)
            //        .HasName("Trans_Index")
            //        .IsClustered();

            //    entity.HasIndex(e => new { e.WcId, e.OrderId, e.StyleId })
            //        .HasName("IX_tbl_WC_DailyTransaction_Log");

            //    entity.Property(e => e.ColorId).HasColumnName("ColorID");

            //    entity.Property(e => e.ConfirmedQty)
            //        .HasColumnName("Confirmed_Qty")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.DelQty)
            //        .HasColumnName("Del_Qty")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.Deleted)
            //        .IsRequired()
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.FabricCategoryId)
            //        .HasColumnName("FabricCategoryID")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.InsQty)
            //        .HasColumnName("Ins_Qty")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.OrderId)
            //        .HasColumnName("OrderID")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.Qrmrate)
            //        .HasColumnName("QRMRate")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.QualityId)
            //        .HasColumnName("QualityID")
            //        .HasDefaultValueSql("(1)");

            //    entity.Property(e => e.RecQty)
            //        .HasColumnName("Rec_Qty")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.RejQty)
            //        .HasColumnName("Rej_Qty")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.SizeId).HasColumnName("SizeID");

            //    entity.Property(e => e.Smv)
            //        .HasColumnName("SMV")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.StyleId)
            //        .HasColumnName("StyleID")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.StyleValue).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.TransDate)
            //        .HasColumnName("Trans_Date")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.TransId)
            //        .HasColumnName("Trans_ID")
            //        .HasColumnType("numeric(18, 0)")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.WcId).HasColumnName("WC_ID");
            //});

            //modelBuilder.Entity<TblWorkCenterAttributes>(entity =>
            //{
            //    entity.HasKey(e => e.VerNo);

            //    entity.ToTable("tbl_WorkCenterAttributes");

            //    entity.Property(e => e.AppliedRate).HasColumnType("decimal(19, 4)");

            //    entity.Property(e => e.AppliedTime).HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.AvCapacity)
            //        .HasColumnName("Av_Capacity")
            //        .HasDefaultValueSql("(1)");

            //    entity.Property(e => e.AvMinPerDay).HasColumnName("Av_MinPerDay");

            //    entity.Property(e => e.AvStrength).HasColumnName("Av_Strength");

            //    entity.Property(e => e.AvgOverHead)
            //        .HasColumnName("Avg_OverHead")
            //        .HasColumnType("decimal(19, 4)");

            //    entity.Property(e => e.AvgSalary)
            //        .HasColumnName("Avg_Salary")
            //        .HasColumnType("decimal(19, 4)");

            //    entity.Property(e => e.CostVariance).HasColumnType("decimal(19, 4)");

            //    entity.Property(e => e.EDate)
            //        .HasColumnName("eDate")
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.IsActive)
            //        .IsRequired()
            //        .HasDefaultValueSql("(1)");

            //    entity.Property(e => e.MaterialCost)
            //        .HasColumnType("decimal(19, 4)")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.OverheadRate).HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.TMonth)
            //        .HasColumnName("tMonth")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.TYear)
            //        .HasColumnName("tYear")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.Wastage).HasColumnType("decimal(19, 4)");

            //    entity.Property(e => e.WcId).HasColumnName("WC_ID");

            //    entity.Property(e => e.Wuid)
            //        .HasColumnName("WUID")
            //        .HasDefaultValueSql("(1)");
            //});

            //modelBuilder.Entity<TblWorkCenterAttributesDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_WorkCenterAttributes_Detail");

            //    entity.Property(e => e.FabricCategoryId).HasColumnName("FabricCategoryID");

            //    entity.Property(e => e.Wcaid).HasColumnName("WCAID");

            //    entity.HasOne(d => d.Wca)
            //        .WithMany(p => p.TblWorkCenterAttributesDetail)
            //        .HasForeignKey(d => d.Wcaid)
            //        .HasConstraintName("FK_tbl_WorkCenterAttributes_Detail_tbl_WorkCenterAttributes");
            //});

            //modelBuilder.Entity<TblWorkCentre>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_WorkCentre");

            //    entity.Property(e => e.ProcessVal).HasColumnType("numeric(18, 0)");

            //    entity.Property(e => e.WcDescrip)
            //        .HasColumnName("WC_Descrip")
            //        .HasMaxLength(50);

            //    entity.Property(e => e.WcId)
            //        .HasColumnName("WC_ID")
            //        .HasColumnType("numeric(18, 0)")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<TblWorkCentreCostCentres>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_WorkCentre_CostCentres");

            //    entity.Property(e => e.CostCentreId)
            //        .HasColumnName("CostCentreID")
            //        .HasColumnType("numeric(18, 0)");

            //    entity.Property(e => e.WcId)
            //        .HasColumnName("WC_ID")
            //        .HasColumnType("numeric(18, 0)");
            //});

            //modelBuilder.Entity<TblWorkCentreCostingProcess>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_WorkCentreCostingProcess");

            //    entity.Property(e => e.Descrip).HasMaxLength(150);

            //    entity.Property(e => e.Mrpitem)
            //        .HasColumnName("MRPItem")
            //        .HasColumnType("numeric(18, 0)")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.WcId)
            //        .HasColumnName("WC_ID")
            //        .HasColumnType("numeric(18, 0)")
            //        .HasDefaultValueSql("(0)");
            //});

            //modelBuilder.Entity<TblWorkCentreVariance>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_WorkCentreVariance");

            //    entity.Property(e => e.IsDel)
            //        .IsRequired()
            //        .HasColumnName("isDel")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.Labour).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.Material).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.OrderId)
            //        .HasColumnName("OrderID")
            //        .HasColumnType("numeric(18, 0)")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.OverHead).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.StyleId)
            //        .HasColumnName("StyleID")
            //        .HasColumnType("numeric(18, 0)")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.StyleQty).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.TMonth)
            //        .HasColumnName("tMonth")
            //        .HasColumnType("numeric(18, 0)")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.TYear)
            //        .HasColumnName("tYear")
            //        .HasColumnType("numeric(18, 0)")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.TotalWcproduction)
            //        .HasColumnName("TotalWCProduction")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.TotalWcvariance)
            //        .HasColumnName("TotalWCVariance")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.TransNo)
            //        .HasColumnName("Trans_No")
            //        .HasColumnType("numeric(18, 0)")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Variance)
            //        .HasColumnType("money")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.WcId)
            //        .HasColumnName("WC_ID")
            //        .HasColumnType("numeric(18, 0)")
            //        .HasDefaultValueSql("(0)");
            //});

            //modelBuilder.Entity<TblWorkingUnit>(entity =>
            //{
            //    entity.HasKey(e => e.Wuid);

            //    entity.ToTable("tbl_WorkingUnit");

            //    entity.Property(e => e.Wuid).HasColumnName("WUID");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<TblWorkingUnitDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tbl_WorkingUnit_Detail");

            //    entity.Property(e => e.FabricCategoryId).HasColumnName("FabricCategoryID");

            //    entity.Property(e => e.Wuid).HasColumnName("WUID");
            //});

            //modelBuilder.Entity<Temp1>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.Property(e => e.Command)
            //        .HasMaxLength(1000)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ObjectName)
            //        .HasMaxLength(1000)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ObjectType)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<TempOrderSummaryTable>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Temp_OrderSummaryTable");

            //    entity.Property(e => e.CutIss).HasColumnName("Cut_Iss");

            //    entity.Property(e => e.CutProd).HasColumnName("Cut_Prod");

            //    entity.Property(e => e.CutRej).HasColumnName("Cut_Rej");

            //    entity.Property(e => e.FinRec).HasColumnName("Fin_Rec");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.OrderNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ShipBqty).HasColumnName("Ship_BQty");

            //    entity.Property(e => e.ShipQty).HasColumnName("Ship_Qty");

            //    entity.Property(e => e.StIss).HasColumnName("ST_Iss");

            //    entity.Property(e => e.StRec).HasColumnName("ST_Rec");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.StyleName)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<TempPomasterTable>(entity =>
            //{
            //    entity.HasKey(e => e.Poid);

            //    entity.ToTable("tempPOMasterTable");

            //    entity.Property(e => e.Poid)
            //        .HasColumnName("POID")
            //        .ValueGeneratedNever();
            //});

            //modelBuilder.Entity<TempTable5>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.Property(e => e.Irid).HasColumnName("IRID");
            //});

            //modelBuilder.Entity<TempXmlstorage>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("TempXMLStorage");

            //    entity.Property(e => e.AccessTime).HasColumnType("datetime");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Xmldata)
            //        .IsRequired()
            //        .HasColumnName("XMLData")
            //        .HasColumnType("ntext");
            //});

            //modelBuilder.Entity<TempYarnIssue>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("TEMP_Yarn_Issue");

            //    entity.Property(e => e.AtributeInstanceId).HasColumnName("AtributeInstanceID");

            //    entity.Property(e => e.IssuanceTime)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.LotNo)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Rid)
            //        .HasColumnName("RID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.WoattributeInstanceId).HasColumnName("WOAttributeInstanceID");

            //    entity.Property(e => e.Woid).HasColumnName("WOID");

            //    entity.Property(e => e.YarnAttributeInstanceId).HasColumnName("YarnAttributeInstanceID");

            //    entity.Property(e => e.Yknc).HasColumnName("YKNC");
            //});

            //modelBuilder.Entity<UsdataToDelete>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("USDataToDelete");

            //    entity.Property(e => e.Brand).HasMaxLength(255);

            //    entity.Property(e => e.CustomerCode)
            //        .HasColumnName("Customer code")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.CustomerName)
            //        .HasColumnName("customer name")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.DeliveryTheme)
            //        .HasColumnName("Delivery /theme")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.DestinationCode)
            //        .HasColumnName("destination code")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.IdNumer)
            //        .HasColumnName("Id numer")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.OrderDate)
            //        .HasColumnName("order date")
            //        .HasColumnType("smalldatetime");

            //    entity.Property(e => e.OrderNo)
            //        .HasColumnName("Order No#")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.Season).HasMaxLength(255);

            //    entity.Property(e => e.Size).HasMaxLength(255);

            //    entity.Property(e => e.SoldQnt).HasColumnName("Sold Qnt");

            //    entity.Property(e => e.StyleCode)
            //        .HasColumnName("Style code")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.StyleDescription)
            //        .HasColumnName("Style description")
            //        .HasMaxLength(255);
            //});

            //modelBuilder.Entity<VGetAllGetPass>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("V_GetAllGetPass");

            //    entity.Property(e => e.ApprovedBy)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ApprovedById).HasColumnName("ApprovedByID");

            //    entity.Property(e => e.ApprovedDate)
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ApprovedOn).HasColumnType("datetime");

            //    entity.Property(e => e.ApprovedTime)
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CatName)
            //        .IsRequired()
            //        .IsUnicode(false);

            //    entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

            //    entity.Property(e => e.CategoryName)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CreateDate).HasColumnType("datetime");

            //    entity.Property(e => e.CustomerName).IsUnicode(false);

            //    entity.Property(e => e.Date)
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

            //    entity.Property(e => e.DepartmentName).IsUnicode(false);

            //    entity.Property(e => e.GatePassId).HasColumnName("GatePassID");

            //    entity.Property(e => e.IsExpired)
            //        .HasMaxLength(7)
            //        .IsUnicode(false);

            //    entity.Property(e => e.IssuedBy)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.MarkedOutBy)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.MarkedOutById).HasColumnName("MarkedOutByID");

            //    entity.Property(e => e.MarkedOutOn).HasColumnType("datetime");

            //    entity.Property(e => e.Serial)
            //        .IsRequired()
            //        .IsUnicode(false);

            //    entity.Property(e => e.Status)
            //        .IsRequired()
            //        .HasMaxLength(12)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Time)
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.Property(e => e.VehicleNo).IsUnicode(false);
            //});

            //modelBuilder.Entity<VIcReturnableRecieveGatePassDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("V_IC_ReturnableRecieveGatePassDetail");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Qty)
            //        .HasColumnName("qty")
            //        .HasColumnType("decimal(38, 2)");
            //});

            modelBuilder.Entity<ValuationClass>(entity =>
            {
                entity.HasNoKey();

                //    entity.Property(e => e.ActivityId)
                //        .HasColumnName("ActivityID")
                //        .HasDefaultValueSql("(9)");

                //    entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

                //    entity.Property(e => e.ClassName)
                //        .IsRequired()
                //        .HasMaxLength(50)
                //        .IsUnicode(false);

                //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                //    entity.Property(e => e.ContraClassId).HasColumnName("ContraClassID");

                //    entity.Property(e => e.CostCentreId)
                //        .HasColumnName("CostCentreID")
                //        .HasDefaultValueSql("(8)");

                //    entity.Property(e => e.LocationId).HasColumnName("LocationID");

                //    entity.Property(e => e.ParentId).HasColumnName("ParentID");
            });

            //modelBuilder.Entity<ValuationClassBkup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("ValuationClass_bkup");

            //    entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

            //    entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

            //    entity.Property(e => e.ClassName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.ContraClassId).HasColumnName("ContraClassID");

            //    entity.Property(e => e.CostCentreId).HasColumnName("CostCentreID");

            //    entity.Property(e => e.LocationId).HasColumnName("LocationID");

            //    entity.Property(e => e.ParentId).HasColumnName("ParentID");
            //});

            //modelBuilder.Entity<VendorEvaluationDetail>(entity =>
            //{
            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.CriteriaDescription)
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Date)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.EvaluationMasterId).HasColumnName("EvaluationMasterID");
            //});

            //modelBuilder.Entity<VendorEvaluationMaster>(entity =>
            //{
            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.Date).HasColumnType("datetime");

            //    entity.Property(e => e.EvaluationCriteria)
            //        .HasMaxLength(250)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Sequance).HasColumnName("sequance");
            //});

            //modelBuilder.Entity<VendorEvaluationTransaction>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.Property(e => e.Creationdate)
            //        .HasColumnName("creationdate")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.EvaluationDate)
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(CONVERT([varchar](10),getdate(),(101)))");

            //    entity.Property(e => e.EvaluationDetailId).HasColumnName("EvaluationDetailID");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.ItemId)
            //        .HasColumnName("itemID")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<WareHouseStatusView>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("WareHouseStatus_View");

            //    entity.Property(e => e.CartonType)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Color)
            //        .IsRequired()
            //        .HasMaxLength(5)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Customer)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Date).HasColumnType("datetime");

            //    entity.Property(e => e.Delivery)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Destination)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Model)
            //        .IsRequired()
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OrderNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Size)
            //        .IsRequired()
            //        .HasMaxLength(5)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<WdPoDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("WD_PO_Detail");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.PantoneNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PomasterId).HasColumnName("POMasterID");

            //    entity.Property(e => e.ReqSheetId).HasColumnName("ReqSheetID");
            //});

            //modelBuilder.Entity<WoGateReceiving>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("WO_GateReceiving");

            //    entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.DeliveryChallan)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

            //    entity.Property(e => e.DeliveryPerson)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Flag).HasColumnName("flag");

            //    entity.Property(e => e.Grid)
            //        .HasColumnName("GRID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Grno)
            //        .IsRequired()
            //        .HasColumnName("GRNo")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.Property(e => e.VehicleNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Woid).HasColumnName("WOID");
            //});

            //modelBuilder.Entity<WoGateReceivingDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("WO_GateReceivingDetail");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.Grdid)
            //        .HasColumnName("GRDID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Grid).HasColumnName("GRID");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.ObjectId).HasColumnName("ObjectID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.WodetailId).HasColumnName("WODetailID");
            //});

            //modelBuilder.Entity<WoInstructions>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("WO_Instructions");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Instruction)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.WorkOrderId).HasColumnName("WorkOrderID");
            //});

            //modelBuilder.Entity<WoIssuanceMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("WO_IssuanceMaster");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.IssuanceDate).HasColumnType("datetime");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.Property(e => e.Woid).HasColumnName("WOID");
            //});

            //modelBuilder.Entity<WoMaterialInspectionMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("WO_MaterialInspection_Master");

            //    entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.Flag).HasColumnName("flag");

            //    entity.Property(e => e.Grnstatus).HasColumnName("GRNStatus");

            //    entity.Property(e => e.InspectionDate).HasColumnType("datetime");

            //    entity.Property(e => e.Mimid)
            //        .HasColumnName("MIMID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Minsno)
            //        .IsRequired()
            //        .HasColumnName("MINSNO")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Woid).HasColumnName("WOID");

            //    entity.Property(e => e.Wotrmid).HasColumnName("WOTRMID");
            //});

            //modelBuilder.Entity<WoPermanentReceivingMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("WO_PermanentReceivingMaster");

            //    entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.Flag).HasColumnName("flag");

            //    entity.Property(e => e.Mimid).HasColumnName("MIMID");

            //    entity.Property(e => e.PermRecDate).HasColumnType("datetime");

            //    entity.Property(e => e.PermRecMid)
            //        .HasColumnName("PermRecMID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.PermRecNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Status).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.Woid).HasColumnName("WOID");
            //});

            //modelBuilder.Entity<WoStatusChangeHistory>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("WO_StatusChangeHistory");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Date).HasColumnType("datetime");

            //    entity.Property(e => e.DispatchDate).HasColumnType("datetime");

            //    entity.Property(e => e.DispatchTo).HasMaxLength(50);

            //    entity.Property(e => e.DispatchTypeId).HasColumnName("DispatchTypeID");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.ReasonId).HasColumnName("ReasonID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.Property(e => e.WorkOrderId).HasColumnName("WorkOrderID");
            //});

            //modelBuilder.Entity<WoStatusSetup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("WO_Status_Setup");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.UsedFor)
            //        .IsRequired()
            //        .HasMaxLength(250)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<WoTempReceivingMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("WO_TempReceivingMaster");

            //    entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.Flag).HasColumnName("flag");

            //    entity.Property(e => e.Grid).HasColumnName("GRID");

            //    entity.Property(e => e.TempRecDate).HasColumnType("datetime");

            //    entity.Property(e => e.Tgrno)
            //        .IsRequired()
            //        .HasColumnName("TGRNO")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Woid).HasColumnName("WOID");

            //    entity.Property(e => e.Wotrmid)
            //        .HasColumnName("WOTRMID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<WoWorkOrder>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("WO_WorkOrder");

            //    entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.ContactPersonId).HasColumnName("ContactPersonID");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.OriginalPoid).HasColumnName("OriginalPOID");

            //    entity.Property(e => e.ParentWoid).HasColumnName("ParentWOID");

            //    entity.Property(e => e.PaymentMode)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PaymentSubTerm)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PaymentTerm)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.RevisionReasonId).HasColumnName("RevisionReasonID");

            //    entity.Property(e => e.SigningAuthorityId).HasColumnName("SigningAuthorityID");

            //    entity.Property(e => e.SpecialComments)
            //        .HasMaxLength(1000)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.Property(e => e.WorkOrderNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<WoWorkOrderDetails>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("WO_WorkOrderDetails");

            //    entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");

            //    entity.Property(e => e.DeliveryDate)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.DeliveryPointId).HasColumnName("DeliveryPointID");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Remarks)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.WomasterId).HasColumnName("WOMasterID");
            //});

            //modelBuilder.Entity<WoWorkOrderMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("WO_WorkOrderMaster");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.IsMrpbased).HasColumnName("IsMRPBased");

            //    entity.Property(e => e.ModelId).HasColumnName("ModelID");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.ObjectId).HasColumnName("ObjectID");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.RequisitionId).HasColumnName("RequisitionID");

            //    entity.Property(e => e.TrimColor)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.TrimColorId).HasColumnName("TrimColorID");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");

            //    entity.Property(e => e.WorkOrderId).HasColumnName("WorkOrderID");
            //});

            //modelBuilder.Entity<YarnAllocationToKnitter>(entity =>
            //{
            //    entity.ToTable("Yarn_AllocationToKnitter");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.BatchNo)
            //        .HasMaxLength(800)
            //        .IsUnicode(false);

            //    entity.Property(e => e.BrandId).HasColumnName("BrandID");

            //    entity.Property(e => e.FabricGroup)
            //        .HasMaxLength(800)
            //        .IsUnicode(false);

            //    entity.Property(e => e.IssuedQty).HasColumnName("IssuedQTY");

            //    entity.Property(e => e.IssuingUnitId).HasColumnName("IssuingUnitID");

            //    entity.Property(e => e.Location)
            //        .HasMaxLength(10)
            //        .IsFixedLength();

            //    entity.Property(e => e.LocationId).HasColumnName("LocationID");

            //    entity.Property(e => e.LotNo)
            //        .HasMaxLength(800)
            //        .IsUnicode(false);

            //    entity.Property(e => e.MasterShade)
            //        .HasMaxLength(800)
            //        .IsUnicode(false);

            //    entity.Property(e => e.MfgDate).HasColumnType("datetime");

            //    entity.Property(e => e.PackingId).HasColumnName("PackingID");

            //    entity.Property(e => e.RateUnitId).HasColumnName("RateUnitID");

            //    entity.Property(e => e.RateWrtbaseUnit).HasColumnName("RateWRTBaseUnit");

            //    entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

            //    entity.Property(e => e.TransactionDate).HasColumnType("datetime");

            //    entity.Property(e => e.Unit)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");

            //    entity.Property(e => e.WoattributeInstanceId).HasColumnName("WOAttributeInstanceID");

            //    entity.Property(e => e.Woid).HasColumnName("WOID");

            //    entity.Property(e => e.YarnAttributeInstanceId).HasColumnName("YarnAttributeInstanceID");

            //    entity.Property(e => e.Ykncid).HasColumnName("YKNCID");
            //});

            //modelBuilder.Entity<YarnAllocationToKnitterRe>(entity =>
            //{
            //    entity.ToTable("Yarn_AllocationToKnitter_re");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.BatchNo)
            //        .HasMaxLength(800)
            //        .IsUnicode(false);

            //    entity.Property(e => e.BrandId).HasColumnName("BrandID");

            //    entity.Property(e => e.FabricGroup)
            //        .HasMaxLength(800)
            //        .IsUnicode(false);

            //    entity.Property(e => e.IdOld).HasColumnName("ID_OLD");

            //    entity.Property(e => e.IssuedQty).HasColumnName("IssuedQTY");

            //    entity.Property(e => e.IssuingUnitId).HasColumnName("IssuingUnitID");

            //    entity.Property(e => e.Location)
            //        .HasMaxLength(10)
            //        .IsFixedLength();

            //    entity.Property(e => e.LocationId).HasColumnName("LocationID");

            //    entity.Property(e => e.LotNo)
            //        .HasMaxLength(800)
            //        .IsUnicode(false);

            //    entity.Property(e => e.MasterShade)
            //        .HasMaxLength(800)
            //        .IsUnicode(false);

            //    entity.Property(e => e.MfgDate).HasColumnType("datetime");

            //    entity.Property(e => e.PackingId).HasColumnName("PackingID");

            //    entity.Property(e => e.RateUnitId).HasColumnName("RateUnitID");

            //    entity.Property(e => e.RateWrtbaseUnit).HasColumnName("RateWRTBaseUnit");

            //    entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

            //    entity.Property(e => e.TransactionDate).HasColumnType("datetime");

            //    entity.Property(e => e.TransactionDateNew)
            //        .HasColumnName("TransactionDate_new")
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Unit)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");

            //    entity.Property(e => e.WoattributeInstanceId).HasColumnName("WOAttributeInstanceID");

            //    entity.Property(e => e.Woid).HasColumnName("WOID");

            //    entity.Property(e => e.YarnAttributeInstanceId).HasColumnName("YarnAttributeInstanceID");

            //    entity.Property(e => e.Ykncid).HasColumnName("YKNCID");
            //});

            //modelBuilder.Entity<YarnBagType>(entity =>
            //{
            //    entity.ToTable("Yarn_BagType");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.BagType)
            //        .IsRequired()
            //        .HasMaxLength(80)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<YarnBookingMaster>(entity =>
            //{
            //    entity.HasKey(e => e.MasterId)
            //        .HasName("PK__Yarn_Booking_Mas__2D5E58E1");

            //    entity.ToTable("Yarn_Booking_Master");

            //    entity.Property(e => e.MasterId).HasColumnName("MasterID");

            //    entity.Property(e => e.IsBooked)
            //        .IsRequired()
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.TransactionDate).HasColumnType("datetime");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<YarnColorItalExport>(entity =>
            //{
            //    entity.ToTable("Yarn_ColorItalExport");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<YarnColorItalImport>(entity =>
            //{
            //    entity.ToTable("Yarn_ColorItalImport");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<YarnColorItalType>(entity =>
            //{
            //    entity.ToTable("Yarn_ColorItalType");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<YarnConeType>(entity =>
            //{
            //    entity.ToTable("Yarn_ConeType");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ConeType)
            //        .IsRequired()
            //        .HasMaxLength(80)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<YarnDaysOfPaymentSetup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Yarn_DaysOfPayment_Setup");

            //    entity.Property(e => e.DaysDesc)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DaysId)
            //        .HasColumnName("DaysID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<YarnDocumentType>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.StatusOfStockTransaction).HasColumnName("Status of StockTransaction");
            //});

            //modelBuilder.Entity<YarnFabricGroup>(entity =>
            //{
            //    entity.ToTable("Yarn_Fabric_Group");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.FabricGroup)
            //        .IsRequired()
            //        .HasMaxLength(80)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<YarnGateReceivingDetail>(entity =>
            //{
            //    entity.HasKey(e => e.YarnGateRecDetailId);

            //    entity.ToTable("Yarn_GateReceivingDetail");

            //    entity.Property(e => e.YarnGateRecDetailId).HasColumnName("YarnGateRecDetailID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.BrandId).HasColumnName("BrandID");

            //    entity.Property(e => e.Gst).HasColumnName("GST");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPitemCode");

            //    entity.Property(e => e.PackagingId).HasColumnName("PackagingID");

            //    entity.Property(e => e.RateUnitId).HasColumnName("RateUnitID");

            //    entity.Property(e => e.ReceivingQty).HasColumnName("ReceivingQTY");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");

            //    entity.Property(e => e.YarnGateRecId).HasColumnName("YarnGateRecID");

            //    entity.Property(e => e.YarnPodetailId).HasColumnName("Yarn_PODetailID");

            //    entity.HasOne(d => d.YarnGateRec)
            //        .WithMany(p => p.YarnGateReceivingDetail)
            //        .HasForeignKey(d => d.YarnGateRecId)
            //        .HasConstraintName("FK_Yarn_GateReceivingDetail_Yarn_GateReceivingMaster");
            //});

            //modelBuilder.Entity<YarnGateReceivingMaster>(entity =>
            //{
            //    entity.HasKey(e => e.YarnGateRecId);

            //    entity.ToTable("Yarn_GateReceivingMaster");

            //    entity.Property(e => e.YarnGateRecId).HasColumnName("YarnGateRecID");

            //    entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.DeliveryChallanDate).HasColumnType("datetime");

            //    entity.Property(e => e.DeliveryChallanNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DeliveryPerson)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Poid).HasColumnName("POID");

            //    entity.Property(e => e.YarnGateEntryNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<YarnGrngrvassociation>(entity =>
            //{
            //    entity.HasKey(e => e.AssociationId);

            //    entity.ToTable("Yarn_GRNGRVAssociation");

            //    entity.Property(e => e.AssociationId).HasColumnName("AssociationID");

            //    entity.Property(e => e.Grn)
            //        .IsRequired()
            //        .HasColumnName("GRN")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Grv)
            //        .IsRequired()
            //        .HasColumnName("GRV")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Poid).HasColumnName("POID");

            //    entity.Property(e => e.Ponumber)
            //        .IsRequired()
            //        .HasColumnName("PONumber")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId).HasColumnName("UserID");
            //});

            //modelBuilder.Entity<YarnImportDuty>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Yarn_ImportDuty");

            //    entity.Property(e => e.YarnHscode)
            //        .HasColumnName("Yarn_HSCODE")
            //        .HasMaxLength(15)
            //        .IsUnicode(false);

            //    entity.Property(e => e.YarnImportAit).HasColumnName("Yarn_ImportAIT");

            //    entity.Property(e => e.YarnImportAtv).HasColumnName("Yarn_ImportATV");

            //    entity.Property(e => e.YarnImportCd).HasColumnName("Yarn_ImportCD");

            //    entity.Property(e => e.YarnImportFiber)
            //        .HasColumnName("Yarn_ImportFiber")
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.YarnImportFiscalYear).HasColumnName("Yarn_ImportFiscalYear");

            //    entity.Property(e => e.YarnImportId)
            //        .HasColumnName("Yarn_ImportID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.YarnImportOther).HasColumnName("Yarn_ImportOther");

            //    entity.Property(e => e.YarnImportRd).HasColumnName("Yarn_ImportRD");

            //    entity.Property(e => e.YarnImportSd).HasColumnName("Yarn_ImportSD");

            //    entity.Property(e => e.YarnImportTotal).HasColumnName("Yarn_ImportTotal");

            //    entity.Property(e => e.YarnImportVat).HasColumnName("Yarn_ImportVAT");
            //});

            //modelBuilder.Entity<YarnImportDutyLog>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Yarn_ImportDuty_log");

            //    entity.Property(e => e.ModifyDate)
            //        .HasColumnName("modify_date")
            //        .HasColumnType("smalldatetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.ModifyUser).HasColumnName("modify_user");

            //    entity.Property(e => e.YarnHscode)
            //        .HasColumnName("Yarn_HSCODE")
            //        .HasMaxLength(15)
            //        .IsUnicode(false);

            //    entity.Property(e => e.YarnImportAit).HasColumnName("Yarn_ImportAIT");

            //    entity.Property(e => e.YarnImportAtv).HasColumnName("Yarn_ImportATV");

            //    entity.Property(e => e.YarnImportCd).HasColumnName("Yarn_ImportCD");

            //    entity.Property(e => e.YarnImportFiber)
            //        .HasColumnName("Yarn_ImportFiber")
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.YarnImportFiscalYear).HasColumnName("Yarn_ImportFiscalYear");

            //    entity.Property(e => e.YarnImportIdLog)
            //        .HasColumnName("yarn_import_id_log")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.YarnImportIdOld).HasColumnName("Yarn_ImportID_old");

            //    entity.Property(e => e.YarnImportOther).HasColumnName("Yarn_ImportOther");

            //    entity.Property(e => e.YarnImportRd).HasColumnName("Yarn_ImportRD");

            //    entity.Property(e => e.YarnImportSd).HasColumnName("Yarn_ImportSD");

            //    entity.Property(e => e.YarnImportTotal).HasColumnName("Yarn_ImportTotal");

            //    entity.Property(e => e.YarnImportVat).HasColumnName("Yarn_ImportVAT");
            //});

            //modelBuilder.Entity<YarnInspectionMaster>(entity =>
            //{
            //    entity.HasKey(e => e.YarnInspectionId);

            //    entity.ToTable("Yarn_InspectionMaster");

            //    entity.Property(e => e.YarnInspectionId).HasColumnName("YarnInspectionID");

            //    entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.InspectionDate).HasColumnType("datetime");

            //    entity.Property(e => e.InspectionNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ReasonDescription)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.YarnGateRecId).HasColumnName("YarnGateRecID");

            //    entity.Property(e => e.YarnPoid).HasColumnName("Yarn_POID");

            //    entity.Property(e => e.YarnTempRecId).HasColumnName("YarnTempRecID");

            //    entity.HasOne(d => d.YarnTempRec)
            //        .WithMany(p => p.YarnInspectionMaster)
            //        .HasForeignKey(d => d.YarnTempRecId)
            //        .HasConstraintName("FK_Yarn_InspectionMaster_Yarn_TemporaryReceivingMaster");
            //});

            //modelBuilder.Entity<YarnInspectionStatusSetup>(entity =>
            //{
            //    entity.HasKey(e => e.YarnInspStatus);

            //    entity.ToTable("Yarn_InspectionStatus_Setup");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<YarnInspectionTypesSetup>(entity =>
            //{
            //    entity.HasKey(e => e.YarnInspTypeId);

            //    entity.ToTable("Yarn_InspectionTypes_Setup");

            //    entity.Property(e => e.YarnInspTypeId).HasColumnName("YarnInspTypeID");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<YarnIotcontractMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Yarn_IOTContractMaster");

            //    entity.Property(e => e.Iotid)
            //        .HasColumnName("IOTID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.NewOrderId).HasColumnName("NewOrderID");

            //    entity.Property(e => e.NewOrderNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.NewProgramTypeId).HasColumnName("NewProgramTypeID");

            //    entity.Property(e => e.OldOrderId).HasColumnName("OldOrderID");

            //    entity.Property(e => e.OldOrderNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OldProgramTypeId).HasColumnName("OldProgramTypeID");
            //});

            //modelBuilder.Entity<YarnIotmaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Yarn_IOTMaster");

            //    entity.Property(e => e.Iotdate)
            //        .HasColumnName("IOTDate")
            //        .HasColumnType("smalldatetime");

            //    entity.Property(e => e.Iotid)
            //        .HasColumnName("IOTID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.Iotno)
            //        .HasColumnName("IOTNo")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OldOrderId).HasColumnName("OldOrderID");

            //    entity.Property(e => e.OldProgramId).HasColumnName("OldProgramID");
            //});

            //modelBuilder.Entity<YarnIssuanceForQualityInspectionMaster>(entity =>
            //{
            //    entity.HasKey(e => e.YarnIssQltyid);

            //    entity.ToTable("Yarn_IssuanceForQualityInspectionMaster");

            //    entity.Property(e => e.YarnIssQltyid).HasColumnName("YarnIssQLTYID");

            //    entity.Property(e => e.YarnTempRecId).HasColumnName("YarnTempRecID");

            //    entity.Property(e => e.YarnWeighInspId).HasColumnName("YarnWeighInspID");
            //});

            //modelBuilder.Entity<YarnIssuanceForQualityMaster>(entity =>
            //{
            //    entity.HasKey(e => e.YarnQltyIssuanceId);

            //    entity.ToTable("Yarn_IssuanceForQualityMaster");

            //    entity.Property(e => e.YarnQltyIssuanceId).HasColumnName("YarnQltyIssuanceID");

            //    entity.Property(e => e.ContactPerson)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CriteriaId).HasColumnName("CriteriaID");

            //    entity.Property(e => e.IssuanceDate).HasColumnType("datetime");

            //    entity.Property(e => e.Poid).HasColumnName("POID");

            //    entity.Property(e => e.QltyLabId).HasColumnName("QltyLabID");

            //    entity.Property(e => e.ReferenceNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.YarnInspectionId).HasColumnName("YarnInspectionID");

            //    entity.Property(e => e.YarnTempRecId).HasColumnName("YarnTempRecID");

            //    entity.HasOne(d => d.YarnInspection)
            //        .WithMany(p => p.YarnIssuanceForQualityMaster)
            //        .HasForeignKey(d => d.YarnInspectionId)
            //        .HasConstraintName("FK_Yarn_IssuanceForQualityMaster_Yarn_InspectionMaster");
            //});

            //modelBuilder.Entity<YarnIssuanceToKnitterMaster>(entity =>
            //{
            //    entity.HasKey(e => e.YarnKnissId);

            //    entity.ToTable("Yarn_IssuanceToKnitterMaster");

            //    entity.Property(e => e.YarnKnissId).HasColumnName("YarnKNIssID");

            //    entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.IssuanceDate).HasColumnType("datetime");

            //    entity.Property(e => e.PickListId).HasColumnName("PickListID");

            //    entity.Property(e => e.Status).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.SubPickListId).HasColumnName("SubPickListID");

            //    entity.Property(e => e.YarnKncontractId).HasColumnName("YarnKNContractID");

            //    entity.HasOne(d => d.YarnKncontract)
            //        .WithMany(p => p.YarnIssuanceToKnitterMaster)
            //        .HasForeignKey(d => d.YarnKncontractId)
            //        .HasConstraintName("FK_Yarn_IssuanceToKnitterMaster_Yarn_KnittingContractMaster");
            //});

            //modelBuilder.Entity<YarnIssuanceToModelMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Yarn_IssuanceToModelMaster");

            //    entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

            //    entity.Property(e => e.ChallanNo)
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.Frsid).HasColumnName("FRSID");

            //    entity.Property(e => e.IssuanceDate)
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.KnitterId).HasColumnName("KnitterID");

            //    entity.Property(e => e.Lcno)
            //        .HasColumnName("LCNo")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.Yisid)
            //        .HasColumnName("YISID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<YarnIssuanceToModelQtyDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Yarn_IssuanceToModelQtyDetail");

            //    entity.Property(e => e.FrsattributeInstanceId).HasColumnName("FRSAttributeInstanceID");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.IssuanceMasterId).HasColumnName("IssuanceMasterID");

            //    entity.Property(e => e.NewAttributeInstanceId).HasColumnName("NewAttributeInstanceID");
            //});

            //modelBuilder.Entity<YarnIssuanceagainstWomaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Yarn_IssuanceagainstWOMaster");

            //    entity.Property(e => e.YarnWocontractId).HasColumnName("YarnWOContractID");

            //    entity.Property(e => e.YarnWoissId)
            //        .HasColumnName("YarnWOIssID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<YarnItemAssociationSetup>(entity =>
            //{
            //    entity.ToTable("yarn_ItemAssociationSetup");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.ItemId).HasColumnName("ItemID");
            //});

            //modelBuilder.Entity<YarnKnitterStockTransactions>(entity =>
            //{
            //    entity.HasKey(e => e.KnitterStockTrnsId);

            //    entity.ToTable("Yarn_KnitterStockTransactions");

            //    entity.Property(e => e.KnitterStockTrnsId).HasColumnName("KnitterStockTrnsID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.BagName)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.BatchNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.BrandId).HasColumnName("BrandID");

            //    entity.Property(e => e.IssuanceToKnitterId).HasColumnName("IssuanceToKnitterID");

            //    entity.Property(e => e.KnittingContractId).HasColumnName("KnittingContractID");

            //    entity.Property(e => e.LotNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.MfgDate).HasColumnType("datetime");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.OrderNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PackagingId).HasColumnName("PackagingID");

            //    entity.Property(e => e.ProgramTypeId).HasColumnName("ProgramTypeID");

            //    entity.Property(e => e.Rate).HasColumnName("rate");

            //    entity.Property(e => e.RateUnitId).HasColumnName("rateUnitID");

            //    entity.Property(e => e.RateWrtbaseUnit).HasColumnName("RateWRTBaseUnit");

            //    entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

            //    entity.Property(e => e.TransactionDate).HasColumnType("datetime");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");
            //});

            //modelBuilder.Entity<YarnKnittingContractClosureDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Yarn_KnittingContractClosureDetail");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.VoucherNumber)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.YarnKncontractId).HasColumnName("YarnKNContractID");
            //});

            //modelBuilder.Entity<YarnKnittingContractColor>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Yarn_KnittingContractColor");

            //    entity.Property(e => e.Color)
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.YarnKncontractId).HasColumnName("YarnKNContractID");

            //    entity.Property(e => e.YarnNo).HasColumnName("YarnNO");
            //});

            //modelBuilder.Entity<YarnKnittingContractDeliverySchedule>(entity =>
            //{
            //    entity.HasKey(e => e.KncontractDelSchdId);

            //    entity.ToTable("Yarn_KnittingContractDeliverySchedule");

            //    entity.Property(e => e.KncontractDelSchdId).HasColumnName("KNContractDelSchdID");

            //    entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

            //    entity.Property(e => e.GreigeDeliveryLocationId).HasColumnName("GreigeDeliveryLocationID");

            //    entity.Property(e => e.Sizes)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.YarnKncontractId).HasColumnName("YarnKNContractID");

            //    entity.HasOne(d => d.YarnKncontract)
            //        .WithMany(p => p.YarnKnittingContractDeliverySchedule)
            //        .HasForeignKey(d => d.YarnKncontractId)
            //        .HasConstraintName("FK_Yarn_KnittingContractDeliverySchedule_Yarn_KnittingContractMaster");
            //});

            //modelBuilder.Entity<YarnKnittingContractDetail>(entity =>
            //{
            //    entity.HasKey(e => e.YarnKncontractDetailId);

            //    entity.ToTable("Yarn_KnittingContractDetail");

            //    entity.Property(e => e.YarnKncontractDetailId).HasColumnName("YarnKNContractDetailID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.YarnKncontractId).HasColumnName("YarnKNContractID");

            //    entity.Property(e => e.YarnNo).HasColumnName("YarnNO");

            //    entity.HasOne(d => d.YarnKncontract)
            //        .WithMany(p => p.YarnKnittingContractDetail)
            //        .HasForeignKey(d => d.YarnKncontractId)
            //        .HasConstraintName("FK_Yarn_KnittingContractDetail_Yarn_KnittingContractMaster");
            //});

            //modelBuilder.Entity<YarnKnittingContractFlatBed>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Yarn_KnittingContractFlatBed");

            //    entity.Property(e => e.Amount).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.BalanceQuantity).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.BalanceQuantityInKgs).HasColumnName("BalanceQuantityInKGs");

            //    entity.Property(e => e.Length).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.Quantity).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.QuantityInKgs)
            //        .HasColumnName("QuantityInKGs")
            //        .HasDefaultValueSql("(0)");

            //    entity.Property(e => e.RatePerPieces).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.SizeId)
            //        .HasColumnName("SizeID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.SkgLength).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.SkgWidth).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.Width).HasDefaultValueSql("(0)");

            //    entity.Property(e => e.YarnKncontractId).HasColumnName("YarnKNContractID");

            //    entity.HasOne(d => d.YarnKncontract)
            //        .WithMany(p => p.YarnKnittingContractFlatBed)
            //        .HasForeignKey(d => d.YarnKncontractId)
            //        .HasConstraintName("FK_Yarn_KnittingContractFlatBed_Yarn_KnittingContractMaster");
            //});

            //modelBuilder.Entity<YarnKnittingContractMaster>(entity =>
            //{
            //    entity.HasKey(e => e.YarnKncontractId);

            //    entity.ToTable("Yarn_KnittingContractMaster");

            //    entity.Property(e => e.YarnKncontractId).HasColumnName("YarnKNContractID");

            //    entity.Property(e => e.AverageDailyProduction)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.ContractDate).HasColumnType("datetime");

            //    entity.Property(e => e.ContractName)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DyeingId).HasColumnName("DyeingID");

            //    entity.Property(e => e.FabricCategoryId).HasColumnName("FabricCategoryID");

            //    entity.Property(e => e.FabricCodeId).HasColumnName("FabricCodeID");

            //    entity.Property(e => e.FabricTrimSelectedId).HasColumnName("FabricTrimSelectedID");

            //    entity.Property(e => e.FabricTypeId).HasColumnName("FabricTypeID");

            //    entity.Property(e => e.Fid).HasColumnName("FID");

            //    entity.Property(e => e.GaugeId).HasColumnName("GaugeID");

            //    entity.Property(e => e.GreigeAttributeInstanceId).HasColumnName("GreigeAttributeInstanceID");

            //    entity.Property(e => e.GreigeMrp).HasColumnName("GreigeMRP");

            //    entity.Property(e => e.Gsm).HasColumnName("GSM");

            //    entity.Property(e => e.IsClosed).HasDefaultValueSql("((0))");

            //    entity.Property(e => e.KnitterId).HasColumnName("KnitterID");

            //    entity.Property(e => e.KnittingContractTypeSetupId).HasColumnName("KnittingContractTypeSetupID");

            //    entity.Property(e => e.KnittingWastageId).HasColumnName("KnittingWastageID");

            //    entity.Property(e => e.KrsId).HasColumnName("KRS_ID");

            //    entity.Property(e => e.MachineTypeId).HasColumnName("MachineTypeID");

            //    entity.Property(e => e.MaterialSourceId).HasColumnName("MaterialSourceID");

            //    entity.Property(e => e.ModeOfPayment)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ModelId).HasColumnName("ModelID");

            //    entity.Property(e => e.ModelName)
            //        .HasMaxLength(100)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.OrderNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ProgramTypeId).HasColumnName("ProgramTypeID");

            //    entity.Property(e => e.QualityId).HasColumnName("QualityID");

            //    entity.Property(e => e.RatePerKg).HasColumnName("RatePerKG");

            //    entity.Property(e => e.Status).HasDefaultValueSql("((1))");

            //    entity.Property(e => e.StichLength)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.YkncclosureQuantity).HasColumnName("YKNCClosureQuantity");
            //});

            //modelBuilder.Entity<YarnKnittingContractStausSetup>(entity =>
            //{
            //    entity.HasKey(e => e.YkstatusId);

            //    entity.ToTable("Yarn_KnittingContractStaus_Setup");

            //    entity.Property(e => e.YkstatusId)
            //        .HasColumnName("YKStatusID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<YarnKnittingContractTippingSpecification>(entity =>
            //{
            //    entity.HasKey(e => e.TippingId);

            //    entity.ToTable("Yarn_KnittingContractTippingSpecification");

            //    entity.Property(e => e.TippingId).HasColumnName("TippingID");

            //    entity.Property(e => e.KnittingContractId).HasColumnName("KnittingContractID");

            //    entity.Property(e => e.YarnAttributeInstanceId).HasColumnName("YarnAttributeInstanceID");

            //    entity.Property(e => e.YarnId).HasColumnName("YarnID");

            //    entity.HasOne(d => d.KnittingContract)
            //        .WithMany(p => p.YarnKnittingContractTippingSpecification)
            //        .HasForeignKey(d => d.KnittingContractId)
            //        .OnDelete(DeleteBehavior.Cascade)
            //        .HasConstraintName("FK_Yarn_KnittingContractTippingSpecification_Yarn_KnittingContractMaster");
            //});

            //modelBuilder.Entity<YarnKnittingContractYarnSpecification>(entity =>
            //{
            //    entity.HasKey(e => e.YarnId);

            //    entity.ToTable("Yarn_KNittingContractYarnSpecification");

            //    entity.Property(e => e.YarnId).HasColumnName("YarnID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.FabricColorId).HasColumnName("FabricColorID");

            //    entity.Property(e => e.KnittingContractId).HasColumnName("KnittingContractID");

            //    entity.Property(e => e.PantoneNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.YarnCompositionId).HasColumnName("YarnCompositionID");

            //    entity.Property(e => e.YarnCountId).HasColumnName("YarnCountID");

            //    entity.Property(e => e.YarnDesignId).HasColumnName("YarnDesignID");

            //    entity.Property(e => e.YarnDyeingId).HasColumnName("YarnDyeingID");

            //    entity.Property(e => e.YarnNo).HasColumnName("YarnNO");

            //    entity.Property(e => e.YarnQualityId).HasColumnName("YarnQualityID");

            //    entity.HasOne(d => d.KnittingContract)
            //        .WithMany(p => p.YarnKnittingContractYarnSpecification)
            //        .HasForeignKey(d => d.KnittingContractId)
            //        .HasConstraintName("FK_Yarn_KNittingContractYarnSpecification_Yarn_KnittingContractMaster");
            //});

            modelBuilder.Entity<Yarn_KnittingWastage_Setup>(entity =>
            {
                entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            });

            //modelBuilder.Entity<YarnMasterShade>(entity =>
            //{
            //    entity.ToTable("Yarn_Master_Shade");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.MasterShade)
            //        .IsRequired()
            //        .HasMaxLength(80)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<YarnOpeningBalanceDetail>(entity =>
            //{
            //    entity.HasKey(e => e.ObDetailId);

            //    entity.ToTable("Yarn_OpeningBalance_Detail");

            //    entity.Property(e => e.ObDetailId).HasColumnName("OB_Detail_ID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.BatchNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.BrandId).HasColumnName("BrandID");

            //    entity.Property(e => e.DocumentDate).HasColumnType("datetime");

            //    entity.Property(e => e.LotNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.MfgDate).HasColumnType("datetime");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.ObId).HasColumnName("OB_ID");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.OrderNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ProgramId).HasColumnName("ProgramID");

            //    entity.Property(e => e.Rate)
            //        .HasColumnName("rate")
            //        .HasColumnType("numeric(18, 4)");

            //    entity.Property(e => e.RateUnitId).HasColumnName("RateUnitID");

            //    entity.Property(e => e.StoreLocationId).HasColumnName("StoreLocationID");

            //    entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

            //    entity.Property(e => e.TransactionQty).HasColumnType("numeric(18, 4)");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");

            //    entity.HasOne(d => d.Ob)
            //        .WithMany(p => p.YarnOpeningBalanceDetail)
            //        .HasForeignKey(d => d.ObId)
            //        .OnDelete(DeleteBehavior.Cascade)
            //        .HasConstraintName("FK_Yarn_OpeningBalance_Detail_Yarn_OpeningBalance_Master");
            //});

            //modelBuilder.Entity<YarnOpeningBalanceMaster>(entity =>
            //{
            //    entity.HasKey(e => e.ObId);

            //    entity.ToTable("Yarn_OpeningBalance_Master");

            //    entity.Property(e => e.ObId).HasColumnName("OB_ID");

            //    entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.GlHit).HasColumnName("GL_Hit");

            //    entity.Property(e => e.Obdate)
            //        .HasColumnName("OBDate")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.OrderNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ProgramId).HasColumnName("ProgramID");

            //    entity.Property(e => e.Reference)
            //        .HasColumnName("reference")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Remarks)
            //        .HasColumnName("remarks")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            //});

            //modelBuilder.Entity<YarnOrderDetail>(entity =>
            //{
            //    entity.ToTable("Yarn_OrderDetail");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.Yomid).HasColumnName("YOMID");

            //    entity.HasOne(d => d.Yom)
            //        .WithMany(p => p.YarnOrderDetail)
            //        .HasForeignKey(d => d.Yomid)
            //        .HasConstraintName("FK_Yarn_OrderDetail_Yarn_OrderMaster");
            //});

            //modelBuilder.Entity<YarnOrderMaster>(entity =>
            //{
            //    entity.ToTable("Yarn_OrderMaster");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.Ipaddress)
            //        .HasColumnName("IPAddress")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.Property(e => e.Yono)
            //        .HasColumnName("YONo")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<YarnOutGatePassDetail>(entity =>
            //{
            //    entity.HasKey(e => e.YarnOutwardDetailId);

            //    entity.ToTable("Yarn_OutGatePass_Detail");

            //    entity.Property(e => e.YarnOutwardDetailId).HasColumnName("Yarn_OutwardDetailID");

            //    entity.Property(e => e.YarnOutGatePassId).HasColumnName("Yarn_OutGatePassID");

            //    entity.Property(e => e.YarnTempRecId).HasColumnName("YarnTempRecID");

            //    entity.Property(e => e.YarnWeighInspId).HasColumnName("YarnWeighInspID");

            //    entity.HasOne(d => d.YarnOutGatePass)
            //        .WithMany(p => p.YarnOutGatePassDetail)
            //        .HasForeignKey(d => d.YarnOutGatePassId)
            //        .HasConstraintName("FK_Yarn_OutGatePass_Detail_Yarn_OutGatePassMaster");
            //});

            //modelBuilder.Entity<YarnOutGatePassMaster>(entity =>
            //{
            //    entity.HasKey(e => e.YarnOutGatePassId);

            //    entity.ToTable("Yarn_OutGatePassMaster");

            //    entity.Property(e => e.YarnOutGatePassId).HasColumnName("YarnOutGatePassID");

            //    entity.Property(e => e.Comments)
            //        .HasColumnType("ntext")
            //        .HasDefaultValueSql("(N'-20')");

            //    entity.Property(e => e.IdentificationNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OutGatePassDate).HasColumnType("datetime");

            //    entity.Property(e => e.Poid).HasColumnName("POID");

            //    entity.Property(e => e.ReceivingPerson)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.VehicleNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Yrtsid)
            //        .HasColumnName("YRTSID")
            //        .HasDefaultValueSql("((-20))");
            //});

            //modelBuilder.Entity<YarnPermanentReceivingMaster>(entity =>
            //{
            //    entity.HasKey(e => e.YarnPermRecId);

            //    entity.ToTable("Yarn_PermanentReceivingMaster");

            //    entity.Property(e => e.YarnPermRecId).HasColumnName("YarnPermRecID");

            //    entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.YarnPermRecDate).HasColumnType("datetime");

            //    entity.Property(e => e.YarnPermRecNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.YarnPoid).HasColumnName("YarnPOID");

            //    entity.Property(e => e.YarnQtyInspId).HasColumnName("yarnQtyInspID");

            //    entity.Property(e => e.YarnTempRecId).HasColumnName("YarnTempRecID");

            //    entity.Property(e => e.YarnWeighingId).HasColumnName("yarnWeighingID");

            //    entity.HasOne(d => d.YarnTempRec)
            //        .WithMany(p => p.YarnPermanentReceivingMaster)
            //        .HasForeignKey(d => d.YarnTempRecId)
            //        .HasConstraintName("FK_Yarn_PermanentReceivingMaster_Yarn_TemporaryReceivingMaster");
            //});

            //modelBuilder.Entity<YarnPodeliverySchedule>(entity =>
            //{
            //    entity.HasKey(e => e.YarnDelSchId);

            //    entity.ToTable("Yarn_PODeliverySchedule");

            //    entity.Property(e => e.YarnDelSchId).HasColumnName("YarnDelSchID");

            //    entity.Property(e => e.Cf).HasColumnName("CF");

            //    entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

            //    entity.Property(e => e.DeliveryQty).HasColumnName("DeliveryQTY");

            //    entity.Property(e => e.YarnPodetailId).HasColumnName("Yarn_PODetailID");
            //});

            //modelBuilder.Entity<YarnPodetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Yarn_PODetail");

            //    entity.Property(e => e.AmountWithGst)
            //        .HasColumnName("AmountWithGST")
            //        .HasColumnType("numeric(18, 4)");

            //    entity.Property(e => e.AmountWithOutGst)
            //        .HasColumnName("AmountWithOutGST")
            //        .HasColumnType("numeric(18, 4)");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.BalanceQty)
            //        .HasColumnName("BalanceQTY")
            //        .HasColumnType("numeric(18, 4)");

            //    entity.Property(e => e.BrandId).HasColumnName("BrandID");

            //    entity.Property(e => e.CurrencyRate).HasColumnType("numeric(18, 4)");

            //    entity.Property(e => e.Gst)
            //        .HasColumnName("GST")
            //        .HasColumnType("numeric(18, 4)");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.OrderQty)
            //        .HasColumnName("OrderQTY")
            //        .HasColumnType("numeric(18, 4)");

            //    entity.Property(e => e.PackagingId).HasColumnName("PackagingID");

            //    entity.Property(e => e.Rate).HasColumnType("numeric(18, 4)");

            //    entity.Property(e => e.RateUnitId).HasColumnName("RateUnitID");

            //    entity.Property(e => e.TempBalanceQty)
            //        .HasColumnName("tempBalanceQty")
            //        .HasColumnType("numeric(18, 4)");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");

            //    entity.Property(e => e.YarnPodetailId)
            //        .HasColumnName("Yarn_PODetailID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.YarnPoid).HasColumnName("Yarn_POID");
            //});

            //modelBuilder.Entity<YarnPodetailRequisition>(entity =>
            //{
            //    entity.ToTable("Yarn_PODetailRequisition");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.YarnPodetailId).HasColumnName("Yarn_PODetailID");

            //    entity.Property(e => e.YarnReqDetailId).HasColumnName("YarnReqDetailID");
            //});

            modelBuilder.Entity<Yarn_POMaster>(entity =>
            {
                entity.HasKey(e => e.Yarn_POID);

                //    entity.ToTable("Yarn_POMaster");

                //    entity.HasIndex(e => new { e.YarnPono, e.YarnPoid })
                //        .HasName("_dta_index_Yarn_POMaster_9_525349036__K1_2");

                //    entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

                //    entity.Property(e => e.CartageId).HasColumnName("CartageID");

                //    entity.Property(e => e.ColorItalExportId).HasColumnName("ColorItalExportID");

                //    entity.Property(e => e.ColorItalImportId).HasColumnName("ColorItalImportID");

                //    entity.Property(e => e.ColorItalTypeId).HasColumnName("ColorItalTypeID");

                //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                //    entity.Property(e => e.KnitterId).HasColumnName("KnitterID");

                //    entity.Property(e => e.LcNumber)
                //        .HasMaxLength(25)
                //        .IsUnicode(false);

                //    entity.Property(e => e.ModeId).HasColumnName("ModeID");

                //    entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                //    entity.Property(e => e.ModifiedUserId).HasColumnName("ModifiedUserID");

                //    entity.Property(e => e.ModifiedUserName)
                //        .HasMaxLength(50)
                //        .IsUnicode(false);

                //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

                //    entity.Property(e => e.OrderNo)
                //        .HasMaxLength(50)
                //        .IsUnicode(false);

                //    entity.Property(e => e.Pino)
                //        .HasColumnName("PINO")
                //        .HasMaxLength(50)
                //        .IsUnicode(false);

                //    entity.Property(e => e.Podate)
                //        .HasColumnName("PODate")
                //        .HasColumnType("datetime");

                //    entity.Property(e => e.ProcurementPurposeId).HasColumnName("ProcurementPurposeID");

                //    entity.Property(e => e.ProcurementTypeId).HasColumnName("ProcurementTypeID");

                //    entity.Property(e => e.ProgramTypeId).HasColumnName("ProgramTypeID");

                //    entity.Property(e => e.Remarks)
                //        .HasMaxLength(600)
                //        .IsUnicode(false);

                //    entity.Property(e => e.SupplierId)
                //        .HasColumnName("SupplierID")
                //        .HasColumnType("numeric(18, 0)");

                //    entity.Property(e => e.TermId).HasColumnName("TermID");

                //    entity.Property(e => e.UserId).HasColumnName("UserID");

                //    entity.Property(e => e.UserName)
                //        .HasMaxLength(50)
                //        .IsUnicode(false);

                //    entity.Property(e => e.YarnBrokerId).HasColumnName("YarnBrokerID");

                entity.Property(e => e.Yarn_POID)
                    .HasColumnName("Yarn_POID")
                    .ValueGeneratedOnAdd();

                //    entity.Property(e => e.YarnPono)
                //        .HasColumnName("YarnPONo")
                //        .HasMaxLength(50)
                //        .IsUnicode(false);

                //    entity.Property(e => e.YarnStoreLocationId).HasColumnName("YarnStoreLocationID");

                //    entity.Property(e => e.YpcId).HasColumnName("YPC_ID");
            });

            //modelBuilder.Entity<YarnProcurementPurpose>(entity =>
            //{
            //    entity.ToTable("Yarn_ProcurementPurpose");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<YarnProcurementType>(entity =>
            //{
            //    entity.ToTable("Yarn_ProcurementType");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<YarnProgramTypeSetup>(entity =>
            //{
            //    entity.HasKey(e => e.ProgramTypeId);

            //    entity.ToTable("Yarn_ProgramType_Setup");

            //    entity.Property(e => e.ProgramTypeId)
            //        .HasColumnName("ProgramTypeID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.ProgramType)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<YarnQualityInspectionCriteriaDetail>(entity =>
            //{
            //    entity.HasKey(e => e.DetailId);

            //    entity.ToTable("Yarn_QualityInspectionCriteriaDetail");

            //    entity.Property(e => e.DetailId).HasColumnName("DetailID");

            //    entity.Property(e => e.AttributeId).HasColumnName("AttributeID");

            //    entity.Property(e => e.AttributeValue)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CriteriaId).HasColumnName("CriteriaID");

            //    entity.HasOne(d => d.Criteria)
            //        .WithMany(p => p.YarnQualityInspectionCriteriaDetail)
            //        .HasForeignKey(d => d.CriteriaId)
            //        .OnDelete(DeleteBehavior.Cascade)
            //        .HasConstraintName("FK_Yarn_QualityInspectionCriteriaDetail_Yarn_QualityInspectionCriteriaMaster");
            //});

            //modelBuilder.Entity<YarnQualityInspectionCriteriaMaster>(entity =>
            //{
            //    entity.HasKey(e => e.CriteriaId);

            //    entity.ToTable("Yarn_QualityInspectionCriteriaMaster");

            //    entity.Property(e => e.CriteriaId).HasColumnName("CriteriaID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.CriteriaName)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<YarnQualityInspectionDetail>(entity =>
            //{
            //    entity.HasKey(e => e.QualityInspDetailId);

            //    entity.ToTable("Yarn_QualityInspectionDetail");

            //    entity.Property(e => e.QualityInspDetailId).HasColumnName("QualityInspDetailID");

            //    entity.Property(e => e.AttributeId)
            //        .HasColumnName("AttributeID")
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.AttributeValue)
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.FabricGroupId).HasColumnName("FabricGroupID");

            //    entity.Property(e => e.MasterShadeId).HasColumnName("MasterShadeID");

            //    entity.Property(e => e.QualityInspId).HasColumnName("QualityInspID");

            //    entity.Property(e => e.ShadeColor)
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.HasOne(d => d.QualityInsp)
            //        .WithMany(p => p.YarnQualityInspectionDetail)
            //        .HasForeignKey(d => d.QualityInspId)
            //        .HasConstraintName("FK_Yarn_QualityInspectionDetail_Yarn_QualityInspectionMaster");
            //});

            //modelBuilder.Entity<YarnQualityInspectionMaster>(entity =>
            //{
            //    entity.HasKey(e => e.QualityInspId);

            //    entity.ToTable("Yarn_QualityInspectionMaster");

            //    entity.Property(e => e.QualityInspId)
            //        .HasColumnName("QualityInspID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.CriteriaId).HasColumnName("CriteriaID");

            //    entity.Property(e => e.InspectionDate).HasColumnType("datetime");

            //    entity.Property(e => e.Poid).HasColumnName("POID");

            //    entity.Property(e => e.TempRecId).HasColumnName("TempRecID");
            //});

            //modelBuilder.Entity<YarnQualityLabsSetup>(entity =>
            //{
            //    entity.HasKey(e => e.YarnQltyLabsId);

            //    entity.ToTable("Yarn_QualityLabs_Setup");

            //    entity.Property(e => e.YarnQltyLabsId).HasColumnName("YarnQltyLabsID");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<YarnRateSetup>(entity =>
            //{
            //    entity.HasKey(e => e.RateId);

            //    entity.ToTable("Yarn_RateSetup");

            //    entity.Property(e => e.RateId)
            //        .HasColumnName("RateID")
            //        .HasComment("The Primary Key");

            //    entity.Property(e => e.RateDisplayName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .HasComment("This is the Display Name Ex. 10 pounds would have\" per ten pound\" display name and It must be Unique");

            //    entity.Property(e => e.RateUnit).HasComment("This Unit can only be in KGs or Pounds . 1 stands for KGs and 2 stands for Pounds");

            //    entity.Property(e => e.RateValue)
            //        .HasColumnType("numeric(18, 5)")
            //        .HasComment("The value for example per 10 pound rate has Value= 10 .This value Need not be Unique");

            //    entity.Property(e => e.Skuconversion)
            //        .HasColumnName("SKUConversion")
            //        .HasColumnType("numeric(18, 5)")
            //        .HasComment("The value required to convert it into KGs or SKU unit");

            //    entity.Property(e => e.SkuconvertedValue)
            //        .HasColumnName("SKUConvertedValue")
            //        .HasColumnType("numeric(18, 5)");
            //});

            //modelBuilder.Entity<YarnReceivingWithoutPomaster>(entity =>
            //{
            //    entity.HasKey(e => e.YarnRecWopoid);

            //    entity.ToTable("Yarn_ReceivingWithoutPOMaster");

            //    entity.Property(e => e.YarnRecWopoid).HasColumnName("YarnRecWOPOID");

            //    entity.Property(e => e.BrokerId).HasColumnName("BrokerID");

            //    entity.Property(e => e.CartageId).HasColumnName("CartageID");

            //    entity.Property(e => e.DeliveryChallanDate).HasColumnType("datetime");

            //    entity.Property(e => e.DeliveryChallanNo)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DeliveryPerson)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.OrderNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Podate)
            //        .HasColumnName("PODate")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.Pono)
            //        .IsRequired()
            //        .HasColumnName("POno")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ProgramId).HasColumnName("ProgramID");

            //    entity.Property(e => e.Reference)
            //        .HasColumnName("reference")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Remarks)
            //        .HasColumnName("remarks")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StoreId).HasColumnName("StoreID");

            //    entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            //});

            modelBuilder.Entity<Yarn_RequisitionDetail>(entity =>
            {
                //  entity.HasNoKey();

                entity.ToTable("Yarn_RequisitionDetail");



                entity.Property(e => e.ColorName)
                    .HasMaxLength(200)
                    .IsUnicode(false);



                entity.Property(e => e.Remarks)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.YarnReqDetailID)
                    .HasColumnName("YarnReqDetailID")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.Yarn_RequisitionMaster)
                    .WithMany(p => p.Yarn_RequisitionDetail)
                    .HasForeignKey(d => d.YarnReqID)
                    .HasConstraintName("FK_Yarn_RequisitionDetail_Yarn_RequisitionMaster");
            });

            //modelBuilder.Entity<YarnRequisitionDetailRegeneration>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Yarn_RequisitionDetail_Regeneration");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.BalanceQty).HasColumnName("BalanceQTY");

            //    entity.Property(e => e.ColorName)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DetailId)
            //        .HasColumnName("DetailID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.GrossId).HasColumnName("GrossID");

            //    entity.Property(e => e.GrossQty).HasColumnName("GrossQTY");

            //    entity.Property(e => e.MasterId).HasColumnName("MasterID");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.NetQty).HasColumnName("NetQTY");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.OriginalQty).HasColumnName("OriginalQTY");

            //    entity.Property(e => e.StyleId).HasColumnName("StyleID");

            //    entity.Property(e => e.YarnReqId).HasColumnName("YarnReqID");
            //});

            modelBuilder.Entity<Yarn_RequisitionMaster>(entity =>
            {
                entity.HasKey(e => e.YarnReqID);

                entity.ToTable("Yarn_RequisitionMaster");


                entity.Property(e => e.Date)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IsDependent)
                    .IsRequired()
                    .HasDefaultValueSql("(0)");



                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.YarnReqNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            //modelBuilder.Entity<YarnRequisitionMasterRegeneration>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Yarn_RequisitionMaster_Regeneration");

            //    entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.Date)
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.Property(e => e.UserName)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.YarnReqDate).HasColumnType("datetime");

            //    entity.Property(e => e.YarnReqId).HasColumnName("YarnReqID");

            //    entity.Property(e => e.YarnReqNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<YarnReturnFromKnitter>(entity =>
            //{
            //    entity.HasKey(e => e.ReturnFromKnitterId);

            //    entity.ToTable("Yarn_ReturnFromKnitter");

            //    entity.Property(e => e.ReturnFromKnitterId).HasColumnName("ReturnFromKnitterID");

            //    entity.Property(e => e.ReturnDate).HasColumnType("datetime");
            //});

            //modelBuilder.Entity<YarnReturnFromQualityInspection>(entity =>
            //{
            //    entity.HasKey(e => e.YarnRtrnQltyInspId);

            //    entity.ToTable("Yarn_ReturnFromQualityInspection");

            //    entity.Property(e => e.YarnRtrnQltyInspId).HasColumnName("YarnRtrnQltyInspID");

            //    entity.Property(e => e.YarnIssQltyid).HasColumnName("YarnIssQLTYID");
            //});

            //modelBuilder.Entity<YarnReturnToSupplierDetail>(entity =>
            //{
            //    entity.HasKey(e => e.YrtsdetailId);

            //    entity.ToTable("Yarn_ReturnToSupplierDetail");

            //    entity.Property(e => e.YrtsdetailId).HasColumnName("YRTSDetailID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.YrtsmasterId).HasColumnName("YRTSMasterID");
            //});

            //modelBuilder.Entity<YarnReturnToSupplierMaster>(entity =>
            //{
            //    entity.HasKey(e => e.Yrtsid);

            //    entity.ToTable("Yarn_ReturnToSupplierMaster");

            //    entity.Property(e => e.Yrtsid).HasColumnName("YRTSID");

            //    entity.Property(e => e.Poid).HasColumnName("POID");

            //    entity.Property(e => e.YarnPermRecId).HasColumnName("YarnPermRecID");

            //    entity.Property(e => e.Yrtsdate)
            //        .HasColumnName("YRTSDate")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.Yrtsno)
            //        .IsRequired()
            //        .HasColumnName("YRTSNo")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<YarnReturnfromKnittergriege>(entity =>
            //{
            //    entity.HasKey(e => e.RfkId);

            //    entity.ToTable("yarn_returnfromKnittergriege");

            //    entity.Property(e => e.RfkId).HasColumnName("RFK_ID");

            //    entity.Property(e => e.KnittingContractId).HasColumnName("KnittingContractID");

            //    entity.Property(e => e.ReturnDate).HasColumnType("datetime");

            //    entity.Property(e => e.ReturnedGreigeFabric).HasColumnType("numeric(18, 5)");

            //    entity.HasOne(d => d.KnittingContract)
            //        .WithMany(p => p.YarnReturnfromKnittergriege)
            //        .HasForeignKey(d => d.KnittingContractId)
            //        .HasConstraintName("FK_yarn_returnfromKnittergriege_Yarn_KnittingContractMaster");
            //});

            //modelBuilder.Entity<YarnReturnfromWorkOrder>(entity =>
            //{
            //    entity.HasKey(e => e.RwoId);

            //    entity.ToTable("yarn_returnfromWorkOrder");

            //    entity.Property(e => e.RwoId).HasColumnName("RWO_ID");

            //    entity.Property(e => e.ReturnDate).HasColumnType("datetime");

            //    entity.Property(e => e.ReturnedYarn).HasColumnType("numeric(18, 5)");

            //    entity.Property(e => e.WorkOrderId).HasColumnName("WorkORderID");

            //    entity.HasOne(d => d.WorkOrder)
            //        .WithMany(p => p.YarnReturnfromWorkOrder)
            //        .HasForeignKey(d => d.WorkOrderId)
            //        .HasConstraintName("FK_yarn_yarn_returnfromWorkOrder_Yarn_WorkOrderMaster");
            //});

            //modelBuilder.Entity<YarnStatusPo>(entity =>
            //{
            //    entity.ToTable("yarn_StatusPo");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50);
            //});

            //modelBuilder.Entity<YarnStockAdjustment>(entity =>
            //{
            //    entity.ToTable("Yarn_StockAdjustment");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");
            //});

            //modelBuilder.Entity<YarnStockTransactions>(entity =>
            //{
            //    entity.HasKey(e => e.YarnStockTransactionId);

            //    entity.ToTable("Yarn_StockTransactions");

            //    entity.Property(e => e.YarnStockTransactionId).HasColumnName("YarnStockTransactionID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.BagName)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.BagTypeId).HasColumnName("BagTypeID");

            //    entity.Property(e => e.BatchNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.BrandId).HasColumnName("BrandID");

            //    entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.ConeTypeId).HasColumnName("ConeTypeID");

            //    entity.Property(e => e.DocumentDate).HasColumnType("datetime");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.GrossId).HasColumnName("GrossID");

            //    entity.Property(e => e.KnittingJobId).HasColumnName("KnittingJobID");

            //    entity.Property(e => e.LotNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.MfgDate).HasColumnType("datetime");

            //    entity.Property(e => e.MovingAverage).HasColumnType("numeric(18, 4)");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.ObconversionRate).HasColumnName("OBConversionRate");

            //    entity.Property(e => e.ObcurrencyId).HasColumnName("OBCurrencyID");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.OrderNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PackagingId).HasColumnName("PackagingID");

            //    entity.Property(e => e.ProgramTypeId).HasColumnName("ProgramTypeID");

            //    entity.Property(e => e.Rate)
            //        .HasColumnName("rate")
            //        .HasColumnType("numeric(18, 4)");

            //    entity.Property(e => e.RateUnitId).HasColumnName("rateUnitID");

            //    entity.Property(e => e.RateWrtbaseUnit)
            //        .HasColumnName("RateWRTBaseUnit")
            //        .HasColumnType("numeric(18, 4)");

            //    entity.Property(e => e.ReqAttributeInstanceId).HasColumnName("ReqAttributeInstanceID");

            //    entity.Property(e => e.StoreLocationId).HasColumnName("StoreLocationID");

            //    entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

            //    entity.Property(e => e.TransactionDate).HasColumnType("datetime");

            //    entity.Property(e => e.TransactionQty).HasColumnType("numeric(18, 4)");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");

            //    entity.Property(e => e.YarnKnittingContractId).HasColumnName("YarnKnittingContractID");
            //});

            //modelBuilder.Entity<YarnStockTransactionsStatusSetup>(entity =>
            //{
            //    entity.HasKey(e => e.YarnStransId);

            //    entity.ToTable("Yarn_StockTransactionsStatus_Setup");

            //    entity.Property(e => e.YarnStransId)
            //        .HasColumnName("YarnSTransID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<YarnStvissuanceAssociation>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Yarn_STVIssuanceAssociation");

            //    entity.Property(e => e.AssociationId)
            //        .HasColumnName("AssociationID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.IssuanceId)
            //        .HasColumnName("ISsuanceID")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Stv)
            //        .HasColumnName("STV")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId).HasColumnName("USerID");

            //    entity.Property(e => e.Ykcid).HasColumnName("YKCID");
            //});

            //modelBuilder.Entity<YarnSupplierInitial>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Yarn_SupplierInitial");

            //    entity.Property(e => e.Initial)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

            //    entity.Property(e => e.YarnSupplierInitialId)
            //        .HasColumnName("Yarn_SupplierInitialID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<Yarn_TemporaryReceivingMaster>(entity =>
            //{
            //        entity.HasNoKey();
            //    entity.HasKey(e => e.YarnTempRecId);

            //    entity.ToTable("Yarn_TemporaryReceivingMaster");

            //    entity.Property(e => e.YarnTempRecId).HasColumnName("YarnTempRecID");

            //    entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.DeliveryChallanNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

            //    entity.Property(e => e.DeliveryPerson)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Poid).HasColumnName("POID");

            //    entity.Property(e => e.YarnGateRecId).HasColumnName("YarnGateRecID");

            //    entity.Property(e => e.YarnTempRecNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.HasOne(d => d.YarnGateRec)
            //        .WithMany(p => p.YarnTemporaryReceivingMaster)
            //        .HasForeignKey(d => d.YarnGateRecId)
            //        .HasConstraintName("FK_Yarn_TemporaryReceivingMaster_Yarn_GateReceivingMaster");
            //  });

            //modelBuilder.Entity<YarnTermsOfPaymentSetup>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Yarn_TermsOfPayment_Setup");

            //    entity.Property(e => e.PaymentModeId).HasColumnName("PaymentModeID");

            //    entity.Property(e => e.Topdesc)
            //        .IsRequired()
            //        .HasColumnName("TOPDesc")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Topid)
            //        .HasColumnName("TOPID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<YarnUnitSetup>(entity =>
            //{
            //    entity.HasKey(e => e.UnitId);

            //    entity.ToTable("Yarn_UnitSetup");

            //    entity.Property(e => e.UnitId)
            //        .HasColumnName("UnitID")
            //        .HasComment("This is the Yarn Unit ID and Primary Key");

            //    entity.Property(e => e.DisplayName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .HasComment("The Description  Shown on the Page");

            //    entity.Property(e => e.IsSku)
            //        .HasColumnName("isSKU")
            //        .HasComment("Is this Unit the SKU for Yarn Ex. 1=SKU 0=Not SKU");

            //    entity.Property(e => e.Skuconversion)
            //        .HasColumnName("SKUConversion")
            //        .HasComment("The Divisor or Multiplier to get the Quantity in SKU Unit");

            //    entity.Property(e => e.UnitName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .HasComment("The Full Name of the Unit Ex. 50KG/Bags");
            //});

            //modelBuilder.Entity<YarnWeighingBagWise>(entity =>
            //{
            //    entity.ToTable("Yarn_Weighing_BagWise");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.BagName)
            //        .HasMaxLength(80)
            //        .IsUnicode(false);

            //    entity.Property(e => e.GrossBagWeight)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Lcno)
            //        .HasColumnName("LCNO")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.LotNo)
            //        .HasMaxLength(400)
            //        .IsUnicode(false);

            //    entity.Property(e => e.NetBagWeight)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Poid).HasColumnName("POID");

            //    entity.Property(e => e.TempRecId).HasColumnName("TempRecID");
            //});

            //modelBuilder.Entity<YarnWeighingInspectionDetail>(entity =>
            //{
            //    entity.HasKey(e => e.YarnWeighDetailId);

            //    entity.ToTable("Yarn_WeighingInspectionDetail");

            //    entity.Property(e => e.YarnWeighDetailId).HasColumnName("Yarn_WeighDetailID");

            //    entity.Property(e => e.Weight).HasColumnType("numeric(18, 5)");

            //    entity.Property(e => e.YarnWeighInspId).HasColumnName("YarnWeighInspID");

            //    entity.HasOne(d => d.YarnWeighInsp)
            //        .WithMany(p => p.YarnWeighingInspectionDetail)
            //        .HasForeignKey(d => d.YarnWeighInspId)
            //        .OnDelete(DeleteBehavior.Cascade)
            //        .HasConstraintName("FK_Yarn_WeighingInspectionDetail_Yarn_WeighingInspectionMaster");
            //});

            //modelBuilder.Entity<YarnWeighingInspectionMaster>(entity =>
            //{
            //    entity.HasKey(e => e.YarnWeighInspId);

            //    entity.ToTable("Yarn_WeighingInspectionMaster");

            //    entity.Property(e => e.YarnWeighInspId)
            //        .HasColumnName("YarnWeighInspID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.AverageGrossWeightPerUnit).HasColumnType("numeric(18, 5)");

            //    entity.Property(e => e.AverageNetWeightPerUnit).HasColumnType("numeric(18, 5)");

            //    entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

            //    entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            //    entity.Property(e => e.InspectionDate).HasColumnType("datetime");

            //    entity.Property(e => e.InspectionNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Poid).HasColumnName("POID");

            //    entity.Property(e => e.SampleUnit).HasColumnName("SampleUNit");

            //    entity.Property(e => e.StandardWeightPerUnit).HasColumnType("numeric(18, 5)");

            //    entity.Property(e => e.TarePerUnit).HasColumnType("numeric(18, 5)");

            //    entity.Property(e => e.TotalQty).HasColumnType("numeric(18, 5)");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.Property(e => e.UserName)
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.YarnTempRecId).HasColumnName("YarnTempRecID");
            //});

            //modelBuilder.Entity<YarnWodeliverySchedule>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Yarn_WODeliverySchedule");

            //    entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

            //    entity.Property(e => e.DeliveryQty).HasColumnName("DeliveryQTY");

            //    entity.Property(e => e.YarnDelSchId)
            //        .HasColumnName("YarnDelSchID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.YarnWoid).HasColumnName("Yarn_WOID");
            //});

            //modelBuilder.Entity<YarnWogateReceivingDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Yarn_WOGateReceivingDetail");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPitemCode");

            //    entity.Property(e => e.RateUnitId).HasColumnName("RateUnitID");

            //    entity.Property(e => e.ReceivingQty).HasColumnName("ReceivingQTY");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");

            //    entity.Property(e => e.YarnGateRecDetailId)
            //        .HasColumnName("YarnGateRecDetailID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.YarnGateRecId).HasColumnName("YarnGateRecID");

            //    entity.Property(e => e.YarnWorecDetailId).HasColumnName("Yarn_WORecDetailID");
            //});

            //modelBuilder.Entity<YarnWogateReceivingMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Yarn_WOGateReceivingMaster");

            //    entity.Property(e => e.DeliveryChallanDate).HasColumnType("datetime");

            //    entity.Property(e => e.DeliveryChallanNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DeliveryPerson)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Woid).HasColumnName("WOID");

            //    entity.Property(e => e.WotypeId).HasColumnName("WOTypeID");

            //    entity.Property(e => e.YarnGateEntryNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.YarnGateRecId)
            //        .HasColumnName("YarnGateRecID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<YarnWoissRecAssociate>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Yarn_WOIssRecAssociate");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.YarnWoid).HasColumnName("Yarn_WOID");

            //    entity.Property(e => e.YarnWoissDetailId).HasColumnName("Yarn_WOIssDetailID");

            //    entity.Property(e => e.YarnWorecDetailId).HasColumnName("Yarn_WORecDetailID");
            //});

            //modelBuilder.Entity<YarnWoissuedYarnDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Yarn_WOIssuedYarnDetail");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.BalanceQty).HasColumnName("BalanceQTY");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.OrderQty).HasColumnName("OrderQTY");

            //    entity.Property(e => e.TempBalanceQty).HasColumnName("tempBalanceQty");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");

            //    entity.Property(e => e.YarnWoissDetailId)
            //        .HasColumnName("Yarn_WOIssDetailID")
            //        .ValueGeneratedOnAdd();
            //});

            modelBuilder.Entity<Yarn_WOMaster>(entity =>
            {
                entity.HasNoKey();

                //    entity.ToTable("Yarn_WOMaster");

                //    entity.Property(e => e.Comments)
                //        .HasMaxLength(8000)
                //        .IsUnicode(false);

                //    entity.Property(e => e.ModeId).HasColumnName("ModeID");

                //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

                //    entity.Property(e => e.OrderNo)
                //        .HasMaxLength(50)
                //        .IsUnicode(false);

                //    entity.Property(e => e.ProgramTypeId).HasColumnName("ProgramTypeID");

                //    entity.Property(e => e.ReferenceNumber)
                //        .HasMaxLength(800)
                //        .IsUnicode(false);

                //    entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                //    entity.Property(e => e.TermId).HasColumnName("TermID");

                //    entity.Property(e => e.UserId).HasColumnName("UserID");

                //    entity.Property(e => e.Wodate)
                //        .HasColumnName("WODate")
                //        .HasColumnType("datetime");

                //    entity.Property(e => e.WotypeId).HasColumnName("WOTypeID");

                //    entity.Property(e => e.YarnStoreLocationId).HasColumnName("YarnStoreLocationID");

                //    entity.Property(e => e.YarnWoid)
                //        .HasColumnName("Yarn_WOID")
                //        .ValueGeneratedOnAdd();

                //    entity.Property(e => e.YarnWono)
                //        .HasColumnName("YarnWONo")
                //        .HasMaxLength(50)
                //        .IsUnicode(false);
            });

            //modelBuilder.Entity<YarnWopermanentReceivingMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Yarn_WOPermanentReceivingMaster");

            //    entity.Property(e => e.Woid).HasColumnName("WOID");

            //    entity.Property(e => e.YarnPermRecDate).HasColumnType("datetime");

            //    entity.Property(e => e.YarnPermRecId)
            //        .HasColumnName("YarnPermRecID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.YarnPermRecNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.YarnTempRecId).HasColumnName("YarnTempRecID");

            //    entity.Property(e => e.YarnWeighingId).HasColumnName("yarnWeighingID");
            //});

            //modelBuilder.Entity<YarnWoreceivedYarnDetail>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Yarn_WOReceivedYarnDetail");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.BalanceQty).HasColumnName("BalanceQTY");

            //    entity.Property(e => e.ColorCode)
            //        .HasMaxLength(80)
            //        .IsUnicode(false);

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.OrderQty).HasColumnName("OrderQTY");

            //    entity.Property(e => e.RateUnitId).HasColumnName("RateUnitID");

            //    entity.Property(e => e.TempBalanceQty).HasColumnName("tempBalanceQty");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");

            //    entity.Property(e => e.YarnWorecDetailId)
            //        .HasColumnName("Yarn_WORecDetailID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<YarnWorkOrderDeliverySchedule>(entity =>
            //{
            //    entity.HasKey(e => e.WorkOrderDelSchdId);

            //    entity.ToTable("Yarn_WorkOrderDeliverySchedule");

            //    entity.Property(e => e.WorkOrderDelSchdId).HasColumnName("WorkOrderDelSchdID");

            //    entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

            //    entity.Property(e => e.DeliveryLocationId).HasColumnName("DeliveryLocationID");

            //    entity.Property(e => e.Weight).HasColumnType("numeric(9, 5)");

            //    entity.Property(e => e.WorkOrderId).HasColumnName("WorkOrderID");

            //    entity.HasOne(d => d.WorkOrder)
            //        .WithMany(p => p.YarnWorkOrderDeliverySchedule)
            //        .HasForeignKey(d => d.WorkOrderId)
            //        .OnDelete(DeleteBehavior.Cascade)
            //        .HasConstraintName("FK_Yarn_WorkOrderDeliverySchedule_Yarn_WorkOrderMaster");
            //});

            //modelBuilder.Entity<YarnWorkOrderDetail>(entity =>
            //{
            //    entity.HasKey(e => e.WorkOrderDetailId);

            //    entity.ToTable("Yarn_WorkOrderDetail");

            //    entity.Property(e => e.WorkOrderDetailId).HasColumnName("WorkOrderDetailID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.WorkOrderId).HasColumnName("WorkOrderID");

            //    entity.HasOne(d => d.WorkOrder)
            //        .WithMany(p => p.YarnWorkOrderDetail)
            //        .HasForeignKey(d => d.WorkOrderId)
            //        .HasConstraintName("FK_Yarn_WorkOrderDetail_Yarn_WorkOrderMaster");
            //});

            //modelBuilder.Entity<YarnWorkOrderIssueMaster>(entity =>
            //{
            //    entity.HasKey(e => e.WorkOrderIssueId);

            //    entity.ToTable("Yarn_WorkOrderIssueMaster");

            //    entity.Property(e => e.WorkOrderIssueId).HasColumnName("WorkOrderIssueID");

            //    entity.Property(e => e.IssuanceDate).HasColumnType("datetime");

            //    entity.Property(e => e.WorkOrderId).HasColumnName("WorkOrderID");
            //});

            //modelBuilder.Entity<YarnWorkOrderMaster>(entity =>
            //{
            //    entity.HasKey(e => e.WorkOrderId);

            //    entity.ToTable("Yarn_WorkOrderMaster");

            //    entity.Property(e => e.WorkOrderId).HasColumnName("WorkOrderID");

            //    entity.Property(e => e.BalanceQty).HasColumnType("numeric(9, 5)");

            //    entity.Property(e => e.Comments)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.KnitterId).HasColumnName("KnitterID");

            //    entity.Property(e => e.ModeOfPayment)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.OrderNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ProgramTypeId).HasColumnName("ProgramTypeID");

            //    entity.Property(e => e.RatePerKg)
            //        .HasColumnName("RatePerKG")
            //        .HasColumnType("numeric(18, 4)");

            //    entity.Property(e => e.TermOfPayment)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.TotalQty).HasColumnType("numeric(9, 5)");

            //    entity.Property(e => e.WorkOrderDate).HasColumnType("datetime");

            //    entity.Property(e => e.WorkOrderName)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.YarnAttributeInstanceId).HasColumnName("YarnAttributeInstanceID");

            //    entity.Property(e => e.YarnMrp).HasColumnName("YarnMRP");
            //});

            //modelBuilder.Entity<YarnWorkOrderStockTransactions>(entity =>
            //{
            //    entity.HasKey(e => e.WorkOrderStockTransactionId);

            //    entity.ToTable("Yarn_WorkOrderStockTransactions");

            //    entity.Property(e => e.WorkOrderStockTransactionId).HasColumnName("WorkOrderStockTransactionID");

            //    entity.Property(e => e.AttributeInstanceId).HasColumnName("AttributeInstanceID");

            //    entity.Property(e => e.BatchNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.BrandId).HasColumnName("BrandID");

            //    entity.Property(e => e.DocumentDate).HasColumnType("datetime");

            //    entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            //    entity.Property(e => e.LotNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.MfgDate).HasColumnType("datetime");

            //    entity.Property(e => e.MovingAverage).HasColumnType("numeric(18, 4)");

            //    entity.Property(e => e.MrpitemCode).HasColumnName("MRPItemCode");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.OrderNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PackagingId).HasColumnName("PackagingID");

            //    entity.Property(e => e.ProgramTypeId).HasColumnName("ProgramTypeID");

            //    entity.Property(e => e.Rate)
            //        .HasColumnName("rate")
            //        .HasColumnType("numeric(18, 4)");

            //    entity.Property(e => e.RateUnitId).HasColumnName("rateUnitID");

            //    entity.Property(e => e.RateWrtbaseUnit)
            //        .HasColumnName("RateWRTBaseUnit")
            //        .HasColumnType("numeric(18, 4)");

            //    entity.Property(e => e.StoreLocationId).HasColumnName("StoreLocationID");

            //    entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

            //    entity.Property(e => e.TransactionDate).HasColumnType("datetime");

            //    entity.Property(e => e.TransactionQty).HasColumnType("numeric(18, 4)");

            //    entity.Property(e => e.UnitId).HasColumnName("UnitID");

            //    entity.Property(e => e.WorkOrderId).HasColumnName("WorkOrderID");

            //    entity.Property(e => e.WorkOrderTypeId).HasColumnName("WorkOrderTypeID");

            //    entity.Property(e => e.YarnIssuanceId).HasColumnName("YarnIssuanceID");

            //    entity.Property(e => e.YarnStockTransactionId).HasColumnName("YarnStockTransactionID");
            //});

            //modelBuilder.Entity<YarnWotempReceivingMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Yarn_WOTempReceivingMaster");

            //    entity.Property(e => e.DeliveryChallanNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

            //    entity.Property(e => e.DeliveryPerson)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Woid).HasColumnName("WOID");

            //    entity.Property(e => e.YarnGateRecId).HasColumnName("YarnGateRecID");

            //    entity.Property(e => e.YarnTempRecId)
            //        .HasColumnName("YarnTempRecID")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.YarnTempRecNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<YarnWotype>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Yarn_WOType");

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<YarnWoweighingInspectionMaster>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Yarn_WOWeighingInspectionMaster");

            //    entity.Property(e => e.InspectionDate).HasColumnType("datetime");

            //    entity.Property(e => e.InspectionNo)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.Property(e => e.Woid).HasColumnName("WOID");

            //    entity.Property(e => e.YarnTempRecId).HasColumnName("YarnTempRecID");

            //    entity.Property(e => e.YarnWeighInspId)
            //        .HasColumnName("YarnWeighInspID")
            //        .ValueGeneratedOnAdd();
            //});

            //modelBuilder.Entity<YkncclosureSetup>(entity =>
            //{
            //    entity.ToTable("YKNCClosure_Setup");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(200)
            //        .IsUnicode(false);
            //});

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
