using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblMarkerSize
    {
        public int Id { get; set; }
        public string SizeName { get; set; }
        public int? SizeQty { get; set; }
        public int? StocktransationId { get; set; }
    }
}
