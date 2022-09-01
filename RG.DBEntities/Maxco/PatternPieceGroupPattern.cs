using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class PatternPieceGroupPattern
    {
        public int Id { get; set; }
        public int PatternId { get; set; }
        public int GroupId { get; set; }
        public int SpecificationId { get; set; }
    }
}
