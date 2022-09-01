using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Embro.Business
{
    public class vw_ItemAccounts_OfCompany
    {
        public int AccountID { get; set; }
        public string AccountName { get; set; }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public int IdentificationID { get; set; }
        public string IdentificationName { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
