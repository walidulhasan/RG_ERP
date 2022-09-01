using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class FsRejectedFabric
    {
        public FsRejectedFabric()
        {
            FsRejectedFabricRejections = new HashSet<FsRejectedFabricRejections>();
        }

        public int Id { get; set; }
        public int OrderId { get; set; }
        public int StyleId { get; set; }
        public int? ColorId { get; set; }
        public int? SizeId { get; set; }
        public int AttributeInstanceId { get; set; }
        public int Quantity { get; set; }
        public double PerPieceConsumption { get; set; }
        public double? TotalKg { get; set; }
        public double? BalanceKg { get; set; }
        public int? Status { get; set; }
        public int? RejectionDetailId { get; set; }

        public virtual ICollection<FsRejectedFabricRejections> FsRejectedFabricRejections { get; set; }
    }
}
