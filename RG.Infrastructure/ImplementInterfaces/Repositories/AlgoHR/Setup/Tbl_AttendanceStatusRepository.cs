using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.AlgoHR.Setup;
using RG.DBEntities.AlgoHR.Setup;
using RG.Infrastructure.Persistence.AlgoHRDB;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Setup
{
    public class Tbl_AttendanceStatusRepository : GenericRepository<Tbl_AttendanceStatus>, ITbl_AttendanceStatusRepository
    {
        private readonly AlgoHRDBContext dbCon;
        public Tbl_AttendanceStatusRepository(AlgoHRDBContext context)
            : base(context)
        {
            dbCon = context;
        }
        public async Task<List<SelectListItem>> DDLAttendanceStatus(CancellationToken cancellationToken = default)
        {
            var query = dbCon.Tbl_AttendanceStatus.Select(s => new SelectListItem()
            {
                Text = s.StatusName,
                Value = s.StatusID.ToString()
            });
            return await query.ToListAsync(cancellationToken);
        }
    }
}
