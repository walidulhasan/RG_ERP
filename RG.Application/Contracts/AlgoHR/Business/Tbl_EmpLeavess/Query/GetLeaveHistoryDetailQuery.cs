using MediatR;
using RG.Application.Contracts.AlgoHR.Tbl_EmpLeavess.Query.RequestResponseModel;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Tbl_EmpLeavess.Query
{
    public class GetLeaveHistoryDetailQuery : IRequest<List<LeaveHistoryDetailRM>>
    {
        public LeaveHistoryDetailQM QueryModel { get; set; }
    }
    public class GetLeaveHistoryDetailQueryHandler : IRequestHandler<GetLeaveHistoryDetailQuery, List<LeaveHistoryDetailRM>>
    {
        private readonly ITbl_EmpLeavesService tbl_EmpLeavesService;
        private readonly IEmployeeShortLeaveService _employeeShortLeaveService;

        public GetLeaveHistoryDetailQueryHandler(ITbl_EmpLeavesService _tbl_EmpLeavesService, IEmployeeShortLeaveService employeeShortLeaveService)
        {
            tbl_EmpLeavesService = _tbl_EmpLeavesService;
            _employeeShortLeaveService = employeeShortLeaveService;
        }
        public async Task<List<LeaveHistoryDetailRM>> Handle(GetLeaveHistoryDetailQuery request, CancellationToken cancellationToken)
        {
            var data= await tbl_EmpLeavesService.GetEmployeeLeaveHistoryDetail(request.QueryModel, cancellationToken);
            var shortLeaveData = await _employeeShortLeaveService.GetEmployeeLeaveHistoryDetail(request.QueryModel, cancellationToken);

            data.AddRange(shortLeaveData);
            return data;

        }
    }
}
