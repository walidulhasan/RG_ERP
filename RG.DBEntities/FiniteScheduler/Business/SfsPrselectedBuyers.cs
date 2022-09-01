using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SfsPrselectedBuyers
    {
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public string Buyer { get; set; }
        public int SfsPrsid { get; set; }
    }
}
