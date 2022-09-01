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
    public class IC_ScrapSalesGatePassMasterRM : IMapFrom<IC_ScrapSalesGatePassMaster>
    {
        public IC_ScrapSalesGatePassMasterRM()
        {
            IC_ScrapSalesGatePassDetail = new List<IC_ScrapSalesGatePassDetailRM>();
        }
        public long GatePassID { get; set; }
        public long ScrapCustomerID { get; set; }
        public long IssuedBy { get; set; }
        public string WeightSlipNo { get; set; }
        public int? DepartmentId { get; set; }
        public string VehicleDriverMobileNo { get; set; }
        public string Description { get; set; }
        public bool? IsSelfVehicle { get; set; }
        public List<IC_ScrapSalesGatePassDetailRM> IC_ScrapSalesGatePassDetail { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<IC_ScrapSalesGatePassMasterRM, IC_ScrapSalesGatePassMaster>().ReverseMap();
        }
    }
}