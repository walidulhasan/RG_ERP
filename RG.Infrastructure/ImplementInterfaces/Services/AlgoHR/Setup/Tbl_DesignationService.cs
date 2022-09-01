using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Utilities;
using RG.Application.Interfaces.Repositories.AlgoHR.Setup;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AlgoHR.Setup
{
    public class Tbl_DesignationService : ITbl_DesignationService
    {
        private readonly ITbl_DesignationRepository _tbl_DesignationRepository;

        public Tbl_DesignationService(ITbl_DesignationRepository tbl_DesignationRepository)
        {
            _tbl_DesignationRepository = tbl_DesignationRepository;
        }
        public async Task<List<SelectListItem>> DDLDesignation(int? officeDivisionID, int? departmentID, int? sectionID, CancellationToken cancalletionToken = default)
        {
            return await _tbl_DesignationRepository.DDLDesignation(officeDivisionID, departmentID, sectionID, cancalletionToken);
        }

        public async Task<List<SelectListItem>> DDLDesignation(List<int> officeDivisionID, List<int> departmentID, List<int> sectionID, string Predict = null, CancellationToken cancalletionToken = default)
        {
            return await _tbl_DesignationRepository.DDLDesignation(officeDivisionID, departmentID, sectionID, Predict, cancalletionToken);
        }

        public async Task<List<IdNamePairRM>> DDLDesignationLookup(List<int> CompanyID, List<int> officeDivisionID, List<int> departmentID, List<int> sectionID, string Predict = null, CancellationToken cancalletionToken = default)
        {
            return await _tbl_DesignationRepository.DDLDesignationLookup(CompanyID,officeDivisionID,departmentID,sectionID,Predict,cancalletionToken);
        }

        public async Task<List<IdNamePairRM>> DDLSectionDesignationLookup(List<int> sectionID, string Predict = null, CancellationToken cancalletionToken = default)
        {
            return await _tbl_DesignationRepository.DDLSectionDesignationLookup(sectionID, Predict, cancalletionToken);
        }
    }
}
