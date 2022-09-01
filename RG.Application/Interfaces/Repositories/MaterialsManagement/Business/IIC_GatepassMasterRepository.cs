using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries.RequestResponseModel;
using RG.Application.ViewModel.MaterialsManagement.Business.GatePass;
using RG.DBEntities.MaterialsManagement.Business;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.MaterialsManagement.Business
{
    public interface IIC_GatepassMasterRepository : IGenericRepository<IC_GatepassMaster>
    {
        IQueryable<GatepassRM> GetICBrowseGetPassesList(GatepassQM model);
        Task<RResult> SaveGatepassMaster(IC_GatepassMaster entity, CancellationToken cancellationToken);
        Task<string> GetGatePassSerial(byte categoryID);
        Task<List<GatePassAccountIssueRM>> GetGatePassAccountIssueList(GatePassAccountIssueQM reqModel, CancellationToken cancellationToken);
        Task<RResult> UpdateGatepassMaster(IC_GatepassMaster entity, CancellationToken cancellationToken);
        Task<RResult> UpdateGatepassMasterDetail(IC_GatepassMaster entity, CancellationToken cancellationToken);
        Task<IC_GatepassMaster> GetIC_GatepassMasterDetailInfoByID(long gatePassID, CancellationToken cancellationToken);
        Task<RResult> ApprovedGatePass(long gatePassID, int userID, CancellationToken cancellationToken);
        Task<RResult> MarkedOutGatePass(long gatePassID, int userID, CancellationToken cancellationToken);
        Task<RResult> RemoveMasterIfDetailNotExists(long gatePassID, CancellationToken cancellationToken);
        Task<List<GatepassRM>> GetGatePassApprovalList(GatepassQM model, CancellationToken cancellationToken);
        Task<List<GatepassRM>> GetGatePassMarkOutList(GatepassQM model, CancellationToken cancellationToken);
        Task<List<GatepassRM>> GetGatePassReceivableList(GatepassQM model, CancellationToken cancellationToken);
        Task<RResult> RemoveGatepass(long gatePassID, bool isSuperAdmin, CancellationToken cancellationToken);
        Task<bool> IsApprovedGatePass(long gatePassID, CancellationToken cancellationToken);
        Task<List<ExportSalesItemVM>> GetExportSalesItem(long GatePassID, CancellationToken cancellationToken);
        Task<List<LocalSalesItemVM>> GetLocalSalesItem(long GatePassID, CancellationToken cancellationToken);
        //Task<GatePassNotificationResponseModel> GetGatePassNotification();
        //Task<List<NotificationResponseModel>> GetAllNotifications();
        //Task<List<SelectListItem>> GetExportGatePassWiseOrderList(long GatePassID);
        Task<List<ReturnableItemVM>> GetReturnableItem(long GatePassID, CancellationToken cancellationToken);
    }
}
