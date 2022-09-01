using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class TissuePaper
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int? PrintImageId { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int UnitId { get; set; }
        public int NumberPerGarment { get; set; }
        public int ItemSourceId { get; set; }
        public string Comments { get; set; }
        public int? SelectedPackingAccessoriesId { get; set; }
    }
}
