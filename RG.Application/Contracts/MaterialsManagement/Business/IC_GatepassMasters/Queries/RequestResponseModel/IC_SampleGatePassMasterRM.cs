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
    public class IC_SampleGatePassMasterRM : IMapFrom<IC_SampleGatePassMaster>
    {
        public IC_SampleGatePassMasterRM()
        {
            IC_SampleGatePassDetail = new List<IC_SampleGatePassDetailRM>();
        }
        public long GatePassID { get; set; }
        public int SampleProcessTypeID { get; set; }
        public int? CustomerTypeID { get; set; }
        public int? CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int? OrderID { get; set; }
        public string ReferenceNo { get; set; }
        public string CarrierName { get; set; }
        public string SampleDescription { get; set; }
        public int? IssuedBy { get; set; }
        public string WeightSlipNo { get; set; }
        public int? DepartmentID { get; set; }
        public List<IC_SampleGatePassDetailRM> IC_SampleGatePassDetail { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<IC_SampleGatePassMasterRM, IC_SampleGatePassMaster>().ReverseMap();
        }
    }
}
