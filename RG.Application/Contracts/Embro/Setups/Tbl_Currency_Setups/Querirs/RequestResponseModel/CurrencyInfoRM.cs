using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Setups.Tbl_Currency_Setups.Querirs.RequestResponseModel
{
    public class CurrencyInfoRM
    {
        public long ID { get; set; }
        public string CountryName { get; set; }
        public string CurrencyName { get; set; }
        public string Symbol { get; set; }
        public string ShortName { get; set; }
        public CurrencyRateRM CurrencyRate { get; set; }

    }
    public class CurrencyRateRM
    {
        public int ID { get; set; }
        public decimal? RateInBDT { get; set; }
        public DateTime? Date { get; set; }
        public long? CurId { get; set; }
    }
}
