using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.LateAttendanceWarningLetterMasters.Query.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using RG.DBEntities.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AlgoHR.Business
{
    public class LateAttendanceWarningLetterMasterService : ILateAttendanceWarningLetterMasterService
    {
        private readonly ILateAttendanceWarningLetterMasterRepository lateAttendanceWarningLetterMasterRepository;
        private readonly ITbl_EmpAttendanceService tbl_EmpAttendanceService;

        public LateAttendanceWarningLetterMasterService(ILateAttendanceWarningLetterMasterRepository _lateAttendanceWarningLetterMasterRepository, ITbl_EmpAttendanceService _tbl_EmpAttendanceService)
        {
            lateAttendanceWarningLetterMasterRepository = _lateAttendanceWarningLetterMasterRepository;
            tbl_EmpAttendanceService = _tbl_EmpAttendanceService;
        }

        public async Task<List<LateWarningLetterRM>> GetEmployeeWiseLateWarningLetter(int employeeID, int year, int month, CancellationToken cancellationToken)
        {
            return await lateAttendanceWarningLetterMasterRepository.GetEmployeeWiseLateWarningLetter(employeeID, year, month, cancellationToken);
        }

        public async Task<RResult> SaveLateAttendanceWarningLetter(int employeeID, DateTime dateFrom, DateTime dateTo, CancellationToken cancellationToken)
        {
            try
            {
                var entityDetail = new List<LateAttendanceWarningLetterDetail>();
                var lateHistory = await tbl_EmpAttendanceService.GetEmployeeLateHistory(employeeID, null, dateFrom, dateTo, cancellationToken);

                var entity = new LateAttendanceWarningLetterMaster
                {
                    EmployeeID = employeeID,
                    LetterForMonth = dateFrom.Month,
                    LetterForYear = dateFrom.Year,
                    LetterIssueDate = DateTime.Now,
                    LateAttendanceWarningLetterDetail = lateHistory.Select(x => new LateAttendanceWarningLetterDetail
                    {
                        AttendanceDate = x.AttendanceDate,
                        ShiftInTime = x.ShiftInTime,
                        AttendanceInTime = x.AttendanceInTime
                    }).ToList()
                };
                return await lateAttendanceWarningLetterMasterRepository.SaveLateAttendanceWarningLetter(entity);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
