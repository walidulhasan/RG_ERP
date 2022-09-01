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
    public class IC_NonReturnableGatePassDetailDTM : IMapFrom<IC_NonReturnableGatePassDetail>
    {
        public long ID { get; set; }
        public string ItemName { get; set; }
        public double Quantity { get; set; }
        public int UnitID { get; set; }
        public double GrossWeight { get; set; }
        public string Remarks { get; set; }
        public long NonReturnableGatePassID { get; set; }
        public bool IsAddedOrUpdated { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<IC_NonReturnableGatePassDetailDTM, IC_NonReturnableGatePassDetail>();

        }
    }
}
