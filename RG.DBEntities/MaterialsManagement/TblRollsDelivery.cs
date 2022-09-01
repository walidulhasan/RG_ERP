using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class TblRollsDelivery
    {
        public long? Sno { get; set; }
        public int? OrderId { get; set; }
        public long? Rollid { get; set; }
        public string Rollno { get; set; }
        public double? Quantity { get; set; }
        public long DcgattributeInstanceId { get; set; }
        public int Dcid { get; set; }
        public long StockGattributeInstanceId { get; set; }
        public string PantoneNo { get; set; }
        public long? PantoneId { get; set; }
        public string Ftype { get; set; }
        public string Fquality { get; set; }
        public string Fcompoistion { get; set; }
        public string Gsm { get; set; }
        public long StockTransactionid { get; set; }
        public int Delivery { get; set; }
        public int IssuanceAgainstDyeingContractDetaiId { get; set; }
    }
}
