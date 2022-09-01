using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class GreigeGateReceivingMaster
    {
        [Key]
        public int Grid { get; set; }
        public string DeliveryChallan { get; set; }
        public string DeliveryPerson { get; set; }
        public string VehicleNo { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Ykncid { get; set; }
        public string Grno { get; set; }
        public double QuantityInKg { get; set; }
        public int? QuantityInPcs { get; set; }
        public int? NoOfRolls { get; set; }
        public int Status { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? UserId { get; set; }
    }
}
