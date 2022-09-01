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
    public class Tbl_EmpTypeService : ITbl_EmpTypeService
    {
        private readonly ITbl_EmpTypeRepository _tbl_EmpTypeRepository;

        public Tbl_EmpTypeService(ITbl_EmpTypeRepository tbl_EmpTypeRepository)
        {
            _tbl_EmpTypeRepository = tbl_EmpTypeRepository;
        }
        public async Task<List<SelectListItem>> DDLEmployeeType(CancellationToken cancellationToken)
        {
            var query = _tbl_EmpTypeRepository.GetAll();
            var dataQuery = query.Select(s => new SelectListItem()
            {
                Text = s.Type_Name,
                Value = s.Type_ID.ToString()
            });

            return await dataQuery.ToListAsync(cancellationToken);
        }
    }
}
