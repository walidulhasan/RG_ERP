using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WfsLotConfirmationAssociation
    {
        public int? LotId { get; set; }
        public int? ConformationId { get; set; }
    }
}
