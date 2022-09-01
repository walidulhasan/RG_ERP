using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class SketchFabricImageComments
    {
        public int Id { get; set; }
        public string CommentId { get; set; }
        public string Comment { get; set; }
        public double X1 { get; set; }
        public double X2 { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public long? ColorSetId { get; set; }
        public byte? ImageId { get; set; }
        public string PicturePath { get; set; }
        public int? Variation { get; set; }
        public int? ImageCategoryId { get; set; }
        public long? StyleId { get; set; }
        public string Htmlcode { get; set; }
        public int? Xaxis { get; set; }
        public int? Yaxis { get; set; }
    }
}
