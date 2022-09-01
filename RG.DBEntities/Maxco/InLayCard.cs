using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class InLayCard
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public int UnitId { get; set; }
        public double Thickness { get; set; }
        public int NumberPerGarment { get; set; }
        public bool IsFolded { get; set; }
        public int? PrintImageId { get; set; }
        public string Comments { get; set; }
        public int? SelectedPackingAccessoriesId { get; set; }
    }
}
