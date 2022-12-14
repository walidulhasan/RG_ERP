using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.UserAuthGBS.Setup.User.Queries.RequestResponseModel;
using RG.DBEntities.UserAuthentication.DBViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.UserAuthGBS.Setup
{
    public interface IUserEmployeeRepository
    {
        Task<List<UserEmployeeRM>> GetUserEmployee(string Predict = null);
        Task<List<SelectListItem>> GetDDLUserEmployee(string Predict = null);
        Task<List<DropDownItem>> GetDDLCustomUserEmployee(string Predict = null);
        IQueryable<Vw_UserEmployees> GetUserEmployee();
    }
}
