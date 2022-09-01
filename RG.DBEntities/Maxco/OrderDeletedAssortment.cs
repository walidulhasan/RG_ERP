using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class OrderDeletedAssortment
    {
        public int Id { get; set; }
        public short UserId { get; set; }
        public DateTime DeletedOn { get; set; }
        public int ShippmentId { get; set; }
        public byte PackingAssortmentCombinationId { get; set; }
        public short NoOfPieces { get; set; }
    }
}
