using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class CoaforCostSheet
    {
        public int Id { get; set; }
        public int? Coaid { get; set; }
        public string Description { get; set; }
        public int? CompanyId { get; set; }
    }
}
