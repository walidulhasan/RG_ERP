using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class PatternPieceGroup
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int StyleId { get; set; }
    }
}
