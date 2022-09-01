using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.Tbl_Emp.Query.RequestResponseModel;
using RG.Application.Contracts.AlgoHR.Setups.UserDepartmentAccess.Commands.DataTransferModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Setup;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using RG.DBEntities.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AlgoHR.Setup
{
    public class UserDepartmentAccessService : IUserDepartmentAccessService
    {
        private readonly IUserDepartmentAccessRepository _userDepartmentAccessRepository;
        private readonly IMapper mapper;

        public UserDepartmentAccessService(IUserDepartmentAccessRepository userDepartmentAccessRepository, IMapper _mapper)
        {
            _userDepartmentAccessRepository = userDepartmentAccessRepository;
            mapper = _mapper;
        }
        public async Task<List<SelectListItem>> DDLUserCompany(int UserID, bool IsAll = false, CancellationToken cancellationToken = default)
        {
            return await _userDepartmentAccessRepository.DDLUserCompany(UserID, IsAll, cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLUserDepartment(int UserID, List<int> CompanyID, List<int> DivisionID, bool IsAll = false, string Predict = null, CancellationToken cancellationToken = default)
        {
            return await _userDepartmentAccessRepository.DDLUserDepartment(UserID, CompanyID, DivisionID, IsAll,Predict, cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLUserDivision(int UserID, List<int> CompanyID, bool IsAll = false,string Predict=null, CancellationToken cancellationToken = default)
        {
            return await _userDepartmentAccessRepository.DDLUserDivision(UserID, CompanyID, IsAll,Predict, cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLUserSection(int UserID, List<int> CompanyID, List<int> DivisionID, List<int> DepartmentID, bool IsAll = false, string Predit = null, CancellationToken cancellationToken = default)
        {
            return await _userDepartmentAccessRepository.DDLUserSection(UserID, CompanyID, DivisionID, DepartmentID, IsAll,Predit, cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLUserSectionEmployee(int UserID, List<int> CompanyID, List<int> DivisionID, List<int> DepartmentID
             , List<int> SectionID, List<int> Designations, List<int>  Locations, int? EmployeeTypes=null, string Gender=null,bool?ActiveStatus=null
             , string Predit = null, bool IsAll = false, CancellationToken cancellationToken = default)
        {
            return await _userDepartmentAccessRepository.DDLUserSectionEmployee(UserID, CompanyID, DivisionID, DepartmentID,SectionID
                ,Designations,Locations,EmployeeTypes,Gender,ActiveStatus
                ,Predit, IsAll, cancellationToken);
        }

        public IQueryable<EmployeeToSectionRM> GetUserDepartmentAccessList(int UserID = 0)
        {
            return _userDepartmentAccessRepository.GetUserDepartmentAccessList(UserID);
        }

        public async Task<RResult> InsertUserDepartmentAccess(List<UserDepartmentAccessCreateDTM> model)
        {
            try
            {
                var entities = mapper.Map<List<UserDepartmentAccessCreateDTM>, List<UserDepartmentAccess>>(model);
                return await _userDepartmentAccessRepository.SaveUserDepartmentAccess(entities);
            }
            catch (Exception e)
            {
                throw;
            }
          
        }

        public Task<RResult> UpdateUserDepartmentAccess(List<UserDepartmentAccess> model)
        {
            throw new NotImplementedException();
        }
    }
}
