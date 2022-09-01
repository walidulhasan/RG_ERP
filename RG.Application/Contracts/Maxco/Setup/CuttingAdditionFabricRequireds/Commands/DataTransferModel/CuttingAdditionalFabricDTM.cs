using RG.Application.Common.Mappings;
using RG.DBEntities.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Setup.CuttingAdditionFabricRequireds.Commands.DataTransferModel
{
    public class CuttingAdditionalFabricDTM:IMapFrom<CuttingAdditionFabricRequired>
    {
        public int ID { get; set; }
        public long OrderID { get; set; }
        public DateTime RequisitionDate { get; set; }
        public decimal RequisitionQuantity { get; set; }
        public decimal PlanQuantity { get; set; } 
        //public decimal? StandardEfficiencyPercent { get; set; }
        //public decimal? OverAllEfficiencyPercent { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<CuttingAdditionalFabricDTM, CuttingAdditionFabricRequired>();
        }
      
    }
}
