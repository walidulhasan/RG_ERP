using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public class AssetDepriciationHistory:DefaultTableProperties
    {
        public int ID { get; set; }
        //[ForeignKey("AssetInfo")]
        public int AssetID { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? FiscalYear { get; set; }
        public decimal Rate { get; set; }
        public decimal DepricationValue { get; set; }
        public string DepricationType { get; set; }
        //public virtual AssetInfo AssetInfo { get; set; }
       
    }
}
