using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.FabricAndYarn;
using RG.DBEntities.Maxco.Trims;

namespace RG.DBEntities.Maxco
{
    public partial class TrimPodeliveries
    {
        public int Id { get; set; }
        public int TpodeliveriesId { get; set; }
        public int Tpodid { get; set; }
        public int DayId { get; set; }
        public double Quantity { get; set; }
        public int ReceivingStoreId { get; set; }

        public virtual StoreSetup ReceivingStore { get; set; }
        public virtual TrimPodetail Tpod { get; set; }
    }
}
