using AutoMapper;
using RG.Application.Contracts.AlgoHR.Business.Tbl_LeaveOpeningBalances.Query.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using RG.DBEntities.AlgoHR.Business;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AlgoHR.Business
{
    public class Tbl_LeaveOpeningBalanceService : ITbl_LeaveOpeningBalanceService
    {
        private readonly ITbl_LeaveOpeningBalanceRepository tbl_LeaveOpeningBalanceRepository;
        private readonly IMapper mapper;

        public Tbl_LeaveOpeningBalanceService(ITbl_LeaveOpeningBalanceRepository _tbl_LeaveOpeningBalanceRepository, IMapper _mapper)
        {
            tbl_LeaveOpeningBalanceRepository = _tbl_LeaveOpeningBalanceRepository;
            mapper = _mapper;
        }

        public async Task<List<LeaveOpeningBalanceRM>> GetYearWiseEmployeeLeaveOpeningBalance(string employeeCode, int year, CancellationToken cancellationToken)
        {
            var data = await tbl_LeaveOpeningBalanceRepository.GetYearWiseEmployeeLeaveOpeningBalance(employeeCode, year, cancellationToken);
            var retData = mapper.Map<List<Tbl_LeaveOpeningBalance>, List<LeaveOpeningBalanceRM>>(data);
            return retData;

        }
    }
}
