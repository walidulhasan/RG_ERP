using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.DBEntities.FiniteScheduler.Business;
using RG.DBEntities.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.FiniteScheduler.Business
{
  public  interface Itbl_knittingGateRepository:IGenericRepository<tbl_knittingGate>
    {
        //Task<List<SelectListItem>> DDLYKNCListForGateReceiving(int KnitterId);
        //Task<RResult> SaveInitialGateReceiving(tbl_knittingGateViewModel knittingGate, double totalQty, List<Yarn_KnittingContractDetail> ykncDetail, int createdBy, bool saveChanges = true);
    }
}
