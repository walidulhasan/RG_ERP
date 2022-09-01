
using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.ApprovalNotifications.Queries.RequestResponseModel;
using RG.Application.Contracts.FiniteScheduler.Business.MT_MachineAndMaintenanceCheckListMasters.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Business.MT_MachineAndMaintenanceCheckListMasters.Queries.RequestResponseModel;
using RG.DBEntities.FiniteScheduler.Business;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.FiniteScheduler.Business
{
    public interface IMT_MachineAndMaintenanceCheckListMasterRepository : IGenericRepository<MT_MachineAndMaintenanceCheckListMaster>
    {
        Task<RResult> MachineMaintenceCheckListSave(MT_MachineAndMaintenanceCheckListMaster entity, bool saveChanges = true);
        Task<RResult> MachineMaintenceCheckListUpdate(CheckListMasterDTM model, bool saveChanges = true);
        Task<List<MachineAndMaintenanceCheckRM>> GetMachineAndMaintenanceCheckList(int? machineID, DateTime dateFrom, DateTime dateTo, CancellationToken cancellationToken);
        Task<MachineAndMaintenanceCheckMasterRM> GetMachineAndMaintenanceCheckListMasterData(int Id, CancellationToken cancellationToken);
        //Task<RResult> MachineMaintenceCheckListMasterUpdate(MT_MachineAndMaintenanceCheckListMasterEditViewModel model);
        Task<List<MonthlyMachineMaintainceRM>> GetMonthlyMachineMaintainceReport(int locationID, int month, int year, CancellationToken cancellationToken = default);
        Task<MT_MachineAndMaintenanceCheckListMaster> GetMachineAndMaintenanceCheckListMasterDataByCheckDate(int machineID, DateTime checkDate);
        Task<List<MachineMaintainceItemDetailRM>> GetMachineMaintainceItemDetailInfo(int month, int year, int locationID, int machineID, CancellationToken cancellationToken);
        Task<RResult> UpdateMT_MachineAndMaintenanceCheckListMaster(MT_MachineAndMaintenanceCheckListMaster entity);
        Task<List<MachineMaintenanceNotificationRM>> GetMachineMaintenanceCheckListByNotification(List<MachineMaintenanceNotificationRM> notifications, CancellationToken cancellationToken);
        Task<List<MachineMaintenanceNotificationDetailRM>> GetMachineAndMaintenanceCheckListDetail(int masterID, CancellationToken cancellationToken);

        Task GenerateMonthlyMaintenanceSchedule();
    }
}
