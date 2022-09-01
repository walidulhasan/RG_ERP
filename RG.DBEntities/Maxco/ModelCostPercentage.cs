using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class ModelCostPercentage
    {
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public int StyleId { get; set; }
        public int VersionId { get; set; }
        public double RoyaltyPercentage { get; set; }
        public double ProfitPercentage { get; set; }
        public double GeneralExpense { get; set; }
        public double? RejectionPercentage { get; set; }
        public double? PriceFactor { get; set; }
    }
}
