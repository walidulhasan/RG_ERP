using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.Tbl_Shift.Queries
{
    public class GetDDLAttendanceShiftQuery : IRequest<List<SelectListItem>>
    {

    }

    public class GetDDLAttendanceShiftQueryHandler : IRequestHandler<GetDDLAttendanceShiftQuery, List<SelectListItem>>
    {
        private readonly Itbl_ShiftService _shiftService;

        public GetDDLAttendanceShiftQueryHandler(Itbl_ShiftService shiftService)
        {
            _shiftService = shiftService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLAttendanceShiftQuery request, CancellationToken cancellationToken)
        {
            return await _shiftService.DDLAttendanceShift(cancellationToken);

        }
    }


}
