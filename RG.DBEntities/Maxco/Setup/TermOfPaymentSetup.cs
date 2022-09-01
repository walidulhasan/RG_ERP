using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class TermOfPaymentSetup
    {
        public TermOfPaymentSetup()
        {
            MaterialPomaster = new HashSet<MaterialPomaster>();
            TrimPomaster = new HashSet<TrimPomaster>();
        }
        public int Id { get; set; }
        public int Topid { get; set; }
        public string Topdesc { get; set; }

        public virtual ICollection<MaterialPomaster> MaterialPomaster { get; set; }
        public virtual ICollection<TrimPomaster> TrimPomaster { get; set; }
    }
}
