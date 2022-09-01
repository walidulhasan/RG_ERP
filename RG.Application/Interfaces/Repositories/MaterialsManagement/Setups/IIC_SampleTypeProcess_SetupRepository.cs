﻿using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.DBEntities.MaterialsManagement.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.MaterialsManagement.Setups
{
    public interface IIC_SampleTypeProcess_SetupRepository : IGenericRepository<IC_SampleTypeProcess_Setup>
    {
        Task<List<SelectListItem>> DDLSampleTypeProcess(int SampleTypeID, CancellationToken cancellationToken = default);
        Task<List<DropDownItem>> DDLCustomSampleTypeProcess(int SampleTypeID, CancellationToken cancellationToken = default);
    }
}
