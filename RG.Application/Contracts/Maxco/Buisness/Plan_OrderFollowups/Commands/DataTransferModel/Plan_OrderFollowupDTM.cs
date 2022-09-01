using RG.Application.Common.Mappings;
using RG.DBEntities.Maxco.Business;
using System;

namespace RG.Application.Contracts.Maxco.Buisness.Plan_OrderFollowups.Commands.DataTransferModel
{
    public class Plan_OrderFollowupDTM:IMapFrom<Plan_OrderFollowup>
    {
        public int FollowupID { get; set; }
        public int OrderID { get; set; }
        public int OrderClassificationID { get; set; }
        public decimal? AdditionalFromStock { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public DateTime? PackingCompleteDate { get; set; }
        public DateTime? PreFinalDate { get; set; }
        public bool IsOrderClosed { get; set; }
        public DateTime? ExpectedSampleDate { get; set; }
        public DateTime? PreProductionSampleApprovalDate { get; set; }
        public string Remarks { get; set; }
        public static void Mapping(MappingProfile profile)
        {
            profile.CreateMap<Plan_OrderFollowupDTM, Plan_OrderFollowup>();
        }
    }
}
