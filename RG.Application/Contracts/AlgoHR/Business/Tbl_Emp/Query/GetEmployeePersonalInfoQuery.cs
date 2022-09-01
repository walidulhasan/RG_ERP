using MediatR;
using RG.Application.Contracts.AlgoHR.Business.Tbl_Emp.Query.RequestResponseModel;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Tbl_Emp.Query
{
    public class GetEmployeePersonalInfoQuery : IRequest<EmployeePersonalInfoRM>
    {
        public string EmployeeCode { get; set; }
    }
    public class GetEmployeePersonalInfoQueryHandler : IRequestHandler<GetEmployeePersonalInfoQuery, EmployeePersonalInfoRM>
    {
        private readonly ITbl_EmpService _tbl_EmpService;

        public GetEmployeePersonalInfoQueryHandler(ITbl_EmpService tbl_EmpService)
        {
            _tbl_EmpService = tbl_EmpService;
        }
        public async Task<EmployeePersonalInfoRM> Handle(GetEmployeePersonalInfoQuery request, CancellationToken cancellationToken)
        {
            return await _tbl_EmpService.GetEmployeePersonalInfo(request.EmployeeCode, cancellationToken);
        }
    }
}
