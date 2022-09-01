using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SfsLayoutRequisition
    {
        public long ReqId { get; set; }
        public long? Lineid { get; set; }
        public string LineNo { get; set; }
        public long? Orderid { get; set; }
        public string Orderno { get; set; }
        public long? Styleid { get; set; }
        public string Styleno { get; set; }
        public long? Colorid { get; set; }
        public string Colorname { get; set; }
        public DateTime? Creationdate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public long? Userid { get; set; }
    }
}
