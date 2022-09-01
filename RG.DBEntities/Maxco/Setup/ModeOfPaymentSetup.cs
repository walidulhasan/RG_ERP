using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class ModeOfPaymentSetup
    {
        public ModeOfPaymentSetup()
        {
            MaterialPomaster = new HashSet<MaterialPomaster>();
            TrimPomaster = new HashSet<TrimPomaster>();
        }
        public int Id { get; set; }
        public int Mopid { get; set; }
        public string Mopdesc { get; set; }

        public virtual ICollection<MaterialPomaster> MaterialPomaster { get; set; }
        public virtual ICollection<TrimPomaster> TrimPomaster { get; set; }
    }
}
