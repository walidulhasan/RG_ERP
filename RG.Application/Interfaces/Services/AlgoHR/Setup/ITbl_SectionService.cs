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
    public interface ITbl_SectionService
    {
        Task<List<SelectListItem>> DDLSection(int departmentID,CancellationToken cancellationToken=default);
        Task<List<SelectListItem>> DDLSection(List<int> departmentID,string Predict=null, CancellationToken cancellationToken = default);
        Task<List<IdNamePairRM>> DDLSectionLookup(List<int> departmentID,string Predict=null, CancellationToken cancellationToken = default);
    }
}
