using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblMarkerCreate
    {
        public long Id { get; set; }
        public DateTime? Date { get; set; }
        public long? Buyerid { get; set; }
        public string Buyername { get; set; }
        public string Color { get; set; }
        public string Gsm { get; set; }
        public string Ftype { get; set; }
        public string Fquality { get; set; }
        public string Fcomposition { get; set; }
        public long? SizeRadioId { get; set; }
        public string SizeRadio { get; set; }
        public decimal? FabricWidthFinish { get; set; }
        public decimal? FabricWithOutside { get; set; }
        public DateTime? Creationdate { get; set; }
        public long? Lotid { get; set; }
        public string Lotno { get; set; }
        public long? Orderid { get; set; }
        public string Orderno { get; set; }
        public decimal? MLength { get; set; }
        public long? Userid { get; set; }
        public string Username { get; set; }
        public long? Styleid { get; set; }
    }
}
