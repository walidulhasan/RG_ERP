using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.LateAttendanceWarningLetterMasters.Query.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AlgoHR.Business
{
    public interface ILateAttendanceWarningLetterMasterService
    {
        Task<RResult> SaveLateAttendanceWarningLetter(int employeeID, DateTime dateFrom, DateTime dateTo, CancellationToken cancellationToken);
        Task<List<LateWarningLetterRM>> GetEmployeeWiseLateWarningLetter(int employeeID, int year, int month, CancellationToken cancellationToken);
    }
}
