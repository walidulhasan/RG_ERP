using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class Style_Transactions
    {
        public int ID { get; set; }
        [ForeignKey("Tansaction_Setup")]
        public byte TransactionTypeID { get; set; }
        public long StyleID { get; set; }
        public int UserID { get; set; }
        public DateTime Datetime { get; set; }

        public virtual Tansaction_Setup Tansaction_Setup { get; set; }
    }
}
