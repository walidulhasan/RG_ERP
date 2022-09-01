using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Contracts.AlgoHR.Business.SalaryAnalysisDivisions.Query.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AlgoHR.Business
{
    public interface ISalaryAnalysisDivisionService
    {
        Task<List<SelectListItem>> DDLSalaryAnalysisDivision(CancellationToken cancellationToken);
        Task<List<AnalysisDivisionWiseSalaryRM>> GetAnalysisDivisionWiseSalary(string analysisDivision, string departmentGroup, int year, int month, CancellationToken cancellationToken);
        Task<List<AnalysisDivisionWiseAllowanceRM>> GetAnalysisDivisionWiseAllowance(string analysisDivision, string departmentGroup, int year, int month, CancellationToken cancellationToken);
    }
}
