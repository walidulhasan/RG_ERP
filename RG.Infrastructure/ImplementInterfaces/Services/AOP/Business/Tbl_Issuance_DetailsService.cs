using AutoMapper;
using RG.Application.Contracts.AOP.Business.Tbl_Issuance_Detailss.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AOP.Business;
using RG.Application.Interfaces.Services.AOP.Business;
using RG.DBEntities.AOP.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AOP.Business
{
    public class Tbl_Issuance_DetailsService : ITbl_Issuance_DetailsService
    {
        private readonly ITbl_Issuance_DetailsRepository tbl_Issuance_DetailsRepository;
        private readonly IMapper mapper;

        public Tbl_Issuance_DetailsService(ITbl_Issuance_DetailsRepository tbl_Issuance_DetailsRepository, IMapper _mapper)
        {
            this.tbl_Issuance_DetailsRepository = tbl_Issuance_DetailsRepository;
            mapper = _mapper;
        }
        public async Task<Tbl_Issuance_DetailsRM> GetTbl_Issuance_DetailsByID(long id, CancellationToken cancellationToken)
        {
            var data = mapper.Map<Tbl_Issuance_Details, Tbl_Issuance_DetailsRM>(await tbl_Issuance_DetailsRepository.GetByIdAsync(id));
            return data;
        }
    }
}
