using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Common.Utilities;
using RG.Application.Contracts.AlgoHR.Business.Tbl_Emp.Commands.DataTransferModel;
using RG.Application.Contracts.AlgoHR.Business.Tbl_Emp.Query.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AlgoHR.Business
{
   public interface ITbl_EmpService
    {
        /// <summary>
        /// Dropdown value ? Code OR ID
        /// </summary>
        /// <param name="filterQM"></param>
        /// <param name="DPValue"> Dropdown Value ? Code Or ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<SelectListItem>> GetDDLEmployeeByAdvanceFilter(EmployeeDDLAdvanceFilterQM filterQM, string DPValue = "ID", CancellationToken cancellationToken = default);
        Task<List<EmployeeBreakDownRM>> DDLHREmployeeLookup(List<int> CompanyID, List<int> officeDivisionID, List<int> departmentID, List<int> sectionID, List<int> designationID, string Predict = null, CancellationToken cancalletionToken = default);
        Task<RResult> UpdateEmployeePersonalInfo(EmployeePersonalInfoDTM personalInfo, CancellationToken cancellationToken);
        Task<RResult> GetEmployeeAddressInfo(EmployeeAddressInfoDTM addressInfo, CancellationToken cancellationToken);
        Task<EmployeePersonalInfoRM> GetEmployeePersonalInfo(string EmployeeCode, CancellationToken cancellationToken);
        Task<EmployeeAddressInfoRM> GetEmployeeAddressInfo(string EmployeeCode, CancellationToken cancellationToken);
    }
}
