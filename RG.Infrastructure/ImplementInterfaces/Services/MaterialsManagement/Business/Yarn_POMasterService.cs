using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Business;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.MaterialsManagement.Business
{
    public class Yarn_POMasterService : IYarn_POMasterService
    {
        private readonly IYarn_POMasterRepository _yarn_POMasterRepository;

        public Yarn_POMasterService(IYarn_POMasterRepository yarn_POMasterRepository)
        {
            _yarn_POMasterRepository = yarn_POMasterRepository;
        }
        public async Task<List<SelectListItem>> DDLYarnPONo(int supplierID, DateTime poDateFrom, DateTime poDateTo, string Predict = null, CancellationToken cancellationToken = default)
        {            
            return await _yarn_POMasterRepository.DDLYarnPONo(supplierID, poDateFrom, poDateTo,Predict, cancellationToken);
        }
    }
}
