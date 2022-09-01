using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.Embro.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Setups.SupplierSetups.Queries
{
    //public class GetDDLSuppliersQuery
    //{
    //}
    public class GetDDLSuppliersQuery : IRequest<List<SelectListItem>>
    {
        public GetDDLSuppliersQuery()
        {
            NotInSupplier = new List<int>();
            AccCategoryID = new List<int>();
        }
        public int CompanyID { get; set; } = 0;
        public List<int> AccCategoryID { get; set; }
        public List<int> NotInSupplier { get; set; }
        public string Predict { get; set; } = null;
    }
    public class GetDDLSuppliersQueryHandler : IRequestHandler<GetDDLSuppliersQuery, List<SelectListItem>>
    {
        private readonly ISupplierSetupService supplierSetupService;
        public GetDDLSuppliersQueryHandler(ISupplierSetupService _supplierSetupService)
        {
            supplierSetupService = _supplierSetupService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLSuppliersQuery request, CancellationToken cancellationToken)
        {
            return await supplierSetupService.DDLSuppliers(request.CompanyID, request.AccCategoryID, request.NotInSupplier, request.Predict, cancellationToken);
        }
    }
}
