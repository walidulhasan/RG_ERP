using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.DBViews
{
    public class vw_DyeingContractBalanceOrder
    {
        public int BuyerID { get; set; }
        public string BuyerName { get; set; }
        public int CollectionID { get; set; }
        public string CollectionName { get; set; }
        public string OrderNo { get; set; }
        public long OrderID { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
