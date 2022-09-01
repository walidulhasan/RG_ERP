using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.DBEntities.AlgoHR.Business;
using RG.Infrastructure.Persistence.AlgoHRDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Business
{
    public class SchedulerTaskRepository : ISchedulerTaskRepository
    {
        private readonly AlgoHRDBContext _dbCon;

        public SchedulerTaskRepository(AlgoHRDBContext context)           
        {
            _dbCon = context;           
        }
        public async Task<RResult> ModifyAttendanceByShortLeaveAndOutsideDuty(CancellationToken cancellationToken)
        {
            RResult rResult = new();
            try
            {
                List<Tbl_EmpAttendance> attendanceData = new();

                var lastSalaryDate = (await _dbCon.Tbl_Payroll_Master.OrderBy(x=>x.Payroll_ID).LastAsync(cancellationToken)).Payroll_To.Date;

                var attOfEmpWithShotLeave = await (from att in _dbCon.Tbl_EmpAttendance
                                                   join sl in _dbCon.EmployeeShortLeave on 
                                                    new { att.Att_Date.Date, EmployeeCode=att.Att_EmpCd } equals new { sl.LeaveDate.Date,sl.EmployeeCode }
                                                   where att.Att_Status == 7 && sl.LeaveDate.Date >lastSalaryDate && sl.LeaveDate.Date<DateTime.Now.Date
                                                   && sl.IsActive == true && sl.IsRemoved == false && sl.IsApproved == true
                                                   select att).ToListAsync(cancellationToken);
                attOfEmpWithShotLeave.ForEach(c => { c.Att_Remarks = "Short Leave"; });
                attendanceData.AddRange(attOfEmpWithShotLeave);
                
                var attOfEmpWithOutsideDuty = await (from att in _dbCon.Tbl_EmpAttendance
                                                     join ot in _dbCon.Tbl_EmpOutSideTask on
                                                        new { att.Att_Date.Date, EmployeeCode=att.Att_EmpCd } equals new { ot.OutsideTaskDate.Date,ot.EmployeeCode }
                                                     where (att.Att_Status == 7 || att.Att_Status == 2) 
                                                     && ot.OutsideTaskDate.Date > lastSalaryDate && ot.OutsideTaskDate.Date < DateTime.Now.Date
                                                     && ot.IsActive == true && ot.IsRemoved == false && ot.IsApproved == 1
                                                     select att).ToListAsync(cancellationToken);
                attOfEmpWithOutsideDuty.ForEach(c => { c.Att_Remarks = "Outside Duty"; });
                attendanceData.AddRange(attOfEmpWithOutsideDuty);

                
                foreach (var attItem in attendanceData)
                {
                    var entity = await _dbCon.Tbl_EmpAttendance.Where(x => x.Att_EmpCd == attItem.Att_EmpCd && x.Att_Date == attItem.Att_Date).FirstAsync(cancellationToken);
                    entity.Att_Status = 3;
                    entity.Att_Remarks = attItem.Att_Remarks;
                    entity.Att_Adjusted = true;
                    await _dbCon.SaveChangesAsync(cancellationToken);
                }
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
