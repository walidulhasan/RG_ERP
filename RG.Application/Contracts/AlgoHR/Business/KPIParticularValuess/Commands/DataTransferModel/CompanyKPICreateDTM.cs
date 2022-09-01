using RG.Application.Common.Mappings;
using RG.DBEntities.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.KPIParticularValuess.Commands.DataTransferModel
{
    public class CompanyKPICreateDTM : IMapFrom<KPIParticularValues>
    {
        public int ID { get; set; }
        public int ParticularID { get; set; }
        public decimal? ParticularValue { get; set; }
        public int KPIMonth { get; set; }
        public int KPIYear { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<CompanyKPICreateDTM, KPIParticularValues>();
        }
    }
}
