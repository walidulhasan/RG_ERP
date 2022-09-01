using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class MaElement
    {
        public int Id { get; set; }
        public long StyleId { get; set; }
        public short StatusId { get; set; }
        public int? DescriptiveId { get; set; }
        public string ColorName { get; set; }
        public string Htmlcode { get; set; }
        public string PantoneNo { get; set; }
        public string PicturePath { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public short CategoryId { get; set; }
        public int OrderId { get; set; }
        public string Location { get; set; }
        public string TargetDate { get; set; }
        public string Size { get; set; }
        public short? VariantId { get; set; }
        public int? ColorId { get; set; }
        public string Material { get; set; }
        public string ThreadCount { get; set; }
        public string SizeColor { get; set; }
    }
}
