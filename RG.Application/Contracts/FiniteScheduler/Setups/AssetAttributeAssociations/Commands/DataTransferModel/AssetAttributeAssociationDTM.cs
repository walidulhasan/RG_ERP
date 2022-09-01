using AutoMapper;
using RG.Application.Common.Mappings;
using RG.DBEntities.FiniteScheduler.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetAttributeAssociations.Commands.DataTransferModel
{
    public class AssetAttributeAssociationDTM : IMapFrom<AssetAttributeAssociation>
    {
        public int AssociationID { get; set; }
        public int AssetSubTypeID { get; set; }
        public int AttributeID { get; set; }
        public int PrioritySerial { get; set; }
        public bool IsVisible { get; set; }
        public bool IsFilterable { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AssetAttributeAssociationDTM, AssetAttributeAssociation>().ReverseMap();
        }
    }
   
}
