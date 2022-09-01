using AutoMapper;
using RG.Application.Common.Models;
using RG.Application.Contracts.Maxco.Buisness.Plan_OrderMasters.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.Maxco.Business;
using RG.Application.Interfaces.Services.Maxco.Business;
using RG.DBEntities.Maxco.Business;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.Maxco.Business
{
    public class Plan_VersionsService : IPlan_VersionsService
    {
        private readonly IPlan_VersionsRepository plan_VersionsRepository;
        private readonly IMapper mapper;

        public Plan_VersionsService(IPlan_VersionsRepository _plan_VersionsRepository, IMapper _mapper)
        {
            plan_VersionsRepository = _plan_VersionsRepository;
            mapper = _mapper;
        }
        public async Task<List<Plan_VersionsRM>> GetOrderWisePlanVersions(int orderID, CancellationToken cancellationToken)
        {
            var data = await plan_VersionsRepository.GetOrderWisePlanVersions(orderID, cancellationToken);
            return mapper.Map<List<Plan_Versions>, List<Plan_VersionsRM>>(data);
        }

        public async Task<RResult> InActivePlanVersion(int orderID)
        {
            RResult rResult = new();
            var data = await plan_VersionsRepository.GetOrderWiseActivePlanVersion(orderID, new CancellationToken());            
            data.IsActive = false;
            await plan_VersionsRepository.UpdateAsync(data);
            rResult.result = 1;
            return rResult;
        }
    }
}
