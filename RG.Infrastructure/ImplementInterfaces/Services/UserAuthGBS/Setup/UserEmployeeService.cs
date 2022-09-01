using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.UserAuthGBS.Setup.User.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.UserAuthGBS.Setup;
using RG.Application.Interfaces.Services.UserAuthGBS.Setup;
using RG.DBEntities.UserAuthentication.DBViews;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.UserAuthGBS.Setup
{
    public class UserEmployeeService : IUserEmployeeService
    {
        private readonly IUserEmployeeRepository _userEmployeeRepository;

        public UserEmployeeService(IUserEmployeeRepository userEmployeeRepository)
        {
            _userEmployeeRepository = userEmployeeRepository;
        }

        public async Task<List<DropDownItem>> GetDDLCustomUserEmployee(string Predict = null)
        {
            return await _userEmployeeRepository.GetDDLCustomUserEmployee(Predict);
        }

        public async Task<List<SelectListItem>> GetDDLUserEmployee(string Predict = null)
        {
            return await _userEmployeeRepository.GetDDLUserEmployee(Predict);
        }

        public async Task<List<UserEmployeeRM>> GetUserEmployee(string Predict = null)
        {
            return await _userEmployeeRepository.GetUserEmployee(Predict);
        }

        public IQueryable<Vw_UserEmployees> GetUserEmployee()
        {
            var usersQuery = _userEmployeeRepository.GetUserEmployee();
            return usersQuery;
        }
    }
}
