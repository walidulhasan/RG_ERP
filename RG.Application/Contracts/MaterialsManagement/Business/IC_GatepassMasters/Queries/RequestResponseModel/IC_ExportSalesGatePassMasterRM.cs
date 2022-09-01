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
    public class IC_ExportSalesGatePassMasterRM : IMapFrom<IC_ExportSalesGatePassMaster>
    {
        public IC_ExportSalesGatePassMasterRM()
        {
            IC_ExportSalesGatePassDetail = new List<IC_ExportSalesGatePassDetailRM>();
        }
        public long? GatePassId { get; set; }
        public string CustomerId { get; set; }
        public long? IssuedBy { get; set; }
        public string Purpose { get; set; }
        public string VehicleRef { get; set; }
        public string Description { get; set; }
        public string DriverName { get; set; }
        public string MobileNo { get; set; }
        public string TransportServiceName { get; set; }
        public long? DepartmentID { get; set; }
        public List<IC_ExportSalesGatePassDetailRM> IC_ExportSalesGatePassDetail { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<IC_ExportSalesGatePassMasterRM, IC_ExportSalesGatePassMaster>().ReverseMap();
        }
    }
}