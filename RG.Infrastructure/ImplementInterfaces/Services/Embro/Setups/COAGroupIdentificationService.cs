using RG.Application.Common.Models;
using RG.Application.Interfaces.Repositories.Embro.Setups;
using RG.Application.Interfaces.Services.Embro.Setups;
using RG.DBEntities.Embro.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.Embro.Setups
{
    public class COAGroupIdentificationService : ICOAGroupIdentificationService
    {
        private readonly ICOAGroupIdentificationRepository _cOAGroupIdentificationRepository;

        public COAGroupIdentificationService(ICOAGroupIdentificationRepository cOAGroupIdentificationRepository)
        {
            _cOAGroupIdentificationRepository = cOAGroupIdentificationRepository;
        }
        public async Task<RResult> Create(List<COAGroupIdentification> groupIdentification, bool saveChanges)
        {
            return await _cOAGroupIdentificationRepository.Create(groupIdentification, saveChanges);
        }
    }
}
