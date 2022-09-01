using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class DeletedPolyBag
    {
        public int Id { get; set; }
        public short UserId { get; set; }
        public DateTime DeletedOn { get; set; }
        public bool IsSinglePiece { get; set; }
    }
}
