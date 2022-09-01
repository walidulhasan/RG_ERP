using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AlgoHR.Setup
{
    public interface ITbl_DivisionService
    {
        Task<List<SelectListItem>> DDLDivision(int embroCompanyID, List<int> exceptDivision, string Predict = null, CancellationToken cancellationToken=default);
        Task<List<SelectListItem>> DDLDivision(List<int> embroCompanyID, List<int> exceptDivision, string Predict = null, CancellationToken cancellationToken = default);

        Task<List<IdNamePairRM>> DDLDivisionLookUp(List<int> embroCompanyID, List<int> exceptDivision, string Predict = null, CancellationToken cancellationToken = default);
    }
}
