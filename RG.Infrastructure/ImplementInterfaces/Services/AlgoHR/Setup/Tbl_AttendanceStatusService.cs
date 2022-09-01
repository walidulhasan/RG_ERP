using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Repositories.AlgoHR.Setup;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AlgoHR.Setup
{
    public class Tbl_AttendanceStatusService : ITbl_AttendanceStatusService
    {
        private readonly ITbl_AttendanceStatusRepository _tbl_AttendanceStatusRepository;

        public Tbl_AttendanceStatusService(ITbl_AttendanceStatusRepository tbl_AttendanceStatusRepository)
        {
            _tbl_AttendanceStatusRepository = tbl_AttendanceStatusRepository;
        }
        public async Task<List<SelectListItem>> DDLAttendanceStatus(CancellationToken cancellationToken = default)
        {
            return await _tbl_AttendanceStatusRepository.DDLAttendanceStatus(cancellationToken);
        }
    }
}
