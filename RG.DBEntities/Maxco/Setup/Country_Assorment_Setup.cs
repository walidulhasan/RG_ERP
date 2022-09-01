using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.Maxco.Setup
{
    public class Country_Assorment_Setup
    {
        [Key]
        public long Country_ID { get; set; }
        public long? Country_Buyer { get; set; }
        public string Country_Name { get; set; }
        public string Country_Abbrevation { get; set; }
        public long? Country_SetupID { get; set; }
    }
}
