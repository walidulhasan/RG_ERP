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
    public class IC_GatepassMasterRM : IMapFrom<IC_GatepassMaster>
    {
        public IC_GatepassMasterRM()
        {
            IC_LocalSalesGatePassMaster = new IC_LocalSalesGatePassMasterRM();
            IC_SampleGatePassMaster = new IC_SampleGatePassMasterRM();
            IC_NonReturnableGatePassMaster = new IC_NonReturnableGatePassMasterRM();
            IC_ReturnableGatePassMaster = new IC_ReturnableGatePassMasterRM();
            IC_ExportSalesGatePassMaster = new IC_ExportSalesGatePassMasterRM();
            IC_ScrapSalesGatePassMaster = new IC_ScrapSalesGatePassMasterRM();
        }
        public long ID { get; set; }
        public string Serial { get; set; }
        public string VehicleNo { get; set; }
        public byte? CategoryID { get; set; }
        public long? CompanyID { get; set; }
        public IC_LocalSalesGatePassMasterRM IC_LocalSalesGatePassMaster { get; set; }
        public IC_SampleGatePassMasterRM IC_SampleGatePassMaster { get; set; }
        public IC_NonReturnableGatePassMasterRM IC_NonReturnableGatePassMaster { get; set; }
        public IC_ReturnableGatePassMasterRM IC_ReturnableGatePassMaster { get; set; }
        public IC_ExportSalesGatePassMasterRM IC_ExportSalesGatePassMaster { get; set; }
        public IC_ScrapSalesGatePassMasterRM IC_ScrapSalesGatePassMaster { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<IC_GatepassMasterRM, IC_GatepassMaster>().ReverseMap();
        }
    }
}
