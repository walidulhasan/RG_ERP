using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Utilities;
using RG.Application.Interfaces.Repositories.AlgoHR.Setup;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AlgoHR.Setup
{
    public class Tbl_CompanyService : ITbl_CompanyService
    {
        private readonly ITbl_CompanyRepository _tbl_CompanyRepository;

        public Tbl_CompanyService(ITbl_CompanyRepository tbl_CompanyRepository)
        {
            _tbl_CompanyRepository = tbl_CompanyRepository;
        }
        public Task<List<SelectListItem>> GetDDLEmbroCompany()
        {
            throw new NotImplementedException();
        }

        public async Task<List<IdNamePairRM>> GetDDLEmbroCompanyLookUp(int? CompanyID = 0, CancellationToken cancellationToken = default)
        {
            return await _tbl_CompanyRepository.GetDDLEmbroCompanyLookUp(CompanyID, cancellationToken);
        }

        public async Task<List<int>> GetEmbroToHrCompany(int EmbroCompanyID = 0, List<int> EmbroCompanyIDList = null, CancellationToken cancellationToken = default)
        {
            var query = _tbl_CompanyRepository.GetAll();
            if (EmbroCompanyID > 0)
            {
                query = query.Where(b => b.EmbroCompanyID == EmbroCompanyID);
            }
            if (EmbroCompanyIDList.Count > 0)
            {
                query = query.Where(b => EmbroCompanyIDList.Contains(b.EmbroCompanyID));
            }
            return await query.Select(s =>s.Cmp_ID).ToListAsync(cancellationToken);

        }
    }
}
