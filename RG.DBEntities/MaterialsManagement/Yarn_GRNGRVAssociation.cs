using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class Yarn_GRNGRVAssociation
    {
        [Key]
        public long AssociationID { get; set; }
        public string GRN { get; set; }
        public string GRV { get; set; }
        public long POID { get; set; }
        public string PONumber { get; set; }
        public long UserID { get; set; }
    }
}
