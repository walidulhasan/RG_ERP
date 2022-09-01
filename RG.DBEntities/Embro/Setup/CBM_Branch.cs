using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.Embro.Setup
{
   public class CBM_Branch
    {
        public CBM_Branch()
        {
            CBM_BankAccountSetup = new HashSet<CBM_BankAccountSetup>();
        }
        [Key]
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public string BranchAddress { get; set; }
        public int? BankID { get; set; }

        public virtual CBM_Bank Bank { get; set; }
        public virtual ICollection<CBM_BankAccountSetup> CBM_BankAccountSetup { get; set; }
    }
}
