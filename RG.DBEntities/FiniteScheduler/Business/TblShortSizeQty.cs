using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblShortSizeQty
    {
        public int Id { get; set; }
        public long? OrderId { get; set; }
        public string Sizename { get; set; }
        public int? SizeQty { get; set; }
        public long? StocktransationId { get; set; }
    }
}
