using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.LateAttendanceWarningLetterMasters.Query.RequestResponseModel;
using RG.DBEntities.AlgoHR.Business;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.AlgoHR.Business
{
    public interface ILateAttendanceWarningLetterMasterRepository : IGenericRepository<LateAttendanceWarningLetterMaster>
    {
        Task<RResult> SaveLateAttendanceWarningLetter(LateAttendanceWarningLetterMaster entity);
        Task<List<LateWarningLetterRM>> GetEmployeeWiseLateWarningLetter(int employeeID, int year, int month, CancellationToken cancellationToken);
    }
}
