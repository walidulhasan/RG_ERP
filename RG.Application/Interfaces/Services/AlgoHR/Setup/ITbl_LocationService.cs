using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AlgoHR.Setup
{
   public interface ITbl_LocationService
    {
        Task<List<SelectListItem>> DDLLocation(int CompanyID, CancellationToken cancellationToken);
        Task<List<SelectListItem>> DDLLocation(List<int> CompanyID,string Predict=null, CancellationToken cancellationToken=default);
    }
}
