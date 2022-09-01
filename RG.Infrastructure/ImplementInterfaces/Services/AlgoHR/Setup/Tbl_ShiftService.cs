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
    public class Tbl_ShiftService : Itbl_ShiftService
    {
        private readonly Itbl_ShiftRepository _shiftRepository;

        public Tbl_ShiftService(Itbl_ShiftRepository shiftRepository)
        {
            _shiftRepository = shiftRepository;
        }
        public async Task<List<SelectListItem>> DDLAttendanceShift(CancellationToken cancellationToken = default)
        {
            var query = _shiftRepository.GetAll();
            query = query.Where(b => b.Shift_Active == true);

            return await query.Select(b => new SelectListItem()
            {
                Text = b.Shift_Name,
                Value = b.Shift_ID.ToString()
            }).ToListAsync(cancellationToken);
        }
    }
}
