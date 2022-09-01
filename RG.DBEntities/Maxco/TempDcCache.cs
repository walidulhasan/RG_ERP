using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class TempDcCache
    {
        public int Id { get; set; }
        public string SessionId { get; set; }
        public int UserId { get; set; }
        public int Year { get; set; }
        public int Week { get; set; }
        public string PantoneNo { get; set; }
        public int FabAttributeInstanceId { get; set; }
        public int StyleId { get; set; }
        public decimal Kg { get; set; }
        public long Intx { get; set; }
    }
}
