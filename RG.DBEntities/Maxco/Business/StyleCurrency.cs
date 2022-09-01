using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Business
{
  public partial  class StyleCurrency
    {
        public int ID { get; set; }
        public long? StyleID { get; set; }
        public int? CurrencyID { get; set; }
        public int? InputCurrencyID { get; set; }
    }
}
