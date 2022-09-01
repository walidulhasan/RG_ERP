using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class IC_GatePassAccountReview:DefaultTableProperties
    {
        [Key]
        public int ID { get; set; }
        public long GatePassID { get; set; }
        public int PaymentTypeID { get; set; }
        public string Remarks { get; set; }
    }
}
