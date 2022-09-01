using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.Maxco
{
   public class SelectedElement_Transactions
    {
        [Key]
        public int StyleID { get; set; }
        public int OrderStyleElementID { get; set; }
        public int TransactionTypeID { get; set; }
        public int UserID { get; set; }
        public DateTime Datetime { get; set; }
    }
}
