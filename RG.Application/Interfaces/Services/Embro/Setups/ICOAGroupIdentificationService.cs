using RG.Application.Common.Models;
using RG.DBEntities.Embro.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.Embro.Setups
{
    public interface ICOAGroupIdentificationService
    {
        Task<RResult> Create(List<COAGroupIdentification> groupIdentification, bool saveChanges);
    }
}
