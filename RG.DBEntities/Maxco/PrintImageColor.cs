using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class PrintImageColor
    {
        public int Id { get; set; }
        public int ImageId { get; set; }
        public long ObjectId { get; set; }
        public long ColorSetId { get; set; }
    }
}
