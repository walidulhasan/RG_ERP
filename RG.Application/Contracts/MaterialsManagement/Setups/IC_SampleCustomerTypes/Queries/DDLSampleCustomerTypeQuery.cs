using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.IC_SampleCustomerTypes.Queries
{
    public class DDLSampleCustomerTypeQuery : IRequest<List<SelectListItem>>
    {
    }
    public class DDLSampleCustomerTypeQueryHandler : IRequestHandler<DDLSampleCustomerTypeQuery, List<SelectListItem>>
    {
        private readonly IIC_SampleCustomerTypeService iC_SampleCustomerTypeService;

        public DDLSampleCustomerTypeQueryHandler(IIC_SampleCustomerTypeService _iC_SampleCustomerTypeService)
        {
            iC_SampleCustomerTypeService = _iC_SampleCustomerTypeService;
        }
        public async Task<List<SelectListItem>> Handle(DDLSampleCustomerTypeQuery request, CancellationToken cancellationToken)
        {
            var dataList = await iC_SampleCustomerTypeService.DDLSampleCustomerType(cancellationToken);
            return dataList;

        }
    }
}
