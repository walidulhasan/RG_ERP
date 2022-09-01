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
    public interface  ITbl_CompanyService
    {
        public Task<List<SelectListItem>> GetDDLEmbroCompany();
        public Task<List<int>> GetEmbroToHrCompany(int EmbroCompanyID = 0,List<int> EmbroCompanyIDList = null,CancellationToken cancellationToken=default);

        public Task<List<IdNamePairRM>> GetDDLEmbroCompanyLookUp(int? CompanyID = 0,CancellationToken cancellationToken=default);
    }
}
