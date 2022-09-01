using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciUniqueBarCodeDetail
    {
        public int Id { get; set; }
        public long? CartonSetupDetailId { get; set; }
        public long? CartonSetupMasterId { get; set; }
        public string UniqueBarCode { get; set; }
        public DateTime? Date { get; set; }
    }
}
