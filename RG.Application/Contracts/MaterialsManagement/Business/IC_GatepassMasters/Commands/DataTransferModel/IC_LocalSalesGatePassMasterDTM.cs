using AutoMapper;
using RG.Application.Common.Mappings;
using RG.DBEntities.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Commands.DataTransferModel
{
    public class IC_LocalSalesGatePassMasterDTM : IMapFrom<IC_LocalSalesGatePassMaster>
    {
        public IC_LocalSalesGatePassMasterDTM()
        {
            IC_LocalSalesGatePassDetail = new List<IC_LocalSalesGatePassDetailDTM>();
        }
        public long GatePassID { get; set; }
        public long CustomerID { get; set; }
        public long DepartmentID { get; set; }
        public int? ProcessID { get; set; }
        public long IssuedBy { get; set; }
        public bool? isSelfVehicle { get; set; }
        public int? PaymentMode { get; set; }
       
        public List<IC_LocalSalesGatePassDetailDTM> IC_LocalSalesGatePassDetail { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<IC_LocalSalesGatePassMasterDTM, IC_LocalSalesGatePassMaster>();
        }
    }
}
