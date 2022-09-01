using RG.Application.Common.Mappings;
using RG.DBEntities.FiniteScheduler.Business;
using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetInfos.Commands.DataTransferModel
{
    public class AssetInfoDTM:IMapFrom<AssetInfo>
    {
        public int AssetID { get; set; }
        public string AssetName { get; set; }
        public int AssetSubTypeID { get; set; }
        public int AssetAssignedType { get; set; }
        public string Code { get; set; }
        
        public string BrandName { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PurchaseValue { get; set; }
        public decimal ValueAfterDeprication { get; set; }
        public int CompanyID { get; set; }
        public bool IsReturnable { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
        public DateTime DapricationDateFrom { get; set; }
        public DateTime DapricationDateTo { get; set; }
        public decimal DepriciationPercent { get; set; }
        public List<AssetAttributeAssociationValueDTM> AssetAttributeAssociationValue { get; set; }
        public List<AssetLocationDTM> AssetLocation { get; set; }
        public int FunctionalStatusID { get; set; }
        public decimal? Capacity { get; set; }
        public int? CapacityUnitID { get; set; }
        public string ModelNo { get; set; }
        public string LCNo { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<AssetInfoDTM, AssetInfo>().ReverseMap();
        }
    }


    public class AssetLocationDTM : IMapFrom<AssetLocation>
    {
        
        public int AssetID { get; set; }
        public int BuildingID { get; set; }
        public int FloorID { get; set; }
        public int DepartmentID { get; set; }
        public string EmployeeCode { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public bool IsReturned { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<AssetLocationDTM, AssetLocation>().ReverseMap();
        }
    }
    public class AssetAttributeAssociationValueDTM : IMapFrom<AssetAttributeAssociationValue>
    {
        public long AssociationValueID { get; set; }
        public int AssociationID { get; set; }
        public int? ValueID { get; set; }
        public string ValueDescription { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<AssetAttributeAssociationValueDTM, AssetAttributeAssociationValue>().ReverseMap();
        }
    }
}
