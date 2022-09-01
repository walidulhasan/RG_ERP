using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Contracts.AlgoHR.Business.Tbl_Emp.Query.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using RG.DBEntities.AlgoHR.DBViews;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AlgoHR.Business
{
    public class vw_ERP_EmpShortInfoService : Ivw_ERP_EmpShortInfoService
    {
        private readonly Ivw_ERP_EmpShortInfoRepository vw_ERP_EmpShortInfoRepository;
        private readonly IMapper mapper;

        public vw_ERP_EmpShortInfoService(Ivw_ERP_EmpShortInfoRepository vw_ERP_EmpShortInfoRepository, IMapper _mapper)
        {
            this.vw_ERP_EmpShortInfoRepository = vw_ERP_EmpShortInfoRepository;
            mapper = _mapper;
        }
        public async Task<List<SelectListItem>> DDLEmployeeList(int companyID, int officeDivisionID, int departmentID, int sectionID, int designationID, string predict = null, CancellationToken cancellationToken = default)
        {
            return await vw_ERP_EmpShortInfoRepository.DDLEmployeeList(companyID, officeDivisionID, departmentID, sectionID, designationID, predict, cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLEmployeeList(string predict = null, CancellationToken cancellationToken = default)
        {
            return await vw_ERP_EmpShortInfoRepository.DDLEmployeeList(predict, cancellationToken);
        }

        public async Task<vw_ERP_EmpShortInfoRM> Get_ERP_EmpShortInfo(string empCode = null, long? employeeID = 0, CancellationToken cancellationToken = default)
        {
            var data = await vw_ERP_EmpShortInfoRepository.Get_ERP_EmpShortInfo(empCode, employeeID, cancellationToken);
            var rm = mapper.Map<vw_ERP_EmpShortInfo, vw_ERP_EmpShortInfoRM>(data);
            return rm;
        }
    }
}
