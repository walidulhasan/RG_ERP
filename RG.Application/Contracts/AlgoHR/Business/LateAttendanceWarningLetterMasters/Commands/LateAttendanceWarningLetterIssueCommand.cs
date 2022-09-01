using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.LateAttendanceWarningLetterMasters.Commands
{
    public class LateAttendanceWarningLetterIssueCommand : IRequest<RResult>
    {
        public int EmployeeID { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
    }
    public class LateAttendanceWarningLetterIssueCommandHandler : IRequestHandler<LateAttendanceWarningLetterIssueCommand, RResult>
    {
        private readonly ILateAttendanceWarningLetterMasterService lateAttendanceWarningLetterMasterService;

        public LateAttendanceWarningLetterIssueCommandHandler(ILateAttendanceWarningLetterMasterService _lateAttendanceWarningLetterMasterService)
        {
            lateAttendanceWarningLetterMasterService = _lateAttendanceWarningLetterMasterService;
        }
        public async Task<RResult> Handle(LateAttendanceWarningLetterIssueCommand request, CancellationToken cancellationToken)
        {
            var dateFrom = new DateTime(request.Year, request.Month, 1);
            var dateTo = dateFrom.AddMonths(1).AddDays(-1);
            return await lateAttendanceWarningLetterMasterService.SaveLateAttendanceWarningLetter(request.EmployeeID, dateFrom, dateTo, cancellationToken);
        }
    }
}
