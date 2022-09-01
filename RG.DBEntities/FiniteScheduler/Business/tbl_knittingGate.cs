using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.FiniteScheduler.Business
{
  public partial  class tbl_knittingGate
    {
        public tbl_knittingGate()
        {
            tbl_GateKnittingRolls = new HashSet<tbl_GateKnittingRolls>();
        }
        [Key]
        public long ID { get; set; }
        public int NoOfRolls { get; set; }
        public DateTime Date { get; set; }
        public string VehicleNo { get; set; }
        public string DeliveryPerson { get; set; }
        public int JobID { get; set; }
        public int YKNC { get; set; }
        public string DeliveryChallan { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public ICollection<tbl_GateKnittingRolls> tbl_GateKnittingRolls { get; set; }
    }
}
