using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.Tbl_EmpAttendances.Query.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AlgoHR.Business
{
    public interface ITbl_EmpAttendanceService
    {
        Task<List<LateHistoryRM>> GetEmployeeLateHistory(int employeeID, string employeeCode, DateTime dateFrom, DateTime dateTo, CancellationToken cancellationToken);
        Task<List<LateEmployeesRM>> GetLateEmployees(int CompanyID, int OfficeDivisionID, int DepartmentID, int SectionID, int Year, int Month);
        Task<List<LeftyEmployeeRM>> GetLeftyEmployeeList(DateTime dateTo, int noOfAbsentDays, string companyID, string divisionID, string departmentID, bool isStaff = false);

        IQueryable<MyAttendanceInfoRM> GetMyAttendanceInfoData(long EmployeeID,string AttendanceStatus,DateTime DateFrom, DateTime DateTo);
        Task<EmployeeShiftShortInfoRM> GetEmployeeShiftShortInfo(int employeeID, DateTime shiftDate, CancellationToken cancellationToken);
        Task<RResult> AttendanceStatusChange(long epmID,DateTime leaveDateForm, DateTime leaveDateTo, short attStatus, bool saveChanges = true);
        Task<RResult> GenerateAttendance(DateTime dateFrom, DateTime dateTo, int divID, int deptID, int secID, int location, string empCode, int overWrite);
    }
}
