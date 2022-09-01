using MediatR;
using RG.Application.Contracts.AlgoHR.Business.LateAttendanceWarningLetterMasters.Query.RequestResponseModel;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.LateAttendanceWarningLetterMasters.Query
{
    public class GetEmployeeWiseLateAttendanceWarningLetterQuery : IRequest<List<LateWarningLetterRM>>
    {
        public int EmployeeID { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
    }
    public class GetEmployeeWiseLateAttendanceWarningLetterQueryHandler : IRequestHandler<GetEmployeeWiseLateAttendanceWarningLetterQuery, List<LateWarningLetterRM>>
    {
        private readonly ILateAttendanceWarningLetterMasterService lateAttendanceWarningLetterMasterService;
        public GetEmployeeWiseLateAttendanceWarningLetterQueryHandler(ILateAttendanceWarningLetterMasterService _lateAttendanceWarningLetterMasterService)
        {
            lateAttendanceWarningLetterMasterService = _lateAttendanceWarningLetterMasterService;
        }
        public async Task<List<LateWarningLetterRM>> Handle(GetEmployeeWiseLateAttendanceWarningLetterQuery request, CancellationToken cancellationToken)
        {
            return await lateAttendanceWarningLetterMasterService.GetEmployeeWiseLateWarningLetter(request.EmployeeID, request.Year, request.Month, cancellationToken);
        }
    }
}
