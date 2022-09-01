using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class CustomerBankInfo
    {
        public int CustomerId { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string AccountNumber { get; set; }
    }
}
