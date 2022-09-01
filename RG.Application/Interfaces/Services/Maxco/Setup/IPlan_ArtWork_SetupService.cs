using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Contracts.Maxco.Setup.Plan_ArtWork_Setup.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.Maxco.Setup
{
    public interface IPlan_ArtWork_SetupService
    {
        Task<List<SelectListItem>> DDLArtWork(CancellationToken cancellationToken=default);
        Task<PlanArtRM> GetArtWorkByID(int ID,CancellationToken cancellationToken = default);
    }
}
