using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class Mrpitem
    {
        public Mrpitem()
        {
            Fimmassociation = new HashSet<Fimmassociation>();
        }
        public int Id { get; set; }
        public int MrpitemCode { get; set; }
        public string Mname { get; set; }
        public int? Sku { get; set; }
        public string PurchaseUnit { get; set; }
        public string IssueUnit { get; set; }

        public virtual Mrpunits SkuNavigation { get; set; }
        public virtual ICollection<Fimmassociation> Fimmassociation { get; set; }
    }
}
