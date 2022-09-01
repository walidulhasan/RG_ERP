using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.AlgoHR.Setup;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AlgoHR.Setup
{
    public class Tbl_LocationService : ITbl_LocationService
    {
        private readonly ITbl_LocationRepository _tbl_LocationRepository;

        public Tbl_LocationService(ITbl_LocationRepository tbl_LocationRepository)
        {
            _tbl_LocationRepository = tbl_LocationRepository;
        }
        public async Task<List<SelectListItem>> DDLLocation(int CompanyID, CancellationToken cancellationToken)
        {
            var query = _tbl_LocationRepository.GetAll();
            if (CompanyID > 0)
            {
                query = query.Where(b => b.Location_Company == CompanyID);
            }
            return await query.Select(s => new SelectListItem()
            {
                Text = s.Location_Name,
                Value = s.Location_Id.ToString()
            }).ToListAsync(cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLLocation(List<int> CompanyID, string Predict = null, CancellationToken cancellationToken = default)
        {
            return await _tbl_LocationRepository.DDLLocation(CompanyID, Predict, cancellationToken);
        }
    }
}
