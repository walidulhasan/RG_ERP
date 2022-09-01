using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Embro.Setup
{
    public class tbl_Currency_Setup
    {
        public tbl_Currency_Setup()
        {
            tbl_currency_Detail = new List<tbl_Currency_Detail>();
        }
        public long ID { get; set; }
        public string countryName { get; set; }
        public string currencyName { get; set; }
        public string Symbol { get; set; }
        public string ShortName { get; set; }
        public byte? Status { get; set; }

        public List<tbl_Currency_Detail> tbl_currency_Detail { get; set; }
    }
}
