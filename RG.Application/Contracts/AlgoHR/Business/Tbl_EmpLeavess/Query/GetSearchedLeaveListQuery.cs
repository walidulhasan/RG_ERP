using MediatR;
using RG.Application.Common.DevExtremeModelBinds;
using RG.Application.Contracts.AlgoHR.Business.Tbl_EmpLeavess.Query.RequestResponseModel;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Tbl_EmpLeavess.Query
{
    public class GetSearchedLeaveListQuery:IRequest<List<SearchedLeaveListRM>>
    {
        public int LeaveID { get; set; }
        public string leaveStatus { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int CompanyID { get; set; }
        public int DivisionID { get; set; }
        public int DepartmentID { get; set; }
    }
    public class GetSearchedLeaveListQueryHandler : IRequestHandler<GetSearchedLeaveListQuery, List<SearchedLeaveListRM>>
    {
        private readonly ITbl_EmpLeavesService _tbl_EmpLeavesService;

        public GetSearchedLeaveListQueryHandler(ITbl_EmpLeavesService tbl_EmpLeavesService)
        {
            _tbl_EmpLeavesService = tbl_EmpLeavesService;
        }
        public async Task<List<SearchedLeaveListRM>> Handle(GetSearchedLeaveListQuery request, CancellationToken cancellationToken)
        {
            return await _tbl_EmpLeavesService.SearchedLeaveList(request.LeaveID,request.leaveStatus,request.DateFrom,request.DateTo,request.CompanyID,request.DivisionID,request.DepartmentID,cancellationToken);
        }
    }
}
