using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class VacumTable
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public string Serial { get; set; }
        public string Specification { get; set; }
        public string Origin { get; set; }
        public string PurchaseYear { get; set; }
        public string Status { get; set; }
    }
}
