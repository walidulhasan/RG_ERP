using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class BuyerWisePercentageSetup
    {
        public long Id { get; set; }
        public byte BuyerId { get; set; }
        public double RoyaltyPercentage { get; set; }
        public double ProfitPercentage { get; set; }
        public double GeneralExpense { get; set; }

        public virtual Buyer_Setup Buyer { get; set; }
    }
}
