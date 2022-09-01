using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Business
{
  public  class Yarn_KnittingContractDeliverySchedule
    {
        [Key]
        public long KNContractDelSchdID { get; set; }
        [ForeignKey("Yarn_KnittingContractMaster")]
        public long YarnKNContractID { get; set; }
        public DateTime DeliveryDate { get; set; }
        public double Weight { get; set; }
        public int GreigeDeliveryLocationID { get; set; }
        public string Sizes { get; set; }
        public double? RatePerPieces { get; set; }

        public virtual Yarn_KnittingContractMaster YarnKncontract { get; set; }
    }
}
