using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.Embro.Setup
{
    public class LoanType:DefaultTableProperties
    {
        public int ID { get; set; }
        public string LoanTypeName { get; set; }
        public string LoanTypeShortName { get; set; }
    }
}
