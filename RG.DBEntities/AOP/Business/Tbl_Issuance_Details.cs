using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.AOP.Business
{
    public class Tbl_Issuance_Details
    {
        [Key]
        public long ID { get; set; }
        public long? Transation_ID { get; set; }
        public long? fab_id { get; set; }
        public decimal? fabric_qty { get; set; }
        public long? roll_qty { get; set; }
    }
}
