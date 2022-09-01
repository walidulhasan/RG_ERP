using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Commands.DataTransferModel;
using RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries.RequestResponseModel;
using RG.Application.ViewModel.MaterialsManagement.Business.GatePass;
using RG.DBEntities.MaterialsManagement.Business;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.MaterialsManagement.Business
{
    public interface IIC_GatepassMasterService
    {
        IQueryable<GatepassRM> GetICBrowseGetPassesList(GatepassQM model);
        Task<string> GetGatePassSerial(byte categoryID);
        Task<RResult> SaveLocalSales(LocalSalesGatePassDTM model, CancellationToken cancellationToken);
        Task<RResult> SaveExportSalses(ExportSalesGatePassDTM model, CancellationToken cancellationToken);
        Task<RResult> SaveScrapSales(ScrapSalesGatePassDTM model, CancellationToken cancellationToken);
        Task<List<GatePassAccountIssueRM>> GetGatePassAccountIssueList(GatePassAccountIssueQM reqModel, CancellationToken cancellationToken);
        Task<RResult> SaveNonReturnable(NonReturnableGatePassDTM model, CancellationToken cancellationToken);
        Task<RResult> GatepassMasterAccountsApprovalInfoUpdate(long gatePassMasterID, bool isApproved, CancellationToken cancellationToken);
        Task<RResult> SaveSampleGatePass(SampleGatePassDTM model, CancellationToken cancellationToken);
        Task<RResult> SaveReturnableGatePass(ReturnableGatePassDTM model, CancellationToken cancellationToken);
        Task<IC_GatepassMasterRM> GetIC_GatepassMasterDetailInfoByID(long gatePassID, CancellationToken cancellationToken);

        Task<RResult> ApprovedGatePass(long gatePassID, CancellationToken cancellationToken);
        Task<RResult> MarkedOutGatePass(long gatePassID, int userID, CancellationToken cancellationToken);

        //Task<RResult> UpdateLocalSales(LocalSalesGatePassDTM model, CancellationToken cancellationToken);
        Task<RResult> RemoveIC_GatepassMaster(long id, CancellationToken cancellationToken);
        //Task<RResult> MapAndrUpdate(IC_GatepassMasterDTM entity, CancellationToken cancellationToken);        
        Task<RResult> UpdateGatepassMasterDetail(IC_GatepassMaster entity, CancellationToken cancellationToken);
        // Task<RResult> UpdateGatepassMaster(IC_GatepassMaster entity, CancellationToken cancellationToken);
        Task<List<GatepassRM>> GetGatePassApprovalList(GatepassQM model, CancellationToken cancellationToken);
        Task<List<GatepassRM>> GetGatePassMarkOutList(GatepassQM model, CancellationToken cancellationToken);
        Task<List<GatepassRM>> GetGatePassReceivableList(GatepassQM model, CancellationToken cancellationToken);
        Task<RResult> RemoveGatepass(long gatePassID, bool isSuperAdmin, CancellationToken cancellationToken);
        //Task<GatePassNotificationResponseModel> GetGatePassNotification();
        //Task<List<NotificationResponseModel>> GetAllNotifications();
        Task<bool> IsApprovedGatePass(long gatePassID, CancellationToken cancellationToken);
        Task<List<ExportSalesItemVM>> GetExportSalesItem(long GatePassID, CancellationToken cancellationToken);
        Task<List<ReturnableItemVM>> GetReturnableItem(long GatePassID, CancellationToken cancellationToken);
        Task<List<LocalSalesItemVM>> GetLocalSalesItem(long GatePassID, CancellationToken cancellationToken);
    }
}
