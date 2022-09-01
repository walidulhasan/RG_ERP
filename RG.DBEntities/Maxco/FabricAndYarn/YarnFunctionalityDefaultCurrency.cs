using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class YarnFunctionalityDefaultCurrency
    {
        public short Id { get; set; }
        public short YarnFunctionalityId { get; set; }
        public short DefaultCurrencyId { get; set; }
    }
}
