using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class MM_ListAttributeInstanceID
    {
        [Key, Column(Order = 0)]
        public long ListAttInstanceID { get; set; }
        [Key, Column(Order = 1)]
        public long AttributeInstanceID { get; set; }
    }
}
