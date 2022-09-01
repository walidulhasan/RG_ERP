using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.MaterialsManagement.Setup
{
    public class IC_Department
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public long AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
    }
}
