using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class Sticker
    {
        public int Id { get; set; }
        public int StickerTypeId { get; set; }
        public int ItemSourceId { get; set; }
        public int NumberOfPlacement { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int UnitId { get; set; }
        public string Comments { get; set; }
        public int? Code { get; set; }
        public int? Warning { get; set; }
        public int? Barcode { get; set; }
        public int OrderId { get; set; }
        public int ImageId { get; set; }
        public int PrintImageId { get; set; }
        public int MaterialId { get; set; }
        public int? SelectedPackingAccessoriesId { get; set; }
    }
}
