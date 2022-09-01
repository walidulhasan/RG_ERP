using System;

namespace RG.Application.Contracts.Maxco.Buisness.OrderPlanReports.Queries.RequestResponseModel
{
    
    public class ArtWorkRM
    {
        public int OrderID { get; set; }
        public string PantoneNo { get; set; }
        public string ArtWorkName { get; set; }
        public DateTime ArtWorkDate { get; set; }
    }
}
