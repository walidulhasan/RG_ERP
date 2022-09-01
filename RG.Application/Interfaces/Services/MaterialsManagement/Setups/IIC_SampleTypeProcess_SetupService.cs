using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.MaterialsManagement.Setups
{
    public interface IIC_SampleTypeProcess_SetupService
    {
        Task<List<SelectListItem>> DDLSampleTypeProcess(int SampleTypeID, CancellationToken cancellationToken = default);
        Task<List<DropDownItem>> DDLCustomSampleTypeProcess(int SampleTypeID, CancellationToken cancellationToken = default);
    }
}
