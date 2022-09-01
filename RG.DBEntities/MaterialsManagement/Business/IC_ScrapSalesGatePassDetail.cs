using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class IC_ScrapSalesGatePassDetail : DefaultTableProperties
    {[Key]
        public long ID { get; set; }
        public string ItemName { get; set; }
        public decimal Quantity { get; set; }
        public int UnitID { get; set; }
        public decimal? FirstWeight { get; set; }
        public decimal? SecondWeight { get; set; }
        public int? PaymentMode { get; set; }
        public string Remarks { get; set; }
        [ForeignKey("IC_ScrapSalesGatePassMaster")]
        public long? ScrapSalesGatePassID { get; set; }
        public decimal? Rate { get; set; }
        public virtual IC_ScrapSalesGatePassMaster IC_ScrapSalesGatePassMaster { get; set; }
        //
    }
}
