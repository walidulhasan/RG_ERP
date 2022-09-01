using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Setups.CBM_PrintedCheques.Commands.DataTransferModel
{
    public class UpdateChequeStatusDTM
    {
        public long ChqID { get; set; }
        public int UpdatedStatusID { get; set; }
        public DateTime ClearingDate { get; set; }
    }
}
