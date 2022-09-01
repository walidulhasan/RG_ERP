using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.MaterialsManagement.DBViews
{
    public class Vw_Currency
    {
        public int ID { get; set; }
        public string countryName { get; set; }
        public string currencyName { get; set; }
        public string Symbol { get; set; }
        public string ShortName { get; set; }
        public byte Status { get; set; }
        public int CreatedBy { get; set; }
    }
}
