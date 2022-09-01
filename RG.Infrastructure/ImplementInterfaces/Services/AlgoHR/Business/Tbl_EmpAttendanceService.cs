using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.Tbl_EmpAttendances.Query.RequestResponseModel;
using RG.Application.Enums;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AlgoHR.Business
{
    public class Tbl_EmpAttendanceService : ITbl_EmpAttendanceService
    {
        private readonly ITbl_EmpAttendanceRepository tbl_EmpAttendanceRepository;

        public Tbl_EmpAttendanceService(ITbl_EmpAttendanceRepository _tbl_EmpAttendanceRepository)
        {
            tbl_EmpAttendanceRepository = _tbl_EmpAttendanceRepository;
        }


        public async Task<RResult> AttendanceStatusChange(long epmID,DateTime leaveDateForm, DateTime leaveDateTo, short attStatus, bool saveChanges = true)
        {
            try
            {
                RResult result = new();
                for (DateTime dateForm = leaveDateForm; dateForm <= leaveDateTo; dateForm=dateForm.AddDays(1))
                {
                    var dbModel = await tbl_EmpAttendanceRepository.FindAsync(x => x.Att_Emp == epmID && x.Att_Date == dateForm);
                    if (dbModel!= null)
                    {
                        if(dbModel.Att_InTime==null)
                            dbModel.Att_Status = (int)enum_AttendanceStatus.Absent;
                        else
                        dbModel.Att_Status = attStatus;
                        
                        dbModel.Att_Remarks = "Leave Canceled.";
                        await tbl_EmpAttendanceRepository.UpdateAsync(dbModel, saveChanges);                       
                    }
                }
           
               result.result = 1;
                result.message = ReturnMessage.UpdateMessage;
                
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<RResult> GenerateAttendance(DateTime dateFrom, DateTime dateTo, int divID, int deptID, int secID, int location, string empCode, int overWrite)
        {
            return await tbl_EmpAttendanceRepository.GenerateAttendance(dateFrom, dateTo, divID, deptID, secID, location, empCode, overWrite);
        }

        public async Task<List<LateHistoryRM>> GetEmployeeLateHistory(int employeeID, string employeeCode, DateTime dateFrom, DateTime dateTo, CancellationToken cancellationToken)
        {
            return await tbl_EmpAttendanceRepository.GetEmployeeLateHistory(employeeID, employeeCode, dateFrom, dateTo, cancellationToken);
        }

        public async Task<EmployeeShiftShortInfoRM> GetEmployeeShiftShortInfo(int employeeID, DateTime shiftDate, CancellationToken cancellationToken)
        {
            return await tbl_EmpAttendanceRepository.GetEmployeeShiftShortInfo(employeeID, shiftDate, cancellationToken);
        }

        public async Task<List<LateEmployeesRM>> GetLateEmployees(int CompanyID, int OfficeDivisionID, int DepartmentID, int SectionID, int Year, int Month)
        {
            return await tbl_EmpAttendanceRepository.GetLateEmployees(CompanyID, OfficeDivisionID, DepartmentID, SectionID, Year, Month);
        }

        public async Task<List<LeftyEmployeeRM>> GetLeftyEmployeeList(DateTime dateTo, int noOfAbsentDays, string companyID, string divisionID, string departmentID, bool isStaff = false)
        {
            return await tbl_EmpAttendanceRepository.GetLeftyEmployeeList(dateTo, noOfAbsentDays, companyID, divisionID, departmentID, isStaff);
        }

        public IQueryable<MyAttendanceInfoRM> GetMyAttendanceInfoData(long EmployeeID,string AttendanceStatus, DateTime DateFrom, DateTime DateTo)
        {
            return tbl_EmpAttendanceRepository.GetMyAttendanceInfoData(EmployeeID,AttendanceStatus,DateFrom,DateTo);
        }

        
    }
}
