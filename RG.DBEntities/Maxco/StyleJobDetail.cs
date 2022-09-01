using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class StyleJobDetail
    {
        public long Id { get; set; }
        public long StyleJobId { get; set; }
        public string BodyPart { get; set; }
        public long StyleId { get; set; }
        public long? ObjectId { get; set; }
    }
}
