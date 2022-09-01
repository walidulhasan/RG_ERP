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
    public class IC_LocalSalesGatePassMasterRM : IMapFrom<IC_LocalSalesGatePassMaster>
    {
        public IC_LocalSalesGatePassMasterRM()
        {
            IC_LocalSalesGatePassDetail = new List<IC_LocalSalesGatePassDetailRM>();
        }
        public long GatePassID { get; set; }
        public long CustomerID { get; set; }
        public long DepartmentID { get; set; }
        public long IssuedBy { get; set; }
        public bool? isSelfVehicle { get; set; }
        public List<IC_LocalSalesGatePassDetailRM> IC_LocalSalesGatePassDetail { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<IC_LocalSalesGatePassMasterRM, IC_LocalSalesGatePassMaster>().ReverseMap();
        }
    }
}

