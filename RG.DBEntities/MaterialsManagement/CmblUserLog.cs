using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblUserLog
    {
       
        public long? UserId { get; set; }
        public string UserAction { get; set; }
        public int? DocumentTypeId { get; set; }
        [Key]
        public long? DocId { get; set; }
        public DateTime? ActionDateTime { get; set; }
    }
}
