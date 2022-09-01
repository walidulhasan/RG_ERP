using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciDeletedSingleBarCodes
    {
        public int Id { get; set; }
        public string SingleBarCode { get; set; }
        public int MasterId { get; set; }
    }
}
