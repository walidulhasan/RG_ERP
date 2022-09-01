using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class SelectedElementTransactions
    {
      //  public int Id { get; set; }
        public int StyleId { get; set; }
        public byte OrderStyleElementId { get; set; }
        public byte TransactionTypeId { get; set; }
        public int UserId { get; set; }
        public DateTime Datetime { get; set; }
    }
}
