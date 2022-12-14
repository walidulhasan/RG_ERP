using RG.Application.Common.Mappings;
using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetSubTypes.Commands.DataTransferModel
{
    public class AssetSubTypeDTM:IMapFrom<AssetSubType>
    {
        public int AssetSubTypeID { get; set; }
        public int AssetTypeID { get; set; }
        public string SubTypeName { get; set; }
        public string Code { get; set; }
        public int Serial { get; set; }
        public string Description { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<AssetSubTypeDTM, AssetSubType>().ReverseMap();
        }
    }
}
