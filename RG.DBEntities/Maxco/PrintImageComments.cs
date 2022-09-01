using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class PrintImageComments
    {
        public int Id { get; set; }
        public int PrintImageColorId { get; set; }
        public string CommentId { get; set; }
        public string Comment { get; set; }
        public double X1 { get; set; }
        public double X2 { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
    }
}
