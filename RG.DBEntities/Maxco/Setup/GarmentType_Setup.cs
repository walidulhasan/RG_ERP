using RG.DBEntities.Maxco.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Setup
{
    public class GarmentType_Setup
    {
        public GarmentType_Setup()
        {
            ChainHistoricalNmax = new HashSet<ChainHistoricalNmax>();
            GarmentSizeRangeSetup = new HashSet<GarmentSizeRange_Setup>();
            Series = new HashSet<Series>();
            SizeChartPlacementSetup = new HashSet<SizeChartPlacementSetup>();
        }

        public byte ID { get; set; }
        public string Description { get; set; }
        public int? NoOfPatternPieces { get; set; }
        public int? GarmentCategoryID { get; set; }
        public string GarmentCode { get; set; }
        public string ImagePath { get; set; }

        public virtual GarmentCategory_Setup GarmentCategory { get; set; }
        public virtual ICollection<ChainHistoricalNmax> ChainHistoricalNmax { get; set; }
        public virtual ICollection<GarmentSizeRange_Setup> GarmentSizeRangeSetup { get; set; }
        public virtual ICollection<Series> Series { get; set; }
        public virtual ICollection<SizeChartPlacementSetup> SizeChartPlacementSetup { get; set; }
    }
}
