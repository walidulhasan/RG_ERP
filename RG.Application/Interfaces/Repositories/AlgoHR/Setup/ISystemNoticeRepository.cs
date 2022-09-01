using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Setups.SystemNotices.Queries.RequestResponseModel;
using RG.DBEntities.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.AlgoHR.Setup
{
    public interface ISystemNoticeRepository:IGenericRepository<SystemNotice>
    {
        Task<RResult> SystemNoticeSave(SystemNotice notice);
        Task<SystemNotice> GetSystemNotice(int noticeID, CancellationToken cancellationToken);
        Task<RResult> SystemNoticeUpdate(SystemNotice notice);
        IQueryable<SystemNoticeRM> GetNoticeList(CancellationToken cancellationToken);
        Task <List<SystemNoticeRM>> GetAllNotices(int companyID,int divisionID,int departmentID,int sectionID);
    }
}
