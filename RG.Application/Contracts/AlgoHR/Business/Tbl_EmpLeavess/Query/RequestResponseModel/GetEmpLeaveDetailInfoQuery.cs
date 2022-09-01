using AutoMapper;
using MediatR;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Tbl_EmpLeavess.Query.RequestResponseModel
{
    public class GetEmpLeaveDetailInfoQuery : IRequest<List<LeaveHistoryDetailInfoRM>>
    {
        public LeaveHistoryDetailInfoQM QueryModel { get; set; }
    }
    public class GetEmpLeaveDetailInfoQueryHandlerF : IRequestHandler<GetEmpLeaveDetailInfoQuery, List<LeaveHistoryDetailInfoRM>>
    {
        private readonly ITbl_EmpLeavesService _tbl_EmpLeavesService;

        public GetEmpLeaveDetailInfoQueryHandlerF(ITbl_EmpLeavesService tbl_EmpLeavesService)
        {
            _tbl_EmpLeavesService = tbl_EmpLeavesService;
        }
        public async Task<List<LeaveHistoryDetailInfoRM>> Handle(GetEmpLeaveDetailInfoQuery request, CancellationToken cancellationToken)
        {
            var data = await _tbl_EmpLeavesService.GetEmployeeLeaveHistoryDetailInfo(request.QueryModel, cancellationToken);
            return data;
        }
    }
}
