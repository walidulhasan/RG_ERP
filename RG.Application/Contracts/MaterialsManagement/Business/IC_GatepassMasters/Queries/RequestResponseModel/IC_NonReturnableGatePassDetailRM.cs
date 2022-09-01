using AutoMapper;
using RG.Application.Common.Mappings;
using RG.DBEntities.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries.RequestResponseModel
{
    public class IC_NonReturnableGatePassDetailRM : IMapFrom<IC_NonReturnableGatePassDetail>
    {
        public long ID { get; set; }
        public string ItemName { get; set; }
        public double Quantity { get; set; }
        public int UnitID { get; set; }
        public double GrossWeight { get; set; }
        public string Remarks { get; set; }
        public long NonReturnableGatePassID { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<IC_NonReturnableGatePassDetailRM, IC_NonReturnableGatePassDetail>().ReverseMap();
        }
    }
}

