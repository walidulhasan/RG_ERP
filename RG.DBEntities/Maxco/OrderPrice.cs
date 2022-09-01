using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class OrderPrice
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int Currency { get; set; }
        public int PaymentMode { get; set; }
        public int QuotaCategory { get; set; }
        public int Lctype { get; set; }
        public int Comission { get; set; }
        public bool IsComissionInPrice { get; set; }
    }
}
