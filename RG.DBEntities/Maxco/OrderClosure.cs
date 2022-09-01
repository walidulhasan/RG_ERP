using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class OrderClosure
    {
        public int Id { get; set; }
        public int DomainId { get; set; }
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
    }
}
