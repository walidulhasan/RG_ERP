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
    public class IC_SampleGatePassDetailRM : IMapFrom<IC_SampleGatePassDetail>
    {
        public long ID { get; set; }
        public string ItemName { get; set; }
        public double Quantity { get; set; }
        public int UnitID { get; set; }
        public double? FirstWeight { get; set; }
        public double? SecondWeight { get; set; }
        public string Remarks { get; set; }
        public long? ScrapSalesGatePassID { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<IC_SampleGatePassDetailRM, IC_SampleGatePassDetail>().ReverseMap();
        }
    }
}
