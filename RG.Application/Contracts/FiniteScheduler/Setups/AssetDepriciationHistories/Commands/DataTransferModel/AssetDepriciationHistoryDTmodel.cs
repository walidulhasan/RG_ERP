using RG.Application.Common.Mappings;
using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetDepriciationHistories.Commands.DataTransferModel
{
    public class AssetDepriciationHistoryDTmodel:IMapFrom<AssetDepriciationHistory>
    {
        public int ID { get; set; }
        public int AssetID { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public decimal Rate { get; set; }
        public string DepricationType { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<AssetDepriciationHistoryDTmodel, AssetDepriciationHistory>().ReverseMap();
        }
    }
}
