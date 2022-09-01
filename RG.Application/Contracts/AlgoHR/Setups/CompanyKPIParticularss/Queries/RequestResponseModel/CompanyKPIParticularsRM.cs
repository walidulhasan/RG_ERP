using RG.Application.Common.Mappings;
using RG.DBEntities.AlgoHR.Setup;

namespace RG.Application.Contracts.AlgoHR.Setups.CompanyKPIParticularss.Queries.RequestResponseModel
{
    public class CompanyKPIParticularsRM:IMapFrom<CompanyKPIParticulars>
    {
        public int ID { get; set; }
        public int Serial { get; set; }
        public string ParticularHead { get; set; }
        public string Particulars { get; set; }
        public int ParticularValueID { get; set; }
        public decimal? ParticularValue { get; set; }
        public bool IsCalculationParticular { get; set; }
        public bool AutoCalculation { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<CompanyKPIParticulars, CompanyKPIParticularsRM>();
        }
    }
}
