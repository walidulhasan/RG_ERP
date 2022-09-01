using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.Tbl_AttendanceStatuss.Query
{
    public class GetDDLAttendanceStatusQuery :IRequest<List<SelectListItem>>
    {
    }

    public class GetDDLAttendanceStatusQueryHandler : IRequestHandler<GetDDLAttendanceStatusQuery, List<SelectListItem>>
    {
        private readonly ITbl_AttendanceStatusService _tbl_AttendanceStatusService;

        public GetDDLAttendanceStatusQueryHandler(ITbl_AttendanceStatusService tbl_AttendanceStatusService)
        {
            _tbl_AttendanceStatusService = tbl_AttendanceStatusService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLAttendanceStatusQuery request, CancellationToken cancellationToken)
        {
            return await _tbl_AttendanceStatusService.DDLAttendanceStatus(cancellationToken);
        }
    }


}
