using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Interfaces.Repositories.Embro.Setups;
using RG.DBEntities.Embro.Setup;
using RG.Infrastructure.Persistence.EmbroDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.Embro.Setups
{
    public class ERP_PaymentModesRepository : GenericRepository<ERP_PaymentModes>, IERP_PaymentModesRepository
    {
        private readonly EmbroDBContext dbCon;
        private readonly ICurrentUserService _currentUserService;

        public ERP_PaymentModesRepository(EmbroDBContext context, ICurrentUserService currentUserService )
            : base(context)
        {
            dbCon = context;
            _currentUserService = currentUserService;
        }

        public async Task<List<SelectListItem>> GetDDLERP_PaymentModes(CancellationToken cancellationToken)
        {
            var companyID = _currentUserService.CompanyID;
            var data = await dbCon.ERP_PaymentModes.Where(x=>x.CompanyID.Equals(companyID))
                .Select(x => new SelectListItem
                {
                    Text = x.PMDescription.Trim(),
                    Value = x.PMID.ToString()
                }).ToListAsync(cancellationToken);
            return data;
        }
    }
}
