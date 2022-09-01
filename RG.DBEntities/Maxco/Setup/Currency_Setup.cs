using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Setup
{
    public class Currency_Setup
    {
        public Currency_Setup()
        {
            OrderSelectedStyle = new HashSet<OrderSelectedStyle>();
        }

        public int ID { get; set; }
        public string Description { get; set; }
        public double? ConversionRate { get; set; }
        public string CurrencySymbol { get; set; }
        public int? IsDefaultCurrency { get; set; }
        public int? IsBaseCurrency { get; set; }
        public int? FID { get; set; }

        public virtual ICollection<OrderSelectedStyle> OrderSelectedStyle { get; set; }
    }

}
