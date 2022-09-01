using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Setups.SystemNotices.Commands.DataTransferModel;
using RG.Application.Contracts.AlgoHR.Setups.SystemNotices.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AlgoHR.Setup
{
    public interface ISystemNoticeService
    {
        Task<RResult> SystemNoticeSave(SystemNoticeDTM notice);
        Task<SystemNoticeRM> GetSystemNotice(int noticeID, CancellationToken cancellationToken);
        Task<RResult> SystemNoticeUpdate(int noticeID);
        Task<RResult> SystemNoticeDelete(int noticeID);
        IQueryable<SystemNoticeRM> GetNoticeList(CancellationToken cancellationToken);
        Task<List<SystemNoticeRM>> GetAllNotices(int companyID, int divisionID, int departmentID, int sectionID);
    }
}
