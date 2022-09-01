using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblKnittingStockTransaction27thMar2014
    {
        public long StockTransactionId { get; set; }
        public int DocumentTypeId { get; set; }
        public long DocumentNo { get; set; }
        public long RollId { get; set; }
        public double RollWeight { get; set; }
        public double? Width { get; set; }
        public int? Gsm { get; set; }
        public long JobId { get; set; }
    }
}
