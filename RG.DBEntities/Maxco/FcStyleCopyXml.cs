using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class FcStyleCopyXml
    {
        public int Id { get; set; }
        public long StyleId { get; set; }
        public long ParentStyleId { get; set; }
        public string StyleCopyXml { get; set; }
    }
}
