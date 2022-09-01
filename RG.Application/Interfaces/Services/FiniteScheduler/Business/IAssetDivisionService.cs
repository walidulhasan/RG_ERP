using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.FiniteScheduler.Business
{
    public  interface IAssetDivisionService
    {
        Task<List<SelectListItem>> EmbroCompanyWiseDDLDivision(int embroCompanyID, string Predict = null, CancellationToken cancellationToken = default);
    }
}
