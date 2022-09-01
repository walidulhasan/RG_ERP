using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Embro.Setup
{
    public partial class SupplierDetail 
    {

        public int ID { get; set; }
        public decimal SupplierID { get; set; }
        public string ContactPerson { get; set; }
        public string Designation { get; set; }
        public string Division { get; set; }
        public string CellNumber { get; set; }
        public string ContactEmail { get; set; }
        public decimal UID { get; set; }
    }
}
