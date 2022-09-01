using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.Embro.Setup
{
    public class CBM_Currency
    {
        public CBM_Currency()
        {
            CBM_BankAccountSetup = new HashSet<CBM_BankAccountSetup>();
        }
        [Key]
        public int CurID { get; set; }
        public string CurName { get; set; }
        public string CurAbbreviation { get; set; }
        public string CurSign { get; set; }

        public virtual ICollection<CBM_BankAccountSetup> CBM_BankAccountSetup { get; set; }
    }
}
