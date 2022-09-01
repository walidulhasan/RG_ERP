using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco.Business
{
    public class Plan_FabricBatchCommitment : DefaultTableProperties
    {
        public int FabricBatchCommitmentID { get; set; }
        [ForeignKey("Plan_StyleFabrics")]
        public int StyleFabricsID { get; set; }
        public DateTime ShipmentDate { get; set; }
        public DateTime CommitmentDate { get; set; }
        [NotMapped]
        public string CommitmentDateMsg { get { return CommitmentDate.ToString("dd-MMM-yyyy"); } }
        public decimal CommitmentQuantity { get; set; }

        public virtual Plan_StyleFabrics Plan_StyleFabrics { get; set; }
    }
}
