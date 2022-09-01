using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.Embro.Setups.COAGroups.Querirs.RequestResponseModel;
using RG.Application.ViewModel.Embro.Setup.COAGroupings;
using RG.DBEntities.Embro.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.Embro.Setups
{
    public interface ICOAGroupRepository:IGenericRepository<COAGroup>
    {
        Task<List<SelectListItem>> DDLCOAGroup(int categoryID, string predict, CancellationToken cancellationToken);
        
        IQueryable<COAGroupingRM> GetListOfCOAGroup();
        Task<bool> IsDuplicateValue(COAGroupingCreateVM model);


    }
}
