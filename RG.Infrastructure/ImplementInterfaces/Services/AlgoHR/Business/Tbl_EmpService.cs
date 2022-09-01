using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Common.Utilities;
using RG.Application.Contracts.AlgoHR.Business.Tbl_Emp.Commands.DataTransferModel;
using RG.Application.Contracts.AlgoHR.Business.Tbl_Emp.Query.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AlgoHR.Business
{
    public class Tbl_EmpService : ITbl_EmpService
    {
        private readonly ITbl_EmpRepository _tbl_EmpRepository;

        public Tbl_EmpService(ITbl_EmpRepository tbl_EmpRepository)
        {
            _tbl_EmpRepository = tbl_EmpRepository;
        }

        public Task<List<EmployeeBreakDownRM>> DDLHREmployeeLookup(List<int> CompanyID, List<int> officeDivisionID, List<int> departmentID, List<int> sectionID, List<int> designationID, string Predict = null, CancellationToken cancalletionToken = default)
        {
            return _tbl_EmpRepository.DDLHREmployeeLookup(CompanyID, officeDivisionID, departmentID, sectionID, designationID, Predict, cancalletionToken);
        }

        public async Task<List<SelectListItem>> GetDDLEmployeeByAdvanceFilter(EmployeeDDLAdvanceFilterQM filterQM, string DPValue = "ID", CancellationToken cancellationToken = default)
        {
            return await _tbl_EmpRepository.GetDDLEmployeeByAdvanceFilter(filterQM, DPValue, cancellationToken);
        }

        public async Task<RResult> GetEmployeeAddressInfo(EmployeeAddressInfoDTM addressInfo, CancellationToken cancellationToken)
        {
            RResult rResult = new();
            try
            {
                var entity = await _tbl_EmpRepository.GetByIdAsync(addressInfo.Emp_ID, cancellationToken);
                entity.Emp_Country1 = addressInfo.Emp_Country1;
                entity.Emp_Country2 = addressInfo.Emp_Country2;
                entity.Emp_State1 = addressInfo.Emp_State1;
                entity.Emp_State2 = addressInfo.Emp_State2;
                entity.Emp_City1 = addressInfo.Emp_City1;
                entity.Emp_City2 = addressInfo.Emp_City2;
                entity.Emp_Address1 = addressInfo.Emp_Address1;
                entity.Emp_Address2 = addressInfo.Emp_Address2;
                entity.Emp_Zip1 = addressInfo.Emp_Zip1;
                entity.Emp_Zip2 = addressInfo.Emp_Zip2;
                await _tbl_EmpRepository.UpdateAsync(entity, true);
                rResult.result = 1;
                rResult.message = ReturnMessage.UpdateMessage;
            }
            catch (Exception e)
            {
                rResult.result = 0;
                rResult.message = ReturnMessage.ErrorMessage;

            }
            return rResult;
        }

        public async Task<EmployeeAddressInfoRM> GetEmployeeAddressInfo(string EmployeeCode, CancellationToken cancellationToken)
        {
            return await _tbl_EmpRepository.GetEmployeeAddressInfo(EmployeeCode,cancellationToken);
        }

        public async Task<EmployeePersonalInfoRM> GetEmployeePersonalInfo(string EmployeeCode, CancellationToken cancellationToken)
        {
            return await _tbl_EmpRepository.GetEmployeePersonalInfo(EmployeeCode, cancellationToken);
        }

        public async Task<RResult> UpdateEmployeePersonalInfo(EmployeePersonalInfoDTM personalInfo, CancellationToken cancellationToken)
        {
            RResult rResult = new();
            try
            {
                var entity = await _tbl_EmpRepository.GetByIdAsync(personalInfo.Emp_ID, cancellationToken);
                entity.Emp_oldNo = personalInfo.Emp_oldNo;
                entity.Emp_Name = personalInfo.Emp_Name;
                entity.Emp_Fname = personalInfo.Emp_Fname;
                entity.Emp_Mname = personalInfo.Emp_Mname;
                entity.Emp_Lname = personalInfo.Emp_Lname;
                entity.Emp_Appointment = personalInfo.Emp_Appointment;
                entity.Emp_Confirmation = personalInfo.Emp_Confirmation;
                entity.emp_type = personalInfo.emp_type;
                entity.Emp_Religion = personalInfo.Emp_Religion;
                entity.Emp_SSN = personalInfo.Emp_SSN;
                entity.Emp_Father = personalInfo.Emp_Father;
                entity.Emp_MotherName = personalInfo.Emp_MotherName;
                entity.Emp_DOB = personalInfo.Emp_DOB;
                entity.Emp_Gender = personalInfo.Emp_Gender;
                await _tbl_EmpRepository.UpdateAsync(entity, true);
                rResult.result = 1;
                rResult.message = ReturnMessage.UpdateMessage;
            }
            catch (Exception e)
            {
                rResult.result = 0;
                rResult.message = ReturnMessage.ErrorMessage;

            }
            return rResult;

        }
    }
}
