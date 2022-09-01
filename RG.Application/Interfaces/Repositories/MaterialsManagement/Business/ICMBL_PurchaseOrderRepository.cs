using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Contracts.AlgoHR.Business.SalaryAnalysisDivisions.Query.RequestResponseModel;
using RG.Application.ViewModel.MDSir.CMBLPurchaseOrder;
using RG.DBEntities.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.MaterialsManagement.Business
{
    public interface ICMBL_PurchaseOrderRepository:IGenericRepository<CMBL_PurchaseOrder>
    {
        Task<List<AnalysisDivisionWiseSalaryRM>> GetAnalysisDivisionWiseCost(string analysisDivision, string departmentGroup, int year, int month, CancellationToken cancellationToken);
        Task<POReportVM> GetPOReportMdSir(long POID, CancellationToken cancellationToken);
        Task<List<SelectListItem>> GetDDLPO(int companyID, string predict, CancellationToken cancellationToken);
    }
}
