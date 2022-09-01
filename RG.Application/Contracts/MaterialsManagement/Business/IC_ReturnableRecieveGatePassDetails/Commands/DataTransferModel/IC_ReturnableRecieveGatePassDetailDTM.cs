using AutoMapper;
using RG.Application.Common.Mappings;
using RG.DBEntities.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.IC_ReturnableRecieveGatePassDetails.Commands.DataTransferModel
{
    public class IC_ReturnableRecieveGatePassDetailDTM : IMapFrom<IC_ReturnableRecieveGatePassDetail>
    {
        public double Quantity { get; set; }
        public int UnitID { get; set; }
        public double? GrossWeight { get; set; }
        public long? ReturnableGatePassItemID { get; set; }
        public decimal RecieveQuantity { get; set; }
        public decimal WastageQuantity { get; set; }
        public DateTime? RecieveDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<IC_ReturnableRecieveGatePassDetailDTM, IC_ReturnableRecieveGatePassDetail>();
        }
    }
}
