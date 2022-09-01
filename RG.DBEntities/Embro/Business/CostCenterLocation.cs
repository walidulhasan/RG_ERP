using RG.DBEntities.Embro.Setup;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Embro.Business
{
    public partial class CostCenterLocation 
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("CostCenter")]
        public decimal CostCenterID { get; set; }
        [ForeignKey("Location")]
        public decimal LocationID { get; set; }

        public virtual BasicCOA CostCenter { get; set; }
        public virtual Location Location { get; set; }
    }
}