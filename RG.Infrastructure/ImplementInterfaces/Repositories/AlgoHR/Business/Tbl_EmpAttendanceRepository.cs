using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RG.Application.Common.Models;
using RG.Application.Common.Utilities;
using RG.Application.Contracts.AlgoHR.Business.Tbl_EmpAttendances.Query.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.DBEntities.AlgoHR.Business;
using RG.Infrastructure.Persistence.AlgoHRDB;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Business
{
    public class Tbl_EmpAttendanceRepository : GenericRepository<Tbl_EmpAttendance>, ITbl_EmpAttendanceRepository
    {
        private readonly AlgoHRDBContext dbCon;
        private readonly ILogger<Tbl_EmpAttendanceRepository> _logger;

        public Tbl_EmpAttendanceRepository(AlgoHRDBContext context,ILogger<Tbl_EmpAttendanceRepository> logger)
            : base(context)
        {
            dbCon = context;
            _logger = logger;
        }

        public async Task<RResult> GenerateAttendance(DateTime dateFrom, DateTime dateTo, int divID, int deptID, int secID, int location, string empCode, int overWrite)
        {
            RResult rResult = new();
            try
            {

            await dbCon.LoadStoredProc("dbo.SP_GenerateAttendance", commandTimeout: 1000)
                                .WithSqlParam("pDtF", dateFrom)
                                .WithSqlParam("pDtT", dateTo)
                                .WithSqlParam("Division", divID)
                                .WithSqlParam("depID", deptID)
                                .WithSqlParam("SecID", secID)
                                .WithSqlParam("Location", location)
                                .WithSqlParam("pEmp", empCode)
                                .WithSqlParam("OverWrite", overWrite)
                               .ExecuteStoredNonQueryAsync();
                rResult.result = 1;
                rResult.message = ReturnMessage.UpdateMessage;
            }
            catch (Exception)
            {
                rResult.result = 0;
                rResult.message = ReturnMessage.ErrorMessage;
            }
            return rResult;
        }

        public async Task<Tbl_EmpAttendance> GetEmpAttendance(long employeeID, DateTime attendanceDate, CancellationToken cancellationToken)
        {
            var data = await dbCon.Tbl_EmpAttendance.Where(x => x.Att_Emp == employeeID && x.Att_Date.Date == attendanceDate.Date).FirstOrDefaultAsync(cancellationToken);
            return data;
        }

        public async Task<List<LateHistoryRM>> GetEmployeeLateHistory(int employeeID, string employeeCode, DateTime dateFrom, DateTime dateTo, CancellationToken cancellationToken)
        {

            var data = await (from ea in dbCon.Tbl_EmpAttendance
                              join vw in dbCon.vw_ERP_EmpShortInfo on ea.Att_EmpCd equals vw.EmployeeCode
                              where (employeeID == 0 || vw.EmployeeID == employeeID)
                              && (ea.Att_Status == 3 || ea.Att_Status == 7)
                              && (employeeCode == null || vw.EmployeeCode == employeeCode)
                              && ea.Att_Date >= dateFrom && ea.Att_Date <= dateTo && ea.Att_InTime > ea.Att_ShiftIn
                              select new LateHistoryRM
                              {
                                  EmployeeID = vw.EmployeeID,
                                  AttendanceDate = ea.Att_Date,
                                  ShiftInTime = ea.Att_ShiftIn,
                                  AttendanceInTime = ea.Att_InTime.Value,
                                  AttendanceDateMsg = ea.Att_Date.ToString("dd-MMM-yyyy"),
                                  ShiftInTimeMsg = ea.Att_ShiftIn.ToString("hh:mm tt"),
                                  AttendanceInTimeMsg = ea.Att_InTime.Value.ToString("hh:mm tt"),
                                  LateTime = $"{(ea.Att_InTime.Value.Subtract(ea.Att_ShiftIn)).Hours}:{(ea.Att_InTime.Value.Subtract(ea.Att_ShiftIn)).Minutes}"
                              }).ToListAsync(cancellationToken);
            return data;
        }

        public async Task<EmployeeShiftShortInfoRM> GetEmployeeShiftShortInfo(int employeeID, DateTime shiftDate, CancellationToken cancellationToken)
        {
            var data = await (from es in dbCon.Tbl_EmpShift
                              join s in dbCon.tbl_Shift on es.Shift_Shift equals s.Shift_ID
                              where es.Shift_Emp == employeeID && es.Shift_Date.Date == shiftDate.Date
                              select new EmployeeShiftShortInfoRM
                              {
                                  EmployeeID = (int)es.Shift_Emp.Value,
                                  EmployeeCode=es.Shift_EmpCD,
                                  ShiftDate=es.Shift_Date,
                                  ShiftID=s.Shift_ID,
                                  ShiftName=s.Shift_Name.Trim(),
                                  ShiftIn=es.Shift_In.Value,
                                  ShiftOut=es.Shift_Out.Value

                              }).FirstOrDefaultAsync(cancellationToken);
            return data;
        }

        public async Task<List<LateEmployeesRM>> GetLateEmployees(int CompanyID, int OfficeDivisionID, int DepartmentID, int SectionID, int Year, int Month)
        {
            List<LateEmployeesRM> lateEmployees = new();
            try
            {
                await dbCon.LoadStoredProc("ajt.usp_GetLateEmployees")
                    .WithSqlParam(nameof(CompanyID), CompanyID)
                    .WithSqlParam(nameof(OfficeDivisionID), OfficeDivisionID)
                    .WithSqlParam(nameof(DepartmentID), DepartmentID)
                    .WithSqlParam(nameof(SectionID), SectionID)
                    .WithSqlParam(nameof(Year), Year)
                    .WithSqlParam(nameof(Month), Month)
                                  .ExecuteStoredProcAsync((handler) =>
                                  {
                                      lateEmployees = handler.ReadToList<LateEmployeesRM>() as List<LateEmployeesRM>;
                                  });

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lateEmployees;
        }

        public async Task<List<LeftyEmployeeRM>> GetLeftyEmployeeList(DateTime dateTo, int noOfAbsentDays, string companyID, string divisionID, string departmentID, bool isStaff = false)
        {
            var data = new List<LeftyEmployeeRM>();

            string _hrCompanyID = "";
            companyID = string.IsNullOrEmpty(companyID) == true ? "183,20183" : companyID;

            int[] companyParm = companyID.Split(',').Select(int.Parse).ToArray();
            var dbCompany = await dbCon.Tbl_Company
                               .Where(b => companyParm.Contains(b.EmbroCompanyID))
                               .Select(s => new
                               {
                                   Cmp_ID = s.Cmp_ID.ToString()
                               }).ToArrayAsync();
            _hrCompanyID = string.Join(",", dbCompany.Select(s => s.Cmp_ID).ToArray());


            try
            {
                if (isStaff)
                {
                    await dbCon.LoadStoredProc("rpt.getLeftyEmployeeListStaff", commandTimeout: 1000)
                                .WithSqlParam("DateTo", dateTo)
                                .WithSqlParam("NoOfAbsentDays", noOfAbsentDays)
                                .WithSqlParam("CompanyID", _hrCompanyID)
                                .WithSqlParam("DivisionID", divisionID)
                                .WithSqlParam("DepartmentID", departmentID)
                                .ExecuteStoredProcAsync((handler) =>
                                {
                                    data = handler.ReadToList<LeftyEmployeeRM>().ToList();
                                });
                }
                else
                {
                    await dbCon.LoadStoredProc("rpt.getLeftyEmployeeListWorker",commandTimeout:1000)
                                .WithSqlParam("DateTo", dateTo)
                                .WithSqlParam("NoOfAbsentDays", noOfAbsentDays)
                                .WithSqlParam("CompanyID", _hrCompanyID)
                                .WithSqlParam("DivisionID", divisionID)
                                .WithSqlParam("DepartmentID", departmentID)
                                .ExecuteStoredProcAsync((handler) =>
                                {
                                    data = handler.ReadToList<LeftyEmployeeRM>().ToList();
                                });
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return data;

        }

        public IQueryable<MyAttendanceInfoRM> GetMyAttendanceInfoData(long EmployeeID, string AttendanceStatus, DateTime DateFrom, DateTime DateTo)
        {
            try
            {
                var attendanceStatus = new List<short>();
                if (!string.IsNullOrEmpty(AttendanceStatus))
                {
                    attendanceStatus = ListToString.StringToIntList<short>(AttendanceStatus ?? "", ",");
                }
                    

                var attendance = from att in dbCon.Vw_EmpAttendance
                                 where att.Att_Emp == EmployeeID
                                   && att.Att_Date >= DateFrom && att.Att_Date <= DateTo
                                 select att;
                if (attendanceStatus.Count > 0)
                {
                    attendance = attendance.Where(att => attendanceStatus.Contains(att.Att_Status ?? 6));
                }
                           

            //var data = attendance.ToQueryString();
            //_logger.LogInformation(attendance.ToQueryString());
             var query = from empInfo in dbCon.vw_ERP_EmpShortInfo
                        join Att in attendance on  empInfo.EmployeeID equals Att.Att_Emp  into _empAtt
                        from empAtt in _empAtt.DefaultIfEmpty()
                        where empInfo.EmployeeID == EmployeeID
                        orderby empAtt.Att_Date
                        select new MyAttendanceInfoRM
                        {    
                            Serial = empAtt ==null ?0:empAtt.Serial,
                            EmployeeID = empInfo.EmployeeID,
                            EmployeeCode = empInfo.EmployeeCode,
                            EmployeeName = empInfo.EmployeeName,
                            Designation = empInfo.DesignationName,
                            AttendanceDate = empAtt.Att_Date,
                            AttendanceDateST = empAtt.Att_DateST,
                            ShiftName = empAtt.Shift_Name,
                            ShiftBName = empAtt.Shift_Bname,
                            Status = empAtt.StatusName,
                            DaysName = empAtt.DaysName,
                            ShiftInDate = empAtt.ShiftInTime,
                            ShiftInTime = empAtt.ShiftInTime,
                            ShiftOutTime = empAtt.ShiftOutTime, 
                            AttendanceInTime = empAtt.InTime,
                            AttendanceOutTime = empAtt.OutTime,
                            Late = empAtt!=null?empAtt.LateMinutes:0, 
                        };

                var aa = query.ToQueryString();
            return query;


            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<RResult> UpdateEmpAttendance(Tbl_EmpAttendance EmpAttendance)
        {
            RResult rResult = new();
            dbCon.Tbl_EmpAttendance.Update(EmpAttendance);
            await dbCon.SaveChangesAsync();

            rResult.result = 1;
            rResult.message = ReturnMessage.UpdateMessage;
            return rResult;

        }
    }
}
