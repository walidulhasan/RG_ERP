using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class HangerImageComments
    {
        public int Id { get; set; }
        public string CommentId { get; set; }
        public string Comment { get; set; }
        public double X1 { get; set; }
        public double X2 { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public long ObjectId { get; set; }
        public int ImageId { get; set; }
    }
}
