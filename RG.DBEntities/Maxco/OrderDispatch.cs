using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class OrderDispatch
    {
        public int Id { get; set; }
        public int ColorId { get; set; }
        public int CartonsDispatched { get; set; }
        public int ModelId { get; set; }
        public int NoOfCartonsAvailable { get; set; }
    }
}
