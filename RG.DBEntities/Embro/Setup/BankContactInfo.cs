using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Embro.Setup
{
   public partial class BankContactInfo
    {
        public int ID { get; set; }
        public decimal AccountID { get; set; }
        public string ContactName { get; set; }
        public string Designation { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }
    }
}
