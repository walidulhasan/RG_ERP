using RG.DBEntities.Embro.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.Embro.Setup
{
   public class CBM_Bank
    {
        public CBM_Bank()
        {
            //CbmBankFacility = new HashSet<CbmBankFacility>();
            CBM_Branch = new HashSet<CBM_Branch>();
        }
        [Key]
        public int BankID { get; set; }
        public string BankName { get; set; }
        public int? BankStatus { get; set; }
        public decimal? CompanyID { get; set; }
        public string Abbr { get; set; }

        public virtual BasicCOA BasicCOA { get; set; }
        //public virtual ICollection<CbmBankFacility> CbmBankFacility { get; set; }
        public virtual ICollection<CBM_Branch> CBM_Branch { get; set; }
    }
}
