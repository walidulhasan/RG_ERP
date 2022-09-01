using RG.Application.Common.Mappings;
using RG.DBEntities.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Setup.Production_Efficiency.Commands.DataTransferModel
{
    public class ProductionEfficiencyDTM:IMapFrom<GarmentsProductionEfficiency>
    {
        public int ID { get; set; }
        public DateTime ProductionDate { get; set; }
        public decimal? StandardEfficiencyPercent { get; set; }
        public decimal? OverAllEfficiencyPercent { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<ProductionEfficiencyDTM, GarmentsProductionEfficiency>();
        }
    }
}
