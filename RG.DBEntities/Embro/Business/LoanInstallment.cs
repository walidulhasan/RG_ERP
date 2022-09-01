using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.Embro.Business
{
    public class LoanInstallment : DefaultTableProperties
    {
        public long LoanInstallmentID { get; set; }

        [ForeignKey("LoanMaster")]
        public int LoanID { get; set; }
        public decimal LoanCOAID { get; set; }
        public int InstallmentNo { get; set; }
        public DateTime InstallmentDate { get; set; }
        public decimal InstallmentAmount { get; set; }
        public decimal InterestAmount { get; set; }

        public virtual LoanMaster LoanMaster { get; set; }

    }
}
