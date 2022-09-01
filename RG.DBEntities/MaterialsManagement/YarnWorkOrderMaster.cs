using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnWorkOrderMaster
    {
        public YarnWorkOrderMaster()
        {
            YarnReturnfromWorkOrder = new HashSet<YarnReturnfromWorkOrder>();
            YarnWorkOrderDeliverySchedule = new HashSet<YarnWorkOrderDeliverySchedule>();
            YarnWorkOrderDetail = new HashSet<YarnWorkOrderDetail>();
        }
        [Key]
        public long WorkOrderId { get; set; }
        public int? YarnMrp { get; set; }
        public long? YarnAttributeInstanceId { get; set; }
        public int ContractStatus { get; set; }
        public long KnitterId { get; set; }
        public string WorkOrderName { get; set; }
        public int? ProgramTypeId { get; set; }
        public int? OrderId { get; set; }
        public string OrderNo { get; set; }
        public DateTime? WorkOrderDate { get; set; }
        public decimal? RatePerKg { get; set; }
        public string ModeOfPayment { get; set; }
        public string TermOfPayment { get; set; }
        public string Comments { get; set; }
        public decimal? TotalQty { get; set; }
        public int? WorkOrderType { get; set; }
        public decimal? BalanceQty { get; set; }
        public long? Destination { get; set; }

        public virtual ICollection<YarnReturnfromWorkOrder> YarnReturnfromWorkOrder { get; set; }
        public virtual ICollection<YarnWorkOrderDeliverySchedule> YarnWorkOrderDeliverySchedule { get; set; }
        public virtual ICollection<YarnWorkOrderDetail> YarnWorkOrderDetail { get; set; }
    }
}
