using AutoMapper;
using RG.Application.Common.Mappings;
using RG.DBEntities.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.IC_GatePassAccountReviews.Commands.DataTransferModel
{
    public class IC_GatePassAccountReviewDTM : IMapFrom<IC_GatePassAccountReview>
    {
        public int ID { get; set; }
        public long GatePassID { get; set; }
        public int PaymentTypeID { get; set; }
        public string Remarks { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<IC_GatePassAccountReviewDTM, IC_GatePassAccountReview>().ReverseMap();
        }
    }
}
