using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.MaterialsManagement.Setup
{
    public class IC_SampleCustomerType
    {
        [Key]
        public int ID { get; set; }
        public string CustomerType { get; set; }
        public string TypeDescription { get; set; }
        public bool IsActive { get; set; }
    }
}
