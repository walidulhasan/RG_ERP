using AutoMapper;
using RG.Application.Common.Mappings;
using RG.DBEntities.FiniteScheduler.Setup;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetTypes.Commands.DataTransferModel
{
    public class AssetTypeDTM : IMapFrom<AssetType>
    {
        public int AssetTypeID { get; set; }
        public string TypeName { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AssetTypeDTM, AssetType>();
        }
    }
}
