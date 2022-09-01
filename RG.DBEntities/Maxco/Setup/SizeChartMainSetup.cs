using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class SizeChartMainSetup
    {
        public SizeChartMainSetup()
        {
            SizeChartSpecificationSetup = new HashSet<SizeChartSpecificationSetup>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public int? VersionNo { get; set; }
        public int? BuyerId { get; set; }
        public int? GenderId { get; set; }
        public int? GarmentTypeId { get; set; }
        public int? SizeRangeRegionId { get; set; }

        public virtual ICollection<SizeChartSpecificationSetup> SizeChartSpecificationSetup { get; set; }
    }
}
