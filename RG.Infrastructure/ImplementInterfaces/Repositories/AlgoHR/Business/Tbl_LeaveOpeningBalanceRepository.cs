using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.AlgoHR;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.DBEntities.AlgoHR;
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
    public class Tbl_LeaveOpeningBalanceRepository : GenericRepository<Tbl_LeaveOpeningBalance>, ITbl_LeaveOpeningBalanceRepository
    {
        private readonly AlgoHRDBContext _dbCon;
        public Tbl_LeaveOpeningBalanceRepository(AlgoHRDBContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }
        public async Task<List<Tbl_LeaveOpeningBalance>> GetYearWiseEmployeeLeaveOpeningBalance(string employeeCode, int year, CancellationToken cancellationToken)
        {
            var data = await _dbCon.Tbl_LeaveOpeningBalance.Where(x => x.EmpCD == employeeCode && x.Year == year).ToListAsync();
            return data;
        }
    }
}
