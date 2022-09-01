using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public class tbl_KnittingStockTransaction 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long StockTransactionID { get; set; }
        [Key, Column(Order = 0)]
        public int DocumentTypeID { get; set; }
        public long DocumentNo { get; set; }
        [Key, Column(Order = 1)]
        [ForeignKey("tbl_KnittingRolls")]
        public long RollID { get; set; }
        public double RollWeight { get; set; }
        public double? Width { get; set; }
        public int? GSM { get; set; }
        public long JobID { get; set; }
        public tbl_KnittingRolls tbl_KnittingRolls { get; set; }
    }
}
