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
    public class IC_ReturnableGatePassDetailRM : IMapFrom<IC_ReturnableGatePassDetail>
    {
        public long ID { get; set; }
        public int ReturnableItemCategoryID { get; set; }
        public int RequisitionID { get; set; }
        public string ItemName { get; set; }
        public decimal Quantity { get; set; }
        public int UnitID { get; set; }
        public decimal? GrossWeight { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public string Remarks { get; set; }
        public long? ReturnableGatePassID { get; set; }
        public decimal? RecieveQuantity { get; set; }
        public decimal? WastageQuantity { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<IC_ReturnableGatePassDetailRM, IC_ReturnableGatePassDetail>().ReverseMap();
        }
    }
}
