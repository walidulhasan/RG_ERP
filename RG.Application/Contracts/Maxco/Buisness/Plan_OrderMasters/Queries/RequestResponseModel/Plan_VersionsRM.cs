using RG.Application.Common.Mappings;
using RG.DBEntities.Maxco.Business;
using System;

namespace RG.Application.Contracts.Maxco.Buisness.Plan_OrderMasters.Queries.RequestResponseModel
{
    public class Plan_VersionsRM:IMapFrom<Plan_Versions>
    {
        public int PlanVersionID { get; set; }
        public int VersionNo { get; set; }
        public int PlanID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedDateMsg { get { return CreatedDate.ToString("dd-MMM-yyyy"); } }
        public bool IsActive { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<Plan_Versions, Plan_VersionsRM>();
        }
    }
}
