using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Contracts.Maxco.Setup.Plan_ArtWork_Setup.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.Maxco.Setup;
using RG.Application.Interfaces.Services.Maxco.Setup;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.Maxco.Setup
{
    public class Plan_ArtWork_SetupService : IPlan_ArtWork_SetupService
    {
        private readonly IPlan_ArtWork_SetupRepository _plan_ArtWork_SetupRepository;

        public Plan_ArtWork_SetupService(IPlan_ArtWork_SetupRepository plan_ArtWork_SetupRepository)
        {
            _plan_ArtWork_SetupRepository = plan_ArtWork_SetupRepository;
        }

        public async Task<List<SelectListItem>> DDLArtWork(CancellationToken cancellationToken = default)
        {
            var qryData = await _plan_ArtWork_SetupRepository
             .GetAll()
             .Where(b => b.IsRemoved == false && b.IsActive == true)
             .Select(s => new SelectListItem()
             {
                 Value = s.ArtWorkID.ToString(),
                 Text = s.ArtWorkName
             }).ToListAsync(cancellationToken);
            return qryData;
        }

        public async Task<PlanArtRM> GetArtWorkByID(int ID, CancellationToken cancellationToken = default)
        {
            return await _plan_ArtWork_SetupRepository.GetAll()
                .Where(b => b.ArtWorkID == ID)
                .Select(s => new PlanArtRM()
                {
                    ArtID = s.ArtWorkID,
                    ArtName = s.ArtWorkName
                }).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
