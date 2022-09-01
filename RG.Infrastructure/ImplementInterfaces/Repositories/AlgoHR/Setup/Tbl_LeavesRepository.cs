using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.AlgoHR.Setup;
using RG.DBEntities.AlgoHR.Setup;
using RG.Infrastructure.Persistence.AlgoHRDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Setup
{
    public class Tbl_LeavesRepository : GenericRepository<Tbl_Leaves>, ITbl_LeavesRepository
    {
        private readonly AlgoHRDBContext dbCon;
        public Tbl_LeavesRepository(AlgoHRDBContext context)
            : base(context)
        {
            dbCon = context;
        }

        public async Task<List<SelectListItem>> DDLLeaves(CancellationToken cancellationToken)
        {
            var data = await dbCon.Tbl_Leaves
                .Select(x => new SelectListItem
                {
                    Text = x.Leaves_Desc.Trim(),
                    Value = x.Leaves_ID.ToString()
                }).ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<SelectListItem>> GetDDLComplimentaryLeave(long employeeID, CancellationToken cancellationToken)
        {

            var dataQuery = dbCon.Tbl_Holiday
                .FromSqlInterpolated($@"SELECT h.* FROM Tbl_Holiday h 
                                    INNER JOIN Tbl_EmpAttendance att on h.Holiday_Date = att.Att_Date and att.Att_Emp = {employeeID} AND att.Att_InTime is not null
                                    LEFT JOIN Tbl_EmpLeaves lv on h.Holiday_Date = lv.Complimentary_LeaveDate AND att.Att_EmpCd = lv.Leave_EmpCD AND ISNULL(lv.Leave_Approved,1) != 0
                                    where YEAR(H.Holiday_Date) = YEAR(GETDATE())
                                       AND lv.ID is NULL");
            var aa = dataQuery.ToQueryString();
            var holidayDates = await dataQuery
                .Select(s => new SelectListItem()
                {
                    Text = s.Holiday_Date.ToString("dd-MMM-yyyy") + " (" + s.Holiday_Desc + ")",
                    Value = s.Holiday_Date.ToString("dd-MMM-yyyy")
                }).ToListAsync(cancellationToken);

            return holidayDates;
        }
    }
}
