using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.Tbl_EmpLeavess.Query.RequestResponseModel;
using RG.Application.Contracts.AlgoHR.Tbl_EmpLeavess.Query.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.DBEntities.AlgoHR.Business;
using RG.DBEntities.AlgoHR.DBViews;
using RG.Infrastructure.Persistence.AlgoHRDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Business
{
    public class Tbl_EmpLeavesRepository : GenericRepository<Tbl_EmpLeaves>, ITbl_EmpLeavesRepository
    {
        private readonly AlgoHRDBContext dbCon;
        public Tbl_EmpLeavesRepository(AlgoHRDBContext context)
            : base(context)
        {
            dbCon = context;
        }



        public async Task<RResult> DeleteTbl_EmpLeaves(int leaveID, bool saveChange = true)
        {
            RResult rResult = new();

            await DeleteAsync(leaveID, saveChange);
            rResult.result = 1;
            rResult.message = ReturnMessage.DeleteMessage;
            return rResult;
        }

        public async Task<List<EmpLeavesEnjoyedRM>> EmpLeavesEnjoyed(List<EmpLeavesEnjoyedQM> queryModel, CancellationToken cancellationToken)
        {
            try
            {
                List<EmpLeavesEnjoyedRM> leavesEnjoyed = new();
                var yearFirstDate = new DateTime(DateTime.Now.Year, 1, 1);
                var yearLastDate = yearFirstDate.AddYears(1).AddDays(-1);
                foreach (var item in queryModel)
                {
                    var leaveEnjoyed = await dbCon.Tbl_EmpLeaves.Where(x => x.Leave_Emp == item.EmployeeID && x.Leave_ID == item.LeaveTypeID && x.Leave_Approved == true
                     && x.Leave_From >= yearFirstDate && x.Leave_To <= yearLastDate).ToListAsync(cancellationToken);

                    var leaveCount = leaveEnjoyed.Sum(x => (x.Leave_To.Value - x.Leave_From.Value).TotalDays + 1);

                    var data = new EmpLeavesEnjoyedRM()
                    {
                        EmployeeID = item.EmployeeID,
                        LeaveTypeID = item.LeaveTypeID,
                        LeaveEnjoyed = (int)leaveCount
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

        public async Task<Vw_EmpLeaves> GetEmpLeaveInfo(int leaveApplicationID, CancellationToken cancellationToken)
        {
            try
            {
                var data = await dbCon.Vw_EmpLeaves.Where(x => x.LeaveApplicationID == leaveApplicationID).FirstOrDefaultAsync(cancellationToken);
                return data;
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task<List<EmployeeAvailedLeavesRM>> GetEmployeeAvailedLeaves(int employeeID, string employeeCode, DateTime dateFrom, DateTime dateTo, CancellationToken cancellationToken)
        {
            try
            {
                var data = await (from empLeave in dbCon.Tbl_EmpLeaves
                                  join emp in dbCon.vw_ERP_EmpShortInfo on empLeave.Leave_EmpCD equals emp.EmployeeCode
                                  join l in dbCon.Tbl_Leaves on empLeave.Leave_ID equals l.Leaves_ID
                                  where (employeeID == 0 || emp.EmployeeID == employeeID) && (employeeCode == null || emp.EmployeeCode == employeeCode)
                                  //&& l.Leaves_Lapse == true
                                  && empLeave.Leave_Approved == true && empLeave.Leave_From >= dateFrom && empLeave.Leave_To <= dateTo
                                  select new EmployeeAvailedLeavesRM
                                  {
                                      EmployeeID = emp.EmployeeID,
                                      EmployeeCode = empLeave.Leave_EmpCD,
                                      LeaveID = empLeave.Leave_ID.Value,
                                      AvailedLeaveCount = (int)(empLeave.Leave_To.Value - empLeave.Leave_From.Value).TotalDays + 1
                                  }).ToListAsync(cancellationToken);
                //EL
                //data.AddRange(await (from empLeave in dbCon.Tbl_EmpLeaves
                //                     join emp in dbCon.vw_ERP_EmpShortInfo on empLeave.Leave_EmpCD equals emp.EmployeeCode
                //                     join l in dbCon.Tbl_Leaves on empLeave.Leave_ID equals l.Leaves_ID
                //                     where (employeeID == 0 || emp.EmployeeID == employeeID) && (employeeCode == null || emp.EmployeeCode == employeeCode)
                //                     && empLeave.Leave_Approved == true  && l.Leaves_Lapse == false
                //                     && empLeave.Leave_From >= dateFrom && empLeave.Leave_To <= dateTo
                //                     select new EmployeeAvailedLeavesRM
                //                     {
                //                         EmployeeID = emp.EmployeeID,
                //                         EmployeeCode = empLeave.Leave_EmpCD,
                //                         LeaveID = empLeave.Leave_ID.Value,
                //                         AvailedLeaveCount = (int)(empLeave.Leave_To.Value - empLeave.Leave_From.Value).TotalDays+1
                //                     }).ToListAsync(cancellationToken));
                var retData = data.GroupBy(x => new { x.EmployeeID, x.EmployeeCode, x.LeaveID }).Select(r => new EmployeeAvailedLeavesRM
                {
                    EmployeeID = r.Key.EmployeeID,
                    EmployeeCode = r.Key.EmployeeCode,
                    LeaveID = r.Key.LeaveID,
                    AvailedLeaveCount = r.Sum(y => y.AvailedLeaveCount)
                }).ToList();

                return retData;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<LeaveHistoryDetailRM>> GetEmployeeLeaveHistoryDetail(LeaveHistoryDetailQM queryModel, CancellationToken cancellationToken)
        {
            if (queryModel.SearchDate != null && queryModel.SearchYear == null)
                queryModel.SearchYear = queryModel.SearchDate.Value.Year;
            else if (queryModel.SearchDate == null && queryModel.SearchYear == null)
                queryModel.SearchYear = DateTime.Now.Year;
            try
            {

                var dataQuery = from el in dbCon.Tbl_EmpLeaves
                                join l in dbCon.Tbl_Leaves on el.Leave_ID equals l.Leaves_ID
                                join vw in dbCon.vw_ERP_EmpShortInfo on el.Leave_Emp equals vw.EmployeeID

                                join n in dbCon.ApprovalNotification on new { ApplicationID = (int)el.ID, IsChecked = false, IsShortLeave = false, IsActive = true, IsRemoved = false } equals new { n.ApplicationID, n.IsChecked, n.IsShortLeave, n.IsActive, n.IsRemoved } into nlj
                                from nj in nlj.DefaultIfEmpty()

                                join cd in dbCon.ApprovalConfigDetail on nj.ApprovalDetailID equals cd.ConfigDetailID into cdlj
                                from cdj in cdlj.DefaultIfEmpty()

                                join vw1 in dbCon.vw_ERP_EmpShortInfo on cdj.ApproverEmployeeID equals (int)vw1.EmployeeID into vwlj
                                from vwj in vwlj.DefaultIfEmpty()

                                where (queryModel.CompanyID == 0 || vw.EmbroCompanyID == queryModel.CompanyID)

                                && (queryModel.DivisionID == 0 || vw.DivisionID == queryModel.DivisionID)
                                && (queryModel.DepartmentID == 0 || vw.DepartmentID == queryModel.DepartmentID)
                                && (queryModel.SectionID == 0 || vw.SectionID == queryModel.SectionID)
                                && (queryModel.DesignationID == 0 || vw.DesignationID == queryModel.DesignationID)

                                && (queryModel.EmployeeID == 0 || el.Leave_Emp == queryModel.EmployeeID)
                                && (queryModel.LeaveTypeID == 0 || el.Leave_ID == queryModel.LeaveTypeID)
                                && (queryModel.LeaveStatusIndependent || el.Leave_Approved == queryModel.LeaveStatus)
                                && (queryModel.SearchDate == null || ((el.Leave_From <= queryModel.SearchDate) && (queryModel.SearchDate <= el.Leave_To)))
                                && el.Leave_From.Value.Year == queryModel.SearchYear
                                && el.Leave_To.Value.Year == queryModel.SearchYear
                                select new LeaveHistoryDetailRM
                                {
                                    LeaveID = el.ID,
                                    EmployeeID = (int)el.Leave_Emp,
                                    EmployeeCode = el.Leave_EmpCD,
                                    EmployeeName = vw.EmployeeName,
                                    CompanyName = vw.CompanyName,
                                    DivisionName = vw.DivisionName,
                                    DepartmentName = vw.DepartmentName,
                                    SectionName = vw.SectionName,
                                    DesignationName = vw.DesignationName,
                                    AppointmentDate = vw.Emp_Appointment,
                                    LeaveTypeID = el.Leave_ID.Value,
                                    LeaveType = l.Leaves_Desc.Trim(),
                                    LeaveFrom = el.Leave_From,
                                    LeaveTo = el.Leave_To,
                                    LeaveReason = el.Leave_Reason,
                                    LeaveApproved = el.Leave_Approved,
                                    LeaveAddress = el.Leave_Address,
                                    LeaveDays = (int)(el.Leave_To.Value - el.Leave_From.Value).TotalDays + 1,
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

        public async Task<List<LeaveHistoryDetailInfoRM>> GetEmployeeLeaveHistoryDetailInfo(LeaveHistoryDetailInfoQM queryModel, CancellationToken cancellationToken)
        {
            if (queryModel.SearchDate != null && queryModel.SearchYear == null)
                queryModel.SearchYear = queryModel.SearchDate.Value.Year;
            else if (queryModel.SearchDate == null && queryModel.SearchYear == null)
                queryModel.SearchYear = DateTime.Now.Year;
            try
            {
                List<LeaveHistoryDetailInfoRM> returnData = new();
                if (queryModel.LeaveTypeID!=-1)
                {
                var dataQuery = from el in dbCon.Tbl_EmpLeaves
                                join l in dbCon.Tbl_Leaves on el.Leave_ID equals l.Leaves_ID
                                join vw in dbCon.vw_ERP_EmpShortInfo on el.Leave_Emp equals vw.EmployeeID

                                join n in dbCon.ApprovalNotification on new { ApplicationID = (int)el.ID, IsChecked = false, IsShortLeave = false, IsActive = true, IsRemoved = false } equals new { n.ApplicationID, n.IsChecked, n.IsShortLeave, n.IsActive, n.IsRemoved } into nlj
                                from nj in nlj.DefaultIfEmpty()

                                join cd in dbCon.ApprovalConfigDetail on nj.ApprovalDetailID equals cd.ConfigDetailID into cdlj
                                from cdj in cdlj.DefaultIfEmpty()

                                join vw1 in dbCon.vw_ERP_EmpShortInfo on cdj.ApproverEmployeeID equals (int)vw1.EmployeeID into vwlj
                                from vwj in vwlj.DefaultIfEmpty()

                                where (queryModel.CompanyID == 0 || vw.EmbroCompanyID == queryModel.CompanyID)

                                && (queryModel.DivisionID == 0 || vw.DivisionID == queryModel.DivisionID)
                                && (queryModel.DepartmentID == 0 || vw.DepartmentID == queryModel.DepartmentID)
                                && (queryModel.SectionID == 0 || vw.SectionID == queryModel.SectionID)
                                && (queryModel.DesignationID == 0 || vw.DesignationID == queryModel.DesignationID)

                                && (queryModel.EmployeeID == 0 || el.Leave_Emp == queryModel.EmployeeID)
                                && (queryModel.LeaveTypeID == 0 || el.Leave_ID == queryModel.LeaveTypeID)
                                && (queryModel.LeaveStatusIndependent || el.Leave_Approved == queryModel.LeaveStatus)
                                && (queryModel.SearchDate == null || ((el.Leave_From <= queryModel.SearchDate) && (queryModel.SearchDate <= el.Leave_To)))
                                && el.Leave_From.Value.Year == queryModel.SearchYear
                                && el.Leave_To.Value.Year == queryModel.SearchYear
                                select new LeaveHistoryDetailInfoRM
                                {
                                    LeaveID = el.ID,
                                    EmployeeID = (int)el.Leave_Emp,
                                    EmployeeCode = el.Leave_EmpCD,
                                    EmployeeName = vw.EmployeeName,
                                    CompanyName = vw.CompanyName,
                                    DivisionName = vw.DivisionName,
                                    DepartmentName = vw.DepartmentName,
                                    SectionName = vw.SectionName,
                                    DesignationName = vw.DesignationName,
                                    AppointmentDate = vw.Emp_Appointment,
                                    LeaveTypeID = el.Leave_ID.Value,
                                    LeaveType = l.Leaves_Desc.Trim(),
                                    LeaveFrom = el.Leave_From,
                                    IsNotCurrentMonth = el.Leave_From.Value.Month != DateTime.Now.Month,
                                    LeaveTo = el.Leave_To,
                                    LeaveReason = el.Leave_Reason,
                                    LeaveApproved = el.Leave_Approved,
                                    LeaveAddress = el.Leave_Address,
                                    LeaveDays = (int)(el.Leave_To.Value - el.Leave_From.Value).TotalDays + 1,
                                    PendingAtApprover = vwj.EmployeeName ?? "",
                                    ApprovalLevel = cdj != null ? cdj.ApprovalLevel.Value : 0
                                };
                var data = await dataQuery.OrderBy(b => b.LeaveFrom).ToListAsync(cancellationToken);
                returnData.AddRange(data);
                }

                if (queryModel.LeaveTypeID<1)
                {
                    var dataQuery = from el in dbCon.EmployeeShortLeave                                    
                                    join vw in dbCon.vw_ERP_EmpShortInfo on el.EmployeeID equals vw.EmployeeID

                                    join n in dbCon.ApprovalNotification on new { ApplicationID = el.ShortLeaveID, IsChecked = false, IsShortLeave = true, IsActive = true, IsRemoved = false } equals new { n.ApplicationID, n.IsChecked, n.IsShortLeave, n.IsActive, n.IsRemoved } into nlj
                                    from nj in nlj.DefaultIfEmpty()

                                    join cd in dbCon.ApprovalConfigDetail on nj.ApprovalDetailID equals cd.ConfigDetailID into cdlj
                                    from cdj in cdlj.DefaultIfEmpty()

                                    join vw1 in dbCon.vw_ERP_EmpShortInfo on cdj.ApproverEmployeeID equals (int)vw1.EmployeeID into vwlj
                                    from vwj in vwlj.DefaultIfEmpty()

                                    where (queryModel.CompanyID == 0 || vw.EmbroCompanyID == queryModel.CompanyID)

                                    && (queryModel.DivisionID == 0 || vw.DivisionID == queryModel.DivisionID)
                                    && (queryModel.DepartmentID == 0 || vw.DepartmentID == queryModel.DepartmentID)
                                    && (queryModel.SectionID == 0 || vw.SectionID == queryModel.SectionID)
                                    && (queryModel.DesignationID == 0 || vw.DesignationID == queryModel.DesignationID)

                                    && (queryModel.EmployeeID == 0 || el.EmployeeID == queryModel.EmployeeID)                                    
                                    && (queryModel.LeaveStatusIndependent || el.IsApproved == queryModel.LeaveStatus)
                                    && (queryModel.SearchDate == null || ((el.LeaveDate <= queryModel.SearchDate) && (queryModel.SearchDate <= el.LeaveDate)))
                                    && el.LeaveDate.Year == queryModel.SearchYear
                                    && el.LeaveDate.Year == queryModel.SearchYear
                                    select new LeaveHistoryDetailInfoRM
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
                                        LeaveTypeID = -1,//for short leave
                                        LeaveType = "Short Leave",
                                        LeaveFrom = el.LeaveDate,
                                        IsNotCurrentMonth = el.LeaveDate.Month != DateTime.Now.Month,
                                        LeaveTo = el.LeaveDate,
                                        LeaveReason = el.LeaveReason,
                                        LeaveApproved = el.IsApproved,
                                        LeaveAddress = el.LeaveAddress,
                                        LeaveDays = 0,
                                        PendingAtApprover = vwj.EmployeeName ?? "",
                                        ApprovalLevel = cdj != null ? cdj.ApprovalLevel.Value : 0
                                    };
                    var data = await dataQuery.OrderBy(b => b.LeaveFrom).ToListAsync(cancellationToken);
                    returnData.AddRange(data);
                }


                foreach (var item in returnData)
                {
                    var isShortLeave = item.LeaveTypeID == -1 ? true : false;
                    item.NotificationHistory = await GetApplicationNotificationHistory(item.LeaveID, isShortLeave, cancellationToken);
                }

                return returnData;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private async Task<List<NotificationHistoryRM>> GetApplicationNotificationHistory(long leaveID,bool isShortLeave=false, CancellationToken cancellationToken=default)
        {
            var data = await (from an in dbCon.ApprovalNotification
                              join cd in dbCon.ApprovalConfigDetail on an.ApprovalDetailID equals cd.ConfigDetailID
                              join vw in dbCon.vw_ERP_EmpShortInfo on cd.ApproverEmployeeID equals (int)vw.EmployeeID into vwLeft
                              from vw in vwLeft.DefaultIfEmpty()
                              where an.ApplicationID == leaveID && an.IsShortLeave== isShortLeave
                              orderby an.NotificationID
                              select new NotificationHistoryRM
                              {
                                  ApprovalEmployee = vw != null ? $"{vw.EmployeeName}-{vw.EmployeeCode}" : "",
                                  DesignationName = vw != null ? vw.DesignationName : "",
                                  DepartmentName = vw != null ? vw.DepartmentName : "",
                                  CheckedDate = an.CheckedDate != null ? an.CheckedDate.Value.ToString("dd-MMM-yyyy") : "",
                                  ApprovalStatus = an.CheckedStatus != null ? an.CheckedStatus.Value == 0 ? "Rejected" : "Approved" : "Procesing",
                                  Remarks = an.Remarks
                              }).ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<EmpLeavesRM>> GetLeaveApplicationsWaitingForApproval(CancellationToken cancellationToken)
        {
            var dataQuery = (from el in dbCon.Tbl_EmpLeaves
                             join l in dbCon.Tbl_Leaves on el.Leave_ID equals l.Leaves_ID
                             join vw in dbCon.vw_ERP_EmpShortInfo on el.Leave_Emp equals vw.EmployeeID
                             join holiday in dbCon.Tbl_Holiday on el.Complimentary_LeaveDate equals holiday.Holiday_Date into hljoin
                             from hlj in hljoin.DefaultIfEmpty()
                             join att in dbCon.Tbl_EmpAttendance on new { Att_Emp = el.Leave_Emp.Value, Att_Date = hlj.Holiday_Date } equals new { att.Att_Emp, Att_Date = att.Att_Date } into attLjoin
                             from attlj in attLjoin.DefaultIfEmpty()


                             where el.Leave_Approved == null
                             select new EmpLeavesRM
                             {
                                 ID = el.ID,
                                 Leave_Emp = el.Leave_Emp,
                                 Leave_EmpCD = el.Leave_EmpCD,
                                 Leave_EmpName = vw.EmployeeName,
                                 Leave_ID = el.Leave_ID,
                                 Leave_TypeID = l.Leaves_ID,
                                 Leave_Type = l.Leaves_Desc.Trim(),
                                 Leave_From = el.Leave_From,
                                 Leave_To = el.Leave_To,
                                 Leave_Created = el.Leave_Created,
                                 Leave_Reason = el.Leave_Reason,
                                 Leave_User = el.Leave_User,
                                 Leave_Approved = el.Leave_Approved,
                                 Leave_Address = el.Leave_Address,
                                 CompanyName = vw.CompanyName,
                                 DivisionName = vw.DivisionName,
                                 DepartmentName = vw.DepartmentName,
                                 SectionName = vw.SectionName,
                                 Designation = vw.DesignationName,
                                 LeaveDays = (int)(el.Leave_To.Value - el.Leave_From.Value).TotalDays + 1,

                                 Complimentary_LeaveDate = el.Complimentary_LeaveDate,
                                 HolidayType = hlj == null ? "" : hlj.Holiday_Desc,
                                 AttendanceInTime = attlj == null ? "" : attlj.Att_InTime.Value.ToString("HH:mm tt"),
                                 AttendanceOutTime = attlj == null ? "" : attlj.Att_OutTime.Value.ToString("HH:mm tt")
                             });

            //var aa = dataQuery.ToQueryString();
            var data = await dataQuery.ToListAsync(cancellationToken);

            return data;
        }

        public async Task<RResult> SaveTbl_EmpLeaves(Tbl_EmpLeaves entity, bool saveChange = true)
        {
            RResult rResult = new();
            await dbCon.Tbl_EmpLeaves.AddAsync(entity);
            if (saveChange)
            {
                await dbCon.SaveChangesAsync();
                rResult.result = 1;
                rResult.longId = entity.ID;
                rResult.message = ReturnMessage.InsertMessage;
            }

            return rResult;
        }

        public async Task<List<SearchedLeaveListRM>> SearchedLeaveList(int leaveID, string leaveStatus, DateTime dateFrom, DateTime dateTo, int companyID, int divisionID, int departmentID, CancellationToken cancellationToken)
        {
            try
            {
                bool? status = leaveStatus != "-1" ? leaveStatus != null ? leaveStatus == "1" : null : null;
                var data = (from el in dbCon.Tbl_EmpLeaves
                            join lt in dbCon.Tbl_Leaves on el.Leave_ID equals lt.Leaves_ID
                            join ei in dbCon.vw_ERP_EmpShortInfo on el.Leave_Emp equals ei.EmployeeID
                            join an in dbCon.ApprovalNotification on el.ID equals an.ApplicationID
                            where (companyID == 0 || ei.EmbroCompanyID == companyID) && (divisionID == 0 || ei.DivisionID == divisionID) && (departmentID == 0 || ei.DepartmentID == departmentID)
                           && (leaveID == 0 || el.Leave_ID == leaveID) && (leaveStatus == "-1" || el.Leave_Approved == status)
                           && el.Leave_From >= dateFrom
                           && el.Leave_From <= dateTo
                            select new
                            {
                                LeaveApplicationID = el.ID,
                                EmployeeID = el.Leave_Emp,
                                EmployeeCode = el.Leave_EmpCD,
                                EmployeeName = ei.EmployeeName,
                                DivisionName = ei.DivisionName,
                                DepartmentName = ei.DepartmentName,
                                Designation = ei.DesignationName,
                                LeaveID = el.Leave_ID,
                                LeaveFrom = el.Leave_From,
                                LeaveTo = el.Leave_To,
                                LeaveReason = el.Leave_Reason,
                                ApprovalMasterID = an.ApprovalMasterID,
                                Leave_Approved = el.Leave_Approved,
                                LeaveType = lt.Leaves_Desc.Trim()
                            }).Distinct();

                var a = data.ToQueryString();
                var allDataQuery = from d in data
                                   join vw in dbCon.Viw_ApprovalConfiguration on d.ApprovalMasterID equals vw.ConfigMasterID
                                   join an in dbCon.ApprovalNotification on new { ApplicationID = d.LeaveApplicationID, ApprovalMasterID = vw.ConfigMasterID, ApprovalDetailID = vw.ConfigDetailID }
                                                                equals new { ApplicationID = (long)an.ApplicationID, an.ApprovalMasterID, an.ApprovalDetailID } into leftJ
                                   from lj in leftJ.DefaultIfEmpty()
                                   select new SearchedLeaveListRM
                                   {
                                       LeaveApplicationID = d.LeaveApplicationID,
                                       EmployeeID = d.EmployeeID,
                                       EmployeeCode = d.EmployeeCode,
                                       EmployeeName = d.EmployeeName,
                                       DivisionName = d.DivisionName,
                                       DepartmentName = d.DepartmentName,
                                       Designation = d.Designation,
                                       LeaveID = d.LeaveID,
                                       LeaveType = d.LeaveType,
                                       LeaveFrom = d.LeaveFrom.Value.ToString("dd-MMM-yy"),
                                       LeaveTo = d.LeaveTo.Value.ToString("dd-MMM-yy"),
                                       LeaveReason = d.LeaveReason,
                                       LeaveStatus = d.Leave_Approved == null ? "Processing" : d.Leave_Approved.Value ? "Approved" : "Reject",
                                       ApprovalMasterID = d.ApprovalMasterID,
                                       ApprovalLevel = vw.ApprovalLevel,
                                       ApproverEmployeeCode = vw.AppEmpCode,
                                       ApproverEmployeeName = vw.ApplEmpName,
                                       IsChecked = lj != null ? lj.IsChecked : null
                                   };
                var b = allDataQuery.ToQueryString();

                return await allDataQuery.ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<RResult> UpdateTbl_EmpLeaves(Tbl_EmpLeaves entity, bool saveChange = true)
        {
            RResult rResult = new();
            /*
            //dbCon.Tbl_EmpLeaves.Update(entity);
            dbCon.Update<Tbl_EmpLeaves>(entity);
            if (saveChange)
            {
                await dbCon.SaveChangesAsync();
                rResult.result = 1;
                rResult.message = ReturnMessage.UpdateMessage;
            }
            */
            try
            {
                await UpdateAsync(entity, saveChange);
                rResult.result = 1;
                rResult.message = ReturnMessage.UpdateMessage;
            }
            catch (Exception e)
            {
                rResult.result = 0;
                rResult.message = e.Message;
            }
            return rResult;
        }
    }
}
