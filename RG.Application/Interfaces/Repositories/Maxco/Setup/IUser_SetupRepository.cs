using Microsoft.AspNetCore.Mvc.Rendering;
using RG.DBEntities.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.Maxco.Setup
{
    public interface IUser_SetupRepository : IGenericRepository<User_Setup>
    {
        Task<User_Setup> GetUserSetupDetails(int UserID, CancellationToken cancellationToken);
        Task<List<SelectListItem>> GetDDLAlgoUser(int CompanyID = 0, string Predict = "", CancellationToken cancellationToken = default);

    }
}
