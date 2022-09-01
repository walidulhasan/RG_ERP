using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.ViewModel.MaterialsManagement.Setup;
using RG.DBEntities.MaterialsManagement.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.MaterialsManagement.Setups
{
    public interface IYarnSubRackSetupRepository:IGenericRepository<YarnSubRackSetup>
    {
        Task<List<SelectListItem>> DDLRackWiseSubRack(int rackID, bool withStorageLimit = false, CancellationToken cancellationToken=default);
        Task<List<DropDownItem>> CustomDDLRackWiseSubRack(int rackID, bool withStorageLimit = false, CancellationToken cancellationToken = default);
        Task<List<YarnSubRackVM>> SubRackEdit(int rackID, CancellationToken cancellationToken);

    }
}
