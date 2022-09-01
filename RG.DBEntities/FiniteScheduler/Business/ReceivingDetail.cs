using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class ReceivingDetail
    {
        public int ReceivingDetailId { get; set; }
        public int ReceivingMasterId { get; set; }
        public int AttributeInstanceId { get; set; }
        public int ShellColorId { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
        public int AvailableQty { get; set; }
        public int ReceivedQty { get; set; }
    }
}
