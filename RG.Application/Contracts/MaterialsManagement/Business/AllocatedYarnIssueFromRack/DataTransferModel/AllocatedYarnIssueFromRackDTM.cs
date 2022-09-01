using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.AllocatedYarnIssueFromRack.DataTransferModel
{
    public class AllocatedYarnIssueFromRackDTM
    {       
        public int SubRackID { get; set; }
        public int RackAllocationID { get; set; }
        public decimal IssuedQuantity { get; set; }
    }
}
