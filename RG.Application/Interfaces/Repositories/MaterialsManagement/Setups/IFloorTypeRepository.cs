using Microsoft.AspNetCore.Mvc.Rendering;
using RG.DBEntities.MaterialsManagement.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.MaterialsManagement.Setups
{
    public  interface IFloorTypeRepository:IGenericRepository<FloorType>
    {
        Task<List<SelectListItem>> GetDDLFloorType(CancellationToken cancellationToken);
    }
}
