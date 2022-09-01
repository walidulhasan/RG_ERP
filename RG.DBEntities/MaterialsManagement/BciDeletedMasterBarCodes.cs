using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciDeletedMasterBarCodes
    {
        [Key]
        public int MasterId { get; set; }
        public string MasterBarCode { get; set; }
        public int? UserId { get; set; }
        public DateTime? DeletionDate { get; set; }
    }
}
