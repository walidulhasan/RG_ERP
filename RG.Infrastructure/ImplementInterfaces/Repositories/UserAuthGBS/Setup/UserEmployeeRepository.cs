using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.UserAuthGBS.Setup.User.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.UserAuthGBS.Setup;
using RG.DBEntities.UserAuthentication.DBViews;
using RG.Infrastructure.Persistence.UserAuthDB;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.UserAuthGBS.Setup
{
    public class UserEmployeeRepository : IUserEmployeeRepository
    {
        private readonly UserAuthDBContext _dbCon;

        public UserEmployeeRepository(UserAuthDBContext dbCon)
        {
            _dbCon = dbCon;
        }

        public async Task<List<DropDownItem>> GetDDLCustomUserEmployee(string Predict = null)
        {
            var data = await GetUserEmployee(Predict);
            var group = data
                         .Select(g => $"{g.DepartmentName}")
                         .Distinct()
                         .Select(gn => new SelectListGroup() { Name = gn })
                         .ToDictionary(gp => gp.Name, StringComparer.Ordinal);

            var dataValue = data
                            .Select(s => new DropDownItem()
                            {
                                Text = $"{s.UserName} ({s.EmployeeName}-{s.EmployeeCode})",
                                Value = s.SourceUserID.ToString(),
                                Custom1= s.UserID.ToString(),
                                Group = group[$"{s.DepartmentName}"]
                            }).ToList();
            return dataValue;
        }

        public async Task<List<SelectListItem>> GetDDLUserEmployee(string Predict = null)
        {
            var data = await GetUserEmployee(Predict);
            var group =   data
                         .Select(g => $"{g.DepartmentName}")
                         .Distinct()
                         .Select(gn => new SelectListGroup() { Name = gn })
                         .ToDictionary(gp => gp.Name, StringComparer.Ordinal);

            var dataValue = data
                            .Select(s => new SelectListItem()
                            {
                                Text = $"{s.UserName} ({s.EmployeeName}-{s.EmployeeCode})",
                                Value = s.UserID.ToString(), 
                                Group = group[$"{s.DepartmentName}"]
                            }).ToList();
            return dataValue;
        }

        public async Task<List<UserEmployeeRM>> GetUserEmployee(string Predict = null)
        {
            List<UserEmployeeRM> userEmp = new();
            await _dbCon.LoadStoredProc("USP_GetUserEmployee")
            .WithSqlParam("Predict", Predict)

            .ExecuteStoredProcAsync((handler) =>
            {
                userEmp = handler.ReadToList<UserEmployeeRM>() as List<UserEmployeeRM>;
            });
            return userEmp;

            
        }

        public IQueryable<Vw_UserEmployees> GetUserEmployee()
        {
            return _dbCon.Vw_UserEmployees.Where(x=>x.UserID>0);

        }
    }
}
