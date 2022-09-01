using RG.DBEntities.Embro.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Embro.Setup
{
    public class VoucherType_setup
    {
        public VoucherType_setup()
        {
            //SubVoucherTypeSetup = new HashSet<SubVoucherTypeSetup>();
            //Voucher = new HashSet<Voucher>();
            VoucherParameters = new HashSet<VoucherParameters>();
        }

        public int Id { get; set; }
        public string VoucherType { get; set; }
        public string Initials { get; set; }

        //public virtual ICollection<SubVoucherTypeSetup> SubVoucherTypeSetup { get; set; }
        //public virtual ICollection<Voucher> Voucher { get; set; }
        public virtual ICollection<VoucherParameters> VoucherParameters { get; set; }
    }
}
