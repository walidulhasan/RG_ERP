using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.LateAttendanceWarningLetterMasters.Query.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.DBEntities.AlgoHR.Business;
using RG.Infrastructure.Persistence.AlgoHRDB;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Business
{
    public class LateAttendanceWarningLetterMasterRepository : GenericRepository<LateAttendanceWarningLetterMaster>, ILateAttendanceWarningLetterMasterRepository
    {
        private readonly AlgoHRDBContext dbCon;
        public LateAttendanceWarningLetterMasterRepository(AlgoHRDBContext context)
            : base(context)
        {
            dbCon = context;
        }
        public async Task<List<LateWarningLetterRM>> GetEmployeeWiseLateWarningLetter(int employeeID, int year, int month, CancellationToken cancellationToken)
        {
            var data = await dbCon.LateAttendanceWarningLetterMaster.Where(x => x.EmployeeID == employeeID && x.LetterForYear == year && x.LetterForMonth == month)
                .Select(r => new LateWarningLetterRM()
                {
                    LetterMasterID = r.LetterMasterID
                }).ToListAsync();
            return data;
        }

        public async Task<RResult> SaveLateAttendanceWarningLetter(LateAttendanceWarningLetterMaster entity)
        {
            RResult rResult = new RResult();
            await dbCon.LateAttendanceWarningLetterMaster.AddAsync(entity);
            await dbCon.SaveChangesAsync();
            rResult.result = 1;
            rResult.message = ReturnMessage.InsertMessage;
            rResult.statusCode = entity.LetterMasterID;
            return rResult;
        }
    }
}
