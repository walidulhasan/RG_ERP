using RG.Application.Common.Models;
using RG.DBEntities.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.MaterialsManagement.Business
{
    public interface IYarn_IssuanceToKnitterMasterRepository:IGenericRepository<Yarn_IssuanceToKnitterMaster>
    {
        Task<RResult> Yarn_IssuanceToKnitterMasterSave(Yarn_IssuanceToKnitterMaster entity, bool saveChanges = true);
    }
}
