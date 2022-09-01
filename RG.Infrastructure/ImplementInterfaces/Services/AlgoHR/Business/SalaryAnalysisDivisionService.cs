using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Contracts.AlgoHR.Business.SalaryAnalysisDivisions.Query.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Business;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AlgoHR.Business
{
    public class SalaryAnalysisDivisionService : ISalaryAnalysisDivisionService
    {
        private readonly ISalaryAnalysisDivisionRepository _salaryAnalysisDivisionRepository;
        private readonly ICMBL_PurchaseOrderRepository _cMBL_PurchaseOrderRepository;

        public SalaryAnalysisDivisionService(ISalaryAnalysisDivisionRepository salaryAnalysisDivisionRepository
            , ICMBL_PurchaseOrderRepository CMBL_PurchaseOrderRepository)
        {
            _salaryAnalysisDivisionRepository = salaryAnalysisDivisionRepository;
            _cMBL_PurchaseOrderRepository = CMBL_PurchaseOrderRepository;
        }
        public async Task<List<SelectListItem>> DDLSalaryAnalysisDivision(CancellationToken cancellationToken)
        {
            return await _salaryAnalysisDivisionRepository.DDLSalaryAnalysisDivision(cancellationToken);
        }

        public async Task<List<AnalysisDivisionWiseAllowanceRM>> GetAnalysisDivisionWiseAllowance(string analysisDivision, string departmentGroup, int year, int month, CancellationToken cancellationToken)
        {
            return await _salaryAnalysisDivisionRepository.GetAnalysisDivisionWiseAllowance(analysisDivision,departmentGroup, year, month, cancellationToken);
        }

        public async Task<List<AnalysisDivisionWiseSalaryRM>> GetAnalysisDivisionWiseSalary(string analysisDivision, string departmentGroup, int year, int month, CancellationToken cancellationToken)
        {            
            List<AnalysisDivisionWiseSalaryRM> data = new();
            if (analysisDivision=="8")//Other Materials Cost 
            {
                data = await _cMBL_PurchaseOrderRepository.GetAnalysisDivisionWiseCost(analysisDivision, departmentGroup, year, month, cancellationToken);
            }
            else
            {
                data=await _salaryAnalysisDivisionRepository.GetAnalysisDivisionWiseSalary(analysisDivision,departmentGroup, year, month, cancellationToken);
            }
            return data;
        }
    }
}
