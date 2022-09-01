using Microsoft.EntityFrameworkCore;
using RG.DBEntities.FiniteScheduler.Business;
using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.FiniteScheduler
{
    public interface IFiniteSchedulerDBContext
    {
        #region Setup
         DbSet<tbl_KnittingJobStatus> tbl_KnittingJobStatus { get; set; }
         DbSet<tbl_KnittingRollsQuality_Setup> tbl_KnittingRollsQuality_Setup { get; set; }
         DbSet<MT_Location_Setup> MT_Location_Setup { get; set; }
         DbSet<MT_Machine_Setup> MT_Machine_Setup { get; set; }
         DbSet<MT_MachineMaintenanceCategory_Setup> MT_MachineMaintenanceCategory_Setup { get; set; }
         DbSet<MT_MaintenanceItem_Setup> MT_MaintenanceItem_Setup { get; set; }
         DbSet<MT_MachineAndMaintenanceItemAssociation> MT_MachineAndMaintenanceItemAssociation { get; set; }
         DbSet<MT_MachineMaintenanceStatus> MT_MachineMaintenanceStatus { get; set; }
        
         DbSet<MT_MaintenanceSchedule_Setup> MT_MaintenanceSchedule_Setup { get; set; }
        //
        #endregion


        #region Business
         DbSet<DFS_DCAssociationforLot> DFS_DCAssociationforLot { get; set; }
         DbSet<tbl_KnittingPickListMaster> tbl_KnittingPickListMaster { get; set; }
         DbSet<DFS_LotMakingMaster> DFS_LotMakingMaster { get; set; }
         DbSet<tbl_KnittingPickListDetail> tbl_KnittingPickListDetail { get; set; }
         DbSet<DFS_ReceivingMaster> DFS_ReceivingMaster { get; set; }
         DbSet<tbl_KnittingRolls> tbl_KnittingRolls { get; set; }
         DbSet<DFS_Return_Rolls> DFS_Return_Rolls { get; set; }
         DbSet<tbl_KnittingRolls_Roll_Attributes> tbl_KnittingRolls_Roll_Attributes { get; set; }
         DbSet<DFS_StockTransaction> DFS_StockTransaction { get; set; }
         DbSet<tbl_KnittingStockTransaction> tbl_KnittingStockTransaction { get; set; }
         DbSet<tbl_KnittingSubPickListMaster> tbl_KnittingSubPickListMaster { get; set; }
         DbSet<tbl_GateKnittingRolls> tbl_GateKnittingRolls { get; set; }
         DbSet<tbl_knittingGate> tbl_knittingGate { get; set; }
         DbSet<tbl_KnittingSubPickListDetail> tbl_KnittingSubPickListDetail { get; set; }
         DbSet<tbl_KnittingInspectionMaster> tbl_KnittingInspectionMaster { get; set; }
         DbSet<tbl_KnittingIssuanceMaster> tbl_KnittingIssuanceMaster { get; set; }
         DbSet<tbl_KnittingLaboratoryInspection> tbl_KnittingLaboratoryInspection { get; set; }
         DbSet<tbl_KnittingJobConfirmation> tbl_KnittingJobConfirmation { get; set; }
         DbSet<tbl_KnittingJobs> tbl_KnittingJobs { get; set; }
         DbSet<DFS_IssuanceMaster> DFS_IssuanceMaster { get; set; }
         DbSet<DFS_ConfirmationMaster> DFS_ConfirmationMaster { get; set; }
         DbSet<DFS_InspectionMaster> DFS_InspectionMaster { get; set; }
         DbSet<DFS_InspectionNewAttribute_Setup> DFS_InspectionNewAttribute_Setup { get; set; }
       

         DbSet<MT_MachineAndMaintenanceCheckListMaster> MT_MachineAndMaintenanceCheckListMaster { get; set; }
         DbSet<MT_MachineAndMaintenanceCheckListDetails> MT_MachineAndMaintenanceCheckListDetails { get; set; }
       
        
        //

        #endregion Business
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
