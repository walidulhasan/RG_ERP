using MediatR;
using RG.Application.Contracts.MaterialsManagement.Business.Yarn_PermanentReceivingMasters.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.Yarn_PermanentReceivingMasters.Queries
{
    public class GetYarnReceivingByPOForRackAllocationQuery : IRequest<List<YarnReceivingByPoRM>>
    {
        public long SupplierID { get; set; }
        public long POID { get; set; }
        public long YarnPermRecID { get; set; }
        public int TopData { get; set; }
        public string LotNo { get; set; }
    }
    public class GetYarnReceivingByPOQueryHandler : IRequestHandler<GetYarnReceivingByPOForRackAllocationQuery, List<YarnReceivingByPoRM>>
    {
        private readonly IYarn_PermanentReceivingMasterService _yarn_PermanentReceivingMasterService;

        public GetYarnReceivingByPOQueryHandler(IYarn_PermanentReceivingMasterService yarn_PermanentReceivingMasterService)
        {
            _yarn_PermanentReceivingMasterService = yarn_PermanentReceivingMasterService;
        }
        public async Task<List<YarnReceivingByPoRM>> Handle(GetYarnReceivingByPOForRackAllocationQuery request, CancellationToken cancellationToken)
        {
            return await _yarn_PermanentReceivingMasterService.YarnReceivingByPOForRackAllocation(request.SupplierID, request.POID, request.YarnPermRecID,request.TopData,request.LotNo,cancellationToken);
        }
    }
}
