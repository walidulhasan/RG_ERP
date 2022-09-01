using RG.Application.Common.Models;
using RG.DBEntities.FiniteScheduler.Business;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.FiniteScheduler.Business
{
  public  interface Itbl_KnittingInspectionMasterRepository:IGenericRepository<tbl_KnittingInspectionMaster>
    {
        //
        //Task<RResult> SaveRollsGSMFinishedWidth(List<tbl_KnittingStockTransactionViewModel> KnittingStockTransaction, int JobId, int createdBy, bool saveChanges = true);
        //Task<RResult> SaveYKNCInspection(List<tbl_KnittingStockTransactionViewModel> KnittingStockTransaction, int JobId, int createdBy, bool saveChanges = true);
    }
}
