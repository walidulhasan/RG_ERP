using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class OrderClosureLog
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public bool? IsTrimTransferred { get; set; }
        public bool? IsGrollTransferred { get; set; }
        public bool? IsDrollTransferred { get; set; }
    }
}
