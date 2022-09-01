using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class IssuanceDetail
    {
        public int IssuanceDetailId { get; set; }
        public int IssuanceMasterId { get; set; }
        public int AttributeInstanceId { get; set; }
        public int ShellColorId { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
        public int AvailableQty { get; set; }
        public int IssuanceQty { get; set; }
    }
}
