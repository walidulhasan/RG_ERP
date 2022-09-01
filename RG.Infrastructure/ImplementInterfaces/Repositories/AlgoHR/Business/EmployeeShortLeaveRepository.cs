using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.Tbl_EmpLeavess.Query.RequestResponseModel;
using RG.Application.Contracts.AlgoHR.Tbl_EmpLeavess.Query.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.DBEntities.AlgoHR.Business;
using RG.Infrastructure.Persistence.AlgoHRDB;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Business
{
    public class EmployeeShortLeaveRepository : GenericRepository<EmployeeShortLeave>, IEmployeeShortLeaveRepository
    {
        private readonly AlgoHRDBContext _dbCon;

        public EmployeeShortLeaveRepository(AlgoHRDBContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }

        public async Task<RResult> EmployeeShortLeaveSave(EmployeeShortLeave entity, bool saveChanges = true)
        {
            RResult rResult = new();
            await _dbCon.EmployeeShortLeave.AddAsync(entity);
            if (saveChanges)
            {
                await _dbCon.SaveChangesAsync();
                rResult.result = 1;
                rResult.longId = entity.ShortLeaveID;
                rResult.message = ReturnMessage.InsertMessage;
            }

            return rResult;
        }

        public async Task<List<EmpLeavesEnjoyedRM>> EmpShortLeavesEnjoyed(List<EmpLeavesEnjoyedQM> empWithShortLeave, CancellationToken cancellationToken)
        {
            try
            {
                List<EmpLeavesEnjoyedRM> leavesEnjoyed = new();

                foreach (var item in empWithShortLeave)
                {
                    var monthFirstDate = new DateTime(item.LeaveDate.Year, item.LeaveDate.Month, 1);
                    var monthLastDate = monthFirstDate.AddMonths(1).AddDays(-1);

                    var leaveEnjoyed = await _dbCon.EmployeeShortLeave.Where(x => x.EmployeeID == item.EmployeeID && x.IsApproved == true
                     && x.LeaveDate >= monthFirstDate && x.LeaveDate <= monthLastDate).ToListAsync(cancellationToken);

                    var leaveCount = leaveEnjoyed.Count;

                    var data = new EmpLeavesEnjoyedRM()
                    {
                        EmployeeID = item.EmployeeID,
                        LeaveEnjoyed = (int)leaveCount,
                        LeaveDate = item.LeaveDate.ToString("dd-MMM-yyyy")
                    };
                    leavesEnjoyed.Add(data);
                }
                return leavesEnjoyed;


            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<List<EmployeeAvailedLeavesRM>> GetEmployeeAvailedLeaves(int employeeID, string employeeCode, DateTime dateFrom, DateTime dateTo, CancellationToken cancellationToken)
        {
            var dataList = await _dbCon.EmployeeShortLeave.Where(x => x.IsActive == true && x.IsRemoved == false && x.EmployeeID == employeeID && x.IsApproved == true
                                  && x.LeaveDate >= dateFrom && x.LeaveDate <= dateTo).ToListAsync(cancellationToken);
            var retData = new EmployeeAvailedLeavesRM
            {
                EmployeeID = employeeID,
                EmployeeCode = employeeCode,
                LeaveID = 0,
                AvailedLeaveCount = dataList.Count()
            };
            List<EmployeeAvailedLeavesRM> data = new();
            data.Add(retData);
            return data;
        }

        public async Task<List<LeaveHistoryDetailRM>> GetEmployeeLeaveHistoryDetail(LeaveHistoryDetailQM queryModel, CancellationToken cancellationToken)
        {
            if (queryModel.SearchDate != null && queryModel.SearchYear == null)
                queryModel.SearchYear = queryModel.SearchDate.Value.Year;
            else if (queryModel.SearchDate == null && queryModel.SearchYear == null)
                queryModel.SearchYear = DateTime.Now.Year;
            try
            {

                var dataQuery = from el in _dbCon.EmployeeShortLeave
                                join vw in _dbCon.vw_ERP_EmpShortInfo on el.EmployeeID equals vw.EmployeeID

                                join n in _dbCon.ApprovalNotification on new { ApplicationID = (int)el.ShortLeaveID, IsChecked = false, IsShortLeave = true, IsActive = true, IsRemoved = false } equals new { n.ApplicationID, n.IsChecked, n.IsShortLeave, n.IsActive, n.IsRemoved } into nlj
                                from nj in nlj.DefaultIfEmpty()

                                join cd in _dbCon.ApprovalConfigDetail on nj.ApprovalDetailID equals cd.ConfigDetailID into cdlj
                                from cdj in cdlj.DefaultIfEmpty()

                                join vw1 in _dbCon.vw_ERP_EmpShortInfo on cdj.ApproverEmployeeID equals (int)vw1.EmployeeID into vwlj
                                from vwj in vwlj.DefaultIfEmpty()

                                where el.IsActive == true && el.IsRemoved == false
                                && (queryModel.CompanyID == 0 || vw.EmbroCompanyID == queryModel.CompanyID)
                                && (queryModel.DivisionID == 0 || vw.DivisionID == queryModel.DivisionID)
                                && (queryModel.DepartmentID == 0 || vw.DepartmentID == queryModel.DepartmentID)
                                && (queryModel.SectionID == 0 || vw.SectionID == queryModel.SectionID)
                                && (queryModel.DesignationID == 0 || vw.DesignationID == queryModel.DesignationID)

                                && (queryModel.EmployeeID == 0 || el.EmployeeID == queryModel.EmployeeID)
                                && (queryModel.LeaveStatusIndependent || el.IsApproved == queryModel.LeaveStatus)
                                && (queryModel.SearchDate == null || ((el.LeaveDate <= queryModel.SearchDate) && (queryModel.SearchDate <= el.LeaveDate)))
                                && el.LeaveDate.Year == queryModel.SearchYear

                                select new LeaveHistoryDetailRM
                                {
                                    LeaveID = el.ShortLeaveID,
                                    EmployeeID = (int)el.EmployeeID,
                                    EmployeeCode = el.EmployeeCode,
                                    EmployeeName = vw.EmployeeName,
                                    CompanyName = vw.CompanyName,
                                    DivisionName = vw.DivisionName,
                                    DepartmentName = vw.DepartmentName,
                                    SectionName = vw.SectionName,
                                    DesignationName = vw.DesignationName,
                                    AppointmentDate = vw.Emp_Appointment,
                                    LeaveTypeID = 0,
                                    LeaveType = "Short Leave",
                                    LeaveFrom = el.LeaveDate,
                                    LeaveTimeFrom = el.LeaveTimeFrom,
                                    LeaveTimeTo = el.LeaveTimeTo,
                                    LeaveTo = el.LeaveDate,
                                    LeaveReason = el.LeaveReason,
                                    LeaveApproved = el.IsApproved,
                                    LeaveDays = 0,
                                    PendingAtApprover = vwj.EmployeeName ?? "",
                                    ApprovalLevel = cdj != null ? cdj.ApprovalLevel.Value : 0
                                };
                //var query = dataQuery.ToQueryString();
                var data = await dataQuery.OrderBy(b => b.LeaveFrom).ToListAsync(cancellationToken);

                return data;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<EmpLeavesRM>> GetShortLeaveApplicationsWaitingForApproval(CancellationToken cancellationToken)
        {
            var data = await (from el in _dbCon.EmployeeShortLeave
                              join vw in _dbCon.vw_ERP_EmpShortInfo on el.EmployeeID equals vw.EmployeeID
                              join att in _dbCon.Tbl_EmpAttendance on new { Att_Emp = el.EmployeeID, Att_Date = el.LeaveDate } equals new { att.Att_Emp , Att_Date = att.Att_Date } into attLjoin
                              from at in attLjoin.DefaultIfEmpty()
                              where el.IsApproved == null
                              select new EmpLeavesRM
                              {
                                  ID = el.ShortLeaveID,
                                  Leave_Emp = el.EmployeeID,
                                  Leave_EmpCD = el.EmployeeCode,
                                  Leave_EmpName = vw.EmployeeName,
                                  Leave_Type = "Short Leave",
                                  Leave_From = el.LeaveDate,
                                  //Leave_To = el.Leave_To,
                                  Leave_Created = el.CreatedDate,
                                  Leave_Reason = el.LeaveReason,
                                  //Leave_User = el.Leave_User,
                                  Leave_Approved = el.IsApproved,
                                  Leave_Address = el.LeaveAddress,
                                  CompanyName = vw.CompanyName,
                                  DivisionName = vw.DivisionName,
                                  DepartmentName = vw.DepartmentName,
                                  SectionName = vw.SectionName,
                                  Designation = vw.DesignationName,
                                  LeaveDays = 0,
                                  IsShortLeave = true,
                                  ShortLeaveFromTo = $"{el.LeaveTimeFrom} to {el.LeaveTimeTo}",
                                  ShortLeaveFromTime = el.LeaveDate.Add(DateTime.Parse(el.LeaveTimeFrom).TimeOfDay),
                                  AttendanceDateAndOutTime = at.Att_OutTime,
                                  AttDate =at.Att_Date,
                                  AttendanceInTime = at.Att_InTime.HasValue==true? at.Att_InTime.Value.ToString("HH:mm tt"):"",
                                  AttendanceOutTime = at.Att_OutTime.HasValue == true ? at.Att_OutTime.Value.ToString("HH:mm tt") : "",
                              }).ToListAsync(cancellationToken);

            return data;
        }
        public async Task<RResult> UpdateEmployeeShortLeave(EmployeeShortLeave entity)
        {
            RResult rResult = new RResult();
            _dbCon.EmployeeShortLeave.Update(entity);
            await _dbCon.SaveChangesAsync();
            rResult.result = 1;
            rResult.message = ReturnMessage.UpdateMessage;
            return rResult;
        }
    }
}
