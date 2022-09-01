using AutoMapper;
using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Setups.SystemNotices.Commands.DataTransferModel;
using RG.Application.Contracts.AlgoHR.Setups.SystemNotices.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Setup;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using RG.DBEntities.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AlgoHR.Setup
{
    public class SystemNoticeService : ISystemNoticeService
    {
        private readonly ISystemNoticeRepository _systemNoticeRepository;
        private readonly IMapper _mapper;

        public SystemNoticeService(ISystemNoticeRepository systemNoticeRepository,IMapper mapper)
        {
            _systemNoticeRepository = systemNoticeRepository;
            _mapper = mapper;
        }

        public async Task<List<SystemNoticeRM>> GetAllNotices(int companyID, int divisionID, int departmentID, int sectionID)
        {
            return await _systemNoticeRepository.GetAllNotices(companyID, divisionID, departmentID, sectionID);
        }

        public IQueryable<SystemNoticeRM> GetNoticeList(CancellationToken cancellationToken)
        {
            return _systemNoticeRepository.GetNoticeList(cancellationToken);
        }

        public async Task<SystemNoticeRM> GetSystemNotice(int noticeID, CancellationToken cancellationToken)
        {
            var entity = await _systemNoticeRepository.GetSystemNotice(noticeID,cancellationToken);
            var model = _mapper.Map<SystemNotice, SystemNoticeRM>(entity);
            return model;

        }

        public async Task<RResult> SystemNoticeDelete(int noticeID)
        {
            var entity = await _systemNoticeRepository.GetByIdAsync(noticeID);
            entity.IsRemoved = true;
            return await _systemNoticeRepository.SystemNoticeUpdate(entity);
        }

        public async Task<RResult> SystemNoticeSave(SystemNoticeDTM notice)
        {
            if(notice.ValidTimeFrom!=null)
            notice.ValidDateFrom = notice.ValidDateFrom.Date + Convert.ToDateTime(notice.ValidTimeFrom).TimeOfDay;
            if (notice.ValidTimeTo != null)
                notice.ValidDateTo = notice.ValidDateTo.Date + Convert.ToDateTime(notice.ValidTimeTo).TimeOfDay;
            var noticeEntity = _mapper.Map<SystemNoticeDTM, SystemNotice>(notice);
            return await _systemNoticeRepository.SystemNoticeSave(noticeEntity);
        }

        public async Task<RResult> SystemNoticeUpdate(int noticeID)
        {
            throw new NotImplementedException();
        }
    }
}
