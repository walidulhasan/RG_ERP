using MediatR;
using RG.Application.Contracts.AlgoHR.Business.Tbl_Emp.Query.RequestResponseModel;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Tbl_Emp.Query
{
    public class GetEmpShortInfoByCodeQuery : IRequest<vw_ERP_EmpShortInfoRM>
    {
        public long? EmployeeID { get; set; }
        public string EmployeeCode { get; set; }



    }
    public class GetEmpShortInfoByCodeQueryHandler : IRequestHandler<GetEmpShortInfoByCodeQuery, vw_ERP_EmpShortInfoRM>
    {
        private readonly Ivw_ERP_EmpShortInfoService vw_ERP_EmpShortInfoService;


        public GetEmpShortInfoByCodeQueryHandler(Ivw_ERP_EmpShortInfoService _vw_ERP_EmpShortInfoService)
        {
            vw_ERP_EmpShortInfoService = _vw_ERP_EmpShortInfoService;
        }
        public async Task<vw_ERP_EmpShortInfoRM> Handle(GetEmpShortInfoByCodeQuery request, CancellationToken cancellationToken)
        {
            return await vw_ERP_EmpShortInfoService.Get_ERP_EmpShortInfo(request.EmployeeCode, request.EmployeeID, cancellationToken);
        }
    }
}
