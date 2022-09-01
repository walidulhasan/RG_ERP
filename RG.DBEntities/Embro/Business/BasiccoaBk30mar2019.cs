using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class BasiccoaBk30mar2019
    {
        public decimal Id { get; set; }
        public string Description { get; set; }
        public string AccountCode { get; set; }
        public int? ParentId { get; set; }
        public int LevelId { get; set; }
        public byte Status { get; set; }
        public DateTime Rdate { get; set; }
        public long? NaturalAccountId { get; set; }
    }
}
