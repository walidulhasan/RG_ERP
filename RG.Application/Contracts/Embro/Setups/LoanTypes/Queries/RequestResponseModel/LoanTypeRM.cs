using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Setups.LoanTypes.Queries.RequestResponseModel
{
    public class LoanTypeRM
    {
        public int ID { get; set; }
        public string LoanTypeName { get; set; }
        public string LoanTypeShortName { get; set; }
    }
}
