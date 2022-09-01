using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Utilities;
using RG.DBEntities.AlgoHR;
using RG.DBEntities.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.AlgoHR.Setup
{
  public  interface ITbl_DesignationRepository:IGenericRepository<Tbl_Designation>
    {
        Task<List<SelectListItem>> DDLDesignation(int? officeDivisionID, int? departmentID, int? sectionID, CancellationToken cancalletionToken = default);
        Task<List<SelectListItem>> DDLDesignation(List<int> officeDivisionID, List<int> departmentID, List<int> sectionID,string Predict=null, CancellationToken cancalletionToken = default);
        Task<List<IdNamePairRM>> DDLDesignationLookup(List<int> CompanyID, List<int> officeDivisionID, List<int> departmentID, List<int> sectionID,string Predict=null, CancellationToken cancalletionToken = default);
        Task<List<IdNamePairRM>> DDLSectionDesignationLookup(List<int> sectionID, string Predict = null, CancellationToken cancalletionToken = default);
    }
}
