  using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class Accounts
    {
        public decimal CatID { get; set; }
        public string CatName { get; set; }
        public decimal SubcatID { get; set; }
        public string SubcatName { get; set; }
        public decimal BGID { get; set; }
        public string BGname { get; set; }
        public decimal NGID { get; set; }
        public string Ngname { get; set; }
        public decimal IID{ get; set; }
        public string IName { get; set; }
        public decimal ItemID { get; set; }
        public string ItemName { get; set; }
    }
}
