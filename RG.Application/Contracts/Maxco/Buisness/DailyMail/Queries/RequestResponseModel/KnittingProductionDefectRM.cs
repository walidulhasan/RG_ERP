using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.DailyMail.Queries.RequestResponseModel
{
    public class KnittingProductionDefectRM
    {
        public string production_date { get; set; }
        public string ShiftCode { get; set; }
        public double ttl_qty { get; set; }
        public int r_qty { get; set; }
        public double ttl_Length { get; set; }
        public long  Width { get; set; }
        public decimal ttl_NEEDLE_HOLE { get; set; }
        public decimal ttl_SINKER_MARK { get; set; }
        public decimal ttl_OIL_STAIN { get; set; }
        public decimal ttl_loop { get; set; }
        public decimal ttl_LYCRA_OUT { get; set; }
        public decimal ttl_MISSING_YARN { get; set; }
        public decimal ttl_STRIPE_YD { get; set; }
        public decimal ttl_YARN_CONTAM { get; set; }
        public decimal ttl_SLUB { get; set; }
        public decimal ttl_BARRIE { get; set; }
        public decimal ttl_PRESS_OFF { get; set; }
        public decimal ttl_NB { get; set; }
        public decimal ttl_LYCRA_DROP { get; set; }
        
    }
}
