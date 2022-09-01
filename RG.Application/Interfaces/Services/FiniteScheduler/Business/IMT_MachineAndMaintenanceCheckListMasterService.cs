using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.ApprovalNotifications.Queries.RequestResponseModel;
using RG.Application.Contracts.FiniteScheduler.Business.MT_MachineAndMaintenanceCheckListMasters.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Business.MT_MachineAndMaintenanceCheckListMasters.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.FiniteScheduler.Business
{
    public interface IMT_MachineAndMaintenanceCheckListMasterService
    {
        Task<RResult> MachineMaintenceCheckListSave(CheckListMasterDTM model, bool saveChanges = true);
        Task<RResult> MachineMaintenceCheckListUpdate(CheckListMasterDTM model, bool saveChanges = true);
        Task<MachineAndMaintenanceCheckMasterRM> GetMachineAndMaintenanceCheckListMasterData(int Id, CancellationToken cancellationToken);
        Task<List<MachineAndMaintenanceCheckRM>> GetMachineAndMaintenanceCheckList(int? machineID, DateTime dateFrom, DateTime dateTo,CancellationToken cancellationToken);
        Task<List<MonthlyMachineMaintainceRM>> GetMonthlyMachineMaintainceReport(int locationID, int month, int year,CancellationToken cancellationToken=default);
        Task<List<MachineMaintainceItemDetailRM>> GetMachineMaintainceItemDetailInfo(int month, int year, int locationID, int machineID, CancellationToken cancellationToken);
        Task<List<MachineMaintenanceNotificationDetailRM>> GetMachineAndMaintenanceCheckListDetail(int masterID, CancellationToken cancellationToken);
        Task GenerateMonthlyMaintenanceSchedule();
    }
}
