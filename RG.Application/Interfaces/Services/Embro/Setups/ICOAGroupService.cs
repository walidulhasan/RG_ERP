using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.Embro.Setups.COAGroups.Querirs.RequestResponseModel;
using RG.Application.ViewModel.Embro.Setup.COAGroupings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.Embro.Setups
{
    public interface ICOAGroupService
    {
        Task<RResult> Create(COAGroupingCreateVM COAGrouping,bool saveChange=true);
        Task<List<SelectListItem>> DDLCOAGroup(int categoryID, string predict, CancellationToken cancellationToken);
        Task<RResult> Update(COAGroupingCreateVM COAGrouping,bool saveChange);
        
        IQueryable<COAGroupingRM> GetListOfCOAGroup();
        Task<RResult> Remove(int id, bool saveChange);
    }
}
