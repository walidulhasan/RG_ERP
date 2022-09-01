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
    public class IC_ReturnableGatePassDetailDTM : IMapFrom<IC_ReturnableGatePassDetail>
    {
        public long ID { get; set; }
        public int ReturnableItemCategoryID { get; set; }
        public int RequisitionID { get; set; }
        public string ItemName { get; set; }
        public double Quantity { get; set; }
        public int UnitID { get; set; }
        public double? GrossWeight { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public string Remarks { get; set; }
        public long? ReturnableGatePassID { get; set; }
        public decimal? RecieveQuantity { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<IC_ReturnableGatePassDetailDTM, IC_ReturnableGatePassDetail>();
        }
    }
}
