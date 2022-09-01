using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.MaterialsManagement.Setups
{
    public interface IYarnSubRackSetupService
    {
        Task<List<SelectListItem>> DDLRackWiseSubRack(int rackID, bool withStorageLimit = false, CancellationToken cancellationToken=default);
        Task<List<DropDownItem>> CustomDDLRackWiseSubRack(int rackID, bool withStorageLimit = false, CancellationToken cancellationToken = default);
    }
}
