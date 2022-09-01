using System;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.AOP.Business
{
    public class Tbl_Issuance_Master
    {
        [Key]
        public long ID { get; set; }
        public long? challan_id { get; set; }
        public DateTime? creation_date { get; set; }
        public long? user_id { get; set; }
        public DateTime? Issuance_date { get; set; }
        public long? Issuance_status { get; set; }
    }
}
